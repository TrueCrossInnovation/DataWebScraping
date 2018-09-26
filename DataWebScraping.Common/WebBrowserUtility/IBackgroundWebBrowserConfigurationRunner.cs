using System;
using System.Windows.Forms;
using DataWebScraping.Common.Configuration;

namespace DataWebScraping.Common.WebBrowserUtility
{
    public interface IBackgroundWebBrowserConfigurationRunner : IWebBrowserConfigurationRunner
    {
        event EventHandler WebBrowserWasCreatedEvent;
    }
}