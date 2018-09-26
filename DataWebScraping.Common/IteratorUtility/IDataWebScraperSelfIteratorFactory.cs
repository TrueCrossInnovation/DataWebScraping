using DataWebScraping.Common.IteratorUtility;
using System.Windows.Forms;

namespace DataWebScraping.Common.IteratorUtility
{
    public interface IDataWebScraperSelfIteratorFactory
    {
        IDataWebScraperSelfIterator GetDataWebScraperSelfIterator(WebBrowser webBrowser);
    }
}