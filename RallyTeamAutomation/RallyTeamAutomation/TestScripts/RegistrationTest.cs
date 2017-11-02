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
    [TestFixture("ExternalStormURL", "chrome", Category = "RegistrationChromePreprod")]
    [TestFixture("ExternalStormURL", "ie", Category = "RegistrationIEPreprod")]
    [TestFixture("Production", "chrome", Category = "RegistrationChromeProduction")]
    [TestFixture("Production", "ie", Category = "RegistrationIEProduction")]
    [Parallelizable(ParallelScope.Fixtures)]
    public class RegistrationTest : BaseTestWithoutLogin
    {
        public RegistrationTest(string urlKey, string Browser) : base(urlKey, Browser)
        {
            String url = urlKey;
        }

        static ReadData readRegistration = new ReadData("Registration");

        [Test]
        public void Register_User_001_VerifySignUpOption()
        {
            Global.MethodName = "Register_User_001_VerifySignUpOption";

            Thread.Sleep(2000);
            authenticationPage.VerifySignUp();
            log.Info("Verify SignUp option given to the user.");
        }

        [Test]
        public void Register_User_002_VerifyRegistrationPage()
        {
            Global.MethodName = "Register_User_002_VerifyRegistrationPage";

            //Click SignUp link
            Thread.Sleep(2000);
            authenticationPage.ClickOnSignUpLink();
            log.Info("Click SignUp option given to the user.");
            Thread.Sleep(2000);

            //Verify First Name on the screen
            registrationPage.VerifyFirstName();
            log.Info("Verify First Name on the screen.");
            Thread.Sleep(2000);

            //Verify Last Name on the screen
            registrationPage.VerifyLastName();
            log.Info("Verify Last Name on the screen.");
            Thread.Sleep(2000);

            //Verify Work Email on the screen
            registrationPage.VerifyWorkEmail();
            log.Info("Verify Work Email on the screen.");
            Thread.Sleep(2000);

            //Verify SignUp button on the screen
            registrationPage.VerifySignUpBtn();
            log.Info("Verify SignUp button on the screen.");
            Thread.Sleep(2000);

            //Verify Terms Of Use on the screen
            registrationPage.VerifyTermsOfUse();
            log.Info("Verify Terms Of Use on the screen.");
            Thread.Sleep(2000);

            //Verify Privacy Policy on the screen
            registrationPage.VerifyPrivacyPolicy();
            log.Info("Verify Privacy Policy on the screen.");
        }

        [Test]
        public void Register_User_003_ClickSignUpAndVerify()
        {
            Global.MethodName = "Register_User_003_ClickSignUpAndVerify";

            //Click SignUp link
            Thread.Sleep(2000);
            authenticationPage.ClickOnSignUpLink();
            log.Info("Click SignUp option given to the user.");
            Thread.Sleep(2000);

            //Enter First Name on the screen
            String validFirstName = readRegistration.GetValue("Credentials", "validFirstName");
            registrationPage.EnterFirstName(validFirstName);
            log.Info("Enter First Name on the screen.");
            Thread.Sleep(2000);

            //Enter Last Name on the screen
            String validLastName = readRegistration.GetValue("Credentials", "validLastName");
            registrationPage.EnterLastName(validLastName);
            log.Info("Enter Last Name on the screen.");
            Thread.Sleep(2000);

            //Enter Work Email on the screen
            Thread.Sleep(5000);
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(6));
            String validWorkEmail = readRegistration.GetValue("Credentials", "validWorkEmail");
            String workEmail = builder + validWorkEmail;         
            registrationPage.EnterWorkEmail(workEmail);
            log.Info("Enter Work Email on the screen.");
            Thread.Sleep(2000);

            //Click SignUp button on the screen
            registrationPage.ClickSignUpBtn();
            log.Info("Click SignUp button on the screen.");
            Thread.Sleep(5000);

            //Verify Create a Password field on the screen
            registrationPage.VerifyCreatePwdFields();
            log.Info("Verify Create a Password field on the screen.");
            Thread.Sleep(2000);

            //Verify Confirm Password field on the screen
            registrationPage.VerifyConfirmPwdFields();
            log.Info("Verify Confirm Password field on the screen.");
            Thread.Sleep(2000);

            //Verify Next button on the screen
            registrationPage.VerifyAllDoneBtn();
            log.Info("Verify Next button on the screen.");
        }

        /*[Test]
        public void Register_User_006_VerifyNotYouLinkFunctionality()
        {
            Global.MethodName = "Register_User_006_VerifyNotYouLinkFunctionality";

            //Click SignUp link
            Thread.Sleep(2000);
            authenticationPage.ClickOnSignUpLink();
            log.Info("Click SignUp option given to the user.");
            Thread.Sleep(2000);

            //Enter First Name on the screen
            String validFirstName = readRegistration.GetValue("Credentials", "validFirstName");
            registrationPage.EnterFirstName(validFirstName);
            log.Info("Enter First Name on the screen.");
            Thread.Sleep(2000);

            //Enter Last Name on the screen
            String validLastName = readRegistration.GetValue("Credentials", "validLastName");
            registrationPage.EnterLastName(validLastName);
            log.Info("Enter Last Name on the screen.");
            Thread.Sleep(2000);

            //Enter Work Email on the screen
            String validWorkEmail = readRegistration.GetValue("Credentials", "validWorkEmail");
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(4));
            validWorkEmail = builder + validWorkEmail;
            registrationPage.EnterWorkEmail(validWorkEmail);
            log.Info("Enter Work Email on the screen.");
            Thread.Sleep(2000);

            //Click SignUp button on the screen
            registrationPage.ClickSignUpBtn();
            log.Info("Click SignUp button on the screen.");
            Thread.Sleep(5000);

            //Enter Create a Password field on the screen
            String createPwd = readRegistration.GetValue("Credentials", "createPwd");
            registrationPage.EnterCreatePwdFields(createPwd);
            log.Info("Enter Create a Password field on the screen.");
            Thread.Sleep(2000);

            //Enter Confirm Password field on the screen
            String confirmPwd = readRegistration.GetValue("Credentials", "confirmPwd");
            registrationPage.EnterConfirmPwdFields(confirmPwd);
            log.Info("Enter Confirm Password field on the screen.");
            Thread.Sleep(2000);

            //Click Next Button on the screen
            registrationPage.ClickAllDoneBtn();
            log.Info("Click Next button on the screen.");
            Thread.Sleep(2000);

            //Click Not you Link on the screen
            registrationPage.ClickNotYouLink();
            log.Info("Click Not You Link on the screen.");
            Thread.Sleep(5000);

            //Verify SignUp button on the screen
            registrationPage.VerifySignUpBtn();
            log.Info("Verify SignUp button on the screen.");
        }*/

        [Test]
        public void Register_User_007_EnterDuplicateEmailAndVerify()
        {
            Global.MethodName = "Register_User_007_EnterDuplicateEmailAndVerify";

            //Click SignUp link
            Thread.Sleep(2000);
            authenticationPage.ClickOnSignUpLink();
            log.Info("Click SignUp option given to the user.");
            Thread.Sleep(2000);

            //Enter First Name on the screen
            String duplicateFirstName = readRegistration.GetValue("Credentials", "duplicateFirstName");
            registrationPage.EnterFirstName(duplicateFirstName);
            log.Info("Enter First Name on the screen.");
            Thread.Sleep(2000);

            //Enter Last Name on the screen
            String duplicateLastName = readRegistration.GetValue("Credentials", "duplicateLastName");
            registrationPage.EnterLastName(duplicateLastName);
            log.Info("Enter Last Name on the screen.");
            Thread.Sleep(2000);

            //Enter Work Email on the screen
            String duplicateWorkEmail = readRegistration.GetValue("Credentials", "duplicateWorkEmail");
            registrationPage.EnterWorkEmail(duplicateWorkEmail);
            log.Info("Enter Work Email on the screen.");
            Thread.Sleep(2000);

            //Click SignUp button on the screen
            registrationPage.ClickSignUpBtn();
            log.Info("Click SignUp button on the screen.");
            Thread.Sleep(5000);

            //Verify Duplicate Error Message on the screen
            registrationPage.DuplicateEmailErrorMessage();
            log.Info("Verify Duplicate error message on the screen.");
        }

        [Test]
        public void Register_User_008_DoNotEnterEmailAndVerify()
        {
            Global.MethodName = "Register_User_008_DoNotEnterEmailAndVerify";

            //Click SignUp link
            Thread.Sleep(2000);
            authenticationPage.ClickOnSignUpLink();
            log.Info("Click SignUp option given to the user.");
            Thread.Sleep(2000);

            //Enter First Name on the screen
            String duplicateFirstName = readRegistration.GetValue("Credentials", "duplicateFirstName");
            registrationPage.EnterFirstName(duplicateFirstName);
            log.Info("Enter First Name on the screen.");
            Thread.Sleep(2000);

            //Enter Last Name on the screen
            String duplicateLastName = readRegistration.GetValue("Credentials", "duplicateLastName");
            registrationPage.EnterLastName(duplicateLastName);
            log.Info("Enter Last Name on the screen.");
            Thread.Sleep(2000);

            //Verify disabled SignUp button on the screen
            registrationPage.VerifyDisabledSignUpBtn();
            log.Info("Verify disabled  SignUp button on the screen.");
            Thread.Sleep(5000);

            /*//Verify Error Message on the screen
            registrationPage.ErrorMessage();
            log.Info("Verify error message on the screen.");*/
        }

        [Test]
        public void Register_User_009_LeaveCreatePwdAndVerify()
        {
            Global.MethodName = "Register_User_009_LeaveCreatePwdAndVerify";

            //Click SignUp link
            Thread.Sleep(2000);
            authenticationPage.ClickOnSignUpLink();
            log.Info("Click SignUp option given to the user.");
            Thread.Sleep(2000);

            //Enter First Name on the screen
            String validFirstName = readRegistration.GetValue("Credentials", "validFirstName");
            registrationPage.EnterFirstName(validFirstName);
            log.Info("Enter First Name on the screen.");
            Thread.Sleep(2000);

            //Enter Last Name on the screen
            String validLastName = readRegistration.GetValue("Credentials", "validLastName");
            registrationPage.EnterLastName(validLastName);
            log.Info("Enter Last Name on the screen.");
            Thread.Sleep(2000);

            //Enter Work Email on the screen
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(4));
            String validWorkEmail = readRegistration.GetValue("Credentials", "validWorkEmail");
            String workEmail = (Convert.ToString(builder)).ToLower() + validWorkEmail;
            registrationPage.EnterWorkEmail(workEmail);
            log.Info("Enter Work Email on the screen.");
            Thread.Sleep(2000);

            //Click SignUp button on the screen
            registrationPage.ClickSignUpBtn();
            log.Info("Click SignUp button on the screen.");
            Thread.Sleep(5000);

            //Enter Confirm Password field on the screen
            String confirmPwd = readRegistration.GetValue("Credentials", "confirmPwd");
            registrationPage.EnterCreatePwdFields("");
            registrationPage.EnterConfirmPwdFields(confirmPwd);
            log.Info("Enter Confirm Password field on the screen.");
            Thread.Sleep(2000);

            //Click Next Button on the screen
            registrationPage.ClickAllDoneBtn();
            log.Info("Click Next button on the screen.");
            Thread.Sleep(5000);

            //Verify Error Message on the screen
            registrationPage.CreatePwdEmpty();
            log.Info("Verify error message on the screen.");
        }

        [Test]
        public void Register_User_010_LeaveConfirmPwdAndVerify()
        {
            Global.MethodName = "Register_User_010_LeaveConfirmPwdAndVerify";

            //Click SignUp link
            Thread.Sleep(2000);
            authenticationPage.ClickOnSignUpLink();
            log.Info("Click SignUp option given to the user.");
            Thread.Sleep(2000);

            //Enter First Name on the screen
            String validFirstName = readRegistration.GetValue("Credentials", "validFirstName");
            registrationPage.EnterFirstName(validFirstName);
            log.Info("Enter First Name on the screen.");
            Thread.Sleep(2000);

            //Enter Last Name on the screen
            String validLastName = readRegistration.GetValue("Credentials", "validLastName");
            registrationPage.EnterLastName(validLastName);
            log.Info("Enter Last Name on the screen.");
            Thread.Sleep(2000);

            //Enter Work Email on the screen
            String validWorkEmail = readRegistration.GetValue("Credentials", "validWorkEmail");
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(4));
            
            validWorkEmail = (Convert.ToString(builder)).ToLower() + validWorkEmail;
            registrationPage.EnterWorkEmail(validWorkEmail);
            log.Info("Enter Work Email on the screen.");
            Thread.Sleep(2000);

            //Click SignUp button on the screen
            registrationPage.ClickSignUpBtn();
            log.Info("Click SignUp button on the screen.");
            Thread.Sleep(5000);

            //Enter Create a Password field on the screen
            String createPwd = readRegistration.GetValue("Credentials", "createPwd");
            registrationPage.EnterCreatePwdFields(createPwd);
            registrationPage.EnterConfirmPwdFields("");
            log.Info("Enter Create a Password field on the screen.");
            Thread.Sleep(2000);

            //Click Next Button on the screen
            registrationPage.ClickAllDoneBtn();
            log.Info("Click Next button on the screen.");
            Thread.Sleep(5000);

            //Verify Error Message on the screen
            registrationPage.ConfirmPwdEmpty();
            log.Info("Verify error message on the screen.");
        }

        [Test]
        public void Register_User_011_DifferentCreateAndConfirmPwd()
        {
            Global.MethodName = "Register_User_011_DifferentCreateAndConfirmPwd";

            //Click SignUp link
            Thread.Sleep(2000);
            authenticationPage.ClickOnSignUpLink();
            log.Info("Click SignUp option given to the user.");
            Thread.Sleep(2000);

            //Enter First Name on the screen
            String validFirstName = readRegistration.GetValue("Credentials", "validFirstName");
            registrationPage.EnterFirstName(validFirstName);
            log.Info("Enter First Name on the screen.");
            Thread.Sleep(2000);

            //Enter Last Name on the screen
            String validLastName = readRegistration.GetValue("Credentials", "validLastName");
            registrationPage.EnterLastName(validLastName);
            log.Info("Enter Last Name on the screen.");
            Thread.Sleep(2000);

            //Enter Work Email on the screen
            String validWorkEmail = readRegistration.GetValue("Credentials", "validWorkEmail");
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(4));
            validWorkEmail = (Convert.ToString(builder)).ToLower() + validWorkEmail;
            registrationPage.EnterWorkEmail(validWorkEmail);
            log.Info("Enter Work Email on the screen.");
            Thread.Sleep(2000);

            //Click SignUp button on the screen
            registrationPage.ClickSignUpBtn();
            log.Info("Click SignUp button on the screen.");
            Thread.Sleep(2000);

            //Enter Create a Password field on the screen
            registrationPage.EnterCreatePwdFields("Create123");
            log.Info("Enter Create a Password field on the screen.");
            Thread.Sleep(2000);

            //Enter Confirm Password field on the screen
            registrationPage.EnterConfirmPwdFields("Confirm123");
            log.Info("Enter Confirm Password field on the screen.");
            Thread.Sleep(2000);

            //Click Next Button on the screen
            registrationPage.ClickAllDoneBtn();
            log.Info("Click Next button on the screen.");
            Thread.Sleep(5000);

            //Verify Error Message on the screen
            registrationPage.DifferentPwdError();
            log.Info("Verify error message on the screen.");
            Thread.Sleep(2000);
        }

        [Test]
        public void Register_User_012_InvalidCreateAndConfirmPwd()
        {
            Global.MethodName = "Register_User_012_InvalidCreateAndConfirmPwd";

            //Click SignUp link
            Thread.Sleep(2000);
            authenticationPage.ClickOnSignUpLink();
            log.Info("Click SignUp option given to the user.");
            Thread.Sleep(2000);

            //Enter First Name on the screen
            String validFirstName = readRegistration.GetValue("Credentials", "validFirstName");
            registrationPage.EnterFirstName(validFirstName);
            log.Info("Enter First Name on the screen.");
            Thread.Sleep(2000);

            //Enter Last Name on the screen
            String validLastName = readRegistration.GetValue("Credentials", "validLastName");
            registrationPage.EnterLastName(validLastName);
            log.Info("Enter Last Name on the screen.");
            Thread.Sleep(2000);

            //Enter Work Email on the screen
            String validWorkEmail = readRegistration.GetValue("Credentials", "validWorkEmail");
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(4));
            validWorkEmail = (Convert.ToString(builder)).ToLower() + validWorkEmail;
            registrationPage.EnterWorkEmail(validWorkEmail);
            log.Info("Enter Work Email on the screen.");
            Thread.Sleep(2000);

            //Click SignUp button on the screen
            registrationPage.ClickSignUpBtn();
            log.Info("Click SignUp button on the screen.");
            Thread.Sleep(5000);

            //Enter Create a Password field on the screen
            String invalidPwd = readRegistration.GetValue("Credentials", "invalidPwd");
            registrationPage.EnterCreatePwdFields(invalidPwd);
            log.Info("Enter Create a Password field on the screen.");
            Thread.Sleep(2000);

            //Enter Confirm Password field on the screen
            registrationPage.EnterConfirmPwdFields(invalidPwd);
            log.Info("Enter Confirm Password field on the screen.");
            Thread.Sleep(2000);

            //Click Next Button on the screen
            registrationPage.ClickAllDoneBtn();
            log.Info("Click Next button on the screen.");
            Thread.Sleep(5000);

            //Verify Error Message on the screen
            registrationPage.ShortPwdError();
            log.Info("Verify error message on the screen.");
            Thread.Sleep(2000);
        }

        /*[Test]
        public void Register_User_013_InvalidWorkEmail()
        {
            Global.MethodName = "Register_User_013_InvalidWorkEmail";

            //Click SignUp link
            Thread.Sleep(2000);
            authenticationPage.ClickOnSignUpLink();
            log.Info("Click SignUp option given to the user.");
            Thread.Sleep(2000);

            //Enter First Name on the screen
            String validFirstName = readRegistration.GetValue("Credentials", "validFirstName");
            registrationPage.EnterFirstName(validFirstName);
            log.Info("Enter First Name on the screen.");
            Thread.Sleep(2000);

            //Enter Last Name on the screen
            String validLastName = readRegistration.GetValue("Credentials", "validLastName");
            registrationPage.EnterLastName(validLastName);
            log.Info("Enter Last Name on the screen.");
            Thread.Sleep(2000);

            //Enter Work Email on the screen
            String invalidWorkEmail = readRegistration.GetValue("Credentials", "invalidWorkEmail");
            registrationPage.EnterWorkEmail(invalidWorkEmail);
            log.Info("Enter Work Email on the screen.");
            Thread.Sleep(2000);

            //Click SignUp button on the screen
            registrationPage.ClickSignUpBtn();
            log.Info("Click SignUp button on the screen.");
            Thread.Sleep(5000);

            //Verify Invalid Email Error Message on the screen
            registrationPage.InvalidEmailErrorMessage();
            log.Info("Verify invalid email error message on the screen.");
            Thread.Sleep(2000);
        }*/

        /*Login button has been removed from Registration page
        [Test]
        public void Register_User_014_ClickRegistrationLogin()
        {
            Global.MethodName = "Register_User_014_ClickRegistrationLogin";

            //Click the SignUp link
            Thread.Sleep(2000);
            authenticationPage.ClickOnSignUpLink();
            log.Info("Click SignUp link.");
            Thread.Sleep(2000);

            //Click the Login Button field at Registration page
            authenticationPage.ClickRegistrationLoginBtn();
            log.Info("Click Login Button on Registration page.");
            Thread.Sleep(5000);

            //Verify the login page is displayed
            authenticationPage.VerifyLoginPage();
            log.Info("Verify Login Url Page");
            Thread.Sleep(2000);
        }*/
    }
}
