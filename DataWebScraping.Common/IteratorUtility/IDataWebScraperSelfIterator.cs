using DataWebScraping.Common.DataWebScraperStep;
using System;
using System.Collections.Generic;

namespace DataWebScraping.Common.IteratorUtility
{
    internal interface IDataWebScraperSelfIterator
    {
        event EventHandler DataWebScraperSelfIteratorWasComplete;
        void SetElements(IEnumerable<IDataWebScraperStep> orderedEnumerable);
        void Iterate();
    }
}