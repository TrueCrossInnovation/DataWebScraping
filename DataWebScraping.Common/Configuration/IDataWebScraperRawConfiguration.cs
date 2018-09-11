using System.Collections.Generic;

namespace DataWebScraping.Common.Configuration
{
    internal interface IDataWebScraperRawConfiguration
    {
        IEnumerable<IDataWebScraperRawStep> DataWebScraperRawSteps { get; }
    }
}