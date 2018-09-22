namespace DataWebScraping.Common.DataWebScraperStep.Property
{
    public interface IDataWebScraperStepProperty
    {
        DataWebScraperStepPropertyType DataWebScraperStepPropertyType { get; }
        string Key { get; }
        string Value { get; }
    }
}