using System.Windows.Forms;

namespace DataWebScraping.Common
{
    public interface IDataWebScraperRunner
    {
        WebBrowser WebBrowser { get; }
        void Run(string dataWebScraperConfigurationFile);
    }
}