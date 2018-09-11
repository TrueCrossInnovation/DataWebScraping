using System;

namespace DataWebScraping.Common.DataWebScraperSteps
{
    public class DataWebScraperThreadHolderFactory
    {
        public ThreadHolderManager GetDataWebScraperThreadHolder(long millisecondsToHold)
        {
            return new ThreadHolderManager(millisecondsToHold);
        }
    }
}