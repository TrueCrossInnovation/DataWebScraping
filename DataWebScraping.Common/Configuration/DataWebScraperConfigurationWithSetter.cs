using DataWebScraping.Common.DataWebScraperStep;
using DataWebScraping.Common.JsonUtility;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace DataWebScraping.Common.Configuration
{
    internal class DataWebScraperConfigurationWithSetter : IDataWebScraperConfiguration
    {
        public string MainUrl { get; set; }        
        [JsonProperty(nameof(IDataWebScraperConfiguration.DataWebScraperSteps), 
            ItemConverterType = typeof(ConcreteConverter<IDataWebScraperStep, DataWebScraperStepWithSetter>))]        
        public IEnumerable<IDataWebScraperStep> DataWebScraperSteps { get; set; }
    }
}