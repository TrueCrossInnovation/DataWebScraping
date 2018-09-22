using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataWebScraping.Common.DataWebScraperStep.Property;
using DataWebScraping.Common.JsonUtility;
using Newtonsoft.Json;

namespace DataWebScraping.Common.DataWebScraperStep
{
    internal class DataWebScraperStepWithSetter : IDataWebScraperStep
    {
        public DataWebScraperStepType StepType { get; set; }
        public int StepSequence { get; set; }
        [JsonProperty(nameof(IDataWebScraperStep.DataWebScraperStepProperties),
            ItemConverterType = typeof(ConcreteConverter<IDataWebScraperStepProperty, DataWebScraperStepPropertyWithSetter>))]
        public IEnumerable<IDataWebScraperStepProperty> DataWebScraperStepProperties { get; set; }
    }
}
