using System.Windows.Forms;
using DataWebScraping.Common.Configuration;

namespace DataWebScraping.Common.WebBrowserUtility
{
    public interface IWebBrowserConfigurationRunner
    {
        WebBrowser WebBrowser { get; }        
        void Run(IDataWebScraperConfiguration dataWebScraperConfiguration);
    }
}