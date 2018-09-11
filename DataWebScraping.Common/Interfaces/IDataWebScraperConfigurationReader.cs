namespace DataWebScraping.Common.Interfaces
{
    public interface IDataWebScraperConfigurationReader
    {
        IDataWebScraperConfiguration Read(string dataWebScraperConfigurationFilePath);
    }
}