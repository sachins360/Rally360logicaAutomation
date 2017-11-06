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
using log4net;
using System.Reflection;

namespace RallyTeam.TestScripts
{
    [TestFixture]
    [Category("Onboarding")]
    public class OnboardingTest : BaseTestWithoutLogin
    {
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        static ReadData readOnboarding = new ReadData("Onboarding");
        String workEmail;
        StringBuilder builder;

        //Signing up a new user
        public void SignUpNewUser()
        {
            commonPage.NavigateToExternalStorm(_externalStormURL);
            Thread.Sleep(2000);

            //Click SignUp link
            Thread.Sleep(2000);
            authenticationPage.ClickOnSignUpLink();
            log.Info("Click SignUp option given to the user.");
            Thread.Sleep(2000);

            builder = new StringBuilder();
            builder.Append(RandomString(6));                        

            //Enter First Name on the screen
            registrationPage.EnterFirstName(builder.ToString());
            log.Info("Enter First Name on the screen.");
            Thread.Sleep(2000);

            //Enter Last Name on the screen
            registrationPage.EnterLastName(builder.ToString());
            log.Info("Enter Last Name on the screen.");
            Thread.Sleep(2000);

            //Enter Work Email on the screen
            workEmail = builder.ToString().ToLower() + "@harakirimail.com";
            registrationPage.EnterWorkEmail(workEmail);
            log.Info("Enter Work Email on the screen.");
            Thread.Sleep(4000);

            //Click SignUp button on the screen
            registrationPage.ClickSignUpBtn();
            log.Info("Click SignUp button on the screen.");
            Thread.Sleep(5000);

            //Enter Create a Password field on the screen
            registrationPage.EnterCreatePwdFields("Logica360");
            log.Info("Enter Create a Password field on the screen.");
            Thread.Sleep(2000);

            //Enter Confirm Password field on the screen
            registrationPage.EnterConfirmPwdFields("Logica360");
            log.Info("Enter Confirm Password field on the screen.");
            Thread.Sleep(2000);

            //Click Next Button on the screen
            registrationPage.ClickAllDoneBtn();
            log.Info("Click Next button on the screen.");
            Thread.Sleep(10000);
        }

        public void GetConfirmationCode()
        {
            //Navigate to the user inbox
            commonPage.NavigateToUrl("https://harakirimail.com/");
            log.Info("Navigate to the mailinator site.");
            Thread.Sleep(5000);

            //Enter Harakirimail Email address
            onboardingPage.EnterHarakirimailEmail(workEmail);
            log.Info("Enter email address.");
            Thread.Sleep(2000);

            //Press Enter key
            commonPage.PressEnterKey();
            Thread.Sleep(5000);

            //Click the Email Subject
            onboardingPage.ClickEmailSubject();
            log.Info("Click the Email Subject.");
            Thread.Sleep(5000);

            //Get the Confirmation Code
            commonPage.ScrollDown();
            Thread.Sleep(2000);
            String confirmationCode = onboardingPage.GetConfirmationCode();
            Console.WriteLine("Code: " + confirmationCode);
            char[] codeArray = confirmationCode.ToCharArray();
            log.Info("Get Confirmation Code.");
            Thread.Sleep(2000);

            commonPage.NavigateToUrl("https://360logicaext.rallyteam.com/#/wizard/verify");
            Thread.Sleep(7000);

            //Enter Confirmation Code
            Console.WriteLine(codeArray[0].ToString());
            onboardingPage.test();
            Thread.Sleep(2000);
            onboardingPage.EnterCodeOne(codeArray[0].ToString());
            Thread.Sleep(1000);
            onboardingPage.EnterCodeTwo(codeArray[1].ToString());
            Thread.Sleep(1000);
            onboardingPage.EnterCodeThree(codeArray[2].ToString());
            Thread.Sleep(1000);
            onboardingPage.EnterCodeFour(codeArray[4].ToString());
            Thread.Sleep(1000);
            onboardingPage.EnterCodeFive(codeArray[5].ToString());
            Thread.Sleep(1000);
            onboardingPage.EnterCodeSix(codeArray[6].ToString());
            Thread.Sleep(2000);
            onboardingPage.testtwo();
            Thread.Sleep(2000);

        }

