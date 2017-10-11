using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RallyTeam.UILocators
{
    public static class MarketPlaceUI
    {
        public readonly static By marketplaceTab = By.XPath("//a[text()= 'MARKETPLACE']");
        public readonly static By browseBtn = By.XPath("//a[text()= 'Browse All Opportunities']");
        public readonly static By searchText = By.XPath("//input[contains(@placeholder, 'What kind of opportunity are you looking for?')]");
        public readonly static By searchBtn = By.XPath("//span[contains(text(), 'Search')]");
        public readonly static By searchProjBtn = By.XPath("//button[text()= 'Search']"); 
        public readonly static By allProjectsDropDown = By.XPath("//div[@class='rt-marketplace__search-field--align']//select[@ng-model='vm.filter']");
        //public readonly static By allProjectsDropDown = By.XPath("//select[contains(@class, 'marketplace__search-filter')]");
        public readonly static By projectDraftStatus = By.XPath("//div[text()= 'Draft']");

        public static By ProjectNameOnPage(String variable)
        {
            return By.XPath("//div[contains(text(), '" + variable + "')]");
        }

        public static By RecProjectNameOnPage(String variable)
        {
            return By.XPath("//div[@class='col-md-10 col-sm-12 col-xs-12 m-b-lg']/div[contains( text(), '" + variable + "')]");
            //return By.XPath("//span[contains(text(), '" + variable + "')]");
        }
        



    }
}
