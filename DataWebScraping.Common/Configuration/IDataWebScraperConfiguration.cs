using DataWebScraping.Common.DataWebScraperStep;
using System.Collections.Generic;

namespace DataWebScraping.Common.Configuration
{
    public interface IDataWebScraperConfiguration
    {
        IEnumerable<IDataWebScraperStep> DataWebScraperSteps { get; }        

        void AddDataWebScraperStep(IDataWebScraperStep datawebScraperStep);
    }
}