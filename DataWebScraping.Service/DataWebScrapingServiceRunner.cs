using DataWebScraping.Common;
using DataWebScraping.Common.Configuration;
using DataWebScraping.Util;

namespace DataWebScraping.Service
{
    public class DataWebScrapingServiceRunner : IDataWebScrapingServiceRunner
    {
        private static IDataWebScrapingServiceRunner _instance;
        public IDataWebScraperRunner DataWebScraperRunner { get; }
        public WebBrowserFactory WebBrowserFactory { get; }

        public static IDataWebScrapingServiceRunner Instance()
        {            
            if (_instance == null)
            {
                DataWebScraperConfigurationFactory dataWebScraperStepFactory = new DataWebScraperConfigurationFactory();                
                DataWebScraperConfigurationReader dataWebScraperConfigurationReader = new DataWebScraperConfigurationReader(dataWebScraperStepFactory);
                IDataWebScraperRunner dataWebScraperRunner = new DataWebScraperRunner(dataWebScraperConfigurationReader, new WebBrowserFactory());
                WebBrowserFactory webBrowserFactory = new WebBrowserFactory();
                _instance = new DataWebScrapingServiceRunner(dataWebScraperRunner, webBrowserFactory);
            }

            return _instance;
        }

        private DataWebScrapingServiceRunner(IDataWebScraperRunner dataWebScraperRunner, WebBrowserFactory webBrowserFactory)
        {
            DataWebScraperRunner = dataWebScraperRunner;
            WebBrowserFactory = webBrowserFactory;
        }

        public void Run(string dataWebScraperConfigurationFile)
        {
            DataWebScraperRunner.Run(dataWebScraperConfigurationFile, WebBrowserFactory.GetWebBrowser());
        }
    }
}
