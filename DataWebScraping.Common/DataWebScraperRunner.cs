using System;
using System.Net;
using System.Windows.Forms;
using DataWebScraping.Common.Configuration;
using DataWebScraping.Common.WebBrowserUtility;
using DataWebScraping.Util;

namespace DataWebScraping.Common
{
    public class DataWebScraperRunner : IDataWebScraperRunner
    {         
        public IDataWebScraperConfigurationReader DataWebScraperConfigurationReader { get; }                
        public IWebBrowserConfigurationRunner WebBrowserConfigurationRunner { get; }        

        public WebBrowser WebBrowser { get; private set; }

        public DataWebScraperRunner(IDataWebScraperConfigurationReader dataWebScraperConfigurationReader, IWebBrowserConfigurationRunner dataWebScraperWebBrowserLoader)
        {            
            DataWebScraperConfigurationReader = dataWebScraperConfigurationReader;                        
            WebBrowserConfigurationRunner = dataWebScraperWebBrowserLoader;            
        }
        
        public void Run(string dataWebScraperConfigurationFilePath)
        {
            IDataWebScraperConfiguration dataWebScraperConfiguration = DataWebScraperConfigurationReader.Read(dataWebScraperConfigurationFilePath);
            WebBrowser = WebBrowserConfigurationRunner.WebBrowser;
            WebBrowserConfigurationRunner.Run(dataWebScraperConfiguration);            
        }        
    }
}