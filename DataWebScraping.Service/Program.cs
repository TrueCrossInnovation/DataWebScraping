using DataWebScraping.Common;
using DataWebScraping.Common.Configuration;
using DataWebScraping.Common.WebBrowserUtility;
using System.Configuration;

namespace DataWebScraping.RunningFromConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var dataWebScraperConfigurationFilePath = ConfigurationManager.AppSettings["DataWebScraperConfigurationFilePath"];
            IDataWebScraperConfigurationReader dataWebScraperConfigurationReader = new DataWebScraperConfigurationReader();
            ThreadLockWebBrowserConfigurationRunner dataWebBrowserConfigurationRunner = new ThreadLockWebBrowserConfigurationRunner();
            IDataWebScraperConfiguration dataWebScraperConfiguration = dataWebScraperConfigurationReader.Read(dataWebScraperConfigurationFilePath);
            dataWebBrowserConfigurationRunner.Run(dataWebScraperConfiguration);            
        }
    }
}
