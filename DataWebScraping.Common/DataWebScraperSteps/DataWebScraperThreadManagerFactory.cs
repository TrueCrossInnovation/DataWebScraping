using System;

namespace DataWebScraping.Common.DataWebScraperSteps
{
    public class DataWebScraperThreadHolderFactory
    {
        public ThreadHolderManager GetDataWebScraperThreadHolder()
        {
            return new ThreadHolderManager();
        }
    }
}