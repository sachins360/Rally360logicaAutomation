using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RallyTeam.UILocators
{
    public static class EventsUI
    {
        public static By eventNameDashboard(string variable)
        {
            return By.XPath("//div[contains(text(), '" + variable + "')]");
        }

        public static By eventDescDashboard(string variable)
        {
            return By.XPath("//div[@class='col-md-12']//div[contains(text(), '" + variable + "')]");
        }

        public readonly static By joinedBtnDashboard = By.XPath("//button[contains(text(), 'Joined')]");
        public readonly static By joinBtnDashboard = By.XPath("//button[text()='Join']");
        public readonly static By newEventBtn = By.XPath("//*[contains(@class, 'title-action')]//span[contains(text(), 'New Event')]");
        public readonly static By createEventPage = By.XPath("//span[text()='Create an Event']");
        public readonly static By errorMessage = By.XPath("//span[text()='Please correct the errors in the form to continue.']");
        public readonly static By eventName = By.XPath("//*[contains(@class, 'form-control') and @name='abstract']");
        public readonly static By eventDescription = By.XPath("//*[contains(@class, 'form-control') and @name='description']");
        public readonly static By eventLocation = By.XPath("//*[contains(@class, 'form-control') and @name='location']");
        public readonly static By eventHost = By.XPath("//select[@name='moderator']");
        public readonly static By eventGroup = By.XPath("//select[@name='group']");
        public readonly static By visibilityPublic = By.XPath("//*[contains(@class, 'form-group')]//input[@id='inlineRadio1']");
        public readonly static By visibilityPrivate = By.XPath("//*[contains(@class, 'form-group')]//input[@id='inlineRadio2']");
        public readonly static By additionalDetails = By.XPath("//textarea[@name='description']");
        public readonly static By createBtn = By.XPath("//button[text()='Create']");
        public readonly static By allEventsDrpdwnLink = By.XPath("//a[@class='dropdown-toggle']//*[contains(text(), 'All Events')]");
        public static By allEventsOption = By.XPath("//ul[@class='dropdown-menu']/li[1]");
        public static By myEventsOption = By.XPath("//ul[@class='dropdown-menu']/li[2]");
        public static By eventNameOnEventPage(String variable)
        {
            return By.XPath("//a[contains(text(), '"+variable+"')]");
        }
        public readonly static By settings = By.XPath("//button[contains(@class, 'rt-settings-btn')]");
        public static By settingsOptions(string variable)
        {
            return By.XPath("//li[@class='ng-scope']//a[contains(text(), '" + variable + "')]");
        }
        public readonly static By privateLabel = By.XPath("//div[contains(@class, 'rt-event-about__title')]//span[text()='Private']");

        public readonly static By deleteEventWindow = By.XPath("//div[contains(@class, 'modal-dialog')]//h3[contains(text(),'Are you sure you want to delete this event?')]");
        public readonly static By deleteEventWindowNoBtn = By.XPath("//div[contains(@class, 'modal-dialog')]//a[contains(text(),'No')]");
        public readonly static By deleteEventWindowYesBtn = By.XPath("//div[contains(@class, 'modal-dialog')]//a[contains(text(),'Yes')]");
        public static By deleteGroupConfirmationMsg = By.XPath("//div[contains(@class, 'cg-notify-message')]//div[contains(text(), 'Group has been deleted.')]");
        public readonly static By deleteEventWindowCloseIcon = By.XPath("//div[contains(@class, 'modal-dialog')]//i[contains(@class,'fa fa-times')]");

        public readonly static By leaveEventWindow = By.XPath("//div[contains(@class, 'modal-dialog')]//h3[contains(text(),'Are you sure you want to leave this event?')]");
        public readonly static By leaveEventWindowNoBtn = By.XPath("//div[contains(@class, 'modal-dialog')]//a[contains(text(),'No')]");
        public readonly static By leaveEventWindowYesBtn = By.XPath("//div[contains(@class, 'modal-dialog')]//a[contains(text(),'Yes')]");
        public readonly static By leaveEventWindowCloseIcon = By.XPath("//div[contains(@class, 'modal-dialog')]//i[contains(@class,'fa fa-times')]");

        public readonly static By aboutTab = By.XPath("//ul[contains(@class, 'nav nav-tabs')]//a[contains(text(), 'About')]");
        public readonly static By discussionsTab = By.XPath("//ul[contains(@class, 'nav nav-tabs')]//a[contains(text(), 'Discussions')]");
        public readonly static By projectsTab = By.XPath("//ul[contains(@class, 'nav nav-tabs')]//a[contains(text(), 'Projects')]");
        public readonly static By filesTab = By.XPath("//ul[contains(@class, 'nav nav-tabs')]//a[contains(text(), 'Files')]");

        public readonly static By editEventWindow = By.XPath("//div[contains(@class, 'ng-scope')]//span[contains(text(), 'Edit this Event')]");
        public readonly static By editEventSaveBtn = By.XPath("//button[@value='Save']");
        public readonly static By editEventCancelBtn = By.XPath("//a[text()='Cancel']");

        public readonly static By addMemberWindow = By.XPath("//div[contains(@class, 'modal-dialog')]//div[contains(text(), 'Add Participants')]");
        public readonly static By addWindowAddButton = By.XPath("//div[contains(@class, 'modal-dialog')]//a[contains(text(), 'Add')]");
        public readonly static By addMemberText = By.XPath("//div[contains(@class, 'modal-dialog')]//input[contains(@class, 'input')]");
        public static By addMemberSuggList(string variable)
        {
            return By.XPath("//ul[contains(@class, 'suggestion-list')]//span[contains(text(), '" + variable + "')]");
        }
        public static By addMemberConfirmationMsg = By.XPath("//div[contains(@class, 'cg-notify-message')]//div[contains(text(), 'Thank you! Participants have been added.')]");
        public readonly static By addMemberWindowCloseIcon = By.XPath("//div[contains(@class, 'modal-dialog')]//i[contains(@class, 'fa fa-times')]");

        public readonly static By discussionWindow = By.XPath("//div[@class='discussion_wrapper']");
        public readonly static By discussionTypeMessageArea = By.XPath("//div[contains(@id, 'taTextElement')]");
        public readonly static By discussionPostBtn = By.XPath("//div[contains(@class, 'text-right')]//button[contains(@class, 'btn')]");
        public readonly static By discussionReplyBtn = By.XPath("//div[contains(@class, 'chat-activity-list')]//div[2]//a[contains(text(), 'Reply')]");
        public readonly static By discussionAttachIcon = By.XPath("//i[contains(@class, 'fa fa-paperclip')]");
        public readonly static By discussionReplyText = By.XPath("//form[contains(@class, 'ng-dirty')]//div[contains(@id, 'taTextElement')]");


    }
}
