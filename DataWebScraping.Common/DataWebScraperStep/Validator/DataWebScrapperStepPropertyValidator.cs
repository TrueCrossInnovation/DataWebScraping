using DataWebScraping.Common.DataWebScraperStep.Property;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataWebScraping.Common.DataWebScraperStep.Validator
{
    public class DataWebScrapperStepPropertyValidator : IDataWebScrapperStepPropertyValidator
    {                        

        public IDataWebScraperStepProperty GetFirstProperty(DataWebScraperStepPropertyType dataWebScraperStepPropertyType, IEnumerable<IDataWebScraperStepProperty> dataWebScraperStepProperties)
        {
            IDataWebScraperStepProperty dataWebScraperStepProperty = dataWebScraperStepProperties.FirstOrDefault(p => p.DataWebScraperStepPropertyType == dataWebScraperStepPropertyType);

            if (dataWebScraperStepProperty == null)
            {
                throw new NullReferenceException($"There is no property for type '{dataWebScraperStepPropertyType.ToString()}'.");
            }

            return dataWebScraperStepProperty;
        }

        public IEnumerable<IDataWebScraperStepProperty> GetAllProperties(DataWebScraperStepPropertyType dataWebScraperStepPropertyType, IEnumerable<IDataWebScraperStepProperty> dataWebScraperStepProperties)
        {
            IEnumerable<IDataWebScraperStepProperty> dataWebScraperStepPropertiesResult = dataWebScraperStepProperties.Where(p => p.DataWebScraperStepPropertyType == dataWebScraperStepPropertyType);

            if (dataWebScraperStepPropertiesResult == null || dataWebScraperStepPropertiesResult.Count() == 0)
            {
                throw new NullReferenceException($"There is no properties for type '{dataWebScraperStepPropertyType.ToString()}'.");
            }

            return dataWebScraperStepPropertiesResult;
        }

        public void ValidatePropertyValueNotEmpty(IDataWebScraperStepProperty dataWebScraperStepProperty)
        {
            if (string.IsNullOrWhiteSpace(dataWebScraperStepProperty.Value))
            {
                throw new NullReferenceException($"The property {dataWebScraperStepProperty.Key} should not be empty.");
            }
        }

        internal void ValidatePropertyValueNumericNotZero(IDataWebScraperStepProperty dataWebScraperStepProperty)
        {
            ValidatePropertyValueNotEmpty(dataWebScraperStepProperty);

            if (!int.TryParse(dataWebScraperStepProperty.Value, out int convertedProperty))
            {
                throw new NullReferenceException($"The property {dataWebScraperStepProperty.Key} does not contains a numeric value.");
            }
            else
            {
                if(convertedProperty == 0)
                {
                    throw new NullReferenceException($"The property {dataWebScraperStepProperty.Key} should not be zero.");
                }
            }
        }

        public void ValidatePropertiesValueNotEmpty(IEnumerable<IDataWebScraperStepProperty> dataWebScraperStepProperties)
        {
            foreach(IDataWebScraperStepProperty dataWebScraperStepProperty in dataWebScraperStepProperties)
            {
                ValidatePropertyValueNotEmpty(dataWebScraperStepProperty);
            }
        }
    }
}