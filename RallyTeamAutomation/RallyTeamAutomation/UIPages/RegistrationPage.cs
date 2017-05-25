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
    public class RegistrationPage : BasePage
    {
        CommonMethods commonPage;

        public RegistrationPage(IWebDriver driver, int pageLoadTimeout)
            : base(driver, pageLoadTimeout)
        {
            commonPage = new CommonMethods(_driver, pageLoadTimeout);
        }

        public RegistrationPage NavigateTo(String _URL)
        {
            _driver.Navigate().GoToUrl(_URL);
            return this;
        }

        // Assert Login button on Registration page
        public void VerifyRegistrationLoginBtn()
        {
            _assertHelper.AssertElementDisplayed(AuthenticationUI.registrationLogInBtn);
        }

        // Assert Linkedin Icon on Registration page
        public void VerifyLinkedinIcon()
        {
            _assertHelper.AssertElementDisplayed(RegistrationUI.linkedinIcon);
        }

        // Assert Google Plus Iconon Registration page
        public void VerifyGoogleIcon()
        {
            _assertHelper.AssertElementDisplayed(RegistrationUI.googleIcon);
        }

        // Assert Outlook Icon on Registration page
        public void VerifyOutlookIcon()
        {
            _assertHelper.AssertElementDisplayed(RegistrationUI.outlookIcon);
        }

        // Assert First Name on Registration page
        public void VerifyFirstName()
        {
            _assertHelper.AssertElementDisplayed(RegistrationUI.firstName);
        }

        // Assert Last Name on Registration page
        public void VerifyLastName()
        {
            _assertHelper.AssertElementDisplayed(RegistrationUI.lastName);
        }

        // Assert Work Email on Registration page
        public void VerifyWorkEmail()
        {
            _assertHelper.AssertElementDisplayed(RegistrationUI.workEmail);
        }

        // Assert SignUp Button on Registration page
        public void VerifySignUpBtn()
        {
            _assertHelper.AssertElementDisplayed(RegistrationUI.signUpButton);
        }

        // Assert Terms of Use on Registration page
        public void VerifyTermsOfUse()
        {
            _assertHelper.AssertElementDisplayed(RegistrationUI.termsOfUseLink);
        }

        // Assert Privacy Policy on Registration page
        public void VerifyPrivacyPolicy()
        {
            _assertHelper.AssertElementDisplayed(RegistrationUI.privacyPolicyLink);
        }

        //Enter First name field
        public void EnterFirstName(String firstName)
        {
            _driver.SafeEnterText(RegistrationUI.firstName, firstName);
        }

        //Enter Last name field
        public void EnterLastName(String lastName)
        {
            _driver.SafeEnterText(RegistrationUI.lastName, lastName);
        }

        //Enter Work Email field
        public void EnterWorkEmail(String email)
        {
            _driver.SafeEnterText(RegistrationUI.workEmail, email);
        }

        //Click SignUp button
        public void ClickSignUpBtn()
        {
            _driver.SafeClick(RegistrationUI.signUpButton);
        }

        //Verify disabled SignUp button
        public void VerifyDisabledSignUpBtn()
        {
            _driver.SafeClick(RegistrationUI.disabledSignUpButton);
        }

        //Assert the Duplicate Work Email Error message
        public void DuplicateEmailErrorMessage()
        {
            _assertHelper.AssertElementDisplayed(RegistrationUI.duplicateEmailErrorMessage);
        }

        //Assert the Error message
        public void ErrorMessage()
        {
            _assertHelper.AssertElementDisplayed(RegistrationUI.errorMessage);
        }

        //Assert the Error message
        public void DifferentPwdError()
        {
            _assertHelper.AssertElementDisplayed(RegistrationUI.differentPwdError);
        }

        //Assert the Error message
        public void ShortPwdError()
        {
            _assertHelper.AssertElementDisplayed(RegistrationUI.shortPwdError);
        }

        //Assert the Create Pwd empty message
        public void CreatePwdEmpty()
        {
            _assertHelper.AssertElementDisplayed(RegistrationUI.createPwdEmpty);
        }

        //Assert the Confirm Pwd empty message
        public void ConfirmPwdEmpty()
        {
            _assertHelper.AssertElementDisplayed(RegistrationUI.confirmPwdEmpty);
        }

        //Assert the Error message
        public void InvalidEmailErrorMessage()
        {
            _assertHelper.AssertElementDisplayed(RegistrationUI.invalidEmailErrorMessage);
        }

        //Assert Create a Password Field
        public void VerifyCreatePwdFields()
        {
            _assertHelper.AssertElementDisplayed(RegistrationUI.createPassword);
        }

        //Enter Create a Password Field
        public void EnterCreatePwdFields(String createPwd)
        {
            _driver.SafeEnterText(RegistrationUI.createPassword, createPwd);
        }

        //Assert Confirm Password Field
        public void VerifyConfirmPwdFields()
        {
            _assertHelper.AssertElementDisplayed(RegistrationUI.confirmPassword);
        }

        //Enter Confirm Password Field
        public void EnterConfirmPwdFields(String confirmPwd)
        {
            _driver.SafeEnterText(RegistrationUI.confirmPassword, confirmPwd);
        }

        //Assert Next Button
        public void VerifyAllDoneBtn()
        {
            _assertHelper.AssertElementDisplayed(RegistrationUI.allDoneButton);
        }

        //Click Next Button
        public void ClickAllDoneBtn()
        {
            _driver.SafeClick(RegistrationUI.allDoneButton);
        }

        //Click Not You Link
        public void ClickNotYouLink()
        {
            _driver.SafeClick(RegistrationUI.notYouLink);
        }
    }
}
