﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataWebScraping.Common.Configuration;
using DataWebScraping.Common.DataWebScraperStep;
using DataWebScraping.Common.DataWebScraperStep.Converter;
using DataWebScraping.Common.IteratorUtility;
using DataWebScraping.Common.ThreadUtility;
using DataWebScraping.Util;

namespace DataWebScraping.Common.WebBrowserUtility
{
    public class ThreadLockWebBrowserConfigurationRunner : AbstractWebBrowserConfigurationRunner
    {
        public ThreadLockWebBrowserConfigurationRunner() : this(new ThreadWrapperFactory(),
            new WebBrowserFactory(),
            new WebBrowserConfigurationRunnerProcessor(new DataWebScraperSelfIteratorFactory()),
            new WebBrowserDisposerFactory())
        {

        }

        internal ThreadLockWebBrowserConfigurationRunner(ThreadWrapperFactory threadWrapperFactory, 
            WebBrowserFactory webBrowserFactory, 
            WebBrowserConfigurationRunnerProcessor 
            webBrowserConfigurationRunnerProcessor, 
            WebBrowserDisposerFactory webBrowserDisposerFactory) : 
            base(threadWrapperFactory, 
                webBrowserFactory, 
                webBrowserConfigurationRunnerProcessor, 
                webBrowserDisposerFactory)
        {
        }

        internal override bool WaitForProcessToBeCompleted => true;
    }
}
