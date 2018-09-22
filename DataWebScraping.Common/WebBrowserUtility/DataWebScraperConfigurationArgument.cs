using System;
using DataWebScraping.Common.Configuration;

namespace DataWebScraping.Common.WebBrowserUtility
{
    internal class DataWebScraperConfigurationArgument : EventArgs
    {
        public IDataWebScraperConfiguration DataWebScraperConfiguration { get; }

        public DataWebScraperConfigurationArgument(IDataWebScraperConfiguration dataWebScraperConfiguration)
        {
            DataWebScraperConfiguration = dataWebScraperConfiguration;
        }
    }
}