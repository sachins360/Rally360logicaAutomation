using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace RallyTeam.UILocators
{
    public static class AuthenticationUI
    {
        public readonly static By workEmail = By.Name("email");
        public readonly static By password = By.Name("password");
        public readonly static By logInBtn = By.XPath("//button[text()='Log in']");
        public readonly static By loginForm = By.XPath("//form[@name= 'loginForm']");
        public readonly static By forgotPwd = By.XPath("//a[text()='Forgot password?']");
        public readonly static By signUp = By.XPath("//span[text()='Sign Up']");
        public readonly static By registrationLogInBtn= By.XPath("//button[text()='Log in']");
        public readonly static By errorMessage = By.XPath("//div[contains(text(), 'Please fill out the missing info.')]");
        public readonly static By errorMessageForInvalidEmail = By.XPath("//div[contains(text(), 'Bad Request. Could not find the user with email')]");
        public readonly static By forgotPwdPage = By.XPath("//div[contains(text(), 'Forgot your password?')]");
        public readonly static By submitBtn = By.XPath("//button[text()='Submit']");
        public readonly static By goBackLink = By.XPath("//a[text()='Go Back']");
        public readonly static By resendEmailBtn = By.XPath("//button[text()='Resend Email']");
        public readonly static By deactivatedMsg = By.XPath("//div[contains(text(),'Your account was deactivated. Please contact your admin for more information.')]");

    }
}
