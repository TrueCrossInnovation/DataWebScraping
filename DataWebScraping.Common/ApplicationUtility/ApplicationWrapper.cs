using System;
using System.Windows.Forms;

namespace DataWebScraping.Common.WebBrowserUtility
{
    public class ApplicationWrapper : IApplicationWrapper
    {
        private static IApplicationWrapper _instance;        

        internal static IApplicationWrapper Instance()
        {
            if(_instance == null)
            {
                _instance = new ApplicationWrapper();
            }

            return _instance;
        }

        public void Run()
        {
            Application.Run();
        }

        public void Exit()
        {
            Application.Exit();
        }
    }
}