using System;
using System.Net;
using System.Windows.Forms;
using DataWebScraping.Common.Configuration;
using DataWebScraping.Common.DataWebScraperStep;
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

        public void Run(string dataWebScraperConfigurationFilePath, WebBrowser webBrowser)
        {
            IDataWebScraperConfiguration dataWebScraperConfiguration = DataWebScraperConfigurationReader.Read(dataWebScraperConfigurationFilePath);

            foreach (IDataWebScraperStep dataWebScraperStep in dataWebScraperConfiguration.DataWebScraperSteps)
            {
                dataWebScraperStep.Execute(webBrowser);
            }
        }
    }
}
