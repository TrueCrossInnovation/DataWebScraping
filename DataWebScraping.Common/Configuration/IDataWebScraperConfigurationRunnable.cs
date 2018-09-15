using DataWebScraping.Common.DataWebScraperStep;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataWebScraping.Common.Configuration
{
    public interface IDataWebScraperConfigurationRunnable
    {
        IEnumerable<IDataWebScraperStepRunnable> DataWebScraperSteps { get; }

        void AddDataWebScraperStep(IDataWebScraperStepRunnable datawebScraperStep);
    }
}
