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
    [Category("AddUsers")]
    public class AddUsersTest : BaseTestES
    {
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        static ReadData readInviteUser = new ReadData("AddUser");
        StringBuilder builder;
        String email;

        public void GoToAddUser()
        {
            builder = new StringBuilder();
            builder.Append(RandomString(6));
            
            //Click User Profile Icon
            userProfilePage.ClickUserProfileIcon();
            log.Info("Click the User Profile Icon.");
            Thread.Sleep(2000);

            //Select the User Profile Option 'Admin'
            userProfilePage.ClickUserProfileOptions("Admin");
            log.Info("Click User Profile option 'Admin'.");
            Thread.Sleep(5000);
                      
            //Click Add Users button
            addUsersPage.ClickAddUsersBtn();
            log.Info("Click Add Users button.");
            Thread.Sleep(5000);
        }

        public void MoveToWelcomePage()
        {
            //Navigate to the user inbox
            commonPage.NavigateToUrl("https://www.mailinator.com/");
            log.Info("Navigate to the mailinator site.");
            Thread.Sleep(5000);

            //Enter Mailinator Email address
            addUsersPage.EnterHarakirimailEmail(email);
            log.Info("Enter email address.");
            Thread.Sleep(2000);

            //Click on Go button
            addUsersPage.ClickGoBtn();
            log.Info("Click Go button.");
            Thread.Sleep(5000);

            //Click the Email Sender
            addUsersPage.ClickEmailSender();
            log.Info("Click the Email Sender.");
            Thread.Sleep(5000);

            //Switch to Iframe
            addUsersPage.SwitchIframe();
            Thread.Sleep(2000);

            //Get the Email Link and navigate
            String emailLink = addUsersPage.GetEmailLink();
            Console.WriteLine("EMAIL: " + emailLink);
            commonPage.NavigateToUrl(emailLink);
            log.Info("Navigate to the Email Link.");
            Thread.Sleep(5000);

            //Enter First Name on the screen
            registrationPage.EnterFirstName(builder.ToString());
            log.Info("Enter First Name on the screen.");
            Thread.Sleep(2000);

            //Enter Last Name on the screen
            registrationPage.EnterLastName(builder.ToString());
            log.Info("Enter Last Name on the screen.");
            Thread.Sleep(2000);

            //Enter valid password
            authenticationPage.SetPassword("Logica360");
            log.Info("Enter valid password.");
            Thread.Sleep(2000);

            //Click SignUp button on the screen
            registrationPage.ClickSignUpBtn();
            log.Info("Click SignUp button on the screen.");
            Thread.Sleep(5000);
        }

        [Test]
        public void AddUser_001_VerifyInviteUserWindow()
        {
            Global.MethodName = "AddUser_001_VerifyInviteUserWindow";
            Thread.Sleep(5000);
            GoToAddUser();

            //Verify Close Icon
            Thread.Sleep(5000);
            addUsersPage.VerifyCloseIcon();
            log.Info("Verify Close Icon.");
            Thread.Sleep(1000);

            /*//Verify Let's build your marketplace! message
            addUsersPage.VerifyLetsBuildYourMarketplaceMsg();
            log.Info("Verify Let's build your marketplace! message.");
            Thread.Sleep(1000);  */                        

            //Verify Maybe Later Option
            addUsersPage.VerifyCloseIcon();
            log.Info("Verify Maybe Later Option.");
            Thread.Sleep(1000);
                        
            //Verify CSV button
            addUsersPage.VerifyCsvBtn();
            log.Info("Verify CSV button.");
            Thread.Sleep(1000);

            //Verify Email button
            addUsersPage.VerifyEmailBtn();
            log.Info("Verify Email button.");
            Thread.Sleep(1000);

            //Verify Create Profile button
            addUsersPage.VerifyCreateProfileBtn();
            log.Info("Verify Create Profile button.");
        }

        [Test]
        public void AddUser_002_SendAndVerifyInviteEmail()
        {
            Global.MethodName = "AddUser_002_SendAndVerifyInviteEmail";
            Thread.Sleep(5000);
            GoToAddUser();
                        
            //Click Email button
            addUsersPage.ClickEmailBtn();
            log.Info("Click Email button.");
            Thread.Sleep(5000);

            //Enter Email Address
            email = builder + "@harakirimail.com";
            addUsersPage.EnterEmailAddresses(email);
            log.Info("Enter Email Address.");
            commonPage.PressTabKey();
            Thread.Sleep(2000);

            //Click Add Users button
            addUsersPage.ClickEmailAddUsersBtn();
            log.Info("Click Add Users button.");
            Thread.Sleep(5000);

            //Click Finish button
            addUsersPage.ClickFinishBtn();
            log.Info("Click Finish button.");
            Thread.Sleep(5000);

            //Navigate to the user inbox
            commonPage.NavigateToUrl("https://www.harakirimail.com/");
            log.Info("Navigate to the mailinator site.");
            Thread.Sleep(7000);

            //Enter Harakirimail Email address
            addUsersPage.EnterHarakirimailEmail(email);
            log.Info("Enter email address.");
            Thread.Sleep(2000);

            //Press Enter key
            commonPage.PressEnterKey();
            Thread.Sleep(5000);                       

            //Verify the Email Sender
            addUsersPage.VerifyEmailSender();
            log.Info("Verify the Email Sender.");
            Thread.Sleep(2000);

            //Verify the Email Subject
            addUsersPage.VerifyEmailSubject();
            log.Info("Verify the Email Subject.");
            Thread.Sleep(2000);

            //Click the Email Subject
            addUsersPage.ClickEmailSubject();
            log.Info("Click the Email Subject.");
            Thread.Sleep(5000);
                        
            //Verify the Email Get Started Button
            addUsersPage.VerifyEmailGetStartedBtn();
            log.Info("Verify the Email Get Started Button.");
        }

        [Test]
        public void AddUser_003_OnboardWithInvitedUser()
        {
            Global.MethodName = "AddUser_003_OnboardWithInvitedUser";
            Thread.Sleep(5000);
            GoToAddUser();

            //Click Email button
            addUsersPage.ClickEmailBtn();
            log.Info("Click Email button.");
            Thread.Sleep(5000);

            //Enter Email Address
            email = builder + "@harakirimail.com";
            addUsersPage.EnterEmailAddresses(email);
            log.Info("Enter Email Address.");
            commonPage.PressTabKey();
            Thread.Sleep(2000);

            //Click Add Users button
            addUsersPage.ClickEmailAddUsersBtn();
            log.Info("Click Add Users button.");
            Thread.Sleep(5000);

            //Click Finish button
            addUsersPage.ClickFinishBtn();
            log.Info("Click Finish button.");
            Thread.Sleep(5000);

            //Navigate to the user inbox
            commonPage.NavigateToUrl("https://www.harakirimail.com/");
            log.Info("Navigate to the mailinator site.");
            Thread.Sleep(7000);

            //Enter Harakirimail Email address
            addUsersPage.EnterHarakirimailEmail(email);
            log.Info("Enter email address.");
            Thread.Sleep(2000);

            //Press Enter key
            commonPage.PressEnterKey();
            Thread.Sleep(5000);               

            //Click the Email Subject
            addUsersPage.ClickEmailSubject();
            log.Info("Click the Email Subject.");
            Thread.Sleep(5000);

            //Click Get Started button
            addUsersPage.ClickEmailGetStartedBtn();
            log.Info("Click the Get Started Button.");
            Thread.Sleep(5000);

            //Enter First Name on the screen
            registrationPage.EnterFirstName(builder.ToString());
            log.Info("Enter First Name on the screen.");
            Thread.Sleep(2000);

            //Enter Last Name on the screen
            registrationPage.EnterLastName(builder.ToString());
            log.Info("Enter Last Name on the screen.");
            Thread.Sleep(2000);

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

            //Click All Done Button on the screen
            registrationPage.ClickAllDoneBtn();
            log.Info("Click All Done button on the screen.");
            Thread.Sleep(7000);

            //Verify the Get Started button
            addUsersPage.VerifyGetStartedBtn();
            log.Info("Verify Get Started button.");

            //Click Get Started button
            addUsersPage.ClickGetStartedBtn();
            log.Info("Click Get Staerted button.");
            Thread.Sleep(5000);

            //Click Linkedin Next button
            addUsersPage.ClickNextLinkedIn();
            log.Info("Click Next button on LinkedIn Page.");
            Thread.Sleep(5000);

            //Select Expertise
            addUsersPage.SelectExpertiseDropDown("Information Technology");
            log.Info("Select Expertise.");
            Thread.Sleep(2000);

            //Click Expertise Continue button
            addUsersPage.ClickExpertiseContinueBtn();
            log.Info("Click Expertise Continue button.");
            Thread.Sleep(5000);

            //Enter Skills
            addUsersPage.EnterSkills("Android");
            Thread.Sleep(2000);
            commonPage.PressEnterKey();
            Thread.Sleep(2000);
            addUsersPage.EnterSkills("Computer science");
            Thread.Sleep(2000);
            commonPage.PressEnterKey();
            Thread.Sleep(2000);

            //Click View My Profile button
            addUsersPage.ClickViewMyProfileBtn();
            log.Info("Click View My Profile button.");
            Thread.Sleep(5000);

            //Assert Skills entered are populated in the Profile
            addUsersPage.AssertSkillOne("Android");
            log.Info("Assert Skill One.");
            Thread.Sleep(1000);
            addUsersPage.AssertSkillTwo("Computer science");
            log.Info("Assert Skill Two.");
            Thread.Sleep(1000);

            //Click Done button on Profile
            commonPage.ScrollUp();
            Thread.Sleep(2000);
            addUsersPage.ClickDoneBtn();
            log.Info("Click Done button.");
            Thread.Sleep(5000);
        }

        [Test]
        public void AddUser_004_SendAndVerifyInviteEmailMultipleUsers()
        {
            Global.MethodName = "AddUser_004_SendAndVerifyInviteEmailMultipleUsers";
            Thread.Sleep(5000);
            GoToAddUser();

            //Click Email button
            addUsersPage.ClickEmailBtn();
            log.Info("Click Email button.");
            Thread.Sleep(5000);

            //Enter Email Address
            email = builder + "@harakirimail.com";
            addUsersPage.EnterEmailAddresses(email);
            log.Info("Enter Email Address.");
            commonPage.PressTabKey();
            builder.Append(RandomString(6));
            email = builder + "@harakirimail.com";
            addUsersPage.EnterEmailAddresses(email);
            log.Info("Enter Second Email Address.");
            commonPage.PressTabKey();
            Thread.Sleep(2000);

            //Click Add Users button
            addUsersPage.ClickEmailAddUsersBtn();
            log.Info("Click Add Users button.");
            Thread.Sleep(5000);

            //Click Finish button
            addUsersPage.ClickFinishBtn();
            log.Info("Click Finish button.");
            Thread.Sleep(5000);

            //Navigate to the user inbox
            commonPage.NavigateToUrl("https://www.harakirimail.com/");
            log.Info("Navigate to the mailinator site.");
            Thread.Sleep(7000);

            //Enter Harakirimail Email address
            addUsersPage.EnterHarakirimailEmail(email);
            log.Info("Enter email address.");
            Thread.Sleep(2000);

            //Press Enter key
            commonPage.PressEnterKey();
            Thread.Sleep(5000);

            //Verify the Email Sender
            addUsersPage.VerifyEmailSender();
            log.Info("Verify the Email Sender.");
            Thread.Sleep(2000);

            //Verify the Email Subject
            addUsersPage.VerifyEmailSubject();
            log.Info("Verify the Email Subject.");
            Thread.Sleep(2000);

            //Click the Email Subject
            addUsersPage.ClickEmailSubject();
            log.Info("Click the Email Subject.");
            Thread.Sleep(5000);

            //Verify the Email Get Started Button
            addUsersPage.VerifyEmailGetStartedBtn();
            log.Info("Verify the Email Get Started Button.");
            Thread.Sleep(2000);

            //Navigate to the user inbox
            commonPage.NavigateToUrl("https://www.harakirimail.com/");
            log.Info("Navigate to the mailinator site.");
            Thread.Sleep(7000);

            //Enter Harakirimail Email address
            addUsersPage.EnterHarakirimailEmail(email);
            log.Info("Enter email address.");
            Thread.Sleep(2000);

            //Press Enter key
            commonPage.PressEnterKey();
            Thread.Sleep(5000);

            //Verify the Email Sender
            addUsersPage.VerifyEmailSender();
            log.Info("Verify the Email Sender.");
            Thread.Sleep(2000);

            //Verify the Email Subject
            addUsersPage.VerifyEmailSubject();
            log.Info("Verify the Email Subject.");
            Thread.Sleep(2000);

            //Click the Email Subject
            addUsersPage.ClickEmailSubject();
            log.Info("Click the Email Subject.");
            Thread.Sleep(5000);

            //Verify the Email Get Started Button
            addUsersPage.VerifyEmailGetStartedBtn();
            log.Info("Verify the Email Get Started Button.");
        }

        [Test]
        public void AddUser_005_UploadResume()
        {
            Global.MethodName = "AddUser_005_UploadResume";
            Thread.Sleep(5000);
            GoToAddUser();

            //Click Email button
            addUsersPage.ClickEmailBtn();
            log.Info("Click Email button.");
            Thread.Sleep(5000);

            //Enter Email Address
            email = builder + "@harakirimail.com";
            addUsersPage.EnterEmailAddresses(email);
            log.Info("Enter Email Address.");
            commonPage.PressTabKey();
            Thread.Sleep(2000);

            //Click Add Users button
            addUsersPage.ClickEmailAddUsersBtn();
            log.Info("Click Add Users button.");
            Thread.Sleep(5000);

            //Click Finish button
            addUsersPage.ClickFinishBtn();
            log.Info("Click Finish button.");
            Thread.Sleep(5000);

            //Navigate to the user inbox
            commonPage.NavigateToUrl("https://www.harakirimail.com/");
            log.Info("Navigate to the mailinator site.");
            Thread.Sleep(7000);

            //Enter Harakirimail Email address
            addUsersPage.EnterHarakirimailEmail(email);
            log.Info("Enter email address.");
            Thread.Sleep(2000);

            //Press Enter key
            commonPage.PressEnterKey();
            Thread.Sleep(5000);            

            //Click the Email Subject
            addUsersPage.ClickEmailSubject();
            log.Info("Click the Email Subject.");
            Thread.Sleep(5000);

            //Click Email Get Started button
            addUsersPage.ClickEmailGetStartedBtn();
            log.Info("Click the Email Get Started Button.");

            //Enter First Name on the screen
            registrationPage.EnterFirstName(builder.ToString());
            log.Info("Enter First Name on the screen.");
            Thread.Sleep(2000);

            //Enter Last Name on the screen
            registrationPage.EnterLastName(builder.ToString());
            log.Info("Enter Last Name on the screen.");
            Thread.Sleep(2000);

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

            //Click All Done Button on the screen
            registrationPage.ClickAllDoneBtn();
            log.Info("Click All Done button on the screen.");
            Thread.Sleep(7000);           

            //Click Get Started button
            addUsersPage.ClickGetStartedBtn();
            log.Info("Click Get Staerted button.");
            Thread.Sleep(5000);

            //Click Upload Resume button
            addUsersPage.ClickUploadYourResumeBtn();
            Thread.Sleep(5000);
            String startupPath = Environment.CurrentDirectory; ;
            startupPath = startupPath + "\\AuzebManzoor.pdf";
            Console.WriteLine("Start up path: " + startupPath);
            SendKeys.SendWait(@startupPath);
            Thread.Sleep(2000);
            SendKeys.SendWait(@"{Enter}");
            Thread.Sleep(7000);

            //Verify the Confirm Tickmark
            addUsersPage.VerifyConfirmTickmark();
            log.Info("Verify the Confirm Tickmark.");
        }

        [Test]
        public void AddUser_006_UploadLinkedIn()
        {
            Global.MethodName = "AddUser_006_UploadLinkedIn";
            Thread.Sleep(5000);
            GoToAddUser();

            //Click Email button
            addUsersPage.ClickEmailBtn();
            log.Info("Click Email button.");
            Thread.Sleep(5000);

            //Enter Email Address
            email = builder + "@harakirimail.com";
            addUsersPage.EnterEmailAddresses(email);
            log.Info("Enter Email Address.");
            commonPage.PressTabKey();
            Thread.Sleep(2000);

            //Click Add Users button
            addUsersPage.ClickEmailAddUsersBtn();
            log.Info("Click Add Users button.");
            Thread.Sleep(5000);

            //Click Finish button
            addUsersPage.ClickFinishBtn();
            log.Info("Click Finish button.");
            Thread.Sleep(5000);

            //Navigate to the user inbox
            commonPage.NavigateToUrl("https://www.harakirimail.com/");
            log.Info("Navigate to the mailinator site.");
            Thread.Sleep(7000);

            //Enter Harakirimail Email address
            addUsersPage.EnterHarakirimailEmail(email);
            log.Info("Enter email address.");
            Thread.Sleep(2000);

            //Press Enter key
            commonPage.PressEnterKey();
            Thread.Sleep(5000);

            //Click the Email Subject
            addUsersPage.ClickEmailSubject();
            log.Info("Click the Email Subject.");
            Thread.Sleep(5000);

            //Click Email Get Started button
            addUsersPage.ClickEmailGetStartedBtn();
            log.Info("Click the Email Get Started Button.");

            //Enter First Name on the screen
            registrationPage.EnterFirstName(builder.ToString());
            log.Info("Enter First Name on the screen.");
            Thread.Sleep(2000);

            //Enter Last Name on the screen
            registrationPage.EnterLastName(builder.ToString());
            log.Info("Enter Last Name on the screen.");
            Thread.Sleep(2000);

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

            //Click All Done Button on the screen
            registrationPage.ClickAllDoneBtn();
            log.Info("Click All Done button on the screen.");
            Thread.Sleep(7000);

            //Click Get Started button
            addUsersPage.ClickGetStartedBtn();
            log.Info("Click Get Staerted button.");
            Thread.Sleep(5000);

            //Click LinkedIn button Resume button
            addUsersPage.ClickLinkedInBtn();
            log.Info("Click LinkedIn button.");
            Thread.Sleep(7000);

            addUsersPage.SwitchLinkedInWindow();
            Thread.Sleep(3000);

            //Enter the LinkedIn User Id
            addUsersPage.EnterLinkedInUserId("ammar.pccs@yahoo.com");
            log.Info("Enter LinkedIn User Id.");
            Thread.Sleep(2000);

            //Enter the LinkedIn Password
            addUsersPage.EnterLinkedInPwd("Canada@123");
            log.Info("Enter LinkedIn Password.");
            Thread.Sleep(2000);

            //Click the LinkedIn SignIn button
            addUsersPage.EnterLinkedInSignInBtn();
            log.Info("Enter LinkedIn SignIn button.");
            Thread.Sleep(10000);

            addUsersPage.SwitchOriginalWindow();
            Thread.Sleep(3000);

            //Verify the LinkedIn button disabled
            addUsersPage.VerifyLinkedInDisabled();
            log.Info("Verify the LinkedIn button disabled.");
        }

        [Test]
        public void AddUser_007_CreateProfile()
        {
            Global.MethodName = "AddUser_007_CreateProfile";
            Thread.Sleep(5000);
            GoToAddUser();

            //Click Create a Profile button
            addUsersPage.ClickCreateProfileBtn();
            log.Info("Click Create a Profile button.");
            Thread.Sleep(5000);

            //Enter First Name
            addUsersPage.EnterFirstName(builder.ToString());
            log.Info("Enter First Name.");
            Thread.Sleep(2000);

            //Enter Last Name
            addUsersPage.EnterLastName(builder.ToString());
            log.Info("Enter Last Name.");
            Thread.Sleep(2000);

            //Enter Email
            email = builder + "@harakirimail.com";
            addUsersPage.EnterEmail(email);
            log.Info("Enter Email.");
            Thread.Sleep(2000);

            //Enter Title
            addUsersPage.EnterTitle("Automation Script");
            log.Info("Enter Title.");
            Thread.Sleep(2000);

            //Enter About Me
            addUsersPage.EnterAboutMe("I am an automated script");
            log.Info("Enter About Me.");
            Thread.Sleep(2000);

            //Enter My Top Skills
            addUsersPage.EnterMyTopSkills("Selenium WebDriver");
            log.Info("Enter My Top Skills.");
            Thread.Sleep(2000);
            commonPage.PressEnterKey();
            Thread.Sleep(2000);

            //Enter Other Skills
            addUsersPage.EnterOtherSkills("C#");
            log.Info("Enter Other Skills.");
            Thread.Sleep(2000);
            commonPage.PressEnterKey();
            Thread.Sleep(2000);

            /*//Enter Industry / Domain Expertise
            addUsersPage.EnterIndustryDomainExpertise("Agricultural Chemicals");
            log.Info("Enter Industry / Domain Expertise.");
            Thread.Sleep(2000);
            commonPage.PressEnterKey();
            Thread.Sleep(2000);*/

            //Enter Languages
            addUsersPage.EnterLanguages("English");
            log.Info("Enter Languages.");
            Thread.Sleep(2000);
            commonPage.PressEnterKey();
            Thread.Sleep(2000);

            //Enter Development Skills
            addUsersPage.EnterDevelopmentSkills("Cricket");
            log.Info("Enter Interested In.");
            Thread.Sleep(2000);
            commonPage.PressEnterKey();
            Thread.Sleep(2000);

            //Enter LinkedIn Url
            addUsersPage.EnterLinkedInUrl("https://linkedDinMe.com");
            log.Info("Enter LinkedIn Url.");
            Thread.Sleep(2000);

            //Enter Phone
            addUsersPage.EnterPhone("9811966057");
            log.Info("Enter Phone.");
            Thread.Sleep(2000);

            //Enter Address
            addUsersPage.EnterAddress("Capetown");
            log.Info("Enter Address.");
            Thread.Sleep(2000);

            //Enter City
            addUsersPage.EnterCity("Noida");
            log.Info("Enter City.");
            Thread.Sleep(2000);

            //Enter State/Province
            addUsersPage.EnterStateProvince("UP");
            log.Info("Enter State/Province.");
            Thread.Sleep(2000);

            //Enter Postal Code
            addUsersPage.EnterPostalCode("201305");
            log.Info("Enter Postal Code.");
            Thread.Sleep(2000);

            //Enter Country
            addUsersPage.EnterCountry("India");
            log.Info("Enter Country.");
            Thread.Sleep(2000);

            //Click Create button
            commonPage.ScrollUp();
            Thread.Sleep(2000);
            addUsersPage.ClickCreate();
            log.Info("Click on Create Button");
            Thread.Sleep(7000);

            //Verify the added user
            addUsersPage.VerifyAddedUserName(builder.ToString()+" "+builder.ToString());
            log.Info("Verify the added user Full Name.");
            Thread.Sleep(1000);    
        }

    }
}
