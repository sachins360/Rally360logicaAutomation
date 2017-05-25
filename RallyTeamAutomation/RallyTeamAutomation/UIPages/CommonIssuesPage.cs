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
    public class CommonIssuesPage : BasePage
    {
        CommonMethods commonPage;

        public CommonIssuesPage(IWebDriver driver, int pageLoadTimeout)
            : base(driver, pageLoadTimeout)
        {
            commonPage = new CommonMethods(_driver, pageLoadTimeout);
        }


        //Click on Marketplace tab
        public void DeaactivateUser()
        {
            Boolean b = true;
            b = _assertHelper.AssertElementDisplayedNoError(UserProfileUI.deactivate);
            if (b == false)
            {
                _driver.SafeClick(UserProfileUI.toggle);
            }
        }

        //Assert deactivated user message
        public void VerifyDeactivateUserMsg()
        {
            _assertHelper.AssertElementDisplayed(AuthenticationUI.deactivatedMsg);
        }

        //Assert error message not displayed on opening profile page
        public void VerifyErrorMsgNotDisplayedOpeningUserProfile()
        {
            _assertHelper.AssertElementNotDisplayed(UserProfileUI.errorOpeningUserProfile);
        }



    }
}
