namespace DataWebScraping.Common.DataWebScraperStep.Strategy
{
    public interface IDataWebScraperStepStrategyFactory
    {
        IDataWebScraperStepStrategy GetDataWebScraperStepStrategy(DataWebScraperStepType dataWebScraperStepType);
    }
}