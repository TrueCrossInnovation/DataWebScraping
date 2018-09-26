using System;
using System.Windows.Forms;

namespace DataWebScraping.Common.WebBrowserUtility
{
    internal class WebBrowserDisposer
    {
        public WebBrowser WebBrowser { get; }

        public WebBrowserDisposer(WebBrowser webBrowser)
        {
            WebBrowser = webBrowser;
        }

        delegate void DisposeCallback();

        internal void Dispose()
        {
            if (!WebBrowser.IsDisposed)
            {
                if (WebBrowser.InvokeRequired)
                {
                    DisposeCallback d = new DisposeCallback(Dispose);
                    WebBrowser.Invoke(d);
                }
                else
                {
                    WebBrowser.Dispose();
                }
            }
        }
    }
}