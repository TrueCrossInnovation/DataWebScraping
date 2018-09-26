using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataWebScraping.Common.Configuration;
using DataWebScraping.Common.DataWebScraperStep.Converter;
using DataWebScraping.Common.ThreadUtility;
using DataWebScraping.Util;

namespace DataWebScraping.Common.WebBrowserUtility
{
    public abstract class AbstractWebBrowserConfigurationRunner : IWebBrowserConfigurationRunner
    {
        private IThreadWrapper _threadWrapper;
        private bool _webBrowserConfigurationRunnerProcessorWascompleted;
        private WebBrowser _webBrowser;

        internal ThreadWrapperFactory ThreadWrapperFactory { get; }
        internal WebBrowserFactory WebBrowserFactory { get; }

        internal WebBrowserConfigurationRunnerProcessor WebBrowserConfigurationRunnerProcessor { get; }
        internal WebBrowserDisposerFactory WebBrowserDisposerFactory { get; }
        internal abstract bool WaitForProcessToBeCompleted { get; }
        public event EventHandler WebBrowserConfigurationRunWascompleted;

        internal AbstractWebBrowserConfigurationRunner(ThreadWrapperFactory threadWrapperFactory, WebBrowserFactory webBrowserFactory, WebBrowserConfigurationRunnerProcessor webBrowserConfigurationRunnerProcessor, WebBrowserDisposerFactory webBrowserDisposerFactory)
        {
            WebBrowserFactory = webBrowserFactory;
            ThreadWrapperFactory = threadWrapperFactory;
            WebBrowserConfigurationRunnerProcessor = webBrowserConfigurationRunnerProcessor;
            WebBrowserDisposerFactory = webBrowserDisposerFactory;
        }



        public void Run(IDataWebScraperConfiguration dataWebScraperConfiguration)
        {
            _webBrowserConfigurationRunnerProcessorWascompleted = false;
            WebBrowserConfigurationRunnerProcessor.WebBrowserConfigurationRunnerProcessorWasCompleted += WebBrowserConfigurationRunnerProcessor_WebBrowserConfigurationRunnerProcessorWasCompleted;

            _threadWrapper = ThreadWrapperFactory.GetThreadWrapper(new ParameterizedThreadStart(ProcessDataWebScraperconfigurationInWebBrowser));
            _threadWrapper.SetApartmentState(ApartmentState.STA);
            _threadWrapper.Start(dataWebScraperConfiguration);
            if (WaitForProcessToBeCompleted)
            {
                while (!_webBrowserConfigurationRunnerProcessorWascompleted)
                {
                    Thread.Sleep(1000);
                }
            }
        }

        private void WebBrowserConfigurationRunnerProcessor_WebBrowserConfigurationRunnerProcessorWasCompleted(object sender, EventArgs e)
        {
            WebBrowserConfigurationRunnerProcessor.WebBrowserConfigurationRunnerProcessorWasCompleted -= WebBrowserConfigurationRunnerProcessor_WebBrowserConfigurationRunnerProcessorWasCompleted;
            WebBrowserConfigurationRunWascompleted?.Invoke(this, null);            
            WebBrowserDisposer webBrowserDisposer = WebBrowserDisposerFactory.GetWebBrowserDisposer(_webBrowser);
            webBrowserDisposer.Dispose();
            ThreadWrapperKiller.Instance().Kill(_threadWrapper);
        }

        internal void ProcessDataWebScraperconfigurationInWebBrowser(object param)
        {
            var dataWebScraperConfiguration = param as IDataWebScraperConfiguration;
            if (dataWebScraperConfiguration != null)
            {
                _webBrowser = WebBrowserFactory.GetWebBrowser();
                WebBrowserWasCreated(_webBrowser);
                WebBrowserConfigurationRunnerProcessor.StartProcess(_webBrowser, dataWebScraperConfiguration);
            }
        }

        internal virtual void WebBrowserWasCreated(WebBrowser webBrowser) { }

    }
}
