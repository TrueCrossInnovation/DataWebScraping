using DataWebScraping.Common.DataWebScraperStep;
using System.Collections.Generic;
using System.Linq;

namespace DataWebScraping.Common.Configuration
{
    public class DataWebScraperConfiguration : IDataWebScraperConfiguration
    {
        private List<IDataWebScraperStep> _dataWebScraperSteps;
        public IEnumerable<IDataWebScraperStep> DataWebScraperSteps => _dataWebScraperSteps.AsReadOnly();
        

        public DataWebScraperConfiguration()
        {
            _dataWebScraperSteps = new List<IDataWebScraperStep>();        
        }
        
        public void AddDataWebScraperStep(IDataWebScraperStep datawebScraperStep)
        {
            _dataWebScraperSteps.Add(datawebScraperStep);
        }

        public void RemoveDataWebScraperStep(IDataWebScraperStep datawebScraperStep)
        {
            _dataWebScraperSteps.Remove(datawebScraperStep);
        }
    }
}