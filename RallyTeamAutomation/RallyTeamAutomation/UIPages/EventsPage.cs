using OpenQA.Selenium;
using RallyTeam.Util;
using RallyTeam.UILocators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Interactions;

namespace RallyTeam.UIPages
{
    public class EventsPage : BasePage
    {
        CommonMethods commonPage;

        public EventsPage(IWebDriver driver, int pageLoadTimeout)
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

        //Verify Events menu option
        public void VerifyEventsMenuOption()
        {
            _assertHelper.AssertElementDisplayed(DashboardUI.sideNavBar("Events"));
        }

        //Click on Events menu option
        public void ClickEventsMenu()
        {
            _driver.WaitForElementAvailableAtDOM(DashboardUI.sideNavBar("Events"), 1);
            _driver.ClickElementUsingAction(DashboardUI.sideNavBar("Events"));
        }

        //Press on Event's About tab
        public void ClickEventsAboutTab()
        {
            _driver.WaitForElementAvailableAtDOM(EventsUI.aboutTab, 1);
            _driver.SafeClick(EventsUI.aboutTab);
        }

        //Click the All Events Dropdown
        public void ClickAllEventsDropDown()
        {
            _driver.WaitForElementAvailableAtDOM(EventsUI.allEventsDrpdwnLink, 1);
            _driver.SafeClick(EventsUI.allEventsDrpdwnLink);
        }

        //Assert the All Events Dropdown option
        public void VerifyAllEventsDropDownOption()
        {
            _driver.WaitForElementAvailableAtDOM(EventsUI.allEventsOption, 1);
            _assertHelper.AssertElementTextContains(EventsUI.allEventsOption, "All Events");
        }

        //Assert the My Events Dropdown option
        public void VerifyMyEventsDropDownOption()
        {
            _driver.WaitForElementAvailableAtDOM(EventsUI.myEventsOption, 1);
            _assertHelper.AssertElementTextContains(EventsUI.myEventsOption, "My Events");
        }

        //Click the My Events Dropdown option
        public void ClickMyEventsDropDownOption()
        {
            _driver.WaitForElementAvailableAtDOM(EventsUI.myEventsOption, 1);
            _driver.SafeClick(EventsUI.myEventsOption);
        }

        //Click Event on Events Page
        public void ClickEventOnEventPage(String eventName)
        {
            _driver.WaitForElementAvailableAtDOM(EventsUI.eventNameOnEventPage(eventName), 1);
            _driver.SafeClick(EventsUI.eventNameOnEventPage(eventName));
        }

        //Verify Event on Events Page
        public void VerifyEventNotDisplayedOnEventPage(String eventName)
        {
            _assertHelper.AssertElementNotDisplayed(EventsUI.eventNameOnEventPage(eventName));
        }

        //Click on 'New Event' button
        public void ClickOnNewEventButton()
        {
            _driver.WaitForElementAvailableAtDOM(EventsUI.newEventBtn, 1);
            _driver.SafeClick(EventsUI.newEventBtn);
        }

        //Assert the Create New Event Page
        public void VerifyCreateNewEventPage()
        {
            _driver.WaitForElementAvailableAtDOM(EventsUI.createEventPage, 1);
            _assertHelper.AssertElementDisplayed(EventsUI.createEventPage);
        }

        //Assert the Error Message
        public void VerifyErrorMessage()
        {
            _driver.WaitForElementAvailableAtDOM(EventsUI.errorMessage, 1);
            _assertHelper.AssertElementDisplayed(EventsUI.errorMessage);
        }

        //Enter Event Name
        public void EnterEventName(String eventName)
        {
            _driver.WaitForElementAvailableAtDOM(EventsUI.eventName, 1);
            _driver.SafeEnterText(EventsUI.eventName, eventName);
        }

        //Enter Event Description
        public void EnterEventDescription(String eventDescription)
        {
            _driver.WaitForElementAvailableAtDOM(EventsUI.eventDescription, 1);
            _driver.SafeEnterText(EventsUI.eventDescription, eventDescription);
        }

        //Enter Event Location
        public void EnterEventLocation(String eventLocation)
        {
            _driver.WaitForElementAvailableAtDOM(EventsUI.eventLocation, 1);
            _driver.SafeEnterText(EventsUI.eventLocation, eventLocation);
        }

