using DataWebScraping.Common.DataWebScraperStep.Property;
using DataWebScraping.Common.DataWebScraperStep.Validator;
using DataWebScraping.Common.WebBrowserUtility;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DataWebScraping.Common.DataWebScraperStep.Strategy
{
    class SetTextBoxDataWebScraperStepStrategy : IDataWebScraperStepStrategy
    {        
        public DataWebScrapperStepPropertyValidator DataWebScrapperStepPropertyValidator { get; }
        public DataWebScraperElementFinder DataWebScraperElementFinder { get; }        

        public SetTextBoxDataWebScraperStepStrategy(DataWebScrapperStepPropertyValidator dataWebScrapperStepPropertyValidator, DataWebScraperElementFinder dataWebScraperElementFinder)
        {            
            DataWebScrapperStepPropertyValidator = dataWebScrapperStepPropertyValidator;
            DataWebScraperElementFinder = dataWebScraperElementFinder;
        }

        public void Execute(WebBrowser webBrowser, IEnumerable<IDataWebScraperStepProperty> dataWebScraperStepProperties)
        {            
            IDataWebScraperStepProperty elementValueProperty = DataWebScrapperStepPropertyValidator.GetFirstProperty(DataWebScraperStepPropertyType.ElementValue, dataWebScraperStepProperties);
            IEnumerable<IDataWebScraperStepProperty> attributeToFindElementByProperties = DataWebScrapperStepPropertyValidator.GetAllProperties(DataWebScraperStepPropertyType.AttributeToFindElementBy, dataWebScraperStepProperties);
            
            DataWebScrapperStepPropertyValidator.ValidatePropertyValueNotEmpty(elementValueProperty);            
            DataWebScrapperStepPropertyValidator.ValidatePropertiesValueNotEmpty(attributeToFindElementByProperties);

            HtmlElement htmlElement = DataWebScraperElementFinder.FindElement(attributeToFindElementByProperties, webBrowser);
            htmlElement.InnerText = elementValueProperty.Value;
        }        
    }
}
