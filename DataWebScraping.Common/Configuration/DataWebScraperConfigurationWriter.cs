using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataWebScraping.Common.Configuration
{
    public class DataWebScraperConfigurationWriter : IDataWebScraperConfigurationWriter
    {
        public void Write(IDataWebScraperConfiguration dataWebScraperConfiguration, string pathToWrite, string fileName, bool overrideFile)
        {
            if(!Directory.Exists(pathToWrite))
            {
                Directory.CreateDirectory(pathToWrite);
            }

            string fullFileNamePath = Path.Combine(pathToWrite, fileName);

            if (File.Exists(fullFileNamePath))
            {
                if (overrideFile)
                {
                    File.Delete(fullFileNamePath);
                }
                else
                {
                    throw new Exception($"The file {fullFileNamePath} already exist and is not marked as override.");
                }
            }

            var dataWebScraperConfigurationWithSetter = new DataWebScraperConfigurationWithSetter(dataWebScraperConfiguration);

            string dataWebScraperConfigurationJson = JsonConvert.SerializeObject(dataWebScraperConfigurationWithSetter);

            File.WriteAllText(fullFileNamePath, dataWebScraperConfigurationJson);
        }
    }
}
