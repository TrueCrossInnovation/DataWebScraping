using DataWebScraping.Common.DataWebScraperSteps;
using System.Collections.Generic;

namespace DataWebScraping.Common.Interfaces
{
    public interface IDataWebScraperConfiguration
    {
        IEnumerable<IDataWebScraperStep> DataWebScraperSteps { get; }
        string MainPageUrl { get; }

        void AddDataWebScraperStep(IDataWebScraperStep datawebScraperStep);
    }
}