using DataWebScraping.Common.DataWebScraperStep.Property;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace DataWebScraping.Common.WebBrowserUtility
{
    public class DataWebScraperElementFinder
    {      
        public HtmlElement FindElement(IEnumerable<IDataWebScraperStepProperty> attributeToFindElementByProperties, WebBrowser webBrowser)
        {
            if(attributeToFindElementByProperties.Count() <= 0)
            {
                throw new NullReferenceException("The attributes to find elements could not be empty");
            }

            HtmlElement HtmlElementItemResult = null;

            try
            {

                HtmlWindow htmlWindow = webBrowser.Document.Window;
                HtmlElementCollection all = htmlWindow.Document.Body.All;

                foreach (HtmlElement HtmlElementItem in all)
                {
                    bool isFound = FindElement(HtmlElementItem, attributeToFindElementByProperties);                    

                    if (isFound)
                    {
                        HtmlElementItemResult = HtmlElementItem;
                        break;
                    }                    
                }

                if (HtmlElementItemResult == null)
                {
                    throw new MissingMemberException("There is no element that match with the properties.");
                }

                return HtmlElementItemResult;
            }catch(Exception e)
            {
                string s = e.Message;
            }

            return null;

        }

        private bool FindElement(HtmlElement htmlElementItem, IEnumerable<IDataWebScraperStepProperty> attributeToFindElementByProperties)
        {
            bool isFound = true;            

            foreach (IDataWebScraperStepProperty dataWebScraperStepProperty in attributeToFindElementByProperties)
            {
                string htmlAttribute = htmlElementItem.GetAttribute(dataWebScraperStepProperty.Key);
                if (htmlAttribute?.ToUpper() != dataWebScraperStepProperty.Value.ToUpper())
                {
                    isFound = false;
                    break;
                }
            }

            return isFound;
        }
    }
}