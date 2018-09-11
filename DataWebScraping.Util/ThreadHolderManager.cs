using System;
using System.Diagnostics;

namespace DataWebScraping.Util
{
    public class ThreadHolderManager
    {
        private bool _threadValue;

        public long MilisecondsToHold { get; }

        public ThreadHolderManager(long milisecondsToHold)
        {
            MilisecondsToHold = milisecondsToHold;
        }

        public void SetThreadValue(bool threadValue)
        {
            _threadValue = threadValue;
        }

        public bool GetThreadValue(bool threadValue)
        {
            return _threadValue;
        }

        public void WaitUntilValue(bool expectedValue)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            while(_threadValue != expectedValue )
            {
                if(stopWatch.ElapsedMilliseconds >= MilisecondsToHold)
                {
                    throw new TimeoutException("The time to hold was exceeded.");
                }
            }
        }
    }
}