        [Test]
        public void Onboarding_001_SignUpNewProfile()
        {
            Global.MethodName = "Onboarding_001_SignUpNewProfile";
            SignUpNewUser();
            Thread.Sleep(2000);

            //Verify the Welcome RallyTeam message
            onboardingPage.VerifyWelcomeRallyTeamMsg();
            log.Info("Verify the Welcome RallyTeam message.");
            Thread.Sleep(1000);

            //Verify the Get Started button
            onboardingPage.VerifyGetStartedBtn();
            log.Info("Verify Get Started button.");

            //Click Get Started button
            onboardingPage.ClickGetStartedBtn();
            log.Info("Click Get Staerted button.");
            Thread.Sleep(5000);

            //Click Linkedin Next button
            onboardingPage.ClickNextLinkedIn();
            log.Info("Click Next button on LinkedIn Page.");
            Thread.Sleep(5000);

            //Select Expertise
            onboardingPage.SelectExpertiseDropDown("Information Technology");
            log.Info("Select Expertise.");
            Thread.Sleep(2000);

            //Click Expertise Continue button
            onboardingPage.ClickExpertiseContinueBtn();
            log.Info("Click Expertise Continue button.");
            Thread.Sleep(5000);

            //Enter Skills
            onboardingPage.EnterSkills("Android");
            Thread.Sleep(2000);
            commonPage.PressEnterKey();
            Thread.Sleep(2000);
            onboardingPage.EnterSkills("Computer science");
            Thread.Sleep(2000);
            commonPage.PressEnterKey();
            Thread.Sleep(2000);

            //Click View My Profile button
            onboardingPage.ClickViewMyProfileBtn();
            log.Info("Click View My Profile button.");
            Thread.Sleep(5000);

            //Assert Skills entered are populated in the Profile
            onboardingPage.AssertSkillOne("Android");
            log.Info("Assert Skill One.");
            Thread.Sleep(1000);
            onboardingPage.AssertSkillTwo("Computer science");
            log.Info("Assert Skill Two.");
            Thread.Sleep(1000);

            //Click Done button on Profile
            commonPage.ScrollUp();
            Thread.Sleep(2000);
            onboardingPage.ClickDoneBtn();
            log.Info("Click Done button.");
            Thread.Sleep(5000);

            GetConfirmationCode();
            Thread.Sleep(5000);

            //Click Lets Rally button
            onboardingPage.ClickLetsRallyBtn();
            log.Info("Click Lets Rally button.");
            Thread.Sleep(5000);
        }

        /*[Test]
        public void Onboarding_002_VerifyEmailReceived()
        {
            Global.MethodName = "Onboarding_002_VerifyEmailReceived";
            SignUpNewUser();

            //Navigate to the user inbox
            commonPage.NavigateToUrl("https://harakirimail.com/");
            log.Info("Navigate to the mailinator site.");
            Thread.Sleep(5000);

            //Enter Mailinator Email address
            onboardingPage.EnterMailinatorEmail(workEmail);
            log.Info("Enter email address.");
            Thread.Sleep(2000);

            //Click on Go button
            onboardingPage.ClickGoBtn();
            log.Info("Click Go button.");
            Thread.Sleep(5000);

            //Refresh page
            commonPage.RefreshPage();
            Thread.Sleep(3000);

            //Verify the Email Sender
            onboardingPage.VerifyEmailSender();
            log.Info("Verify the Email Sender.");
            Thread.Sleep(2000);

            //Verify the Email Subject
            onboardingPage.VerifyEmailSubject();
            log.Info("Verify the Email Subject.");
            Thread.Sleep(2000);

            //Click the Email Sender
            onboardingPage.ClickEmailSubject();
            log.Info("Click the Email Sender.");
            Thread.Sleep(5000);

            //Switch to Iframe
            onboardingPage.SwitchIframe();
            Thread.Sleep(2000);

            //Verify the button Verify Your Email
            onboardingPage.VerifyYourEmailBtn();
            log.Info("Verify the button: Verify your Email.");
            Thread.Sleep(3000);

            //Get the Email Link and navigate
            String emailLink = onboardingPage.GetEmailLink();
            Console.WriteLine("EMAIL: " + emailLink);
            commonPage.NavigateToUrl(emailLink);
            log.Info("Navigate to the Email Link.");
            Thread.Sleep(5000);

            //Login page should be displayed
            authenticationPage.VerifyLoginPage();
            log.Info("Verify Login Url Page");            
        }*/

