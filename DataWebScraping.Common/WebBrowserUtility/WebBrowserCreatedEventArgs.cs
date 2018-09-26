using System;
using System.Windows.Forms;

namespace DataWebScraping.Common.WebBrowserUtility
{
    public class WebBrowserCreatedEventArgs : EventArgs
    {
        public WebBrowser WebBrowser { get; }

        public WebBrowserCreatedEventArgs(WebBrowser webBrowser)
        {
            WebBrowser = webBrowser;
        }
    }
}