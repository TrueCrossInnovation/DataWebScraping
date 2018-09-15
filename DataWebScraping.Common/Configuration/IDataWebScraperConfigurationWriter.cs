namespace DataWebScraping.Common.Configuration
{
    public interface IDataWebScraperConfigurationWriter
    {
        void Write(IDataWebScraperConfiguration dataWebScraperConfiguration, string pathToWrite, string fileName, bool overrideFile);
    }
}