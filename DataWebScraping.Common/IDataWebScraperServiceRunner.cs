using System.Windows.Forms;

namespace DataWebScraping.Common
{
    public interface IDataWebScraperRunner
    {        
        void Run(string dataWebScraperConfigurationFile);
    }
}