using DataWebScraping.Common.Configuration;
using System;
using System.Windows.Forms;

namespace DataWebScraping.Common.WebBrowserUtility
{
    internal interface IWebBrowserConfigurationRunnerProcessor
    {
        event EventHandler WebBrowserConfigurationRunnerProcessorWasCompleted;
        void StartProcess(WebBrowser webBrowser, IDataWebScraperConfiguration dataWebScraperConfiguration);
    }
}