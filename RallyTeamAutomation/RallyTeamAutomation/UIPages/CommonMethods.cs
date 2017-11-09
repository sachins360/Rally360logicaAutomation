using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RallyTeam.UILocators;
using OpenQA.Selenium;
using RallyTeam.Util;
using System.Threading;
using RallyTeam.UILocators;
using RallyTeam.UIPages;

namespace RallyTeam.UIPages
{
    public class CommonMethods : BasePage
    {
        public CommonMethods(IWebDriver driver, int pageLoadTimeout)
            : base(driver, pageLoadTimeout)
        {

        }        

        //Navigate To Mailinator.com
        public void NavigateToUrl(String _navigateUrl)
        {
            _driver.Navigate().GoToUrl(_navigateUrl);
        }

        //Navigate To External Storm
        public void NavigateToExternalStorm(String _ExternalStormURL)
        {
            _driver.Navigate().GoToUrl(_ExternalStormURL);
        }

        //Refresh Page
        public void RefreshPage()
        {
            _driver.Navigate().Refresh();
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

        //Press Down Arrow Key
        public void PressDownArrowKey()
        {
            _driver.PressKeyBoardDownArrow();
        }

        //Get Highlighted Text (Not working for now)
        public void GetHighlightedText()
        {
            ((IJavaScriptExecutor)_driver).ExecuteScript("return window.getSelection().toString();");
            Console.WriteLine("JS returns: "+((IJavaScriptExecutor)_driver).ExecuteScript("return window.getSelection().toString();"));
        }

        //Scrollup
        public void ScrollUp()
        {
            ((IJavaScriptExecutor)_driver).ExecuteScript("window.scrollTo(document.body.scrollHeight - 200, 0)");
        }

        //Scrolldown
        public void ScrollDown()
        {
            ((IJavaScriptExecutor)_driver).ExecuteScript("window.scrollTo(0, document.body.scrollHeight - 200)");
        }
        public void HalfScrollDown(int size)
        {
            ((IJavaScriptExecutor)_driver).ExecuteScript("window.scrollTo(0, "+ size + ")");
        }
        //Scrolldown Variable
        public void ScrollDownVariable(int size)
        {
            ((IJavaScriptExecutor)_driver).ExecuteScript("window.scrollTo(0, document.body.scrollHeight - "+size+")");
        }

        //Get User name through User Icon
        public string GetUserName()
        {
            String userName = _driver.GetUserNameTooltipValue(DashboardUI.userIconToolTip);
            return userName;
        }

       

    }
}
