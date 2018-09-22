using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DataWebScraping.Common.DataWebScraperStep;
using DataWebScraping.Common.DataWebScraperStep.Property;
using DataWebScraping.Common.DataWebScraperStep.Strategy;
using DataWebScraping.Common.IteratorUtility;

namespace DataWebScraping.Common.DataWebScraperStep
{
    public class DataWebScraperStepRunnable : IDataWebScraperStepRunnable
    {
        private WebBrowser _webBrowser;

        public event EventHandler StepWasCompleted;

        public IDataWebScraperStepStrategy DataWebScraperStepStrategy { get; }

                
        public IDataWebScraperStep DataWebScraperStep { get; }

        public DataWebScraperStepType StepType => DataWebScraperStep.StepType;

        public int StepSequence => DataWebScraperStep.StepSequence;

        public IEnumerable<IDataWebScraperStepProperty> DataWebScraperStepProperties => DataWebScraperStep.DataWebScraperStepProperties;

        public DataWebScraperStepRunnable(IDataWebScraperStepStrategy dataWebScraperStepStrategy, IDataWebScraperStep dataWebScraperStep)
        {
            DataWebScraperStepStrategy = dataWebScraperStepStrategy;
            DataWebScraperStep = dataWebScraperStep;
        }        

        public void Run(WebBrowser webBrowser)
        {
            _webBrowser = webBrowser;
            DataWebScraperStepStrategy.StepWasCompleted += DataWebScraperStepStrategy_StepWasCompleted;
            DataWebScraperStepStrategy.Execute(webBrowser, DataWebScraperStep.DataWebScraperStepProperties);
        }

        private void DataWebScraperStepStrategy_StepWasCompleted(object sender, EventArgs e)
        {
            DataWebScraperStepStrategy.StepWasCompleted -= DataWebScraperStepStrategy_StepWasCompleted;
            StepWasCompleted.Invoke(this, new WebBroserInWebScraperStepRunnabelArgument(_webBrowser));
        }
    }
}