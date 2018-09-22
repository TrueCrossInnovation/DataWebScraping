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
    public class ThreadLockWebBrowserConfigurationRunner : IWebBrowserConfigurationRunner
    {
        private bool _dataWebScraperSelfIteratorWasCompleted;
        public IDataWebScraperConfiguration DataWebScraperConfiguration { get; private set; }
        internal IDataWebScraperSelfIterator DataWebScraperSelfIterator { get; private set; }
        public WebBrowser WebBrowser { get; private set; }
        public IDataWebScraperToRunnableConverter DataWebScraperToRunnableConverter { get; }
        public WebBrowserFactory WebBrowserFactory { get; }
        public Thread MainThread { get; private set; }
        private object Locker { get; }

        public ThreadLockWebBrowserConfigurationRunner(IDataWebScraperToRunnableConverter dataWebScraperToRunnableConverter, WebBrowserFactory webBrowserFactory)
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
                _dataWebScraperSelfIteratorWasCompleted = false;
                WebBrowser = WebBrowserFactory.GetWebBrowser();
                DataWebScraperSelfIterator = new DataWebScraperSelfIterator(new DataWebScraperToRunnableConverter(new DataWebScraperStep.Strategy.DataWebScraperStepStrategyFactory()), WebBrowser);
                DataWebScraperSelfIterator.SetElements(DataWebScraperConfiguration.DataWebScraperSteps.OrderBy(s => s.StepSequence));
                //DataWebScraperSelfIterator.Iterate();
                //DataWebScraperSelfIterator.DataWebScraperSelfIteratorWasComplete += DataWebScraperSelfIterator_DataWebScraperSelfIteratorWasComplete;
                Application.Run();
            });
            MainThread.SetApartmentState(ApartmentState.STA);
            MainThread.Start();

            //while(!_dataWebScraperSelfIteratorWasCompleted)
            //{
            //Thread.Sleep(1000);
            //}

            Thread.Sleep(5000);
            KillMainThread();
        }

        private void DataWebScraperSelfIterator_DataWebScraperSelfIteratorWasComplete(object sender, EventArgs e)
        {
            _dataWebScraperSelfIteratorWasCompleted = true;
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
