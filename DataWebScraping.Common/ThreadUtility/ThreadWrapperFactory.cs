using System.Threading;

namespace DataWebScraping.Common.ThreadUtility
{
    public class ThreadWrapperFactory
    {
        public IThreadWrapper GetThreadWrapper(ThreadStart threadStart)
        {
            return new ThreadWrapper(threadStart);
        }
        public IThreadWrapper GetThreadWrapper(ParameterizedThreadStart parameterizedThreadStart)
        {
            return new ThreadWrapper(parameterizedThreadStart);
        }
    }
}