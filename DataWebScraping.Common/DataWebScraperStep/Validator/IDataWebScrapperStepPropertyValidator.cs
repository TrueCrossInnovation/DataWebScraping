using DataWebScraping.Common.DataWebScraperStep.Property;
using System.Collections.Generic;

namespace DataWebScraping.Common.DataWebScraperStep.Validator
{
    public interface IDataWebScrapperStepPropertyValidator
    {
        IDataWebScraperStepProperty GetFirstProperty(DataWebScraperStepPropertyType dataWebScraperStepPropertyType, IEnumerable<IDataWebScraperStepProperty> dataWebScraperStepProperties);
        IEnumerable<IDataWebScraperStepProperty> GetAllProperties(DataWebScraperStepPropertyType dataWebScraperStepPropertyType, IEnumerable<IDataWebScraperStepProperty> dataWebScraperStepProperties);
        void ValidatePropertyValueNotEmpty(IDataWebScraperStepProperty urlProperty);        
    }
}