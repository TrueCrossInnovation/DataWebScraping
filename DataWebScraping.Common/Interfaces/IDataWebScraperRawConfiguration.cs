using System.Collections.Generic;

namespace DataWebScraping.Common.Interfaces
{
    internal interface IDataWebScraperRawConfiguration
    {
        IEnumerable<IDataWebScraperRawStep> DataWebScraperRawSteps { get; }
    }
}