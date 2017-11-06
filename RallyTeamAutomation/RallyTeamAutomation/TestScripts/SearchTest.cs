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
    [Category("Search")]
    public class SearchTest : BaseTest
    {
        static ReadData readSearch = new ReadData("Search");

        //SignIn
        private void SignInDifferentUser()
        {
            String userName = readSearch.GetValue("SignInDifferentUser", "userName");
            String password = readSearch.GetValue("SignInDifferentUser", "password");
            authenticationPage.SetUserName(userName);
            authenticationPage.SetPassword(password);
            authenticationPage.ClickOnLoginButton();
        }

        [Test]
        public void Search_001_VerifySearchOption()
        {
            Global.MethodName = "Search_001_VerifySearchOption";
            Thread.Sleep(2000);
            searchPage.VerifySearchMenuOption();
            log.Info("Verify Search menu icon");
        }

        [Test]
        public void Search_002_SearchLoggedInUser()
        {
            Global.MethodName = "Search_002_SearchLoggedInUser";
            Thread.Sleep(5000);

            //Get UserName
            String userName = readSearch.GetValue("Search", "loggedUser");

            //Enter Search menu option
            searchPage.EnterSearchMenuOption(userName);
            log.Info("Enter the Search option.");
            Thread.Sleep(1000);

            //Press Enter Key
            searchPage.PressEnterKey();
            Thread.Sleep(5000);

            //Verify Search Page is displayed
            searchPage.VerifySearchPage();
            log.Info("Verify the Search Page is displayed.");
            Thread.Sleep(1000);

            //Verify the Search Result is displayed
            searchPage.VerifySearchResult(userName);
            log.Info("Verify the Search highlighted result.");
            Thread.Sleep(2000);
        }

        [Test]
        public void Search_008_VerifyForZeroResult()
        {
            Global.MethodName = "Search_008_VerifyForZeroResult";
            Thread.Sleep(2000);

            //Enter Search menu option
            searchPage.EnterSearchMenuOption("sdfhdsjkfhdsf");
            log.Info("Enter the Search option.");
            Thread.Sleep(1000);

            //Press Enter Key
            searchPage.PressEnterKey();
            Thread.Sleep(5000);

            /*//Select All Radio button
            searchPage.ClickAllRadio();
            log.Info("Select All Radio button.");
            Thread.Sleep(2000);*/

            //Verify the Zero Search Results are displayed
            searchPage.VerifyZeroSearch();
            log.Info("Verify zero results displayed.");
            Thread.Sleep(2000);
        }

        [Test]
        public void Search_009_VerifySearchScreenDisplay()
        {
            Global.MethodName = "Search_009_VerifySearchScreenDisplay";
            Thread.Sleep(5000);

            //Get UserName
            String userName = readSearch.GetValue("Search", "loggedUser");

            //Enter Search menu option
            searchPage.EnterSearchMenuOption(userName);
            log.Info("Enter the Search option.");
            Thread.Sleep(1000);

            //Press Enter Key
            searchPage.PressEnterKey();
            Thread.Sleep(5000);

            //Verify Search text field is displayed
            searchPage.VerifySearchField();
            log.Info("Verify Search Text Field is displayed.");
            Thread.Sleep(2000);

            //Verify Search button field is displayed
            searchPage.VerifySearchBtn();
            log.Info("Verify Search button Field is displayed.");
            Thread.Sleep(1000);

            /*//Verify All Radio button is displayed
            searchPage.VerifyAllRadioBtn();
            log.Info("Verify All Radio button is displayed.");
            Thread.Sleep(1000);

            //Verify Users Radio button is displayed
            searchPage.VerifyUsersRadioBtn();
            log.Info("Verify Users Radio button is displayed.");
            Thread.Sleep(1000);

            //Verify Groups Radio button is displayed
            searchPage.VerifyGroupsRadioBtn();
            log.Info("Verify Groups Radio button is displayed.");
            Thread.Sleep(1000);

            //Verify Events Radio button is displayed
            searchPage.VerifyEventsRadioBtn();
            log.Info("Verify Events Radio button is displayed.");
            Thread.Sleep(1000);

            //Verify Projects Radio button is displayed
            searchPage.VerifyProjectsRadioBtn();
            log.Info("Verify Projects Radio button is displayed.");
            Thread.Sleep(1000);*/
        }

        /*[Test]
        public void Search_012_VerifyAllRadio()
        {
            Global.MethodName = "Search_012_VerifyAllRadio";
            Thread.Sleep(5000);

            //Get UserName
            String userName = readSearch.GetValue("Search", "loggedUser");

            //Enter Search menu option
            searchPage.EnterSearchMenuOption(userName);
            log.Info("Enter the Search option.");
            Thread.Sleep(1000);

            //Press Enter Key
            searchPage.PressEnterKey();
            Thread.Sleep(5000);

            //Select All Radio button
            searchPage.ClickAllRadio();
            log.Info("Select All Radio button.");
            Thread.Sleep(2000);

            //Verify the Search Result is displayed
            searchPage.VerifySearchResult(userName);
            log.Info("Verify the Search highlighted result.");
            Thread.Sleep(2000);
        }*/

        [Test]
        public void Search_013_VerifyGroupRadio()
        {
            Global.MethodName = "Search_013_VerifyGroupRadio";
            Thread.Sleep(2000);

            //Create Group
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(5));
            String groupName = readSearch.GetValue("Search", "groupName");
            groupName = groupName + builder;
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
            Thread.Sleep(3000);

            //Enter Search menu option
            searchPage.EnterSearchMenuOption(groupName);
            log.Info("Enter the Search option.");
            Thread.Sleep(1000);

            //Press Enter Key
            searchPage.PressEnterKey();
            Thread.Sleep(5000);

            /*//Select Group Radio button
            searchPage.ClickGroupRadio();
            log.Info("Select Group Radio button.");
            Thread.Sleep(2000);*/

            //Verify the Search Result is displayed
            searchPage.VerifySearchResult(groupName);
            log.Info("Verify the Search highlighted result.");
            Thread.Sleep(2000);

            //Delete Group
            groupsPage.clickGroupsMenu();
            log.Info("Click on the side navigation link 'Groups'");
            Thread.Sleep(3000);

            //Click the Group created
            groupsPage.ClickGroupOnGroupPage(groupName);
            Thread.Sleep(3000);

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

        [Test]
        public void Search_014_VerifyUserRadio()
        {
            Global.MethodName = "Search_014_VerifyUserRadio";
            Thread.Sleep(5000);

            //Get UserName
            String userName = readSearch.GetValue("Search", "loggedUser");

            //Enter Search menu option
            searchPage.EnterSearchMenuOption(userName);
            log.Info("Enter the Search option.");
            Thread.Sleep(1000);

            //Press Enter Key
            searchPage.PressEnterKey();
            Thread.Sleep(5000);

            /*//Select Users Radio button
            searchPage.ClickUsersRadio();
            log.Info("Select Users Radio button.");
            Thread.Sleep(2000);

            //Verify the Search Result is displayed
            searchPage.VerifySearchResult(userName);
            log.Info("Verify the Search highlighted result.");
            Thread.Sleep(2000);*/
        }

        [Test]
        public void Search_015_VerifyEventsRadio()
        {
            Global.MethodName = "Search_015_VerifyEventsRadio";
            Thread.Sleep(2000);

            //Create Event
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(5));
            String eventName = readSearch.GetValue("Search", "eventName");
            eventName = eventName + builder;

            //Click Events menu option
            eventsPage.ClickEventsMenu();
            log.Info("Click the Events menu option.");
            Thread.Sleep(3000);

            //Click New Event button
            eventsPage.ClickOnNewEventButton();
            log.Info("Click on New Event button.");
            Thread.Sleep(3000);

            //Enter the Event Name
            eventsPage.EnterEventName(eventName);
            log.Info("Enter the Event Name.");
            Thread.Sleep(2000);

            //Enter the Event Description
            eventsPage.EnterEventDescription("Event Desc");
            log.Info("Enter the Event Description.");
            Thread.Sleep(2000);

            //Click the Create button
            eventsPage.ClickOnCreateEventBtn();
            log.Info("Verify Create New Event Page.");
            Thread.Sleep(4000);

            //Enter Search menu option
            searchPage.EnterSearchMenuOption(eventName);
            log.Info("Enter the Search option.");
            Thread.Sleep(1000);

            //Press Enter Key
            searchPage.PressEnterKey();
            Thread.Sleep(5000);

            /*//Select Events Radio button
            searchPage.ClickEventsRadio();
            log.Info("Select Events Radio button.");
            Thread.Sleep(2000);*/

            //Verify the Search Result is displayed
            searchPage.VerifySearchResult(eventName);
            log.Info("Verify the Search highlighted result.");
            Thread.Sleep(2000);

            //Delete Event
            eventsPage.ClickEventsMenu();
            log.Info("Click on the side navigation link 'Events'");
            Thread.Sleep(3000);

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

        [Test]
        public void Search_016_VerifyProjectsRadio()
        {
            Global.MethodName = "Search_016_VerifyProjectsRadio";
            Thread.Sleep(2000);

            //Create Project
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(5));
            String projectName = readSearch.GetValue("Search", "projectName");
            projectName = projectName + builder;

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
            projectsPage.EnterProjectDescription("Project Desc");
            Thread.Sleep(2000);

            //Click on the create button at Add Project form
            projectsPage.ClickOnCreateProjectBtn();
            Thread.Sleep(2000);

            //Select Project Type
            projectsPage.SelectProjectType("Just for Me");
            Thread.Sleep(8000);

            //Enter Search menu option
            searchPage.EnterSearchMenuOption(projectName);
            log.Info("Enter the Search option.");
            Thread.Sleep(1000);

            //Press Enter Key
            searchPage.PressEnterKey();
            Thread.Sleep(5000);

            /*//Select Projects Radio button
            searchPage.ClickProjectsRadio();
            log.Info("Select Projects Radio button.");
            Thread.Sleep(2000);*/

            //Verify the Search Result is displayed
            searchPage.VerifySearchResult(projectName);
            log.Info("Verify the Search highlighted result.");
            Thread.Sleep(2000);

            //Delete Project
            //Click Projects menu option
            projectsPage.ClickProjectsMenu();
            Thread.Sleep(5000);

            //Click the All Projects Dropdown option
            projectsPage.ClickAllProjectsDropDown();
            log.Info("Click the All Projects dropdown.");
            Thread.Sleep(2000);

            //Select I've Posted option from All Projects Dropdown
            projectsPage.SelectAllProjectsIvePosted();
            log.Info("Select I've Posted option from the All Projects dropdown.");
            Thread.Sleep(2000);

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

        /*[Test]
        public void Search_022_SearchEmptyData()
        {
            Global.MethodName = "Search_022_SearchEmptyData";
            Thread.Sleep(2000);

            //Enter Search menu option
            String emptySearch = readSearch.GetValue("Search", "emptySearch"); ;
            searchPage.EnterSearchMenuOption(emptySearch);
            log.Info("Enter the Search option.");
            Thread.Sleep(1000);

            //Press Enter Key
            searchPage.PressEnterKey();
            Thread.Sleep(5000);

            //Verify Search Page is displayed
            searchPage.VerifySearchPage();
            log.Info("Verify the Search Page is displayed.");
            Thread.Sleep(1000);

            //Verify the Empty Result Message
            searchPage.VerifyEmptySearchMsg();
            log.Info("Verify the empty result message.");
            Thread.Sleep(2000);
        }*/

        [Test]
        public void Search_023_VerifyNumberSearch()
        {
            Global.MethodName = "Search_023_VerifyNumberSearch";
            Thread.Sleep(2000);

            //Create Project
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(5));
            String projectName = "12345";
            projectName = projectName + builder;

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
            projectsPage.EnterProjectDescription("Project Desc");
            Thread.Sleep(2000);

            //Click on the create button at Add Project form
            projectsPage.ClickOnCreateProjectBtn();
            Thread.Sleep(2000);

            //Select Project Type
            projectsPage.SelectProjectType("Just for Me");
            Thread.Sleep(10000);

            //Enter Search menu option
            searchPage.EnterSearchMenuOption("12345");
            log.Info("Enter the Search option.");
            Thread.Sleep(1000);

            //Press Enter Key
            searchPage.PressEnterKey();
            Thread.Sleep(10000);

            /*//Select Projects Radio button
            searchPage.ClickProjectsRadio();
            log.Info("Select Projects Radio button.");
            Thread.Sleep(2000);*/

            //Verify the Search Result is displayed
            searchPage.VerifySearchResult("12345");
            log.Info("Verify the Search highlighted result.");
            Thread.Sleep(2000);

            //Delete Project
            //Click Projects menu option
            projectsPage.ClickProjectsMenu();
            Thread.Sleep(5000);

            //Click the All Projects Dropdown option
            projectsPage.ClickAllProjectsDropDown();
            log.Info("Click the All Projects dropdown.");
            Thread.Sleep(2000);

            //Select I've Posted option from All Projects Dropdown
            projectsPage.SelectAllProjectsIvePosted();
            log.Info("Select I've Posted option from the All Projects dropdown.");
            Thread.Sleep(2000);

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
        public void Search_024_VerifySearchForNonExistingItem()
        {
            Global.MethodName = "Search_024_VerifySearchForNonExistingItem";
            Thread.Sleep(2000);

            //Create Project
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(5));
            String projectName = readSearch.GetValue("Search", "projectName");
            projectName = projectName + builder;

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
            projectsPage.EnterProjectDescription("Project Desc");
            Thread.Sleep(2000);

            //Click on the create button at Add Project form
            projectsPage.ClickOnCreateProjectBtn();
            Thread.Sleep(2000);

            //Select Project Type
            projectsPage.SelectProjectType("Just for Me");
            Thread.Sleep(3000);

            //Click Delete Project Icon
            commonPage.ScrollUp();
            Thread.Sleep(3000);
            projectsPage.ClickDeleteProjectIcon();
            Thread.Sleep(2000);

            //Click the Delete Project Window Yes Button
            projectsPage.PressDeleteProjectWindowYesBtn();
            Thread.Sleep(5000);

            //Enter Search menu option
            searchPage.EnterSearchMenuOption(projectName);
            log.Info("Enter the Search option.");
            Thread.Sleep(1000);

            //Press Enter Key
            searchPage.PressEnterKey();
            Thread.Sleep(5000);

            /*//Select Projects Radio button
            searchPage.ClickProjectsRadio();
            log.Info("Select Projects Radio button.");
            Thread.Sleep(2000);*/

            //Verify the Search Result is not displayed
            searchPage.VerifySearchResultNotDisplayed(projectName);
            log.Info("Verify the Search highlighted resultis not displayed.");
            Thread.Sleep(2000);
        }

        [Test]
        public void Search_025_VerifySearchOptionPeoplePage()
        {
            Global.MethodName = "Search_025_VerifySearchOptionPeoplePage";

            //Click People menu option
            Thread.Sleep(2000);
            peoplePage.ClickPeopleMenu();
            log.Info("Click the People menu option.");
            Thread.Sleep(3000);

            //Verify the Search box is displayed
            peoplePage.VerifySearchBox();
            log.Info("Verify the Search text.");
            Thread.Sleep(2000);
        }

        [Test]
        public void Search_026_VerifyPeoplePageSearch()
        {
            Global.MethodName = "Search_026_VerifyPeoplePageSearch";
            //Click People menu option
            Thread.Sleep(2000);
            peoplePage.ClickPeopleMenu();
            log.Info("Click the People menu option.");
            Thread.Sleep(5000);

            //Get UserName
            String userName = readSearch.GetValue("Search", "loggedUser");

            //Enter the Search text
            peoplePage.EnterSearchBox(userName);
            log.Info("Enter the Search text.");
            Thread.Sleep(1000);

            //Press enter key
            peoplePage.PressEnterKey();
            Thread.Sleep(3000);

            //Verify correct search result is displayed
            peoplePage.VerifyUserContainerUserName(userName);
            Thread.Sleep(2000);
        }

        [Test]
        public void Search_029_EditPeoplePageSearchAndVerify()
        {
            Global.MethodName = "Search_029_EditPeoplePageSearchAndVerify";
            //Click People menu option
            Thread.Sleep(2000);
            peoplePage.ClickPeopleMenu();
            log.Info("Click the People menu option.");
            Thread.Sleep(5000);

            //Get UserName
            String userName = readSearch.GetValue("Search", "loggedUser");

            //Enter the Search text
            peoplePage.EnterSearchBox("abcd");
            log.Info("Enter the Search text.");
            Thread.Sleep(1000);

            //Press enter key
            peoplePage.PressEnterKey();
            Thread.Sleep(3000);

            //Enter the Search text
            peoplePage.EnterSearchBox(userName);
            log.Info("Enter the Search text.");
            Thread.Sleep(1000);

            //Press enter key
            peoplePage.PressEnterKey();
            Thread.Sleep(3000);

            //Verify correct search result is displayed
            peoplePage.VerifyUserContainerUserName(userName);
            Thread.Sleep(2000);
        }

        [Test]
        public void Search_030_VerifyAdvanceSearchOptionPeoplePage()
        {
            Global.MethodName = "Search_030_VerifyAdvanceSearchOptionPeoplePage";

            //Click People menu option
            Thread.Sleep(2000);
            peoplePage.ClickPeopleMenu();
            log.Info("Click the People menu option.");
            Thread.Sleep(3000);

            //Verify the Advance Search Link is displayed
            peoplePage.VerifyAdvanceSearchLink();
            log.Info("Verify the Advance Search Link.");
            Thread.Sleep(2000);
        }

        [Test]
        public void Search_031_VerifyAdvanceSearchFieldsPeoplePage()
        {
            Global.MethodName = "Search_031_VerifyAdvanceSearchFieldsPeoplePage";
            //Click People menu option
            Thread.Sleep(2000);
            peoplePage.ClickPeopleMenu();
            log.Info("Click the People menu option.");
            Thread.Sleep(3000);

            //Click the Advance Search option
            peoplePage.ClickAdvanceSearchLink();
            log.Info("Clickthe Advance Search hyperlink.");
            Thread.Sleep(2000);

            //Assert the Advance Search Name
            peoplePage.VerifyName();
            log.Info("Verify Advance Search Name.");
            Thread.Sleep(1000);

            //Assert the Advance Search Skills Needed
            peoplePage.VerifySkillsNeeded();
            log.Info("Verify Advance Search Skills Needed.");
            Thread.Sleep(1000);

            //Assert the Advance Search Job Function
            peoplePage.VerifyJobFunction();
            log.Info("Verify Advance Search Job Function.");
            Thread.Sleep(1000);

            //Assert the Advance Search Location
            peoplePage.VerifyLocation();
            log.Info("Verify Advance Search Location.");
            Thread.Sleep(1000);

            //Assert the Advance Industry/Domain Expertise 
            peoplePage.VerifyAdvSearchIndustryDomainExpertise();
            log.Info("Verify Advance Search Industry/Domain Expertise.");
            Thread.Sleep(1000);

            //Assert the Advance Search Endorsed By
            peoplePage.VerifyEndorsedBy();
            log.Info("Verify Advance Search Endorsed By.");
            Thread.Sleep(1000);

            //Assert the Advance Search Availability
            peoplePage.VerifyAvailability();
            log.Info("Verify Advance Search Availability.");
            Thread.Sleep(1000);

            //Assert the Advance Search Type
            peoplePage.VerifyType();
            log.Info("Verify Advance Search Type.");
            Thread.Sleep(1000);
        }

        [Test]
        public void Search_032_VerifyPeoplePageAdvanceSearch()
        {
            Global.MethodName = "Search_032_VerifyPeoplePageAdvanceSearch";
            //Click People menu option
            Thread.Sleep(2000);
            peoplePage.ClickPeopleMenu();
            log.Info("Click the People menu option.");
            Thread.Sleep(5000);

            //Get UserName
            String userName = readSearch.GetValue("Search", "loggedUser");

            //Click the Advance Search option
            peoplePage.ClickAdvanceSearchLink();
            log.Info("Clickthe Advance Search hyperlink.");
            Thread.Sleep(2000);

            //Enter the Advance Search Name
            peoplePage.EnterAdvanceSearchName(userName);
            log.Info("Verify Advance Search Name.");
            Thread.Sleep(1000);

            //Press Advance Search button
            peoplePage.ClickAdvanceSearchBtn();
            Thread.Sleep(5000);

            //Verify correct search result is displayed
            peoplePage.VerifyUserContainerUserName(userName);
            Thread.Sleep(2000);
        }








    }
}