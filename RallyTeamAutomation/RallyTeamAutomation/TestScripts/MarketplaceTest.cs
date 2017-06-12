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
    [Category("Marketplace")]
    public class MarketplaceTest : BaseTestES
    {
        static ReadData readPostProject = new ReadData("PostProject");

        //SignIn
        private void SignInDifferentUser()
        {
            String userName = readPostProject.GetValue("SignInDifferentUser", "userName");
            String password = readPostProject.GetValue("SignInDifferentUser", "password");
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

            //Press Delete Project Window Yes button
            postProjectPage.PressDeleteProjectWindowYesBtn();
            log.Info("Press Delete Project Window Yes button.");
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

            //Click Publish button
            commonPage.ScrollDown();
            Thread.Sleep(2000);
            postProjectPage.ClickPublishBtn();
            log.Info("Click Publish Button");
            Thread.Sleep(7000);
        }

        [Test]
        public void Marketplace_001_SearchProject()
        {
            Global.MethodName = "Marketplace_001_SearchProject";

            //Post a new project
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(6));
            String projectName = readPostProject.GetValue("AddProjectDetails", "projectName");
            projectName = projectName + builder;
            PostNewProject(projectName);

            //Click the Marketplace tab
            marketplacePage.ClickMarketplaceTab();
            log.Info("Click the Marketplace tab.");
            Thread.Sleep(5000);

            //Click Browse button
            marketplacePage.ClickBrowseBtn();
            log.Info("Click Browse button.");
            Thread.Sleep(5000);

            //Enter the Project Name
            postProjectPage.SearchProjectName(projectName);
            log.Info("Enter the project name.");
            Thread.Sleep(2000);

            //Click Search button
            marketplacePage.ClickSearchBtn();
            log.Info("Click the Search button.");
            Thread.Sleep(12000);

            //Click the created Project
            marketplacePage.ClickProjectNameOnPage(projectName);
            log.Info("Click the Project Name on the Projects Page.");
            Thread.Sleep(5000);           
           
            //Delete Project
            DeleteProject();
        }

        [Test]
        public void Marketplace_002_BrowseAndSearchProject()
        {
            Global.MethodName = "Marketplace_002_BrowseAndSearchProject";

            //Post a new project
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(6));
            String projectName = readPostProject.GetValue("AddProjectDetails", "projectName");
            projectName = projectName + builder;
            PostNewProject(projectName);

            //Click the Marketplace tab
            marketplacePage.ClickMarketplaceTab();
            log.Info("Click the Marketplace tab.");
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
            Thread.Sleep(5000);

            //Click the created Project
            marketplacePage.ClickProjectNameOnPage(projectName);
            log.Info("Click the Project Name on the Projects Page.");
            Thread.Sleep(5000);

            //Delete Project
            DeleteProject();
        }

        [Test]
        public void Marketplace_003_VerifyProjectsIveJoinedSearch()
        {
            Global.MethodName = "Marketplace_003_VerifyProjectsIveJoinedSearch";

            //Post a new project
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(6));
            String projectName = readPostProject.GetValue("AddProjectDetails", "projectName");
            projectName = projectName + builder;
            PostNewProject(projectName);
            
            //Click the Marketplace tab
            marketplacePage.ClickMarketplaceTab();
            log.Info("Click the Marketplace tab.");
            Thread.Sleep(5000);

            //Click the Browse button
            marketplacePage.ClickBrowseBtn();
            log.Info("Click the Browse button.");
            Thread.Sleep(5000);

            //Enter the Project Name          
            marketplacePage.EnterSearchField(projectName);
            log.Info("Enter the project name.");
            Thread.Sleep(7000);

            //Select Projects I've Joined from the All Projects drop-down
            marketplacePage.SelectAllProjectsDropDown("Projects I've Joined");
            log.Info("Select Projects I Own from the drop-down.");
            Thread.Sleep(5000);

            //Click the created Project
            marketplacePage.ClickProjectNameOnPage(projectName);
            log.Info("Click the Project Name on the Projects Page.");
            Thread.Sleep(5000);

            //Delete Project
            DeleteProject();
        }

        [Test]
        public void Marketplace_004_VerifyProjectsIOwnSearch()
        {
            Global.MethodName = "Marketplace_004_VerifyProjectsIOwnSearch";

            //Post a new project
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(6));
            String projectName = readPostProject.GetValue("AddProjectDetails", "projectName");
            projectName = projectName + builder;
            PostNewProject(projectName);

            //Click the Marketplace tab
            marketplacePage.ClickMarketplaceTab();
            log.Info("Click the Marketplace tab.");
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

            //Select My Projects from the All Projects drop-down
            marketplacePage.SelectAllProjectsDropDown("Projects I Own");
            log.Info("Select My Projects from the drop-down.");
            Thread.Sleep(5000);

            //Click the created Project
            marketplacePage.ClickProjectNameOnPage(projectName);
            log.Info("Click the Project Name on the Projects Page.");
            Thread.Sleep(5000);

            //Delete Project
            DeleteProject();
        }

        [Test]
        public void Marketplace_005_VerifyRecruitingProjectsSearch()
        {
            Global.MethodName = "Marketplace_005_VerifyRecruitingProjectsSearch";

            //Post a new project
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(6));
            String projectName = readPostProject.GetValue("AddProjectDetails", "projectName");
            projectName = projectName + builder;
            PostNewProject(projectName);

            //Click the Marketplace tab
            marketplacePage.ClickMarketplaceTab();
            log.Info("Click the Marketplace tab.");
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

            //Select Projects in Recruiting from the All Projects drop-down
            marketplacePage.SelectAllProjectsDropDown("Projects in Recruiting");
            log.Info("Select Projects in Recruiting from the drop-down.");
            Thread.Sleep(5000);

            //Click the created Project
            marketplacePage.ClickProjectNameOnPage(projectName);
            log.Info("Click the Project Name on the Projects Page.");
            Thread.Sleep(5000);

            //Delete Project
            DeleteProject();
        }

        [Test]
        public void Marketplace_006_VerifyRecommendedProjectsSearch()
        {
            Global.MethodName = "Marketplace_006_VerifyRecommendedProjectsSearch";

            //Post a new project
            //Enter the Project Name
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(6));
            String projectName = "Testing Recommended";
            projectName = projectName + builder;
            PostNewProject(projectName);
            //postProjectPage.EnterProjectName(projectName);
            Thread.Sleep(1000);
                        
            //Signout of the application
            Thread.Sleep(5000);
            authenticationPage.SignOut();
            log.Info("Click on the Signout button.");

            //Sign in with a different user
            Thread.Sleep(2000);
            SignInDifferentUser();
            log.Info("Sign in with different user.");

            //Click the Marketplace tab
            Thread.Sleep(5000);
            marketplacePage.ClickMarketplaceTab();
            log.Info("Click the Marketplace tab.");
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

            //Select Recommended Projects from the All Projects drop-down
            marketplacePage.SelectAllProjectsDropDown("Recommended Projects");
            log.Info("Select Recommended Projects from the drop-down.");
            Thread.Sleep(5000);

            //Signout of the application
            Thread.Sleep(5000);
            authenticationPage.SignOut();
            log.Info("Click on the Signout button.");
            Thread.Sleep(5000);

            //Login to the application
            authenticationPage.SetUserName(_workEmail);
            authenticationPage.SetPassword(_password);
            authenticationPage.ClickOnLoginButton();

            //Click Browse button
            Thread.Sleep(5000);
            marketplacePage.ClickBrowseBtn();
            log.Info("Click Browse button.");
            Thread.Sleep(5000);

            //Enter the Project Name
            postProjectPage.SearchProjectName(projectName);
            log.Info("Enter the project name.");
            Thread.Sleep(2000);

            //Click Search button
            marketplacePage.ClickSearchBtn();
            log.Info("Click the Search button.");
            Thread.Sleep(12000);

            //Click the created project
            marketplacePage.ClickProjectNameOnPage(projectName);
            log.Info("Click the Project Name on the Projects Page.");
            Thread.Sleep(5000);

            //Delete Project
            Thread.Sleep(3000);
            DeleteProject();
        }

        [Test]
        public void Marketplace_007_VerifyInProgressProjectsSearch()
        {
            Global.MethodName = "Marketplace_007_VerifyInProgressProjectsSearch";

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

            //Select Project status as In Progress
            postProjectPage.SelectProjectStatus("In Progress");
            log.Info("Select Project status as 'In Progress'");
            Thread.Sleep(3000);

            //Click Save Button
            postProjectPage.ClickSaveBtn();
            log.Info("Click on the Save button.");
            Thread.Sleep(5000);

            //Click the Marketplace tab
            marketplacePage.ClickMarketplaceTab();
            log.Info("Click the Marketplace tab.");
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

            //Select In Progress from the All Projects drop-down
            marketplacePage.SelectAllProjectsDropDown("Projects In Progress");
            log.Info("Select In Progress from the drop-down.");
            Thread.Sleep(5000);

            //Click the created Project
            marketplacePage.ClickProjectNameOnPage(projectName);
            log.Info("Click the Project Name on the Projects Page.");
            Thread.Sleep(5000);

            //Delete Project
            DeleteProject();
        }

        [Test]
        public void Marketplace_008_VerifyCompletedProjectsSearch()
        {
            Global.MethodName = "Marketplace_008_VerifyCompletedProjectsSearch";

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

            commonPage.ScrollDown();
            postProjectPage.ClickSidePointonCompleteProjectBtn();

            //Click on Complete Project button
            postProjectPage.ClickCompleteProjectBtn();
            log.Info("Click Complete Project button.");
            Thread.Sleep(7000);

            //Click the Marketplace tab
            marketplacePage.ClickMarketplaceTab();
            log.Info("Click the Marketplace tab.");
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

            //Select Completed Projects from the All Projects drop-down
            marketplacePage.SelectAllProjectsDropDown("Completed Projects");
            log.Info("Select Completed Projects from the drop-down.");
            Thread.Sleep(5000);

            //Click the created Project
            marketplacePage.ClickProjectNameOnPage(projectName);
            log.Info("Click the Project Name on the Projects Page.");
            Thread.Sleep(5000);

            //Delete Project
            DeleteProject();
        }

        [Test]
        public void Marketplace_009_VerifyClosedProjectsSearch()
        {
            Global.MethodName = "Marketplace_009_VerifyClosedProjectsSearch";

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

            //Click the Marketplace tab
            marketplacePage.ClickMarketplaceTab();
            log.Info("Click the Marketplace tab.");
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

            //Select Closed Projects from the All Projects drop-down
            marketplacePage.SelectAllProjectsDropDown("Closed Projects");
            log.Info("Select Closed Projects from the drop-down.");
            Thread.Sleep(5000);

            //Click the created Project
            marketplacePage.ClickProjectNameOnPage(projectName);
            log.Info("Click the Project Name on the Projects Page.");
            Thread.Sleep(5000);

            //Delete Project
            DeleteProject();
        }
        

    }
}
