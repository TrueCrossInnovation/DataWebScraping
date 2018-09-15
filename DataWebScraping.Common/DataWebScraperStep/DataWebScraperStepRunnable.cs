using System.Collections.Generic;
using System.Windows.Forms;
using DataWebScraping.Common.DataWebScraperStep;
using DataWebScraping.Common.DataWebScraperStep.Property;
using DataWebScraping.Common.DataWebScraperStep.Strategy;

namespace DataWebScraping.Common.DataWebScraperStep
{
    public class DataWebScraperStepRunnable : IDataWebScraperStepRunnable
    {
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
            DataWebScraperStepStrategy.Execute(webBrowser, DataWebScraperStep.DataWebScraperStepProperties);
        }
    }
}