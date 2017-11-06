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
    [Category("InviteUsersTest")]
    public class InviteUsersTest : BaseTest
    {
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        static ReadData readInviteUser = new ReadData("InviteUser");
        StringBuilder builder;
        String email;

        public void GoToInviteUser()
        {
            commonPage.NavigateToExternalStorm(_externalStormURL);
            Thread.Sleep(2000);

            builder = new StringBuilder();
            builder.Append(RandomString(6));

            //Login to the application
            Thread.Sleep(5000);
            authenticationPage.SetUserName(_workEmail);
            authenticationPage.SetPassword(_password);
            authenticationPage.ClickOnLoginButton();
            Thread.Sleep(5000);

            //Click User Profile Icon
            userProfilePage.ClickUserProfileIcon();
            log.Info("Click the User Profile Icon.");
            Thread.Sleep(2000);

            //Select the User Profile Option 'Admin'
            userProfilePage.ClickUserProfileOptions("Admin");
            log.Info("Click User Profile option 'Admin'.");
            Thread.Sleep(5000);

           /* //Click Manage Users tab
            userProfilePage.ClickManageUsersTab();
            log.Info("Click Manage Users tab.");
            Thread.Sleep(2000);*/

            //Click Invite Users button
            inviteUsersPage.ClickInviteUsersBtn();
            log.Info("Click Invite Users button.");
            Thread.Sleep(5000);
        }

        public void MoveToWelcomePage()
        {
            //Navigate to the user inbox
            commonPage.NavigateToUrl("https://www.mailinator.com/");
            log.Info("Navigate to the mailinator site.");
            Thread.Sleep(5000);

            //Enter Mailinator Email address
            onboardingPage.EnterMailinatorEmail(email);
            log.Info("Enter email address.");
            Thread.Sleep(2000);

            //Click on Go button
            onboardingPage.ClickGoBtn();
            log.Info("Click Go button.");
            Thread.Sleep(5000);

            //Click the Email Sender
            inviteUsersPage.ClickEmailSender();
            log.Info("Click the Email Sender.");
            Thread.Sleep(5000);

            //Switch to Iframe
            onboardingPage.SwitchIframe();
            Thread.Sleep(2000);

            //Get the Email Link and navigate
            String emailLink = inviteUsersPage.GetEmailLink();
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
        public void InviteUser_001_VerifyInviteUserWindow()
        {
            Global.MethodName = "InviteUser_001_VerifyInviteUserWindow";
            GoToInviteUser();

            //Verify Close Icon
            inviteUsersPage.VerifyCloseIcon();
            log.Info("Verify Close Icon.");
            Thread.Sleep(1000);

            /*//Verify Let's expand your network! message
            inviteUsersPage.VerifyLetsExpandYourNetworkMsg();
            log.Info("Verify Let's expand your network! message.");
            Thread.Sleep(1000);*/

            //Verify Upload your employees, external contractors, or contacts message
            inviteUsersPage.VerifyUploadkMsg();            
            log.Info("Verify Upload your employees, external contractors, or contacts message.");
            Thread.Sleep(1000);            

            //Verify Maybe Later Option
            inviteUsersPage.VerifyCloseIcon();
            log.Info("Verify Maybe Later Option.");
            Thread.Sleep(1000);

            //Verify Google button
            inviteUsersPage.VerifyGoogleBtn();
            log.Info("Verify Google button.");
            Thread.Sleep(1000);

            //Verify Outlook button
            inviteUsersPage.VerifyOutlookBtn();
            log.Info("Verify Outlook button.");
            Thread.Sleep(1000);

            //Verify CSV button
            inviteUsersPage.VerifyCsvBtn();
            log.Info("Verify CSV button.");
            Thread.Sleep(1000);

            //Verify Email button
            inviteUsersPage.VerifyEmailBtn();
            log.Info("Verify Email button.");
        }

        [Test]
        public void InviteUser_002_SendInvitationViaEmail()
        {
            Global.MethodName = "InviteUser_002_SendInvitationViaEmail";
            GoToInviteUser();
                        
            //Click Email button
            inviteUsersPage.ClickEmailBtn();
            log.Info("Click Email button.");
            Thread.Sleep(5000);

            //Enter Email Address
            email = builder + "@mailinator.com";
            inviteUsersPage.EnterEmailAddresses(email);
            log.Info("Enter Email Address.");
            Thread.Sleep(2000);

            //Click Send Invites button
            inviteUsersPage.ClickSendInvitesBtn();
            log.Info("Click Send Invites button.");
            Thread.Sleep(5000);

            //Click Finish button
            inviteUsersPage.ClickFinishBtn();
            log.Info("Click Finish button.");
            Thread.Sleep(5000);

            //Navigate to the user inbox
            commonPage.NavigateToUrl("https://www.mailinator.com/");
            log.Info("Navigate to the mailinator site.");
            Thread.Sleep(5000);

            //Enter Mailinator Email address
            onboardingPage.EnterMailinatorEmail(email);
            log.Info("Enter email address.");
            Thread.Sleep(2000);

            //Click on Go button
            onboardingPage.ClickGoBtn();
            log.Info("Click Go button.");
            Thread.Sleep(5000);

            //Verify the Email Sender
            inviteUsersPage.VerifyEmailSender();
            log.Info("Verify the Email Sender.");
            Thread.Sleep(2000);

            //Verify the Email Subject
            inviteUsersPage.VerifyEmailSubject();
            log.Info("Verify the Email Subject.");
            Thread.Sleep(2000);

            //Click the Email Sender
            inviteUsersPage.ClickEmailSender();
            log.Info("Click the Email Sender.");
            Thread.Sleep(5000);

            //Switch to Iframe
            onboardingPage.SwitchIframe();
            Thread.Sleep(2000);

            //Verify the Let's Rally Button
            inviteUsersPage.VerifyLetsRallyBtn();
            log.Info("Click the Let's Rally Button.");
        }

        [Test]
        public void InviteUser_003_VerifyInvitationViaEmail()
        {
            Global.MethodName = "InviteUser_003_VerifyInvitationViaEmail";
            GoToInviteUser();

            //Click Email button
            inviteUsersPage.ClickEmailBtn();
            log.Info("Click Email button.");
            Thread.Sleep(5000);

            //Enter Email Address
            email = builder + "@mailinator.com";
            inviteUsersPage.EnterEmailAddresses(email);
            log.Info("Enter Email Address.");
            Thread.Sleep(2000);

            //Click Send Invites button
            inviteUsersPage.ClickSendInvitesBtn();
            log.Info("Click Send Invites button.");
            Thread.Sleep(5000);

            //Click Finish button
            inviteUsersPage.ClickFinishBtn();
            log.Info("Click Finish button.");
            Thread.Sleep(5000);

            //Navigate to the user inbox
            commonPage.NavigateToUrl("https://www.mailinator.com/");
            log.Info("Navigate to the mailinator site.");
            Thread.Sleep(5000);

            //Enter Mailinator Email address
            onboardingPage.EnterMailinatorEmail(email);
            log.Info("Enter email address.");
            Thread.Sleep(2000);

            //Click on Go button
            onboardingPage.ClickGoBtn();
            log.Info("Click Go button.");
            Thread.Sleep(5000);            

            //Click the Email Sender
            inviteUsersPage.ClickEmailSender();
            log.Info("Click the Email Sender.");
            Thread.Sleep(5000);

            //Switch to Iframe
            onboardingPage.SwitchIframe();
            Thread.Sleep(2000);

            //Get the Email Link and navigate
            String emailLink = onboardingPage.GetEmailLink();
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
            Thread.Sleep(5000);

            //Verify the We Just Sent You An Email message
            onboardingPage.VerifyWeJustSentYouAnEmailMsg();
            log.Info("Verify the We Just Sent You An Email message.");
            Thread.Sleep(1000);

            //Verify Resend Email button
            onboardingPage.VerifyResendEmailbtn();
            log.Info("Verify Resend Email button.");
            Thread.Sleep(2000);
        }




    }
}
