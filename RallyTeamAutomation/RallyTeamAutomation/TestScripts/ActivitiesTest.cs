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
    [Category("Activities")]
    public class ActivitiesTest : BaseTest
    {
        static ReadData readActivities = new ReadData("Activities");
        static ReadData readEvents = new ReadData("Events");
        static ReadData readGroups = new ReadData("Groups");
        static ReadData readProjects = new ReadData("Projects");

        //SignIn
        private void SignInDifferentUser()
        {
            String userName = readEvents.GetValue("SignInDifferentUser", "userName");
            String password = readEvents.GetValue("SignInDifferentUser", "password");
            authenticationPage.SetUserName(userName);
            authenticationPage.SetPassword(password);
            authenticationPage.ClickOnLoginButton();
        }

        //Create Event
        public void CreateEvent(String eventName)
        {
            //Create a new Event 
            Thread.Sleep(5000);
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

            //Click the Create button
            eventsPage.ClickOnCreateEventBtn();
            log.Info("Verify Create New Event Page.");
            Thread.Sleep(4000);
        }


        //Delete Event
        public void DeleteEvent()
        {
            //Click Events menu option
            eventsPage.ClickEventsMenu();
            log.Info("Click the Events menu option.");
            Thread.Sleep(8000);

            //Click the All Events Dropdown option
            eventsPage.ClickAllEventsDropDown();
            log.Info("Click the All Events dropdown.");
            Thread.Sleep(2000);

            //Select My Events option
            eventsPage.ClickMyEventsDropDownOption();
            log.Info("Click the My Events dropdown option.");
            Thread.Sleep(5000);

            //Click the Event created
            eventsPage.ClickEventOnEventPage("Event for Activity");
            log.Info("Click the Event Name on Events Page.");
            Thread.Sleep(5000);

            //Click Settings option
            commonPage.ScrollUp();
            Thread.Sleep(2000);
            eventsPage.ClickSettingsOption();
            log.Info("Click on the Settings option after Event is created.");

            //Click Settings Options value 'Delete Event'
            eventsPage.ClickSettingsOptionsValues("Delete Event");
            log.Info("Verified Settings option value: 'Delete Event'");
            Thread.Sleep(2000);

            //Click the Delete Event Window Yes Button
            eventsPage.PressDeleteEventWindowYesBtn();
            log.Info("Click the Delete Event Window Yes Button.");
            Thread.Sleep(2000);
        }

        //Creare Group
        public void CreateGroup(String groupName)
        {
            //Create a new Group 
            Thread.Sleep(5000);
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
            String groupDesc = readGroups.GetValue("AddPublicGroupDetails", "groupDesc");
            groupsPage.enterNewGroupDescription(groupDesc);

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
            Thread.Sleep(5000);

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
            Thread.Sleep(5000);

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

        public void CreateProject(String projectName)
        {
            //Click Projects menu option
            projectsPage.ClickProjectsMenu();
            Thread.Sleep(5000);

            //Click on Add Project button
            projectsPage.ClickOnAddProjectButton();
            log.Info("Click on the Add Project button at Projects page");
            Thread.Sleep(2000);

            //Enter the Project Name
            projectsPage.EnterProjectName(projectName);
            Thread.Sleep(2000);

            //Enter the Project Description
            String projectDesc = readProjects.GetValue("AddProjectDetails", "projectDesc");
            projectsPage.EnterProjectDescription(projectDesc);
            Thread.Sleep(2000);

            //Click on the create button at Add Project form
            projectsPage.ClickOnCreateProjectBtn();
            Thread.Sleep(2000);

            //Select Project Type
            String projectType = readProjects.GetValue("AddProjectDetails", "projectType");
            projectsPage.SelectProjectType(projectType);
            Thread.Sleep(2000);
        }

        //Delete Project
        public void DeleteProject(String projectName)
        {
            //Click Projects menu option
            projectsPage.ClickProjectsMenu();
            log.Info("Click the Projects menu option.");
            Thread.Sleep(5000);

            //Click the All Projects Dropdown option
            projectsPage.ClickAllProjectsDropDown();
            log.Info("Click the All Projects dropdown.");
            Thread.Sleep(2000);

            //Select I've Posted option from All Projects Dropdown
            projectsPage.SelectAllProjectsIvePosted();
            log.Info("Select I've Posted option from the All Projects dropdown.");
            Thread.Sleep(5000);

            //Click the created project
            projectsPage.ClickProjectNameOnPage(projectName);
            log.Info("Click the Project Name on the Projects Page.");
            Thread.Sleep(5000);

            //Click Delete Project Icon
            commonPage.ScrollUp();
            Thread.Sleep(3000);
            projectsPage.ClickDeleteProjectIcon();
            Thread.Sleep(2000);

            //Click the Delete Project Window Yes Button
            projectsPage.PressDeleteProjectWindowYesBtn();
            Thread.Sleep(2000);
        }


        [Test]
        public void Activities_001_VerifyActivitiesPage()
        {
            Global.MethodName = "Activities_001_VerifyActivitiesPage";

            //Click on the side navigation link 'Activities' 
            Thread.Sleep(5000);
            activitiesPage.clickActivitiesMenu();
            log.Info("Click on the side navigation link 'Activities'");

            //Verify Activity Feed Page
            activitiesPage.VerifyActivityFeedPage();
            log.Info("Verify Activity Feed Page is displayed.");
            Thread.Sleep(2000);
        }

        [Test]
        public void Activities_009_VerifyEventCreateActivity()
        {
            Global.MethodName = "Activities_009_VerifyEventCreateActivity";

            //Create Event
            Thread.Sleep(5000);
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(4));
            String eventName = "Event for Activity";
            eventName = eventName + builder;
            log.Info("Create a new Group");
            CreateEvent(eventName);

            //Click on the side navigation link 'Activities' 
            activitiesPage.clickActivitiesMenu();
            log.Info("Click on the side navigation link 'Activities'");
            Thread.Sleep(6000);

            //Verify Create Event Activity
            activitiesPage.VerifyCreateEventActivity();
            log.Info("Verify Create Event Activity is displayed.");
            Thread.Sleep(2000);

            //Verify Event Name Activity
            activitiesPage.VerifyNameActivity("Event for Activity");
            log.Info("Verify Create Event Activity is displayed.");
            Thread.Sleep(2000);

            //DeleteEvent
            DeleteEvent();
        }

        [Test]
        public void Activities_010_VerifyEventAddMemberActivity()
        {
            Global.MethodName = "Activities_010_VerifyEventAddMemberActivity";

            //Create Event
            Thread.Sleep(5000);
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(4));
            String eventName = "Event for Activity";
            eventName = eventName + builder;
            log.Info("Create a new Group");
            CreateEvent(eventName);

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
            Thread.Sleep(5000);

            //Click on the side navigation link 'Activities' 
            activitiesPage.clickActivitiesMenu();
            log.Info("Click on the side navigation link 'Activities'");
            Thread.Sleep(7000);

            //Verify Join Event Activity
            activitiesPage.VerifyJoinEventActivity();
            log.Info("Verify Join Event Activity is displayed.");
            Thread.Sleep(2000);

            //Verify Event Name Activity
            activitiesPage.VerifyNameActivity("Event for Activity");
            log.Info("Verify Create Event Activity is displayed.");
            Thread.Sleep(2000);

            //Verify User Name Activity
            activitiesPage.VerifyUserNameActivity(addMemberName);
            log.Info("Verify User Name Activity is displayed.");
            Thread.Sleep(2000);

            //Delete Event
            DeleteEvent();
        }

        [Test]
        public void Activities_011_VerifyEventJoinActivity()
        {
            Global.MethodName = "Activities_011_VerifyEventJoinActivity";

            //Create Event
            Thread.Sleep(5000);
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(4));
            String eventName = "Event for Activity";
            eventName = eventName + builder;
            log.Info("Create a new Group");
            CreateEvent(eventName);

            //Signout of the application
            Thread.Sleep(5000);
            authenticationPage.SignOut();
            log.Info("Click on the Signout button.");

            //Sign in with a different user
            Thread.Sleep(5000);
            SignInDifferentUser();
            log.Info("Sign in with different user.");

            //Select Event
            //Click Events menu option
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

            //Click on the side navigation link 'Activities' 
            activitiesPage.clickActivitiesMenu();
            log.Info("Click on the side navigation link 'Activities'");
            Thread.Sleep(3000);

            //Verify Join Event Activity
            activitiesPage.VerifyJoinEventActivity();
            log.Info("Verify Join Event Activity is displayed.");
            Thread.Sleep(2000);

            //Verify Event Name Activity
            activitiesPage.VerifyNameActivity("Event for Activity");
            log.Info("Verify Create Event Activity is displayed.");
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

            //Delete Event
            DeleteEvent();
        }

        [Test]
        public void Activities_013_VerifyGroupCreateActivity()
        {
            Global.MethodName = "Activities_013_VerifyGroupCreateActivity";

            //Create Group
            Thread.Sleep(5000);
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(4));
            String groupName = "Group for Activity";
            groupName = groupName + builder;
            log.Info("Create a new Group");
            CreateGroup(groupName);
            Thread.Sleep(5000);

            //Click on the side navigation link 'Activities' 
            activitiesPage.clickActivitiesMenu();
            log.Info("Click on the side navigation link 'Activities'");
            Thread.Sleep(5000);

            //Verify Create Group Activity
            activitiesPage.VerifyCreateGroupActivity();
            log.Info("Verify Create Event Activity is displayed.");
            Thread.Sleep(2000);

            //Verify Group Name Activity
            activitiesPage.VerifyNameActivity(groupName);
            log.Info("Verify Group Name Activity is displayed.");
            Thread.Sleep(2000);

            //Delete Group
            DeleteGroup(groupName);
        }

        [Test]
        public void Activities_014_VerifyGroupAddMemberActivity()
        {
            Global.MethodName = "Activities_014_VerifyGroupAddMemberActivity";

            //Create Group
            Thread.Sleep(5000);
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(4));
            String groupName = "Group for Activity";
            groupName = groupName + builder;
            log.Info("Create a new Group");
            CreateGroup(groupName);

            //Click Add Group Member Icon
            groupsPage.ClickOnAddMemberIcon();
            log.Info("Click on the Add Member Icon after Group is created.");
            Thread.Sleep(3000);

            //Enter the Group Member Name
            String addMemberName = readGroups.GetValue("AddGroupMember", "addMemberName");
            groupsPage.EnterGroupMemberEmail(addMemberName);
            Thread.Sleep(3000);

            //Press Enter Key
            eventsPage.PressEnterKey();
            Thread.Sleep(2000);

            //Click the Add button
            groupsPage.ClickAddWindowAddButton();
            log.Info("Click on Add Window Add button.");
            Thread.Sleep(5000);

            //Click on the side navigation link 'Activities' 
            activitiesPage.clickActivitiesMenu();
            log.Info("Click on the side navigation link 'Activities'");
            Thread.Sleep(5000);

            //Verify Join Group Activity
            activitiesPage.VerifyJoinGroupActivity();
            log.Info("Verify Join Group Activity is displayed.");
            Thread.Sleep(2000);

            //Verify Group Name Activity
            activitiesPage.VerifyNameActivity(groupName);
            log.Info("Verify Create Group Activity is displayed.");
            Thread.Sleep(2000);

            //Verify User Name Activity
            activitiesPage.VerifyUserNameActivity(addMemberName);
            log.Info("Verify User Name Activity is displayed.");
            Thread.Sleep(2000);

            //Delete Group
            DeleteGroup(groupName);
        }

        [Test]
        public void Activities_015_VerifyGroupJoinActivity()
        {
            Global.MethodName = "Activities_015_VerifyGroupJoinActivity";

            //Create Group
            Thread.Sleep(5000);
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(4));
            String groupName = "Group for Activity";
            groupName = groupName + builder;
            log.Info("Create a new Group");
            CreateGroup(groupName);

            //Signout of the application
            Thread.Sleep(7000);
            authenticationPage.SignOut();
            log.Info("Click on the Signout button.");

            //Sign in with a different user
            Thread.Sleep(2000);
            SignInDifferentUser();
            log.Info("Sign in with different user.");

            //Select Group
            //Click Groups menu option
            groupsPage.clickGroupsMenu();
            log.Info("Click the Groups menu option.");
            Thread.Sleep(5000);

            //Click the Group created
            //commonPage.ScrollDown();
            Thread.Sleep(2000);
            groupsPage.ClickGroupOnGroupPage(groupName);
            log.Info("Click the Group Name on Groups Page.");
            Thread.Sleep(2000);

            //Click Join button
            groupsPage.ClickJoinBtn();
            log.Info("Click the Join button on Dashboard.");
            Thread.Sleep(2000);

            //Click on the side navigation link 'Activities' 
            activitiesPage.clickActivitiesMenu();
            log.Info("Click on the side navigation link 'Activities'");
            Thread.Sleep(3000);

            //Verify Join Group Activity
            activitiesPage.VerifyJoinGroupActivity();
            log.Info("Verify Join Group Activity is displayed.");
            Thread.Sleep(2000);

            //Verify Group Name Activity
            activitiesPage.VerifyNameActivity(groupName);
            log.Info("Verify Create Group Activity is displayed.");
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

            //Delete Group
            DeleteGroup(groupName);
        }

        [Test]
        public void Activities_017_VerifyProjectCreateActivity()
        {
            Global.MethodName = "Activities_017_VerifyProjectCreateActivity";

            //Create a new project
            Thread.Sleep(5000);
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(4));
            String projectName = "Activity Project";
            projectName = projectName + builder;
            CreateProject(projectName);

            //Click on the side navigation link 'Activities' 
            activitiesPage.clickActivitiesMenu();
            log.Info("Click on the side navigation link 'Activities'");
            Thread.Sleep(3000);

            //Verify Create Project Activity
            activitiesPage.VerifyCreateProjectActivity();
            log.Info("Verify Create Project Activity is displayed.");
            Thread.Sleep(2000);

            //Verify Project Name Activity
            activitiesPage.VerifyNameActivity(projectName);
            log.Info("Verify Project Name Activity is displayed.");
            Thread.Sleep(2000);

            //Delete Project
            DeleteProject(projectName);
        }

        /*[Test]
        public void Activities_018_VerifyProjectAddMemberActivity()
        {
            Global.MethodName = "Activities_018_VerifyProjectAddMemberActivity";

            //Create a new project
            Thread.Sleep(5000);
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(4));
            String projectName = "Activity Project";
            projectName = projectName + builder;
            CreateProject(projectName);

            //Click on Add member icon
            Thread.Sleep(3000);
            projectsPage.ClickAddMemberIcon();
            log.Info("Click the Add member icon for the Project.");

            //Enter the Project Member Name
            Thread.Sleep(4000);
            String addMemberName = readProjects.GetValue("AddProjectMember", "addMemberName");
            projectsPage.EnterProjectMemberEmail(addMemberName);

            //Press Enter Key
            eventsPage.PressEnterKey();
            Thread.Sleep(2000);

            //Click the Add Project Member window Done button
            Thread.Sleep(2000);
            projectsPage.ClickAddProjectMemberDoneBtn();
            log.Info("Click the Add Project Member window Done button.");
            Thread.Sleep(4000);

            //Click on the side navigation link 'Activities' 
            activitiesPage.clickActivitiesMenu();
            log.Info("Click on the side navigation link 'Activities'");
            Thread.Sleep(3000);

            //Verify Join Project Activity
            activitiesPage.VerifyJoinProjectActivity();
            log.Info("Verify Join Project Activity is displayed.");
            Thread.Sleep(2000);

            //Verify Project Name Activity
            activitiesPage.VerifyNameActivity(projectName);
            log.Info("Verify Create Project Activity is displayed.");
            Thread.Sleep(2000);

            //Verify User Name Activity
            activitiesPage.VerifyUserNameActivity(addMemberName);
            log.Info("Verify User Name Activity is displayed.");
            Thread.Sleep(2000);

            //Delete Project
            DeleteProject(projectName);
        }*/

        /*[Test]
        public void Activities_019_VerifyProjectJoinActivity()
        {
            Global.MethodName = "Activities_019_VerifyProjectJoinActivity";

            //Create a new project
            Thread.Sleep(5000);
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(4));
            String projectName = "Activity Project";
            projectName = projectName + builder;
            CreateProject(projectName);

            //Signout of the application
            Thread.Sleep(5000);
            authenticationPage.SignOut();
            log.Info("Click on the Signout button.");

            //Sign in with a different user
            Thread.Sleep(2000);
            SignInDifferentUser();
            log.Info("Sign in with different user.");

            //Select Projects
            //Click Projects menu option
            projectsPage.ClickProjectsMenu();
            log.Info("Click the Projects menu option.");
            Thread.Sleep(5000);

            //Click the All Projects Dropdown option
            projectsPage.ClickAllProjectsDropDown();
            log.Info("Click the All Projects dropdown.");
            Thread.Sleep(2000);

            //Select Recruiting option from All Projects Dropdown
            projectsPage.SelectAllProjectsRecruiting();
            log.Info("Select Recruiting option from the All Projects dropdown.");
            Thread.Sleep(2000);

            //Click the created project
            projectsPage.ClickProjectNameOnPage(projectName);
            log.Info("Click the Project Name on the Projects Page.");
            Thread.Sleep(3000);

            //Click Request to Join button displayed on the screen
            projectsPage.ClickRequestToJoinBtn();
            log.Info("Click Request To Join button doisplayed on screen.");
            Thread.Sleep(3000);

            //Signout of the application
            Thread.Sleep(5000);
            authenticationPage.SignOut();
            log.Info("Click on the Signout button.");

            //Login to the application
            authenticationPage.SetUserName(_workEmail);
            authenticationPage.SetPassword(_password);
            authenticationPage.ClickOnLoginButton();
            authenticationPage.VerifyHomeScreen();

            //Click Projects menu option
            projectsPage.ClickProjectsMenu();
            log.Info("Click the Projects menu option.");
            Thread.Sleep(5000);

            //Click the All Projects Dropdown option
            projectsPage.ClickAllProjectsDropDown();
            log.Info("Click the All Projects dropdown.");
            Thread.Sleep(2000);

            //Select Recruiting Posted option from All Projects Dropdown
            projectsPage.SelectAllProjectsRecruiting();
            log.Info("Select 'Recruiting' option from the All Projects dropdown.");
            Thread.Sleep(3000);

            //Click the created project
            projectsPage.ClickProjectNameOnPage(projectName);
            log.Info("Click the Project Name on the Projects Page.");
            Thread.Sleep(3000);

            //Select the Requested Member Icon
            projectsPage.ClickRequestedMember();
            log.Info("Click the Requested Member of the Project.");
            Thread.Sleep(3000);

            //Click on the Accept icon of the Pending Request window
            commonPage.ScrollDown();
            Thread.Sleep(2000);
            projectsPage.AcceptRequestedMember();
            log.Info("Accept the Requested member.");
            Thread.Sleep(3000);

            //Click on the side navigation link 'Activities' 
            activitiesPage.clickActivitiesMenu();
            log.Info("Click on the side navigation link 'Activities'");
            Thread.Sleep(3000);

            //Verify Join Project Activity
            activitiesPage.VerifyJoinProjectActivity();
            log.Info("Verify Join Project Activity is displayed.");
            Thread.Sleep(2000);

            //Verify Project Name Activity
            activitiesPage.VerifyNameActivity(projectName);
            log.Info("Verify Create Project Activity is displayed.");
            Thread.Sleep(2000);

            //Delete Project
            DeleteProject(projectName);
        }*/

        [Test]
        public void Activities_020_VerifyProjectCompleteActivity()
        {
            Global.MethodName = "Activities_020_VerifyProjectCompleteActivity";

            //Create a new project
            Thread.Sleep(5000);
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(4));
            String projectName = "Activity Project";
            projectName = projectName + builder;
            CreateProject(projectName);
            Thread.Sleep(5000);

            //Select Project status as Completed
            projectsPage.SelectStatusDropDown("Completed");
            log.Info("Select Project status as 'Completed'");
            Thread.Sleep(5000);

            //Click on Mark Complete button
            projectsPage.ClickMarkComplete();
            log.Info("Click Mark Complete button.");
            Thread.Sleep(3000);

            //Click on the side navigation link 'Activities' 
            activitiesPage.clickActivitiesMenu();
            log.Info("Click on the side navigation link 'Activities'");
            Thread.Sleep(5000);

            //Verify Complete Project Activity
            activitiesPage.VerifyCompleteProjectActivity();
            log.Info("Verify Complete Project Activity is displayed.");
            Thread.Sleep(2000);

            //Verify Project Name Activity
            activitiesPage.VerifyNameActivity(projectName);
            log.Info("Verify Create Project Activity is displayed.");
            Thread.Sleep(2000);

            //Delete Project
            //Click Projects menu option
            projectsPage.ClickProjectsMenu();
            log.Info("Click the Projects menu option.");
            Thread.Sleep(5000);

            //Click the All Projects Dropdown option
            projectsPage.ClickAllProjectsDropDown();
            log.Info("Click the All Projects dropdown.");
            Thread.Sleep(2000);

            //Select Completed Posted option from All Projects Dropdown
            projectsPage.SelectAllProjectsCompleted();
            log.Info("Select Completed option from the All Projects dropdown.");
            Thread.Sleep(5000);

            //Click the created project
            projectsPage.ClickProjectNameOnPage(projectName);
            log.Info("Click the Project Name on the Projects Page.");
            Thread.Sleep(3000);

            //Click Delete Project Icon
            commonPage.ScrollUp();
            Thread.Sleep(3000);
            projectsPage.ClickDeleteProjectIcon();
            Thread.Sleep(2000);

            //Click the Delete Project Window Yes Button
            projectsPage.PressDeleteProjectWindowYesBtn();
            Thread.Sleep(2000);
        }

        [Test]
        public void Activities_002_VerifyEditDeleteOptions()
        {
            Global.MethodName = "Activities_002_VerifyEditDeleteOptions";

            //Create a new project
            Thread.Sleep(5000);
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(4));
            String projectName = "Activity Project";
            projectName = projectName + builder;
            CreateProject(projectName);
            Thread.Sleep(5000);

            //Click on the side navigation link 'Activities' 
            activitiesPage.clickActivitiesMenu();
            log.Info("Click on the side navigation link 'Activities'");
            Thread.Sleep(3000);

            //Verify Project Name Activity
            activitiesPage.VerifyNameActivity(projectName);
            log.Info("Verify Create Project Activity is displayed.");
            Thread.Sleep(2000);

            //Click the Edit Icon
            activitiesPage.ClickEditActivityIcon();
            log.Info("Click the Edit Activity Icon");
            Thread.Sleep(2000);

            //Verify the Edit Message option
            activitiesPage.VerifyEditMessageOption();
            Thread.Sleep(2000);

            //Verify the Delete Message option
            activitiesPage.VerifyDeleteMessageOption();
            Thread.Sleep(2000);

            //Delete Project
            DeleteProject(projectName);
        }

        [Test]
        public void Activities_003_ClickEditMessageAndVerify()
        {
            Global.MethodName = "Activities_003_ClickEditMessageAndVerify";

            //Create a new project
            Thread.Sleep(5000);
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(4));
            String projectName = "Activity Project";
            projectName = projectName + builder;
            CreateProject(projectName);
            Thread.Sleep(5000);

            //Click on the side navigation link 'Activities'
            activitiesPage.clickActivitiesMenu();
            log.Info("Click on the side navigation link 'Activities'");
            Thread.Sleep(3000);

            //Verify Project Name Activity
            activitiesPage.VerifyNameActivity(projectName);
            log.Info("Verify Create Project Activity is displayed.");
            Thread.Sleep(2000);

            //Click the Edit Icon
            activitiesPage.ClickEditActivityIcon();
            log.Info("Click the Edit Activity Icon");
            Thread.Sleep(2000);

            //Click the Edit Message option
            activitiesPage.ClickEditMessageOption();
            Thread.Sleep(2000);

            //Verify the Edit Div Text Area
            activitiesPage.VerifyEditDivTextArea();
            Thread.Sleep(2000);

            //Verify the Edit Div Attachment Icon
            activitiesPage.VerifyEditDivAttachmentIcon();
            Thread.Sleep(2000);

            //Verify the Edit Div Cancel Button
            activitiesPage.VerifyEditDivCancelBtn();
            Thread.Sleep(2000);

            //Verify the Edit Div Post Button
            activitiesPage.VerifyEditDivPostButton();
            Thread.Sleep(2000);

            //Delete Project
            DeleteProject(projectName);
        }

        [Test]
        public void Activities_004_ClickEditMessageAndPost()
        {
            Global.MethodName = "Activities_004_ClickEditMessageAndPost";

            //Create a new project
            Thread.Sleep(5000);
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(4));
            String projectName = "Activity Project";
            projectName = projectName + builder;
            CreateProject(projectName);
            Thread.Sleep(5000);

            //Click on the side navigation link 'Activities'
            activitiesPage.clickActivitiesMenu();
            log.Info("Click on the side navigation link 'Activities'");
            Thread.Sleep(3000);

            //Verify Project Name Activity
            activitiesPage.VerifyNameActivity(projectName);
            log.Info("Verify Create Project Activity is displayed.");
            Thread.Sleep(2000);

            //Click the Edit Icon
            activitiesPage.ClickEditActivityIcon();
            log.Info("Click the Edit Activity Icon");
            Thread.Sleep(2000);

            //Click the Edit Message option
            activitiesPage.ClickEditMessageOption();
            Thread.Sleep(2000);

            //Verify the Edit Div Text Area
            activitiesPage.VerifyEditDivTextArea();
            Thread.Sleep(2000);

            //Enter message in Edit Div Area
            activitiesPage.EnterEditDivTextArea("Activity Message");
            Thread.Sleep(2000);

            //Click the Edit Div Post Button
            activitiesPage.ClickEditDivPostButton();
            Thread.Sleep(2000);

            //Delete Project
            DeleteProject(projectName);
        }
        /*
        [Test]
        public void Activities_008_VerifyEditIconForOtherUserActivity()
        {
            //Create Project
            CreateProject();
            Thread.Sleep(5000);

            //Signout of the application
            Thread.Sleep(5000);
            authenticationPage.SignOut();
            log.Info("Click on the Signout button.");

            //Sign in with a different user
            Thread.Sleep(2000);
            SignInDifferentUser();
            log.Info("Sign in with different user.");

            //Click on the side navigation link 'Activities' 
            activitiesPage.clickActivitiesMenu();
            log.Info("Click on the side navigation link 'Activities'");
            Thread.Sleep(3000);

            //Verify Project Name Activity
            activitiesPage.VerifyNameActivity("Project Activity");
            log.Info("Verify Create Project Activity is displayed.");
            Thread.Sleep(2000);

            //Verify the Edit Icon not displayed
            activitiesPage.VerifyEditActivityIconNotDisplayed();
            log.Info("Verify the Edit Activity Icon is not displayed.");
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

            //Delete Project
            DeleteProject();
        }*/

        [Test]
        public void Activities_023_ClickEditMessageAndPost()
        {
            Global.MethodName = "Activities_023_ClickEditMessageAndPost";

            //Create a new project
            Thread.Sleep(5000);
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(4));
            String projectName = "Activity Project";
            projectName = projectName + builder;
            CreateProject(projectName);
            Thread.Sleep(5000);

            //Click on the side navigation link 'Activities'
            activitiesPage.clickActivitiesMenu();
            log.Info("Click on the side navigation link 'Activities'");
            Thread.Sleep(3000);

            //Verify Project Name Activity
            activitiesPage.VerifyNameActivity(projectName);
            log.Info("Verify Create Project Activity is displayed.");
            Thread.Sleep(2000);

            //Click the Edit Icon
            activitiesPage.ClickEditActivityIcon();
            log.Info("Click the Edit Activity Icon");
            Thread.Sleep(2000);

            //Click the Edit Message option
            activitiesPage.ClickEditMessageOption();
            Thread.Sleep(2000);

            //Verify the Edit Div Text Area
            activitiesPage.VerifyEditDivTextArea();
            Thread.Sleep(2000);

            //Enter message in Edit Div Area
            activitiesPage.EnterEditDivTextArea("Activity Message");
            Thread.Sleep(2000);

            //Click the Edit Div Post Button
            activitiesPage.ClickEditDivPostButton();
            Thread.Sleep(2000);

            //Delete Project
            DeleteProject(projectName);
        }

        [Test]
        public void Activities_024_ClickDeleteMessage()
        {
            Global.MethodName = "Activities_024_ClickDeleteMessage";

            //Create a new project
            Thread.Sleep(5000);
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(4));
            String projectName = "Activity Project";
            projectName = projectName + builder;
            CreateProject(projectName);
            Thread.Sleep(5000);

            //Click on the side navigation link 'Activities'
            activitiesPage.clickActivitiesMenu();
            log.Info("Click on the side navigation link 'Activities'");
            Thread.Sleep(5000);

            //Verify Project Name Activity
            activitiesPage.VerifyNameActivity(projectName);
            log.Info("Verify Create Project Activity is displayed.");
            Thread.Sleep(2000);

            //Click the Edit Icon
            activitiesPage.ClickEditActivityIcon();
            log.Info("Click the Edit Activity Icon");
            Thread.Sleep(2000);

            //Click the Delete Message option
            activitiesPage.ClickDeleteMessageOption();
            Thread.Sleep(5000);

            //Verify the Activity is not displayed anymore
            activitiesPage.VerifyNameActivityNotDisplayed(projectName);
            Thread.Sleep(2000);

            //Delete Project
            DeleteProject(projectName);
        }
    }
}
