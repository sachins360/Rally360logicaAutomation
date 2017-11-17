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
    public class DirectMessagingPage : BasePage
    {
        CommonMethods commonPage;

        public DirectMessagingPage(IWebDriver driver, int pageLoadTimeout)
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
            _assertHelper.AssertElementDisplayed(DirectMessagingUI.messagesPage);
        }

        //Assert All Messages drop-down displayed
        public void VerifyAllMessagesDropDown()
        {
            _assertHelper.AssertElementDisplayed(DirectMessagingUI.allMessagesDropDown);
        }

        //Assert New Message button displayed
        public void VerifyNewMessageBtn()
        {
            _assertHelper.AssertElementDisplayed(DirectMessagingUI.newMessageBtn);
        }
        
        //Click New Message button
        public void ClickNewMessageBtn()
        {
            _driver.SafeClick(DirectMessagingUI.newMessageBtn);
        }
                
        //Assert New Message Window displayed
        public void VerifyNewMessageWindow()
        {
            _assertHelper.AssertElementDisplayed(DirectMessagingUI.newMessageWindow);
        }

        //Assert New Message Window doesn't displayed
        public void VerifyNewMessageWindowDoesntDisplayed()
        {
            _assertHelper.AssertElementNotDisplayed(DirectMessagingUI.newMessageWindowIcon);
        }

        //Assert New Message Window To Label displayed
        public void VerifyToLabel()
        {
            _assertHelper.AssertElementDisplayed(DirectMessagingUI.toLabel);
        }

        //Assert New Message Window Text Input displayed
        public void VerifyToTextInput()
        {
            _assertHelper.AssertElementDisplayed(DirectMessagingUI.toTextInput);
        }

        //Enter New Message Window Text Input
        public void EnterToTextInput(string userEmail)
        {
            _driver.SafeEnterText(DirectMessagingUI.toTextInput, userEmail);
        }

        //Assert New Message Window Text Area displayed
        public void VerifyTextArea()
        {
            _assertHelper.AssertElementDisplayed(DirectMessagingUI.textArea);
        }

        //Enter New Message Window Text Area
        public void EnterTextArea(string message)
        {
            _driver.SafeEnterText(DirectMessagingUI.textArea, message);
        }

        //Assert New Message Window Send Button displayed
        public void VerifySendBtn()
        {
            _assertHelper.AssertElementDisplayed(DirectMessagingUI.sendButton);
        }

        //Click New Message Window Send Button
        public void ClickSendBtn()
        {
            _driver.SafeClick(DirectMessagingUI.sendButton);
        }

        //Assert New Message Window Attachment icon displayed
        public void VerifyAttachmentIcon()
        {
            _assertHelper.AssertElementDisplayed(DirectMessagingUI.attachmentIcon);
        }

        //Assert New Message Window Close Icon displayed
        public void VerifyNewMessageWindowCloseIcon()
        {
            _assertHelper.AssertElementDisplayed(DirectMessagingUI.closeIcon);
        }

        //Assert New Message is successfully posted
        public void VerifyNewMessagePosted(String message)
        {
            _assertHelper.AssertElementDisplayed(DirectMessagingUI.messagePosted(message));
        }         

        //Click the message received
        public void ClickMessageReceived(String message)
        {
            _driver.SafeClick(DirectMessagingUI.messageDisplayed(message));
        }

        //Enter Reply Message Window Text Area
        public void EnterReplyTextArea(string message)
        {
            _driver.SafeEnterText(DirectMessagingUI.replyTextArea, message);
        }

        //Click Reply Message Window Send Button
        public void ClickReplySendBtn()
        {
            _driver.CheckElementVisibility(DirectMessagingUI.replySendButton);
            _driver.CheckElementClickable(DirectMessagingUI.replySendButton);
            _driver.SafeClick(DirectMessagingUI.replySendButton);
        }

        //Get the Message Counter Value
        public String GetMessageCounterValue()
        {
            return _driver.GetElementText(DashboardUI.messageCounter);
        }

        //Verify the Increased Message Counter Value
        public void VerifyIncreasedMessageCounterValue(string counter)
        {
            _assertHelper.AssertElementDisplayed(DashboardUI.increasedMessageCounter(counter));
        }

        //Click the Messages back icon
        public void ClickBackIcon()
        {
            _driver.SafeClick(DirectMessagingUI.messageBackIcon);
        }

        //Assert Send Announcement button displayed
        public void VerifySendAnnouncementBtn()
        {
            _assertHelper.AssertElementDisplayed(DirectMessagingUI.sendAnnouncementBtn);
        }

        //Assert Send Announcement button not displayed
        public void VerifySendAnnouncementBtnNotDisplayed()
        {
            _assertHelper.AssertElementNotDisplayed(DirectMessagingUI.sendAnnouncementBtn);
        }

        //Click Send Announcement button
        public void ClickSendAnnouncementBtn()
        {
            _driver.SafeClick(DirectMessagingUI.sendAnnouncementBtn);
        }



        //Assert Send Announcement Window displayed
        public void VerifySendAnnouncementWindow()
        {
            _assertHelper.AssertElementDisplayed(DirectMessagingUI.sendAnnouncementWindow);
        }

        //Assert Send Announcement Window Group drop-down displayed
        public void VerifyGroupDropDown()
        {
            _assertHelper.AssertElementDisplayed(DirectMessagingUI.groupDropDown);
        }

        //Select Send Announcement Window Group drop-down
        public void SelectGroup(String group)
        {
            _driver.SelectDropDownOption(group, DirectMessagingUI.groupDropDown);
        }

        //Assert New Announcement is successfully posted
        public void VerifyAnnouncementPosted(String announcement)
        {
            _assertHelper.AssertElementDisplayed(DirectMessagingUI.messagePosted(announcement));
        }

        //Assert Announcement Received Modal
        public void VerifyAnnouncementModal()
        {
            _assertHelper.AssertElementDisplayed(DirectMessagingUI.announcementModal);
        }

        //Assert Announcement Received Header
        public void VerifyAnnouncementHeader(String userName)
        {
            _assertHelper.AssertElementDisplayed(DirectMessagingUI.annoucementHeader(userName));
        }

        //Assert Announcement Received Text
        public void VerifyAnnouncementText(String annoucement)
        {
            _assertHelper.AssertElementDisplayed(DirectMessagingUI.annoucementDisplayed(annoucement));
        }

        //Assert Announcement Not Received Text
        public void VerifyAnnouncementNoText(String annoucement)
        {
            _assertHelper.AssertElementNotDisplayed(DirectMessagingUI.annoucementDisplayed(annoucement));
        }

        //Assert Announcement Received Modal Close button
        public void VerifyAnnouncementCloseBtn()
        {
            _assertHelper.AssertElementDisplayed(DirectMessagingUI.closeButton);
        }

        //Assert Announcement Received Modal Contact Sender
        public void VerifyAnnouncementContactSender()
        {
            _assertHelper.AssertElementDisplayed(DirectMessagingUI.contactSender);
        }

        //Assert Announcement Received Modal Close Icon
        public void VerifyAnnouncementCloseIcon()
        {
            _assertHelper.AssertElementDisplayed(DirectMessagingUI.closeAnnoucementIcon);
        }

        //Click Announcement Received Modal Close button
        public void ClickAnnouncementCloseBtn()
        {
            _driver.SafeClick(DirectMessagingUI.closeButton);
        }

        //Click Announcement Received Modal Contact Sender
        public void ClickAnnouncementContactSender()
        {
            _driver.SafeClick(DirectMessagingUI.contactSender);
        }

        //Assert Reply Announcement Text Area not displayed
        public void VerifyReplyTextAreaNotDisplayed()
        {
            _assertHelper.AssertElementNotDisplayed(DirectMessagingUI.replyTextArea);
        }

    }
}