        //Select Event Host
        public void SelectEventHost(String eventHost)
        {
            _driver.WaitForElementAvailableAtDOM(EventsUI.eventHost, 1);
            _driver.SafeSelectDropDownText(EventsUI.eventHost, eventHost);
        }

        //Select Event Group
        public void SelectEventGroup(String eventGroup)
        {
            _driver.WaitForElementAvailableAtDOM(EventsUI.eventGroup, 1);
            _driver.SafeSelectDropDownText(EventsUI.eventGroup, eventGroup);
        }

        //Assert Visibility Public Radio Option
        public void VerifyVisibilityPublic()
        {
            _assertHelper.AssertElementDisplayed(EventsUI.visibilityPublic);
        }        

        //Assert Visibility Private Radio Option
        public void VerifyVisibilityPrivate()
        {
            _assertHelper.AssertElementDisplayed(EventsUI.visibilityPrivate);
        }

        //Select Visibility
        public void selectVisibility(String radioOption)
        {
            if (radioOption.Equals("Public"))
            {
                _driver.WaitForElementAvailableAtDOM(EventsUI.visibilityPublic, 1);
                _driver.SafeClick(EventsUI.visibilityPublic);
            }
            if (radioOption.Equals("Private"))
            {
                _driver.WaitForElementAvailableAtDOM(EventsUI.visibilityPrivate, 1);
                _driver.SafeClick(EventsUI.visibilityPrivate);
            }
        }

        //Enter Event Additonal Details
        public void EnterEventAdditionalDetails(String eventAdditionalDetails)
        {
            _driver.WaitForElementAvailableAtDOM(EventsUI.additionalDetails, 1);
            _driver.SafeEnterText(EventsUI.additionalDetails, eventAdditionalDetails);
        }

        //Click Create button
        public void ClickOnCreateEventBtn()
        {
            _driver.WaitForElementAvailableAtDOM(EventsUI.createBtn, 1);
            _driver.SafeClick(EventsUI.createBtn);
        }

        //Click Settings option
        public void ClickSettingsOption()
        {
            _driver.WaitForElementAvailableAtDOM(EventsUI.settings, 1);
            _driver.SafeClick(EventsUI.settings);
        }

        //Assert Settings drop-down values
        public void GetSettingsOptionsValues(String optionValue)
        {
            _driver.WaitForElementAvailableAtDOM(GroupsUI.settingsOptions(optionValue), 1);
            _assertHelper.AssertElementDisplayed(GroupsUI.settingsOptions(optionValue));
        }

        //Click Settings drop-down values
        public void ClickSettingsOptionsValues(String optionValue)
        {
            _driver.WaitForElementAvailableAtDOM(EventsUI.settingsOptions(optionValue), 1);
            _driver.SafeClick(EventsUI.settingsOptions(optionValue));
        }

        //Assert the About Tab displayed
        public void VerifyAboutTab()
        {
            _assertHelper.AssertElementDisplayed(EventsUI.aboutTab);
        }

        //Assert the Discussions Tab displayed
        public void VerifyDiscussionsTab()
        {
            _assertHelper.AssertElementDisplayed(EventsUI.discussionsTab);
        }

        //Assert the Projects Tab displayed
        public void VerifyProjectsTab()
        {
            _assertHelper.AssertElementDisplayed(EventsUI.projectsTab);
        }

        //Assert the Files Tab displayed
        public void VerifyFilesTab()
        {
            _assertHelper.AssertElementDisplayed(EventsUI.filesTab);
        }

        //Assert Private Label for Private Event
        public void VerifyPrivateLabel()
        {
            _assertHelper.AssertElementDisplayed(EventsUI.privateLabel);
        }

        //Assert Event Name on Dashboard
        public void VerifyEventNameDashboard(String eventName)
        {
            _assertHelper.AssertElementDisplayed(EventsUI.eventNameDashboard(eventName));
        }

        //Assert Event Description on Dashboard
        public void VerifyEventDescDashboard(String eventDesc)
        {
            _assertHelper.AssertElementDisplayed(EventsUI.eventDescDashboard(eventDesc));
        }

        //Assert Joined on Dashboard
        public void VerifyJoinedBtnDashboard()
        {
            _assertHelper.AssertElementDisplayed(EventsUI.joinedBtnDashboard);
        }

        //Assert Join Button on Dashboard
        public void VerifyJoinBtnDashboard()
        {
            _assertHelper.AssertElementDisplayed(EventsUI.joinBtnDashboard);
        }

