namespace DataWebScraping.Common.DataWebScraperStep.Property
{
    internal class DataWebScraperStepPropertyWithSetter : IDataWebScraperStepPropertyWithSetter
    {
        public string Key { get; set; }

        public string Value { get; set; }
        
        public DataWebScraperStepPropertyWithSetter()
        { }

        public DataWebScraperStepPropertyWithSetter(IDataWebScraperStepProperty dataWebScraperStepProperty)
        {
            Key = dataWebScraperStepProperty.Key;
            Value = dataWebScraperStepProperty.Value;
        }
    }
}