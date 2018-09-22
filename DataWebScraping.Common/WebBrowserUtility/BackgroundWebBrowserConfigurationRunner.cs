using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataWebScraping.Common.Configuration;
using DataWebScraping.Common.DataWebScraperStep;
using DataWebScraping.Common.DataWebScraperStep.Converter;
using DataWebScraping.Common.IteratorUtility;
using DataWebScraping.Util;

namespace DataWebScraping.Common.WebBrowserUtility
{
    public class BackGroundWebBrowserConfigurationRunner : IWebBrowserConfigurationRunner
    {        
        public IDataWebScraperConfiguration DataWebScraperConfiguration { get; private set; }
        internal IDataWebScraperSelfIterator DataWebScraperSelfIterator { get; private set; }
        public WebBrowser WebBrowser { get; private set; }
        public IDataWebScraperToRunnableConverter DataWebScraperToRunnableConverter { get; }
        public WebBrowserFactory WebBrowserFactory { get; }
        public Thread MainThread { get; private set; }
        private object Locker { get; }

        public BackGroundWebBrowserConfigurationRunner(IDataWebScraperToRunnableConverter dataWebScraperToRunnableConverter, WebBrowserFactory webBrowserFactory)
        {
            DataWebScraperToRunnableConverter = dataWebScraperToRunnableConverter;
            WebBrowserFactory = webBrowserFactory;
        }

        delegate void DisposeCallback();

        public event EventHandler WebBrowserConfigurationRunWascompleted;

        public void Run(IDataWebScraperConfiguration dataWebScraperConfiguration)
        {
            DataWebScraperConfiguration = dataWebScraperConfiguration;
            MainThread = new Thread(() => {
                WebBrowser = WebBrowserFactory.GetWebBrowser();
                DataWebScraperSelfIterator = new DataWebScraperSelfIterator(new DataWebScraperToRunnableConverter(new DataWebScraperStep.Strategy.DataWebScraperStepStrategyFactory()), WebBrowser);
                DataWebScraperSelfIterator.SetElements(DataWebScraperConfiguration.DataWebScraperSteps.OrderBy(s => s.StepSequence));
                DataWebScraperSelfIterator.Iterate();
                DataWebScraperSelfIterator.DataWebScraperSelfIteratorWasComplete += DataWebScraperSelfIterator_DataWebScraperSelfIteratorWasComplete;
                Application.Run();
            });
            MainThread.SetApartmentState(ApartmentState.STA);
            MainThread.Start();                       
        }

        private void DataWebScraperSelfIterator_DataWebScraperSelfIteratorWasComplete(object sender, EventArgs e)
        {
            KillMainThread();
        }

        [SecurityPermissionAttribute(SecurityAction.Demand, ControlThread = true)]
        private void KillMainThread()
        {
            DisposeWebBrowser();

            if (MainThread.IsAlive)
            {
                MainThread.Abort();
            }
        }

        private void DisposeWebBrowser()
        {
            if (!WebBrowser.IsDisposed)
            {
                if (WebBrowser.InvokeRequired)
                {
                    DisposeCallback d = new DisposeCallback(DisposeWebBrowser);
                    WebBrowser.Invoke(d);
                }
                else
                {
                    WebBrowser.Dispose();
                }
            }
        }
    }
}
