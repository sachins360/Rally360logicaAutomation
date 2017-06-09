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
using RallyTeam;
using log4net;
using System.Reflection;

namespace RallyTeam.TestScripts
{
    [TestFixture]
    [Category("DirectMessaging")]
    public class DirectMessagingTest : BaseTestES
    {
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        static ReadData readMessages = new ReadData("DirectMessaging");

        //SignIn
        private void SignInDifferentUser()
        {
            String userName = readMessages.GetValue("SignInDifferentUser", "userName");
            String password = readMessages.GetValue("SignInDifferentUser", "password");
            authenticationPage.SetUserName(userName);
            authenticationPage.SetPassword(password);
            authenticationPage.ClickOnLoginButton();
        }
        
        [Test]
        public void DirectMessaging_001_VerifyMessagesPage()
        {
            Global.MethodName = "DirectMessaging_001_VerifyMessagesPage";

            Thread.Sleep(5000);
            directMessagingPage.VerifyMessagessMenuOption();
            log.Info("Verify Messages icon");
       
            //Click Messages menu icon
            directMessagingPage.ClickMessagesMenu();
            log.Info("Click Messages menu icon.");
            Thread.Sleep(3000);                
                 
            //Verify All Messages drop-down is displayed
            directMessagingPage.VerifyAllMessagesDropDown();
            log.Info("Verify All Messages drop-down is displayed.");
            Thread.Sleep(1000);

            //Verify New Message Btn is displayed
            directMessagingPage.VerifyNewMessageBtn();
            log.Info("Verify New Message Btn is displayed.");
            Thread.Sleep(1000);

            //Verify Send Announcemnet Btn is displayed
            directMessagingPage.VerifySendAnnouncementBtn();
            log.Info("Verify Send Announcemnet Btn is displayed.");
        }

        [Test]
        public void DirectMessaging_002_VerifyNewMessageWindow()
        {
            Global.MethodName = "DirectMessaging_002_VerifyNewMessageWindow";

            //Click Messages menu icon
            Thread.Sleep(5000);
            directMessagingPage.ClickMessagesMenu();
            log.Info("Click Messages menu icon.");
            Thread.Sleep(5000);

            //Click New Message button
            directMessagingPage.ClickNewMessageBtn();
            log.Info("Click New Message button.");
            Thread.Sleep(5000);

            //Verify New Message Window is displayed
            directMessagingPage.VerifyNewMessageWindow();
            log.Info("Verify New Message Window is displayed.");
            Thread.Sleep(1000);

            //Verify To label is displayed
            directMessagingPage.VerifyToLabel();
            log.Info("Verify To label is displayed.");
            Thread.Sleep(1000);

            //Verify To text input is displayed
            directMessagingPage.VerifyToTextInput();
            log.Info("Verify To text input is displayed.");
            Thread.Sleep(1000);

            //Verify Text Area is displayed
            directMessagingPage.VerifyTextArea();
            log.Info("Verify Text Area is displayed.");
            Thread.Sleep(1000);

            //Verify Send button is displayed
            directMessagingPage.VerifySendBtn();
            log.Info("Verify Send button is displayed.");
            Thread.Sleep(1000);

            //Verify attachment icon is displayed
            directMessagingPage.VerifyTextArea();
            log.Info("Verify attachment icon is displayed.");
            Thread.Sleep(1000);

            //Verify close icon is displayed
            directMessagingPage.VerifyTextArea();
            log.Info("Verify close icon is displayed.");            
        }

