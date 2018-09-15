using DataWebScraping.Common.DataWebScraperStep;
using System.Collections.Generic;

namespace DataWebScraping.Common.Configuration
{
    public class DataWebScraperConfigurationRunnable : IDataWebScraperConfigurationRunnable
    {        
        IEnumerable<IDataWebScraperStepRunnable> IDataWebScraperConfigurationRunnable.DataWebScraperSteps => throw new System.NotImplementedException();

        public DataWebScraperConfigurationRunnable()
        {
        }               

        public void AddDataWebScraperStep(IDataWebScraperStepRunnable datawebScraperStep)
        {
            throw new System.NotImplementedException();
        }
    }
}