using DataWebScraping.Common;
using DataWebScraping.Common.Configuration;
using DataWebScraping.Common.WebBrowserUtility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataWebScraping.RunningFromWinForm
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void btnRunConfiguration_Click(object sender, EventArgs e)
        {
            var dataWebScraperConfigurationFilePath = ConfigurationManager.AppSettings["DataWebScraperConfigurationFilePath"];
            IDataWebScraperConfigurationReader dataWebScraperConfigurationReader = new DataWebScraperConfigurationReader();
            BackgroundWebBrowserConfigurationRunner dataWebBrowserConfigurationRunner = new BackgroundWebBrowserConfigurationRunner();
            IDataWebScraperConfiguration dataWebScraperConfiguration = dataWebScraperConfigurationReader.Read(dataWebScraperConfigurationFilePath);
            dataWebBrowserConfigurationRunner.WebBrowserWasCreatedEvent += DataWebBrowserConfigurationRunner_WebBrowserWasCreatedEvent;
            dataWebBrowserConfigurationRunner.Run(dataWebScraperConfiguration);         
        }

        private void DataWebBrowserConfigurationRunner_WebBrowserWasCreatedEvent(object sender, EventArgs e)
        {
            var backgroundWebBrowserConfigurationRunner = sender as BackgroundWebBrowserConfigurationRunner;
            var webBrowserCreatedEventArgs = e as WebBrowserCreatedEventArgs;

            backgroundWebBrowserConfigurationRunner.WebBrowserWasCreatedEvent -= DataWebBrowserConfigurationRunner_WebBrowserWasCreatedEvent;
            wbViewer = webBrowserCreatedEventArgs.WebBrowser;
        }

        private void DataWebBrowserConfigurationRunner_WebBrowserConfigurationWasInitialized(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
