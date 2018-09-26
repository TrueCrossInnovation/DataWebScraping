using DataWebScraping.Common.DataWebScraperStep.Converter;
using DataWebScraping.Common.DataWebScraperStep.Strategy;
using DataWebScraping.Common.IteratorUtility;
using System.Windows.Forms;

namespace DataWebScraping.Common.IteratorUtility
{
    public class DataWebScraperSelfIteratorFactory : IDataWebScraperSelfIteratorFactory
    {
        public IDataWebScraperSelfIterator GetDataWebScraperSelfIterator(WebBrowser webBrowser)
        {
            return new DataWebScraperSelfIterator(new DataWebScraperToRunnableConverter(new DataWebScraperStepStrategyFactory()), webBrowser);
        }
    }
}