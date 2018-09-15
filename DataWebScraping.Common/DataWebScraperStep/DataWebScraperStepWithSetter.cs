using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataWebScraping.Common.DataWebScraperStep.Property;

namespace DataWebScraping.Common.DataWebScraperStep
{
    internal class DataWebScraperStepWithSetter : IDataWebScraperStepWithSetter
    {
        public DataWebScraperStepType StepType { get; set; }
        public int StepSequence { get; set; }
        public IEnumerable<IDataWebScraperStepPropertyWithSetter> DataWebScraperStepProperties { get; set; }

        DataWebScraperStepType IDataWebScraperStep.StepType => StepType;
        int IDataWebScraperStep.StepSequence => StepSequence;
        IEnumerable<IDataWebScraperStepProperty> IDataWebScraperStep.DataWebScraperStepProperties => DataWebScraperStepProperties;

        public DataWebScraperStepWithSetter()
        { }

        public DataWebScraperStepWithSetter(IDataWebScraperStep dataWebScraperStep)
        {
            List<IDataWebScraperStepPropertyWithSetter> dataWebScraperStepPropertyWithSetter = new List<IDataWebScraperStepPropertyWithSetter>();
            foreach(IDataWebScraperStepProperty dataWebScraperStepProperty in dataWebScraperStep.DataWebScraperStepProperties)
            {
                dataWebScraperStepPropertyWithSetter.Add(new DataWebScraperStepPropertyWithSetter(dataWebScraperStepProperty));
            }

            DataWebScraperStepProperties = dataWebScraperStepPropertyWithSetter;
            StepType = dataWebScraperStep.StepType;
            StepSequence = dataWebScraperStep.StepSequence;
        }
    }
}
