using DataWebScraping.Common.DataWebScrapingStepProperties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace DataWebScraping.Common.DataWebScraperSteps
{
    public class DataWebScraperElementFinder
    {
        public HtmlElement FindElement(string elementNameToFindValue, string attributeToFindElementByPropertyValue, IEnumerable<string> attributeToMatchElementPropertyValues, WebBrowser webBrowser)
        {
            //Creao que puedo usar solo esto en vez de obtener por id y despues por atrbituo,
            //el id puede ser un atribute y solo pasar todos los atrbitueos

            //foreach (HtmlElement HtmlElementitem in webBrowser.Document.Window.Frames[0].Document.Body.All)
            //{
            //    if (HtmlElementitem.GetAttribute("value") == "Go" &&
            //        HtmlElementitem.GetAttribute("name") == "GoButton" &&
            //        HtmlElementitem.GetAttribute("type") == "image")
            //    {
            //        HtmlElementitem.InvokeMember("click");
            //        return true;
            //    }
            //}

            List<HtmlElement> elements = new List<HtmlElement>();

            if (attributeToFindElementByPropertyValue == AttributeToFindElementByType.Id)
            {
                var element = webBrowser.Document.Window.Frames[0].Document.GetElementById(elementNameToFindValue);
                if(element != null)
                {
                    elements.Add(element);
                }

            }else if (attributeToFindElementByPropertyValue == AttributeToFindElementByType.TagName)
            {
                HtmlElementCollection elems = webBrowser.Document.Window.Frames[0].Document.GetElementsByTagName(elementNameToFindValue);                
                foreach(HtmlElement e in elems)
                {
                    elements.Add(e);
                }
            }   
            
            if(elements.Count == 0)
            {
                throw new MissingMemberException($"The element {elementNameToFindValue} does not exist.");
            }

            if(attributeToMatchElementPropertyValues.Count() > 0)
            {

            }
            else
            {
                return elements.First();
            }

            return null;
        }
    }
}