using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataWebScraping.Common.Configuration;
using DataWebScraping.Common.DataWebScraperStep;
using DataWebScraping.Common.DataWebScraperStep.Converter;
using DataWebScraping.Util;

namespace DataWebScraping.Common.WebBrowserUtility
{
    public class WebBrowserConfigurationRunner : IWebBrowserConfigurationRunner
    {
        public IDataWebScraperConfiguration DataWebScraperConfiguration { get; private set; }
        public WebBrowser WebBrowser { get; private set; }
        public IDataWebScraperToRunnableConverter DataWebScraperToRunnableConverter { get; }
        public Thread MainThread { get; }

        public WebBrowserConfigurationRunner(IDataWebScraperToRunnableConverter dataWebScraperToRunnableConverter, WebBrowserFactory webBrowserFactory)
        {
            DataWebScraperToRunnableConverter = dataWebScraperToRunnableConverter;            
            MainThread = new Thread(()=>StartWebBrowserNavigation(webBrowserFactory));
            MainThread.SetApartmentState(ApartmentState.STA);
            MainThread.Start();
        }

        private void StartWebBrowserNavigation(WebBrowserFactory webBrowserFactory)
        {
            WebBrowser = webBrowserFactory.GetWebBrowser();
            WebBrowser.DocumentCompleted += WebBrowser_DocumentCompleted;
        }
        
        private void WebBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            WebBrowserConfigurationRunner webBrowserconfigurationRunner = sender as WebBrowserConfigurationRunner;

            if(webBrowserconfigurationRunner == null)
            {
                throw new NullReferenceException($"sender is not {typeof(WebBrowserConfigurationRunner)}");
            }

            foreach (IDataWebScraperStep dataWebScraperStep in webBrowserconfigurationRunner.DataWebScraperConfiguration.DataWebScraperSteps)
            {
                IDataWebScraperStepRunnable dataWebScraperStepRunnable = DataWebScraperToRunnableConverter.Convert(dataWebScraperStep);
                dataWebScraperStepRunnable.Run(webBrowserconfigurationRunner.WebBrowser);
            }
        }

        public void Run(IDataWebScraperConfiguration dataWebScraperConfiguration)
        {
            DataWebScraperConfiguration = dataWebScraperConfiguration;
            WebBrowser.Navigate(dataWebScraperConfiguration.MainUrl);
        }
    }
}
