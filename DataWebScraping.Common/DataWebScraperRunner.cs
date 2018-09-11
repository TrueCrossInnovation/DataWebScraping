using System;
using System.Net;
using System.Windows.Forms;
using DataWebScraping.Common.DataWebScraperSteps;
using DataWebScraping.Common.Interfaces;
using DataWebScraping.Util;

namespace DataWebScraping.Common
{
    public class DataWebScraperRunner : IDataWebScraperRunner
    {        
        public IDataWebScraperConfigurationReader DataWebScraperConfigurationReader { get; }
        public WebBrowserFactory WebBrowserFactory { get; }

        public DataWebScraperRunner(IDataWebScraperConfigurationReader dataWebScraperConfigurationReader, WebBrowserFactory webBrowserFactory)
        {            
            DataWebScraperConfigurationReader = dataWebScraperConfigurationReader;
            WebBrowserFactory = webBrowserFactory;
        }        

        public void Run(string dataWebScraperConfigurationFilePath)
        {
            IDataWebScraperConfiguration dataWebScraperConfiguration = DataWebScraperConfigurationReader.Read(dataWebScraperConfigurationFilePath);
            string url = dataWebScraperConfiguration.MainPageUrl;

            WebBrowser webBrowser = WebBrowserFactory.GetWebBrowser();            

            foreach (IDataWebScraperStep dataWebScraperStep in dataWebScraperConfiguration.DataWebScraperSteps)
            {
                dataWebScraperStep.Execute(webBrowser);
            }
        }
    }
}
