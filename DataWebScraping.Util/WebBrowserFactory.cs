using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataWebScraping.Util
{
    public class WebBrowserFactory
    {
        public WebBrowser GetWebBrowser()
        {
            return new WebBrowser();
        }
    }
}
