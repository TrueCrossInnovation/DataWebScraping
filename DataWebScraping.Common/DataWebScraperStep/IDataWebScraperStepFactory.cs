namespace DataWebScraping.Common.DataWebScraperStep
{
    public interface IDataWebScraperStepFactory
    {
        IDataWebScraperStep GetDataWebScraperStep(IDataWebScraperStepRaw dataWebScraperRawStep);
    }
}