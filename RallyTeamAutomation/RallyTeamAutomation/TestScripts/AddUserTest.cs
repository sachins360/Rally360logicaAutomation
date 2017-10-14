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
using System.Configuration;

namespace RallyTeam.TestScripts
{
    [TestFixture]
    [Category("AddUsers")]
    public class AddUsersTest : BaseTestES
    {
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        public string _browser = ConfigurationSettings.AppSettings["Browser"].ToLower();
        static ReadData readInviteUser = new ReadData("AddUser");
        public string _password = ConfigurationSettings.AppSettings["password"].ToString();
        public string _workEmail = ConfigurationSettings.AppSettings["workEmail"].ToLower(); 

        String _Emailsubject = readInviteUser.GetValue("InviteEmailDetails", "emailSubject");
        String _EmailMessage = readInviteUser.GetValue("InviteEmailDetails", "emailMessage");
        String _opportunitiesType= readInviteUser.GetValue("InviteEmailDetails", "opportunitiesType");
        String _availableTime = readInviteUser.GetValue("InviteEmailDetails", "availableTime");

        StringBuilder builder, builder2;
        String email,email2;

        public void GoToAddUser()
        {
            builder = new StringBuilder();
            builder2 = new StringBuilder();
            builder.Append(RandomString(10));
            builder2.Append(RandomString(10));

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

        public void inviteUser()
        {
            //Click Email button
            if (_browser == "edge")
                addUsersPage.PressEmailBtn();
            else
                addUsersPage.ClickEmailBtn();
            log.Info("Click Email button.");
            Thread.Sleep(5000);

            //Enter Email Address
            email = builder + "@harakirimail.com";
            addUsersPage.EnterEmailAddresses(email);
            log.Info("Enter Email Address.");
            //commonPage.PressEnterKey();
            Thread.Sleep(2000);
            commonPage.PressEnterKey();
            builder.Append(RandomString(6));
            email2 = builder + "@harakirimail.com";
            addUsersPage.AppendEmailAddresses(email2);
            log.Info("Enter Second Email Address.");
            //commonPage.PressTabKey();
            commonPage.PressEnterKey();
            commonPage.PressEnterKey();
            Thread.Sleep(2000);

            //Click Add Users button
            addUsersPage.ClickEmailAddUsersBtn();
            log.Info("Click Add Users button.");
            Thread.Sleep(5000);

            //Enter the invite emaail subject and message
            addUsersPage.EnterEmailSubjectAndMessage(_Emailsubject, _EmailMessage);
            log.Info("Enter Email Subject.");
            commonPage.PressTabKey();
            Thread.Sleep(2000);


            //click on send invite button   
            addUsersPage.ClickSendInviteBtn();
            log.Info("Click Send Invite button.");
            Thread.Sleep(5000);

            //Click Finish button
            addUsersPage.ClickFinishBtn();
            log.Info("Click Finish button.");
            Thread.Sleep(5000);
        }

        public void verifyInviteMailFromMailinator(string _userEmail,string userId="User")
        {
            //Navigate to the user inbox
            commonPage.NavigateToUrl("https://www.harakirimail.com/");
            log.Info("Navigate to the mailinator site.");
            Thread.Sleep(7000);

            //Enter Harakirimail Email address
            addUsersPage.EnterHarakirimailEmail(_userEmail);
            log.Info("Enter email"+ _userEmail + " address.");
            Thread.Sleep(2000);

            //Press Enter key
            commonPage.PressEnterKey();
            Thread.Sleep(5000);

            //Verify the Email Sender
            addUsersPage.VerifyEmailSender();
            log.Info("Verify the "+ userId + " Email Sender.");
            Thread.Sleep(2000);

            //Verify the Email Subject
            addUsersPage.VerifyEmailSubject(_Emailsubject);
            log.Info("Verify the "+ userId + " Email Subject.");
            Thread.Sleep(2000);

            //Click the Email Subject
            addUsersPage.ClickEmailSubject(_Emailsubject);
            log.Info("Click the "+ userId + " Email Subject.");
            Thread.Sleep(5000);

            //Verify the Email Get Started Button
            addUsersPage.VerifyEmailGetStartedBtn();
            log.Info("Verify the "+ userId + " Email Get Started Button.");

        }      

        public void onBoardInviteUser(string skill= "Android")
        {
            //Click Get Started button
            addUsersPage.ClickMailinatorEmailGetStartedBtn();
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
            registrationPage.EnterCreatePwdFields(_password);
            log.Info("Enter Create a Password field on the screen.");
            Thread.Sleep(2000);

            //Enter Confirm Password field on the screen
            registrationPage.EnterConfirmPwdFields(_password);
            log.Info("Enter Confirm Password field on the screen.");
            Thread.Sleep(2000);

            //Click All Done Button on the screen
            registrationPage.ClickAllDoneBtn();
            log.Info("Click All Done button on the screen.");
            Thread.Sleep(7000);


            //Select type of opportunities are you looking for            
            addUsersPage.SelectOpportunitiesType(_opportunitiesType);
            log.Info("Select type of opportunities are you looking for.");
            Thread.Sleep(7000);

            //Select How many hours a week are you available
            addUsersPage.SelectAvailableTime(_availableTime);
            log.Info("Select type of opportunities are you looking for.");
            Thread.Sleep(4000);

            //Click on next link
            addUsersPage.ClickNextBtn();
            log.Info("Click on next link.");
            Thread.Sleep(4000);

            //Click on skip button    
            addUsersPage.ClickSkipBtn();
            log.Info("Click on skip link.");
            Thread.Sleep(4000);

            //Enter Skill and Click on next button
            addUsersPage.EnterSkillAndClickNextBtn("Test");
            log.Info("Click on next link.");
            Thread.Sleep(4000);

            //Enter Skills
            commonPage.ScrollDown();
            addUsersPage.EnterTopSkills(skill);
            Thread.Sleep(2000);
            commonPage.PressEnterKey();
            Thread.Sleep(2000);        

            //Click Done button on Profile
            commonPage.ScrollUp();
            Thread.Sleep(2000);
            addUsersPage.ClickDoneBtn();
            log.Info("Click Done button.");
            Thread.Sleep(5000);
        }

        public void createUserProfile()
        {//Click Create a Profile button
            if (_browser == "edge")
                addUsersPage.PressCreateProfileBtn();
            else
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

            //Enter Title
            addUsersPage.EnterTitle("Automation Script");
            log.Info("Enter Title.");
            Thread.Sleep(2000);

            //Enter About Me
            addUsersPage.EnterAboutMe("I am an automated script");
            log.Info("Enter About Me.");
            Thread.Sleep(2000);

            //Enter Address
            addUsersPage.EnterAddress("Capetown");
            log.Info("Enter Address.");
            Thread.Sleep(2000);
            commonPage.HalfScrollDown(500);
            Thread.Sleep(2000);

            //Enter City
            addUsersPage.EnterCity("Noida");
            log.Info("Enter City.");
            Thread.Sleep(2000);

            //Enter State/Province
            addUsersPage.EnterStateProvince("UP");
            log.Info("Enter State/Province.");
            Thread.Sleep(2000);

            //Enter Country
            addUsersPage.EnterCountry("India");
            log.Info("Enter Country.");
            Thread.Sleep(2000);

            //Enter Postal Code
            addUsersPage.EnterPostalCode("201305");
            log.Info("Enter Postal Code.");
            Thread.Sleep(2000);

            //Enter Email
            email = builder + "@harakirimail.com";
            addUsersPage.EnterEmail(email);
            log.Info("Enter Email.");
            Thread.Sleep(2000);

            //Enter Phone
            addUsersPage.EnterPhone("9811966057");
            log.Info("Enter Phone.");

            Thread.Sleep(2000);

            //Enter My Top Skills
            addUsersPage.EnterMyTopSkills("Selenium WebDriver");
            log.Info("Enter My Top Skills.");
            Thread.Sleep(2000);
            commonPage.PressEnterKey();
            Thread.Sleep(2000);
            commonPage.HalfScrollDown(700);
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

            ////Enter Development Skills
            //addUsersPage.EnterDevelopmentSkills("Cricket");
            //log.Info("Enter Interested In.");
            //Thread.Sleep(2000);
            //commonPage.PressEnterKey();
            //Thread.Sleep(2000);

            ////Enter Languages
            //addUsersPage.EnterLanguages("English");
            //log.Info("Enter Languages.");
            //Thread.Sleep(2000);
            //commonPage.PressEnterKey();
            //Thread.Sleep(2000);


            ////Enter LinkedIn Url
            //addUsersPage.EnterLinkedInUrl("https://linkedDinMe.com");
            //log.Info("Enter LinkedIn Url.");
            //Thread.Sleep(2000);  


            //Click Create button
            commonPage.ScrollUp();
            Thread.Sleep(2000);
            addUsersPage.ClickCreate();
            log.Info("Click on Create Button");
            Thread.Sleep(7000);


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

            //Verify Download CSV link
            Thread.Sleep(5000);
            addUsersPage.VerifyDownloadCSV();
            log.Info("Verify Download CSV Option.");
            Thread.Sleep(1000);

            ////Verify CSV button
            //addUsersPage.VerifyCsvBtn();
            //log.Info("Verify CSV button.");
            //Thread.Sleep(1000);

            ////Verify Email button
            //addUsersPage.VerifyEmailBtn();
            //log.Info("Verify Email button.");
            //Thread.Sleep(1000);

            ////Verify Create Profile button
            //addUsersPage.VerifyCreateProfileBtn();
            //log.Info("Verify Create Profile button.");
        }

        [Test]
        public void AddUser_002_SendAndVerifyInviteEmail()
        {
            Global.MethodName = "AddUser_002_SendAndVerifyInviteEmail";
            Thread.Sleep(5000);
            GoToAddUser();

            //Invite an user         
            inviteUser();

            //Verify user invite email from mailinator
            verifyInviteMailFromMailinator(email);
            Thread.Sleep(2000);

            //Click on Get Started button from mailinator email
            addUsersPage.ClickMailinatorEmailGetStartedBtn();
            log.Info("Click Get Started button from mailinator email.");
            Thread.Sleep(5000);

            //Verfy user redirected to Rallyteam after click on Get Started button
            addUsersPage.VerifyRallyteamLogo();
            log.Info("Verify Rallyteam logo on signup page");
            Thread.Sleep(3000);
        }

        [Test]
        public void AddUser_003_OnboardWithInvitedUser()
        {
            Global.MethodName = "AddUser_003_OnboardWithInvitedUser";
            Thread.Sleep(5000);
            GoToAddUser();

            //Invite an user         
            inviteUser();

            //Verify user invite email from mailinator
            verifyInviteMailFromMailinator(email);
            Thread.Sleep(2000);

            //Onboard invite user
            onBoardInviteUser();

        }

        [Test]
        public void AddUser_004_SendAndVerifyInviteEmailMultipleUsers()
        {
            Global.MethodName = "AddUser_004_SendAndVerifyInviteEmailMultipleUsers";
            Thread.Sleep(5000);
            GoToAddUser();

            //Invite auser1
            email = builder + "@harakirimail.com";
            inviteUser();

            //Verify user1 invite email from mailinator
            verifyInviteMailFromMailinator(email);
            Thread.Sleep(2000);          

            //Verify user2 invite email from mailinator
            verifyInviteMailFromMailinator(email2);
            Thread.Sleep(2000);

            ////Click Email button
            //if (_browser == "edge")
            //    addUsersPage.PressEmailBtn();
            //else
            //    addUsersPage.ClickEmailBtn();
            //log.Info("Click Email button.");
            //Thread.Sleep(5000);

            ////Enter Email Address
            //email = builder + "@harakirimail.com";
            //addUsersPage.EnterEmailAddresses(email);
            //log.Info("Enter Email Address.");
            //commonPage.PressTabKey();
            //builder.Append(RandomString(6));
            //email2 = builder + "@harakirimail.com";
            //addUsersPage.EnterEmailAddresses(email);
            //log.Info("Enter Second Email Address.");
            //commonPage.PressTabKey();
            //Thread.Sleep(2000);

            ////Click Add Users button
            //addUsersPage.ClickEmailAddUsersBtn();
            //log.Info("Click Add Users button.");
            //Thread.Sleep(5000);

            ////Click Finish button
            //addUsersPage.ClickFinishBtn();
            //log.Info("Click Finish button.");
            //Thread.Sleep(5000);

            ////Navigate to the user inbox
            //commonPage.NavigateToUrl("https://www.harakirimail.com/");
            //log.Info("Navigate to the mailinator site.");
            //Thread.Sleep(7000);

            ////Enter Harakirimail Email address
            //addUsersPage.EnterHarakirimailEmail(email);
            //log.Info("Enter email address.");
            //Thread.Sleep(2000);

            ////Press Enter key
            //commonPage.PressEnterKey();
            //Thread.Sleep(5000);

            ////Verify the Email Sender
            //addUsersPage.VerifyEmailSender();
            //log.Info("Verify the Email Sender.");
            //Thread.Sleep(2000);

            ////Verify the Email Subject
            //addUsersPage.VerifyEmailSubject();
            //log.Info("Verify the Email Subject.");
            //Thread.Sleep(2000);

            ////Click the Email Subject
            //addUsersPage.ClickEmailSubject();
            //log.Info("Click the Email Subject.");
            //Thread.Sleep(5000);

            ////Verify the Email Get Started Button
            //addUsersPage.VerifyEmailGetStartedBtn();
            //log.Info("Verify the Email Get Started Button.");
            //Thread.Sleep(2000);

            ////Navigate to the user inbox
            //commonPage.NavigateToUrl("https://www.harakirimail.com/");
            //log.Info("Navigate to the mailinator site.");
            //Thread.Sleep(7000);

            ////Enter Harakirimail Email address
            //addUsersPage.EnterHarakirimailEmail(email2);
            //log.Info("Enter email address.");
            //Thread.Sleep(2000);

            ////Press Enter key
            //commonPage.PressEnterKey();
            //Thread.Sleep(5000);

            ////Verify the Email Sender
            //addUsersPage.VerifyEmailSender();
            //log.Info("Verify the Email Sender.");
            //Thread.Sleep(2000);

            ////Verify the Email Subject
            //addUsersPage.VerifyEmailSubject();
            //log.Info("Verify the Email Subject.");
            //Thread.Sleep(2000);

            ////Click the Email Subject
            //addUsersPage.ClickEmailSubject();
            //log.Info("Click the Email Subject.");
            //Thread.Sleep(5000);

            ////Verify the Email Get Started Button
            //addUsersPage.VerifyEmailGetStartedBtn();
            //log.Info("Verify the Email Get Started Button.");
        }

        [Test]
        public void AddUser_005_UploadResume()
        {
            Global.MethodName = "AddUser_005_UploadResume";
            Thread.Sleep(5000);
            GoToAddUser();

            inviteUser();

            verifyInviteMailFromMailinator(email);

            //Click Get Started button
            addUsersPage.ClickMailinatorEmailGetStartedBtn();
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
            registrationPage.EnterCreatePwdFields(_password);
            log.Info("Enter Create a Password field on the screen.");
            Thread.Sleep(2000);

            //Enter Confirm Password field on the screen
            registrationPage.EnterConfirmPwdFields(_password);
            log.Info("Enter Confirm Password field on the screen.");
            Thread.Sleep(2000);

            //Click All Done Button on the screen
            registrationPage.ClickAllDoneBtn();
            log.Info("Click All Done button on the screen.");
            Thread.Sleep(7000);


            //Select type of opportunities are you looking for            
            addUsersPage.SelectOpportunitiesType(_opportunitiesType);
            log.Info("Select type of opportunities are you looking for.");
            Thread.Sleep(7000);

            //Select How many hours a week are you available
            addUsersPage.SelectAvailableTime(_availableTime);
            log.Info("Select type of opportunities are you looking for.");
            Thread.Sleep(4000);

            //Click on next link
            addUsersPage.ClickNextBtn();
            log.Info("Click on next link.");
            Thread.Sleep(4000);

            //Click Upload Resume button
            addUsersPage.ClickUploadYourResumeBtn();
            Thread.Sleep(5000);
           // String startupPath = Environment.CurrentDirectory; ;

            //string startupPath = "D:\\Rally360logicaAutomation\\RallyTeamAutomation";
            string startupPath = System.IO.Directory.GetCurrentDirectory();
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

            inviteUser();

            verifyInviteMailFromMailinator(email);

            //Click Get Started button
            addUsersPage.ClickMailinatorEmailGetStartedBtn();
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
            registrationPage.EnterCreatePwdFields(_password);
            log.Info("Enter Create a Password field on the screen.");
            Thread.Sleep(2000);

            //Enter Confirm Password field on the screen
            registrationPage.EnterConfirmPwdFields(_password);
            log.Info("Enter Confirm Password field on the screen.");
            Thread.Sleep(2000);

            //Click All Done Button on the screen
            registrationPage.ClickAllDoneBtn();
            log.Info("Click All Done button on the screen.");
            Thread.Sleep(7000);


            //Select type of opportunities are you looking for            
            addUsersPage.SelectOpportunitiesType(_opportunitiesType);
            log.Info("Select type of opportunities are you looking for.");
            Thread.Sleep(7000);

            //Select How many hours a week are you available
            addUsersPage.SelectAvailableTime(_availableTime);
            log.Info("Select type of opportunities are you looking for.");
            Thread.Sleep(4000);

            //Click on next link
            addUsersPage.ClickNextBtn();
            log.Info("Click on next link.");
            Thread.Sleep(4000);
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

            //Create User Profile
            createUserProfile();

            //Verify the added user
            addUsersPage.VerifyAddedUserName(builder.ToString() + " " + builder.ToString());
            log.Info("Verify the added user Full Name.");
            Thread.Sleep(1000);
        }

        //[Test]
        //public void AddUser_008_SendAndVerifyMultipleUserInviteEmail()
        //{
        //    Global.MethodName = "AddUser_008_SendAndVerifyMultipleUserInviteEmail";
        //    Thread.Sleep(5000);
        //    GoToAddUser();

        //    //Click Email button
        //    if (_browser == "edge")
        //        addUsersPage.PressEmailBtn();
        //    else
        //        addUsersPage.ClickEmailBtn();
        //    log.Info("Click Email button.");
        //    Thread.Sleep(5000);

        //    //Enter Email Address
        //    email = builder + "@harakirimail.com,";
        //    addUsersPage.EnterEmailAddresses(email);
        //    log.Info("Enter first Email Address.");
        //    //commonPage.PressEnterKey();
        //    Thread.Sleep(5000);
        //    email2 = builder2 + "@harakirimail.com";
        //    addUsersPage.EnterEmailAddresses(email2);
        //    log.Info("Enter Second Email Address.");
        //    commonPage.PressEnterKey();
        //    commonPage.PressTabKey();
        //    Thread.Sleep(2000);

        //    //Click Add Users button
        //    addUsersPage.ClickEmailAddUsersBtn();
        //    log.Info("Click Add Users button.");
        //    Thread.Sleep(5000);

        //    //Click Finish button
        //    addUsersPage.ClickFinishBtn();
        //    log.Info("Click Finish button.");
        //    Thread.Sleep(5000);

        //    //Verify invite email for first user
        //    verifyInviteMailFromMailinator(email,"First User");
        //    Thread.Sleep(3000);

        //    //Verify invite email for second user
        //    verifyInviteMailFromMailinator(email2, "Second User");
            

        //}
      
        [Test]
        public void AddUser_009_CannotInviteRegisteredUser()
        {
            Global.MethodName = "AddUser_009_CannotInviteRegisteredUser";
            Thread.Sleep(5000);
            GoToAddUser();

            if (_browser == "edge")
                addUsersPage.PressEmailBtn();
            else
                addUsersPage.ClickEmailBtn();
            log.Info("Click Email button.");
            Thread.Sleep(5000);

            //Enter Email Address
            email = "ammark@360logica.com";
            addUsersPage.EnterEmailAddresses(email);
            log.Info("Enter Email Address.");          
            commonPage.PressEnterKey();
            commonPage.PressEnterKey();
            Thread.Sleep(2000);

            //Click Add Users button
            addUsersPage.ClickEmailAddUsersBtn();
            log.Info("Click Add Users button.");
            Thread.Sleep(5000);

            //Enter the invite emaail subject and message
            addUsersPage.EnterEmailSubjectAndMessage(_Emailsubject, _EmailMessage);
            log.Info("Enter Email Subject.");
            commonPage.PressTabKey();
            Thread.Sleep(2000);


            //click on send invite button   
            addUsersPage.ClickSendInviteBtn();
            log.Info("Click Send Invite button.");
            Thread.Sleep(5000);

            //Verify no user should uploaded
            addUsersPage.VerifyUploadedUser();
            log.Info("Verify 0 user should uploaded");
            Thread.Sleep(3000);
        }

        [Test]
        public void AddUser_010_CannotInviteToInvalidEmailId()
        {
            Global.MethodName = "AddUser_010_CannotInviteToInvalidEmailId";
            Thread.Sleep(5000);
            GoToAddUser();

            //Click Email button
            if (_browser == "edge")
                addUsersPage.PressEmailBtn();
            else
                addUsersPage.ClickEmailBtn();
            log.Info("Click Email button.");
            Thread.Sleep(5000);

            //Enter Email Address            
            addUsersPage.EnterEmailAddresses("sachins@360logica");
            log.Info("Enter Invalid Email Address.");
            commonPage.PressTabKey();
            Thread.Sleep(2000);

            //Click Add Users button
            addUsersPage.ClickEmailAddUsersBtn();
            log.Info("Click Add Users button.");
            Thread.Sleep(5000);

            //Enter the invite emaail subject and message
            addUsersPage.EnterEmailSubjectAndMessage(_Emailsubject, _EmailMessage);
            log.Info("Enter Email Subject.");
            commonPage.PressTabKey();
            Thread.Sleep(2000);


            //click on send invite button   
            addUsersPage.ClickSendInviteBtn();
            log.Info("Click Send Invite button.");
            Thread.Sleep(5000);

            //Verify no user should uploaded
            addUsersPage.VerifyUploadedUser();
            log.Info("Verify 0 user should uploaded");
            Thread.Sleep(3000);
        }

        [Test]
        public void AddUser_011_VerifyInvitedEmailNotAskingVerifyCode()
        {
            Global.MethodName = "AddUser_011_VerifyInviteEmailNotAskingVerifyCode";
            Thread.Sleep(5000);
            GoToAddUser();

            //Invite an user         
            inviteUser();

            //Verify user invite email from mailinator
            verifyInviteMailFromMailinator(email);
            Thread.Sleep(2000);

            //Onboard invite user
            onBoardInviteUser();            

            //Verify verification code doesn't asking        
            authenticationPage.VerifyUserIcon();
            log.Info("Verify user able to login without asking any verification code.");
            Thread.Sleep(2000);


        }

        [Test]
        public void AddUser_0012_CreateProfileUserDoesRecciveInvitation()
        {
            Global.MethodName = "AddUser_0012_CreateProfileUserDoesnotRecciveInvitation";
            Thread.Sleep(5000);
            GoToAddUser();

            createUserProfile();

            //Verify the added user
            addUsersPage.VerifyAddedUserName(builder.ToString() + " " + builder.ToString());
            log.Info("Verify the added user Full Name.");
            Thread.Sleep(1000);

            //Click User Profile Icon
            userProfilePage.ClickUserProfileIcon();
            log.Info("Click the User Profile Icon.");
            Thread.Sleep(2000);

            //Select the User Profile Option 'Admin'
            userProfilePage.ClickUserProfileOptions("Admin");
            log.Info("Click User Profile option 'Admin'.");
            Thread.Sleep(5000);

            userProfilePage.EnterSearchUser(email);
            log.Info("Enter search user email id.");
            Thread.Sleep(5000);

            //Click search button            
            userProfilePage.ClickSearchButton();
            log.Info("Click on search button.");
            Thread.Sleep(5000);

            //Click the resend invite link of searched user
            userProfilePage.ClickSearchedUserResendInviteLink();
            log.Info("Click the resend invite link of searched user.");
            Thread.Sleep(5000);

            //click on send invite button   
            addUsersPage.ClickSendInviteBtn();
            log.Info("Click Send Invite button.");
            Thread.Sleep(5000);

            commonPage.NavigateToUrl("https://www.harakirimail.com/");
            log.Info("Navigate to the mailinator site.");
            Thread.Sleep(7000);

            //Enter Harakirimail Email address
            addUsersPage.EnterHarakirimailEmail(email);
            log.Info("Enter email" + email + " address.");
            Thread.Sleep(2000);

            //Press Enter key
            commonPage.PressEnterKey();
            Thread.Sleep(5000);

            //Verify user doesn't reccived any invitation email
            addUsersPage.VerifyEmailSenderDoesExist();
            log.Info("Verify user does reccived any invitation email.");
            Thread.Sleep(2000);

        }


    }
}


