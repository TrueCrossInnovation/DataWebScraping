using System;
using System.Windows.Forms;
using DataWebScraping.Common.Configuration;

namespace DataWebScraping.Common.WebBrowserUtility
{
    public interface IWebBrowserConfigurationRunner
    {
        event EventHandler WebBrowserConfigurationRunWascompleted;
        void Run(IDataWebScraperConfiguration dataWebScraperConfiguration);
    }
}