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

namespace RallyTeam.TestScripts
{
    [TestFixture]
    [Category("Messages")]
    public class MessagesTest : BaseTest
    {
        static ReadData readMessages = new ReadData("Messages");
        ProjectsTest pt = new ProjectsTest();

        //SignIn
        private void SignInDifferentUser()
        {
            String userName = readMessages.GetValue("SignInDifferentUser", "userName");
            String password = readMessages.GetValue("SignInDifferentUser", "password");
            authenticationPage.SetUserName(userName);
            authenticationPage.SetPassword(password);
            authenticationPage.ClickOnLoginButton();
        }

        //Create a Task
        private void CreateTask(String taskName)
        {
            //Click Tasks menu option
            tasksPage.ClickTasksMenu();
            log.Info("Click the Tasks menu option.");
            Thread.Sleep(3000);

            //Enter the Task Name
            tasksPage.EnterTaskName(taskName);
            log.Info("Enter the Task Name.");
            Thread.Sleep(2000);

            //Click the Add Task Plus icon
            tasksPage.ClickAddTaskPlusIcon();
            log.Info("Click the Add Task Plus icon.");
            Thread.Sleep(4000);
        }

        //Delete Task
        private void DeleteTask(String taskName)
        {
            //Click the Task
            Thread.Sleep(2000);
            tasksPage.ClickTaskDisplayed(taskName);
            log.Info("Click the Task.");
            Thread.Sleep(3000);

            //Click Delete this task link
            tasksPage.ClickDeleteThisTaskLink();
            log.Info("Click the Delete This Task link.");
            Thread.Sleep(2000);

            //Click the Delete Task Window Yes Button
            tasksPage.PressDeleteTaskWindowYesBtn();
            log.Info("Click the Delete Task Window Yes Button.");
            Thread.Sleep(2000);
        }

        [Test]
        public void Messages_001_VerifyMessagesOption()
        {
            Global.MethodName = "Messages_001_VerifyMessagesOption";

            Thread.Sleep(2000);
            messagesPage.VerifyMessagessMenuOption();
            log.Info("Verify Messages icon");
        }

        [Test]
        public void Messages_002_VerifyMessagesPage()
        {
            Global.MethodName = "Messages_002_VerifyMessagesPage";

            //Click Messages menu icon
            messagesPage.ClickMessagesMenu();
            log.Info("Click Messages menu icon.");
            Thread.Sleep(3000);

            //Verify Messages Page gets displayed
            messagesPage.VerifyMessagessPage();
            log.Info("Verify Messages Page gets displayed.");
            Thread.Sleep(1000);            
        }

        [Test]
        public void Messages_003_VerifyMessagesPageDisplay()
        {
            Global.MethodName = "Messages_003_VerifyMessagesPageDisplay";

            //Click Messages menu icon
            messagesPage.ClickMessagesMenu();
            log.Info("Click Messages menu icon.");
            Thread.Sleep(3000);

            //Verify All Messages drop-down is displayed
            messagesPage.VerifyAllMessagesDropDown();
            log.Info("Verify All Messages drop-down is displayed.");
            Thread.Sleep(1000);

            //Verify New Message Btn is displayed
            messagesPage.VerifyNewMessageBtn();
            log.Info("Verify New Message Btn is displayed.");
        }

        [Test]
        public void Messages_004_VerifyNewMessageWindow()
        {
            Global.MethodName = "Messages_004_VerifyNewMessageWindow";

            //Click Messages menu icon
            messagesPage.ClickMessagesMenu();
            log.Info("Click Messages menu icon.");
            Thread.Sleep(3000);

            //Click New Message button
            messagesPage.ClickNewMessageBtn();
            log.Info("Click New Message button.");
            Thread.Sleep(3000);

            //Verify New Message Window is displayed
            messagesPage.VerifyNewMessageWindow();
            log.Info("Verify New Message Window is displayed.");
            Thread.Sleep(1000);

            //Verify To label is displayed
            messagesPage.VerifyToLabel();
            log.Info("Verify To label is displayed.");
            Thread.Sleep(1000);

            //Verify To text input is displayed
            messagesPage.VerifyToTextInput();
            log.Info("Verify To text input is displayed.");
            Thread.Sleep(1000);

            //Verify Text Area is displayed
            messagesPage.VerifyTextArea();
            log.Info("Verify Text Area is displayed.");
            Thread.Sleep(1000);

            //Verify Send button is displayed
            messagesPage.VerifySendBtn();
            log.Info("Verify Send button is displayed.");
            Thread.Sleep(1000);

            //Verify attachment icon is displayed
            messagesPage.VerifyTextArea();
            log.Info("Verify attachment icon is displayed.");
            Thread.Sleep(1000);

            //Verify close icon is displayed
            messagesPage.VerifyTextArea();
            log.Info("Verify close icon is displayed.");            
        }

        [Test]
        public void Messages_005_SendNewMessageAndVerify()
        {
            Global.MethodName = "Messages_005_SendNewMessageAndVerify";

            //Click Messages menu icon
            messagesPage.ClickMessagesMenu();
            log.Info("Click Messages menu icon.");
            Thread.Sleep(3000);

            //Click New Message button
            messagesPage.ClickNewMessageBtn();
            log.Info("Click New Message button.");
            Thread.Sleep(3000);

            //Enter To text input
            String userEmail = readMessages.GetValue("Messages", "userEmail");                       
            messagesPage.EnterToTextInput(userEmail);
            log.Info("Enter the user email.");
            Thread.Sleep(2000);

            //Press enter key
            messagesPage.PressEnterKey();
            Thread.Sleep(2000);

            //Enter message in the text area
            String message = readMessages.GetValue("Messages", "message");
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(4));
            message = message + builder;
            messagesPage.EnterTextArea(message);
            log.Info("Enter the message.");
            Thread.Sleep(2000);

            //Click Send button
            messagesPage.ClickSendBtn();
            log.Info("Click Send button.");
            Thread.Sleep(1000);

            //Verify message is successfully posted
            messagesPage.VerifyTextArea();
            log.Info("Verify attachment icon is displayed.");
            Thread.Sleep(1000);

            //Verify close icon is displayed
            messagesPage.VerifyNewMessagePosted(message);
            log.Info("Verify message is successfully posted.");
        }




















    }
}