        //Press Join Button on Dashboard
        public void ClickJoinBtnDashboard()
        {
            _driver.SafeClick(EventsUI.joinBtnDashboard);
        }

        //Assert the Edit Event Window
        public void AssertEditEventDialog()
        {
            _driver.WaitForElementAvailableAtDOM(EventsUI.editEventWindow, 1);
            _assertHelper.AssertElementDisplayed(EventsUI.editEventWindow);
        }

        //Press Edit Event Window Save Button
        public void ClickEditEventWindowSaveBtn()
        {
            _driver.SafeClick(EventsUI.editEventSaveBtn);
        }

        //Press Edit Event Window Cancel Button
        public void ClickEditEventWindowCancelBtn()
        {
            _driver.SafeClick(EventsUI.editEventCancelBtn);
        }

        //Assert Leave Event Window on click of Leave Event button from Settings Option
        public void VerifyLeaveEventWindow()
        {
            _driver.WaitForElementAvailableAtDOM(EventsUI.leaveEventWindow, 1);
            _assertHelper.AssertElementDisplayed(EventsUI.leaveEventWindow);
        }

        //Assert Leave Group Window No Btn on click of Delete Group button from Settings Option
        public void VerifyLeaveGroupWindowNoBtn()
        {
            _driver.WaitForElementAvailableAtDOM(EventsUI.leaveEventWindowNoBtn, 1);
            _assertHelper.AssertElementDisplayed(EventsUI.leaveEventWindowNoBtn);
        }

        //Assert Leave Group Window Yes Btn on click of Delete Group button from Settings Option
        public void VerifyLeaveGroupWindowYesBtn()
        {
            _driver.WaitForElementAvailableAtDOM(EventsUI.leaveEventWindowYesBtn, 1);
            _assertHelper.AssertElementDisplayed(EventsUI.leaveEventWindowYesBtn);
        }

        //Press No Button from the Leave Group Window
        public void PressLeaveGroupWindowNoBtn()
        {
            _driver.SafeClick(EventsUI.leaveEventWindowNoBtn);
        }        

        //Press Yes Button from the Leave Group Window
        public void PressLeaveEventWindowYesBtn()
        {
            _driver.SafeClick(EventsUI.leaveEventWindowYesBtn);
        }

        //Press Leave Event Window Close Icon
        public void PressLeaveEventWindowCloseIcon()
        {
            _driver.SafeClick(EventsUI.leaveEventWindowCloseIcon);
        }

        //Assert the Add Event Member Window
        public void AssertAddEventMemberDialog()
        {
            _driver.WaitForElementAvailableAtDOM(EventsUI.addMemberWindow, 1);
            _assertHelper.AssertElementDisplayed(EventsUI.addMemberWindow);
        }

        //Enter Event Member Name
        public void EnterEventMember(String member)
        {
            _driver.WaitForElementAvailableAtDOM(EventsUI.addMemberText, 1);
            _driver.SafeEnterText(EventsUI.addMemberText, member);
        }

        //Select user from suggestion list
        public void SelectUserfromSuggestion(String SuggItem)
        {
            _driver.WaitForElementAvailableAtDOM(EventsUI.addMemberSuggList(SuggItem), 1);
            _driver.SafeClick(EventsUI.addMemberSuggList(SuggItem));
        }

        //Assert user from suggestion list not displayed
        public void VerifyUserfromSuggestionNotDisplayed(String SuggItem)
        {
            _assertHelper.AssertElementNotDisplayed(EventsUI.addMemberSuggList(SuggItem));
        }

        //Click on Add Event Member Button
        public void ClickAddWindowAddButton()
        {
            _driver.SafeClick(EventsUI.addWindowAddButton);
        }

        //Verify the Added Event Member confirmation message
        public void VerifyAddedMemberConfMsg()
        {
            _driver.WaitForElementAvailableAtDOM(EventsUI.addMemberConfirmationMsg, 1);
            _assertHelper.AssertElementDisplayed(EventsUI.addMemberConfirmationMsg);
        }

        //Press Add Member Window Close Icon
        public void ClickAddWindMemberWindowCloseIcon()
        {
            _driver.SafeClick(GroupsUI.addMemberWindowCloseIcon);
        }

