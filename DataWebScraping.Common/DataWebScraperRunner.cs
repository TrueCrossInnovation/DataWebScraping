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

        public DataWebScraperRunner(IDataWebScraperConfigurationReader dataWebScraperConfigurationReader, IWebBrowserConfigurationRunner dataWebScraperWebBrowserLoader)
        {            
            DataWebScraperConfigurationReader = dataWebScraperConfigurationReader;                        
            WebBrowserConfigurationRunner = dataWebScraperWebBrowserLoader;            
        }
        
        public void Run(string dataWebScraperConfigurationFilePath)
        {
            IDataWebScraperConfiguration dataWebScraperConfiguration = DataWebScraperConfigurationReader.Read(dataWebScraperConfigurationFilePath);
            WebBrowserConfigurationRunner.Run(dataWebScraperConfiguration);
        }        
    }
}