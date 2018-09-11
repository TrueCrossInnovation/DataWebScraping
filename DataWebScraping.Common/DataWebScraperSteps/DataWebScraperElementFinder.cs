using DataWebScraping.Common.DataWebScrapingStepProperties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace DataWebScraping.Common.DataWebScraperSteps
{
    public class DataWebScraperElementFinder
    {      
        public HtmlElement FindElement(IEnumerable<IDataWebScraperStepProperty> attributeToFindElementByProperties, WebBrowser webBrowser)
        {
            if(attributeToFindElementByProperties.Count() <= 0)
            {
                throw new NullReferenceException("The attrubutes to find elements could not be empty");
            }

            HtmlElement HtmlElementItemResult = null;

            foreach (HtmlElement HtmlElementItem in webBrowser.Document.Window.Frames[0].Document.Body.All)
            {                

                foreach(IDataWebScraperStepProperty dataWebScraperStepProperty in attributeToFindElementByProperties)
                {
                    if (HtmlElementItem.GetAttribute(dataWebScraperStepProperty.Key) != dataWebScraperStepProperty.Value)
                    {
                        break;
                    }
                }

                HtmlElementItemResult = HtmlElementItem;
                break;
            }

            if(HtmlElementItemResult == null)
            {
                throw new MissingMemberException("There is no element that match with the properties.");
            }

            return HtmlElementItemResult;
        }
    }
}