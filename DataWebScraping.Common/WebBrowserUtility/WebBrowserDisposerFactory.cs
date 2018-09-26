using System;
using System.Windows.Forms;

namespace DataWebScraping.Common.WebBrowserUtility
{
    public class WebBrowserDisposerFactory
    {
        internal WebBrowserDisposer GetWebBrowserDisposer(WebBrowser webBrowser)
        {
            return new WebBrowserDisposer(webBrowser);
        }
    }
}