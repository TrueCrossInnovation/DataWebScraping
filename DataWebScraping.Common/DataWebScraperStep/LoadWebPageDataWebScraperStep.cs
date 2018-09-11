using DataWebScraping.Common.DataWebScraperStep.Property;
using DataWebScraping.Common.DataWebScraperStep.Validator;
using DataWebScraping.Util;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DataWebScraping.Common.DataWebScraperStep
{
    class LoadWebPageDataWebScraperStep : IDataWebScraperStep
    {
        public IEnumerable<DataWebScraperStepProperty> DataWebScraperStepProperties { get; }

        public DataWebScrapperStepPropertyValidator DataWebScrapperStepPropertyValidator { get; }
        public ThreadHolderManagerFactory ThreadHolderManagerFactory { get; }

        public LoadWebPageDataWebScraperStep(IEnumerable<DataWebScraperStepProperty> dataWebScraperStepProperties, DataWebScrapperStepPropertyValidator dataWebScrapperStepPropertyValidator, ThreadHolderManagerFactory threadHolderManagerFactory)
        {
            DataWebScraperStepProperties = dataWebScraperStepProperties;
            DataWebScrapperStepPropertyValidator = dataWebScrapperStepPropertyValidator;
            ThreadHolderManagerFactory = threadHolderManagerFactory;
        }

        public void Execute(WebBrowser webBrowser)
        {
            IDataWebScraperStepProperty urlProperty = DataWebScrapperStepPropertyValidator.GetFirstProperty(DataWebScraperStepPropertyType.Url, DataWebScraperStepProperties);
            IDataWebScraperStepProperty millisecondsToHoldProperty = DataWebScrapperStepPropertyValidator.GetFirstProperty(DataWebScraperStepPropertyType.MillisecondsToHold, DataWebScraperStepProperties);

            DataWebScrapperStepPropertyValidator.ValidatePropertyValueNotEmpty(urlProperty);
            DataWebScrapperStepPropertyValidator.ValidatePropertyValueNumericNotZero(millisecondsToHoldProperty);

            ThreadHolderManager dataWebScraperThreadHolder = ThreadHolderManagerFactory.GetDataWebScraperThreadHolder(long.Parse(millisecondsToHoldProperty.Value));
            dataWebScraperThreadHolder.SetThreadValue(false);

            webBrowser.DocumentCompleted += (object sender, WebBrowserDocumentCompletedEventArgs e) => {
                if (webBrowser.Document != null && webBrowser.ReadyState == WebBrowserReadyState.Complete)
                {
                    dataWebScraperThreadHolder.SetThreadValue(true);
                }
            };

            webBrowser.Navigate(urlProperty.Value);
            dataWebScraperThreadHolder.WaitUntilValue(true);
        }        
    }
}
