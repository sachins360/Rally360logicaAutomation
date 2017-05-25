using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RallyTeam.UILocators;
using RallyTeam.Util;
using OpenQA.Selenium;
using System.Threading;
using OpenQA.Selenium.Interactions;
using RallyTeam.UILocators;

namespace RallyTeam.UIPages
{
    public class DashboardPage : BasePage
    {
        public DashboardPage(IWebDriver driver, int pageLoadTimeout)
            : base(driver, pageLoadTimeout)
        {

        }

        //Verify user login screen
        public void VerifyUserLoginSuccess()
        {
            _assertHelper.AssertElementDisplayed(DashboardUI.rallyNowHdr);

        }        

        //Press the Plus icon at the top of the page
        public void ClickPlusIconOnTop()
        {
            _driver.SafeClick(DashboardUI.plusIcon);
        }

        //Select an option from the Plus icon options
        public void SelectOptionFromPlusIcon(String variable)
        {
            _driver.SafeClick(DashboardUI.plusIconOptions(variable));
        }

    }
}
