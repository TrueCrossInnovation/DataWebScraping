using System;
using System.Configuration;

namespace DataWebScraping.Service
{
    class Program
    {
        static void Main(string[] args)
        {
            var dataWebScraperConfigurationFilePath =  ConfigurationManager.AppSettings["DataWebScraperConfigurationFilePath"];
            DataWebScrapingServiceRunner.Instance().Run(dataWebScraperConfigurationFilePath);
        }
    }
}
