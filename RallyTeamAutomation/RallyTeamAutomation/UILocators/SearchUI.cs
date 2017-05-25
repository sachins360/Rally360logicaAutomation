using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RallyTeam.UILocators
{
    public static class SearchUI
    {

        //public readonly static By searchResult = By.XPath("//span");
        public readonly static By searchPage = By.XPath("//div[contains(text(), 'Search')]");

        public static By searchResult(String variable)
        {
            return By.XPath("//span[contains(text(), '" + variable + "') and @class='highlightedText']");
        }

        public readonly static By search = By.XPath("//input[@placeholder= 'What can we help you find?']");
        public readonly static By searchBtn = By.XPath("//a[contains(text(), 'Search')]");
        public readonly static By allRadio = By.Id("optionsRadios1");
        public readonly static By usersRadio = By.Id("optionsRadios2");
        public readonly static By groupsRadio = By.Id("optionsRadios3");
        public readonly static By eventsRadio = By.Id("optionsRadios4");
        public readonly static By ProjectsRadio = By.Id("optionsRadios5");

        public readonly static By zeroSearch = By.XPath("//div[contains(text(), '0 results found for: ')]");
        public readonly static By emptySearchMsg = By.XPath("//h2[contains(text(), 'What can we help you find?')]");




    }
}
