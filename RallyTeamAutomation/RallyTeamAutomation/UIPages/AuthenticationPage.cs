using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using RallyTeam.UILocators;
using RallyTeam.Util;
using System.Threading;
using RallyTeam.UILocators;

namespace RallyTeam.UIPages
{
    public class AuthenticationPage : BasePage
    {
        CommonMethods commonPage;

        public AuthenticationPage(IWebDriver driver, int pageLoadTimeout)
            : base(driver, pageLoadTimeout)
        {
            commonPage = new CommonMethods(_driver, pageLoadTimeout);
        }

        public AuthenticationPage NavigateTo(String _URL)
        {
            _driver.Navigate().GoToUrl(_URL);
            return this;
        }

        //Assert Login Page    
        public void VerifyLoginPage()
        {
            _assertHelper.AssertElementDisplayed(AuthenticationUI.loginForm);
        }

        //Assert Work Email
        public void VerifyWorkEmail()
        {
            _assertHelper.AssertElementDisplayed(AuthenticationUI.workEmail);
        }

        //Assert Password
        public void VerifyPassword()
        {
            _assertHelper.AssertElementDisplayed(AuthenticationUI.password);
        }

        //Assert Login button
        public void VerifyLoginBtn()
        {
            _assertHelper.AssertElementDisplayed(AuthenticationUI.logInBtn);
        }

        //Assert Forgot Password
        public void VerifyForgotPwd()
        {
            _assertHelper.AssertElementDisplayed(AuthenticationUI.forgotPwd);
        }

        //Assert SignUp
        public void VerifySignUp()
        {
            _assertHelper.AssertElementDisplayed(AuthenticationUI.signUp);
        }

        // Set Work Email
        public void SetUserName(string userName)
        {
            _driver.WaitForElementVisible(AuthenticationUI.workEmail);
            _driver.SafeEnterText(AuthenticationUI.workEmail, userName);
        }

        // Set password
        public void SetPassword(string password)
        {
            _driver.SafeEnterText(AuthenticationUI.password, password);
        }

        // Click on Login button
        public void ClickOnLoginButton(int _announcementPopupTimeout=25,bool _switch=false)
        {
            _driver.WaitForElementAvailableAtDOM(AuthenticationUI.logInBtn, 1);
            IWebElement button = _driver.FindElement(AuthenticationUI.logInBtn);
            _driver.SafeClick(AuthenticationUI.logInBtn);
            CloseAnnouncementPopup(_announcementPopupTimeout, _switch);
        }

        // Click on SignUp link
        public void ClickOnSignUpLink()
        {
            _driver.WaitForElementAvailableAtDOM(AuthenticationUI.signUp, 1);
            _driver.SafeClick(AuthenticationUI.signUp);
        }

        //Click Forgot Password
        public void ClickForgotPwd()
        {
            _driver.SafeClick(AuthenticationUI.forgotPwd);
        }

        // Click on Login button on Registration page
        public void ClickRegistrationLoginBtn()
        {
            _driver.WaitForElementAvailableAtDOM(AuthenticationUI.registrationLogInBtn, 1);
            _driver.SafeClick(AuthenticationUI.registrationLogInBtn);
        }

        //Assert RallyTeam Home Page
        public void VerifyHomeScreen()
        {
            _assertHelper.AssertElementDisplayed(DashboardUI.rallyNowHdr);

        }

        //Click on the User Icon at the top
        public void ClickUserIcon()
        {
            _driver.SafeClick(DashboardUI.userIcon);
        }

        //Assert on the User Icon at the top
        public void VerifyUserIcon()
        {
            _assertHelper.AssertElementDisplayed(DashboardUI.userIcon);
        }

        //Click on the Sign out link
        public void SignOut()
        {
            _driver.CheckElementVisibility(DashboardUI.userIcon);
            _driver.ScrollWindowToElement(DashboardUI.userIcon);
            _driver.ClickElementUsingAction(DashboardUI.userIcon);
            Thread.Sleep(2000);
            _driver.ClickElementUsingAction(DashboardUI.signOut);
        }

        //Assert the error message
        public void ErrorMessage()
        {
            _assertHelper.AssertElementDisplayed(AuthenticationUI.errorMessage);
        }

        //Assert Forgot Password Page
        public void VerifyForgotPwdPage()
        {
            _assertHelper.AssertElementDisplayed(AuthenticationUI.forgotPwdPage);
        }

        //Assert Forgot Password Submit button
        public void VerifyForgotPwdSubmitBtn()
        {
            _assertHelper.AssertElementDisplayed(AuthenticationUI.submitBtn);
        }

        //Assert Forgot Password Page
        public void VerifyForgotPwdGoBackLink()
        {
            _assertHelper.AssertElementDisplayed(AuthenticationUI.goBackLink);
        }

        //Click Forgot Password Submit button
        public void ClickForgotPwdSubmitBtn()
        {
            _driver.SafeClick(AuthenticationUI.submitBtn);
        }

        //Assert the Resend Email button
        public void VerifyResendEmailBtn()
        {
            _assertHelper.AssertElementDisplayed(AuthenticationUI.resendEmailBtn);
        }

        //public void CloseAnnouncementPopup()
        //{
        //    _driver.SafeClick(AuthenticationUI.announcementCloseButton);
        //}

        public void CloseAnnouncementPopup(int _announcementPopupTimeout,bool _switch=false)
        {
            try
            {
                if (_switch) return;
                Thread.Sleep(3000);
                //_driver.SafeClick(AuthenticationUI.announcementCloseButton);
                IWebElement popup = _driver.FindElementFlexible(AuthenticationUI.announcementCloseButton, _announcementPopupTimeout);
                while (popup != null)
                {                  
                        if (popup.Displayed)
                        {
                            //Thread.Sleep(2000);
                            //commonPage.RefreshPage();
                            Thread.Sleep(5000);
                            _driver.ClickElementUsingAction(AuthenticationUI.announcementCloseButton);
                        }                    
                    Thread.Sleep(3000);
                    popup = _driver.FindElementFlexible(AuthenticationUI.announcementPopup, _announcementPopupTimeout);
                } 
            }
            catch { }
            Thread.Sleep(3000);
        }
    }
}
