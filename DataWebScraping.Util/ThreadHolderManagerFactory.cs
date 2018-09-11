using System;

namespace DataWebScraping.Util
{
    public class ThreadHolderManagerFactory
    {
        public ThreadHolderManager GetDataWebScraperThreadHolder(long millisecondsToHold)
        {
            return new ThreadHolderManager(millisecondsToHold);
        }
    }
}