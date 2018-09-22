namespace DataWebScraping.Common.DataWebScraperStep.Property
{
    public class DataWebScraperStepProperty : IDataWebScraperStepProperty
    {
        public string Key { get; }

        public string Value { get; }

        public DataWebScraperStepPropertyType DataWebScraperStepPropertyType { get; }

        public DataWebScraperStepProperty(DataWebScraperStepPropertyType dataWebScraperStepPropertyType , string key, string value)
        {
            DataWebScraperStepPropertyType = dataWebScraperStepPropertyType;
            Key = key;
            Value = value;
        }        
    }
}