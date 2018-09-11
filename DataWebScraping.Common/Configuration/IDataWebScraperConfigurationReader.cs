namespace DataWebScraping.Common.Configuration
{
    public interface IDataWebScraperConfigurationReader
    {
        IDataWebScraperConfiguration Read(string dataWebScraperConfigurationFilePath);
    }
}