        [Test]
        public void Onboarding_003_LoginAndVerifyWelcomePage()
        {
            Global.MethodName = "Onboarding_003_LoginAndVerifyWelcomePage";
            SignUpNewUser();
            //MoveToWelcomePage();

            /*//Verify the Welcome User Message
            onboardingPage.VerifyWelcomeUserMsg(builder.ToString());
            log.Info("Verify the Welcome User Message.");
            Thread.Sleep(1000);

            //Verify the Welcome RallyTeam Description message
            onboardingPage.VerifyWelcomeRallyTeamDescriptionMsg();
            log.Info("Verify the Welcome RallyTeam Description message.");
            Thread.Sleep(1000);

            //Verify the Get Started button
            onboardingPage.VerifyGetStartedBtn();
            log.Info("Verify Get Started button.");*/
        }

        [Test]
        public void Onboarding_004_VerifyLinkedInPage()
        {
            Global.MethodName = "Onboarding_004_VerifyLinkedInPage";
            SignUpNewUser();
            //MoveToWelcomePage();

            //Click Get Started Button
            onboardingPage.ClickGetStartedBtn();
            log.Info("Click Get Started button.");
            Thread.Sleep(5000);

            //Verify the LinkeDin Confirmation message
            onboardingPage.VerifyLinkedInConfirmationMsg();
            log.Info("Verify the LinkeDin Confirmation message.");
            Thread.Sleep(1000);

            //Verify the Connect with LinkedIn button
            onboardingPage.VerifyConnectWithLinkedInbtn();
            log.Info("Verify the Connect with LinkedIn button.");
            Thread.Sleep(1000);

            //Verify the Skip LinkedIn Option
            onboardingPage.VerifySkipLinkedIn();
            log.Info("Verify Skip LinkedIn Option.");
        }

        [Test]
        public void Onboarding_005_VerifyUploadResumePage()
        {
            Global.MethodName = "Onboarding_005_VerifyUploadResumePage";
            SignUpNewUser();
            //MoveToWelcomePage();

            //Click Get Started Button
            onboardingPage.ClickGetStartedBtn();
            log.Info("Click Get Started button.");
            Thread.Sleep(5000);

            //Skip the LinkedIn Step
            onboardingPage.ClickSkipLinkedIn();
            log.Info("Click Skip LinkedIn option.");
            Thread.Sleep(5000);

            //Verify the Upload Your Resume message
            onboardingPage.VerifyUploadResumeMsg();
            log.Info("Verify the Upload Your Resume message.");
            Thread.Sleep(1000);

            //Verify the Upload Your Resume button
            onboardingPage.VerifyUploadYourResumeBtn();
            log.Info("Verify the Upload Your Resume button.");
            Thread.Sleep(1000);

            //Verify the Skip Upload Resume Option
            onboardingPage.VerifySkipUploadResume();
            log.Info("Verify Skip Upload Resume Option.");
        }