        [Test]
        public void DirectMessaging_003_SendNewMessageAndVerify()
        {
            Global.MethodName = "DirectMessaging_003_SendNewMessageAndVerify";

            //Click Messages menu icon
            Thread.Sleep(5000);
            directMessagingPage.ClickMessagesMenu();
            log.Info("Click Messages menu icon.");
            Thread.Sleep(5000);

            //Click New Message button
            directMessagingPage.ClickNewMessageBtn();
            log.Info("Click New Message button.");
            Thread.Sleep(5000);

            //Enter To text input
            String userEmail = readMessages.GetValue("Messages", "userEmail");
            directMessagingPage.EnterToTextInput(userEmail);
            log.Info("Enter the user email.");
            Thread.Sleep(3000);

            //Press enter key
            directMessagingPage.PressEnterKey();
            Thread.Sleep(1000);

            //Enter message in the text area
            String message = readMessages.GetValue("Messages", "message");
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(4));
            message = message + builder;
            directMessagingPage.EnterTextArea(message);
            log.Info("Enter the message.");
            Thread.Sleep(2000);

            //Click Send button
            directMessagingPage.ClickSendBtn();
            log.Info("Click Send button.");
            Thread.Sleep(5000);                      

            //Verify New message posted successfully
            directMessagingPage.VerifyNewMessagePosted(message);
            log.Info("Verify message is successfully posted.");
        }

        [Test]
        public void DirectMessaging_004_ReplyMessage()
        {
            Global.MethodName = "DirectMessaging_004_ReplyMessage";

            //Click Messages menu icon
            Thread.Sleep(5000);
            directMessagingPage.ClickMessagesMenu();
            log.Info("Click Messages menu icon.");
            Thread.Sleep(5000);

            //Click New Message button
            directMessagingPage.ClickNewMessageBtn();
            log.Info("Click New Message button.");
            Thread.Sleep(5000);

            //Enter To text input
            String userEmail = readMessages.GetValue("Messages", "userEmail");
            directMessagingPage.EnterToTextInput(userEmail);
            log.Info("Enter the user email.");
            Thread.Sleep(3000);

            //Press enter key
            directMessagingPage.PressEnterKey();
            Thread.Sleep(1000);

            //Enter message in the text area
            String message = readMessages.GetValue("Messages", "message");
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(4));
            message = message + builder;
            directMessagingPage.EnterTextArea(message);
            log.Info("Enter the message.");
            Thread.Sleep(2000);

            //Click Send button
            directMessagingPage.ClickSendBtn();
            log.Info("Click Send button.");
            Thread.Sleep(1000);

            //Signout of the application
            Thread.Sleep(5000);
            authenticationPage.SignOut();
            log.Info("Click on the Signout button.");

            //Sign in with a different user
            Thread.Sleep(2000);
            SignInDifferentUser();
            log.Info("Sign in with different user.");
            Thread.Sleep(5000);

            //Click Messages menu icon
            directMessagingPage.ClickMessagesMenu();
            log.Info("Click Messages menu icon.");
            Thread.Sleep(5000);

            //Click the message received
            directMessagingPage.ClickMessageReceived(message);
            log.Info("Click on the message received by the user");
            Thread.Sleep(5000);

            //Enter message in the text area
            directMessagingPage.EnterReplyTextArea("This is the reply message.");
            log.Info("Enter the reply message.");
            Thread.Sleep(3000);

