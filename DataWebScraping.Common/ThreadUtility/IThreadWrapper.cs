using System.Threading;

namespace DataWebScraping.Common.ThreadUtility
{
    public interface IThreadWrapper
    {
        void SetApartmentState(ApartmentState sTA);
        void Start();
        void Start(object param);
        bool IsAlive();
        void Abort();
    }
}