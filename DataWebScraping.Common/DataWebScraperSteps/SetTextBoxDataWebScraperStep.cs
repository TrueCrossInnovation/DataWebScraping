using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace DataWebScraping.Common.DataWebScraperSteps
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
            IDataWebScraperStepProperty elementNameProperty = DataWebScrapperStepPropertyValidator.GetFirstProperty(DataWebScraperStepPropertyType.ElementName, DataWebScraperStepProperties);
            IDataWebScraperStepProperty elementValueProperty = DataWebScrapperStepPropertyValidator.GetFirstProperty(DataWebScraperStepPropertyType.ElementValue, DataWebScraperStepProperties);
            IDataWebScraperStepProperty attributeToFindElementByProperty = DataWebScrapperStepPropertyValidator.GetFirstProperty(DataWebScraperStepPropertyType.AttributeToFindElementBy, DataWebScraperStepProperties);
            IEnumerable<IDataWebScraperStepProperty> attributeToMatchElementProperties = DataWebScrapperStepPropertyValidator.GetAllProperties(DataWebScraperStepPropertyType.AttributeToMatchElement, DataWebScraperStepProperties);

            DataWebScrapperStepPropertyValidator.ValidatePropertyValueNotEmpty(elementNameProperty);
            DataWebScrapperStepPropertyValidator.ValidatePropertyValueNotEmpty(elementValueProperty);
            DataWebScrapperStepPropertyValidator.ValidatePropertyValueNotEmpty(attributeToFindElementByProperty);
            DataWebScrapperStepPropertyValidator.ValidatePropertiesValueNotEmpty(attributeToMatchElementProperties);


            HtmlElement htmlElement = DataWebScraperElementFinder.FindElement(attributeToFindElementByProperty, attributeToMatchElementProperties, webBrowser);
                         
            if (htmlElement != null)
            {
                htmlElement.InnerText = elementValueProperty.Value;                
            }

            throw new MissingMemberException($"The element {elementNameProperty.Value} does not exist.");
        }
    }
}
