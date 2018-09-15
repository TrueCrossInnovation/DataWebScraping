using DataWebScraping.Common.DataWebScraperStep.Property;
using DataWebScraping.Common.DataWebScraperStep.Validator;
using DataWebScraping.Util;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DataWebScraping.Common.DataWebScraperStep.Strategy
{
    class LoadWebPageDataWebScraperStepStrategy : IDataWebScraperStepStrategy
    {        

        public DataWebScrapperStepPropertyValidator DataWebScrapperStepPropertyValidator { get; }
        public ThreadHolderManagerFactory ThreadHolderManagerFactory { get; }        

        public LoadWebPageDataWebScraperStepStrategy(DataWebScrapperStepPropertyValidator dataWebScrapperStepPropertyValidator, ThreadHolderManagerFactory threadHolderManagerFactory)
        {            
            DataWebScrapperStepPropertyValidator = dataWebScrapperStepPropertyValidator;
            ThreadHolderManagerFactory = threadHolderManagerFactory;
        }

        public void Execute(WebBrowser webBrowser, IEnumerable<IDataWebScraperStepProperty> dataWebScraperStepProperties)
        {
            IDataWebScraperStepProperty urlProperty = DataWebScrapperStepPropertyValidator.GetFirstProperty(DataWebScraperStepPropertyType.Url, dataWebScraperStepProperties);
            IDataWebScraperStepProperty millisecondsToHoldProperty = DataWebScrapperStepPropertyValidator.GetFirstProperty(DataWebScraperStepPropertyType.MillisecondsToHold, dataWebScraperStepProperties);

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
