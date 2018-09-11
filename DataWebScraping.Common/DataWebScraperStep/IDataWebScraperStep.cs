using DataWebScraping.Common.DataWebScraperStep.Property;
using System.Collections.Generic;
using System.Net;
using System.Windows.Forms;

namespace DataWebScraping.Common.DataWebScraperStep
{
    public interface IDataWebScraperStep
    {
        IEnumerable<DataWebScraperStepProperty> DataWebScraperStepProperties { get; }

        void Execute(WebBrowser webBrowser);
    }
}