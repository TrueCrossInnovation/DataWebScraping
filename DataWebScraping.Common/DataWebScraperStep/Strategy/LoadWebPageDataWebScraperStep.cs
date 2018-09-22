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
        public ThreadHolderManager DataWebScraperThreadHolder { get; private set; }

        public LoadWebPageDataWebScraperStepStrategy()
        {
            DataWebScrapperStepPropertyValidator = new DataWebScrapperStepPropertyValidator();
            ThreadHolderManagerFactory = new ThreadHolderManagerFactory();
        }

        internal LoadWebPageDataWebScraperStepStrategy(DataWebScrapperStepPropertyValidator dataWebScrapperStepPropertyValidator, ThreadHolderManagerFactory threadHolderManagerFactory)
        {            
            DataWebScrapperStepPropertyValidator = dataWebScrapperStepPropertyValidator;
            ThreadHolderManagerFactory = threadHolderManagerFactory;
        }

        public event EventHandler StepWasCompleted;

        public void Execute(WebBrowser webBrowser, IEnumerable<IDataWebScraperStepProperty> dataWebScraperStepProperties)
        {
            IDataWebScraperStepProperty urlProperty = DataWebScrapperStepPropertyValidator.GetFirstProperty(DataWebScraperStepPropertyType.Url, dataWebScraperStepProperties);
            IDataWebScraperStepProperty millisecondsToHoldProperty = DataWebScrapperStepPropertyValidator.GetFirstProperty(DataWebScraperStepPropertyType.MillisecondsToHold, dataWebScraperStepProperties);

            DataWebScrapperStepPropertyValidator.ValidatePropertyValueNotEmpty(urlProperty);
            DataWebScrapperStepPropertyValidator.ValidatePropertyValueNumericNotZero(millisecondsToHoldProperty);

            DataWebScraperThreadHolder = ThreadHolderManagerFactory.GetDataWebScraperThreadHolder(long.Parse(millisecondsToHoldProperty.Value));
            DataWebScraperThreadHolder.SetThreadValue(false);
            try
            {
                webBrowser.DocumentCompleted += WebBrowser_DocumentCompleted;
                webBrowser.Navigate(urlProperty.Value);
                //DataWebScraperThreadHolder.WaitUntilValue(true);                
            }catch(Exception e)
            {
                string r = e.Message;
            }            

        }

        private void WebBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            WebBrowser webBrowser = sender as WebBrowser;
            webBrowser.DocumentCompleted -= WebBrowser_DocumentCompleted;

            if (webBrowser.Document != null && webBrowser.ReadyState == WebBrowserReadyState.Complete)
            {
                DataWebScraperThreadHolder.SetThreadValue(true);
            }

            StepWasCompleted?.Invoke(null, null);
        }
    }
}