            //Click Send button
            directMessagingPage.ClickReplySendBtn();
            log.Info("Click Send button.");
            Thread.Sleep(5000);
        }

        /*[Test]
        public void DirectMessaging_005_VerifyMessageReceivedCounter()
        {
            Global.MethodName = "DirectMessaging_005_VerifyMessageReceivedCounter";

            //Click Messages menu icon
            Thread.Sleep(5000);
            directMessagingPage.ClickMessagesMenu();
            log.Info("Click Messages menu icon.");
            Thread.Sleep(5000);

            //Click New Message button
            directMessagingPage.ClickNewMessageBtn();
            log.Info("Click New Message button.");
            Thread.Sleep(5000);

            //Enter To text input
            String userEmail = readMessages.GetValue("Messages", "userEmail");
            directMessagingPage.EnterToTextInput(userEmail);
            log.Info("Enter the user email.");
            Thread.Sleep(3000);

            //Press enter key
            directMessagingPage.PressEnterKey();
            Thread.Sleep(1000);

            //Enter message in the text area
            String message = readMessages.GetValue("Messages", "message");
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(4));
            message = message + builder;
            directMessagingPage.EnterTextArea(message);
            log.Info("Enter the message.");
            Thread.Sleep(2000);

            //Click Send button
            directMessagingPage.ClickSendBtn();
            log.Info("Click Send button.");
            Thread.Sleep(7000);

            //Signout of the application
            authenticationPage.SignOut();
            log.Info("Click on the Signout button.");
            Thread.Sleep(5000);

            //Sign in with a different user
            SignInDifferentUser();
            log.Info("Sign in with different user.");
            Thread.Sleep(7000);

            //Get the Initial Message counter
            string initialCounter = directMessagingPage.GetMessageCounterValue();
            int initialCounterInt = Int32.Parse(initialCounter);
            int finalCounter = initialCounterInt + 1;
            string finalCounterString = finalCounter.ToString();

            //Signout of the application
            authenticationPage.SignOut();
            log.Info("Click on the Signout button.");
            Thread.Sleep(5000);

            //Sign in with a different user
            String differentUserName = readMessages.GetValue("SignInDifferentUser", "differentUserName");
            String password = readMessages.GetValue("SignInDifferentUser", "password");
            authenticationPage.SetUserName(differentUserName);
            authenticationPage.SetPassword(password);
            authenticationPage.ClickOnLoginButton();
            log.Info("Sign in with different user.");
            Thread.Sleep(7000);

            //Click Messages menu icon
            Thread.Sleep(5000);
            directMessagingPage.ClickMessagesMenu();
            log.Info("Click Messages menu icon.");
            Thread.Sleep(5000);

            //Click New Message button
            directMessagingPage.ClickNewMessageBtn();
            log.Info("Click New Message button.");
            Thread.Sleep(5000);

            //Enter To text input
            String loggedInUser = readMessages.GetValue("Messages", "userEmail");
            directMessagingPage.EnterToTextInput(loggedInUser);
            log.Info("Enter the user email.");
            Thread.Sleep(3000);

            //Press enter key
            directMessagingPage.PressEnterKey();
            Thread.Sleep(1000);

            //Enter message in the text area
            directMessagingPage.EnterTextArea("Message by Bob");
            log.Info("Enter the message.");
            Thread.Sleep(2000);

            //Click Send button
            directMessagingPage.ClickSendBtn();
            log.Info("Click Send button.");
            Thread.Sleep(7000);

            //Signout of the application
            authenticationPage.SignOut();
            log.Info("Click on the Signout button.");
            Thread.Sleep(5000);

            //Sign in with a different user
            SignInDifferentUser();
            log.Info("Sign in with different user.");
            Thread.Sleep(7000);

            //Verify the Message Counter has increased
            directMessagingPage.VerifyIncreasedMessageCounterValue(finalCounterString);
            log.Info("Verify the Message Counter has increased");
            Thread.Sleep(1000);

            //Click Messages menu icon
            Thread.Sleep(5000);
            directMessagingPage.ClickMessagesMenu();
            log.Info("Click Messages menu icon.");
            Thread.Sleep(5000);

            //Click the message received
            directMessagingPage.ClickMessageReceived(message);
            log.Info("Click on the message received by the user");
            Thread.Sleep(5000);

            //Click back icon
            directMessagingPage.ClickBackIcon();
            log.Info("Click the Messages Back icon.");
            Thread.Sleep(3000);

            //Click the message received
            directMessagingPage.ClickMessageReceived("Message by Bob");
            log.Info("Click on the message received by the user");
            Thread.Sleep(5000);
        }*/

        [Test]
        public void DirectMessaging_005_VerifySendAnnouncementWindow()
        {
            Global.MethodName = "DirectMessaging_005_VerifySendAnnouncementWindow";

            //Click Messages menu icon
            Thread.Sleep(5000);
            directMessagingPage.ClickMessagesMenu();
            log.Info("Click Messages menu icon.");
            Thread.Sleep(5000);

            //Click Send Announcement button
            directMessagingPage.ClickSendAnnouncementBtn();
            log.Info("Click Send Announcement button.");
            Thread.Sleep(5000);

            //Verify Send Announcement Window is displayed
            directMessagingPage.VerifySendAnnouncementWindow();
            log.Info("Verify Send Announcement Window is displayed.");
            Thread.Sleep(1000);

            //Verify Group Drop-Down is displayed
            directMessagingPage.VerifyGroupDropDown();
            log.Info("Verify Group Drop-Down is displayed.");
            Thread.Sleep(1000);                       

            //Verify Text Area is displayed
            directMessagingPage.VerifyTextArea();
            log.Info("Verify Text Area is displayed.");
            Thread.Sleep(1000);

            //Verify Send button is displayed
            directMessagingPage.VerifySendBtn();
            log.Info("Verify Send button is displayed.");
            Thread.Sleep(1000);

            //Verify attachment icon is displayed
            directMessagingPage.VerifyTextArea();
            log.Info("Verify attachment icon is displayed.");
            Thread.Sleep(1000);

            //Verify close icon is displayed
            directMessagingPage.VerifyTextArea();
            log.Info("Verify close icon is displayed.");
        }

        /*[Test]
        public void DirectMessaging_006_SendNewAnnouncementAndVerify()
        {
            Global.MethodName = "DirectMessaging_006_SendNewAnnouncementAndVerify";

            //Click Messages menu icon
            Thread.Sleep(5000);
            directMessagingPage.ClickMessagesMenu();
            log.Info("Click Messages menu icon.");
            Thread.Sleep(5000);

            //Click Send Announcement button
            directMessagingPage.ClickSendAnnouncementBtn();
            log.Info("Click Send Announcement button.");
            Thread.Sleep(5000);

            //Select Group
            String group = readMessages.GetValue("Announcements", "group");
            directMessagingPage.SelectGroup(group);
            log.Info("Select a Group.");

            //Enter announcement in the text area
            String announcement = readMessages.GetValue("Announcements", "announcement");
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(4));
            announcement = announcement + builder;
            directMessagingPage.EnterTextArea(announcement);
            log.Info("Enter the announcement.");
            Thread.Sleep(2000);

            //Click Send button
            directMessagingPage.ClickSendBtn();
            log.Info("Click Send button.");
            Thread.Sleep(5000);

            //Verify announcement posted successfully
            directMessagingPage.VerifyNewMessagePosted(announcement);
            log.Info("Verify announcement is successfully posted.");
        }

        [Test]
        public void DirectMessaging_007_VerifyAnnouncementReceived()
        {
            Global.MethodName = "DirectMessaging_007_VerifyAnnouncementReceived";

            //Click Messages menu icon
            Thread.Sleep(5000);
            directMessagingPage.ClickMessagesMenu();
            log.Info("Click Messages menu icon.");
            Thread.Sleep(5000);

            //Click Send Announcement button
            directMessagingPage.ClickSendAnnouncementBtn();
            log.Info("Click Send Announcement button.");
            Thread.Sleep(5000);

            //Select Group
            String group = readMessages.GetValue("Announcements", "group");
            directMessagingPage.SelectGroup(group);
            log.Info("Select a Group.");

            //Enter announcement in the text area
            String announcement = readMessages.GetValue("Announcements", "announcement");
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(4));
            announcement = announcement + builder;
            directMessagingPage.EnterTextArea(announcement);
            log.Info("Enter the announcement.");
            Thread.Sleep(2000);

            //Click Send button
            directMessagingPage.ClickSendBtn();
            log.Info("Click Send button.");
            Thread.Sleep(5000);

            //Signout of the application
            Thread.Sleep(5000);
            authenticationPage.SignOut();
            log.Info("Click on the Signout button.");

            //Sign in with a different user
            Thread.Sleep(2000);
            SignInDifferentUser();
            log.Info("Sign in with different user.");
            Thread.Sleep(5000);

            //Verify Announcement Received Modal displayed
            directMessagingPage.VerifyAnnouncementModal();
            log.Info("Verify Announcement Received Modal is displayed.");
            Thread.Sleep(1000);

            //Verify Announcement Received Header
            String loggedInUserName = readMessages.GetValue("Messages", "loggedInUserName");
            directMessagingPage.VerifyAnnouncementHeader(loggedInUserName);
            log.Info("Verify Announcement Received Header is displayed.");
            Thread.Sleep(1000);

            //Verify Announcement Received Displayed
            directMessagingPage.VerifyAnnouncementText(announcement);
            log.Info("Verify Announcement Received is displayed.");
            Thread.Sleep(1000);

            //Verify Announcement Modal Close Button
            directMessagingPage.VerifyAnnouncementCloseBtn();
            log.Info("Verify Announcement Modal Close button is displayed.");
            Thread.Sleep(1000);

            //Verify Announcement Modal Close Icon
            directMessagingPage.VerifyAnnouncementCloseIcon();
            log.Info("Verify Announcement Modal Close icon is displayed.");
            Thread.Sleep(1000);

            //Verify Announcement Modal Contact Sender
            directMessagingPage.VerifyAnnouncementContactSender();
            log.Info("Verify Announcement Modal Contact Sender is displayed.");
            Thread.Sleep(1000);

            //Click Announcement Modal Close Button
            directMessagingPage.ClickAnnouncementCloseBtn();
            log.Info("Click Announcement Modal Close button is displayed.");
        }

        [Test]
        public void DirectMessaging_008_SendMessageAnnouncementReceived()
        {
            Global.MethodName = "DirectMessaging_008_SendMessageAnnouncementReceived";

            //Click Messages menu icon
            Thread.Sleep(5000);
            directMessagingPage.ClickMessagesMenu();
            log.Info("Click Messages menu icon.");
            Thread.Sleep(5000);

            //Click Send Announcement button
            directMessagingPage.ClickSendAnnouncementBtn();
            log.Info("Click Send Announcement button.");
            Thread.Sleep(5000);

            //Select Group
            String group = readMessages.GetValue("Announcements", "group");
            directMessagingPage.SelectGroup(group);
            log.Info("Select a Group.");

            //Enter announcement in the text area
            String announcement = readMessages.GetValue("Announcements", "announcement");
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(4));
            announcement = announcement + builder;
            directMessagingPage.EnterTextArea(announcement);
            log.Info("Enter the announcement.");
            Thread.Sleep(2000);

            //Click Send button
            directMessagingPage.ClickSendBtn();
            log.Info("Click Send button.");
            Thread.Sleep(5000);

            //Signout of the application
            Thread.Sleep(5000);
            authenticationPage.SignOut();
            log.Info("Click on the Signout button.");

            //Sign in with a different user
            Thread.Sleep(2000);
            SignInDifferentUser();
            log.Info("Sign in with different user.");
            Thread.Sleep(5000);
                        
            //Click Announcement Modal Contact Sender
            directMessagingPage.ClickAnnouncementContactSender();
            log.Info("Click Announcement Modal Contact Sender.");
            Thread.Sleep(5000);

            //Enter message in the text area
            String message = readMessages.GetValue("Messages", "message");
            builder.Append(RandomString(4));
            message = message + builder;
            directMessagingPage.EnterTextArea(message);
            log.Info("Enter the message.");
            Thread.Sleep(2000);

            //Click Send button
            directMessagingPage.ClickSendBtn();
            log.Info("Click Send button.");
            Thread.Sleep(1000);

            //Click Announcement Modal Close Button
            directMessagingPage.ClickAnnouncementCloseBtn();
            log.Info("Click Announcement Modal Close button is displayed.");
            Thread.Sleep(5000);

            //Verify announcement reply posted successfully
            directMessagingPage.VerifyNewMessagePosted(message);
            log.Info("Verify message is successfully posted.");
        }

        [Test]
        public void DirectMessaging_009_VerifyAnnouncementNotReceived()
        {
            Global.MethodName = "DirectMessaging_009_VerifyAnnouncementNotReceived";

            //Click Messages menu icon
            Thread.Sleep(5000);
            directMessagingPage.ClickMessagesMenu();
            log.Info("Click Messages menu icon.");
            Thread.Sleep(5000);

            //Click Send Announcement button
            directMessagingPage.ClickSendAnnouncementBtn();
            log.Info("Click Send Announcement button.");
            Thread.Sleep(5000);

            //Select Group
            String group = readMessages.GetValue("Announcements", "group");
            directMessagingPage.SelectGroup(group);
            log.Info("Select a Group.");

            //Enter announcement in the text area
            String announcement = readMessages.GetValue("Announcements", "announcement");
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(4));
            announcement = announcement + builder;
            directMessagingPage.EnterTextArea(announcement);
            log.Info("Enter the announcement.");
            Thread.Sleep(2000);

            //Click Send button
            directMessagingPage.ClickSendBtn();
            log.Info("Click Send button.");
            Thread.Sleep(5000);

            //Signout of the application
            Thread.Sleep(5000);
            authenticationPage.SignOut();
            log.Info("Click on the Signout button.");

            //Sign in with a different user
            String differentUserName = readMessages.GetValue("SignInDifferentUser", "differentUserName");
            String password = readMessages.GetValue("SignInDifferentUser", "password");
            authenticationPage.SetUserName(differentUserName);
            authenticationPage.SetPassword(password);
            authenticationPage.ClickOnLoginButton();
            log.Info("Sign in with different user.");
            Thread.Sleep(7000);                       

            //Verify Announcement Not Received
            directMessagingPage.VerifyAnnouncementNoText(announcement);
            log.Info("Verify Announcement not received.");            
        }

        [Test]
        public void DirectMessaging_010_VerifyAnnouncementCannotBeReplied()
        {
            Global.MethodName = "DirectMessaging_010_VerifyAnnouncementCannotBeReplied";

            //Click Messages menu icon
            Thread.Sleep(5000);
            directMessagingPage.ClickMessagesMenu();
            log.Info("Click Messages menu icon.");
            Thread.Sleep(5000);

            //Click Send Announcement button
            directMessagingPage.ClickSendAnnouncementBtn();
            log.Info("Click Send Announcement button.");
            Thread.Sleep(5000);

            //Select Group
            String group = readMessages.GetValue("Announcements", "group");
            directMessagingPage.SelectGroup(group);
            log.Info("Select a Group.");

            //Enter announcement in the text area
            String announcement = readMessages.GetValue("Announcements", "announcement");
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(4));
            announcement = announcement + builder;
            directMessagingPage.EnterTextArea(announcement);
            log.Info("Enter the announcement.");
            Thread.Sleep(2000);

            //Click Send button
            directMessagingPage.ClickSendBtn();
            log.Info("Click Send button.");
            Thread.Sleep(5000);

            //Signout of the application
            Thread.Sleep(5000);
            authenticationPage.SignOut();
            log.Info("Click on the Signout button.");

            //Sign in with a different user
            Thread.Sleep(2000);
            SignInDifferentUser();
            log.Info("Sign in with different user.");
            Thread.Sleep(7000);

            //Click Announcement Modal Close Button
            directMessagingPage.ClickAnnouncementCloseBtn();
            log.Info("Click Announcement Modal Close button.");
            Thread.Sleep(5000);

            //Click Messages menu icon
            directMessagingPage.ClickMessagesMenu();
            log.Info("Click Messages menu icon.");
            Thread.Sleep(5000);

            //Click the announcement received
            directMessagingPage.ClickMessageReceived(announcement);
            log.Info("Click on the announcement received by the user");
            Thread.Sleep(5000);

            //Verify reply text area should not be present
            directMessagingPage.VerifyReplyTextAreaNotDisplayed();
            log.Info("Verify reply text area is not present.");
        }*/
    }
}