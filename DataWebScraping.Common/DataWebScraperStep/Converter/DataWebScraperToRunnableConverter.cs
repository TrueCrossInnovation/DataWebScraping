using DataWebScraping.Common.DataWebScraperStep;
using DataWebScraping.Common.DataWebScraperStep.Converter;
using DataWebScraping.Common.DataWebScraperStep.Strategy;

namespace DataWebScraping.Common.DataWebScraperStep.Converter
{
    public class DataWebScraperToRunnableConverter : IDataWebScraperToRunnableConverter
    {
        private DataWebScraperStepStrategyFactory DataWebScraperStepStrategyFactory;

        public DataWebScraperToRunnableConverter(DataWebScraperStepStrategyFactory dataWebScraperStepStrategyFactory)
        {
            DataWebScraperStepStrategyFactory = dataWebScraperStepStrategyFactory;
        }

        public IDataWebScraperStepRunnable Convert(IDataWebScraperStep dataWebScraperStep)
        {
             IDataWebScraperStepStrategy dataWebScraperStepStrategy = DataWebScraperStepStrategyFactory.GetDataWebScraperStepStrategy(dataWebScraperStep.StepType);
            return new DataWebScraperStepRunnable(dataWebScraperStepStrategy, dataWebScraperStep);
        }
    }
}