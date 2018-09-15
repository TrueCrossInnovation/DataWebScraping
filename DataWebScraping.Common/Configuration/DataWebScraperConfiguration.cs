using DataWebScraping.Common.DataWebScraperStep;
using System.Collections.Generic;
using System.Linq;

namespace DataWebScraping.Common.Configuration
{
    public class DataWebScraperConfiguration : IDataWebScraperConfiguration
    {
        private List<IDataWebScraperStep> _dataWebScraperSteps;
        public IEnumerable<IDataWebScraperStep> DataWebScraperSteps => _dataWebScraperSteps.AsReadOnly();

        public string MainUrl { get; }

        public DataWebScraperConfiguration(string mainUrl)
        {
            _dataWebScraperSteps = new List<IDataWebScraperStep>();
            MainUrl = mainUrl;
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