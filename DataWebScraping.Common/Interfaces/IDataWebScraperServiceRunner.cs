using System.Windows.Forms;

namespace DataWebScraping.Common.Interfaces
{
    public interface IDataWebScraperRunner
    {
        void Run(string dataWebScraperConfigurationFile, WebBrowser webBrowser);
    }
}