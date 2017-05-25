using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace RallyTeam.UILocators
{
    public static class RegistrationUI
    {
        public readonly static By logInBtn = By.XPath("//button[text()='Log in']");
        public readonly static By loginDiv = By.XPath("//div[contains(text(), 'Log in with')]");
        public readonly static By forgotPwd = By.XPath("//a[text()='Forgot password?']");
        public readonly static By registrationLogInBtn = By.XPath("//button[text()='Log in']");
        public readonly static By forgotPwdPage = By.XPath("//div[contains(text(), 'Forgot your password?')]");
        public readonly static By submitBtn = By.XPath("//button[text()='Submit']");
        public readonly static By goBackLink = By.XPath("//a[text()='Go Back']");

        public readonly static By workEmail = By.Name("email");
        public readonly static By firstName = By.Name("firstName");
        public readonly static By lastName = By.Name("lastName");
        public readonly static By signUpButton = By.XPath("//button[text()='Sign Up']");
        public readonly static By disabledSignUpButton = By.XPath("//button[text()='Sign Up' and @disabled= 'disabled']");
        public readonly static By linkedinIcon = By.XPath("//ul[@class='social-list']//li[1]");
        public readonly static By googleIcon = By.XPath("//ul[@class='social-list']//li[2]");
        public readonly static By outlookIcon = By.XPath("//ul[@class='social-list']//li[3]");
        public readonly static By termsOfUseLink = By.XPath("//a[text()='Terms of Use']");
        public readonly static By privacyPolicyLink = By.XPath("//a[text()='Privacy Policy']");
        public readonly static By createPassword = By.XPath("//form[contains(@class, 'form-horizontal')]//input[@name='password']");
        public readonly static By confirmPassword = By.XPath("//form[contains(@class, 'form-horizontal')]//input[@name='confirmPassword']");
        public readonly static By allDoneButton = By.XPath("//form[contains(@class, 'form-horizontal')]//button[contains(text(), 'All Done')]");
        public readonly static By duplicateEmailErrorMessage = By.XPath("//div[contains(text(), 'We thought you looked familiar. This email address has already been registered. Please try another one or log-in to enter.')]");
        public readonly static By errorMessage = By.XPath("//div[contains(text(), 'Please fill out the missing info.')]");
        public readonly static By createPwdEmpty = By.XPath("//div[contains(text(), 'Password does not meet the criteria.')]");
        public readonly static By shortPwdError = By.XPath("//div[contains(text(), 'Password does not meet the criteria.')]");
        public readonly static By differentPwdError = By.XPath("//div[contains(text(), 'Passwords do not match. Please try again.')]");        
        public readonly static By confirmPwdEmpty = By.XPath("//div[contains(text(), 'Passwords do not match. Please try again.')]");
        public readonly static By invalidEmailErrorMessage = By.XPath("//div[contains(text(), 'Sorry, your current organization or email address is not valid')]");
        public readonly static By resendEmailBtn = By.XPath("//button[text()='Resend Email']");
        public readonly static By notYouLink = By.XPath("//a[text()='not you?']");

        
    }
}
