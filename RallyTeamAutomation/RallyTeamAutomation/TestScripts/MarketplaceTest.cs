using NUnit.Framework;
using RallyTeam.UILocators;
using RallyTeam.Util;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RallyTeam.TestScripts
{
    [TestFixture("ExternalStormURL", "chrome", Category = "MarketplaceChromePreprod")]
    [TestFixture("ExternalStormURL", "firefox", Category = "MarketplaceFirefoxPreprod")]
    [TestFixture("Production", "chrome", Category = "MarketplaceChromeProduction")]
    [TestFixture("Production", "firefox", Category = "MarketplaceFirefoxProduction")]
    [Parallelizable(ParallelScope.Fixtures)]
    public class MarketplaceTest : BaseTestES
    {
        public MarketplaceTest(string urlKey, string Browser) : base(urlKey, Browser)
        {
            String url = urlKey;
        }

        static ReadData readPostProject = new ReadData("PostProject");
        static ReadData readProjectApproval = new ReadData("ProjectApproval");
        protected string _workEmail = ConfigurationSettings.AppSettings["workEmail"];
        protected string _password = ConfigurationSettings.AppSettings["password"];

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
        private void SignInDifferentUser(String userName, String password)
        {
            authenticationPage.SetUserName(userName);
            authenticationPage.SetPassword(password);
            authenticationPage.ClickOnLoginButton();
        }

        public void PostNewProjectForApproval(String projectName, bool publicProject = false)
        {

            //Click Post Project option
            Thread.Sleep(3000);
            postProjectPage.ClickCreateProjectJobBtn();
            Thread.Sleep(1000);
            postProjectPage.ClickNewProject();
            Thread.Sleep(5000);

            //Enter the Project Name
            postProjectPage.EnterProjectName(projectName);
            Thread.Sleep(1000);

            //Enter the Project Description
            String projectDesc = readPostProject.GetValue("AddProjectDetails", "projectDesc");
            postProjectPage.EnterProjectDescription(projectDesc);
            Thread.Sleep(1000);

            //Click Continue Button
            commonPage.ScrollDown();
            Thread.Sleep(1000);
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

            commonPage.ScrollDown();
            Thread.Sleep(1000);
            postProjectPage.EnterMembersNeeded("5");
            Thread.Sleep(1000);
            String addMembersEmail = readPostProject.GetValue("AddProjectDetails", "memberEmail");
            List<String> addMembersEmailList = addMembersEmail.Split(',').ToList();
            int noOfMember = addMembersEmailList.Count;
            foreach (String value in addMembersEmailList)
            {
                postProjectPage.EnterMemberName(value);
                Thread.Sleep(2000);
                commonPage.PressEnterKey();
                Thread.Sleep(5000);
                postProjectPage.ClickProjectAddBtn();
                log.Info("Click Add button.");
                Thread.Sleep(3000);
            }

            //Click Continue Button
            commonPage.ScrollDown();
            Thread.Sleep(1000);
            postProjectPage.ClickContinueBtn();
            log.Info("Click on the Continue button.");
            Thread.Sleep(10000);

            //Select private project
            if (publicProject)
            {
                Thread.Sleep(2000);
                postProjectPage.ClickPrivateProjectRdoBtn();
                log.Info("Click on private radio Button");
            }

            //Click Publish button
            commonPage.ScrollDown();
            Thread.Sleep(2000);
            postProjectPage.ClickSubmitForApprovalButton();
            log.Info("Click submit for approval Button");
            Thread.Sleep(7000);
        }

        //Post a Project
        public void PostNewProject(String projectName, string  skill="Testing",bool skilFlag=false)
        {
            String addMembersEmail=null;
            //Click Post Project option
            Thread.Sleep(3000);
            postProjectPage.ClickCreateProjectJobBtn();
            Thread.Sleep(1000);
            postProjectPage.ClickNewProject();
            Thread.Sleep(5000);

            //Enter the Project Name
            postProjectPage.EnterProjectName(projectName);
            Thread.Sleep(1000);

            //Enter the Project Description
            String projectDesc = readPostProject.GetValue("AddProjectDetails", "projectDesc");
            postProjectPage.EnterProjectDescription(projectDesc);
            Thread.Sleep(1000);

            //Click Continue Button
            commonPage.ScrollDown();
            Thread.Sleep(1000);
            postProjectPage.ClickContinueBtn();
            log.Info("Click on the Continue button.");
            Thread.Sleep(5000);

            //Enter Skills
            commonPage.ScrollUp();
            Thread.Sleep(2000);
            if(!skilFlag)
            skill = readPostProject.GetValue("AddProjectDetails", "skills");
            postProjectPage.EnterSkillsNeeded(skill);
            Thread.Sleep(3000);
            commonPage.PressEnterKey();
            Thread.Sleep(2000);
            log.Info("Enter Skills.");

            commonPage.ScrollDown();
            Thread.Sleep(1000);
            postProjectPage.EnterMembersNeeded("6");
            Thread.Sleep(1000);

            if (!skilFlag)
            {
                addMembersEmail = readPostProject.GetValue("AddProjectDetails", "memberEmail");
                List<String> addMembersEmailList = addMembersEmail.Split(',').ToList();
                int noOfMember = addMembersEmailList.Count;
                foreach (String value in addMembersEmailList)
                {
                    postProjectPage.EnterMemberName(value);
                    Thread.Sleep(2000);
                    commonPage.PressEnterKey();
                    Thread.Sleep(5000);
                    postProjectPage.ClickProjectAddBtn();
                    log.Info("Click Add button.");
                    Thread.Sleep(3000);
                }
            }
            //Click Continue Button
            commonPage.ScrollDown();
            Thread.Sleep(1000);
            postProjectPage.ClickContinueBtn();
            log.Info("Click on the Continue button.");
            Thread.Sleep(10000);

            //Select private project
            //if (publicProject)
            //{
            //    Thread.Sleep(2000);
            //    postProjectPage.ClickPrivateProjectRdoBtn();
            //    log.Info("Click Publish Button");
            //}

            //Click Publish button
            commonPage.ScrollDown();
            Thread.Sleep(2000);
            postProjectPage.ClickPublishBtn();
            log.Info("Click Publish Button");
            Thread.Sleep(7000);
        }

        [Test, CustomRetry(_reTryCount)]
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

            //Enter the Project Name
            postProjectPage.SearchProjectName(projectName);
            log.Info("Enter the project name.");
            Thread.Sleep(2000);

            //Click Home Search button
            marketplacePage.ClickHomeSearchBtn();
            log.Info("Click the Home Search button.");
            Thread.Sleep(12000);

            //Click the created Project
            marketplacePage.ClickProjectNameOnPage(projectName);
            log.Info("Click the Project Name on the Projects Page.");
            Thread.Sleep(5000);           
           
            //Delete Project
            DeleteProject();
        }

        [Test, CustomRetry(_reTryCount)]
        public void Marketplace_002_BrowseAndSearchDevelopmentProject()
        {
            Global.MethodName = "Marketplace_002_BrowseAndSearchDevelopmentProject";

            //Post a new project
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(6));
            String projectName = readPostProject.GetValue("AddProjectDetails", "projectName");
            projectName = projectName +DateTime.Now.Day+ DateTime.Now.DayOfWeek+ builder;
            PostNewProject(projectName,"Xamarin",true);

            //Signout of the application
            Thread.Sleep(3000);
            authenticationPage.SignOut();
            log.Info("Click on the Signout button.");

            //Sign in with a different user
            Thread.Sleep(2000);
            String userName = readProjectApproval.GetValue("SignInNonAdminUser", "userName");
            String password = readProjectApproval.GetValue("SignInNonAdminUser", "password");
            SignInDifferentUser(userName, password);
            log.Info("Sign in with different user.");      

            
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

            //Select Development Project from the All Projects drop-down
            marketplacePage.SelectAllProjectsDropDown("Development Projects");
            log.Info("Select Developmen tProject from the drop-down.");
            Thread.Sleep(5000);

            //Click the created Project
            marketplacePage.ClickProjectNameOnPage(projectName);
            log.Info("Click the Project Name on the Projects Page.");
            Thread.Sleep(5000);

            //Signout of the application
            Thread.Sleep(3000);
            authenticationPage.SignOut();
            log.Info("Click on the Signout button.");

            //Sign in with a different user
            Thread.Sleep(2000);         
            SignInDifferentUser(_workEmail, _password);
            log.Info("Sign in with different user.");

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

            //Select Development Projects
            marketplacePage.ClickProjectSearchButton();
            log.Info("Select Development Projects.");
            Thread.Sleep(5000);

            //Click the created Project
            marketplacePage.ClickProjectNameOnPage(projectName);
            log.Info("Click the Project Name on the Projects Page.");
            Thread.Sleep(5000);

            //Delete Project
            DeleteProject();
        }


        //Recommended Projects
        //Development Projects
        //Projects In Progress
        //Completed Projects
        //Closed Projects
        //Projects Needing Approval

        [Test, CustomRetry(_reTryCount)]
        public void Marketplace_003_VerifyProjectsNeedingApprovalSearch()
        {
            //Project need approval

            Global.MethodName = "Marketplace_003_VerifyProjectsNeedingApprovalSearch";

            Thread.Sleep(3000);
            authenticationPage.SignOut();
            log.Info("Click on the Signout button.");

            //Sign in with a different user
            Thread.Sleep(2000);
            String userName = readProjectApproval.GetValue("SignInNonAdminUser", "userName");
            String password = readProjectApproval.GetValue("SignInNonAdminUser", "password");
            SignInDifferentUser(userName, password);
            log.Info("Sign in with different user.");

            //Post a new project
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(6));
            String projectName = readProjectApproval.GetValue("AddProjectDetails", "projectName");
            projectName = projectName +DateTime.Now.Date.Day +builder;
            PostNewProjectForApproval(projectName);

            //Verify Recruit tag at project about page
            Thread.Sleep(2000);
            postProjectPage.VerifyPendingTagOnAboutPage();
            log.Info("Verify Project status pending when project approval ON");


            //Signout of the application
            Thread.Sleep(3000);
            authenticationPage.SignOut();
            log.Info("Click on the Signout button.");

            //Sign in with a different user
            Thread.Sleep(2000);
            userName = readProjectApproval.GetValue("SignInAdminUser", "userName");
            password = readProjectApproval.GetValue("SignInAdminUser", "password");
            SignInDifferentUser(userName, password);
            log.Info("Sign in with different user.");
       
            
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
            marketplacePage.SelectAllProjectsDropDown("Projects Needing Approval");
            log.Info("Select Projects Needing Approval.");
            Thread.Sleep(5000);

            //Click the created Project
            marketplacePage.ClickProjectNameOnPage(projectName);
            log.Info("Click the Project Name on the Projects Page.");
            Thread.Sleep(5000);

            //Delete Project
            DeleteProject();
        }

        //[Test]
        //public void Marketplace_004_VerifyProjectsIOwnSearch()
        //{
        //    Global.MethodName = "Marketplace_004_VerifyProjectsIOwnSearch";

        //    //Post a new project
        //    StringBuilder builder = new StringBuilder();
        //    builder.Append(RandomString(6));
        //    String projectName = readPostProject.GetValue("AddProjectDetails", "projectName");
        //    projectName = projectName + builder;
        //    PostNewProject(projectName);

        //    //Click the Marketplace tab
        //    marketplacePage.ClickMarketplaceTab();
        //    log.Info("Click the Marketplace tab.");
        //    Thread.Sleep(5000);

        //    //Click the Browse button
        //    marketplacePage.ClickBrowseBtn();
        //    log.Info("Click the Browse button.");
        //    Thread.Sleep(5000);

        //    //Enter the Project Name            
        //    marketplacePage.EnterSearchField(projectName);
        //    log.Info("Enter the project name.");
        //    Thread.Sleep(1000);

        //    //Select My Projects from the All Projects drop-down
        //    marketplacePage.SelectAllProjectsDropDown("Projects I Own");
        //    log.Info("Select My Projects from the drop-down.");
        //    Thread.Sleep(5000);

        //    //Click the created Project
        //    marketplacePage.ClickProjectNameOnPage(projectName);
        //    log.Info("Click the Project Name on the Projects Page.");
        //    Thread.Sleep(5000);

        //    //Delete Project
        //    DeleteProject();
        //}

        [Test, CustomRetry(_reTryCount)]
        public void Marketplace_005_VerifyRecruitingProjectsSearch()
        {
            Global.MethodName = "Marketplace_005_VerifyRecruitingProjectsSearch";

            //Post a new project
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(6));
            String projectName = readPostProject.GetValue("AddProjectDetails", "projectName");
            projectName = projectName + DateTime.Now.Day+builder;
            PostNewProject(projectName);

            //Click Settings Icon
            postProjectPage.ClickSettingsIcon();
            log.Info("Click Settings Icon");
            Thread.Sleep(3000);

            //Select Project Settings Option
            postProjectPage.SelectProjectOption("Edit Project");
            log.Info("Select Edit Project option.");
            Thread.Sleep(5000);

            //Select Project status as Recruiting
            postProjectPage.SelectProjectStatus("Recruiting");
            log.Info("Select Project status as 'Recruiting'");
            Thread.Sleep(3000);

            //Click Save Button
            commonPage.ScrollDown();
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

            //Click Search button on Marketplace Projects page
            marketplacePage.ClickProjectSearchButton();
            log.Info("Click Search button on Marketplace Projects page.");
            Thread.Sleep(10000);

            //Click the created Project
            marketplacePage.ClickProjectNameOnPage(projectName);
            log.Info("Click the Project Name on the Projects Page.");
            Thread.Sleep(5000);

            //Delete Project
            DeleteProject();
        }

        [Test, CustomRetry(_reTryCount)]
        public void Marketplace_006_VerifyRecommendedProjectsSearch()
        {
            Global.MethodName = "Marketplace_006_VerifyRecommendedProjectsSearch";

            //Post a new project
            //Enter the Project Name
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(6));
            String projectName = ""+DateTime.Now.Date.Day;
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

        [Test, CustomRetry(_reTryCount)]
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
            commonPage.ScrollDown();
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

        [Test, CustomRetry(_reTryCount)]
        public void Marketplace_008_VerifyCompletedProjectsSearch()
        {
            Global.MethodName = "Marketplace_008_VerifyCompletedProjectsSearch";

            //Post a new project
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(6));
            String projectName = readPostProject.GetValue("AddProjectDetails", "projectName");
            projectName = projectName +DateTime.Now.Date.Day+ builder;
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
            commonPage.ScrollDown();
            Thread.Sleep(1000);
            postProjectPage.SelectAwesomeRatingUserTwo();
            log.Info("Select Awesome rating for user2");
            Thread.Sleep(2000);

            //Click on side point on  Project complete window
            postProjectPage.ClickSidePointonCompleteProjectBtn();
            log.Info("Click Complete Project side button.");
            Thread.Sleep(7000);

            //Click on Complete Project button
            commonPage.ScrollDown();
            Thread.Sleep(1000);
            postProjectPage.ClickCompleteProjectBtn();
            log.Info("Click Complete Project button.");
            Thread.Sleep(7000);

            //Verify Update Metrics button on About Page
            commonPage.ScrollUp();
            Thread.Sleep(1000);
            postProjectPage.VerifyUpdateMetricsBtn();
            log.Info("Verify Update Metrics button on About Page.");
            Thread.Sleep(1000);

            //Verify the Completed Status on About Page
            postProjectPage.VerifyCompletedStatus();
            log.Info("Verify Completed Status on About Page.");
            Thread.Sleep(1000);

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

        [Test, CustomRetry(_reTryCount)]
        public void Marketplace_009_VerifyClosedProjectsSearch()
        {
            Global.MethodName = "Marketplace_009_VerifyClosedProjectsSearch";

            //Post a new project
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(6));
            String projectName = readPostProject.GetValue("AddProjectDetails", "projectName");
            projectName = projectName +DateTime.Now.Day +builder;
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
            commonPage.ScrollDown();
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
