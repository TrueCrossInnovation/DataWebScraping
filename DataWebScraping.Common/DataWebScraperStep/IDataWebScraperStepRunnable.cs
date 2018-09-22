using System;
using System.Windows.Forms;

namespace DataWebScraping.Common.DataWebScraperStep
{
    public interface IDataWebScraperStepRunnable : IDataWebScraperStep
    {
        event EventHandler StepWasCompleted;
        void Run(WebBrowser webBrowser);
    }
}
