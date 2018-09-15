namespace DataWebScraping.Common.DataWebScraperStep.Converter
{
    public interface IDataWebScraperToRunnableConverter
    {
        IDataWebScraperStepRunnable Convert(IDataWebScraperStep dataWebScraperStep);
    }
}