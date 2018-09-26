using System;
using System.Security.Permissions;
using DataWebScraping.Common.ThreadUtility;

namespace DataWebScraping.Common.WebBrowserUtility
{
    public class ThreadWrapperKiller : IThreadWrapperKiller
    {
        private static IThreadWrapperKiller _instance;
        
        public static IThreadWrapperKiller Instance()
        {
            if(_instance == null)
            {
                _instance = new ThreadWrapperKiller();
            }

            return _instance;
        }

        [SecurityPermissionAttribute(SecurityAction.Demand, ControlThread = true)]
        public void Kill(IThreadWrapper threadWrapper)
        {
            if(threadWrapper.IsAlive())
            {
                threadWrapper.Abort();
            }
        }
    }
}