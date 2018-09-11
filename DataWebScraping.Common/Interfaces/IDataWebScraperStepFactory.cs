using DataWebScraping.Common.DataWebScraperSteps;

namespace DataWebScraping.Common.Interfaces
{
    public interface IDataWebScraperStepFactory
    {
        IDataWebScraperStep GetDataWebScraperStep(IDataWebScraperRawStep dataWebScraperRawStep);
    }
}