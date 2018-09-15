using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataWebScraping.Common.DataWebScraperStep.Property;

namespace DataWebScraping.Common.DataWebScraperStep
{
    public class GenericDataWebScraperStep : IDataWebScraperStep
    {
        private List<IDataWebScraperStepProperty> _dataWebScraperStepProperties;
        public DataWebScraperStepType StepType { get; }        
        public int StepSequence { get; }
        public IEnumerable<IDataWebScraperStepProperty> DataWebScraperStepProperties => _dataWebScraperStepProperties.AsReadOnly();

        public GenericDataWebScraperStep(DataWebScraperStepType dataWebScraperStepType, int stepSequence, IEnumerable<IDataWebScraperStepProperty> dataWebScraperStepProperties)
        {
            StepSequence = stepSequence;
            StepType = dataWebScraperStepType;
            if (dataWebScraperStepProperties == null)
            {
                _dataWebScraperStepProperties = new List<IDataWebScraperStepProperty>();
            }
            else
            {
                _dataWebScraperStepProperties = dataWebScraperStepProperties.ToList();
            }
        }

        public GenericDataWebScraperStep(DataWebScraperStepType dataWebScraperStepType, int stepSequence)
        {
            StepSequence = stepSequence;
            StepType = dataWebScraperStepType;            
            _dataWebScraperStepProperties = new List<IDataWebScraperStepProperty>();
        }

        public void AddDataWebScraperStepProperty(IDataWebScraperStepProperty dataWebScraperStepProperty)
        {
            _dataWebScraperStepProperties.Add(dataWebScraperStepProperty);
        }

        public void RemoveDataWebScraperStepProperty(IDataWebScraperStepProperty dataWebScraperStepProperty)
        {
            _dataWebScraperStepProperties.Remove(dataWebScraperStepProperty);
        }
    }
}