        [Test]
        public void Onboarding_006_VerifyWorkPage()
        {
            Global.MethodName = "Onboarding_006_VerifyWorkPage";
            SignUpNewUser();
            //MoveToWelcomePage();

            //Click Get Started Button
            onboardingPage.ClickGetStartedBtn();
            log.Info("Click Get Started button.");
            Thread.Sleep(5000);

            //Skip the LinkedIn Step
            onboardingPage.ClickSkipLinkedIn();
            log.Info("Click Skip LinkedIn option.");
            Thread.Sleep(5000);

            //Skip the Upload Resume Step
            onboardingPage.ClickSkipUploadResume();
            log.Info("Click Skip Upload Resume option.");
            Thread.Sleep(5000);

            
        }

        [Test]
        public void Onboarding_007_SelectWorkAndVerifySkillsPage()
        {
            Global.MethodName = "Onboarding_007_SelectWorkAndVerifySkillsPage";
            SignUpNewUser();
            //MoveToWelcomePage();
            
            //Click Get Started Button
            onboardingPage.ClickGetStartedBtn();
            log.Info("Click Get Started button.");
            Thread.Sleep(5000);

            //Skip the LinkedIn Step
            onboardingPage.ClickSkipLinkedIn();
            log.Info("Click Skip LinkedIn option.");
            Thread.Sleep(5000);

            //Skip the Upload Resume Step
            onboardingPage.ClickSkipUploadResume();
            log.Info("Click Skip Upload Resume option.");
            Thread.Sleep(5000);

            

            
        }

        [Test]
        public void Onboarding_008_VerifyInterestsPage()
        {
            Global.MethodName = "Onboarding_008_VerifyInterestsPage";
            SignUpNewUser();
            //MoveToWelcomePage();

            //Click Get Started Button
            onboardingPage.ClickGetStartedBtn();
            log.Info("Click Get Started button.");
            Thread.Sleep(5000);

            //Skip the LinkedIn Step
            onboardingPage.ClickSkipLinkedIn();
            log.Info("Click Skip LinkedIn option.");
            Thread.Sleep(5000);

            //Skip the Upload Resume Step
            onboardingPage.ClickSkipUploadResume();
            log.Info("Click Skip Upload Resume option.");
            Thread.Sleep(5000);

            
            
        }

        [Test]
        public void Onboarding_009_ClickLetsGetMatchedAndVerify()
        {
            Global.MethodName = "Onboarding_009_ClickLetsGetMatchedAndVerify";
            SignUpNewUser();
            //MoveToWelcomePage();

            //Click Get Started Button
            onboardingPage.ClickGetStartedBtn();
            log.Info("Click Get Started button.");
            Thread.Sleep(5000);

            //Skip the LinkedIn Step
            onboardingPage.ClickSkipLinkedIn();
            log.Info("Click Skip LinkedIn option.");
            Thread.Sleep(5000);

            //Skip the Upload Resume Step
            onboardingPage.ClickSkipUploadResume();
            log.Info("Click Skip Upload Resume option.");
            Thread.Sleep(5000);

            
            
        }

        [Test]
        public void Onboarding_010_UploadResumeAndVerifySkills()
        {
            Global.MethodName = "Onboarding_010_UploadResumeAndVerifySkills";
            SignUpNewUser();
            //MoveToWelcomePage();

            //Click Get Started Button
            onboardingPage.ClickGetStartedBtn();
            log.Info("Click Get Started button.");
            Thread.Sleep(5000);

            //Skip the LinkedIn Step
            onboardingPage.ClickSkipLinkedIn();
            log.Info("Click Skip LinkedIn option.");
            Thread.Sleep(5000);

            //Click the Upload Your Resume button
            onboardingPage.ClickUploadYourResumeBtn();
            log.Info("Click the Upload Your Resume button.");
            Thread.Sleep(1000);
            String startupPath = System.IO.Directory.GetCurrentDirectory() + "\\TestData";
            startupPath = startupPath + "\\AuzebManzoor.pdf";
            Thread.Sleep(2000);
            SendKeys.SendWait(@startupPath);
            Thread.Sleep(2000);
            SendKeys.SendWait(@"{Enter}");
            Thread.Sleep(5000);  
        }









    }
}
