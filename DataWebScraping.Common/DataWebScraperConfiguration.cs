using System.Collections.Generic;
using DataWebScraping.Common.DataWebScraperSteps;
using DataWebScraping.Common.Interfaces;

namespace DataWebScraping.Common
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