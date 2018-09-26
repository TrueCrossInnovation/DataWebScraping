using DataWebScraping.Common.Configuration;
using DataWebScraping.Common.IteratorUtility;
using System;
using System.Linq;
using System.Security.Permissions;
using System.Windows.Forms;

namespace DataWebScraping.Common.WebBrowserUtility
{
    public class WebBrowserConfigurationRunnerProcessor : IWebBrowserConfigurationRunnerProcessor
    {
        public IDataWebScraperSelfIteratorFactory DataWebScraperSelfIteratorFactory { get; }        
        public event EventHandler WebBrowserConfigurationRunnerProcessorWasCompleted;

        internal WebBrowserConfigurationRunnerProcessor (IDataWebScraperSelfIteratorFactory dataWebScraperSelfIteratorFactory)
        {
            DataWebScraperSelfIteratorFactory = dataWebScraperSelfIteratorFactory;
        }        

        public void StartProcess(WebBrowser webBrowser, IDataWebScraperConfiguration dataWebScraperConfiguration)
        {            
            IDataWebScraperSelfIterator dataWebScraperSelfIterator = DataWebScraperSelfIteratorFactory.GetDataWebScraperSelfIterator(webBrowser);
            dataWebScraperSelfIterator.SetElements(dataWebScraperConfiguration.DataWebScraperSteps.OrderBy(s => s.StepSequence));
            dataWebScraperSelfIterator.Iterate();
            dataWebScraperSelfIterator.DataWebScraperSelfIteratorWasComplete += DataWebScraperSelfIterator_DataWebScraperSelfIteratorWasComplete;
            ApplicationWrapper.Instance().Run();
        }

        private void DataWebScraperSelfIterator_DataWebScraperSelfIteratorWasComplete(object sender, EventArgs e)
        {
            ApplicationWrapper.Instance().Exit();
            WebBrowserConfigurationRunnerProcessorWasCompleted?.Invoke(this, null);

        }
    }
}