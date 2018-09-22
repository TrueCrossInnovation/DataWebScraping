using DataWebScraping.Common.DataWebScraperStep;
using DataWebScraping.Common.JsonUtility;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace DataWebScraping.Common.Configuration
{
    public interface IDataWebScraperConfiguration
    {        
        IEnumerable<IDataWebScraperStep> DataWebScraperSteps { get; }        
    }
}