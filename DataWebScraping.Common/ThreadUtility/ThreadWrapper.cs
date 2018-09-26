using System.Threading;

namespace DataWebScraping.Common.ThreadUtility
{
    public class ThreadWrapper : IThreadWrapper
    {
        public ParameterizedThreadStart ParameterizedThreadStart { get; }

        public ThreadStart ThreadStart { get; }
        public Thread Thread { get; }

        public ThreadWrapper(ThreadStart threadStart): this(new Thread(threadStart))
        {
            ThreadStart = threadStart;        
        }

        protected ThreadWrapper(Thread thread)
        {
            Thread = thread;
        }

        public ThreadWrapper(ParameterizedThreadStart parameterizedThreadStart) : this(new Thread(parameterizedThreadStart))
        {
            ParameterizedThreadStart = parameterizedThreadStart;
        }

        public void SetApartmentState(ApartmentState apartmentState)
        {
            Thread.SetApartmentState(apartmentState);
        }

        public void Start()
        {
            Thread.Start();
        }

        public bool IsAlive()
        {
            return Thread.IsAlive;
        }

        public void Abort()
        {
            Thread.Abort();
        }

        public void Start(object param)
        {
            Thread.Start(param);
        }
    }
}