namespace DataWebScraping.Common.Configuration
{
    public interface IDataWebScraperConfigurationWriter
    {
        void Write(DataWebScraperConfiguration dataWebScraperConfiguration, string pathToWrite, string fileName, bool overrideFile);
    }
}