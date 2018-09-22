using DataWebScraping.Common.Configuration;
using DataWebScraping.Common.DataWebScraperStep;
using DataWebScraping.Common.DataWebScraperStep.Property;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataWebScraping.ServiceConfigurationCreator
{
    class Program
    {
        static void Main(string[] args)
        {
            GenericDataWebScraperStep setLoginTextBoxStep = SetLoginTextBoxStep();
            GenericDataWebScraperStep loadMainTextBoxStep = LoadMainWebPageStep();
            DataWebScraperConfiguration dataWebScraperConfiguration = new DataWebScraperConfiguration();
            dataWebScraperConfiguration.AddDataWebScraperStep(setLoginTextBoxStep);
            dataWebScraperConfiguration.AddDataWebScraperStep(loadMainTextBoxStep);
            var c = new DataWebScraperConfigurationWriter();
            c.Write(dataWebScraperConfiguration, @"C:\DatawebScraperConfigurationFolder", "unionpacific.json", true);
        }

        private static GenericDataWebScraperStep LoadMainWebPageStep()
        {
            List<IDataWebScraperStepProperty> loadMainWebPageStepProperties = new List<IDataWebScraperStepProperty>();
            loadMainWebPageStepProperties.Add(new DataWebScraperStepProperty(DataWebScraperStepPropertyType.Url, DataWebScraperStepPropertyType.Url.ToString(), "my.uprr.com"));
            loadMainWebPageStepProperties.Add(new DataWebScraperStepProperty(DataWebScraperStepPropertyType.MillisecondsToHold, DataWebScraperStepPropertyType.MillisecondsToHold.ToString(), "60000"));
            GenericDataWebScraperStep loadMainWebPageStep = new GenericDataWebScraperStep(DataWebScraperStepType.LoadWebPage, 1, loadMainWebPageStepProperties);
            return loadMainWebPageStep;
        }

        private static GenericDataWebScraperStep SetLoginTextBoxStep()
        {
            List<IDataWebScraperStepProperty> setLoginTextBoxProperties = new List<IDataWebScraperStepProperty>();
            setLoginTextBoxProperties.Add(new DataWebScraperStepProperty(DataWebScraperStepPropertyType.AttributeToFindElementBy, "id", "user"));
            setLoginTextBoxProperties.Add(new DataWebScraperStepProperty(DataWebScraperStepPropertyType.AttributeToFindElementBy, "name", "user"));
            setLoginTextBoxProperties.Add(new DataWebScraperStepProperty(DataWebScraperStepPropertyType.AttributeToFindElementBy, "type", "text"));                        

            setLoginTextBoxProperties.Add(new DataWebScraperStepProperty(DataWebScraperStepPropertyType.AttributeToSetInElement, "value", "adrian"));
            GenericDataWebScraperStep setLoginTextBoxStep = new GenericDataWebScraperStep(DataWebScraperStepType.SetTextBox, 2, setLoginTextBoxProperties);
            return setLoginTextBoxStep;
        }
    }
}
