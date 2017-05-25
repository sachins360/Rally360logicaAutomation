using OpenQA.Selenium;
using RallyTeam.Util;
using RallyTeam.UILocators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Interactions;

namespace RallyTeam.UIPages
{
    public class SearchPage : BasePage
    {
        CommonMethods commonPage;

        public SearchPage(IWebDriver driver, int pageLoadTimeout)
            : base(driver, pageLoadTimeout)
        {
            commonPage = new CommonMethods(_driver, pageLoadTimeout);
        }

        //Press Enter Key
        public void PressEnterKey()
        {
            _driver.PressKeyBoardEnter();
        }

        //Press Tab Key
        public void PressTabKey()
        {
            _driver.PressKeyBoardTab();
        }

        //Assert Search menu option
        public void VerifySearchMenuOption()
        {
            _assertHelper.AssertElementDisplayed(DashboardUI.searchText);
        }

        //Enter Search menu option
        public void EnterSearchMenuOption(String search)
        {
            _driver.SafeEnterText(DashboardUI.searchText, search);
        }

        //Assert Search Page is displayed
        public void VerifySearchPage()
        {
            _assertHelper.AssertElementDisplayed(SearchUI.searchPage);
        }

        //Assert Search Result
        public void VerifySearchResult(String search)
        {
            _assertHelper.AssertElementDisplayed(SearchUI.searchResult(search));
        }

        //Assert Search Result Not Displayed
        public void VerifySearchResultNotDisplayed(String search)
        {
            _assertHelper.AssertElementNotDisplayed(SearchUI.searchResult(search));
        }

        //Click All Radio button
        public void ClickAllRadio()
        {
            _driver.WaitForElementAvailableAtDOM(SearchUI.allRadio, 1);
            _driver.SafeClick(SearchUI.allRadio);
        }

        //Click Group Radio button
        public void ClickGroupRadio()
        {
            _driver.WaitForElementAvailableAtDOM(SearchUI.groupsRadio, 1);
            _driver.SafeClick(SearchUI.groupsRadio);
        }

        //Click Users Radio button
        public void ClickUsersRadio()
        {
            _driver.WaitForElementAvailableAtDOM(SearchUI.usersRadio, 1);
            _driver.SafeClick(SearchUI.usersRadio);
        }

        //Click Events Radio button
        public void ClickEventsRadio()
        {
            _driver.WaitForElementAvailableAtDOM(SearchUI.eventsRadio, 1);
            _driver.SafeClick(SearchUI.eventsRadio);
        }

        //Click Projects Radio button
        public void ClickProjectsRadio()
        {
            _driver.WaitForElementAvailableAtDOM(SearchUI.ProjectsRadio, 1);
            _driver.SafeClick(SearchUI.ProjectsRadio);
        }

        //Assert the Zero result displayed
        public void VerifyZeroSearch()
        {
            _assertHelper.AssertElementDisplayed(SearchUI.zeroSearch);
        }

        //Assert Seach Text Field
        public void VerifySearchField()
        {
            _assertHelper.AssertElementDisplayed(SearchUI.search);
        }

        //Assert Search button
        public void VerifySearchBtn()
        {
            _assertHelper.AssertElementDisplayed(SearchUI.searchBtn);
        }

        //Assert All Radio button
        public void VerifyAllRadioBtn()
        {
            _assertHelper.AssertElementDisplayed(SearchUI.allRadio);
        }

        //Assert Users Radio button
        public void VerifyUsersRadioBtn()
        {
            _assertHelper.AssertElementDisplayed(SearchUI.usersRadio);
        }

        //Assert Groups Radio button
        public void VerifyGroupsRadioBtn()
        {
            _assertHelper.AssertElementDisplayed(SearchUI.groupsRadio);
        }

        //Assert Events Radio button
        public void VerifyEventsRadioBtn()
        {
            _assertHelper.AssertElementDisplayed(SearchUI.eventsRadio);
        }

        //Assert Projects Radio button
        public void VerifyProjectsRadioBtn()
        {
            _assertHelper.AssertElementDisplayed(SearchUI.ProjectsRadio);
        }

        //Assert Empty Sarch Message
        public void VerifyEmptySearchMsg()
        {
            _assertHelper.AssertElementDisplayed(SearchUI.emptySearchMsg);
        }

    }
}
