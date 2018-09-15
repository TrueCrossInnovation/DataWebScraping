using DataWebScraping.Common.DataWebScraperStep;
using DataWebScraping.Common.DataWebScraperStep.Converter;
using Newtonsoft.Json;
using System.IO;

namespace DataWebScraping.Common.Configuration
{
    public class DataWebScraperConfigurationReader : IDataWebScraperConfigurationReader
    {                       
        public IDataWebScraperConfiguration Read(string dataWebScraperConfigurationFilePath)
        {
            if(!File.Exists(dataWebScraperConfigurationFilePath))
            {
                new FileNotFoundException(dataWebScraperConfigurationFilePath);
            }

            string configurationJsonText = File.ReadAllText(dataWebScraperConfigurationFilePath);

            DataWebScraperConfigurationWithSetter dataWebScraperConfigurationWithSetter = JsonConvert.DeserializeObject<DataWebScraperConfigurationWithSetter>(configurationJsonText);

            return dataWebScraperConfigurationWithSetter;
        }
    }
}