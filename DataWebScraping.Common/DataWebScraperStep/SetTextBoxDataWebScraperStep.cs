using DataWebScraping.Common.DataWebScraperStep.Property;
using DataWebScraping.Common.DataWebScraperStep.Validator;
using DataWebScraping.Common.WebBrowserUtility;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DataWebScraping.Common.DataWebScraperStep
{
    class SetTextBoxDataWebScraperStep : IDataWebScraperStep
    {
        public IEnumerable<DataWebScraperStepProperty> DataWebScraperStepProperties { get; }

        public DataWebScrapperStepPropertyValidator DataWebScrapperStepPropertyValidator { get; }
        public DataWebScraperElementFinder DataWebScraperElementFinder { get; }

        public SetTextBoxDataWebScraperStep(IEnumerable<DataWebScraperStepProperty> dataWebScraperStepProperties, DataWebScrapperStepPropertyValidator dataWebScrapperStepPropertyValidator, DataWebScraperElementFinder dataWebScraperElementFinder)
        {
            DataWebScraperStepProperties = dataWebScraperStepProperties;
            DataWebScrapperStepPropertyValidator = dataWebScrapperStepPropertyValidator;
            DataWebScraperElementFinder = dataWebScraperElementFinder;
        }

        public void Execute(WebBrowser webBrowser)
        {            
            IDataWebScraperStepProperty elementValueProperty = DataWebScrapperStepPropertyValidator.GetFirstProperty(DataWebScraperStepPropertyType.ElementValue, DataWebScraperStepProperties);
            IEnumerable<IDataWebScraperStepProperty> attributeToFindElementByProperties = DataWebScrapperStepPropertyValidator.GetAllProperties(DataWebScraperStepPropertyType.AttributeToFindElementBy, DataWebScraperStepProperties);
            
            DataWebScrapperStepPropertyValidator.ValidatePropertyValueNotEmpty(elementValueProperty);            
            DataWebScrapperStepPropertyValidator.ValidatePropertiesValueNotEmpty(attributeToFindElementByProperties);

            HtmlElement htmlElement = DataWebScraperElementFinder.FindElement(attributeToFindElementByProperties, webBrowser);
            htmlElement.InnerText = elementValueProperty.Value;
        }
    }
}
