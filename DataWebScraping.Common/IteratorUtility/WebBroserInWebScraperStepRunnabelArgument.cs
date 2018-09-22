using System;
using System.Windows.Forms;

namespace DataWebScraping.Common.IteratorUtility
{
    internal class WebBroserInWebScraperStepRunnabelArgument : EventArgs
    {
        public WebBrowser WebBrowser { get; }

        public WebBroserInWebScraperStepRunnabelArgument(WebBrowser webBrowser)
        {
            WebBrowser = webBrowser;
        }
    }
}