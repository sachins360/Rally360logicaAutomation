using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RallyTeam.UILocators
{
    public static class DirectMessagingUI
    {
        public readonly static By messagesPage = By.XPath("//div[contains(@class, 'rt-sub-navbar__nav-title') and text()='Messages']");
        public readonly static By allMessagesDropDown = By.XPath("//h2[@class= 'ng-binding' and text()='All Messages ']");
        public static By allMessagesOptions(String variable)
        {
            return By.XPath("//ul[@class ='dropdown-menu']//a[text()= '"+variable+"']");
        }
        public readonly static By newMessageBtn = By.XPath("//button[contains(text(), 'New Message')]");
        public readonly static By sendAnnouncementBtn = By.XPath("//button[contains(text(), 'Send Announcement')]");

        /*New Message Window*/
        public readonly static By newMessageWindow = By.XPath("//div[@class= 'modal-content']//div[contains(@class, 'rt-round-modal__header') and contains(text(), 'New Message')]");
        public readonly static By toLabel = By.XPath("//div[@class= 'modal-content']//label[text()= 'To:']");
        public readonly static By toTextInput = By.XPath("//div[@class= 'modal-content']//input[@placeholder= 'Add user']");
        public readonly static By textArea = By.XPath("//textarea[@name= 'body']");
        public readonly static By sendButton = By.XPath("//div[@class= 'modal-content']//button[contains(@class, 'rt-btn--primary')]//strong[text()= 'Send']");
        public readonly static By attachmentIcon = By.XPath("//div[@class= 'modal-content']//i[@class= 'fa fa-paperclip']");
        public readonly static By closeIcon = By.XPath("//div[@class= 'modal-content']//i[@class= 'fa fa-times']");

        /*Send Announcement Window*/
        public readonly static By sendAnnouncementWindow = By.XPath("//div[@class= 'modal-content']//div[contains(@class, 'rt-round-modal__header') and contains(text(), 'Send Announcement')]");
        public readonly static By groupDropDown = By.XPath("//div[@class= 'modal-content']//select[contains(@class, 'rt-select--thin')]");

        public static By messagePosted(String variable)
        {
            return By.XPath("//div[contains(text(), '" + variable + "')]");
        }

        public static By messageDisplayed(String variable)
        {
            return By.XPath("//div[contains(text(), '" + variable + "')]");
        }
        public readonly static By replyTextArea = By.XPath("//form[@name= 'messagePostForm']//textarea[@name= 'body']");
        public readonly static By replySendButton = By.XPath("//form[@name= 'messagePostForm']//button[contains(@class, 'btn-sm')]//strong[text()= 'Send']");
        public readonly static By messageBackIcon = By.XPath("//i[contains(@class, 'fa-arrow-left')]");

        /*Announcement Received Modal*/
        public readonly static By announcementModal = By.XPath("//div[@class= 'modal-content']//div[contains(@class, 'rt-round-modal__header') and contains(text(), 'Announcement')]");
        public static By annoucementHeader(String variable)
        {
            return By.XPath("//div[@class= 'modal-content']//div[contains(text(), 'There is a new message from "+variable+"')]");
        }
        public static By annoucementDisplayed(String variable)
        {
            return By.XPath("//div[contains(text(), '" + variable + "')]");
        }
        public readonly static By closeButton = By.XPath("//div[@class= 'modal-content']//button[contains(@class, 'rt-btn--primary')]//strong[text()= 'Close']");
        public readonly static By closeAnnoucementIcon = By.XPath("//div[@class= 'modal-content']//i[@class= 'fa fa-times']");
        public readonly static By contactSender = By.XPath("//div[@class= 'modal-content']//a[contains(text(), 'Contact')]");



    }
}
