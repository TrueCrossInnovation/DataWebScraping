namespace DataWebScraping.Common.DataWebScraperStep.Property
{
    public class DataWebScraperStepProperty : IDataWebScraperStepProperty
    {
        public string Key { get; }

        public string Value { get; }

        public DataWebScraperStepProperty(string key, string value)
        {
            Key = key;
            Value = value;
        }        
    }
}