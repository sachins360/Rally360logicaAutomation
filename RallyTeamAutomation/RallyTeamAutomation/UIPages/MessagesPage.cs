using OpenQA.Selenium;
using RallyTeam.Util;
using RallyTeam.UILocators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Interactions;
using System.Collections;

namespace RallyTeam.UIPages
{
    public class MessagesPage : BasePage
    {
        CommonMethods commonPage;

        public MessagesPage(IWebDriver driver, int pageLoadTimeout)
            : base(driver, pageLoadTimeout)
        {
            commonPage = new CommonMethods(_driver, pageLoadTimeout);
        }

        //Press Enter Key
        public void PressEnterKey()
        {
            _driver.PressKeyBoardEnter();
        }

        //Press Tab Key
        public void PressTabKey()
        {
            _driver.PressKeyBoardTab();
        }

        //Assert Messages option
        public void VerifyMessagessMenuOption()
        {
            _assertHelper.AssertElementDisplayed(DashboardUI.messageIcon);
        }        

        //Click on Messages icon
        public void ClickMessagesMenu()
        {
            _driver.WaitForElementAvailableAtDOM(DashboardUI.messageIcon, 1);
            _driver.SafeClick(DashboardUI.messageIcon);
        }

        //Assert Messages Page
        public void VerifyMessagessPage()
        {
            _assertHelper.AssertElementDisplayed(MessagessUI.messagesPage);
        }

        //Assert All Messages drop-down displayed
        public void VerifyAllMessagesDropDown()
        {
            _assertHelper.AssertElementDisplayed(MessagessUI.allMessagesDropDown);
        }

        //Assert New Message button displayed
        public void VerifyNewMessageBtn()
        {
            _assertHelper.AssertElementDisplayed(MessagessUI.newMessageBtn);
        }

        //Click New Message button displayed
        public void ClickNewMessageBtn()
        {
            _driver.SafeClick(MessagessUI.newMessageBtn);
        }

        //Assert New Message Window displayed
        public void VerifyNewMessageWindow()
        {
            _assertHelper.AssertElementDisplayed(MessagessUI.newMessageWindow);
        }

        //Assert New Message Window To Label displayed
        public void VerifyToLabel()
        {
            _assertHelper.AssertElementDisplayed(MessagessUI.toLabel);
        }

        //Assert New Message Window Text Input displayed
        public void VerifyToTextInput()
        {
            _assertHelper.AssertElementDisplayed(MessagessUI.toTextInput);
        }

        //Enter New Message Window Text Input
        public void EnterToTextInput(string userEmail)
        {
            _driver.SafeEnterText(MessagessUI.toTextInput, userEmail);
        }

        //Assert New Message Window Text Area displayed
        public void VerifyTextArea()
        {
            _assertHelper.AssertElementDisplayed(MessagessUI.textArea);
        }

        //Enter New Message Window Text Area
        public void EnterTextArea(string message)
        {
            _driver.SafeEnterText(MessagessUI.toTextInput, message);
        }

        //Assert New Message Window Send Button displayed
        public void VerifySendBtn()
        {
            _assertHelper.AssertElementDisplayed(MessagessUI.sendButton);
        }

        //Assert New Message Window Send Button displayed
        public void ClickSendBtn()
        {
            _driver.SafeClick(MessagessUI.sendButton);
        }

        //Assert New Message Window Attachment icon displayed
        public void VerifyAttachmentIcon()
        {
            _assertHelper.AssertElementDisplayed(MessagessUI.attachmentIcon);
        }

        //Assert New Message Window Close Icon displayed
        public void VerifyNewMessageWindowCloseIcon()
        {
            _assertHelper.AssertElementDisplayed(MessagessUI.closeIcon);
        }

        //Assert New Message is successfully posted
        public void VerifyNewMessagePosted(String message)
        {
            _assertHelper.AssertElementDisplayed(MessagessUI.messagePosted(message));
        }



















    }
}
