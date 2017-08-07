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
    [Category("PostProject")]
    public class PostProjectTest : BaseTestES
    {
        static ReadData readPostProject = new ReadData("PostProject");
        StringBuilder builder, builder2;
        String email, email2;
        public void GoToAddUser()
        {
            builder = new StringBuilder();
            builder2 = new StringBuilder();
            builder.Append(RandomString(10));
            builder2.Append(RandomString(10));

            //Click User Profile Icon
            userProfilePage.ClickUserProfileIcon();
            log.Info("Click the User Profile Icon.");
            Thread.Sleep(2000);

            //Select the User Profile Option 'Admin'
            userProfilePage.ClickUserProfileOptions("Admin");
            log.Info("Click User Profile option 'Admin'.");
            Thread.Sleep(5000);

            //Click Add Users button
            addUsersPage.ClickAddUsersBtn();
            log.Info("Click Add Users button.");
            Thread.Sleep(5000);
        }

        public void onBoardNewUser()
        {
            Thread.Sleep(5000);
            GoToAddUser();

            //Click Email button
            if (_browser == "edge")
                addUsersPage.PressEmailBtn();
            else
                addUsersPage.ClickEmailBtn();
            log.Info("Click Email button.");
            Thread.Sleep(5000);

            //Enter Email Address
            email = builder + "@harakirimail.com";
            addUsersPage.EnterEmailAddresses(email);
            log.Info("Enter Email Address.");
            commonPage.PressTabKey();
            Thread.Sleep(2000);

            //Click Add Users button
            addUsersPage.ClickEmailAddUsersBtn();
            log.Info("Click Add Users button.");
            Thread.Sleep(5000);

            //Click Finish button
            addUsersPage.ClickFinishBtn();
            log.Info("Click Finish button.");
            Thread.Sleep(5000);

            //Navigate to the user inbox
            commonPage.NavigateToUrl("https://www.harakirimail.com/");
            log.Info("Navigate to the mailinator site.");
            Thread.Sleep(7000);

            //Enter Harakirimail Email address
            addUsersPage.EnterHarakirimailEmail(email);
            log.Info("Enter email address.");
            Thread.Sleep(2000);

            //Press Enter key
            commonPage.PressEnterKey();
            Thread.Sleep(5000);

            //Click the Email Subject
            addUsersPage.ClickEmailSubject();
            log.Info("Click the Email Subject.");
            Thread.Sleep(5000);

            //Click Get Started button
            addUsersPage.ClickEmailGetStartedBtn();
            log.Info("Click the Get Started Button.");
            Thread.Sleep(5000);

            //Enter First Name on the screen
            registrationPage.EnterFirstName(builder.ToString());
            log.Info("Enter First Name on the screen.");
            Thread.Sleep(2000);

            //Enter Last Name on the screen
            registrationPage.EnterLastName(builder.ToString());
            log.Info("Enter Last Name on the screen.");
            Thread.Sleep(2000);

            //Click SignUp button on the screen
            registrationPage.ClickSignUpBtn();
            log.Info("Click SignUp button on the screen.");
            Thread.Sleep(5000);

            //Enter Create a Password field on the screen
            registrationPage.EnterCreatePwdFields(_password);
            log.Info("Enter Create a Password field on the screen.");
            Thread.Sleep(2000);

            //Enter Confirm Password field on the screen
            registrationPage.EnterConfirmPwdFields(_password);
            log.Info("Enter Confirm Password field on the screen.");
            Thread.Sleep(2000);

            //Click All Done Button on the screen
            registrationPage.ClickAllDoneBtn();
            log.Info("Click All Done button on the screen.");
            Thread.Sleep(7000);

            //Verify the Get Started button
            addUsersPage.VerifyGetStartedBtn();
            log.Info("Verify Get Started button.");

            //Click Get Started button
            addUsersPage.ClickGetStartedBtn();
            log.Info("Click Get Staerted button.");
            Thread.Sleep(5000);

            //Click Linkedin Next button
            addUsersPage.ClickNextLinkedIn();
            log.Info("Click Next button on LinkedIn Page.");
            Thread.Sleep(5000);

            //Select Expertise
            addUsersPage.SelectExpertiseDropDown("Information Technology");
            log.Info("Select Expertise.");
            Thread.Sleep(2000);

            //Click Expertise Continue button
            addUsersPage.ClickExpertiseContinueBtn();
            log.Info("Click Expertise Continue button.");
            Thread.Sleep(5000);

            //Enter Skills
            addUsersPage.EnterSkills("Testing");
            Thread.Sleep(2000);
            commonPage.PressEnterKey();
            Thread.Sleep(2000);
            addUsersPage.EnterSkills("JIRA");
            Thread.Sleep(2000);
            commonPage.PressEnterKey();
            Thread.Sleep(2000);

            //Click View My Profile button
            addUsersPage.ClickViewMyProfileBtn();
            log.Info("Click View My Profile button.");
            Thread.Sleep(5000);

            //Assert Skills entered are populated in the Profile
            addUsersPage.AssertSkillOne("Testing");
            log.Info("Assert Skill One.");
            Thread.Sleep(1000);
            addUsersPage.AssertSkillTwo("JIRA");
            log.Info("Assert Skill Two.");
            Thread.Sleep(1000);

            //Click Done button on Profile
            commonPage.ScrollUp();
            Thread.Sleep(2000);
            addUsersPage.ClickDoneBtn();
            log.Info("Click Done button.");
            Thread.Sleep(5000);
        }
        //SignIn
        private void SignInDifferentUser(String userName, String password)
        {
            authenticationPage.SetUserName(userName);
            authenticationPage.SetPassword(password);
            authenticationPage.ClickOnLoginButton();        
        }

        //Delete Project
        public void DeleteProject()
        {
            //Click Settings Icon
            postProjectPage.ClickSettingsIcon();
            log.Info("Click Settings Icon");
            Thread.Sleep(3000);

            //Select Project Settings Option
            postProjectPage.SelectProjectOption("Delete Project");
            log.Info("Select Delete Project option.");
            Thread.Sleep(3000);

            //Press Delete Project Window Yes buttonm
            postProjectPage.PressDeleteProjectWindowYesBtn();
            log.Info("Press Delete Project Window Yes button.");
        }

        //Post a Project
        public void PostNewProject(String projectName,bool publicProject=false)
        {                        
            //Click Post Project tab
            Thread.Sleep(3000);
            postProjectPage.ClickPostProject();
            Thread.Sleep(5000);

            //Enter the Project Name
            postProjectPage.EnterProjectName(projectName);
            Thread.Sleep(1000);

            //Enter the Project Description
            String projectDesc = readPostProject.GetValue("AddProjectDetails", "projectDesc");
            postProjectPage.EnterProjectDescription(projectDesc);
            Thread.Sleep(1000);

            //Click Continue Button
            postProjectPage.ClickContinueBtn();
            log.Info("Click on the Continue button.");
            Thread.Sleep(5000);

            //Enter Skills
            commonPage.ScrollUp();
            Thread.Sleep(2000);
            String skills = readPostProject.GetValue("AddProjectDetails", "skills");
            postProjectPage.EnterSkillsNeeded(skills);
            Thread.Sleep(3000);
            commonPage.PressEnterKey();
            Thread.Sleep(2000);
            log.Info("Enter Skills.");

            String addMembersEmail = readPostProject.GetValue("AddProjectDetails", "memberEmail");
            List<String> addMembersEmailList = addMembersEmail.Split(',').ToList();
            int noOfMember = addMembersEmailList.Count;
            foreach (String value in addMembersEmailList)
            {
                postProjectPage.EnterMemberName(value);
                Thread.Sleep(2000);
                commonPage.PressEnterKey();
                Thread.Sleep(5000);
                postProjectPage.ClickAddBtn();
                log.Info("Click Add button.");
                Thread.Sleep(3000);
            }

            //Click Continue Button
            postProjectPage.ClickContinueBtn();
            log.Info("Click on the Continue button.");
            Thread.Sleep(10000);

            //Select private project
            if (publicProject)
            {
                Thread.Sleep(2000);
                postProjectPage.ClickPrivateProjectRdoBtn();
                log.Info("Click Publish Button");
            }

            //Click Publish button
            commonPage.ScrollDown();
            Thread.Sleep(2000);
            postProjectPage.ClickPublishBtn();
            log.Info("Click Publish Button");
            Thread.Sleep(7000);
        }

        public void PostNewProjectWithoutMember(String projectName)
        {
            //Click Post Project tab
            Thread.Sleep(3000);
            postProjectPage.ClickPostProject();
            Thread.Sleep(5000);

            //Enter the Project Name
            postProjectPage.EnterProjectName(projectName);
            Thread.Sleep(1000);

            //Enter the Project Description
            String projectDesc = readPostProject.GetValue("AddProjectDetails", "projectDesc");
            postProjectPage.EnterProjectDescription(projectDesc);
            Thread.Sleep(1000);

            //Click Continue Button
            postProjectPage.ClickContinueBtn();
            log.Info("Click on the Continue button.");
            Thread.Sleep(5000);

            //Enter Skills
            commonPage.ScrollUp();
            Thread.Sleep(2000);
            String skills = readPostProject.GetValue("AddProjectDetails", "skills");
            postProjectPage.EnterSkillsNeeded(skills);
            Thread.Sleep(3000);
            commonPage.PressEnterKey();
            Thread.Sleep(2000);
            log.Info("Enter Skills.");            

            //Click Continue Button
            postProjectPage.ClickContinueBtn();
            log.Info("Click on the Continue button.");
            Thread.Sleep(10000);

            //Click Publish button
            commonPage.ScrollDown();
            Thread.Sleep(2000);
            postProjectPage.ClickPublishBtn();
            log.Info("Click Publish Button");
            Thread.Sleep(7000);
        }

        //Post a Private Project
        public void PostNewPrivateProject(String projectName)
        {
            //Click Post Project tab
            Thread.Sleep(3000);
            postProjectPage.ClickPostProject();
            Thread.Sleep(5000);

            //Enter the Project Name
            postProjectPage.EnterProjectName(projectName);
            Thread.Sleep(1000);

            //Enter the Project Description
            String projectDesc = readPostProject.GetValue("AddProjectDetails", "projectDesc");
            postProjectPage.EnterProjectDescription(projectDesc);
            Thread.Sleep(1000);

            //Click Continue Button
            postProjectPage.ClickContinueBtn();
            log.Info("Click on the Continue button.");
            Thread.Sleep(5000);

            //Enter Skills
            commonPage.ScrollUp();
            Thread.Sleep(2000);
            String skills = readPostProject.GetValue("AddProjectDetails", "skills");
            postProjectPage.EnterSkillsNeeded(skills);
            Thread.Sleep(3000);
            commonPage.PressEnterKey();
            Thread.Sleep(2000);
            log.Info("Enter Skills.");

            //Click Continue Button
            postProjectPage.ClickContinueBtn();
            log.Info("Click on the Continue button.");
            Thread.Sleep(10000);

            //Click Private Radio option
            postProjectPage.ClickPrivateRadioOption();
            log.Info("Click on Private Radio option.");
            Thread.Sleep(2000);

            //Click Publish button
            commonPage.ScrollDown();
            Thread.Sleep(2000);
            postProjectPage.ClickPublishBtn();
            log.Info("Click Publish Button");
            Thread.Sleep(7000);
        }

        [Test]
        public void PostProject_001_VerifyPostProjectOption()
        {//done
            Global.MethodName = "PostProject_001_VerifyPostProjectOption";

            postProjectPage.VerifyPostProjectOption();
            log.Info("Verify Post A Project tab");
        }

        [Test]
        public void PostProject_002_PostANewProject()
        {//done
            Global.MethodName = "PostProject_002_PostANewProject";

            //Post a new project
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(6));            
            String projectName = readPostProject.GetValue("AddProjectDetails", "projectName");
            projectName = projectName + builder;

            //Click Post Project tab
            Thread.Sleep(3000);
            postProjectPage.ClickPostProject();
            Thread.Sleep(5000);

            //Enter the Project Name
            postProjectPage.EnterProjectName(projectName);
            Thread.Sleep(1000);

            //Enter the Project Description
            String projectDesc = readPostProject.GetValue("AddProjectDetails", "projectDesc");
            postProjectPage.EnterProjectDescription(projectDesc);
            Thread.Sleep(1000);

            //Enter the Project Deliverables
            String projectDelv = readPostProject.GetValue("AddProjectDetails", "projectDelv");
            postProjectPage.EnterProjectDeliverables(projectDelv);
            Thread.Sleep(1000);

            //Select the Project Category
            String projectCategory = readPostProject.GetValue("AddProjectDetails", "projectCategory");
            postProjectPage.SelectProjectCategory(projectCategory);
            log.Info("Enter Project Category.");
            Thread.Sleep(1000);

            //Select Project Type
            String projectType = readPostProject.GetValue("AddProjectDetails", "projectType");
            postProjectPage.SelectProjectType(projectType);
            log.Info("Enter Project Type.");
            Thread.Sleep(1000);

            //Click the Start Date Field
            postProjectPage.ClickStartDateField();
            log.Info("Click Start Date Field.");
            Thread.Sleep(1000);

            //Select today's date
            postProjectPage.ClickTodaysDate();
            log.Info("Select today's date.");
            Thread.Sleep(2000);

            //Select Ongoing check-box
            postProjectPage.ClickOngoingCheckbox();
            log.Info("Select Ongoing check-box.");
            Thread.Sleep(2000);

            //Click Continue Button
            postProjectPage.ClickContinueBtn();
            log.Info("Click on the Continue button.");
            Thread.Sleep(5000);

            //Enter Skills
            commonPage.ScrollUp();
            Thread.Sleep(2000);
            String skills = readPostProject.GetValue("AddProjectDetails", "skills");
            postProjectPage.EnterSkillsNeeded(skills);
            Thread.Sleep(3000);
            commonPage.PressEnterKey();
            Thread.Sleep(2000);
            log.Info("Enter Skills.");
            
            //Select Remote Checkbox
            postProjectPage.ClickRemoteCheckbox();
            log.Info("Select Remote check-box.");
            Thread.Sleep(2000);

            //Select Onsite Checkbox
            postProjectPage.ClickOnsiteCheckbox();
            log.Info("Select Onsite check-box.");
            Thread.Sleep(2000);

            //Select Staff
            String staff = readPostProject.GetValue("AddProjectDetails", "staff");
            postProjectPage.SelectStaff(staff);
            log.Info("Select Staff.");
            Thread.Sleep(1000);

            //Select Expected Time Commitment
            String expectedTimeCommt = readPostProject.GetValue("AddProjectDetails", "expectedTimeCommt");
            postProjectPage.SelectExpectedTimeCommt(expectedTimeCommt);
            log.Info("Select Expected Time Commitment.");
            Thread.Sleep(1000);
            
            //Click Continue Button
            postProjectPage.ClickContinueBtn();
            log.Info("Click on the Continue button.");
            Thread.Sleep(10000);

            //Click Publish button
            commonPage.ScrollDown();
            Thread.Sleep(2000);
            postProjectPage.ClickPublishBtn();
            log.Info("Click Publish Button");
            Thread.Sleep(7000);

            //Verify About tab of the project after creation
            postProjectPage.VerifyAboutTabOnPage();

            //Delete Project
            Thread.Sleep(3000);
            DeleteProject();
        }

        [Test]
        public void PostProject_003_VerifyDraftProject()
        {
            Global.MethodName = "PostProject_003_VerifyDraftProject";

            //Post a new project
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(6));
            String projectName = readPostProject.GetValue("AddProjectDetails", "projectName");
            projectName = projectName + builder;

            //Click Post Project tab
            Thread.Sleep(3000);
            postProjectPage.ClickPostProject();
            Thread.Sleep(5000);

            //Enter the Project Name
            postProjectPage.EnterProjectName(projectName);
            Thread.Sleep(1000);

            //Enter the Project Description
            String projectDesc = readPostProject.GetValue("AddProjectDetails", "projectDesc");
            postProjectPage.EnterProjectDescription(projectDesc);
            Thread.Sleep(1000);
            
            //Click Continue Button
            postProjectPage.ClickContinueBtn();
            log.Info("Click on the Continue button.");
            Thread.Sleep(5000);

            //Enter Skills
            commonPage.ScrollUp();
            Thread.Sleep(2000);
            String skills = readPostProject.GetValue("AddProjectDetails", "skills");
            postProjectPage.EnterSkillsNeeded(skills);
            Thread.Sleep(3000);
            commonPage.PressEnterKey();
            Thread.Sleep(2000);
            log.Info("Enter Skills.");

            //Click Back button
            postProjectPage.ClickBackBtn();
            log.Info("Click on the Back button.");
            Thread.Sleep(3000);

            //Click Save Draft button
            postProjectPage.ClickSaveDraftBtn();
            log.Info("Click on the Save Draft button.");
            Thread.Sleep(10000);

            //Enter the Project Name
            postProjectPage.SearchProjectName(projectName);
            log.Info("Enter the project name.");
            Thread.Sleep(1000);

            //Click Search button
            postProjectPage.ClickSearchBtn();
            log.Info("Click the Search button.");
            Thread.Sleep(15000);

            //Click the created project
            postProjectPage.ClickProjectNameOnPage(projectName);
            log.Info("Click the Project Name on the Projects Page.");
            Thread.Sleep(10000);
            
            //Click Continue Button
            postProjectPage.ClickContinueBtn();
            log.Info("Click on the Continue button.");
            Thread.Sleep(3000);

            //Click Save Draft button
            postProjectPage.ClickSaveDraftBtn();
            log.Info("Click on the Save Draft button.");
            Thread.Sleep(10000);

            //Enter the Project Name
            postProjectPage.SearchProjectName(projectName);
            log.Info("Enter the project name.");
            Thread.Sleep(1000);

            //Click Search button
            postProjectPage.ClickSearchBtn();
            log.Info("Click the Search button.");
            Thread.Sleep(15000);

            //Click the created project
            postProjectPage.ClickProjectNameOnPage(projectName);
            log.Info("Click the Project Name on the Projects Page.");
            Thread.Sleep(10000);

            //Click Continue Button
            postProjectPage.ClickContinueBtn();
            log.Info("Click on the Continue button.");
            Thread.Sleep(3000);

            //Click Continue Button
            postProjectPage.ClickContinueBtn();
            log.Info("Click on the Continue button.");
            Thread.Sleep(3000);

            //Click Save Draft button
            postProjectPage.ClickSaveDraftBtn();
            log.Info("Click on the Save Draft button.");
            Thread.Sleep(10000);

            //Enter the Project Name
            postProjectPage.SearchProjectName(projectName);
            log.Info("Enter the project name.");
            Thread.Sleep(1000);

            //Click Search button
            postProjectPage.ClickSearchBtn();
            log.Info("Click the Search button.");
            Thread.Sleep(15000);

            //Verify Draft status of Project
            postProjectPage.VerifyProjectDraftStatusMarketplace();
            log.Info("Verify Draft status of Project.");
            Thread.Sleep(2000);            
        }

        [Test]
        public void PostProject_004_VerifyDataAboutPage()
        {
            Global.MethodName = "PostProject_004_VerifyDataAboutPage";

            //Post a new project
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(6));
            String projectName = readPostProject.GetValue("AddProjectDetails", "projectName");
            projectName = projectName + builder;

            //Click Post Project tab
            Thread.Sleep(3000);
            postProjectPage.ClickPostProject();
            Thread.Sleep(5000);

            //Enter the Project Name
            postProjectPage.EnterProjectName(projectName);
            Thread.Sleep(1000);

            //Enter the Project Description
            String projectDesc = readPostProject.GetValue("AddProjectDetails", "projectDesc");
            postProjectPage.EnterProjectDescription(projectDesc);
            Thread.Sleep(1000);

            //Enter the Project Deliverables
            String projectDelv = readPostProject.GetValue("AddProjectDetails", "projectDelv");
            postProjectPage.EnterProjectDeliverables(projectDelv);
            Thread.Sleep(1000);

            //Select the Project Category
            String projectCategory = readPostProject.GetValue("AddProjectDetails", "projectCategory");
            postProjectPage.SelectProjectCategory(projectCategory);
            log.Info("Enter Project Category.");
            Thread.Sleep(1000);

            //Select Project Type
            String projectType = readPostProject.GetValue("AddProjectDetails", "projectType");
            postProjectPage.SelectProjectType(projectType);
            log.Info("Enter Project Type.");
            Thread.Sleep(1000);
     
            //Click Continue Button
            postProjectPage.ClickContinueBtn();
            log.Info("Click on the Continue button.");
            Thread.Sleep(6000);

            //Enter Skills
            commonPage.ScrollUp();
            Thread.Sleep(2000);
            String skills = readPostProject.GetValue("AddProjectDetails", "skills");
            postProjectPage.EnterSkillsNeeded(skills);
            Thread.Sleep(4000);
            commonPage.PressEnterKey();
            Thread.Sleep(2000);
            log.Info("Enter Skills.");

            //Enter the Project Location
            String projectLocation = readPostProject.GetValue("AddProjectDetails", "projectLocation");
            postProjectPage.EnterProjectLocation(projectLocation);
            Thread.Sleep(4000);
            commonPage.PressDownArrowKey();
            Thread.Sleep(1000);
            commonPage.PressEnterKey();
            log.Info("Select Project Location.");
            Thread.Sleep(1000);

            //Select Remote Checkbox
            postProjectPage.ClickRemoteCheckbox();
            log.Info("Select Remote check-box.");
            Thread.Sleep(2000);

            //Select Onsite Checkbox
            postProjectPage.ClickOnsiteCheckbox();
            log.Info("Select Onsite check-box.");
            Thread.Sleep(2000);
            
            //Select Expected Time Commitment
            String expectedTimeCommt = readPostProject.GetValue("AddProjectDetails", "expectedTimeCommt");
            postProjectPage.SelectExpectedTimeCommt(expectedTimeCommt);
            log.Info("Select Expected Time Commitment.");
            Thread.Sleep(1000);

            //Enter No Of Members Needed
            String noOfMembers = readPostProject.GetValue("AddProjectDetails", "noOfMembers");
            postProjectPage.EnterMembersNeeded(noOfMembers);
            log.Info("Enter Number of Members needed");
            Thread.Sleep(1000);

            //Enter Member Name
            String memberEmail = readPostProject.GetValue("AddProjectDetails", "memberEmail");
            postProjectPage.EnterMemberName(memberEmail);
            Thread.Sleep(3000);
            commonPage.PressEnterKey();
            log.Info("Enter members email id.");
            Thread.Sleep(1000);

            //Click Add button
            postProjectPage.ClickAddBtn();
            log.Info("Click Add button.");
            Thread.Sleep(3000);

            //Click Continue Button
            postProjectPage.ClickContinueBtn();
            log.Info("Click on the Continue button.");
            Thread.Sleep(10000);

            //Click Publish button
            commonPage.ScrollDown();
            Thread.Sleep(2000);
            postProjectPage.ClickPublishBtn();
            log.Info("Click Publish Button");
            Thread.Sleep(7000);

            //Verify the Project Name on About page
            postProjectPage.VerifyProjectName(projectName);
            log.Info("Verify the Project Name on About page");
            Thread.Sleep(1000);

            //Verify the Project Description on About page
            postProjectPage.VerifyProjectDesc(projectDesc);
            log.Info("Verify the Project Description on About page");
            Thread.Sleep(1000);

            //Verify the Project Deliverables on About page
           // postProjectPage.VerifyProjectDelv(projectDelv);
            log.Info("Verify the Project Deliverables on About page");
            Thread.Sleep(1000);

            //Verify the Project Skills on About page
            postProjectPage.VerifyProjectSkills(skills);
            log.Info("Verify the Project Skills on About page");
            Thread.Sleep(1000);

            //Verify the Project Type on About page
            postProjectPage.VerifyProjectType(projectType);
            log.Info("Verify the Project Type on About page");
            Thread.Sleep(1000);

            //Verify the Project Location on About page
            postProjectPage.VerifyProjectLocation(projectLocation);
            log.Info("Verify the Project Location on About page");
            Thread.Sleep(1000);

            //Verify the Project Staff on About page
            postProjectPage.VerifyProjectStaffOnsite();
            log.Info("Verify the Project Staff Onsite on About page");
            Thread.Sleep(1000);

            //Verify the Project Staff on About page
            postProjectPage.VerifyProjectStaffRemote();
            log.Info("Verify the Project Staff Remote on About page");

            Thread.Sleep(1000);
            //Verify the Project Category on About page
            postProjectPage.VerifyProjectCategory(projectCategory);
            log.Info("Verify the Project Category on About page");
            Thread.Sleep(1000);

            //Verify the Project Hours on About page
            postProjectPage.VerifyProjectHours(expectedTimeCommt);
            log.Info("Verify the Project Hours on About page");
            Thread.Sleep(1000);

            //Delete Project
            Thread.Sleep(3000);
            DeleteProject();
        }

        [Test]
        public void PostProject_005_AddMembersAndVerify()
        {
            Global.MethodName = "PostProject_005_AddMembersAndVerify";

            //Post a new project
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(6));
            String projectName = readPostProject.GetValue("AddProjectDetails", "projectName");
            projectName = projectName + builder;
            PostNewProject(projectName);

            //Verify About tab of the project after creation
            postProjectPage.VerifyAboutTabOnPage();
            Thread.Sleep(1000);

            String addMembersName = readPostProject.GetValue("AddProjectDetails", "memberName");
            List<String> addMembersNameList = addMembersName.Split(',').ToList();
            //int noOfMember = addMembersNameList.Count;
            foreach (String value in addMembersNameList)
            {
                postProjectPage.VerifyMemberName(value);
                Thread.Sleep(2000);
            }            
        }

        [Test]
        public void PostProject_020_AddMembersAfterProjectCreationAndVerify()
        {
            Global.MethodName = "PostProject_020_AddMembersAfterProjectCreationAndVerify";

            //Post a new project
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(6));
            String projectName = readPostProject.GetValue("AddProjectDetails", "projectName");
            projectName = projectName + builder;
            PostNewProjectWithoutMember(projectName);
            Thread.Sleep(5000);
            //Verify About tab of the project after creation
            postProjectPage.VerifyAboutTabOnPage();
            Thread.Sleep(1000);

            //Click Settings Icon
            postProjectPage.ClickSettingsIcon();
            log.Info("Click Settings Icon");
            Thread.Sleep(3000);

            //Select Project Settings Option
            postProjectPage.SelectProjectOption("Manage Team");
            log.Info("Select Edit Project option.");
            Thread.Sleep(5000);

            String addMembersEmail = readPostProject.GetValue("AddProjectDetails", "memberEmail");
            List<String> addMembersEmailList = addMembersEmail.Split(',').ToList();
            int noOfMember = addMembersEmailList.Count;
            foreach (String value in addMembersEmailList)
            {
                postProjectPage.EnterMemberName(value);
                Thread.Sleep(2000);
                commonPage.PressEnterKey();
                Thread.Sleep(5000);
                postProjectPage.ClickAddBtn();
                log.Info("Click Add button.");
                Thread.Sleep(3000);
            }

            //Click Save Button
            postProjectPage.ClickManageTeamSaveBtn();
            log.Info("Click on the Save button.");
            Thread.Sleep(5000);

            String addMembersName = readPostProject.GetValue("AddProjectDetails", "memberName");
            List<String> addMembersNameList = addMembersName.Split(',').ToList();
            //int noOfMember = addMembersNameList.Count;
            foreach (String value in addMembersNameList)
            {
                postProjectPage.VerifyMemberName(value);
                Thread.Sleep(2000);
            }
        }

        [Test]
        public void PostProject_006_EditProjectAndVerify()
        {
            Global.MethodName = "PostProject_006_EditProjectAndVerify";

            //Post a new project
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(6));
            String projectName = readPostProject.GetValue("AddProjectDetails", "projectName");
            projectName = projectName + builder;
            PostNewProject(projectName);

            //Click Settings Icon
            postProjectPage.ClickSettingsIcon();
            log.Info("Click Settings Icon");
            Thread.Sleep(3000);

            //Select Project Settings Option
            postProjectPage.SelectProjectOption("Edit Project");
            log.Info("Select Edit Project option.");
            Thread.Sleep(5000);

            //Verify General Tab
            postProjectPage.VerifyGeneralTab();
            log.Info("Verify General Tab on Edit Page");
            Thread.Sleep(1000);

            //Verify Staffing Info Tab
            postProjectPage.VerifyStaffingInfoTab();
            log.Info("Verify Staffing Info Tab on Edit Page");
            Thread.Sleep(1000);

            //Enter the Project Name
            projectName = projectName + "Edited";
            postProjectPage.EnterProjectName(projectName);
            Thread.Sleep(1000);

            /*//Enter the Project Description
            String projectDesc = "Description Edited";
            postProjectPage.EnterProjectDescription(projectDesc);
            Thread.Sleep(1000);*/
            
            //Click Staffing Info Tab
            postProjectPage.ClickStaffingInfoTab();
            log.Info("Click on the Staffing Info Tab.");
            Thread.Sleep(5000);

            //Enter Skills
            postProjectPage.EnterSkillsNeeded("Java");
            Thread.Sleep(3000);
            commonPage.PressEnterKey();
            Thread.Sleep(2000);
            log.Info("Enter Skills.");

            //Click Save Button
            postProjectPage.ClickSaveBtn();
            log.Info("Click on the Save button.");
            Thread.Sleep(5000);

            //Verify the Project Name on About page
            postProjectPage.VerifyProjectName(projectName);
            log.Info("Verify the Project Name on About page");
            Thread.Sleep(1000);

            /*//Verify the Project Description on About page
            postProjectPage.VerifyProjectDesc("Description Edited");
            log.Info("Verify the Project Description on About page");
            Thread.Sleep(1000); */                     

            //Verify the Project Skills on About page
            postProjectPage.VerifyProjectSkills("Java");
            log.Info("Verify the Project Skills on About page");
            Thread.Sleep(1000);

            //Delete Project
            Thread.Sleep(3000);
            DeleteProject();
        }

        [Test]
        public void PostProject_007_ManageProjectTeam()
        {//done
            Global.MethodName = "PostProject_007_ManageProjectTeam";

            //Post a new project
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(6));
            String projectName = readPostProject.GetValue("AddProjectDetails", "projectName");
            projectName = projectName + builder;
            PostNewProject(projectName);

            //Click Settings Icon
            postProjectPage.ClickSettingsIcon();
            log.Info("Click Settings Icon");
            Thread.Sleep(3000);

            //Select Project Settings Option
            postProjectPage.SelectProjectOption("Manage Team");
            log.Info("Select Edit Project option.");
            Thread.Sleep(5000);                       

            //Remove Member from Project
            postProjectPage.ClickRemoveMemberIcon();
            log.Info("Click Member Remove icon");
            Thread.Sleep(3000);

            //Remove Member from Project
            postProjectPage.ClickRemoveMemberIcon();
            log.Info("Click Member Remove icon");
            Thread.Sleep(3000);

            //Add New Member in the Team
            String manageTeamAddMemberEmail = readPostProject.GetValue("AddProjectDetails", "manageTeamAddMemberEmail");
            postProjectPage.EnterMemberName(manageTeamAddMemberEmail);
            Thread.Sleep(2000);
            commonPage.PressEnterKey();
            Thread.Sleep(5000);
            postProjectPage.ClickAddBtn();
            log.Info("Click Add button.");
            Thread.Sleep(3000);

            //Click Save Button
            postProjectPage.ClickManageTeamSaveBtn();
            log.Info("Click on the Save button.");
            Thread.Sleep(5000);

            //Verify removed members not displayed on Project About Page            
            String addMembersName = readPostProject.GetValue("AddProjectDetails", "memberName");
            List<String> addMembersNameList = addMembersName.Split(',').ToList();
            //noOfMember = addMembersNameList.Count;
            foreach (String value in addMembersNameList)
            {
                postProjectPage.VerifyMemberNotExists(value);
                Thread.Sleep(2000);
            }

            //Verify added member is displayed on Project About Page            
            String manageTeamMemberName = readPostProject.GetValue("AddProjectDetails", "manageTeamMemberName");
            postProjectPage.VerifyMemberName(manageTeamMemberName);
            Thread.Sleep(2000);

            //Delete Project
            DeleteProject();
        }

        [Test]
        public void PostProject_008_CompleteProject()
        {
            Global.MethodName = "PostProject_008_CompleteProject";

            //Post a new project
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(6));
            String projectName = readPostProject.GetValue("AddProjectDetails", "projectName");
            projectName = projectName + builder;
            PostNewProject(projectName);

            //Click on Mark Complete button
            Thread.Sleep(7000);
            postProjectPage.ClickMarkCompleteBtn();
            log.Info("Click Mark Complete button.");
            Thread.Sleep(5000);

            //Select Awesome rating for user1
            postProjectPage.SelectAwesomeRatingUserOne();
            log.Info("Select Awesome rating for user1");
            Thread.Sleep(2000);

            //Select Awesome rating for user2
            postProjectPage.SelectAwesomeRatingUserTwo();
            log.Info("Select Awesome rating for user2");
            Thread.Sleep(2000);       

            //Click on side point on  Project complete window
            postProjectPage.ClickSidePointonCompleteProjectBtn();
            log.Info("Click Complete Project side button.");
            Thread.Sleep(7000);

            //Click on Complete Project button
            postProjectPage.ClickCompleteProjectBtn();
            log.Info("Click Complete Project button.");
            Thread.Sleep(7000);

            //Verify Update Metrics button on About Page
            postProjectPage.VerifyUpdateMetricsBtn();
            log.Info("Verify Update Metrics button on About Page.");
            Thread.Sleep(1000);

            //Verify the Completed Status on About Page
            postProjectPage.VerifyCompletedStatus();
            log.Info("Verify Completed Status on About Page.");
            Thread.Sleep(1000);

            //Delete Project
            DeleteProject();
        }

        [Test]
        public void PostProject_009_MarkProjectInProgress()
        {
            Global.MethodName = "PostProject_009_MarkProjectInProgress";

            //Post a new project
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(6));
            String projectName = readPostProject.GetValue("AddProjectDetails", "projectName");
            projectName = projectName + builder;
            PostNewProject(projectName);

            //Click Settings Icon
            postProjectPage.ClickSettingsIcon();
            log.Info("Click Settings Icon");
            Thread.Sleep(3000);

            //Select Project Settings Option
            postProjectPage.SelectProjectOption("Edit Project");
            log.Info("Select Edit Project option.");
            Thread.Sleep(5000);

            //Select Project Status as In Progress
            postProjectPage.SelectProjectStatus("In Progress");
            log.Info("Select Project status as 'In Progress'");
            Thread.Sleep(3000);

            //Click Save Button
            postProjectPage.ClickSaveBtn();
            log.Info("Click on the Save button.");
            Thread.Sleep(5000);

            //Verify the In Progress Status on About Page
            postProjectPage.VerifyInProgressStatus();
            log.Info("Verify In Progress Status on About Page.");
            Thread.Sleep(1000);

            //Delete Project
            DeleteProject();
        }

        [Test]
        public void PostProject_010_MarkProjectClosed()
        {
            Global.MethodName = "PostProject_010_MarkProjectClosed";

            //Post a new project
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(6));
            String projectName = readPostProject.GetValue("AddProjectDetails", "projectName");
            projectName = projectName + builder;
            PostNewProject(projectName);

            //Click Settings Icon
            postProjectPage.ClickSettingsIcon();
            log.Info("Click Settings Icon");
            Thread.Sleep(3000);

            //Select Project Settings Option
            postProjectPage.SelectProjectOption("Edit Project");
            log.Info("Select Edit Project option.");
            Thread.Sleep(5000);

            //Select Project status as Closed
            postProjectPage.SelectProjectStatus("Closed");
            log.Info("Select Project status as 'Closed'");
            Thread.Sleep(2000);

            //Click Save Button
            postProjectPage.ClickSaveBtn();
            log.Info("Click on the Save button.");
            Thread.Sleep(5000);

            //Verify the Closed Status on About Page
            postProjectPage.VerifyClosedStatus();
            log.Info("Verify Closed Status on About Page.");
            Thread.Sleep(1000);

            //Verify the Update Metrics button on About Page
            postProjectPage.VerifyUpdateMetricsBtn();
            log.Info("Verify Update Metrics button on About Page.");
            Thread.Sleep(1000);

            //Delete Project
            DeleteProject();
        }        

        [Test]
        public void PostProject_011_RequestToJoinProject()
        {
            Global.MethodName = "PostProject_011_RequestToJoinProject";

            //Post a new project
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(6));
            String projectName = readPostProject.GetValue("AddProjectDetails", "projectName");
            projectName = projectName + builder;
            PostNewProject(projectName);

            //Signout of the application
            Thread.Sleep(5000);
            authenticationPage.SignOut();
            log.Info("Click on the Signout button.");

            //Sign in with a different user
            Thread.Sleep(5000);
            String userName = readPostProject.GetValue("SignInDifferentUserForRequestToJoin", "userName");
            String password = readPostProject.GetValue("SignInDifferentUserForRequestToJoin", "password");
            SignInDifferentUser(userName, password);
            log.Info("Sign in with different user.");

            //Enter the Project Name
            Thread.Sleep(5000);
            postProjectPage.SearchProjectName(projectName);
            log.Info("Enter the project name.");
            Thread.Sleep(1000);

            //Click Search button
            postProjectPage.ClickSearchBtn();
            log.Info("Click the Search button.");
            Thread.Sleep(15000);

            //Click the created project
            postProjectPage.ClickProjectNameOnPage(projectName);
            log.Info("Click the Project Name on the Projects Page.");
            Thread.Sleep(10000);

            //Click Request to Join button displayed on the screen
            postProjectPage.ClickRequestToJoinBtn();
            log.Info("Click Request To Join button displayed on screen.");
            Thread.Sleep(5000);

            //Verify the Requested button displayed on screen or not
            postProjectPage.AsssertRequestSentBtn();
            log.Info("Verify Requested button displayed on screen.");
            Thread.Sleep(1000);

            //Signout of the application
            Thread.Sleep(5000);
            authenticationPage.SignOut();
            log.Info("Click on the Signout button.");

            //Login to the application
            authenticationPage.SetUserName(_workEmail);
            authenticationPage.SetPassword(_password);
            authenticationPage.ClickOnLoginButton();

            //Enter the Project Name
            Thread.Sleep(5000);
            postProjectPage.SearchProjectName(projectName);
            log.Info("Enter the project name.");
            Thread.Sleep(1000);

            //Click Search button
            postProjectPage.ClickSearchBtn();
            log.Info("Click the prSearch button.");
            Thread.Sleep(15000);

            //Click the created project
            postProjectPage.ClickProjectNameOnPage(projectName);
            log.Info("Click the Project Name on the Projects Page.");
            Thread.Sleep(5000);

            //Delete Project
            Thread.Sleep(3000);
            DeleteProject();
        }

        [Test]
        public void PostProject_012_AcceptRequestToJoinProject()
        {
            Global.MethodName = "PostProject_012_AcceptRequestToJoinProject";

            //Post a new project
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(6));
            String projectName = readPostProject.GetValue("AddProjectDetails", "projectName");
            projectName = projectName + builder;
            PostNewProject(projectName);

            //Signout of the application
            Thread.Sleep(5000);
            authenticationPage.SignOut();
            log.Info("Click on the Signout button.");

            //Sign in with a different user
            Thread.Sleep(5000);
            String userName = readPostProject.GetValue("SignInDifferentUserForRequestToJoin", "userName");
            String password = readPostProject.GetValue("SignInDifferentUserForRequestToJoin", "password");
            SignInDifferentUser(userName, password);
            log.Info("Sign in with different user.");

            //Enter the Project Name
            Thread.Sleep(5000);
            postProjectPage.SearchProjectName(projectName);
            log.Info("Enter the project name.");
            Thread.Sleep(1000);

            //Click Search button
            postProjectPage.ClickSearchBtn();
            log.Info("Click the Search button.");
            Thread.Sleep(15000);

            //Click the created project
            postProjectPage.ClickProjectNameOnPage(projectName);
            log.Info("Click the Project Name on the Projects Page.");
            Thread.Sleep(10000);

            //Click Request to Join button displayed on the screen
            postProjectPage.ClickRequestToJoinBtn();
            log.Info("Click Request To Join button displayed on screen.");
            Thread.Sleep(5000);
            
            //Signout of the application
            Thread.Sleep(5000);
            authenticationPage.SignOut();
            log.Info("Click on the Signout button.");

            //Login to the application
            authenticationPage.SetUserName(_workEmail);
            authenticationPage.SetPassword(_password);
            authenticationPage.ClickOnLoginButton();

            //Enter the Project Name
            Thread.Sleep(5000);
            postProjectPage.SearchProjectName(projectName);
            log.Info("Enter the project name.");
            Thread.Sleep(1000);

            //Click Search button
            postProjectPage.ClickSearchBtn();
            log.Info("Click the prSearch button.");
            Thread.Sleep(15000);

            //Click the created project
            postProjectPage.ClickProjectNameOnPage(projectName);
            log.Info("Click the Project Name on the Projects Page.");
            Thread.Sleep(5000);

            //Click Settings Icon
            postProjectPage.ClickSettingsIcon();
            log.Info("Click Settings Icon");
            Thread.Sleep(3000);

            //Select Project Settings Option
            postProjectPage.SelectProjectOption("Manage Team");
            log.Info("Select Edit Project option.");
            Thread.Sleep(8000);

            //Click Requested User Accept Icon
            postProjectPage.RequestedUserAcceptIcon();
            log.Info("Click Requested User Accept Icon");
            Thread.Sleep(2000);

            //Click Save Button
            postProjectPage.ClickManageTeamSaveBtn();
            log.Info("Click on the Save button.");
            Thread.Sleep(5000);
                        
            //Verify added member is displayed on Project About Page            
            String manageTeamMemberName = readPostProject.GetValue("AddProjectDetails", "manageTeamMemberName");
            postProjectPage.VerifyMemberName(manageTeamMemberName);
            Thread.Sleep(2000);

            //Delete Project
            DeleteProject();
        }

        [Test]
        public void PostProject_013_RejectRequestToJoinProject()
        {
            Global.MethodName = "PostProject_013_RejectRequestToJoinProject";

            //Post a new project
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(6));
            String projectName = readPostProject.GetValue("AddProjectDetails", "projectName");
            projectName = projectName + builder;
            PostNewProject(projectName);

            //Signout of the application
            Thread.Sleep(5000);
            authenticationPage.SignOut();
            log.Info("Click on the Signout button.");

            //Sign in with a different user
            Thread.Sleep(5000);
            String userName = readPostProject.GetValue("SignInDifferentUserForRequestToJoin", "userName");
            String password = readPostProject.GetValue("SignInDifferentUserForRequestToJoin", "password");
            SignInDifferentUser(userName, password);
            log.Info("Sign in with different user.");

            //Enter the Project Name
            Thread.Sleep(5000);
            postProjectPage.SearchProjectName(projectName);
            log.Info("Enter the project name.");
            Thread.Sleep(1000);

            //Click Search button
            postProjectPage.ClickSearchBtn();
            log.Info("Click the Search button.");
            Thread.Sleep(15000);

            //Click the created project
            postProjectPage.ClickProjectNameOnPage(projectName);
            log.Info("Click the Project Name on the Projects Page.");
            Thread.Sleep(10000);

            //Click Request to Join button displayed on the screen
            postProjectPage.ClickRequestToJoinBtn();
            log.Info("Click Request To Join button displayed on screen.");
            Thread.Sleep(5000);

            //Signout of the application
            Thread.Sleep(5000);
            authenticationPage.SignOut();
            log.Info("Click on the Signout button.");

            //Login to the application
            authenticationPage.SetUserName(_workEmail);
            authenticationPage.SetPassword(_password);
            authenticationPage.ClickOnLoginButton();

            //Enter the Project Name
            Thread.Sleep(5000);
            postProjectPage.SearchProjectName(projectName);
            log.Info("Enter the project name.");
            Thread.Sleep(1000);

            //Click Search button
            postProjectPage.ClickSearchBtn();
            log.Info("Click the prSearch button.");
            Thread.Sleep(15000);

            //Click the created project
            postProjectPage.ClickProjectNameOnPage(projectName);
            log.Info("Click the Project Name on the Projects Page.");
            Thread.Sleep(5000);

            //Click Settings Icon
            postProjectPage.ClickSettingsIcon();
            log.Info("Click Settings Icon");
            Thread.Sleep(3000);

            //Select Project Settings Option
            postProjectPage.SelectProjectOption("Manage Team");
            log.Info("Select Edit Project option.");
            Thread.Sleep(8000);

            //Click Requested User Reject Icon
            postProjectPage.RequestedUserRejectIcon();
            log.Info("Click Requested User Accept Icon");
            Thread.Sleep(2000);

            //Click Save Button
            postProjectPage.ClickManageTeamSaveBtn();
            log.Info("Click on the Save button.");
            Thread.Sleep(5000);

            //Verify added member is not displayed on Project About Page            
            String manageTeamMemberName = readPostProject.GetValue("AddProjectDetails", "manageTeamMemberName");
            postProjectPage.VerifyMemberNameNotDisplayed(manageTeamMemberName);
            Thread.Sleep(2000);

            //Delete Project
            DeleteProject();
        }

        [Test]
        public void PostProject_014_PostNewPrivateProject()
        {
            Global.MethodName = "PostProject_014_PostNewPrivateProject";

            //Post a Project
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(6));
            String projectName = readPostProject.GetValue("AddProjectDetails", "projectName");
            projectName = projectName + builder;
            PostNewPrivateProject(projectName);
            
            //Verify the Private icon on the Projects Page
            postProjectPage.AssertPrivateIcon();
            log.Info("Assert Private Icon.");
            Thread.Sleep(1000);

            //Delete Project
            DeleteProject();
        }

        [Test]
        public void PostProject_015_VerifyNonAdminCannotAccessPrivateProject()
        {
            Global.MethodName = "PostProject_015_VerifyNonAdminCannotAccessPrivateProject";

            //Post a new project
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(6));
            String projectName = readPostProject.GetValue("AddProjectDetails", "projectName");
            projectName = projectName + builder;
            PostNewPrivateProject(projectName);

            //Signout of the application
            Thread.Sleep(5000);
            authenticationPage.SignOut();
            log.Info("Click on the Signout button.");

            //Sign in with Steve Smith
            authenticationPage.SetUserName("smith@mailinator.com");
            authenticationPage.SetPassword("Logica360");
            authenticationPage.ClickOnLoginButton();
            Thread.Sleep(5000);

            //Click the Browse button
            marketplacePage.ClickBrowseBtn();
            log.Info("Click the Browse button.");
            Thread.Sleep(5000);

            //Enter the Project Name
            Thread.Sleep(5000);
            marketplacePage.EnterSearchField(projectName);
            log.Info("Enter the project name.");
            Thread.Sleep(1000);

            //Click Search button
            marketplacePage.ClickSearchBtn();
            log.Info("Click the Search button.");
            Thread.Sleep(7000);

            //Verify Project is not displayed
            postProjectPage.AssertProjectNotDisplayedMsg();
            log.Info("Verify Project is not displayed.");
            Thread.Sleep(1000);

            //Signout of the application
            Thread.Sleep(5000);
            authenticationPage.SignOut();
            log.Info("Click on the Signout button.");

            //Login to the application
            authenticationPage.SetUserName(_workEmail);
            authenticationPage.SetPassword(_password);
            authenticationPage.ClickOnLoginButton();

            //Click the Browse button
            Thread.Sleep(5000);
            marketplacePage.ClickBrowseBtn();
            log.Info("Click the Browse button.");
            Thread.Sleep(7000);

            //Enter the Project Name
            marketplacePage.EnterSearchField(projectName);
            log.Info("Enter the project name.");
            Thread.Sleep(1000);

            //Click Search button
            marketplacePage.ClickSearchBtn();
            log.Info("Click the Search button.");
            Thread.Sleep(7000);

            //Click the created project
            postProjectPage.ClickProjectNameOnPage(projectName);
            log.Info("Click the Project Name on the Projects Page.");
            Thread.Sleep(5000);

            //Delete Project
            Thread.Sleep(3000);
            DeleteProject();
        }

        [Test]
        public void PostProject_016_VerifyInvitedUsersCanAccessPrivateProject()
        {
            Global.MethodName = "PostProject_016_VerifyInvitedUsersCanAccessPrivateProject";

            //Post a new project
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(6));
            String projectName = readPostProject.GetValue("AddProjectDetails", "projectName");
            projectName = projectName + builder;
            PostNewPrivateProject(projectName);

            //Signout of the application
            Thread.Sleep(5000);
            authenticationPage.SignOut();
            log.Info("Click on the Signout button.");

            //Sign in with Bob Lewis
            authenticationPage.SetUserName("bobl@mailinator.com");
            authenticationPage.SetPassword("Logica360");
            authenticationPage.ClickOnLoginButton();
            Thread.Sleep(5000);

            //Click the Browse button
            marketplacePage.ClickBrowseBtn();
            log.Info("Click the Browse button.");
            Thread.Sleep(7000);

            //Enter the Project Name
            marketplacePage.EnterSearchField(projectName);
            log.Info("Enter the project name.");
            Thread.Sleep(1000);

            //Click Search button
            marketplacePage.ClickSearchBtn();
            log.Info("Click the Search button.");
            Thread.Sleep(7000);

            //Click the Project displayed
            postProjectPage.ClickProjectNameOnPage(projectName);
            log.Info("Click the Project displayed.");
            Thread.Sleep(1000);

            //Signout of the application
            Thread.Sleep(5000);
            authenticationPage.SignOut();
            log.Info("Click on the Signout button.");

            //Login to the application
            authenticationPage.SetUserName(_workEmail);
            authenticationPage.SetPassword(_password);
            authenticationPage.ClickOnLoginButton();

            //Click the Browse button
            Thread.Sleep(5000);
            marketplacePage.ClickBrowseBtn();
            log.Info("Click the Browse button.");
            Thread.Sleep(7000);

            //Enter the Project Name
            marketplacePage.EnterSearchField(projectName);
            log.Info("Enter the project name.");
            Thread.Sleep(1000);

            //Click Search button
            marketplacePage.ClickSearchBtn();
            log.Info("Click the Search button.");
            Thread.Sleep(7000);

            //Click the created project
            postProjectPage.ClickProjectNameOnPage(projectName);
            log.Info("Click the Project Name on the Projects Page.");
            Thread.Sleep(5000);

            //Delete Project
            Thread.Sleep(3000);
            DeleteProject();
        }

        [Test]
        public void PostProject_017_VerifyAdminCanAccessPrivateProject()
        {
            Global.MethodName = "PostProject_017_VerifyAdminCanAccessPrivateProject";

            //Post a new project
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(6));
            String projectName = readPostProject.GetValue("AddProjectDetails", "projectName");
            projectName = projectName + builder;
            PostNewPrivateProject(projectName);

            //Signout of the application
            Thread.Sleep(5000);
            authenticationPage.SignOut();
            log.Info("Click on the Signout button.");

            //Sign in with a different user
            Thread.Sleep(5000);
            String userName = readPostProject.GetValue("SignInDifferentUser", "userName");
            String password = readPostProject.GetValue("SignInDifferentUser", "password");
            SignInDifferentUser(userName, password);
            log.Info("Sign in with different user.");

            //Click the Browse button
            marketplacePage.ClickBrowseBtn();
            log.Info("Click the Browse button.");
            Thread.Sleep(5000);

            //Enter the Project Name
            Thread.Sleep(5000);
            marketplacePage.EnterSearchField(projectName);
            log.Info("Enter the project name.");
            Thread.Sleep(1000);

            //Click Search button
            marketplacePage.ClickSearchBtn();
            log.Info("Click the Search button.");
            Thread.Sleep(10000);

            //Click the Project displayed
            postProjectPage.ClickProjectNameOnPage(projectName);
            log.Info("Click the Project displayed.");
            Thread.Sleep(1000);
            
            //Delete Project
            Thread.Sleep(3000);
            DeleteProject();
        }

        [Test]
        public void PostProject_018_ChangeFromPrivateToPublicAndVerify()
        {
            Global.MethodName = "PostProject_018_ChangeFromPrivateToPublicAndVerify";

            //Post a new project
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(6));
            String projectName = readPostProject.GetValue("AddProjectDetails", "projectName");
            projectName = projectName + builder;
            PostNewPrivateProject(projectName);

            //Click Private Icon
            postProjectPage.ClickPrivateIcon();
            log.Info("Click the private icon of the project.");
            Thread.Sleep(3000);

            //Signout of the application
            Thread.Sleep(5000);
            authenticationPage.SignOut();
            log.Info("Click on the Signout button.");

            //Sign in with Bob Lewis
            Thread.Sleep(5000);
            authenticationPage.SetUserName("bobl@mailinator.com");
            authenticationPage.SetPassword("Logica360");
            authenticationPage.ClickOnLoginButton();
            Thread.Sleep(5000);

            //Click the Browse button
            marketplacePage.ClickBrowseBtn();
            log.Info("Click the Browse button.");
            Thread.Sleep(7000);

            //Enter the Project Name
            marketplacePage.EnterSearchField(projectName);
            log.Info("Enter the project name.");
            Thread.Sleep(1000);

            //Click Search button
            marketplacePage.ClickSearchBtn();
            log.Info("Click the Search button.");
            Thread.Sleep(7000);

            //Click Project displayed
            postProjectPage.ClickProjectNameOnPage(projectName);
            log.Info("Click Project displayed.");
            Thread.Sleep(1000);

            //Signout of the application
            Thread.Sleep(5000);
            authenticationPage.SignOut();
            log.Info("Click on the Signout button.");

            //Login to the application
            Thread.Sleep(5000);
            authenticationPage.SetUserName(_workEmail);
            authenticationPage.SetPassword(_password);
            authenticationPage.ClickOnLoginButton();

            //Click the Browse button
            Thread.Sleep(5000);
            marketplacePage.ClickBrowseBtn();
            log.Info("Click the Browse button.");
            Thread.Sleep(7000);

            //Enter the Project Name
            marketplacePage.EnterSearchField(projectName);
            log.Info("Enter the project name.");
            Thread.Sleep(1000);

            //Click Search button
            marketplacePage.ClickSearchBtn();
            log.Info("Click the Search button.");
            Thread.Sleep(7000);

            //Click the created project
            postProjectPage.ClickProjectNameOnPage(projectName);
            log.Info("Click the Project Name on the Projects Page.");
            Thread.Sleep(5000);

            //Delete Project
            Thread.Sleep(3000);
            DeleteProject();
        }

        [Test]
        public void PostProject_019_PromoteProject()
        {
            Global.MethodName = "PostProject_019_PromoteProject";

            //Post a new project
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(6));
            String projectName = readPostProject.GetValue("AddProjectDetails", "projectName");
            projectName = projectName + builder;
            PostNewProject(projectName);

            //Click Settings Icon
            postProjectPage.ClickSettingsIcon();
            log.Info("Click Settings Icon");
            Thread.Sleep(3000);

            //Select Project Settings Option
            postProjectPage.SelectProjectOption("Promote Project");
            log.Info("Select Edit Project option.");
            Thread.Sleep(5000);

            //Enter New Skills
            postProjectPage.EnterSkillsNeeded("Feedback");
            Thread.Sleep(3000);
            commonPage.PressEnterKey();
            Thread.Sleep(2000);
            log.Info("Enter New Skills.");

            //Click Promote Button
            postProjectPage.ClickPromoteBtn();
            log.Info("Click Promote Button");
            Thread.Sleep(3000);

            //Verify Promote Project Success Message
            //postProjectPage.VerifyPromoteProjectSuccessMsg();
            //log.Info("Verify Promote Project Success Message.");
            //Thread.Sleep(1000);
            
            //Delete Project
            DeleteProject();
        }

        [Test]
        public void PostProject_021_POCanViewProjectAfterCreation()
        {
            Global.MethodName = "PostProject_021_POViewProjectAfterCreation";

            //Post a new project     
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(6));
            String projectName = readPostProject.GetValue("AddProjectDetails", "projectName");
            projectName = projectName + builder;
            PostNewProject(projectName);

            //Click on marketplace
            postProjectPage.ClickMarketPlaceMenu();
            log.Info("Click on marketplace menu");
            Thread.Sleep(2000);

            //Click the Browse button
            marketplacePage.ClickBrowseBtn();
            log.Info("Click the Browse button.");
            Thread.Sleep(7000);

            //Enter the Project Name
            marketplacePage.EnterSearchField(projectName);
            log.Info("Enter the project name.");
            Thread.Sleep(1000);

            //Click Search button
            marketplacePage.ClickSearchBtn();
            log.Info("Click the Search button.");
            Thread.Sleep(7000);

            //Click Project displayed
            postProjectPage.ClickProjectNameOnPage(projectName);
            log.Info("Click Project displayed.");
            Thread.Sleep(1000);


            //Delete Project
            DeleteProject();
        }

        [Test]
        public void PostProject_022_UserLeaveProject()
        {
            Global.MethodName = "PostProject_022_UserLeaveProject";

            //Post a new project
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(6));
            String projectName = readPostProject.GetValue("AddProjectDetails", "projectName");
            projectName = projectName + builder;
            PostNewProject(projectName);

            //Signout of the application
            Thread.Sleep(5000);
            authenticationPage.SignOut();
            log.Info("Click on the Signout button.");

            //Sign in with a different user
            Thread.Sleep(5000);
            String userName = readPostProject.GetValue("AddProjectDetails", "leftMemberEmail");
            String password = readPostProject.GetValue("SignInDifferentUser", "password");
            SignInDifferentUser(userName, password);
            log.Info("Sign in with different user.");

            //Enter the Project Name
            Thread.Sleep(5000);
            postProjectPage.SearchProjectName(projectName);
            log.Info("Enter the project name.");
            Thread.Sleep(1000);

            //Click Search button
            postProjectPage.ClickSearchBtn();
            log.Info("Click the Search button.");
            Thread.Sleep(15000);

            //Click the created project
            postProjectPage.ClickProjectNameOnPage(projectName);
            log.Info("Click the Project Name on the Projects Page.");
            Thread.Sleep(10000);

            //Click Leave Project button on Project About Page
            postProjectPage.ClickAboutPageLeaveProjectBtn();
            log.Info("Click Leave Project button on Project About Page.");
            Thread.Sleep(5000);

            //Verify user successfully remove from project
            postProjectPage.AssertRequestToJoinBtn();
            log.Info("Verify user successfully remove from project");

            //Signout of the application
            Thread.Sleep(5000);
            authenticationPage.SignOut();
            log.Info("Click on the Signout button.");

            //Login to the application
            authenticationPage.SetUserName(_workEmail);
            authenticationPage.SetPassword(_password);
            authenticationPage.ClickOnLoginButton();
          
            //Enter the Project Name
            Thread.Sleep(5000);
            postProjectPage.SearchProjectName(projectName);
            log.Info("Enter the project name.");
            Thread.Sleep(1000);

            //Click Search button
            postProjectPage.ClickSearchBtn();
            log.Info("Click the Search button.");
            Thread.Sleep(15000);

            //Click the created project
            postProjectPage.ClickProjectNameOnPage(projectName);
            log.Info("Click the Project Name on the Projects Page.");
            Thread.Sleep(10000);

            //Delete Project
            DeleteProject();
        }

        [Test]
        public void PostProject_023_VerifyDraftProjectCanSeenOnlyToPO()
        {
            Global.MethodName = "PostProject_023_VerifyDraftProjectCanSeenOnlyToPO";

            //Post a new project
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(6));
            String projectName = readPostProject.GetValue("AddProjectDetails", "projectName");
            projectName = projectName + builder;

            //Click Post Project tab
            Thread.Sleep(3000);
            postProjectPage.ClickPostProject();
            Thread.Sleep(5000);

            //Enter the Project Name
            postProjectPage.EnterProjectName(projectName);
            Thread.Sleep(1000);

            //Enter the Project Description
            String projectDesc = readPostProject.GetValue("AddProjectDetails", "projectDesc");
            postProjectPage.EnterProjectDescription(projectDesc);
            Thread.Sleep(1000);

            //Click Continue Button
            postProjectPage.ClickContinueBtn();
            log.Info("Click on the Continue button.");
            Thread.Sleep(5000);

            //Enter Skills
            commonPage.ScrollUp();
            Thread.Sleep(2000);
            String skills = readPostProject.GetValue("AddProjectDetails", "skills");
            postProjectPage.EnterSkillsNeeded(skills);
            Thread.Sleep(3000);
            commonPage.PressEnterKey();
            Thread.Sleep(2000);
            log.Info("Enter Skills.");

            //Click Back button
            postProjectPage.ClickBackBtn();
            log.Info("Click on the Back button.");
            Thread.Sleep(3000);

            //Click Save Draft button
            postProjectPage.ClickSaveDraftBtn();
            log.Info("Click on the Save Draft button.");
            Thread.Sleep(10000);

            //Enter the Project Name
            postProjectPage.SearchProjectName(projectName);
            log.Info("Enter the project name.");
            Thread.Sleep(1000);

            //Click Search button
            postProjectPage.ClickSearchBtn();
            log.Info("Click the Search button.");
            Thread.Sleep(15000);

            //Click the created project
            postProjectPage.ClickProjectNameOnPage(projectName);
            log.Info("Click the Project Name on the Projects Page.");
            Thread.Sleep(10000);

            //Click Continue Button
            postProjectPage.ClickContinueBtn();
            log.Info("Click on the Continue button.");
            Thread.Sleep(3000);

            //Click Save Draft button
            postProjectPage.ClickSaveDraftBtn();
            log.Info("Click on the Save Draft button.");
            Thread.Sleep(10000);

            //Enter the Project Name
            postProjectPage.SearchProjectName(projectName);
            log.Info("Enter the project name.");
            Thread.Sleep(1000);

            //Click Search button
            postProjectPage.ClickSearchBtn();
            log.Info("Click the Search button.");
            Thread.Sleep(15000);

            //Click the created project
            postProjectPage.ClickProjectNameOnPage(projectName);
            log.Info("Click the Project Name on the Projects Page.");
            Thread.Sleep(10000);

            //Click Continue Button
            postProjectPage.ClickContinueBtn();
            log.Info("Click on the Continue button.");
            Thread.Sleep(3000);

            //Click Continue Button
            postProjectPage.ClickContinueBtn();
            log.Info("Click on the Continue button.");
            Thread.Sleep(3000);

            //Click Save Draft button
            postProjectPage.ClickSaveDraftBtn();
            log.Info("Click on the Save Draft button.");
            Thread.Sleep(10000);

            //Enter the Project Name
            postProjectPage.SearchProjectName(projectName);
            log.Info("Enter the project name.");
            Thread.Sleep(1000);

            //Click Search button
            postProjectPage.ClickSearchBtn();
            log.Info("Click the Search button.");
            Thread.Sleep(15000);

            //Verify Draft status of Project
            postProjectPage.VerifyProjectDraftStatusMarketplace();
            log.Info("Verify Draft status of Project.");
            Thread.Sleep(2000);


            //Signout of the application
            Thread.Sleep(5000);
            authenticationPage.SignOut();
            log.Info("Click on the Signout button.");

            //Sign in with a different user
            Thread.Sleep(5000);
            String userName = readPostProject.GetValue("SignInDifferentUser", "userName");
            String password = readPostProject.GetValue("SignInDifferentUser", "password");
            SignInDifferentUser(userName, password);
            log.Info("Sign in with different user.");

            //Click the Browse button
            marketplacePage.ClickBrowseBtn();
            log.Info("Click the Browse button.");
            Thread.Sleep(5000);

            //Enter the Project Name
            Thread.Sleep(5000);
            marketplacePage.EnterSearchField(projectName);
            log.Info("Enter the project name.");
            Thread.Sleep(1000);

            //Click Search button
            marketplacePage.ClickSearchBtn();
            log.Info("Click the Search button.");
            Thread.Sleep(10000);

            //Verify Project is not displayed
            postProjectPage.AssertProjectNotDisplayedMsg();
            log.Info("Verify Project is not displayed.");
            Thread.Sleep(1000);





        }

        [Test]
        public void PostProject_024_ProjectOwnerHasAllTabsAfterAcceptJoinProjectRequest()
        {
            Global.MethodName = "PostProject_024_POHasAllTabsAfterAcceptJoinProjectRequest";

            //Post a new project
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(6));
            String projectName = readPostProject.GetValue("AddProjectDetails", "projectName");
            projectName = projectName + builder;
            PostNewProject(projectName);

            //Signout of the application
            Thread.Sleep(5000);
            authenticationPage.SignOut();
            log.Info("Click on the Signout button.");

            //Sign in with a different user
            Thread.Sleep(5000);
            String userName = readPostProject.GetValue("SignInDifferentUserForRequestToJoin", "userName");
            String password = readPostProject.GetValue("SignInDifferentUserForRequestToJoin", "password");
            SignInDifferentUser(userName, password);
            log.Info("Sign in with different user.");

            //Enter the Project Name
            Thread.Sleep(5000);
            postProjectPage.SearchProjectName(projectName);
            log.Info("Enter the project name.");
            Thread.Sleep(1000);

            //Click Search button
            postProjectPage.ClickSearchBtn();
            log.Info("Click the Search button.");
            Thread.Sleep(15000);

            //Click the created project
            postProjectPage.ClickProjectNameOnPage(projectName);
            log.Info("Click the Project Name on the Projects Page.");
            Thread.Sleep(10000);

            //Click Request to Join button displayed on the screen
            postProjectPage.ClickRequestToJoinBtn();
            log.Info("Click Request To Join button displayed on screen.");
            Thread.Sleep(5000);

            //Signout of the application
            Thread.Sleep(5000);
            authenticationPage.SignOut();
            log.Info("Click on the Signout button.");

            //Login to the application
            authenticationPage.SetUserName(_workEmail);
            authenticationPage.SetPassword(_password);
            authenticationPage.ClickOnLoginButton();

            //Enter the Project Name
            Thread.Sleep(5000);
            postProjectPage.SearchProjectName(projectName);
            log.Info("Enter the project name.");
            Thread.Sleep(1000);

            //Click Search button
            postProjectPage.ClickSearchBtn();
            log.Info("Click the prSearch button.");
            Thread.Sleep(15000);

            //Click the created project
            postProjectPage.ClickProjectNameOnPage(projectName);
            log.Info("Click the Project Name on the Projects Page.");
            Thread.Sleep(5000);

            //Click Settings Icon
            postProjectPage.ClickSettingsIcon();
            log.Info("Click Settings Icon");
            Thread.Sleep(3000);

            //Select Project Settings Option
            postProjectPage.SelectProjectOption("Manage Team");
            log.Info("Select Edit Project option.");
            Thread.Sleep(8000);

            //Click Requested User Accept Icon
            postProjectPage.RequestedUserAcceptIcon();
            log.Info("Click Requested User Accept Icon");
            Thread.Sleep(2000);

            //Click Save Button
            postProjectPage.ClickManageTeamSaveBtn();
            log.Info("Click on the Save button.");
            Thread.Sleep(5000);

            //Verify added member is displayed on Project About Page            
            String manageTeamMemberName = readPostProject.GetValue("AddProjectDetails", "manageTeamMemberName");
            postProjectPage.VerifyMemberName(manageTeamMemberName);
            log.Info("Verify added member is displayed on Project About Page.");
            Thread.Sleep(2000);

            //Verify PO has always Discussions, Tasks and Files tab rights after accepted join request (ENG-4731)

            postProjectPage.VerifyProjectTabs("Discussions");
            log.Info("Verify PO has always Discussions tab rights after accepted join request.");
            Thread.Sleep(2000);

            postProjectPage.VerifyProjectTabs("Tasks");
            log.Info("Verify PO has always Tasks tab rights after accepted join request.");
            Thread.Sleep(2000);

            postProjectPage.VerifyProjectTabs("Files");
            log.Info("Verify PO has always Files tab rights after accepted join request.");
            Thread.Sleep(2000);

            //Delete Project
            DeleteProject();
        }

        [Test]
        public void PostProject_025_VerifyPrivatePromoteProject()
        {
            Global.MethodName = "PostProject_025_VerifyPrivatePromoteProject";

            ////Onboard a new User
            onBoardNewUser();

            //Click on the Signout button.
            Thread.Sleep(5000);
            authenticationPage.SignOut();
            log.Info("Click on the Signout button.");

            //Login to the application
            authenticationPage.SetUserName(_workEmail);
            authenticationPage.SetPassword(_password);
            authenticationPage.ClickOnLoginButton();

            //Post a new project
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(6));
            String projectName = readPostProject.GetValue("AddProjectDetails", "projectName");
            projectName = projectName + builder;
            PostNewProject(projectName,true);

            //Click Settings Icon
            postProjectPage.ClickSettingsIcon();
            log.Info("Click Settings Icon");
            Thread.Sleep(3000);

            //Select Project Settings Option
            postProjectPage.SelectProjectOption("Promote Project");
            log.Info("Select Edit Project option.");
            Thread.Sleep(5000);

            //Enter New Skills
            postProjectPage.EnterSkillsNeeded("JIRA");
            Thread.Sleep(3000);
            commonPage.PressEnterKey();
            Thread.Sleep(2000);
            log.Info("Enter New Skills.");

            //Click Promote Button
            postProjectPage.ClickPromoteBtn();
            log.Info("Click Promote Button");
            Thread.Sleep(3000);


            //Click on the Signout button.
            Thread.Sleep(5000);
            authenticationPage.SignOut();
            log.Info("Click on the Signout button.");

            //Login to the application
            authenticationPage.SetUserName(email);
            authenticationPage.SetPassword(_password);
            authenticationPage.ClickOnLoginButton();

            Thread.Sleep(3000);

            //Click Notifications Icon
            notificationsPage.ClickNotificationsIcon();
            log.Info("Click on the Notifications Icon at top.");
            Thread.Sleep(5000);

            //Verify the User Recruited to Project short notification on the Notification Window
            notificationsPage.VerifyUserRecruitedToProjectNotificationWindow();
            log.Info("Verify the User Recruited to Project short notification on the Notification Window.");
            Thread.Sleep(1000);

            //Click See All link
            notificationsPage.ClickSeeAll();
            log.Info("Click See All link.");
            Thread.Sleep(7000);

            //Verify the User Recruited to Project Notification on Notifications Page
            notificationsPage.VerifyUserRecruitedToProject();
            log.Info("Verify the User Recruited to Project Notification on Notifications Page.");
            Thread.Sleep(1000);

            //Navigate to the user inbox
            commonPage.NavigateToUrl("https://www.harakirimail.com/");
            log.Info("Navigate to the mailinator site.");
            Thread.Sleep(7000);

            //Enter Harakirimail Email address
            addUsersPage.EnterHarakirimailEmail(email);
            log.Info("Enter email address.");
            Thread.Sleep(2000);

            //Press Enter key
            commonPage.PressEnterKey();
            log.Info("press enter for open email.");
            Thread.Sleep(5000);

            //Click the Email Subject
            addUsersPage.ClickRecruitedEmailSubject();
            log.Info("Click the Email Subject.");
            Thread.Sleep(5000);

            // Verify Promote Project Success Message
            //postProjectPage.VerifyPromoteProjectSuccessMsg();
            // log.Info("Verify Promote Project Success Message.");
            // Thread.Sleep(1000);

            //Click on go relly button
            commonPage.ScrollDown();
            postProjectPage.ClickGORallyButton();
            log.Info("Click on go relly button.");
            Thread.Sleep(15000);
            

            //Verify the Project Name on About page
            postProjectPage.VerifyProjectName(projectName);
            log.Info("Verify the Project Name on About page");
            Thread.Sleep(1000);

            //Signout of the application
            Thread.Sleep(5000);
            authenticationPage.SignOut();
            log.Info("Click on the Signout button.");

            //Login to the application
            authenticationPage.SetUserName(_workEmail);
            authenticationPage.SetPassword(_password);
            authenticationPage.ClickOnLoginButton();

            //Enter the Project Name
            Thread.Sleep(5000);
            postProjectPage.SearchProjectName(projectName);
            log.Info("Enter the project name.");
            Thread.Sleep(1000);

            //Click Search button
            postProjectPage.ClickSearchBtn();
            log.Info("Click the prSearch button.");
            Thread.Sleep(15000);

            //Click the created project
            postProjectPage.ClickRecProjectNameOnPage(projectName);
            log.Info("Click the Project Name on the Projects Page.");
            Thread.Sleep(5000);

            //Delete Project
            DeleteProject();
        }

    }
}
