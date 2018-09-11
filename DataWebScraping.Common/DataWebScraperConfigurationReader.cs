using DataWebScraping.Common.DataWebScraperSteps;
using DataWebScraping.Common.Interfaces;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace DataWebScraping.Common
{
    public class DataWebScraperConfigurationReader : IDataWebScraperConfigurationReader
    {
        public IDataWebScraperStepFactory DataWebScraperStepFactory { get; }

        public DataWebScraperConfigurationReader(IDataWebScraperStepFactory dataWebScraperStepFactory)
        {
            DataWebScraperStepFactory = dataWebScraperStepFactory;
        }

        public IDataWebScraperConfiguration Read(string dataWebScraperConfigurationFilePath)
        {
            if(!File.Exists(dataWebScraperConfigurationFilePath))
            {
                new FileNotFoundException(dataWebScraperConfigurationFilePath);
            }

            string configurationJsonText = File.ReadAllText(dataWebScraperConfigurationFilePath);

            IDataWebScraperRawConfiguration  dataWebScraperRawConfiguration = JsonConvert.DeserializeObject<IDataWebScraperRawConfiguration>(configurationJsonText);

            IDataWebScraperConfiguration dataWebScraperConfiguration = new DataWebScraperConfiguration();

            foreach(IDataWebScraperRawStep dataWebScraperRawStep in dataWebScraperRawConfiguration.DataWebScraperRawSteps)
            {
                IDataWebScraperStep datawebScraperStep = DataWebScraperStepFactory.GetDataWebScraperStep(dataWebScraperRawStep);
                dataWebScraperConfiguration.AddDataWebScraperStep(datawebScraperStep);
            }

            return dataWebScraperConfiguration;
        }
    }
}