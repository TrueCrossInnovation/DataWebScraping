using DataWebScraping.Common;
using DataWebScraping.Common.Interfaces;
using DataWebScraping.Util;

namespace DataWebScraping.Service
{
    public class DataWebScrapingServiceRunner : IDataWebScrapingServiceRunner
    {
        private static IDataWebScrapingServiceRunner _instance;
        public IDataWebScraperRunner DataWebScraperRunner { get; }

        public static IDataWebScrapingServiceRunner Instance()
        {            
            if (_instance == null)
            {
                DataWebScraperConfigurationFactory dataWebScraperStepFactory = new DataWebScraperConfigurationFactory();                
                DataWebScraperConfigurationReader dataWebScraperConfigurationReader = new DataWebScraperConfigurationReader(dataWebScraperStepFactory);
                IDataWebScraperRunner dataWebScraperRunner = new DataWebScraperRunner(dataWebScraperConfigurationReader, new WebBrowserFactory());
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
