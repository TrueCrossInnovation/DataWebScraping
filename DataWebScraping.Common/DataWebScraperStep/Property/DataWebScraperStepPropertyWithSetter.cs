namespace DataWebScraping.Common.DataWebScraperStep.Property
{
    internal class DataWebScraperStepPropertyWithSetter : IDataWebScraperStepProperty
    {
        public string Key { get; set; }

        public string Value { get; set; }

        public DataWebScraperStepPropertyType DataWebScraperStepPropertyType { get; set; }
    }
}