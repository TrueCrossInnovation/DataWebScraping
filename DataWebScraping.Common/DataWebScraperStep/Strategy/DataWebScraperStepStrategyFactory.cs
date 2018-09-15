using DataWebScraping.Common.DataWebScraperStep;
using DataWebScraping.Common.DataWebScraperStep.Strategy;
using System;
using System.Collections.Generic;

namespace DataWebScraping.Common.DataWebScraperStep.Strategy
{
    public class DataWebScraperStepStrategyFactory : IDataWebScraperStepStrategyFactory
    {
        private Dictionary<DataWebScraperStepType, Type> _dataWebScraperSteps;

        public IReadOnlyDictionary<DataWebScraperStepType, Type> DataWebScraperSteps => _dataWebScraperSteps;

        public DataWebScraperStepStrategyFactory()
        {
            _dataWebScraperSteps = new Dictionary<DataWebScraperStepType, Type>();            
            _dataWebScraperSteps.Add(DataWebScraperStepType.LogInStep, typeof(SetTextBoxDataWebScraperStepStrategy));
        }                

        public IDataWebScraperStepStrategy GetDataWebScraperStepStrategy(DataWebScraperStepType dataWebScraperStepType)
        {
            Type type = null;
            object args = new object();
            if (_dataWebScraperSteps.TryGetValue(dataWebScraperStepType, out type))
            {
                return (IDataWebScraperStepStrategy)Activator.CreateInstance(type, args);
            }

            throw new NotImplementedException($"The factory didn't find a type {dataWebScraperStepType} registered to be created.");

        }
    }
}