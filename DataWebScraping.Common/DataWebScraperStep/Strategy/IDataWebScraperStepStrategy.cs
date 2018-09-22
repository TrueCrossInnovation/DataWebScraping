using DataWebScraping.Common.DataWebScraperStep.Property;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataWebScraping.Common.DataWebScraperStep.Strategy
{
    public interface IDataWebScraperStepStrategy
    {
        event EventHandler StepWasCompleted;
        void Execute(WebBrowser webBrowser, IEnumerable<IDataWebScraperStepProperty> dataWebScraperStepProperties);
    }
}
