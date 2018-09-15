using DataWebScraping.Common.DataWebScraperStep;
using DataWebScraping.Common.JsonUtility;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace DataWebScraping.Common.Configuration
{
    internal class DataWebScraperConfigurationWithSetter : IDataWebScraperConfigurationWithSetter
    {
        public string MainUrl { get; set; }
        [JsonConverter(typeof(ConcreteConverter<DataWebScraperStepWithSetter>))]
        public IEnumerable<IDataWebScraperStepWithSetter> DataWebScraperSteps { get; set; }
        IEnumerable<IDataWebScraperStep> IDataWebScraperConfiguration.DataWebScraperSteps => DataWebScraperSteps;

        public DataWebScraperConfigurationWithSetter()
        { }

        public DataWebScraperConfigurationWithSetter(IDataWebScraperConfiguration dataWebScraperConfiguration)
        {
            MainUrl = dataWebScraperConfiguration.MainUrl;
            List<DataWebScraperStepWithSetter>  dataWebScraperSteps = new List<DataWebScraperStepWithSetter>();
            foreach(IDataWebScraperStep dataWebScraperStep in dataWebScraperConfiguration.DataWebScraperSteps)
            {
                dataWebScraperSteps.Add(new DataWebScraperStepWithSetter(dataWebScraperStep));
            }

            DataWebScraperSteps = dataWebScraperSteps;


        }        
    }
}