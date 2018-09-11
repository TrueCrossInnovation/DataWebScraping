using DataWebScraping.Common.DataWebScraperStep.Property;
using System.Collections.Generic;

namespace DataWebScraping.Common.DataWebScraperStep.Validator
{
    public interface IDataWebScrapperStepPropertyValidator
    {
        IDataWebScraperStepProperty GetFirstProperty(string keyProperty, IEnumerable<IDataWebScraperStepProperty> dataWebScraperStepProperties);
        void ValidatePropertyValueNotEmpty(IDataWebScraperStepProperty urlProperty);        
    }
}