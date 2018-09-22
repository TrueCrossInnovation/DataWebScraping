using DataWebScraping.Common.DataWebScraperStep.Property;
using DataWebScraping.Common.DataWebScraperStep.Validator;
using DataWebScraping.Common.WebBrowserUtility;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DataWebScraping.Common.DataWebScraperStep.Strategy
{
    class SetAttributeOnElementDataWebScraperStepStrategy : IDataWebScraperStepStrategy
    {        
        public DataWebScrapperStepPropertyValidator DataWebScrapperStepPropertyValidator { get; }
        public DataWebScraperElementFinder DataWebScraperElementFinder { get; }

        public SetAttributeOnElementDataWebScraperStepStrategy()
        {
            DataWebScrapperStepPropertyValidator = new DataWebScrapperStepPropertyValidator();
            DataWebScraperElementFinder = new DataWebScraperElementFinder();
        }

        internal SetAttributeOnElementDataWebScraperStepStrategy(DataWebScrapperStepPropertyValidator dataWebScrapperStepPropertyValidator, DataWebScraperElementFinder dataWebScraperElementFinder)
        {            
            DataWebScrapperStepPropertyValidator = dataWebScrapperStepPropertyValidator;
            DataWebScraperElementFinder = dataWebScraperElementFinder;
        }

        public event EventHandler StepWasCompleted;

        public void Execute(WebBrowser webBrowser, IEnumerable<IDataWebScraperStepProperty> dataWebScraperStepProperties)
        {                        
            IEnumerable<IDataWebScraperStepProperty> attributeToFindElementByProperties = DataWebScrapperStepPropertyValidator.GetAllProperties(DataWebScraperStepPropertyType.AttributeToFindElementBy, dataWebScraperStepProperties);
            IEnumerable<IDataWebScraperStepProperty> attributeToSetInElementProperties = DataWebScrapperStepPropertyValidator.GetAllProperties(DataWebScraperStepPropertyType.AttributeToSetInElement, dataWebScraperStepProperties);
            
            DataWebScrapperStepPropertyValidator.ValidatePropertiesValueNotEmpty(attributeToFindElementByProperties);
            DataWebScrapperStepPropertyValidator.ValidatePropertiesValueNotEmpty(attributeToSetInElementProperties);

            HtmlElement htmlElement = DataWebScraperElementFinder.FindElement(attributeToFindElementByProperties, webBrowser);

            foreach (IDataWebScraperStepProperty dataWebScraperStepProperty in attributeToSetInElementProperties)
            {             
                htmlElement.SetAttribute(dataWebScraperStepProperty.Key, dataWebScraperStepProperty.Value);
            }

            StepWasCompleted?.Invoke(this, null);
        }        
    }
}
