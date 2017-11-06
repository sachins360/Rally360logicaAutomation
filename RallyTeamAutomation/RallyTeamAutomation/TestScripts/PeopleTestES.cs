﻿using NUnit.Framework;
using RallyTeam.UILocators;
using RallyTeam.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RallyTeam.TestScripts
{
    [TestFixture]
    [Category("PeopleES")]
    public class PeopleTestES : BaseTestES
    {
        static ReadData readPeople = new ReadData("People");
        static ReadData readUserProfile = new ReadData("UserProfile");

        //SignIn
        private void SignInDifferentUser()
        {
            String userName = readPeople.GetValue("SignInDifferentUser", "userName");
            String password = readPeople.GetValue("SignInDifferentUser", "password");
            authenticationPage.SetUserName(userName);
            authenticationPage.SetPassword(password);
            authenticationPage.ClickOnLoginButton();
        }

        //Delete Project
        public void DeleteProject()
        {
            //Click Delete Project Icon
            Thread.Sleep(3000);
            postProjectPage.ClickDeleteProjectIcon();
            Thread.Sleep(2000);

            //Click the Delete Project Window Yes Button
            postProjectPage.PressDeleteProjectWindowYesBtn();
            Thread.Sleep(2000);
        }

        //Post a Project
        public void PostNewProject(String projectName)
        {
            //Click Post Project tab
            Thread.Sleep(3000);
            postProjectPage.ClickPostProject();
            Thread.Sleep(5000);

            //Enter the Project Name
            postProjectPage.EnterProjectName(projectName);
            Thread.Sleep(1000);

            //Enter the Project Description
            String projectDesc = readPeople.GetValue("AddProjectDetails", "projectDesc");
            postProjectPage.EnterProjectDescription(projectDesc);
            Thread.Sleep(1000);

            //Click on the create button
            postProjectPage.ClickOnCreateProjectBtn();
            Thread.Sleep(7000);

            //Click on Add member icon
            Thread.Sleep(3000);
            postProjectPage.ClickAddMemberIcon();
            log.Info("Click the Add member icon for the Project.");

            //Enter the Project Member Email
            Thread.Sleep(4000);
            String addMemberEmail = readPeople.GetValue("AddProjectMember", "addMemberEmail");
            postProjectPage.EnterProjectMemberEmail(addMemberEmail);

            //Select user from suggestion
            Thread.Sleep(2000);
            String addMemberName = readPeople.GetValue("AddProjectMember", "addMemberName");
            postProjectPage.SelectUserfromSuggestion(addMemberName);
            log.Info("User selected successfully.");

            //Click the Add Project Member window Done button
            Thread.Sleep(2000);
            postProjectPage.ClickAddProjectMemberDoneBtn();
            log.Info("Click the Add Project Member window Done button.");
            Thread.Sleep(10000);

            //Select Project status as Completed
            postProjectPage.SelectStatusDropDown("Completed");
            log.Info("Select Project status as 'Completed'");
            Thread.Sleep(4000);

            //Select awesome rating
            invoicingPage.ClickAwesomeRating();
            log.Info("Select Awesome rating.");
            Thread.Sleep(2000);

            //Click on Mark Complete button
            postProjectPage.ClickMarkComplete();
            log.Info("Click Mark Complete button.");
            Thread.Sleep(5000);
        }

        private int getIndexofNumber(string cell)
        {
            int indexofNum = -1;
            foreach (char c in cell)
            {
                indexofNum++;
                if (Char.IsDigit(c))
                {
                    return indexofNum;
                }
            }
            return indexofNum;
        }

        [Test]
        public void PeopleES_001_SearchPeople()
        {
            Global.MethodName = "PeopleES_001_SearchPeople";
            //Click People menu option
            Thread.Sleep(5000);
            peoplePage.ClickPeopleTab();
            log.Info("Click the People tab.");
            Thread.Sleep(3000);

            //Enter the Search text on the main search page
            String searchUser = readPeople.GetValue("People", "searchUser");
            peoplePage.EnterBrowseSearch(searchUser);
            log.Info("Enter the Search text on the main search page.");
            Thread.Sleep(1000);

            //Click Search button
            peoplePage.ClickSpanSearch();
            log.Info("Click on the Search button on the main page");
            Thread.Sleep(5000);

            //Verify User container User Name is displayed
            peoplePage.VerifyUserContainerUserName(searchUser);
            log.Info("Verify searched user is displayed.");
            Thread.Sleep(1000);

            //Enter the Search text
            peoplePage.EnterSearchBox(searchUser);
            log.Info("Enter the Search text.");
            Thread.Sleep(1000);

            //Press enter key
            peoplePage.PressEnterKey();
            Thread.Sleep(5000);

            //Verify User container User Name is displayed
            peoplePage.VerifyUserContainerUserName(searchUser);
            log.Info("Verify searched user is displayed.");
        }

        [Test]
        public void PeopleES_002_ClickMessageAndVerify()
        {
            Global.MethodName = "PeopleES_002_ClickMessageAndVerify";
            
            //Click People tab
            Thread.Sleep(2000);
            peoplePage.ClickPeopleTab();
            log.Info("Click the People tab.");
            Thread.Sleep(3000);

            //Enter the Search text on the main search page
            String searchUser = readPeople.GetValue("People", "searchUser");
            peoplePage.EnterBrowseSearch(searchUser);
            log.Info("Enter the Search text on the main search page.");
            Thread.Sleep(1000);

            //Click Search button
            peoplePage.ClickSpanSearch();
            log.Info("Click on the Search button on the main page");
            Thread.Sleep(5000);

            //Move to User Container
            peoplePage.MoveToUserContainer();
            log.Info("Move to user container.");
            Thread.Sleep(2000);

            //Click Message button
            peoplePage.ClickMessageBtn();
            log.Info("Click on Message button.");
            Thread.Sleep(3000);

            //Assert the New Message Window is displayed
            peoplePage.VerifyNewMessageWindow();
            log.Info("Verify New Message Window.");
            Thread.Sleep(2000);
        }

        [Test]
        public void PeopleES_003_ClickViewProfileAndVerify()
        {
            Global.MethodName = "People_003_ClickViewProfileAndVerify";
            //Click People tab
            Thread.Sleep(2000);
            peoplePage.ClickPeopleTab();
            log.Info("Click the People tab.");
            Thread.Sleep(3000);

            //Enter the Search text on the main search page
            String searchUser = readPeople.GetValue("People", "searchUser");
            peoplePage.EnterBrowseSearch(searchUser);
            log.Info("Enter the Search text on the main search page.");
            Thread.Sleep(1000);

            //Click Search button
            peoplePage.ClickSpanSearch();
            log.Info("Click on the Search button on the main page");
            Thread.Sleep(5000);

            //Move to User Container
            peoplePage.MoveToUserContainer();
            log.Info("Move to user container.");
            Thread.Sleep(2000);

            //Click View Profile button
            peoplePage.ClickViewProfileBtn();
            log.Info("Click on Message button.");
            Thread.Sleep(3000);

            //Assert the User Profile User Name
            peoplePage.VerifyUserName(searchUser);
            log.Info("Verify User Profile User Name.");
            Thread.Sleep(2000);

            //Assert the User Profile Message button
            peoplePage.VerifyUserProfileMessageBtn();
            log.Info("Verify User Profile Message button.");
            Thread.Sleep(2000);

            //Assert the User Profile About Me
            peoplePage.VerifyAboutMe();
            log.Info("Verify User Profile About Me.");
            Thread.Sleep(2000);

            //Assert the User Profile Skills & Endorsements
            peoplePage.VerifySkillsEndorsements();
            log.Info("Verify User Profile Skills & Endorsements.");
            Thread.Sleep(2000);

            //Assert the User Profile Industry/Domain Expertise
            peoplePage.VerifyIndustryDomainExpertise();
            log.Info("Verify User Profile Industry/Domain Expertise.");
            Thread.Sleep(2000);

            //Assert the User Profile Languages
            peoplePage.VerifyLanguages();
            log.Info("Verify User Profile Languages.");
            Thread.Sleep(2000);

            //Assert the User Profile Interests
            peoplePage.VerifyInterests();
            log.Info("Verify User Profile Interests.");
            Thread.Sleep(2000);

            //Assert the User Profile Projects
            peoplePage.VerifyProjects();
            log.Info("Verify User Profile Projects.");
            Thread.Sleep(2000);
        }

        [Test]
        public void PeopleES_004_VerifyAdvanceSearchFields()
        {
            Global.MethodName = "People_004_VerifyAdvanceSearchFields";
            //Click People tab
            Thread.Sleep(2000);
            peoplePage.ClickPeopleTab();
            log.Info("Click the People tab.");
            Thread.Sleep(3000);

            //Click the Advance Search option
            peoplePage.ClickAdvanceSearchMainPage();
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
        public void PeopleES_005_NameSearchViaAdvanceSearch()
        {
            Global.MethodName = "PeopleES_005_NameSearchViaAdvanceSearch";
            //Click People tab
            Thread.Sleep(2000);
            peoplePage.ClickPeopleTab();
            log.Info("Click the People tab.");
            Thread.Sleep(3000);

            //Click the Advance Search option
            peoplePage.ClickAdvanceSearchMainPage();
            log.Info("Clickthe Advance Search hyperlink.");
            Thread.Sleep(2000);

            //Enter the Advance Search Name
            String searchUser = readPeople.GetValue("People", "searchUser");
            peoplePage.EnterAdvanceSearchName(searchUser);
            log.Info("Enter Advance Search Name.");
            Thread.Sleep(1000);
            
            //Click Search button
            peoplePage.ClickAdvanceSearchBtn();
            log.Info("Click on the Search button on the Advance Search page.");
            Thread.Sleep(5000);

            //Verify User container User Name is displayed
            peoplePage.VerifyUserContainerUserName(searchUser);
            log.Info("Verify searched user is displayed.");
            Thread.Sleep(1000);
        }

        [Test]
        public void PeopleES_006_EndorseUserAwesomeRating()
        {
            Global.MethodName = "People_003_ClickViewProfileAndVerify";
            //Click People tab
            Thread.Sleep(2000);
            peoplePage.ClickPeopleTab();
            log.Info("Click the People tab.");
            Thread.Sleep(3000);

            //Enter the Search text on the main search page
            String searchUser = readPeople.GetValue("People", "searchUser");
            peoplePage.EnterBrowseSearch(searchUser);
            log.Info("Enter the Search text on the main search page.");
            Thread.Sleep(1000);

            //Click Search button
            peoplePage.ClickSpanSearch();
            log.Info("Click on the Search button on the main page");
            Thread.Sleep(5000);

            //Move to User Container
            peoplePage.MoveToUserContainer();
            log.Info("Move to user container.");
            Thread.Sleep(2000);

            //Click View Profile button
            peoplePage.ClickViewProfileBtn();
            log.Info("Click on Message button.");
            Thread.Sleep(5000);

            //Click Endorse button
            peoplePage.ClickEndorseBtn();
            log.Info("Click on Endorse button.");
            Thread.Sleep(5000);

            //Enter Project Title
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(4));
            String projectName = "Endorse Project ";
            projectName = projectName + builder;
            peoplePage.EnterProjectTitle(projectName);
            log.Info("Enter Project Title.");
            Thread.Sleep(1000);

            //Enter Project Description
            peoplePage.EnterProjectDescription("Proj Desc");
            log.Info("Enter Project Description.");
            Thread.Sleep(1000);

            //Select Awesome rating
            peoplePage.ClickAwesomeRating();
            log.Info("Click the Awesome rating.");
            Thread.Sleep(2000);

            //Enter Feedback
            peoplePage.EnterFeedback("User Feedback");
            log.Info("Enter Project Feedback.");
            Thread.Sleep(1000);

            //Click Endorse button
            peoplePage.ClickEndorseUserBtn();
            log.Info("Click on Endorse button.");
            Thread.Sleep(5000);
        }

        [Test]
        public void PeopleES_007_EndorseUserGoodRating()
        {
            Global.MethodName = "PeopleES_007_EndorseUserGoodRating";
            //Click People tab
            Thread.Sleep(2000);
            peoplePage.ClickPeopleTab();
            log.Info("Click the People tab.");
            Thread.Sleep(3000);

            //Enter the Search text on the main search page
            String searchUser = readPeople.GetValue("People", "searchUser");
            peoplePage.EnterBrowseSearch(searchUser);
            log.Info("Enter the Search text on the main search page.");
            Thread.Sleep(1000);

            //Click Search button
            peoplePage.ClickSpanSearch();
            log.Info("Click on the Search button on the main page");
            Thread.Sleep(5000);

            //Move to User Container
            peoplePage.MoveToUserContainer();
            log.Info("Move to user container.");
            Thread.Sleep(2000);

            //Click View Profile button
            peoplePage.ClickViewProfileBtn();
            log.Info("Click on Message button.");
            Thread.Sleep(5000);

            //Click Endorse button
            peoplePage.ClickEndorseBtn();
            log.Info("Click on Endorse button.");
            Thread.Sleep(5000);

            //Enter Project Title
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(4));
            String projectName = "Endorse Project ";
            projectName = projectName + builder;
            peoplePage.EnterProjectTitle(projectName);
            log.Info("Enter Project Title.");
            Thread.Sleep(1000);

            //Enter Project Description
            peoplePage.EnterProjectDescription("Proj Desc");
            log.Info("Enter Project Description.");
            Thread.Sleep(1000);

            //Select Good rating
            peoplePage.ClickGoodRating();
            log.Info("Click the Good rating.");
            Thread.Sleep(2000);

            //Enter Feedback
            peoplePage.EnterFeedback("User Feedback");
            log.Info("Enter Project Feedback.");
            Thread.Sleep(1000);

            //Click Endorse button
            peoplePage.ClickEndorseUserBtn();
            log.Info("Click on Endorse button.");
            Thread.Sleep(5000);
        }

        [Test]
        public void PeopleES_008_EndorseUserNotGoodRating()
        {
            Global.MethodName = "PeopleES_008_EndorseUserNotGoodRating";
            //Click People tab
            Thread.Sleep(2000);
            peoplePage.ClickPeopleTab();
            log.Info("Click the People tab.");
            Thread.Sleep(3000);

            //Enter the Search text on the main search page
            String searchUser = readPeople.GetValue("People", "searchUser");
            peoplePage.EnterBrowseSearch(searchUser);
            log.Info("Enter the Search text on the main search page.");
            Thread.Sleep(1000);

            //Click Search button
            peoplePage.ClickSpanSearch();
            log.Info("Click on the Search button on the main page");
            Thread.Sleep(5000);

            /*//Move to User Container
            peoplePage.MoveToUserContainer();
            log.Info("Move to user container.");
            Thread.Sleep(2000);*/

            //Click View Profile button
            peoplePage.ClickViewProfileBtn();
            log.Info("Click on View Profile button.");
            Thread.Sleep(5000);

            //Click Endorse button
            peoplePage.ClickEndorseBtn();
            log.Info("Click on Endorse button.");
            Thread.Sleep(5000);

            //Enter Project Title
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(4));
            String projectName = "Endorse Project ";
            projectName = projectName + builder;
            peoplePage.EnterProjectTitle(projectName);
            log.Info("Enter Project Title.");
            Thread.Sleep(1000);

            //Enter Project Description
            peoplePage.EnterProjectDescription("Proj Desc");
            log.Info("Enter Project Description.");
            Thread.Sleep(1000);

            //Select Not Good rating
            peoplePage.ClickNotGoodRating();
            log.Info("Click the Not Good rating.");
            Thread.Sleep(2000);

            //Enter Feedback
            peoplePage.EnterFeedback("User Feedback");
            log.Info("Enter Project Feedback.");
            Thread.Sleep(1000);

            commonPage.ScrollDown();
            Thread.Sleep(2000);

            //Click Endorse button
            peoplePage.ClickEndorseUserBtn();
            log.Info("Click on Endorse button.");
            Thread.Sleep(5000);
        }

        [Test]
        public void PeopleES_009_EndorseUserAndVerifyIncreasedCount()
        {
            Global.MethodName = "PeopleES_009_EndorseUserAndVerifyIncreasedCount";
            //Click People tab
            Thread.Sleep(2000);
            peoplePage.ClickPeopleTab();
            log.Info("Click the People tab.");
            Thread.Sleep(3000);

            //Enter the Search text on the main search page
            String searchUser = readPeople.GetValue("People", "searchUser");
            peoplePage.EnterBrowseSearch(searchUser);
            log.Info("Enter the Search text on the main search page.");
            Thread.Sleep(1000);

            //Click Search button
            peoplePage.ClickSpanSearch();
            log.Info("Click on the Search button on the main page");
            Thread.Sleep(5000);

            //Move to User Container
            peoplePage.MoveToUserContainer();
            log.Info("Move to user container.");
            Thread.Sleep(2000);

            //Click View Profile button
            peoplePage.ClickViewProfileBtn();
            log.Info("Click on Message button.");
            Thread.Sleep(5000);

            string topSkillCount = peoplePage.GetTopSkillCount();
            Console.WriteLine("Top Skill Count: " + topSkillCount);
            int topSkillCountInt = Int32.Parse(topSkillCount);
            int increasedTopSkillCountInt = topSkillCountInt + 1;
            string increasedTopSkillCount = increasedTopSkillCountInt.ToString();

            string topSkillName = peoplePage.GetTopSkillName();
            int row, a = getIndexofNumber(topSkillName);
            string Numberpart = topSkillName.Substring(a, topSkillName.Length - a);
            row = Convert.ToInt32(Numberpart);
            string Stringpart = topSkillName.Substring(0, a);
            Console.WriteLine("String part: " + Stringpart);

            //Click Endorse button
            peoplePage.ClickEndorseBtn();
            log.Info("Click on Endorse button.");
            Thread.Sleep(5000);

            //Enter Project Title
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(4));
            String projectName = "Endorse Project ";
            projectName = projectName + builder;
            peoplePage.EnterProjectTitle(projectName);
            log.Info("Enter Project Title.");
            Thread.Sleep(1000);

            //Enter Project Description
            peoplePage.EnterProjectDescription("Proj Desc");
            log.Info("Enter Project Description.");
            Thread.Sleep(1000);

            //Select Awesome rating
            peoplePage.ClickAwesomeRating();
            log.Info("Click the Awesome rating.");
            Thread.Sleep(2000);

            //Enter Skills Endorsed
            peoplePage.EnterSkills(Stringpart);
            Thread.Sleep(3000);
            commonPage.PressEnterKey();
            log.Info("Enter Skill Name.");
            Thread.Sleep(2000);

            //Click Endorse button
            peoplePage.ClickEndorseUserBtn();
            log.Info("Click on Endorse button.");
            Thread.Sleep(7000);

            //Refresh page
            commonPage.RefreshPage();
            Thread.Sleep(7000);

            //Verify the Top Skill increased
            peoplePage.VerifyIncreasedTopSkillCount(increasedTopSkillCount);
            log.Info("Verify the Top Skill count has increased.");
        }

        [Test]
        public void PeopleES_010_RequestFeedback()
        {
            Global.MethodName = "PeopleES_010_RequestFeedback";

            //Post a new project
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(4));
            String projectName = readPeople.GetValue("AddProjectDetails", "projectName");
            projectName = projectName + builder;
            PostNewProject(projectName);

            //Signout of the application
            Thread.Sleep(5000);
            authenticationPage.SignOut();
            log.Info("Click on the Signout button.");

            //Sign in with a different user
            Thread.Sleep(2000);
            SignInDifferentUser();
            log.Info("Sign in with different user.");

            //Click User Profile Icon
            Thread.Sleep(5000);
            peoplePage.ClickUserProfileIcon();
            log.Info("Click the User Profile Icon.");
            Thread.Sleep(2000);

            //Select the User Profile Option 'Profile'
            peoplePage.ClickUserProfileOptions("Profile");
            log.Info("Click User Profile option 'Profile'.");
            Thread.Sleep(2000);
                        
            //Click Request Feedback button
            peoplePage.ClickRequestFeedbackBtn();
            log.Info("Click on Request Feedback button.");
            Thread.Sleep(5000);

            //Select Project
            peoplePage.SelectProject(projectName);
            log.Info("Select Project.");
            Thread.Sleep(1000);

            //Enter Feedback From
            String feedbackFrom = readPeople.GetValue("People", "feedbackFrom");
            peoplePage.EnterFeedbackFrom(feedbackFrom);
            Thread.Sleep(3000);
            commonPage.PressEnterKey();
            log.Info("Enter Feedback From.");
            Thread.Sleep(1000);

            //Enter Optional Message
            peoplePage.EnterOptionalMessage("Optional Message");
            log.Info("Enter Optional Message.");
            Thread.Sleep(1000);

            //Click Send button
            peoplePage.ClickSendBtnForFeedback();
            log.Info("Click on Send button.");
            Thread.Sleep(5000);            
        }

        [Test]
        public void ENG2248_001_VerifyAddNotesViewNotes()
        {
            Global.MethodName = "ENG2248_001_VerifyAddNotesViewNotes";
                        
            //Click User Profile Icon
            Thread.Sleep(5000);
            userProfilePage.ClickUserProfileIcon();
            log.Info("Click the User Profile Icon.");
            Thread.Sleep(2000);

            //Select the User Profile Option 'Admin'
            userProfilePage.ClickUserProfileOptions("Admin");
            log.Info("Click User Profile option 'Admin'.");
            Thread.Sleep(5000);

            //Verify Notes column
            userProfilePage.VerifyNotesColumn();
            log.Info("Verify Notes column is displayed.");
            Thread.Sleep(1000);

            //Verify View Notes Link
            userProfilePage.VerifyViewNotesLink();
            log.Info("Verify View Notes link is displayed.");
        }

        [Test]
        public void ENG2248_002_VerifyViewNotesWindow()
        {
            Global.MethodName = "ENG2248_002_VerifyViewNotesWindow";
            
            //Click User Profile Icon
            Thread.Sleep(3000);
            userProfilePage.ClickUserProfileIcon();
            log.Info("Click the User Profile Icon.");
            Thread.Sleep(2000);

            //Select the User Profile Option 'Admin'
            userProfilePage.ClickUserProfileOptions("Admin");
            log.Info("Click User Profile option 'Admin'.");
            Thread.Sleep(2000);

            //Enter Search User Email Id
            String searchUser = readUserProfile.GetValue("Admin", "searchUser");
            userProfilePage.EnterSearchUser(searchUser);
            log.Info("Enter search user email id.");
            Thread.Sleep(2000);

            //Press Enter Key
            userProfilePage.PressEnterKey();
            Thread.Sleep(5000);

            //Click View Notes Link
            userProfilePage.ClickViewNotesLink();
            log.Info("Click View Notes link.");
            Thread.Sleep(3000);

            //Verify View Notes Window
            userProfilePage.VerifyViewNotesWindow();
            log.Info("Verify View Notes Window.");
        }

        /*[Test]
        public void ENG2248_003_VerifyViewNotesPage()
        {
            Global.MethodName = "ENG2248_003_VerifyViewNotesPage";
            commonPage.NavigateToExternalStorm(_externalStormURL);

            //Login to the application
            Thread.Sleep(5000);
            authenticationPage.SetUserName(_workEmail);
            authenticationPage.SetPassword(_password);
            authenticationPage.ClickOnLoginButton();

            //Click User Profile Icon
            Thread.Sleep(3000);
            userProfilePage.ClickUserProfileIcon();
            log.Info("Click the User Profile Icon.");
            Thread.Sleep(2000);

            //Select the User Profile Option 'Admin'
            userProfilePage.ClickUserProfileOptions("Admin");
            log.Info("Click User Profile option 'Admin'.");
            Thread.Sleep(2000);

            //Enter Search User Email Id
            String searchUser = readUserProfile.GetValue("Admin", "searchUser");
            userProfilePage.EnterSearchUser(searchUser);
            log.Info("Enter search user email id.");
            Thread.Sleep(2000);

            //Press Enter Key
            userProfilePage.PressEnterKey();
            Thread.Sleep(2000);

            //Click View Notes Link
            userProfilePage.ClickViewNotesLink();
            log.Info("Click View Notes link.");
            Thread.Sleep(3000);

            //Verify View Notes Window
            userProfilePage.VerifyViewNotesWindow();
            log.Info("Verify View Notes Window.");
            Thread.Sleep(1000);

            //Verify View Notes TextArea
            userProfilePage.VerifyViewNotesTextArea();
            log.Info("Verify View Notes TextArea.");
            Thread.Sleep(1000);

            //Verify View Notes Add Note Button
            userProfilePage.VerifyViewNotesAddNoteBtn();
            log.Info("Verify View Notes Add Note Button.");
            Thread.Sleep(1000);

            //Verify View Notes Close Icon
            userProfilePage.VerifyViewNotesCloseIcon();
            log.Info("Verify View Notes Close Icon.");
            Thread.Sleep(1000);
        }*/

        [Test]
        public void ENG2248_004_AddNoteAndVerify()
        {
            Global.MethodName = "ENG2248_004_AddNoteAndVerify";
            
            //Click User Profile Icon
            Thread.Sleep(5000);
            userProfilePage.ClickUserProfileIcon();
            log.Info("Click the User Profile Icon.");
            Thread.Sleep(3000);

            //Select the User Profile Option 'Admin'
            userProfilePage.ClickUserProfileOptions("Admin");
            log.Info("Click User Profile option 'Admin'.");
            Thread.Sleep(2000);

            //Enter Search User Email Id
            String searchUser = readUserProfile.GetValue("Admin", "searchUser");
            userProfilePage.EnterSearchUser(searchUser);
            log.Info("Enter search user email id.");
            Thread.Sleep(2000);

            //Press Enter Key
            userProfilePage.PressEnterKey();
            Thread.Sleep(2000);

            //Click View Notes Link
            userProfilePage.ClickViewNotesLink();
            log.Info("Click View Notes link.");
            Thread.Sleep(3000);

            //Enter A Note
            String note = readUserProfile.GetValue("Admin", "note");
            userProfilePage.EnterViewNotesTextArea(note);
            log.Info("Enter View Notes TextArea.");
            Thread.Sleep(2000);

            //Click on Add Note button
            userProfilePage.ClickViewNotesAddNoteBtn();
            log.Info("Click the Add Note button.");
            Thread.Sleep(3000);

            /*//Verify the added note displayed
            userProfilePage.VerifyViewNotesAddedNote(note);
            log.Info("Verify the added note is displayed.");*/

            String b = userProfilePage.letsDoIt();
            Console.WriteLine("Value of b: " + b);
        }








    }
}
