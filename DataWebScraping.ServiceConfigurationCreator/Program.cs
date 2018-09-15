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
            DataWebScraperConfiguration dataWebScraperConfiguration = new DataWebScraperConfiguration("my.uprr.com");
            dataWebScraperConfiguration.AddDataWebScraperStep(setLoginTextBoxStep);
            var c = new DataWebScraperConfigurationWriter();
            c.Write(dataWebScraperConfiguration, @"C:\DatawebScraperConfigurationFolder", "unionpacific.json", true);
        }

        private static GenericDataWebScraperStep SetLoginTextBoxStep()
        {
            List<IDataWebScraperStepProperty> setLoginTextBoxProperties = new List<IDataWebScraperStepProperty>();
            setLoginTextBoxProperties.Add(new DataWebScraperStepProperty("id", "user"));
            setLoginTextBoxProperties.Add(new DataWebScraperStepProperty("name", "user"));
            setLoginTextBoxProperties.Add(new DataWebScraperStepProperty("type", "text"));
            GenericDataWebScraperStep setLoginTextBoxStep = new GenericDataWebScraperStep(DataWebScraperStepType.SetTextBox, 1, setLoginTextBoxProperties);
            return setLoginTextBoxStep;
        }
    }
}
