using DataWebScraping.Common.DataWebScraperStep.Property;
using DataWebScraping.Common.JsonUtility;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System.Windows.Forms;

namespace DataWebScraping.Common.DataWebScraperStep
{
    internal interface IDataWebScraperStepWithSetter : IDataWebScraperStep
    {
        new DataWebScraperStepType StepType { get; set; }
        new int StepSequence { get; set; }
        [JsonConverter(typeof(ConcreteConverter<DataWebScraperStepPropertyWithSetter>))]
        new IEnumerable<IDataWebScraperStepPropertyWithSetter> DataWebScraperStepProperties { get; set; }
    }
}