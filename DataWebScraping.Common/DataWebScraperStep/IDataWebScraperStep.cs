using DataWebScraping.Common.DataWebScraperStep.Property;
using DataWebScraping.Common.JsonUtility;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System.Windows.Forms;

namespace DataWebScraping.Common.DataWebScraperStep
{
    public interface IDataWebScraperStep
    {
        DataWebScraperStepType StepType { get;  }
        int StepSequence { get; }        
        IEnumerable<IDataWebScraperStepProperty> DataWebScraperStepProperties { get; }                                
    }
}