        //Assert Delete Event Window on click of Delete Event button from Settings Option
        public void VerifyDeleteEventWindow()
        {
            _driver.WaitForElementAvailableAtDOM(EventsUI.deleteEventWindow, 1);
            _assertHelper.AssertElementDisplayed(EventsUI.deleteEventWindow);
        }

        //Assert Delete Group Window No Btn on click of Delete Group button from Settings Option
        public void VerifyDeleteGroupWindowNoBtn()
        {
            _driver.WaitForElementAvailableAtDOM(EventsUI.deleteEventWindowNoBtn, 1);
            _assertHelper.AssertElementDisplayed(EventsUI.deleteEventWindowNoBtn);
        }

        //Assert Delete Group Window Yes Btn on click of Delete Group button from Settings Option
        public void VerifyDeleteGroupWindowYesBtn()
        {
            _driver.WaitForElementAvailableAtDOM(EventsUI.deleteEventWindowYesBtn, 1);
            _assertHelper.AssertElementDisplayed(EventsUI.deleteEventWindowYesBtn);
        }

        //Press No Button from the Delete Event Window
        public void PressDeleteEventWindowNoBtn()
        {
            _driver.SafeClick(EventsUI.deleteEventWindowNoBtn);
        }

        //Press Yes Button from the Delete Event Window
        public void PressDeleteEventWindowYesBtn()
        {
            _driver.SafeClick(EventsUI.deleteEventWindowYesBtn);
        }

        //Press Delete Event Window Close Icon
        public void PressDeleteEventWindowCloseIcon()
        {
            _driver.SafeClick(EventsUI.deleteEventWindowCloseIcon);
        }

        //Press on Event's Discussion tab
        public void ClickEventsDiscussionTab()
        {
            _driver.WaitForElementAvailableAtDOM(EventsUI.discussionsTab, 1);
            _driver.SafeClick(EventsUI.discussionsTab);
        }

        //Assert the Discussions tab Window
        public void VerifyDiscussionsTabWindow()
        {
            _driver.WaitForElementAvailableAtDOM(EventsUI.discussionWindow, 1);
            _assertHelper.AssertElementDisplayed(EventsUI.discussionWindow);
        }

        //Click the Message in the Text Area
        public void ClickMessageTextArea()
        {
            _driver.WaitForElementAvailableAtDOM(EventsUI.discussionTypeMessageArea, 1);
            _driver.SafeClick(EventsUI.discussionTypeMessageArea);
        }

        //Enter the Message in the Text Area
        public void EnterMessageTextArea(String message)
        {
            _driver.WaitForElementAvailableAtDOM(EventsUI.discussionTypeMessageArea, 1);
            _driver.SafeEnterText(EventsUI.discussionTypeMessageArea, message);
        }

        //Press the Message Post button
        public void ClickMessagePostBtn()
        {
            _driver.WaitForElementAvailableAtDOM(EventsUI.discussionPostBtn, 1);
            _driver.SafeClick(EventsUI.discussionPostBtn);
        }

        //Assert the Discussions tab Message Reply button
        public void VerifyDiscussionMsgReplyBtn()
        {
            _driver.WaitForElementAvailableAtDOM(EventsUI.discussionReplyBtn, 1);
            _assertHelper.AssertElementDisplayed(EventsUI.discussionReplyBtn);
        }

        //Press the Discussion Attachment Icon
        public void ClickDiscussionAttachIcon()
        {
            _driver.WaitForElementAvailableAtDOM(EventsUI.discussionAttachIcon, 1);
            _driver.SafeClick(EventsUI.discussionAttachIcon);
        }

        //Press the Message Reply button
        public void ClickMessageReplyBtn()
        {
            _driver.WaitForElementAvailableAtDOM(EventsUI.discussionReplyBtn, 1);
            _driver.SafeClick(EventsUI.discussionReplyBtn);
        }

        //Enter the Message in the Reply Text Area
        public void EnterMessageReplyTextArea(String message)
        {
            _driver.WaitForElementAvailableAtDOM(EventsUI.discussionReplyText, 1);
            _driver.SafeEnterText(EventsUI.discussionReplyText, message);
        }

        //Press on Group's Projects tab
        public void ClickGroupProjectTab()
        {
            _driver.WaitForElementAvailableAtDOM(EventsUI.projectsTab, 1);
            _driver.SafeClick(EventsUI.projectsTab);
        }





    }
}
