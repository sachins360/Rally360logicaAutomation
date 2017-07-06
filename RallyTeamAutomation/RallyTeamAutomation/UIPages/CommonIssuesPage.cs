using OpenQA.Selenium;
using RallyTeam.Util;
using RallyTeam.UILocators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Interactions;
using System.Collections.ObjectModel;

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

        //Enter Project Name
        public void EnterPayerName(String  _name)
        {
            bool isPayerTextboxEmpthy = _driver.IsElementVisible(DashboardUI.payerNameCrossIcon);
            if (isPayerTextboxEmpthy)
            {
                _driver.SafeClick(DashboardUI.payerNameCrossIcon);
            }             

            _driver.WaitForElementAvailableAtDOM(DashboardUI.payerNametxt, 1);            
            _driver.SafeEnterText(DashboardUI.payerNametxt, _name);
            commonPage.PressEnterKey();
        }

        public void EnterInvoiceDesignatedPayor(string _payerName)
        {
            bool configureFlag = _driver.IsElementVisible(DashboardUI.configureLink);
            if (configureFlag)
            {
                _driver.SafeClick(DashboardUI.configureLink);
            }
            else
            {
                //on the invoice payment option                
                ReadOnlyCollection<IWebElement> lstAdminDiv = _driver.FindElements(DashboardUI.allAdminDiv);
                for (int i = 1; i < lstAdminDiv.Count; i++)
                {
                    bool invoiceAndPaymentDivFlag = _driver.IsElementVisible(DashboardUI.invoiceAndPaymentDiv(i));
                    if (invoiceAndPaymentDivFlag)
                    {
                        _driver.SafeClick(DashboardUI.invoiceAndPaymentSwitch(i));
                        break;
                    }
                }
                _driver.SafeClick(DashboardUI.configureLink);
            }
            EnterPayerName(_payerName);     

        }
    }
}
