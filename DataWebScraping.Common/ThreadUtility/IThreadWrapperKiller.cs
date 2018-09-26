using DataWebScraping.Common.ThreadUtility;
using System.Security.Permissions;

namespace DataWebScraping.Common.WebBrowserUtility
{
    public interface IThreadWrapperKiller
    {        
        void Kill(IThreadWrapper threadWrapper);
    }
}