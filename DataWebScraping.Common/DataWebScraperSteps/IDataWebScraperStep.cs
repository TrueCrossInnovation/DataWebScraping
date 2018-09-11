using DataWebScraping.Common.DataWebScraperSteps;
using System.Collections.Generic;
using System.Net;
using System.Windows.Forms;

namespace DataWebScraping.Common.DataWebScraperSteps
{
    public interface IDataWebScraperStep
    {
        IEnumerable<DataWebScraperStepProperty> DataWebScraperStepProperties { get; }

        void Execute(WebBrowser webBrowser);
    }
}