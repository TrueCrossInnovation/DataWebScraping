using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataWebScraping.Common.Configuration
{
    class DataWebScraperConfigurationWriter : IDataWebScraperConfigurationWriter
    {
        public void Write(DataWebScraperConfiguration dataWebScraperConfiguration, string pathToWrite, string fileName, bool overrideFile)
        {
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

            string dataWebScraperConfigurationJson = JsonConvert.SerializeObject(dataWebScraperConfiguration);

            File.WriteAllText(fullFileNamePath, dataWebScraperConfigurationJson);
        }
    }
}
