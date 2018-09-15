namespace DataWebScraping.Common.DataWebScraperStep.Property
{
    internal interface IDataWebScraperStepPropertyWithSetter : IDataWebScraperStepProperty
    {
        new string Key { get; set; }
        new string Value { get; set; }
    }
}