using NUnit.Framework;
using RallyTeam.UILocators;
using RallyTeam.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace RallyTeam.TestScripts
{
    [TestFixture("ExternalStormURL", "chrome", Category = "AuthenticationChromePreprod")]
    [TestFixture("ExternalStormURL", "firefox", Category = "AuthenticationFirefoxPreprod")]
    [TestFixture("Production", "chrome", Category = "AuthenticationChromeProduction")]
    [TestFixture("Production", "firefox", Category = "AuthenticationFirefoxProduction")]
    [Parallelizable(ParallelScope.Fixtures)]
    public class AuthenticationTest : BaseTestWithoutLogin
    {
        public AuthenticationTest(string urlKey, string Browser) : base(urlKey, Browser)
        {
            String url = urlKey;
        }

        static ReadData readAuthentication = new ReadData("Authentication");

        [Test, CustomRetry(_reTryCount)]
        public void Authentication_Login_001_VerifyLoginUrl()
        {
            Global.MethodName = "Authentication_Login_001_VerifyLoginUrl";

            Thread.Sleep(2000);
            authenticationPage.VerifyLoginPage();
            log.Info("Verify Login Url Page");
        }

        [Test, CustomRetry(_reTryCount)]
        public void Authentication_Login_002_VerifyLoginPageFields()
        {
            Global.MethodName = "Authentication_Login_002_VerifyLoginPageFields";

            //Verify the Work Email field
            Thread.Sleep(2000);
            authenticationPage.VerifyWorkEmail();
            log.Info("Verify Work Email");
            Thread.Sleep(2000);

            //Verify the Password field
            authenticationPage.VerifyPassword();
            log.Info("Verify Password");
            Thread.Sleep(1000);

            //Verify the Login Button field
            authenticationPage.VerifyLoginBtn();
            log.Info("Verify Login Button");
            Thread.Sleep(1000);

            //Verify the Forgot Password field
            authenticationPage.VerifyForgotPwd();
            log.Info("Verify Forgot Password");
            Thread.Sleep(1000);

            //Verify the SignUp field
            authenticationPage.VerifySignUp();
            log.Info("Verify SignUp");
        }

        /*Login button has been removed from Registration page
        [Test]
        public void Authentication_Login_003_ClickRegistrationLogin()
        {
            Global.MethodName = "Authentication_Login_003_ClickRegistrationLogin";

            //Click the SignUp link
            Thread.Sleep(2000);
            authenticationPage.ClickOnSignUpLink();
            log.Info("Click SignUp link.");
            Thread.Sleep(5000);

            //Click the Login Button field at Registration page
            authenticationPage.ClickRegistrationLoginBtn();
            log.Info("Click Login Button on Registration page.");
            Thread.Sleep(5000);

            //Verify the login page is displayed
            authenticationPage.VerifyLoginPage();
            log.Info("Verify Login Url Page");
        }*/

        [Test, CustomRetry(_reTryCount)]
        public void Authentication_Login_004_LoginWithEmptyFields()
        {
            Global.MethodName = "Authentication_Login_004_LoginWithEmptyFields";

            //Click the Login button
            Thread.Sleep(2000);
            authenticationPage.ClickOnLoginButton();
            log.Info("Click SignUp link.");
            Thread.Sleep(2000);

            //Verify the error Message displayed
            authenticationPage.ErrorMessage();
            log.Info("Verify the error message for empty fields.");
        }

        [Test, CustomRetry(_reTryCount)]
        public void Authentication_Login_005_InvalidUserNamePwd()
        {
            Global.MethodName = "Authentication_Login_005_InvalidUserNamePwd";

            //Enter invalid Work Email
            Thread.Sleep(2000);
            authenticationPage.SetUserName("InvalidWorkEmail.com");
            log.Info("Enter invalid work email.");
            Thread.Sleep(1000);

            //Enter invalid password
            authenticationPage.SetPassword("invalid");
            log.Info("Enter invalid password.");
            Thread.Sleep(1000);

            //Click the Login button            
            authenticationPage.ClickOnLoginButton();
            log.Info("Click SignUp link.");
            Thread.Sleep(5000);

            //Verify the error Message displayed
            authenticationPage.ErrorMessage();
            log.Info("Verify the error message for empty fields.");
            Thread.Sleep(2000);
        }

        [Test, CustomRetry(_reTryCount)]
        public void Authentication_Login_006_SuccessfulLogin()
        {
            Global.MethodName = "Authentication_Login_006_SuccessfulLogin";

            //Enter valid Work Email
            Thread.Sleep(2000);
            String workEmail = readAuthentication.GetValue("Credentials", "workEmail");
            authenticationPage.SetUserName(workEmail);
            log.Info("Enter valid work email.");
            Thread.Sleep(1000);

            //Enter valid password
            String password = readAuthentication.GetValue("Credentials", "password");
            authenticationPage.SetPassword(password);
            log.Info("Enter valid password.");
            Thread.Sleep(1000);

            //Click the Login button            
            authenticationPage.ClickOnLoginButton();
            log.Info("Click SignUp link.");
            Thread.Sleep(5000);

            //Verify the login success by asserting user icon
            authenticationPage.VerifyUserIcon();
            log.Info("Verify the login success by asserting user icon.");
            Thread.Sleep(2000);
        }

        [Test, CustomRetry(_reTryCount)]
        public void Authentication_Login_008_SuccessfulSignOut()
        {
            Global.MethodName = "Authentication_Login_008_SuccessfulSignOut";

            //Enter valid Work Email
            Thread.Sleep(2000);
            String workEmail = readAuthentication.GetValue("Credentials", "workEmail");
            authenticationPage.SetUserName(workEmail);
            log.Info("Enter valid work email.");
            Thread.Sleep(1000);

            //Enter valid password
            String password = readAuthentication.GetValue("Credentials", "password");
            authenticationPage.SetPassword(password);
            log.Info("Enter valid password.");
            Thread.Sleep(1000);

            //Click the Login button            
            authenticationPage.ClickOnLoginButton();
            log.Info("Click SignUp link.");
            Thread.Sleep(6000);

            //Signout of the application
            authenticationPage.SignOut();
            log.Info("Signout of the application.");
            Thread.Sleep(5000);

            //Verify the login page is displayed
            authenticationPage.VerifyLoginPage();
            log.Info("Verify Login Url Page");
        }

        [Test, CustomRetry(_reTryCount)]
        public void Authentication_Login_010_ClickForgotPwd()
        {
            Global.MethodName = "Authentication_Login_010_ClickForgotPwd";

            //Click the Forgot Password       
            Thread.Sleep(2000);
            authenticationPage.ClickForgotPwd();
            log.Info("Click Forgot Password link.");
            Thread.Sleep(5000);

            //Verify the Forgot Password page is displayed
            authenticationPage.VerifyForgotPwdPage();
            log.Info("Verify Forgot Password Page is displayed.");
        }

        [Test, CustomRetry(_reTryCount)]
        public void Authentication_Login_011_ClickForgotPwdAndVerify()
        {
            Global.MethodName = "Authentication_Login_011_ClickForgotPwdAndVerify";

            //Click the Forgot Password       
            Thread.Sleep(2000);
            authenticationPage.ClickForgotPwd();
            log.Info("Click Forgot Password link.");
            Thread.Sleep(5000);

            //Verify the Work Email field
            authenticationPage.VerifyWorkEmail();
            log.Info("Verify Work Email.");
            Thread.Sleep(1000);

            //Verify the Submit button
            authenticationPage.VerifyForgotPwdSubmitBtn();
            log.Info("Verify Submit button.");
            Thread.Sleep(1000);

            //Verify the Go Back Link
            authenticationPage.VerifyForgotPwdGoBackLink();
            log.Info("Verify Go Back Link.");
        }

        [Test, CustomRetry(_reTryCount)]
        public void Authentication_Login_012_ClickSubmitWithoutEmail()
        {
            Global.MethodName = "Authentication_Login_012_ClickSubmitWithoutEmail";

            //Click the Forgot Password       
            Thread.Sleep(2000);
            authenticationPage.ClickForgotPwd();
            log.Info("Click Forgot Password link.");
            Thread.Sleep(5000);

            //Click the Submit button
            authenticationPage.ClickForgotPwdSubmitBtn();
            log.Info("Click Submit button.");
            Thread.Sleep(5000);

            //Verify the errorMessage
            authenticationPage.ErrorMessage();
            log.Info("Verify the error message displayed.");
        }

        [Test, CustomRetry(_reTryCount)]
        public void Authentication_Login_013_ClickSubmitWithInvalidEmail()
        {
            Global.MethodName = "Authentication_Login_013_ClickSubmitWithInvalidEmail";

            //Click the Forgot Password       
            authenticationPage.ClickForgotPwd();
            log.Info("Click Forgot Password link.");
            Thread.Sleep(5000);

            // Enter invalid Work Email
           // Thread.Sleep(2000);
            authenticationPage.SetUserName("InvalidWorkEmail.com");
            log.Info("Enter invalid work email.");
            Thread.Sleep(5000);

         

            //Click the Submit button
            authenticationPage.ClickForgotPwdSubmitBtn();
            log.Info("Click Submit button.");
            Thread.Sleep(5000);

            //Verify the errorMessage
            authenticationPage.ErrorMessage();
            log.Info("Verify the error message displayed.");
        }

        [Test, CustomRetry(_reTryCount)]
        public void Authentication_Login_014_VerifyResendEmail()
        {
            Global.MethodName = "Authentication_Login_014_VerifyResendEmail";

            //Click the Forgot Password       
            Thread.Sleep(2000);
            authenticationPage.ClickForgotPwd();
            log.Info("Click Forgot Password link.");
            Thread.Sleep(5000);

            //Enter valid Work Email
            String workEmail = readAuthentication.GetValue("Credentials", "workEmail");
            authenticationPage.SetUserName(workEmail);
            log.Info("Enter valid work email.");
            Thread.Sleep(1000);

            //Click the Submit button
            authenticationPage.ClickForgotPwdSubmitBtn();
            log.Info("Click Submit button.");
            Thread.Sleep(5000);

            //Verify the Resend Email button
            authenticationPage.VerifyResendEmailBtn();
            log.Info("Verify the Resend Email button is displayed.");
        }
    }
}