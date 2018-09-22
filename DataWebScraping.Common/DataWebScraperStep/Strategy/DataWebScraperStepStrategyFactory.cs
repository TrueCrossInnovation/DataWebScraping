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
            _dataWebScraperSteps.Add(DataWebScraperStepType.SetTextBox, typeof(SetAttributeOnElementDataWebScraperStepStrategy));
            _dataWebScraperSteps.Add(DataWebScraperStepType.LoadWebPage, typeof(LoadWebPageDataWebScraperStepStrategy));
        }                

        public IDataWebScraperStepStrategy GetDataWebScraperStepStrategy(DataWebScraperStepType dataWebScraperStepType)
        {
            Type type = null;            
            if (_dataWebScraperSteps.TryGetValue(dataWebScraperStepType, out type))
            {
                return (IDataWebScraperStepStrategy)Activator.CreateInstance(type);
            }

            throw new NotImplementedException($"The factory didn't find a type {dataWebScraperStepType} registered to be created.");

        }
    }
}