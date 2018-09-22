using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DataWebScraping.Common.DataWebScraperStep;
using DataWebScraping.Common.DataWebScraperStep.Converter;

namespace DataWebScraping.Common.IteratorUtility
{
    public class DataWebScraperSelfIterator : IDataWebScraperSelfIterator
    {
        private IDataWebScraperStepRunnable _currentDataWebScraperStepRunnable;

        public event EventHandler DataWebScraperSelfIteratorWasComplete;

        public Iterator<IDataWebScraperStep> Iterator { get; private set; }
        public DataWebScraperToRunnableConverter DataWebScraperToRunnableConverter { get; }
        public WebBrowser WebBrowser { get; }        

        public DataWebScraperSelfIterator(DataWebScraperToRunnableConverter dataWebScraperToRunnableConverter, WebBrowser webBrowser)
        {            
            DataWebScraperToRunnableConverter = dataWebScraperToRunnableConverter;
            WebBrowser = webBrowser;
        }

        private void ExecuteElement(IDataWebScraperStep dataWebScraperStep, WebBrowser webBrowser)
        {
            if (dataWebScraperStep != null)
            {
                IDataWebScraperStepRunnable dataWebScraperStepRunnable = DataWebScraperToRunnableConverter.Convert(dataWebScraperStep);

                _currentDataWebScraperStepRunnable = dataWebScraperStepRunnable;

                dataWebScraperStepRunnable.StepWasCompleted += DataWebScraperStepRunnable_StepWasCompleted;
                dataWebScraperStepRunnable.Run(webBrowser);
            }
            else
            {
                DataWebScraperSelfIteratorWasComplete?.Invoke(this, null);
            }
        }

        private void DataWebScraperStepRunnable_StepWasCompleted(object sender, EventArgs e)
        {
            var r = sender as IDataWebScraperStepRunnable;
            r.StepWasCompleted -= DataWebScraperStepRunnable_StepWasCompleted;

            Iterator.MoveToNexElement();
            ExecuteElement(Iterator.CurrentElement(), WebBrowser);
        }

        public void SetElements(IEnumerable<IDataWebScraperStep> dataWebScraperSteps)
        {
            Iterator = new Iterator<IDataWebScraperStep>(dataWebScraperSteps);
        }

        public void Iterate()
        {
            _currentDataWebScraperStepRunnable = null;
            Iterator.Start();
            ExecuteElement(Iterator.CurrentElement(), WebBrowser);
        }
    }
}