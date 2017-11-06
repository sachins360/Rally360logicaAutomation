using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RallyTeam.UILocators
{
    public static class MessagessUI
    {
        public readonly static By messagesPage = By.XPath("//div[contains(@class, 'rt-sub-navbar__nav-title') and text()='Messages']");
        public readonly static By allMessagesDropDown = By.XPath("//h2[@class= 'ng-binding' and text()='All Messages ']");
        public static By allMessagesOptions(String variable)
        {
            return By.XPath("//ul[@class ='dropdown-menu']//a[text()= '"+variable+"']");
        }
        public readonly static By newMessageBtn = By.XPath("//button[contains(text(), 'New Message')]");

        /*New Message Window*/
        public readonly static By newMessageWindow = By.XPath("//div[@class= 'modal-content']//div[contains(@class, 'rt-modal__title') and contains(text(), 'New Message')]");
        public readonly static By toLabel = By.XPath("//div[@class= 'modal-content']//label[text()= 'To:']");
        public readonly static By toTextInput = By.XPath("//div[@class= 'modal-content']//input[@placeholder= 'Add user']");
        public readonly static By textArea = By.XPath("//div[@class= 'modal-content']//textarea[@name= 'body']");
        public readonly static By sendButton = By.XPath("//div[@class= 'modal-content']//button[contains(@class, 'btn-sm')]//strong[text()= 'Send']");
        public readonly static By attachmentIcon = By.XPath("//div[@class= 'modal-content']//i[@class= 'fa fa-paperclip']");
        public readonly static By closeIcon = By.XPath("//div[@class= 'modal-content']//i[@class= 'fa fa-times']");

        public static By messagePosted(String variable)
        {
            return By.XPath("//div[contains(text(), '" + variable + "')]");
        }



    }
}
