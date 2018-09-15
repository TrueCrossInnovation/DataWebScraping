using DataWebScraping.Common.DataWebScraperStep;
using DataWebScraping.Common.JsonUtility;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace DataWebScraping.Common.Configuration
{
    internal interface IDataWebScraperConfigurationWithSetter : IDataWebScraperConfiguration
    {        
        new IEnumerable<IDataWebScraperStepWithSetter> DataWebScraperSteps { get; set; }
        new string MainUrl { get; set; }
    }
}