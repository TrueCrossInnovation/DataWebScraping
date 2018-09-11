using DataWebScraping.Common.DataWebScraperStep;
using System.Collections.Generic;

namespace DataWebScraping.Common.Configuration
{
    public class DataWebScraperConfiguration : IDataWebScraperConfiguration
    {
        public DataWebScraperConfiguration()
        {
        }

        public IEnumerable<IDataWebScraperStep> DataWebScraperSteps => throw new System.NotImplementedException();

        public string MainPageUrl => throw new System.NotImplementedException();

        public void AddDataWebScraperStep(IDataWebScraperStep datawebScraperStep)
        {
            throw new System.NotImplementedException();
        }
    }
}