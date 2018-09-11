using System.Collections.Generic;

namespace DataWebScraping.Common.DataWebScraperSteps
{
    public interface IDataWebScrapperStepPropertyValidator
    {
        IDataWebScraperStepProperty GetFirstProperty(string keyProperty, IEnumerable<IDataWebScraperStepProperty> dataWebScraperStepProperties);
        void ValidatePropertyValueNotEmpty(IDataWebScraperStepProperty urlProperty);        
    }
}