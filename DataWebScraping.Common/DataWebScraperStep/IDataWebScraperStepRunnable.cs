using System.Windows.Forms;

namespace DataWebScraping.Common.DataWebScraperStep
{
    public interface IDataWebScraperStepRunnable : IDataWebScraperStep
    {
        void Run(WebBrowser webBrowser);
    }
}
