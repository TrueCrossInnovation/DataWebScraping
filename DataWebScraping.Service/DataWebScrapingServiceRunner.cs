using DataWebScraping.Common;
using DataWebScraping.Common.Configuration;
using DataWebScraping.Common.DataWebScraperStep.Converter;
using DataWebScraping.Common.DataWebScraperStep.Strategy;
using DataWebScraping.Common.WebBrowserUtility;
using DataWebScraping.Util;

namespace DataWebScraping.ServiceRunner
{
    public class DataWebScrapingServiceRunner : IDataWebScrapingServiceRunner
    {
        private static IDataWebScrapingServiceRunner _instance;
        public IDataWebScraperRunner DataWebScraperRunner { get; }        

        public static IDataWebScrapingServiceRunner Instance()
        {            
            if (_instance == null)
            {
                DataWebScraperStepStrategyFactory dataWebScraperStepStrategyFactory = new DataWebScraperStepStrategyFactory();                
                DataWebScraperConfigurationReader dataWebScraperConfigurationReader = new DataWebScraperConfigurationReader();
                IDataWebScraperToRunnableConverter dataWebScraperToRunnableConverter = new DataWebScraperToRunnableConverter(dataWebScraperStepStrategyFactory);
                WebBrowserFactory webBrowserFactory = new WebBrowserFactory();
                WebBrowserConfigurationRunner dataWebScraperWebBrowserLoader = new WebBrowserConfigurationRunner(dataWebScraperToRunnableConverter, webBrowserFactory);
                IDataWebScraperRunner dataWebScraperRunner = new DataWebScraperRunner(dataWebScraperConfigurationReader, dataWebScraperWebBrowserLoader);
                _instance = new DataWebScrapingServiceRunner(dataWebScraperRunner);
            }

            return _instance;
        }

        private DataWebScrapingServiceRunner(IDataWebScraperRunner dataWebScraperRunner)
        {
            DataWebScraperRunner = dataWebScraperRunner;            
        }

        public void Run(string dataWebScraperConfigurationFile)
        {
            DataWebScraperRunner.Run(dataWebScraperConfigurationFile);
        }
    }
}
