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
    [Category("Events")]
    public class EventsTest : BaseTest
    {
        static ReadData readEvents = new ReadData("Events");

        //SignIn
        private void SignInDifferentUser()
        {
            String userName = readEvents.GetValue("SignInDifferentUser", "userName");
            String password = readEvents.GetValue("SignInDifferentUser", "password");
            authenticationPage.SetUserName(userName);
            authenticationPage.SetPassword(password);
            authenticationPage.ClickOnLoginButton();
        }

        //Create an Event
        public void CreateEvent(String eventName)
        {
            //Click Events menu option
            eventsPage.ClickEventsMenu();
            log.Info("Click the Events menu option.");
            Thread.Sleep(5000);

            //Click New Event button
            eventsPage.ClickOnNewEventButton();
            log.Info("Click on New Event button.");
            Thread.Sleep(3000);

            //Enter the Event Name
            eventsPage.EnterEventName(eventName);
            log.Info("Enter the Event Name.");
            Thread.Sleep(2000);

            //Enter the Event Description
            String eventDesc = readEvents.GetValue("AddEventDetails", "eventDesc");
            eventsPage.EnterEventDescription(eventDesc);
            log.Info("Enter the Event Description.");
            Thread.Sleep(2000);

            //Enter the Event Location
            commonPage.ScrollDown();
            Thread.Sleep(2000);
            String eventLocation = readEvents.GetValue("AddEventDetails", "eventLocation");
            eventsPage.EnterEventLocation(eventLocation);
            log.Info("Enter the Event Location.");
            Thread.Sleep(2000);
            
            //Select Event Visibility
            Thread.Sleep(2000);
            String eventVisibility = readEvents.GetValue("AddEventDetails", "eventVisibility");
            eventsPage.selectVisibility(eventVisibility);

            //Click the Create button
            eventsPage.ClickOnCreateEventBtn();
            log.Info("Verify Create New Event Page.");
            Thread.Sleep(4000);
        }

        //Create a Group
        public void CreateGroup(String groupName)
        {
            groupsPage.clickGroupsMenu();
            log.Info("Click on the side navigation link 'Groups'");

            //Click on Add New Group button
            Thread.Sleep(5000);
            groupsPage.clickOnAddNewGroupButton();
            log.Info("Click on the Add New Group button at Groups page");

            //Enter the Group Name
            Thread.Sleep(2000);
            groupsPage.enterNewGroupName(groupName);
            
            //Enter the Group Description
            Thread.Sleep(2000);
            commonPage.ScrollDown();
            Thread.Sleep(2000);
            groupsPage.enterNewGroupDescription("Group Desc");

            //Click on the create button at Add New Group form
            Thread.Sleep(2000);
            groupsPage.clickOnCreateButton();
        }

        //Delete Group
        public void DeleteGroup(String groupName)
        {
            //Click on the side navigation link 'Groups' 
            groupsPage.clickGroupsMenu();
            log.Info("Click on the side navigation link 'Groups'");
            Thread.Sleep(3000);

            //Click the All Groups Dropdown option
            groupsPage.ClickAllGroupsDropDown();
            log.Info("Click the All Groups dropdown.");
            Thread.Sleep(2000);

            //Select My Groups option
            groupsPage.ClickMyGroupsDropDownOption();
            log.Info("Click the My Groups dropdown option.");
            Thread.Sleep(2000);

            //Click the Group created
            groupsPage.ClickGroupOnGroupPage(groupName);
            log.Info("Click the Group Name on Groups Page.");
            Thread.Sleep(2000);

            //Click Settings option
            commonPage.ScrollUp();
            Thread.Sleep(2000);
            groupsPage.ClickSettingsOption();
            log.Info("Click on the Settings option after Group is created.");

            //Click Settings Options value 'Delete Group'
            groupsPage.ClickSettingsOptionsValues("Delete Group");
            log.Info("Verified Settings option value: 'Delete Group'");
            Thread.Sleep(2000);

            //Click the Delete Group Window Yes Button
            groupsPage.PressDeleteGroupWindowYesBtn();
            log.Info("Click the Delete Group Member Window Yes Button.");
            Thread.Sleep(2000);
        }

        //Delete Event
        public void DeleteEvent()
        {
            //Click Settings option
            commonPage.ScrollUp();
            Thread.Sleep(2000);
            eventsPage.ClickSettingsOption();
            log.Info("Click on the Settings option after Event is created.");

            //Click Settings Options value 'Delete Event'
            Thread.Sleep(2000);
            eventsPage.ClickSettingsOptionsValues("Delete Event");
            log.Info("Verified Settings option value: 'Delete Event'");
            Thread.Sleep(2000);

            //Click the Delete Event Window Yes Button
            eventsPage.PressDeleteEventWindowYesBtn();
            log.Info("Click the Delete Event Window Yes Button.");
            Thread.Sleep(2000);
        }

        //Delete Event after Host Change
        private void DeleteEventAfterHostChange(String eventName)
        {
            //Signout of the application
            Thread.Sleep(5000);
            authenticationPage.SignOut();
            log.Info("Click on the Signout button.");

            //Sign in with a different user
            Thread.Sleep(2000);
            SignInDifferentUser();
            log.Info("Sign in with different user.");

            //Select Event
            //Click Events menu option
            Thread.Sleep(5000);
            eventsPage.ClickEventsMenu();
            log.Info("Click the Events menu option.");
            Thread.Sleep(5000);

            //Click the All Events Dropdown option
            eventsPage.ClickAllEventsDropDown();
            log.Info("Click the All Events dropdown.");
            Thread.Sleep(2000);

            //Select My Events option
            eventsPage.ClickMyEventsDropDownOption();
            log.Info("Click the My Events dropdown option.");
            Thread.Sleep(2000);

            //Click the Event created
            eventsPage.ClickEventOnEventPage(eventName);
            log.Info("Click the Event Name on Events Page.");
            Thread.Sleep(2000);

            //Delete Event
            DeleteEvent();
        }

        [Test]
        public void Event_001_VerifyEventsOption()
        {
            Global.MethodName = "Event_001_VerifyEventsOption";
            eventsPage.VerifyEventsMenuOption();
            log.Info("Verify Events menu icon");
        }

        [Test]
        public void Event_002_VerifyAllEventsDropDown()
        {
            Global.MethodName = "Event_002_VerifyAllEventsDropDown";
            //Click Events menu option
            eventsPage.ClickEventsMenu();
            log.Info("Click the Events menu option.");
            Thread.Sleep(5000);

            //Click the All Events Dropdown option
            eventsPage.ClickAllEventsDropDown();
            log.Info("Click the All Events dropdown.");
            Thread.Sleep(2000);

            //Assert the All Events dropdown option displayed
            eventsPage.VerifyAllEventsDropDownOption();
            log.Info("Verify All Events option from the All Events dropdown.");
            Thread.Sleep(2000);

            //Assert the My Events dropdown option displayed
            eventsPage.VerifyMyEventsDropDownOption();
            log.Info("Verify My Events option from the All Events dropdown.");
            Thread.Sleep(2000);
        }

        [Test]
        public void Event_005_ClickNewEventAndVerify()
        {
            Global.MethodName = "Event_005_ClickNewEventAndVerify";
            //Click Events menu option
            eventsPage.ClickEventsMenu();
            log.Info("Click the Events menu option.");
            Thread.Sleep(5000);

            //Click New Event button
            eventsPage.ClickOnNewEventButton();
            log.Info("Click on New Event button.");
            Thread.Sleep(3000);

            //Assert the Create New Event Page displayed
            eventsPage.VerifyCreateNewEventPage();
            log.Info("Verify Create New Event Page.");
            Thread.Sleep(2000);
        }

        [Test]
        public void Event_008_CreateEventWithoutData()
        {
            Global.MethodName = "Event_008_CreateEventWithoutData";
            //Click Events menu option
            eventsPage.ClickEventsMenu();
            log.Info("Click the Events menu option.");
            Thread.Sleep(5000);

            //Click New Event button
            eventsPage.ClickOnNewEventButton();
            log.Info("Click on New Event button.");
            Thread.Sleep(3000);

            //Click the Create button
            eventsPage.ClickOnCreateEventBtn();
            log.Info("Verify Create New Event Page.");
            Thread.Sleep(2000);

            //Verify the error message displayed
            eventsPage.VerifyErrorMessage();
            log.Info("Verify the Error Message displayed.");
            Thread.Sleep(2000);
        }

        [Test]
        public void Event_009_CreateEventWithoutDesc()
        {
            Global.MethodName = "Event_009_CreateEventWithoutDesc";

            //Click Events menu option
            eventsPage.ClickEventsMenu();
            log.Info("Click the Events menu option.");
            Thread.Sleep(5000);

            //Click New Event button
            eventsPage.ClickOnNewEventButton();
            log.Info("Click on New Event button.");
            Thread.Sleep(3000);

            //Enter the Event Name
            eventsPage.EnterEventName("Event Without Description");
            log.Info("Enter the Event Name.");
            Thread.Sleep(2000);

            //Click the Create button
            eventsPage.ClickOnCreateEventBtn();
            log.Info("Verify Create New Event Page.");
            Thread.Sleep(2000);

            //Verify the error message displayed
            eventsPage.VerifyErrorMessage();
            log.Info("Verify the Error Message displayed.");
            Thread.Sleep(2000);
        }

        [Test]
        public void Event_010_CreateEventWithoutName()
        {
            Global.MethodName = "Event_010_CreateEventWithoutName";

            //Click Events menu option
            eventsPage.ClickEventsMenu();
            log.Info("Click the Events menu option.");
            Thread.Sleep(5000);

            //Click New Event button
            eventsPage.ClickOnNewEventButton();
            log.Info("Click on New Event button.");
            Thread.Sleep(3000);

            //Enter the Event Description
            eventsPage.EnterEventDescription("Event Without Name");
            log.Info("Enter the Event Description.");
            Thread.Sleep(2000);

            //Click the Create button
            eventsPage.ClickOnCreateEventBtn();
            log.Info("Verify Create New Event Page.");
            Thread.Sleep(2000);

            //Verify the error message displayed
            eventsPage.VerifyErrorMessage();
            log.Info("Verify the Error Message displayed.");
            Thread.Sleep(2000);
        }

        [Test]
        public void Event_016_SelectEventHost()
        {
            Global.MethodName = "Event_016_SelectEventHost";

            //Click Events menu option
            eventsPage.ClickEventsMenu();
            log.Info("Click the Events menu option.");
            Thread.Sleep(5000);

            //Click New Event button
            eventsPage.ClickOnNewEventButton();
            log.Info("Click on New Event button.");
            Thread.Sleep(3000);

            //Select Event Host
            String eventHost = readEvents.GetValue("AddEventDetails", "eventHost");
            eventsPage.SelectEventHost(eventHost);
            log.Info("Select Event Host.");
            Thread.Sleep(2000);
        }

        [Test]
        public void Event_017_SelectEventGroup()
        {
            Global.MethodName = "Event_017_SelectEventGroup";

            //Create a Group
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(4));
            String groupName = "Group for Activity";
            groupName = groupName + builder;
            CreateGroup(groupName);
            log.Info("Create a new Group");

            //Click Events menu option
            Thread.Sleep(5000);
            eventsPage.ClickEventsMenu();
            log.Info("Click the Events menu option.");
            Thread.Sleep(6000);

            //Click New Event button
            eventsPage.ClickOnNewEventButton();
            log.Info("Click on New Event button.");
            Thread.Sleep(3000);

            //Select Event Group            
            eventsPage.SelectEventGroup(groupName);
            log.Info("Select Event Group.");
            Thread.Sleep(2000);

            //Delete Group
            DeleteGroup(groupName);
        }

        [Test]
        public void Event_018_VerifyVisibilityOptions()
        {
            Global.MethodName = "Event_018_VerifyVisibilityOptions";

            //Click Events menu option
            eventsPage.ClickEventsMenu();
            log.Info("Click the Events menu option.");
            Thread.Sleep(5000);

            //Click New Event button
            eventsPage.ClickOnNewEventButton();
            log.Info("Click on New Event button.");
            Thread.Sleep(3000);

            //Verify Visibility Public radio option
            eventsPage.VerifyVisibilityPublic();
            log.Info("Verify Public Visibility Radio Option.");
            Thread.Sleep(2000);

            //Verify Visibility Private radio option
            eventsPage.VerifyVisibilityPrivate();
            log.Info("Verify Private Visibility Radio Option.");
            Thread.Sleep(2000);
        }

        [Test]
        public void Event_021_CreatePublicEvent()
        {
            Global.MethodName = "Event_021_CreatePublicEvent";

            //Create a Group
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(4));
            String groupName = "Group for Activity";
            groupName = groupName + builder;
            CreateGroup(groupName);
            log.Info("Create a new Group");

            //Click Events menu option
            Thread.Sleep(3000);
            eventsPage.ClickEventsMenu();
            log.Info("Click the Events menu option.");
            Thread.Sleep(5000);

            //Click New Event button
            eventsPage.ClickOnNewEventButton();
            log.Info("Click on New Event button.");
            Thread.Sleep(3000);

            //Enter the Event Name
            String eventName = readEvents.GetValue("AddEventDetails", "eventName");
            eventName = eventName + builder;
            eventsPage.EnterEventName(eventName);
            log.Info("Enter the Event Name.");
            Thread.Sleep(2000);

            //Enter the Event Description
            String eventDesc = readEvents.GetValue("AddEventDetails", "eventDesc");
            eventsPage.EnterEventDescription(eventDesc);
            log.Info("Enter the Event Description.");
            Thread.Sleep(2000);

            //Enter the Event Location
            commonPage.ScrollDown();
            Thread.Sleep(2000);
            String eventLocation = readEvents.GetValue("AddEventDetails", "eventLocation");
            eventsPage.EnterEventLocation(eventLocation);
            log.Info("Enter the Event Location.");
            Thread.Sleep(2000);

            //Select Event Group
            eventsPage.SelectEventGroup(groupName);
            log.Info("Select Event Group.");
            Thread.Sleep(2000);

            //Select Event Visibility
            Thread.Sleep(2000);
            String eventVisibility = readEvents.GetValue("AddEventDetails", "eventVisibility");
            eventsPage.selectVisibility(eventVisibility);

            //Click the Create button
            eventsPage.ClickOnCreateEventBtn();
            log.Info("Verify Create New Event Page.");
            Thread.Sleep(4000);

            //Delete Event
            DeleteEvent();
            Thread.Sleep(2000);

            //Delete Group
            DeleteGroup(groupName);
        }

        [Test]
        public void Event_022_CreatePrivateEvent()
        {
            Global.MethodName = "Event_022_CreatePrivateEvent";

            //Create a Group
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(4));
            String groupName = "Group for Activity";
            groupName = groupName + builder;
            CreateGroup(groupName);
            log.Info("Create a new Group");

            //Click Events menu option
            Thread.Sleep(3000);
            eventsPage.ClickEventsMenu();
            log.Info("Click the Events menu option.");
            Thread.Sleep(5000);

            //Click New Event button
            eventsPage.ClickOnNewEventButton();
            log.Info("Click on New Event button.");
            Thread.Sleep(3000);

            //Enter the Event Name
            String eventName = readEvents.GetValue("AddEventDetails", "eventName");
            eventName = eventName + builder;
            eventsPage.EnterEventName(eventName);
            log.Info("Enter the Event Name.");
            Thread.Sleep(2000);

            //Enter the Event Description
            String eventDesc = readEvents.GetValue("AddEventDetails", "eventDesc");
            eventsPage.EnterEventDescription(eventDesc);
            log.Info("Enter the Event Description.");
            Thread.Sleep(2000);

            //Enter the Event Location
            commonPage.ScrollDown();
            Thread.Sleep(2000);
            String eventLocation = readEvents.GetValue("AddEventDetails", "eventLocation");
            eventsPage.EnterEventLocation(eventLocation);
            log.Info("Enter the Event Location.");
            Thread.Sleep(2000);

            //Select Event Group
            eventsPage.SelectEventGroup(groupName);
            log.Info("Select Event Group.");
            Thread.Sleep(2000);

            //Select Event Visibility
            Thread.Sleep(2000);
            String eventVisibilityPrivate = readEvents.GetValue("AddEventDetails", "eventVisibilityPrivate");
            eventsPage.selectVisibility(eventVisibilityPrivate);

            //Click the Create button
            eventsPage.ClickOnCreateEventBtn();
            log.Info("Verify Create New Event Page.");
            Thread.Sleep(4000);

            //Delete Event
            DeleteEvent();
            Thread.Sleep(2000);

            //Delete Group
            DeleteGroup(groupName);
        }

        [Test]
        public void Event_023_CreateEventAndVerifyTabs()
        {
            Global.MethodName = "Event_023_CreateEventAndVerifyTabs";

            //Create an Event
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(4));
            String eventName = readEvents.GetValue("AddEventDetails", "eventName");
            eventName = eventName + builder;
            CreateEvent(eventName);
            log.Info("Create a new Event.");
            Thread.Sleep(2000);

            //Verify About Tab
            eventsPage.VerifyAboutTab();
            log.Info("Verify the About Tab.");
            Thread.Sleep(2000);

            //Verify Discussions Tab
            eventsPage.VerifyDiscussionsTab();
            log.Info("Verify the Discussions Tab.");
            Thread.Sleep(2000);

            //Verify Projects Tab
            eventsPage.VerifyProjectsTab();
            log.Info("Verify the Projects Tab.");
            Thread.Sleep(2000);

            //Verify Files Tab
            eventsPage.VerifyFilesTab();
            log.Info("Verify the Files Tab.");
            Thread.Sleep(2000);

            //Delete Event
            DeleteEvent();
        }

        [Test]
        public void Event_024_CreatePrivateEventAndVerify()
        {
            Global.MethodName = "Event_024_CreatePrivateEventAndVerify";

            //Create a Group
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(4));
            String groupName = "Group for Activity";
            groupName = groupName + builder;
            CreateGroup(groupName);
            log.Info("Create a new Group");

            //Click Events menu option
            Thread.Sleep(3000);
            eventsPage.ClickEventsMenu();
            log.Info("Click the Events menu option.");
            Thread.Sleep(5000);

            //Click New Event button
            eventsPage.ClickOnNewEventButton();
            log.Info("Click on New Event button.");
            Thread.Sleep(3000);

            //Enter the Event Name
            String eventName = readEvents.GetValue("AddEventDetails", "eventName");
            eventName = eventName + builder;
            eventsPage.EnterEventName(eventName);
            log.Info("Enter the Event Name.");
            Thread.Sleep(2000);

            //Enter the Event Description
            String eventDesc = readEvents.GetValue("AddEventDetails", "eventDesc");
            eventsPage.EnterEventDescription(eventDesc);
            log.Info("Enter the Event Description.");
            Thread.Sleep(2000);

            //Enter the Event Location
            commonPage.ScrollDown();
            Thread.Sleep(2000);
            String eventLocation = readEvents.GetValue("AddEventDetails", "eventLocation");
            eventsPage.EnterEventLocation(eventLocation);
            log.Info("Enter the Event Location.");
            Thread.Sleep(2000);

            //Select Event Group
            eventsPage.SelectEventGroup(groupName);
            log.Info("Select Event Group.");
            Thread.Sleep(2000);

            //Select Event Visibility
            Thread.Sleep(2000);
            String eventVisibilityPrivate = readEvents.GetValue("AddEventDetails", "eventVisibilityPrivate");
            eventsPage.selectVisibility(eventVisibilityPrivate);

            //Click the Create button
            eventsPage.ClickOnCreateEventBtn();
            log.Info("Verify Create New Event Page.");
            Thread.Sleep(4000);

            //Verify the Private Label
            eventsPage.VerifyPrivateLabel();
            log.Info("Verify the Private Label.");
            Thread.Sleep(2000);

            //Delete Event
            DeleteEvent();
            Thread.Sleep(2000);

            //Delete Group
            DeleteGroup(groupName);
        }

        [Test]
        public void Event_025_CreateEventAndVerifyAbout()
        {
            Global.MethodName = "Event_025_CreateEventAndVerifyAbout";

            //Create an Event
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(4));
            String eventName = readEvents.GetValue("AddEventDetails", "eventName");
            eventName = eventName + builder;
            CreateEvent(eventName);
            log.Info("Create a new Event.");
            Thread.Sleep(2000);

            //Verify Event Name Dashboard
            eventsPage.VerifyEventNameDashboard(eventName);
            log.Info("Verify the Event Name on Dashboard.");
            Thread.Sleep(2000);

            //Verify Event Description Dashboard
            String eventDesc = readEvents.GetValue("AddEventDetails", "eventDesc");
            eventsPage.VerifyEventDescDashboard(eventDesc);
            log.Info("Verify the Event Description on Dashboard.");
            Thread.Sleep(2000);

            //Verify Joined button
            eventsPage.VerifyJoinedBtnDashboard();
            log.Info("Verify the Joined button on Dashboard.");
            Thread.Sleep(2000);

            //Delete Event
            DeleteEvent();
        }

        [Test]
        public void Event_026_LeaveEventAndVerify()
        {
            Global.MethodName = "Event_026_LeaveEventAndVerify";

            //Create an Event
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(4));
            String eventName = readEvents.GetValue("AddEventDetails", "eventName");
            eventName = eventName + builder;
            CreateEvent(eventName);
            log.Info("Create a new Event.");
            Thread.Sleep(2000);

            //Now change the Event Host
            //Click Settings option
            commonPage.ScrollUp();
            Thread.Sleep(2000);
            eventsPage.ClickSettingsOption();
            log.Info("Click on the Settings option after Event is created.");

            //Click Settings Options value 'Edit Event'
            eventsPage.ClickSettingsOptionsValues("Edit Event");
            log.Info("Click Settings option value: 'Edit Event'");
            Thread.Sleep(2000);

            //Verify Edit Event Window
            eventsPage.AssertEditEventDialog();
            log.Info("Verify the Edit Group Member Window.");
            Thread.Sleep(2000);

            //Edit Event Host
            String editEventHost = readEvents.GetValue("EditEvent", "editEventHost");
            eventsPage.SelectEventHost(editEventHost);
            Thread.Sleep(2000);

            //Click Edit Event Window Save Button
            eventsPage.ClickEditEventWindowSaveBtn();
            log.Info("Save clicked successfully.");
            Thread.Sleep(5000);

            //Click leave Event
            //Click Settings option
            commonPage.ScrollUp();
            eventsPage.ClickSettingsOption();
            Thread.Sleep(2000);

            //Click Settings Options value 'Leave Event'
            eventsPage.ClickSettingsOptionsValues("Leave Event");
            log.Info("Click Settings option value: 'Leave Event'");
            Thread.Sleep(2000);

            //Verify the Leave Event Window
            eventsPage.VerifyLeaveEventWindow();
            log.Info("Verify the Leave Event window.");
            Thread.Sleep(2000);

            //Verify the Leave Event Window No Button
            eventsPage.VerifyLeaveGroupWindowNoBtn();
            log.Info("Verify the Leave Event window No Button.");
            Thread.Sleep(2000);

            //Verify the Leave Event Window Yes Button
            eventsPage.VerifyLeaveGroupWindowYesBtn();
            log.Info("Verify the Leave Event window Yes Button.");
            Thread.Sleep(2000);

            //Click Leave Event Window Close Icon
            eventsPage.PressLeaveEventWindowCloseIcon();
            log.Info("Click Leave Event Window Close Icon.");
            Thread.Sleep(2000);

            //Delete Event After Host Change
            DeleteEventAfterHostChange(eventName);
        }

        [Test]
        public void Event_027_ClickLeaveEventNoBtn()
        {
            Global.MethodName = "Event_027_ClickLeaveEventNoBtn";

            //Create an Event
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(4));
            String eventName = readEvents.GetValue("AddEventDetails", "eventName");
            eventName = eventName + builder;
            CreateEvent(eventName);
            log.Info("Create a new Event.");
            Thread.Sleep(2000);

            //Now change the Event Host
            //Click Settings option
            commonPage.ScrollUp();
            Thread.Sleep(2000);
            eventsPage.ClickSettingsOption();
            log.Info("Click on the Settings option after Event is created.");

            //Click Settings Options value 'Edit Event'
            eventsPage.ClickSettingsOptionsValues("Edit Event");
            log.Info("Click Settings option value: 'Edit Event'");
            Thread.Sleep(2000);

            //Verify Edit Event Window
            eventsPage.AssertEditEventDialog();
            log.Info("Verify the Edit Group Member Window.");
            Thread.Sleep(2000);

            //Edit Event Host
            String editEventHost = readEvents.GetValue("EditEvent", "editEventHost");
            eventsPage.SelectEventHost(editEventHost);
            Thread.Sleep(2000);

            //Click Edit Event Window Save Button
            eventsPage.ClickEditEventWindowSaveBtn();
            log.Info("Save clicked successfully.");
            Thread.Sleep(5000);

            //Click leave Event
            //Click Settings option
            commonPage.ScrollUp();
            eventsPage.ClickSettingsOption();
            Thread.Sleep(2000);

            //Click Settings Options value 'Leave Event'
            eventsPage.ClickSettingsOptionsValues("Leave Event");
            log.Info("Click Settings option value: 'Leave Event'");
            Thread.Sleep(2000);

            //Click the Leave Event Window No Button
            eventsPage.PressLeaveGroupWindowNoBtn();
            log.Info("Click Leave Event window No Button.");
            Thread.Sleep(2000);

            //Delete Event After Host Change
            DeleteEventAfterHostChange(eventName);
        }

        [Test]
        public void Event_028_ClickLeaveEventYesBtn()
        {
            Global.MethodName = "Event_028_ClickLeaveEventYesBtn";

            //Create an Event
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(4));
            String eventName = readEvents.GetValue("AddEventDetails", "eventName");
            eventName = eventName + builder;
            CreateEvent(eventName);
            log.Info("Create a new Event.");
            Thread.Sleep(2000);

            //Now change the Event Host
            //Click Settings option
            commonPage.ScrollUp();
            Thread.Sleep(2000);
            eventsPage.ClickSettingsOption();
            log.Info("Click on the Settings option after Event is created.");

            //Click Settings Options value 'Edit Event'
            eventsPage.ClickSettingsOptionsValues("Edit Event");
            log.Info("Click Settings option value: 'Edit Event'");
            Thread.Sleep(2000);

            //Verify Edit Event Window
            eventsPage.AssertEditEventDialog();
            log.Info("Verify the Edit Group Member Window.");
            Thread.Sleep(2000);

            //Edit Event Host
            String editEventHost = readEvents.GetValue("EditEvent", "editEventHost");
            eventsPage.SelectEventHost(editEventHost);
            Thread.Sleep(2000);

            //Click Edit Event Window Save Button
            eventsPage.ClickEditEventWindowSaveBtn();
            log.Info("Save clicked successfully.");
            Thread.Sleep(5000);

            //Click leave Event
            //Click Settings option
            commonPage.ScrollUp();
            eventsPage.ClickSettingsOption();
            Thread.Sleep(2000);

            //Click Settings Options value 'Leave Event'
            eventsPage.ClickSettingsOptionsValues("Leave Event");
            log.Info("Click Settings option value: 'Leave Event'");
            Thread.Sleep(2000);

            //CLick the Leave Event Window Yes Button
            eventsPage.PressLeaveEventWindowYesBtn();
            log.Info("Click Leave Event window Yes Button.");
            Thread.Sleep(2000);

            //Verify Join button present on the screen or not
            Thread.Sleep(2000);
            eventsPage.VerifyJoinBtnDashboard();
            log.Info("Verify the Join button on the screen");

            //Delete Event After Host Change
            DeleteEventAfterHostChange(eventName);
        }

        [Test]
        public void Event_032_AddMemberInEventByName()
        {
            Global.MethodName = "Event_032_AddMemberInEventByName";

            //Create an Event
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(4));
            String eventName = readEvents.GetValue("AddEventDetails", "eventName");
            eventName = eventName + builder;
            CreateEvent(eventName);
            log.Info("Create a new Event.");
            Thread.Sleep(2000);

            //Click Settings option
            commonPage.ScrollUp();
            eventsPage.ClickSettingsOption();
            Thread.Sleep(2000);

            //Click Settings Options value 'Add Participants'
            eventsPage.ClickSettingsOptionsValues("Add Participants");
            log.Info("Click Settings option value: 'Add Participants'");
            Thread.Sleep(2000);

            //Enter the Event Member Name
            String addMemberName = readEvents.GetValue("AddEventMember", "addMemberName");
            eventsPage.EnterEventMember(addMemberName);
            log.Info("Entered " + addMemberName + " into Add Member Text field ");
            Thread.Sleep(5000);

            //Press Enter Key
            eventsPage.PressEnterKey();
            Thread.Sleep(2000);

            //Click the Add button
            groupsPage.ClickAddWindowAddButton();
            log.Info("Click on Add Window Add button.");
            Thread.Sleep(2000);

            //Verify the added member confirmation message
            eventsPage.VerifyAddedMemberConfMsg();
            log.Info("Verify Event member added confirmation message.");
            Thread.Sleep(5000);

            //Delete the Event
            DeleteEvent();
            Thread.Sleep(2000);
        }

        [Test]
        public void Event_033_AddMemberInEventByEmail()
        {
            Global.MethodName = "Event_033_AddMemberInEventByEmail";

            //Create an Event
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(4));
            String eventName = readEvents.GetValue("AddEventDetails", "eventName");
            eventName = eventName + builder;
            CreateEvent(eventName);
            log.Info("Create a new Event.");
            Thread.Sleep(2000);

            //Click Settings option
            commonPage.ScrollUp();
            eventsPage.ClickSettingsOption();
            Thread.Sleep(2000);

            //Click Settings Options value 'Add Participants'
            eventsPage.ClickSettingsOptionsValues("Add Participants");
            log.Info("Click Settings option value: 'Add Participants'");
            Thread.Sleep(2000);

            //Enter the Event Member Email
            String addMemberEmail = readEvents.GetValue("AddEventMember", "addMemberEmail");
            eventsPage.EnterEventMember(addMemberEmail);
            log.Info("Entered " + addMemberEmail + " into Add Member Text field ");
            Thread.Sleep(5000);

            //Select user from suggestion
            String addMemberName = readEvents.GetValue("AddEventMember", "addMemberName");
            eventsPage.SelectUserfromSuggestion(addMemberName);
            log.Info("User selected successfully.");
            Thread.Sleep(5000);

            //Click the Add button
            groupsPage.ClickAddWindowAddButton();
            log.Info("Click on Add Window Add button.");
            Thread.Sleep(2000);

            //Verify the added member confirmation message
            eventsPage.VerifyAddedMemberConfMsg();
            log.Info("Verify Event member added confirmation message.");
            Thread.Sleep(5000);

            //Delete the Event
            DeleteEvent();
            Thread.Sleep(2000);
        }

        [Test]
        public void Event_034_SettingsOptionEventHost()
        {
            Global.MethodName = "Event_034_SettingsOptionEventHost";

            //Create an Event
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(4));
            String eventName = readEvents.GetValue("AddEventDetails", "eventName");
            eventName = eventName + builder;
            CreateEvent(eventName);
            log.Info("Create a new Event.");
            Thread.Sleep(2000);

            //Click Settings option
            Thread.Sleep(5000);
            groupsPage.ClickSettingsOption();
            log.Info("Click on the Settings option after Event is created.");

            //Verify Settings Options value 'Link to Eventbrite'
            groupsPage.GetSettingsOptionsValues("Link to Eventbrite");
            log.Info("Verified Settings option value: 'Link to Eventbrite'");
            Thread.Sleep(2000);

            //Verify Settings Options value 'Add Participants'
            groupsPage.GetSettingsOptionsValues("Add Participants");
            log.Info("Verified Settings option value: 'Add Participants'");
            Thread.Sleep(2000);

            //Verify Settings Options value 'Edit Event'
            groupsPage.GetSettingsOptionsValues("Edit Event");
            log.Info("Verified Settings option value: 'Edit Event'");
            Thread.Sleep(2000);

            //Verify Settings Options value 'Delete Event'
            groupsPage.GetSettingsOptionsValues("Delete Event");
            log.Info("Verified Settings option value: 'Delete Event'");
            Thread.Sleep(2000);

            //Click Settings option
            Thread.Sleep(5000);
            groupsPage.ClickSettingsOption();
            log.Info("Click on the Settings option after Group is created.");

            //Delete the group
            DeleteEvent();
            Thread.Sleep(2000);
        }

        [Test]
        public void Event_036_VerifyAddMemberWindow()
        {
            Global.MethodName = "Event_036_VerifyAddMemberWindow";

            //Create an Event
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(4));
            String eventName = readEvents.GetValue("AddEventDetails", "eventName");
            eventName = eventName + builder;
            CreateEvent(eventName);
            log.Info("Create a new Event.");
            Thread.Sleep(2000);

            //Click Settings option
            commonPage.ScrollUp();
            eventsPage.ClickSettingsOption();
            Thread.Sleep(2000);

            //Click Settings Options value 'Add Participants'
            eventsPage.ClickSettingsOptionsValues("Add Participants");
            log.Info("Click Settings option value: 'Add Participants'");
            Thread.Sleep(2000);

            //Verify the Add Event Participants window displayed
            eventsPage.AssertAddEventMemberDialog();
            log.Info("Verify the 'Add Participants' window displayed.");
            Thread.Sleep(2000);

            //Click Add Member Window Close Icon
            eventsPage.ClickAddWindMemberWindowCloseIcon();
            log.Info("Close icon clicked successfully.");
            Thread.Sleep(3000);

            //Delete Event After Host Change
            DeleteEvent();
            Thread.Sleep(2000);
        }

        [Test]
        public void Event_037_TryToJoinPrivateEvent()
        {
            Global.MethodName = "Event_037_TryToJoinPrivateEvent";

            //Create a Group
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(4));
            String groupName = "Group for Activity";
            groupName = groupName + builder;
            CreateGroup(groupName);
            log.Info("Create a new Group");

            //Click Events menu option
            Thread.Sleep(3000);
            eventsPage.ClickEventsMenu();
            log.Info("Click the Events menu option.");
            Thread.Sleep(5000);

            //Click New Event button
            eventsPage.ClickOnNewEventButton();
            log.Info("Click on New Event button.");
            Thread.Sleep(3000);

            //Enter the Event Name
            String eventName = readEvents.GetValue("AddEventDetails", "eventName");
            eventName = eventName + builder;
            eventsPage.EnterEventName(eventName);
            log.Info("Enter the Event Name.");
            Thread.Sleep(2000);

            //Enter the Event Description
            String eventDesc = readEvents.GetValue("AddEventDetails", "eventDesc");
            eventsPage.EnterEventDescription(eventDesc);
            log.Info("Enter the Event Description.");
            Thread.Sleep(2000);

            //Enter the Event Location
            commonPage.ScrollDown();
            Thread.Sleep(2000);
            String eventLocation = readEvents.GetValue("AddEventDetails", "eventLocation");
            eventsPage.EnterEventLocation(eventLocation);
            log.Info("Enter the Event Location.");
            Thread.Sleep(2000);

            //Select Event Group
            eventsPage.SelectEventGroup(groupName);
            log.Info("Select Event Group.");
            Thread.Sleep(2000);

            //Select Event Visibility
            Thread.Sleep(2000);
            String eventVisibilityPrivate = readEvents.GetValue("AddEventDetails", "eventVisibilityPrivate");
            eventsPage.selectVisibility(eventVisibilityPrivate);

            //Click the Create button
            eventsPage.ClickOnCreateEventBtn();
            log.Info("Verify Create New Event Page.");
            Thread.Sleep(4000);

            //Signout of the application
            Thread.Sleep(5000);
            authenticationPage.SignOut();
            log.Info("Click on the Signout button.");

            //Sign in with a different user
            Thread.Sleep(2000);
            SignInDifferentUser();
            log.Info("Sign in with different user.");

            //Select Event
            //Click Events menu option
            eventsPage.ClickEventsMenu();
            log.Info("Click the Events menu option.");
            Thread.Sleep(5000);

            //Verify the Private Event not displayed on the screen
            eventsPage.VerifyEventNotDisplayedOnEventPage(eventName);
            log.Info("Verify Private Event is not displayed on Events Page.");
            Thread.Sleep(3000);

            //Signout of the application
            authenticationPage.SignOut();
            log.Info("Click on the Signout button.");

            //Login to the application
            authenticationPage.SetUserName(_workEmail);
            authenticationPage.SetPassword(_password);
            authenticationPage.ClickOnLoginButton();
            authenticationPage.VerifyHomeScreen();

            //Select Event
            //Click Events menu option
            eventsPage.ClickEventsMenu();
            log.Info("Click the Events menu option.");
            Thread.Sleep(5000);

            //Click the All Events Dropdown option
            eventsPage.ClickAllEventsDropDown();
            log.Info("Click the All Events dropdown.");
            Thread.Sleep(2000);

            //Select My Events option
            eventsPage.ClickMyEventsDropDownOption();
            log.Info("Click the My Events dropdown option.");
            Thread.Sleep(2000);

            //Click the Event created
            eventsPage.ClickEventOnEventPage(eventName);
            log.Info("Click the Event Name on Events Page.");
            Thread.Sleep(2000);

            //Delete Event
            DeleteEvent();
            Thread.Sleep(2000);

            //Delete Group
            DeleteGroup(groupName);
        }

        [Test]
        public void Event_038_VerifyEditEventWindow()
        {
            Global.MethodName = "Event_038_VerifyEditEventWindow";

            //Create an Event
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(4));
            String eventName = readEvents.GetValue("AddEventDetails", "eventName");
            eventName = eventName + builder;
            CreateEvent(eventName);
            log.Info("Create a new Event.");
            Thread.Sleep(2000);

            //Now change the Event Host
            //Click Settings option
            commonPage.ScrollUp();
            Thread.Sleep(2000);
            eventsPage.ClickSettingsOption();
            log.Info("Click on the Settings option after Event is created.");

            //Click Settings Options value 'Edit Event'
            eventsPage.ClickSettingsOptionsValues("Edit Event");
            log.Info("Click Settings option value: 'Edit Event'");
            Thread.Sleep(2000);

            //Verify Edit Event Window
            eventsPage.AssertEditEventDialog();
            log.Info("Verify the Edit Event Member Window.");
            Thread.Sleep(2000);

            //Click Edit Event Window Cancel button
            eventsPage.ClickEditEventWindowCancelBtn();
            log.Info("Click the Edit Event Window Cancel button.");
            Thread.Sleep(2000);

            //Delete Event
            DeleteEvent();
            Thread.Sleep(2000);
        }

        [Test]
        public void Event_039_EditEventAndVerify()
        {
            Global.MethodName = "Event_039_EditEventAndVerify";

            //Create an Event
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(4));
            String eventName = readEvents.GetValue("AddEventDetails", "eventName");
            eventName = eventName + builder;
            CreateEvent(eventName);
            log.Info("Create a new Event.");
            Thread.Sleep(2000);

            //Now change the Event Host
            //Click Settings option
            commonPage.ScrollUp();
            Thread.Sleep(2000);
            eventsPage.ClickSettingsOption();
            log.Info("Click on the Settings option after Event is created.");

            //Click Settings Options value 'Edit Event'
            eventsPage.ClickSettingsOptionsValues("Edit Event");
            log.Info("Click Settings option value: 'Edit Event'");
            Thread.Sleep(2000);

            //Verify Edit Event Window
            eventsPage.AssertEditEventDialog();
            log.Info("Verify the Edit Event Member Window.");
            Thread.Sleep(2000);

            //Edit Event Name
            eventsPage.EnterEventName("Edited Event Name");
            log.Info("Edit the Event Name.");
            Thread.Sleep(1000);

            //Edit Event Description
            eventsPage.EnterEventDescription("Edited Event Description");
            log.Info("Edit the Event Description.");
            Thread.Sleep(2000);

            //Click Edit Event Window Save button
            eventsPage.ClickEditEventWindowSaveBtn();
            log.Info("Click the Edit Event Window Save button.");
            Thread.Sleep(2000);

            //Verify Event Name Dashboard
            eventsPage.VerifyEventNameDashboard("Edited Event Name");
            log.Info("Verify the Event Name on Dashboard.");
            Thread.Sleep(2000);

            //Verify Event Description Dashboard
            eventsPage.VerifyEventDescDashboard("Edited Event Description");
            log.Info("Verify the Event Description on Dashboard.");
            Thread.Sleep(2000);

            //Delete Event
            DeleteEvent();
            Thread.Sleep(2000);
        }

        [Test]
        public void Event_040_DeleteEventAndVerify()
        {
            Global.MethodName = "Event_040_DeleteEventAndVerify";

            //Create an Event
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(4));
            String eventName = readEvents.GetValue("AddEventDetails", "eventName");
            eventName = eventName + builder;
            CreateEvent(eventName);
            log.Info("Create a new Event.");
            Thread.Sleep(2000);

            //Click Settings option
            commonPage.ScrollUp();
            Thread.Sleep(2000);
            eventsPage.ClickSettingsOption();
            log.Info("Click on the Settings option after Event is created.");

            //Click Settings Options value 'Delete Event'
            eventsPage.ClickSettingsOptionsValues("Delete Event");
            log.Info("Click Settings option value: 'Delete Event'");
            Thread.Sleep(2000);

            //Verify the Delete Event Window
            eventsPage.VerifyDeleteEventWindow();
            log.Info("Verify the Delete Event window.");
            Thread.Sleep(2000);

            //Verify the Delete Event Window No Button
            eventsPage.VerifyDeleteGroupWindowNoBtn();
            log.Info("Verify the Delete Event window No Button.");
            Thread.Sleep(2000);

            //Verify the Delete Event Window Yes Button
            eventsPage.VerifyDeleteGroupWindowYesBtn();
            log.Info("Verify the Delete Event window Yes Button.");
            Thread.Sleep(2000);

            //Click Delete Event Window Close Icon
            eventsPage.PressDeleteEventWindowCloseIcon();
            log.Info("Click Delete Event Window Close Icon.");
            Thread.Sleep(2000);

            //Delete Event
            DeleteEvent();
            Thread.Sleep(2000);
        }

        [Test]
        public void Event_041_DeleteEventNoButton()
        {
            Global.MethodName = "Event_041_DeleteEventNoButton";

            //Create an Event
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(4));
            String eventName = readEvents.GetValue("AddEventDetails", "eventName");
            eventName = eventName + builder;
            CreateEvent(eventName);
            log.Info("Create a new Event.");
            Thread.Sleep(2000);

            //Click Settings option
            commonPage.ScrollUp();
            Thread.Sleep(2000);
            eventsPage.ClickSettingsOption();
            log.Info("Click on the Settings option after Event is created.");

            //Click Settings Options value 'Delete Event'
            eventsPage.ClickSettingsOptionsValues("Delete Event");
            log.Info("Click Settings option value: 'Delete Event'");
            Thread.Sleep(2000);

            //Click Delete Event Window No button
            eventsPage.PressDeleteEventWindowNoBtn();
            log.Info("Click Delete Event Window No button.");
            Thread.Sleep(2000);

            //Verify the Event Name on the dashboard
            eventsPage.VerifyEventNameDashboard(eventName);
            log.Info("Verify the Event Name on the Events dashboard.");
            Thread.Sleep(2000);

            //Delete Event
            DeleteEvent();
            Thread.Sleep(2000);
        }

        [Test]
        public void Event_042_DeleteEventYesButton()
        {
            Global.MethodName = "Event_042_DeleteEventYesButton";

            //Create an Event
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(4));
            String eventName = readEvents.GetValue("AddEventDetails", "eventName");
            eventName = eventName + builder;
            CreateEvent(eventName);
            log.Info("Create a new Event.");
            Thread.Sleep(2000);

            //Click Settings option
            commonPage.ScrollUp();
            Thread.Sleep(2000);
            eventsPage.ClickSettingsOption();
            log.Info("Click on the Settings option after Event is created.");

            //Click Settings Options value 'Delete Event'
            eventsPage.ClickSettingsOptionsValues("Delete Event");
            log.Info("Click Settings option value: 'Delete Event'");
            Thread.Sleep(2000);

            //Click Delete Event Window Yes button
            eventsPage.PressDeleteEventWindowYesBtn();
            log.Info("Click Delete Event Window Yes button.");
            Thread.Sleep(3000);

            //Verify the Event Name not displayed
            eventsPage.VerifyEventNotDisplayedOnEventPage(eventName);
            log.Info("Verify the Event Name on the Events Page.");
            Thread.Sleep(2000);
        }

        [Test]
        public void Event_043_ClickDiscussionsAndVerify()
        {
            Global.MethodName = "Event_043_ClickDiscussionsAndVerify";

            //Create an Event
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(4));
            String eventName = readEvents.GetValue("AddEventDetails", "eventName");
            eventName = eventName + builder;
            CreateEvent(eventName);
            log.Info("Create a new Event.");
            Thread.Sleep(2000);

            //Click on Discussions tab
            eventsPage.ClickEventsDiscussionTab();
            log.Info("Click on Event's Discussion tab.");
            Thread.Sleep(5000);

            //Verify the Discussion message div
            eventsPage.VerifyDiscussionsTabWindow();
            log.Info("Verify the Discussion message div.");
            Thread.Sleep(2000);

            //Click Event's About tab
            eventsPage.ClickEventsAboutTab();
            log.Info("Click on Event's About tab.");
            Thread.Sleep(5000);

            //Delete the Event
            DeleteEvent();
            Thread.Sleep(2000);
        }

        [Test]
        public void Event_044_PostDiscussionMsgAndVerify()
        {
            Global.MethodName = "Event_044_PostDiscussionMsgAndVerify";

            //Create an Event
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(4));
            String eventName = readEvents.GetValue("AddEventDetails", "eventName");
            eventName = eventName + builder;
            CreateEvent(eventName);
            log.Info("Create a new Event.");
            Thread.Sleep(2000);

            //Click on Discussions tab
            eventsPage.ClickEventsDiscussionTab();
            log.Info("Click on Event's Discussion tab.");
            Thread.Sleep(5000);

            //Click Discussion Message Div
            eventsPage.ClickMessageTextArea();
            log.Info("Click message in Discussion.");
            Thread.Sleep(2000);

            //Enter the Message in Text Area
            String typeMessage = readEvents.GetValue("Discussion", "typeMessage");
            eventsPage.EnterMessageTextArea(typeMessage);
            log.Info("Enter message in Discussion.");
            Thread.Sleep(2000);

            //Click the Post button for the message
            eventsPage.ClickMessagePostBtn();
            log.Info("Click the Post button for the message.");
            Thread.Sleep(2000);

            //Verify the Discussion Message Reply button
            eventsPage.VerifyDiscussionMsgReplyBtn();
            log.Info("Verify the Discussion Message Reply button.");
            Thread.Sleep(4000);

            //Click Event's About tab
            eventsPage.ClickEventsAboutTab();
            log.Info("Click on Event's About tab.");
            Thread.Sleep(2000);

            //Delete the group
            DeleteEvent();
            Thread.Sleep(2000);
        }

        [Test]
        public void Event_045_UploadDiscussionFileAndVerify()
        {
            Global.MethodName = "Event_045_UploadDiscussionFileAndVerify";

            //Create an Event
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(4));
            String eventName = readEvents.GetValue("AddEventDetails", "eventName");
            eventName = eventName + builder;
            CreateEvent(eventName);
            log.Info("Create a new Event.");
            Thread.Sleep(2000);

            //Click on Discussions tab
            eventsPage.ClickEventsDiscussionTab();
            log.Info("Click on Event's Discussion tab.");
            Thread.Sleep(5000);

            //Click Discussion Attachment Icon
            eventsPage.ClickDiscussionAttachIcon();
            log.Info("Click message in Discussion.");
            Thread.Sleep(2000);
            String startupPath = Environment.CurrentDirectory; ;
            startupPath = startupPath + "\\no-testing-required-it-will-work.jpg";
            Console.WriteLine("Start up path: " + startupPath);
            SendKeys.SendWait(@startupPath);
            Thread.Sleep(2000);
            SendKeys.SendWait(@"{Enter}");
            Thread.Sleep(5000);

            //Click Event's About tab
            eventsPage.ClickEventsAboutTab();
            log.Info("Click on Event's About tab.");
            Thread.Sleep(2000);

            //Delete the group
            DeleteEvent();
            Thread.Sleep(2000);
        }

        [Test]
        public void Event_050_ReplyDiscussionMsgAndVerify()
        {
            Global.MethodName = "Event_050_ReplyDiscussionMsgAndVerify";

            //Create an Event
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(4));
            String eventName = readEvents.GetValue("AddEventDetails", "eventName");
            eventName = eventName + builder;
            CreateEvent(eventName);
            log.Info("Create a new Event.");
            Thread.Sleep(2000);

            //Click on Discussions tab
            eventsPage.ClickEventsDiscussionTab();
            log.Info("Click on Event's Discussion tab.");
            Thread.Sleep(5000);

            //Click Discussion Message Div
            eventsPage.ClickMessageTextArea();
            log.Info("Click message in Discussion.");
            Thread.Sleep(2000);

            //Enter the Message in Text Area
            String typeMessage = readEvents.GetValue("Discussion", "typeMessage");
            eventsPage.EnterMessageTextArea(typeMessage);
            log.Info("Enter message in Discussion.");
            Thread.Sleep(2000);

            //Click the Post button for the message
            eventsPage.ClickMessagePostBtn();
            log.Info("Click the Post button for the message.");
            Thread.Sleep(2000);

            //Click the Discussion Message Reply button
            eventsPage.ClickMessageReplyBtn();
            log.Info("Click the Discussion Message Reply button.");
            Thread.Sleep(2000);

            eventsPage.PressTabKey();
            Thread.Sleep(2000);
            eventsPage.PressTabKey();
            Thread.Sleep(4000);

            //Enter text in the Discussion Reply Message Text Area
            String typeReplyMessage = readEvents.GetValue("Discussion", "typeReplyMessage");
            eventsPage.EnterMessageReplyTextArea(typeReplyMessage);
            log.Info("Click the Reply Message Text Area");
            Thread.Sleep(2000);

            //Click Event's About tab
            groupsPage.ClickGroupAboutTab();
            log.Info("Click on Event's About tab.");
            Thread.Sleep(2000);

            //Delete the group
            DeleteEvent();
            Thread.Sleep(2000);
        }

        [Test]
        public void Event_052_MoveToProjectAndCreate()
        {
            Global.MethodName = "Event_052_MoveToProjectAndCreate";

            //Create an Event
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(4));
            String eventName = readEvents.GetValue("AddEventDetails", "eventName");
            eventName = eventName + builder;
            CreateEvent(eventName);
            log.Info("Create a new Event.");
            Thread.Sleep(2000);

            //Click on Projects tab
            eventsPage.ClickGroupProjectTab();
            log.Info("Click on Event's Project tab.");
            Thread.Sleep(5000);

            //Click Add New Project button
            projectsPage.ClickOnAddProjectButton();
            log.Info("Click on Projects add new button under Groups.");
            Thread.Sleep(3000);

            //Enter Project Name
            String projectName = "Random Project Name";
            projectName = projectName + builder;
            projectsPage.EnterProjectName(projectName);
            log.Info("Enter Project Name under Group.");
            Thread.Sleep(2000);

            //Enter Project Description
            projectsPage.EnterProjectDescription("Project Desc under Event");
            log.Info("Enter Project Description under Group.");
            Thread.Sleep(2000);

            //Click Create button for Project
            projectsPage.ClickOnCreateProjectBtn();
            Thread.Sleep(2000);

            //Select Event
            //Click Events menu option
            eventsPage.ClickEventsMenu();
            log.Info("Click the Events menu option.");
            Thread.Sleep(5000);

            //Click the All Events Dropdown option
            eventsPage.ClickAllEventsDropDown();
            log.Info("Click the All Events dropdown.");
            Thread.Sleep(2000);

            //Select My Events option
            eventsPage.ClickMyEventsDropDownOption();
            log.Info("Click the My Events dropdown option.");
            Thread.Sleep(2000);

            //Click the Event created
            eventsPage.ClickEventOnEventPage(eventName);
            log.Info("Click the Event Name on Events Page.");
            Thread.Sleep(2000);

            //Delete Event
            DeleteEvent();
        }

        [Test]
        public void Event_056_VerifyEventCreatedByOtherUser()
        {
            Global.MethodName = "Event_056_VerifyEventCreatedByOtherUser";

            //Create an Event
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(4));
            String eventName = readEvents.GetValue("AddEventDetails", "eventName");
            eventName = eventName + builder;
            CreateEvent(eventName);
            log.Info("Create a new Event.");
            Thread.Sleep(2000);

            //Signout of the application
            Thread.Sleep(5000);
            authenticationPage.SignOut();
            log.Info("Click on the Signout button.");

            //Sign in with a different user
            Thread.Sleep(2000);
            SignInDifferentUser();
            log.Info("Sign in with different user.");

            //Select Event
            //Click Events menu option
            Thread.Sleep(5000);
            eventsPage.ClickEventsMenu();
            log.Info("Click the Events menu option.");
            Thread.Sleep(5000);

            //Click the Event created
            eventsPage.ClickEventOnEventPage(eventName);
            log.Info("Click the Event Name on Events Page.");
            Thread.Sleep(2000);

            //Verify Event Name Dashboard
            eventsPage.VerifyEventNameDashboard(eventName);
            log.Info("Verify the Event Name on Dashboard.");
            Thread.Sleep(2000);

            //Verify Event Description Dashboard
            String eventDesc = readEvents.GetValue("AddEventDetails", "eventDesc");
            eventsPage.VerifyEventDescDashboard(eventDesc);
            log.Info("Verify the Event Description on Dashboard.");
            Thread.Sleep(2000);

            //Verify Join button
            eventsPage.VerifyJoinBtnDashboard();
            log.Info("Verify the Join button on Dashboard.");
            Thread.Sleep(2000);

            //Signout of the application
            Thread.Sleep(5000);
            authenticationPage.SignOut();
            log.Info("Click on the Signout button.");

            //Login to the application
            authenticationPage.SetUserName(_workEmail);
            authenticationPage.SetPassword(_password);
            authenticationPage.ClickOnLoginButton();
            authenticationPage.VerifyHomeScreen();

            //Select Event
            //Click Events menu option
            eventsPage.ClickEventsMenu();
            log.Info("Click the Events menu option.");
            Thread.Sleep(5000);

            //Click the All Events Dropdown option
            eventsPage.ClickAllEventsDropDown();
            log.Info("Click the All Events dropdown.");
            Thread.Sleep(2000);

            //Select My Events option
            eventsPage.ClickMyEventsDropDownOption();
            log.Info("Click the My Events dropdown option.");
            Thread.Sleep(2000);

            //Click the Event created
            eventsPage.ClickEventOnEventPage(eventName);
            log.Info("Click the Event Name on Events Page.");
            Thread.Sleep(2000);

            //Delete Event
            DeleteEvent();
        }

        [Test]
        public void Event_057_VerifyEventCreatedByOtherUser()
        {
            Global.MethodName = "Event_057_VerifyEventCreatedByOtherUser";

            //Create an Event
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(4));
            String eventName = readEvents.GetValue("AddEventDetails", "eventName");
            eventName = eventName + builder;
            CreateEvent(eventName);
            log.Info("Create a new Event.");
            Thread.Sleep(2000);

            //Signout of the application
            Thread.Sleep(5000);
            authenticationPage.SignOut();
            log.Info("Click on the Signout button.");

            //Sign in with a different user
            Thread.Sleep(2000);
            SignInDifferentUser();
            log.Info("Sign in with different user.");

            //Select Event
            //Click Events menu option
            Thread.Sleep(5000);
            eventsPage.ClickEventsMenu();
            log.Info("Click the Events menu option.");
            Thread.Sleep(5000);

            //Click the Event created
            eventsPage.ClickEventOnEventPage(eventName);
            log.Info("Click the Event Name on Events Page.");
            Thread.Sleep(2000);

            //Click Join button
            eventsPage.ClickJoinBtnDashboard();
            log.Info("Click the Join button on Dashboard.");
            Thread.Sleep(2000);

            //Assert Joined button
            eventsPage.VerifyJoinedBtnDashboard();
            log.Info("Verify the Joined button on Dashboard.");
            Thread.Sleep(2000);

            //Signout of the application
            Thread.Sleep(5000);
            authenticationPage.SignOut();
            log.Info("Click on the Signout button.");

            //Login to the application
            authenticationPage.SetUserName(_workEmail);
            authenticationPage.SetPassword(_password);
            authenticationPage.ClickOnLoginButton();
            authenticationPage.VerifyHomeScreen();

            //Select Event
            //Click Events menu option
            eventsPage.ClickEventsMenu();
            log.Info("Click the Events menu option.");
            Thread.Sleep(5000);

            //Click the All Events Dropdown option
            eventsPage.ClickAllEventsDropDown();
            log.Info("Click the All Events dropdown.");
            Thread.Sleep(2000);

            //Select My Events option
            eventsPage.ClickMyEventsDropDownOption();
            log.Info("Click the My Events dropdown option.");
            Thread.Sleep(2000);

            //Click the Event created
            eventsPage.ClickEventOnEventPage(eventName);
            log.Info("Click the Event Name on Events Page.");
            Thread.Sleep(2000);

            //Delete Event
            DeleteEvent();
        }

        [Test]
        public void Event_058_VerifyLeaveEventOptionByOtherUser()
        {
            Global.MethodName = "Event_058_VerifyLeaveEventOptionByOtherUser";

            //Create an Event
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(4));
            String eventName = readEvents.GetValue("AddEventDetails", "eventName");
            eventName = eventName + builder;
            CreateEvent(eventName);
            log.Info("Create a new Event.");
            Thread.Sleep(2000);

            //Signout of the application
            Thread.Sleep(5000);
            authenticationPage.SignOut();
            log.Info("Click on the Signout button.");

            //Sign in with a different user
            Thread.Sleep(2000);
            SignInDifferentUser();
            log.Info("Sign in with different user.");

            //Select Event
            //Click Events menu option
            Thread.Sleep(5000);
            eventsPage.ClickEventsMenu();
            log.Info("Click the Events menu option.");
            Thread.Sleep(5000);

            //Click the Event created
            eventsPage.ClickEventOnEventPage(eventName);
            log.Info("Click the Event Name on Events Page.");
            Thread.Sleep(2000);

            //Click Join button
            eventsPage.ClickJoinBtnDashboard();
            log.Info("Click the Join button on Dashboard.");
            Thread.Sleep(2000);

            //Refresh Page
            commonPage.RefreshPage();
            Thread.Sleep(5000);

            //Click Settings option
            Thread.Sleep(5000);
            groupsPage.ClickSettingsOption();
            log.Info("Click on the Settings option after Event is joined.");

            //Verify Settings Options value 'Leave Event'
            groupsPage.GetSettingsOptionsValues("Leave Event");
            log.Info("Verified Settings option value: 'Leave Event'");
            Thread.Sleep(2000);

            //Signout of the application
            Thread.Sleep(5000);
            authenticationPage.SignOut();
            log.Info("Click on the Signout button.");

            //Login to the application
            authenticationPage.SetUserName(_workEmail);
            authenticationPage.SetPassword(_password);
            authenticationPage.ClickOnLoginButton();
            authenticationPage.VerifyHomeScreen();

            //Select Event
            //Click Events menu option
            eventsPage.ClickEventsMenu();
            log.Info("Click the Events menu option.");
            Thread.Sleep(5000);

            //Click the All Events Dropdown option
            eventsPage.ClickAllEventsDropDown();
            log.Info("Click the All Events dropdown.");
            Thread.Sleep(2000);

            //Select My Events option
            eventsPage.ClickMyEventsDropDownOption();
            log.Info("Click the My Events dropdown option.");
            Thread.Sleep(2000);

            //Click the Event created
            eventsPage.ClickEventOnEventPage(eventName);
            log.Info("Click the Event Name on Events Page.");
            Thread.Sleep(2000);

            //Delete Event
            DeleteEvent();
        }

        /*[Test]
        public void Event_059_CreateDuplicateEvent()
        {
            Global.MethodName = "Event_059_CreateDuplicateEvent";

            //Click Events menu option
            eventsPage.ClickEventsMenu();
            log.Info("Click the Events menu option.");
            Thread.Sleep(5000);

            //Click New Event button
            eventsPage.ClickOnNewEventButton();
            log.Info("Click on New Event button.");
            Thread.Sleep(3000);

            //Enter the Event Name
            eventsPage.EnterEventName("Event Duplicate");
            log.Info("Enter the Event Name.");
            Thread.Sleep(2000);

            //Enter the Event Description
            String eventDesc = readEvents.GetValue("AddEventDetails", "eventDesc");
            eventsPage.EnterEventDescription(eventDesc);
            log.Info("Enter the Event Description.");
            Thread.Sleep(2000);

            //Click the Create button
            eventsPage.ClickOnCreateEventBtn();
            log.Info("Verify Create New Event Page.");
            Thread.Sleep(4000);

            //Click Events menu option
            eventsPage.ClickEventsMenu();
            log.Info("Click the Projects menu option.");
            Thread.Sleep(5000);

            //Click New Event button
            eventsPage.ClickOnNewEventButton();
            log.Info("Click on New Event button.");
            Thread.Sleep(3000);

            //Enter the Event Name
            eventsPage.EnterEventName("Event Duplicate");
            log.Info("Enter the Event Name.");
            Thread.Sleep(2000);

            //Enter the Event Description
            eventsPage.EnterEventDescription(eventDesc);
            log.Info("Enter the Event Description.");
            Thread.Sleep(2000);

            //Click the Create button
            eventsPage.ClickOnCreateEventBtn();
            log.Info("Verify Create New Event Page.");
            Thread.Sleep(4000);

            //Verify the error message displayed
            eventsPage.VerifyErrorMessage();
            log.Info("Verify the Error Message displayed.");
            Thread.Sleep(2000);

            //Select Event
            //Click Events menu option
            eventsPage.ClickEventsMenu();
            log.Info("Click the Events menu option.");
            Thread.Sleep(5000);

            //Click the All Events Dropdown option
            eventsPage.ClickAllEventsDropDown();
            log.Info("Click the All Events dropdown.");
            Thread.Sleep(2000);

            //Select My Events option
            eventsPage.ClickMyEventsDropDownOption();
            log.Info("Click the My Events dropdown option.");
            Thread.Sleep(2000);

            //Click the Event created
            eventsPage.ClickEventOnEventPage("Event Duplicate");
            log.Info("Click the Event Name on Events Page.");
            Thread.Sleep(2000);

            //Delete Event
            DeleteEvent();
        }*/

        [Test]
        public void Event_062_TryAddDuplicateMember()
        {
            Global.MethodName = "Event_062_TryAddDuplicateMember";

            //Create an Event
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(4));
            String eventName = readEvents.GetValue("AddEventDetails", "eventName");
            eventName = eventName + builder;
            CreateEvent(eventName);
            log.Info("Create a new Event.");
            Thread.Sleep(2000);

            //Click Settings option
            commonPage.ScrollUp();
            eventsPage.ClickSettingsOption();
            Thread.Sleep(2000);

            //Click Settings Options value 'Add Participants'
            eventsPage.ClickSettingsOptionsValues("Add Participants");
            log.Info("Click Settings option value: 'Add Participants'");
            Thread.Sleep(2000);

            //Enter the Event Member Email
            String addMemberEmail = readEvents.GetValue("AddEventMember", "addMemberEmail");
            eventsPage.EnterEventMember(addMemberEmail);
            log.Info("Entered " + addMemberEmail + " into Add Member Text field ");
            Thread.Sleep(5000);

            //Select user from suggestion
            String addMemberName = readEvents.GetValue("AddEventMember", "addMemberName");
            eventsPage.SelectUserfromSuggestion(addMemberName);
            log.Info("User selected successfully.");
            Thread.Sleep(5000);

            //Click the Add button
            groupsPage.ClickAddWindowAddButton();
            log.Info("Click on Add Window Add button.");
            Thread.Sleep(5000);

            //Click Settings option
            commonPage.ScrollUp();
            eventsPage.ClickSettingsOption();
            Thread.Sleep(2000);

            //Click Settings Options value 'Add Participants'
            eventsPage.ClickSettingsOptionsValues("Add Participants");
            log.Info("Click Settings option value: 'Add Participants'");
            Thread.Sleep(2000);

            //Enter the Event Member Email
            addMemberEmail = readEvents.GetValue("AddEventMember", "addMemberEmail");
            eventsPage.EnterEventMember(addMemberEmail);
            log.Info("Entered " + addMemberEmail + " into Add Member Text field ");
            Thread.Sleep(3000);

            //Verify same member is not displayed again
            eventsPage.VerifyUserfromSuggestionNotDisplayed(addMemberName);
            Thread.Sleep(4000);

            //Click Add member window close icon
            eventsPage.ClickAddWindMemberWindowCloseIcon();
            Thread.Sleep(2000);

            //Delete the Event
            DeleteEvent();
            Thread.Sleep(2000);
        }

    }
}