using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataWebScraping.Common.DataWebScraperSteps
{
    class LoadWebPageDataWebScraperStep : IDataWebScraperStep
    {
        public IEnumerable<DataWebScraperStepProperty> DataWebScraperStepProperties { get; }

        public DataWebScrapperStepPropertyValidator DataWebScrapperStepPropertyValidator { get; }
        public DataWebScraperThreadHolderFactory DataWebScraperThreadHolderFactory { get; }

        public LoadWebPageDataWebScraperStep(IEnumerable<DataWebScraperStepProperty> dataWebScraperStepProperties, DataWebScrapperStepPropertyValidator dataWebScrapperStepPropertyValidator, DataWebScraperThreadHolderFactory dataWebScraperThreadHolderFactory)
        {
            DataWebScraperStepProperties = dataWebScraperStepProperties;
            DataWebScrapperStepPropertyValidator = dataWebScrapperStepPropertyValidator;
            DataWebScraperThreadHolderFactory = dataWebScraperThreadHolderFactory;
        }

        public void Execute(WebBrowser webBrowser)
        {
            IDataWebScraperStepProperty urlProperty = DataWebScrapperStepPropertyValidator.GetFirstProperty(DataWebScraperStepPropertyType.Url, DataWebScraperStepProperties);
            DataWebScrapperStepPropertyValidator.ValidatePropertyValueNotEmpty(urlProperty);

            ThreadHolderManager dataWebScraperThreadHolder = DataWebScraperThreadHolderFactory.GetDataWebScraperThreadHolder();
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
