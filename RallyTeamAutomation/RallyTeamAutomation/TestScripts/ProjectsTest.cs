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
    [Category("Projects")]
    public class ProjectsTest : BaseTest
    {
        static ReadData readProjects = new ReadData("Projects");
        
        //SignIn
        private void SignInDifferentUser()
        {
            String userName = readProjects.GetValue("SignInDifferentUser", "userName");
            String password = readProjects.GetValue("SignInDifferentUser", "password");
            authenticationPage.SetUserName(userName);
            authenticationPage.SetPassword(password);
            authenticationPage.ClickOnLoginButton();
        }

        //Delete Project
        public void DeleteProject()
        {
            //Click Delete Project Icon
            commonPage.ScrollUp();
            Thread.Sleep(3000);
            projectsPage.ClickDeleteProjectIcon();
            Thread.Sleep(2000);

            //Click the Delete Project Window Yes Button
            projectsPage.PressDeleteProjectWindowYesBtn();
            Thread.Sleep(2000);
        }

        //Create a Project
        private void CreateProject(String projectName)
        {
            //Click Projects menu option
            Thread.Sleep(3000);
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

        [Test]
        public void Projects_001_VerifyProjectsOption()
        {
            Global.MethodName = "Projects_001_VerifyProjectsOption";

            projectsPage.VerifyProjectsMenuOption();
            log.Info("Verify Projects menu icon");
        }

        [Test]
        public void Projects_005_VerifyIHavePostedProjects()
        {
            Global.MethodName = "Projects_005_VerifyIHavePostedProjects";

            //Create a new project
            Thread.Sleep(5000);
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(4));
            String projectName = readProjects.GetValue("AddProjectDetails", "projectName");
            projectName = projectName + builder;
            CreateProject(projectName);

            //Select Projects
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
            Thread.Sleep(2000);

            //Verify created project should be displayed on the Projects page
            projectsPage.VerifyProjectNameOnPage(projectName);
            log.Info("Verify the Project Name on the Projects Page.");
            Thread.Sleep(2000);

            //Click the created project
            projectsPage.ClickProjectNameOnPage(projectName);
            log.Info("Click the Project Name on the Projects Page.");
            Thread.Sleep(3000);

            //Delete Project
            DeleteProject();
            Thread.Sleep(2000);
        }

        [Test]
        public void Projects_007_VerifyRecruitingProjects()
        {
            Global.MethodName = "Projects_007_VerifyRecruitingProjects";

            //Create a new project
            Thread.Sleep(5000);
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(4));
            String projectName = readProjects.GetValue("AddProjectDetails", "projectName");
            projectName = projectName + builder;
            CreateProject(projectName);

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

            //Verify created project should be displayed on the Projects page
            projectsPage.VerifyProjectNameOnPage(projectName);
            log.Info("Verify the Project Name on the Projects Page.");
            Thread.Sleep(2000);

            //Click the created project
            projectsPage.ClickProjectNameOnPage(projectName);
            log.Info("Click the Project Name on the Projects Page.");
            Thread.Sleep(3000);

            //Delete Project
            DeleteProject();
            Thread.Sleep(2000);
        }

        [Test]
        public void Projects_008_VerifyInProgressProjects()
        {
            Global.MethodName = "Projects_008_VerifyInProgressProjects";

            //Create a new project
            Thread.Sleep(5000);
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(4));
            String projectName = readProjects.GetValue("AddProjectDetails", "projectName");
            projectName = projectName + builder;
            CreateProject(projectName);

            //Select Projects
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

            //Select Project status as In Progress
            projectsPage.SelectStatusDropDown("In Progress");
            log.Info("Select Project status as 'In Progress'");
            Thread.Sleep(5000);

            //Click Projects menu option
            projectsPage.ClickProjectsMenu();
            log.Info("Click the Projects menu option.");
            Thread.Sleep(5000);
            
            //Click the All Projects Dropdown option
            projectsPage.ClickAllProjectsDropDown();
            log.Info("Click the All Projects dropdown.");
            Thread.Sleep(2000);

            //Select In Progress option from All Projects Dropdown
            projectsPage.SelectAllProjectsInProgress();
            log.Info("Select 'In Progress' option from the All Projects dropdown.");
            Thread.Sleep(5000);

            //Verify created project should be displayed on the Projects page
            projectsPage.VerifyProjectNameOnPage(projectName);
            log.Info("Verify the Project Name on the Projects Page.");
            Thread.Sleep(2000);

            //Click the created project
            projectsPage.ClickProjectNameOnPage(projectName);
            log.Info("Click the Project Name on the Projects Page.");
            Thread.Sleep(5000);

            //Delete Project
            DeleteProject();
            Thread.Sleep(2000);
        }

        [Test]
        public void Projects_009_VerifyCompletedProjects()
        {
            Global.MethodName = "Projects_009_VerifyCompletedProjects";

            //Create a new project
            Thread.Sleep(5000);
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(4));
            String projectName = readProjects.GetValue("AddProjectDetails", "projectName");
            projectName = projectName + builder;
            CreateProject(projectName);

            //Select Projects
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

            //Select Project status as Completed
            projectsPage.SelectStatusDropDown("Completed");
            log.Info("Select Project status as 'Completed'");
            Thread.Sleep(4000);

            //Click on Mark Complete button
            projectsPage.ClickMarkComplete();
            log.Info("Click Mark Complete button.");
            Thread.Sleep(5000);

            //Click Projects menu option
            projectsPage.ClickProjectsMenu();
            log.Info("Click the Projects menu option.");
            Thread.Sleep(5000);

            //Click the All Projects Dropdown option
            projectsPage.ClickAllProjectsDropDown();
            log.Info("Click the All Projects dropdown.");
            Thread.Sleep(2000);

            //Select Completed option from All Projects Dropdown
            projectsPage.SelectAllProjectsCompleted();
            log.Info("Select 'Completed' option from the All Projects dropdown.");
            Thread.Sleep(5000);

            //Verify created project should be displayed on the Projects page
            projectsPage.VerifyProjectNameOnPage(projectName);
            log.Info("Verify the Project Name on the Projects Page.");
            Thread.Sleep(2000);

            //Click the created project
            projectsPage.ClickProjectNameOnPage(projectName);
            log.Info("Click the Project Name on the Projects Page.");
            Thread.Sleep(5000);

            //Delete Project
            DeleteProject();
            Thread.Sleep(2000);
        }

        [Test]
        public void Projects_010_VerifyClosedProjects()
        {
            Global.MethodName = "Projects_010_VerifyClosedProjects";

            //Create a new project
            Thread.Sleep(5000);
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(4));
            String projectName = readProjects.GetValue("AddProjectDetails", "projectName");
            projectName = projectName + builder;
            CreateProject(projectName);

            //Select Projects
            //Click Projects menu option
            projectsPage.ClickProjectsMenu();
            log.Info("Click the Projects menu option.");
            Thread.Sleep(5000);

            //Click the All Projects Dropdown option
            projectsPage.ClickAllProjectsDropDown();
            log.Info("Click the All Projects dropdown.");
            Thread.Sleep(5000);

            //Select I've Posted option from All Projects Dropdown
            projectsPage.SelectAllProjectsIvePosted();
            log.Info("Select I've Posted option from the All Projects dropdown.");
            Thread.Sleep(5000);

            //Click the created project
            projectsPage.ClickProjectNameOnPage(projectName);
            log.Info("Click the Project Name on the Projects Page.");
            Thread.Sleep(5000);

            //Select Project status as Closed
            projectsPage.SelectStatusDropDown("Closed");
            log.Info("Select Project status as 'Closed'");
            Thread.Sleep(2000);

            //Click Projects menu option
            projectsPage.ClickProjectsMenu();
            log.Info("Click the Projects menu option.");
            Thread.Sleep(5000);

            //Click the All Projects Dropdown option
            projectsPage.ClickAllProjectsDropDown();
            log.Info("Click the All Projects dropdown.");
            Thread.Sleep(2000);

            //Select Closed option from All Projects Dropdown
            projectsPage.SelectAllProjectsClosed();
            log.Info("Select 'Closed' option from the All Projects dropdown.");
            Thread.Sleep(5000);

            //Verify created project should be displayed on the Projects page
            projectsPage.VerifyProjectNameOnPage(projectName);
            log.Info("Verify the Project Name on the Projects Page.");
            Thread.Sleep(2000);

            //Click the created project
            projectsPage.ClickProjectNameOnPage(projectName);
            log.Info("Click the Project Name on the Projects Page.");
            Thread.Sleep(3000);

            //Delete Project
            DeleteProject();
            Thread.Sleep(2000);
        }

        [Test]
        public void Projects_011_VerifyJoiningOptionForRecruitingProject()
        {
            Global.MethodName = "Projects_011_VerifyJoiningOptionForRecruitingProject";

            //Create a new project
            Thread.Sleep(5000);
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(4));
            String projectName = readProjects.GetValue("AddProjectDetails", "projectName");
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
            Thread.Sleep(5000);

            //Verify created project should be displayed on the Projects page
            projectsPage.VerifyProjectNameOnPage(projectName);
            log.Info("Verify the Project Name on the Projects Page.");
            Thread.Sleep(2000);

            //Click the created project
            projectsPage.ClickProjectNameOnPage(projectName);
            log.Info("Click the Project Name on the Projects Page.");
            Thread.Sleep(3000);

            //Verify that Request to Join button is displayed on the screen
            projectsPage.AsssertRequestToJoinBtn();
            log.Info("Verify Request To Join button doisplayed on screen.");
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
            Thread.Sleep(5000);

            //Click the created project
            projectsPage.ClickProjectNameOnPage(projectName);
            log.Info("Click the Project Name on the Projects Page.");
            Thread.Sleep(5000);

            //Delete Project
            DeleteProject();
            Thread.Sleep(2000);
        }

        [Test]
        public void Projects_012_VerifyJoiningOptionForInProgressProject()
        {
            Global.MethodName = "Projects_012_VerifyJoiningOptionForInProgressProject";

            //Create a new project
            Thread.Sleep(5000);
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(4));
            String projectName = readProjects.GetValue("AddProjectDetails", "projectName");
            projectName = projectName + builder;
            CreateProject(projectName);

            //Select Projects
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

            //Select Project status as In Progress
            projectsPage.SelectStatusDropDown("In Progress");
            log.Info("Select Project status as 'In Progress'");
            Thread.Sleep(2000);

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

            //Select In Progress option from All Projects Dropdown
            projectsPage.SelectAllProjectsInProgress();
            log.Info("Select In Progress option from the All Projects dropdown.");
            Thread.Sleep(5000);

            //Click the created project
            projectsPage.ClickProjectNameOnPage(projectName);
            log.Info("Click the Project Name on the Projects Page.");
            Thread.Sleep(3000);

            //Verify that Request to Join button is displayed on the screen
            projectsPage.AsssertRequestToJoinBtn();
            log.Info("Verify Request To Join button doisplayed on screen.");
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

            //Click Projects menu option
            projectsPage.ClickProjectsMenu();
            log.Info("Click the Projects menu option.");
            Thread.Sleep(5000);

            //Click the All Projects Dropdown option
            projectsPage.ClickAllProjectsDropDown();
            log.Info("Click the All Projects dropdown.");
            Thread.Sleep(2000);

            //Select In Progress Posted option from All Projects Dropdown
            projectsPage.SelectAllProjectsInProgress();
            log.Info("Select 'In Progress' option from the All Projects dropdown.");
            Thread.Sleep(3000);

            //Click the created project
            projectsPage.ClickProjectNameOnPage(projectName);
            log.Info("Click the Project Name on the Projects Page.");
            Thread.Sleep(5000);

            //Delete Project
            DeleteProject();
            Thread.Sleep(2000);
        }

        /*[Test]
        public void Projects_013_VerifyJoiningOptionForCompletedProject()
        {
            Global.MethodName = "Projects_013_VerifyJoiningOptionForCompletedProject";

            //Create a new project
            Thread.Sleep(5000);
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(4));
            String projectName = readProjects.GetValue("AddProjectDetails", "projectName");
            projectName = projectName + builder;
            CreateProject(projectName);

            //Select Projects
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
            Thread.Sleep(2000);

            //Click the created project
            projectsPage.ClickProjectNameOnPage(projectName);
            log.Info("Click the Project Name on the Projects Page.");
            Thread.Sleep(3000);

            //Select Project status as Completed
            projectsPage.SelectStatusDropDown("Completed");
            log.Info("Select Project status as 'Completed'");
            Thread.Sleep(2000);

            //Click on Mark Complete button
            projectsPage.ClickMarkComplete();
            log.Info("Click Mark Complete button.");
            Thread.Sleep(3000);

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

            //Select Completed option from All Projects Dropdown
            projectsPage.SelectAllProjectsCompleted();
            log.Info("Select Completed option from the All Projects dropdown.");
            Thread.Sleep(3000);

            //Click the created project
            projectsPage.ClickProjectNameOnPage(projectName);
            log.Info("Click the Project Name on the Projects Page.");
            Thread.Sleep(5000);

            //Verify Request To Join Button not displayed
            projectsPage.AssertNoRequestToJoinBtn();
            log.Info("Verify the Request To Join Button.");
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
            log.Info("Select 'Completed' option from the All Projects dropdown.");
            Thread.Sleep(3000);

            //Click the created project
            projectsPage.ClickProjectNameOnPage(projectName);
            log.Info("Click the Project Name on the Projects Page.");
            Thread.Sleep(3000);

            //Delete Project
            DeleteProject();
            Thread.Sleep(2000);
        }

        [Test]
        public void Projects_014_VerifyJoiningOptionForClosedProject()
        {
            Global.MethodName = "Projects_014_VerifyJoiningOptionForClosedProject";

            //Create a new project
            Thread.Sleep(5000);
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(4));
            String projectName = readProjects.GetValue("AddProjectDetails", "projectName");
            projectName = projectName + builder;
            CreateProject(projectName);

            //Select Projects
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
            Thread.Sleep(2000);

            //Click the created project
            projectsPage.ClickProjectNameOnPage(projectName);
            log.Info("Click the Project Name on the Projects Page.");
            Thread.Sleep(3000);

            //Select Project status as Closed
            projectsPage.SelectStatusDropDown("Closed");
            log.Info("Select Project status as 'Closed'");
            Thread.Sleep(2000);

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

            //Select Closed option from All Projects Dropdown
            projectsPage.SelectAllProjectsClosed();
            log.Info("Select Closed option from the All Projects dropdown.");
            Thread.Sleep(3000);

            //Click the created project
            projectsPage.ClickProjectNameOnPage(projectName);
            log.Info("Click the Project Name on the Projects Page.");
            Thread.Sleep(5000);

            //Verify Request To Join Button not displayed
            projectsPage.AssertNoRequestToJoinBtn();
            log.Info("Verify the Request To Join Button.");
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

            //Click Projects menu option
            projectsPage.ClickProjectsMenu();
            log.Info("Click the Projects menu option.");
            Thread.Sleep(5000);

            //Click the All Projects Dropdown option
            projectsPage.ClickAllProjectsDropDown();
            log.Info("Click the All Projects dropdown.");
            Thread.Sleep(2000);

            //Select Closed Posted option from All Projects Dropdown
            projectsPage.SelectAllProjectsClosed();
            log.Info("Select 'Closed' option from the All Projects dropdown.");
            Thread.Sleep(3000);

            //Click the created project
            projectsPage.ClickProjectNameOnPage(projectName);
            log.Info("Click the Project Name on the Projects Page.");
            Thread.Sleep(3000);

            //Delete Project
            DeleteProject();
            Thread.Sleep(2000);
        }*/
        
        [Test]
        public void Projects_015_VerifyRequestSentOptionForRecruitingProject()
        {
            Global.MethodName = "Projects_015_VerifyRequestSentOptionForRecruitingProject";

            //Create a new project
            Thread.Sleep(5000);
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(4));
            String projectName = readProjects.GetValue("AddProjectDetails", "projectName");
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
            Thread.Sleep(5000);

            //Verify created project should be displayed on the Projects page
            projectsPage.VerifyProjectNameOnPage(projectName);
            log.Info("Verify the Project Name on the Projects Page.");
            Thread.Sleep(2000);

            //Click the created project
            projectsPage.ClickProjectNameOnPage(projectName);
            log.Info("Click the Project Name on the Projects Page.");
            Thread.Sleep(3000);

            //Verify that Request to Join button is displayed on the screen
            projectsPage.AsssertRequestToJoinBtn();
            log.Info("Verify Request To Join button doisplayed on screen.");
            Thread.Sleep(2000);

            //Click Request to Join button displayed
            projectsPage.ClickRequestToJoinBtn();
            log.Info("Click Request To Join button.");
            Thread.Sleep(3000);

            //Verify the Request Sent button displayed on screen or not
            projectsPage.AsssertRequestSentBtn();
            log.Info("Verify Request Sent button displayed on screen.");
            Thread.Sleep(1000);

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

            //Delete Project
            DeleteProject();
            Thread.Sleep(2000);
        }


        [Test]
        public void Projects_016_VerifyRequestSentOptionForInProgressProject()
        {
            Global.MethodName = "Projects_016_VerifyRequestSentOptionForInProgressProject";

            //Create a new project
            Thread.Sleep(5000);
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(4));
            String projectName = readProjects.GetValue("AddProjectDetails", "projectName");
            projectName = projectName + builder;
            CreateProject(projectName);

            //Select Projects
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

            //Select Project status as In Progress
            projectsPage.SelectStatusDropDown("In Progress");
            log.Info("Select Project status as 'In Progress'");
            Thread.Sleep(2000);

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

            //Select In Progress option from All Projects Dropdown
            projectsPage.SelectAllProjectsInProgress();
            log.Info("Select In Progress option from the All Projects dropdown.");
            Thread.Sleep(5000);

            //Click the created project
            projectsPage.ClickProjectNameOnPage(projectName);
            log.Info("Click the Project Name on the Projects Page.");
            Thread.Sleep(3000);

            //Verify that Request to Join button is displayed on the screen
            projectsPage.AsssertRequestToJoinBtn();
            log.Info("Verify Request To Join button doisplayed on screen.");
            Thread.Sleep(2000);

            //Click Request to Join button 
            projectsPage.ClickRequestToJoinBtn();
            log.Info("Click Request To Join button.");
            Thread.Sleep(3000);

            //Verify the Request Sent button displayed on screen or not
            projectsPage.AsssertRequestSentBtn();
            log.Info("Verify Request Sent button displayed on screen.");
            Thread.Sleep(1000);

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

            //Select In Progress Posted option from All Projects Dropdown
            projectsPage.SelectAllProjectsInProgress();
            log.Info("Select 'In Progress' option from the All Projects dropdown.");
            Thread.Sleep(5000);

            //Click the created project
            projectsPage.ClickProjectNameOnPage(projectName);
            log.Info("Click the Project Name on the Projects Page.");
            Thread.Sleep(5000);

            //Delete Project
            DeleteProject();
            Thread.Sleep(2000);
        }

        [Test]
        public void Projects_017_VerifyInProgressIvePostedProjects()
        {
            Global.MethodName = "Projects_017_VerifyInProgressIvePostedProjects";

            //Create a new project
            Thread.Sleep(5000);
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(4));
            String projectName = readProjects.GetValue("AddProjectDetails", "projectName");
            projectName = projectName + builder;
            CreateProject(projectName);

            //Select Projects
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
            Thread.Sleep(2000);

            //Click the created project
            projectsPage.ClickProjectNameOnPage(projectName);
            log.Info("Click the Project Name on the Projects Page.");
            Thread.Sleep(3000);

            //Select Project status as In Progress
            projectsPage.SelectStatusDropDown("In Progress");
            log.Info("Select Project status as 'In Progress'");
            Thread.Sleep(2000);

            //Click Projects menu option
            projectsPage.ClickProjectsMenu();
            log.Info("Click the Projects menu option.");
            Thread.Sleep(5000);

            //Click the All Projects Dropdown option
            projectsPage.ClickAllProjectsDropDown();
            log.Info("Click the All Projects dropdown.");
            Thread.Sleep(2000);

            //Select In Progress option from All Projects Dropdown
            projectsPage.SelectAllProjectsInProgress();
            log.Info("Select 'In Progress' option from the All Projects dropdown.");
            Thread.Sleep(2000);

            //Verify created project should be displayed on the Projects page
            projectsPage.VerifyProjectNameOnPage(projectName);
            log.Info("Verify the Project Name on the Projects Page.");
            Thread.Sleep(2000);

            //Click the created project
            projectsPage.ClickProjectNameOnPage(projectName);
            log.Info("Click the Project Name on the Projects Page.");
            Thread.Sleep(3000);

            //Delete Project
            DeleteProject();
            Thread.Sleep(2000);
        }

        [Test]
        public void Projects_020_VerifyLeaveProjectOption()
        {
            Global.MethodName = "Projects_020_VerifyLeaveProjectOption";

            //Create a new project
            Thread.Sleep(5000);
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(4));
            String projectName = readProjects.GetValue("AddProjectDetails", "projectName");
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
            Thread.Sleep(5000);

            //Click Request to Join button displayed on the screen
            projectsPage.ClickRequestToJoinBtn();
            log.Info("Click Request To Join button doisplayed on screen.");
            Thread.Sleep(3000);

            //Signout of the application
            Thread.Sleep(5000);
            authenticationPage.SignOut();
            log.Info("Click on the Signout button.");

            //Login to the application
            Thread.Sleep(5000);
            authenticationPage.SetUserName(_workEmail);
            authenticationPage.SetPassword(_password);
            authenticationPage.ClickOnLoginButton();

            //Click Projects menu option
            Thread.Sleep(5000);
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
            Thread.Sleep(5000);

            //Click the created project
            projectsPage.ClickProjectNameOnPage(projectName);
            log.Info("Click the Project Name on the Projects Page.");
            Thread.Sleep(5000);

            //Select the Requested Member Icon
            commonPage.ScrollDown();
            Thread.Sleep(2000);
            projectsPage.ClickRequestedMember();
            log.Info("Click the Requested Member of the Project.");
            Thread.Sleep(3000);

            //Click on the Accept icon of the Pending Request window            
            projectsPage.AcceptRequestedMember();
            log.Info("Accept the Requested member.");
            Thread.Sleep(3000);

            //Click on the Close icon of the Pending Request window
            projectsPage.ClosePendingMemberWindow();
            log.Info("Close the Pending member window.");
            Thread.Sleep(3000);

            //Signout of the application
            Thread.Sleep(5000);
            authenticationPage.SignOut();
            log.Info("Click on the Signout button.");

            //Sign in with a different user
            Thread.Sleep(5000);
            SignInDifferentUser();
            log.Info("Sign in with different user.");

            //Select Projects
            //Click Projects menu option
            Thread.Sleep(5000);
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
            Thread.Sleep(5000);

            //Click the created project
            projectsPage.ClickProjectNameOnPage(projectName);
            log.Info("Click the Project Name on the Projects Page.");
            Thread.Sleep(5000);

            //Verify the Leave Project icon displayed on screen or not
            projectsPage.LeaveProjectIcon();
            log.Info("Verify Leave Project icon displayed on screen.");
            Thread.Sleep(1000);

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
            Thread.Sleep(5000);

            //Click the created project
            projectsPage.ClickProjectNameOnPage(projectName);
            log.Info("Click the Project Name on the Projects Page.");
            Thread.Sleep(5000);

            //Delete Project
            DeleteProject();
            Thread.Sleep(2000);
        }

        [Test]
        public void Projects_031_VerifyProjectCreatedMsg()
        {
            Global.MethodName = "Projects_031_VerifyProjectCreatedMsg";

            //Create a new project
            Thread.Sleep(5000);
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(4));
            String projectName = readProjects.GetValue("AddProjectDetails", "projectName");
            projectName = projectName + builder;
            CreateProject(projectName);

            //Verify the successful project creation message
            projectsPage.verifyProjectConfirmationMessage();
            log.Info("Verify the Project Created successful message.");
            Thread.Sleep(2000);

            //Delete Project
            DeleteProject();
            Thread.Sleep(2000);
        }

        [Test]
        public void Projects_032_VerifyProjectCreatedFieldsDisplayed()
        {
            Global.MethodName = "Projects_032_VerifyProjectCreatedFieldsDisplayed";

            //Create a new project
            Thread.Sleep(5000);
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(4));
            String projectName = readProjects.GetValue("AddProjectDetails", "projectName");
            projectName = projectName + builder;
            CreateProject(projectName);

            //Verify the fields displayed on the created project
            //Verify About tab
            projectsPage.VerifyAboutTab();
            log.Info("Verify About tab on the created Project page.");
            Thread.Sleep(2000);

            //Verify Discussion tab
            projectsPage.VerifyDiscussionsTab();
            log.Info("Verify Discussion tab on the created Project page.");
            Thread.Sleep(2000);

            //Verify Tasks tab
            projectsPage.VerifyTasksTab();
            log.Info("Verify Tasks tab on the created Project page.");
            Thread.Sleep(2000);
                       
            //Verify Add member icon
            projectsPage.VerifyAddMemberIcon();
            log.Info("Verify Add member icon on the created Project page.");
            Thread.Sleep(2000);

            //Verify Share project icon
            projectsPage.VerifyShareProjectIcon();
            log.Info("Verify Share project icon on the created Project page.");
            Thread.Sleep(2000);

            //Verify Delete member icon
            projectsPage.VerifyDeleteProjectIcon();
            log.Info("Verify Delete project icon on the created Project page.");
            Thread.Sleep(2000);

            //Verify Start Date field
            projectsPage.VerifyStartDate();
            log.Info("Verify Start Date field on the created Project page.");
            Thread.Sleep(2000);

            //Verify Due Date field
            projectsPage.VerifyDueDate();
            log.Info("Verify Due Date field on the created Project page.");
            Thread.Sleep(2000);

            //Verify Status field
            projectsPage.VerifyStatus();
            log.Info("Verify Status field on the created Project page.");
            Thread.Sleep(2000);

            //Verify Location field
            projectsPage.VerifyLocation();
            log.Info("Verify Location field on the created Project page.");
            Thread.Sleep(2000);

            //Verify Group field
            projectsPage.VerifyGroup();
            log.Info("Verify Group field on the created Project page.");
            Thread.Sleep(2000);

            //Verify Event field
            projectsPage.VerifyEvent();
            log.Info("Verify Event field on the created Project page.");
            Thread.Sleep(2000);

            //Verify Reward field
            projectsPage.VerifyReward();
            log.Info("Verify Reward field on the created Project page.");
            Thread.Sleep(2000);

            //Verify Owner field
            projectsPage.VerifyOwner();
            log.Info("Verify Owner field on the created Project page.");
            Thread.Sleep(2000);                       

            //Verify Mark Complete button
            projectsPage.VerifyMarkCompleteBtn();
            log.Info("Verify Mark Complete on the created Project page.");
            Thread.Sleep(2000);

            //Delete Project
            DeleteProject();
            Thread.Sleep(2000);
        }

        [Test]
        public void Projects_033_VerifyProjectScreenForNonMember()
        {
            Global.MethodName = "Projects_033_VerifyProjectScreenForNonMember";

            //Create a new project
            Thread.Sleep(5000);
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(4));
            String projectName = readProjects.GetValue("AddProjectDetails", "projectName");
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
            Thread.Sleep(5000);

            //Click the created project
            projectsPage.ClickProjectNameOnPage(projectName);
            log.Info("Click the Project Name on the Projects Page.");
            Thread.Sleep(5000);

            //Verify that Request to Join button is displayed on the screen
            projectsPage.AsssertRequestToJoinBtn();
            log.Info("Verify Request To Join button doisplayed on screen.");
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

            //Delete Project
            DeleteProject();
            Thread.Sleep(2000);
        }

        [Test]
        public void Projects_034_VerifyShareLeaveProjectForMember()
        {
            Global.MethodName = "Projects_034_VerifyShareLeaveProjectForMember";

            //Create a new project
            Thread.Sleep(5000);
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(4));
            String projectName = readProjects.GetValue("AddProjectDetails", "projectName");
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
            Thread.Sleep(5000);

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
            Thread.Sleep(5000);

            //Click on the Close icon of the Pending Request window
            projectsPage.ClosePendingMemberWindow();
            log.Info("Close the Pending member window.");

            //Signout of the application
            Thread.Sleep(5000);
            authenticationPage.SignOut();
            log.Info("Click on the Signout button.");

            //Sign in with a different user
            Thread.Sleep(6000);
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

            //Verify the Share Project icon displayed on screen or not
            projectsPage.ShareProjectIcon();
            log.Info("Verify Share Project icon displayed on screen.");
            Thread.Sleep(3000);

            //Verify the Leave Project icon displayed on screen or not
            projectsPage.LeaveProjectIcon();
            log.Info("Verify Leave Project icon displayed on screen.");
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

            //Delete Project
            DeleteProject();
            Thread.Sleep(2000);
        }

        [Test]
        public void Projects_035_ClickAddMemberAndVerify()
        {
            Global.MethodName = "Projects_035_ClickAddMemberAndVerify";

            //Create a new project
            Thread.Sleep(5000);
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(4));
            String projectName = readProjects.GetValue("AddProjectDetails", "projectName");
            projectName = projectName + builder;
            CreateProject(projectName);

            //Click on Add member icon
            Thread.Sleep(3000);
            projectsPage.ClickAddMemberIcon();
            log.Info("Click the Add member icon for the Project.");

            //Verify the data displayed on the screen
            Thread.Sleep(4000);
            projectsPage.VerifyAddProjectMemberWindowFields();
            log.Info("Verify the Add Project Member window fields.");

            //Click the Add Project Member window close icon
            Thread.Sleep(2000);
            projectsPage.ClickAddProjectMemberWindowCloseIcon();
            log.Info("Click the Add Project Member window close icon.");

            //Delete Project
            DeleteProject();
            Thread.Sleep(2000);
        }

        [Test]
        public void Projects_036_AddMemberToProject()
        {
            Global.MethodName = "Projects_036_AddMemberToProject";

            //Create a new project
            Thread.Sleep(5000);
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(4));
            String projectName = readProjects.GetValue("AddProjectDetails", "projectName");
            projectName = projectName + builder;
            CreateProject(projectName);

            //Click on Add member icon
            Thread.Sleep(3000);
            projectsPage.ClickAddMemberIcon();
            log.Info("Click the Add member icon for the Project.");

            //Enter the Project Member Email
            Thread.Sleep(4000);
            String addMemberEmail = readProjects.GetValue("AddProjectMember", "addMemberEmail");
            projectsPage.EnterProjectMemberEmail(addMemberEmail);

            //Select user from suggestion
            Thread.Sleep(2000);
            String addMemberName = readProjects.GetValue("AddProjectMember", "addMemberName");
            projectsPage.SelectUserfromSuggestion(addMemberName);
            log.Info("User selected successfully.");

            //Click the Add Project Member window Done button
            Thread.Sleep(2000);
            projectsPage.ClickAddProjectMemberDoneBtn();
            log.Info("Click the Add Project Member window Done button.");

            //Verify the added member confirmation message
            Thread.Sleep(1000);
            projectsPage.VerifyAddedMemberConfMsg();
            log.Info("Verified Project member added confirmation message.");
            Thread.Sleep(2000);

            //Delete Project
            DeleteProject();
            Thread.Sleep(2000);
        }

        [Test]
        public void Projects_037_AddMultipleMembersToProject()
        {
            Global.MethodName = "Projects_037_AddMultipleMembersToProject";

            //Create a new project
            Thread.Sleep(5000);
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(4));
            String projectName = readProjects.GetValue("AddProjectDetails", "projectName");
            projectName = projectName + builder;
            CreateProject(projectName);

            //Click on Add member icon
            Thread.Sleep(3000);
            projectsPage.ClickAddMemberIcon();
            log.Info("Click the Add member icon for the Project.");

            //Enter the Project Member Email and select users from suggestion
            String addMembersEmail = readProjects.GetValue("AddMultipleProjectMembers", "addMembersEmail");
            List<String> addMembersEmailList = addMembersEmail.Split(',').ToList();
            int noOfMember = addMembersEmailList.Count;
            foreach (String value in addMembersEmailList)
            {
                projectsPage.EnterProjectMemberEmail(value);
                Thread.Sleep(2000);
                groupsPage.PressEnterKey();
                Thread.Sleep(5000);
            }

            //Click the Add Project Member window Done button
            Thread.Sleep(2000);
            projectsPage.ClickAddProjectMemberDoneBtn();
            log.Info("Click the Add Project Member window Done button.");

            //Verify the added member confirmation message
            Thread.Sleep(1000);
            projectsPage.VerifyAddedMemberConfMsg();
            log.Info("Verified Project member added confirmation message.");
            Thread.Sleep(2000);

            //Delete Project
            DeleteProject();
            Thread.Sleep(2000);
        }

        [Test]
        public void Projects_039_ClickRemoveMemberAndVerify()
        {
            Global.MethodName = "Projects_039_ClickRemoveMemberAndVerify";

            //Create a new project
            Thread.Sleep(5000);
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(4));
            String projectName = readProjects.GetValue("AddProjectDetails", "projectName");
            projectName = projectName + builder;
            CreateProject(projectName);

            //Click on Add member icon
            Thread.Sleep(3000);
            projectsPage.ClickAddMemberIcon();
            log.Info("Click the Add member icon for the Project.");

            //Enter the Project Member Email
            Thread.Sleep(4000);
            String addMemberEmail = readProjects.GetValue("AddProjectMember", "addMemberEmail");
            projectsPage.EnterProjectMemberEmail(addMemberEmail);

            //Select user from suggestion
            Thread.Sleep(2000);
            String addMemberName = readProjects.GetValue("AddProjectMember", "addMemberName");
            projectsPage.SelectUserfromSuggestion(addMemberName);
            log.Info("User selected successfully.");

            //Click the Add Project Member window Done button
            Thread.Sleep(2000);
            projectsPage.ClickAddProjectMemberDoneBtn();
            log.Info("Click the Add Project Member window Done button.");

            //Click the added member remove icon
            Thread.Sleep(3000);
            commonPage.ScrollDown();
            Thread.Sleep(1000);
            projectsPage.ClickAddedMemberRemoveIcon();
            log.Info("Click Project member added remove icon.");

            //Verify the Remove Member window
            Thread.Sleep(2000);
            projectsPage.VerifyRemoveMemberWindow();
            log.Info("Verify the Remove Project Member window.");

            //Verify the Remove Member window No Button
            Thread.Sleep(2000);
            projectsPage.VerifyRemoveMemberNoBtn();
            log.Info("Verify the Remove Project Member window No button.");

            //Verify the Remove Member window Yes button
            Thread.Sleep(2000);
            projectsPage.VerifyRemoveMemberYesBtn();
            log.Info("Verify the Remove Project Member window Yes button.");

            //Click the Remove Member window No Button
            Thread.Sleep(2000);
            projectsPage.PressRemoveMemberNoBtn();
            log.Info("Click the Remove Project Member window No button.");
            Thread.Sleep(2000);

            //Delete Project
            DeleteProject();
            Thread.Sleep(2000);
        }

        [Test]
        public void Projects_040_ClickRemoveMemberNoBtn()
        {
            Global.MethodName = "Projects_040_ClickRemoveMemberNoBtn";

            //Create a new project
            Thread.Sleep(5000);
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(4));
            String projectName = readProjects.GetValue("AddProjectDetails", "projectName");
            projectName = projectName + builder;
            CreateProject(projectName);

            //Click on Add member icon
            Thread.Sleep(3000);
            projectsPage.ClickAddMemberIcon();
            log.Info("Click the Add member icon for the Project.");

            //Enter the Project Member Email
            Thread.Sleep(4000);
            String addMemberEmail = readProjects.GetValue("AddProjectMember", "addMemberEmail");
            projectsPage.EnterProjectMemberEmail(addMemberEmail);

            //Select user from suggestion
            Thread.Sleep(2000);
            String addMemberName = readProjects.GetValue("AddProjectMember", "addMemberName");
            projectsPage.SelectUserfromSuggestion(addMemberName);
            log.Info("User selected successfully.");

            //Click the Add Project Member window Done button
            Thread.Sleep(2000);
            projectsPage.ClickAddProjectMemberDoneBtn();
            log.Info("Click the Add Project Member window Done button.");

            //Click the added member remove icon
            Thread.Sleep(3000);
            commonPage.ScrollDown();
            Thread.Sleep(1000);
            projectsPage.ClickAddedMemberRemoveIcon();
            log.Info("Click Project member added remove icon.");

            //Click the Remove Member window No Button
            Thread.Sleep(2000);
            projectsPage.PressRemoveMemberNoBtn();
            log.Info("Click the Remove Project Member window No button.");
            Thread.Sleep(2000);

            //Verify Project Member is not deleted
            projectsPage.VerifyProjectMemberNameNotDeleted(addMemberName);
            log.Info("Verify the Project Member Name");
            Thread.Sleep(2000);

            //Delete Project
            DeleteProject();
            Thread.Sleep(2000);
        }

        [Test]
        public void Projects_041_ClickRemoveMemberYesBtn()
        {
            Global.MethodName = "Projects_041_ClickRemoveMemberYesBtn";

            //Create a new project
            Thread.Sleep(5000);
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(4));
            String projectName = readProjects.GetValue("AddProjectDetails", "projectName");
            projectName = projectName + builder;
            CreateProject(projectName);

            //Click on Add member icon
            Thread.Sleep(3000);
            projectsPage.ClickAddMemberIcon();
            log.Info("Click the Add member icon for the Project.");

            //Enter the Project Member Email
            Thread.Sleep(4000);
            String addMemberEmail = readProjects.GetValue("AddProjectMember", "addMemberEmail");
            projectsPage.EnterProjectMemberEmail(addMemberEmail);

            //Select user from suggestion
            Thread.Sleep(2000);
            String addMemberName = readProjects.GetValue("AddProjectMember", "addMemberName");
            projectsPage.SelectUserfromSuggestion(addMemberName);
            log.Info("User selected successfully.");

            //Click the Add Project Member window Done button
            Thread.Sleep(2000);
            projectsPage.ClickAddProjectMemberDoneBtn();
            log.Info("Click the Add Project Member window Done button.");

            //Click the added member remove icon
            Thread.Sleep(3000);
            commonPage.ScrollDown();
            Thread.Sleep(1000);
            projectsPage.ClickAddedMemberRemoveIcon();
            log.Info("Click Project member added remove icon.");

            //Click the Remove Member window Yes Button
            Thread.Sleep(2000);
            projectsPage.PressRemoveMemberYesBtn();
            log.Info("Click the Remove Project Member window No button.");
            Thread.Sleep(2000);

            //Verify Project member is deleted
            projectsPage.VerifyProjectMemberNameIsDeleted(addMemberName);
            log.Info("Verified Project member is deleted.");
            Thread.Sleep(2000);

            //Delete Project
            DeleteProject();
            Thread.Sleep(2000);
        }

        [Test]
        public void Projects_042_EditProject()
        {
            Global.MethodName = "Projects_042_EditProject";

            //Create a new project
            Thread.Sleep(5000);
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(4));
            String projectName = readProjects.GetValue("AddProjectDetails", "projectName");
            projectName = projectName + builder;
            CreateProject(projectName);

            //Edit the Project Name
            Thread.Sleep(2000);
            String editProjectName = readProjects.GetValue("EditProject", "editProjectName");
            projectsPage.EditProjectName(editProjectName);
            log.Info("Edit the Project Name.");

            //Click the Start Date Field
            projectsPage.ClickStartDateField();
            log.Info("Click Start Date Field.");
            Thread.Sleep(2000);

            //Select today's date
            projectsPage.ClickTodaysDate();
            log.Info("Select today's date.");
            Thread.Sleep(2000);

            //Edit the Project Name
            Thread.Sleep(2000);
            String editDueDate = readProjects.GetValue("EditProject", "editDueDate");
            projectsPage.EditDueDate(editDueDate);
            log.Info("Edit the Due Date.");

            //Edit the Project Owner
            Thread.Sleep(2000);
            String editProjectOwner = readProjects.GetValue("EditProject", "editProjectOwner");
            projectsPage.SelectOptionFromProjectOwner(editProjectOwner);
            log.Info("Edit the Project Owner.");

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
            projectsPage.ClickProjectNameOnPage(editProjectName);
            log.Info("Click the Project Name on the Projects Page.");
            Thread.Sleep(3000);

            //Delete Project
            DeleteProject();
            Thread.Sleep(2000);
        }

        [Test]
        public void Projects_043_ClickDeleteProjectAndVerify()
        {
            Global.MethodName = "Projects_043_ClickDeleteProjectAndVerify";

            //Create a new project
            Thread.Sleep(5000);
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(4));
            String projectName = readProjects.GetValue("AddProjectDetails", "projectName");
            projectName = projectName + builder;
            CreateProject(projectName);

            //Click the Delete icon
            commonPage.ScrollUp();
            Thread.Sleep(3000);
            projectsPage.ClickDeleteProjectIcon();
            Thread.Sleep(2000);

            //Verify Delete Project Window
            projectsPage.VerifyDeleteProjectWindow();
            log.Info("Verify the Delete Project Member Window.");
            Thread.Sleep(2000);

            //Verify Delete Project Window No Button 
            projectsPage.VerifyDeleteProjectWindowNoBtn();
            log.Info("Verify the Delete Project Member Window No Button.");
            Thread.Sleep(2000);

            //Verify Delete Project Window Yes Button 
            projectsPage.VerifyDeleteProjectWindowYesBtn();
            log.Info("Verify the Delete Project Member Window Yes button.");
            Thread.Sleep(2000);

            //Click the Delete Project Window No Icon
            projectsPage.PressDeleteProjectWindowNoBtn();
            log.Info("Close the Delete Group Member Window.");
            Thread.Sleep(3000);

            //Delete Project
            DeleteProject();
            Thread.Sleep(2000);
        }

        [Test]
        public void Projects_044_ClickDeleteProjectNoBtn()
        {
            Global.MethodName = "Projects_044_ClickDeleteProjectNoBtn";

            //Create a new project
            Thread.Sleep(5000);
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(4));
            String projectName = readProjects.GetValue("AddProjectDetails", "projectName");
            projectName = projectName + builder;
            CreateProject(projectName);

            //Click the Delete icon
            commonPage.ScrollUp();
            Thread.Sleep(3000);
            projectsPage.ClickDeleteProjectIcon();
            Thread.Sleep(2000);

            //Click the Delete Project Window No button
            projectsPage.PressDeleteProjectWindowNoBtn();
            log.Info("Click the Delete Group Member Window No button.");
            Thread.Sleep(3000);

            //***Verify the Project is still displayed***
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
            Thread.Sleep(2000);

            //Verify created project should be displayed on the Projects page
            projectsPage.VerifyProjectNameOnPage(projectName);
            log.Info("Verify the Project Name on the Projects Page is still displayed.");
            Thread.Sleep(2000);

            //Click the created project
            projectsPage.ClickProjectNameOnPage(projectName);
            log.Info("Click the Project Name on the Projects Page.");
            Thread.Sleep(3000);

            //Delete Project
            DeleteProject();
            Thread.Sleep(2000);
        }

        [Test]
        public void Projects_045_ClickDeleteProjectYesBtn()
        {
            Global.MethodName = "Projects_045_ClickDeleteProjectYesBtn";

            //Create a new project
            Thread.Sleep(5000);
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(4));
            String projectName = readProjects.GetValue("AddProjectDetails", "projectName");
            projectName = projectName + builder;
            CreateProject(projectName);

            //Click the Delete icon
            commonPage.ScrollUp();
            Thread.Sleep(3000);
            projectsPage.ClickDeleteProjectIcon();
            Thread.Sleep(2000);

            //Click the Delete Project Window Yes button
            projectsPage.PressDeleteProjectWindowYesBtn();
            log.Info("Click the Delete Group Member Window Yes button.");
            Thread.Sleep(3000);

            //***Verify the Project is not displayed***
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
            Thread.Sleep(2000);

            //Verify created project should be displayed on the Projects page
            projectsPage.VerifyProjectNameOnPageNotDisplayed(projectName);
            log.Info("Verify the Project Name on the Projects Page is not displayed.");
            Thread.Sleep(2000);
        }


        [Test]
        public void Projects_046_CreateProjectWithoutAnyField()
        {
            Global.MethodName = "Projects_046_CreateProjectWithoutAnyField";

            //Click Projects menu option
            projectsPage.ClickProjectsMenu();
            Thread.Sleep(5000);

            //Click on Add Project button
            projectsPage.ClickOnAddProjectButton();
            log.Info("Click on the Add Project button at Projects page");
            Thread.Sleep(2000);

            //Click on the create button at Add Project form
            projectsPage.ClickOnCreateProjectBtn();
            Thread.Sleep(2000);

            //Verify the Name required error message
            projectsPage.VerifyNameRequiredMsg();
            log.Info("Verify the Name required error message");
            Thread.Sleep(2000);

            //Verify the Desc required error message
            projectsPage.VerifyDescRequiredMsg();
            log.Info("Verify the Desc required error message");
            Thread.Sleep(2000);

            //Click Close Icon
            projectsPage.ClickAddProjectWindowCloseIcon();
            log.Info("Click on Cancel button.");
            Thread.Sleep(2000);
        }

        [Test]
        public void Projects_047_CreateProjectWithoutName()
        {
            Global.MethodName = "Projects_047_CreateProjectWithoutName";

            //Click Projects menu option
            projectsPage.ClickProjectsMenu();
            Thread.Sleep(5000);

            //Click on Add Project button
            projectsPage.ClickOnAddProjectButton();
            log.Info("Click on the Add Project button at Projects page");
            Thread.Sleep(2000);

            //Enter the Project Description
            String projectDesc = readProjects.GetValue("AddProjectDetails", "projectDesc");
            projectsPage.EnterProjectDescription(projectDesc);
            Thread.Sleep(2000);

            //Click on the create button at Add Project form
            projectsPage.ClickOnCreateProjectBtn();
            Thread.Sleep(2000);

            //Verify the Name required error message
            projectsPage.VerifyNameEmptyMsg();
            log.Info("Verify the Name required error message");
            Thread.Sleep(2000);

            //Click Close Icon
            projectsPage.ClickAddProjectWindowCloseIcon();
            log.Info("Click on Cancel button.");
            Thread.Sleep(2000);
        }

        [Test]
        public void Projects_048_CreateProjectWithoutDesc()
        {
            Global.MethodName = "Projects_048_CreateProjectWithoutDesc";

            //Click Projects menu option
            projectsPage.ClickProjectsMenu();
            Thread.Sleep(5000);

            //Click on Add Project button
            projectsPage.ClickOnAddProjectButton();
            log.Info("Click on the Add Project button at Projects page");
            Thread.Sleep(2000);

            //Enter the Project Name
            projectsPage.EnterProjectName("ProjectName");
            Thread.Sleep(2000);

            //Click on the create button at Add Project form
            projectsPage.ClickOnCreateProjectBtn();
            Thread.Sleep(2000);

            //Verify the Desc required error message
            projectsPage.VerifyDescEmptyMsg();
            log.Info("Verify the Desc required error message");
            Thread.Sleep(2000);

            //Click Close Icon

            projectsPage.ClickAddProjectWindowCloseIcon();
            log.Info("Click on Cancel button.");
            Thread.Sleep(2000);
        }

        [Test]
        public void Projects_052_LeaveProject()
        {
            Global.MethodName = "Projects_052_LeaveProject";

            //Create a new project
            Thread.Sleep(5000);
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(4));
            String projectName = readProjects.GetValue("AddProjectDetails", "projectName");
            projectName = projectName + builder;
            CreateProject(projectName);

            //Click on Add member icon
            Thread.Sleep(3000);
            projectsPage.ClickAddMemberIcon();
            log.Info("Click the Add member icon for the Project.");

            //Enter the Project Member Email
            Thread.Sleep(3000);
            String addMemberEmail = readProjects.GetValue("AddProjectMember", "addMemberEmail");
            projectsPage.EnterProjectMemberEmail(addMemberEmail);

            //Select user from suggestion
            Thread.Sleep(2000);
            String addMemberName = readProjects.GetValue("AddProjectMember", "addMemberName");
            projectsPage.SelectUserfromSuggestion(addMemberName);
            log.Info("User selected successfully.");

            //Click the Add Project Member window Done button
            Thread.Sleep(2000);
            projectsPage.ClickAddProjectMemberDoneBtn();
            log.Info("Click the Add Project Member window Done button.");

            //Signout of the application
            Thread.Sleep(5000);
            authenticationPage.SignOut();
            log.Info("Click on the Signout button.");

            //Sign in with a different user
            Thread.Sleep(5000);
            SignInDifferentUser();
            log.Info("Sign in with different user.");

            //Select Projects
            //Click Projects menu option
            Thread.Sleep(5000);
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
            Thread.Sleep(5000);

            //Click the Leave Project icon displayed on screen 
            projectsPage.ClickLeaveProjectIcon();
            log.Info("Click Leave Project icon displayed on screen.");
            Thread.Sleep(2000);

            //Click Leave Project window Yes button
            projectsPage.ClickLeaveProjectWindowYesBtn();
            log.Info("Click Leave Project window Yes button.");
            Thread.Sleep(2000);

            //Signout of the application
            Thread.Sleep(2000);
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
            Thread.Sleep(5000);

            //Delete Project
            DeleteProject();
            Thread.Sleep(2000);
        }

        [Test]
        public void Projects_053_ClickDiscussionAndVerify()
        {
            Global.MethodName = "Projects_053_ClickDiscussionAndVerify";

            //Create a new project
            Thread.Sleep(5000);
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(4));
            String projectName = readProjects.GetValue("AddProjectDetails", "projectName");
            projectName = projectName + builder;
            CreateProject(projectName);

            //Click on Discussions tab
            projectsPage.ClickProjectDiscussionTab();
            log.Info("Click on Project's Discussion tab.");
            Thread.Sleep(5000);

            //Verify the Discussion message div
            projectsPage.VerifyDiscussionsMsgDiv();
            log.Info("Verify the Discussion message div.");
            Thread.Sleep(5000);

            //Verify Discussion tab Add member icon
            projectsPage.VerifyDiscussionAddMemberIcon();
            log.Info("Verify the Discussion tab Add member icon.");
            Thread.Sleep(2000);

            ////Verify Discussion tab Share Project icon
            projectsPage.VerifyDiscussionShareProjectIcon();
            log.Info("Verify the Discussion Share Project icon.");
            Thread.Sleep(2000);

            //Verify Discussion tab Delete Project icon
            projectsPage.VerifyDiscussionDeleteProjectIcon();
            log.Info("Verify the Discussion tab Delete Project icon.");
            Thread.Sleep(2000);

            //Delete Project
            //Click Delete Project Icon
            commonPage.ScrollUp();
            Thread.Sleep(3000);
            projectsPage.ClickDiscussionDeleteProjectIcon();
            Thread.Sleep(2000);

            //Click the Delete Project Window Yes Button
            projectsPage.PressDeleteProjectWindowYesBtn();
            Thread.Sleep(2000);
        }

        [Test]
        public void Projects_054_PostDiscussionMsgAndVerify()
        {
            Global.MethodName = "Projects_054_PostDiscussionMsgAndVerify";

            //Create a new project
            Thread.Sleep(5000);
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(4));
            String projectName = readProjects.GetValue("AddProjectDetails", "projectName");
            projectName = projectName + builder;
            CreateProject(projectName);

            //Click on Discussions tab
            projectsPage.ClickProjectDiscussionTab();
            log.Info("Click on Project's Discussion tab.");
            Thread.Sleep(3000);

            eventsPage.PressTabKey();
            Thread.Sleep(1000);
            eventsPage.PressTabKey();
            Thread.Sleep(1000);
            eventsPage.PressTabKey();
            Thread.Sleep(1000);
            eventsPage.PressTabKey();
            Thread.Sleep(1000);
            eventsPage.PressTabKey();
            Thread.Sleep(1000);
            eventsPage.PressTabKey();
            Thread.Sleep(3000);

            //Enter the Message in Text Area
            String typeMessage = readProjects.GetValue("Discussion", "typeMessage");
            projectsPage.EnterMessageTextArea(typeMessage);
            log.Info("Enter message in Discussion.");
            Thread.Sleep(2000);

            //Click the Post button for the message
            projectsPage.ClickMessagePostBtn();
            log.Info("Click the Post button for the message.");
            Thread.Sleep(2000);

            //Verify the Discussion Message Reply button
            groupsPage.VerifyDiscussionMsgReplyBtn();
            log.Info("Verify the Discussion Message Reply button.");
            Thread.Sleep(3000);

            //Delete Project
            //Click Delete Project Icon
            commonPage.ScrollUp();
            Thread.Sleep(3000);
            projectsPage.ClickDiscussionDeleteProjectIcon();
            Thread.Sleep(2000);

            //Click the Delete Project Window Yes Button
            projectsPage.PressDeleteProjectWindowYesBtn();
            Thread.Sleep(2000);
        }

        [Test]
        public void Projects_055_UploadDiscussionFileAndVerify()
        {
            Global.MethodName = "Projects_055_UploadDiscussionFileAndVerify";

            //Create a new project
            Thread.Sleep(5000);
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(4));
            String projectName = readProjects.GetValue("AddProjectDetails", "projectName");
            projectName = projectName + builder;
            CreateProject(projectName);

            //Click on Discussions tab
            projectsPage.ClickProjectDiscussionTab();
            log.Info("Click on Project's Discussion tab.");
            Thread.Sleep(3000);

            //Click Discussion Attachment Icon
            projectsPage.ClickDiscussionAttachIcon();
            log.Info("Click message in Discussion.");
            Thread.Sleep(2000);
            String startupPath = Environment.CurrentDirectory; ;
            startupPath = startupPath + "\\no-testing-required-it-will-work.jpg";
            Console.WriteLine("Start up path: " + startupPath);
            SendKeys.SendWait(@startupPath);
            Thread.Sleep(2000);
            SendKeys.SendWait(@"{Enter}");
            Thread.Sleep(5000);

            //Delete the group
            //Click Delete Project Icon
            commonPage.ScrollUp();
            Thread.Sleep(3000);
            projectsPage.ClickDiscussionDeleteProjectIcon();
            Thread.Sleep(2000);

            //Click the Delete Project Window Yes Button
            projectsPage.PressDeleteProjectWindowYesBtn();
            Thread.Sleep(2000);
        }

        [Test]
        public void Projects_057_PostDiscussionMsgToAll()
        {
            Global.MethodName = "Projects_057_PostDiscussionMsgToAll";

            //Create a new project
            Thread.Sleep(5000);
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(4));
            String projectName = readProjects.GetValue("AddProjectDetails", "projectName");
            projectName = projectName + builder;
            CreateProject(projectName);

            //Click on Discussions tab
            projectsPage.ClickProjectDiscussionTab();
            log.Info("Click on Project's Discussion tab.");
            Thread.Sleep(4000);

            //Click Discussion Message Div
            projectsPage.ClickMessageTextArea();
            log.Info("Click message in Discussion.");
            Thread.Sleep(2000);

            //Enter the Message in Text Area
            String typeMessage = "@all";
            projectsPage.EnterMessageTextArea(typeMessage);
            log.Info("Enter message in Discussion.");
            Thread.Sleep(2000);

            //Press Enter Key
            commonPage.PressEnterKey();
            Thread.Sleep(2000);

            //Click the Post button for the message
            projectsPage.ClickMessagePostBtn();
            log.Info("Click the Post button for the message.");
            Thread.Sleep(2000);

            //Delete the Project
            //Click Delete Project Icon
            commonPage.ScrollUp();
            Thread.Sleep(3000);
            projectsPage.ClickDiscussionDeleteProjectIcon();
            Thread.Sleep(2000);

            //Click the Delete Project Window Yes Button
            projectsPage.PressDeleteProjectWindowYesBtn();
            Thread.Sleep(2000);
        }

        [Test]
        public void Projects_058_PostDiscussionMsgToSingleUser()
        {
            Global.MethodName = "Projects_058_PostDiscussionMsgToSingleUser";

            //Create a new project
            Thread.Sleep(5000);
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(4));
            String projectName = readProjects.GetValue("AddProjectDetails", "projectName");
            projectName = projectName + builder;
            CreateProject(projectName);

            //Click on Discussions tab
            projectsPage.ClickProjectDiscussionTab();
            log.Info("Click on Project's Discussion tab.");
            Thread.Sleep(4000);

            //Click Discussion Message Div
            projectsPage.ClickMessageTextArea();
            log.Info("Click message in Discussion.");
            Thread.Sleep(2000);

            //Enter the Message in Text Area
            String singleusername = readProjects.GetValue("PostDiscussionMsgToSingleUser", "singleusername");
            projectsPage.EnterMessageTextArea(singleusername);
            log.Info("Enter message in Discussion.");
            Thread.Sleep(2000);

            //Press Enter Key
            commonPage.PressEnterKey();
            Thread.Sleep(2000);

            //Click the Post button for the message
            projectsPage.ClickMessagePostBtn();
            log.Info("Click the Post button for the message.");
            Thread.Sleep(2000);

            //Delete the Project
            //Click Delete Project Icon
            commonPage.ScrollUp();
            Thread.Sleep(3000);
            projectsPage.ClickDiscussionDeleteProjectIcon();
            Thread.Sleep(2000);

            //Click the Delete Project Window Yes Button
            projectsPage.PressDeleteProjectWindowYesBtn();
            Thread.Sleep(2000);
        }


        [Test]
        public void Projects_060_CreateProjectFromPlusIcon()
        {
            Global.MethodName = "Projects_060_CreateProjectFromPlusIcon";

            //Click on the Plus icon at the top
            Thread.Sleep(2000);
            dashboardPage.ClickPlusIconOnTop();
            log.Info("Click on the Plus icon at the top.");

            //Select Project from the options displayed
            Thread.Sleep(1000);
            dashboardPage.SelectOptionFromPlusIcon("Project");

            //Enter the Project Name
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(4));
            String projectName = readProjects.GetValue("AddProjectDetails", "projectName");
            projectName = projectName + builder;
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

            //Delete Project
            DeleteProject();
            Thread.Sleep(2000);
        }

        [Test]
        public void Projects_080_ViewProjectsTeamStatus()
        {
            Global.MethodName = "Projects_080_ViewProjectsTeamStatus";

            //Create a new project
            Thread.Sleep(5000);
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(4));
            String projectName = readProjects.GetValue("AddProjectDetails", "projectName");
            projectName = projectName + builder;
            CreateProject(projectName);

            //Click on Add member icon
            Thread.Sleep(3000);
            projectsPage.ClickAddMemberIcon();
            log.Info("Click the Add member icon for the Project.");

            //Enter the Project Member Email and select users from suggestion
            String addMembersEmail = readProjects.GetValue("AddMultipleProjectMembers", "addMembersEmail");
            List<String> addMembersEmailList = addMembersEmail.Split(',').ToList();
            String addMembersName = readProjects.GetValue("AddMultipleProjectMembers", "addMembersName");
            List<String> addMembersNameList = addMembersName.Split(',').ToList();
            int noOfMember = addMembersEmailList.Count;
            foreach (String value in addMembersEmailList)
            {
                projectsPage.EnterProjectMemberEmail(value);
                Thread.Sleep(2000);
                groupsPage.PressEnterKey();
                Thread.Sleep(5000);
            }

            //Click the Add Project Member window Done button
            Thread.Sleep(5000);
            projectsPage.ClickAddProjectMemberDoneBtn();
            log.Info("Click the Add Project Member window Done button.");

            //Again click on Add member icon
            Thread.Sleep(5000);
            projectsPage.ClickAddMemberIcon();
            log.Info("Click the Add member icon for the Project.");

            //Click on View Team Status link
            Thread.Sleep(5000);
            projectsPage.ClickViewTeamStatus();
            log.Info("Click on the Biew Team Status hyperlink.");

            //Verify the users displayed in the Project Team
            foreach (String value in addMembersNameList)
            {
                Console.WriteLine("Member Name: " + value);
                projectsPage.VerifyTeamMember(value);
                Thread.Sleep(2000);
            }

            //Click the Team Status window Close icon
            projectsPage.ClickTeamStatusCloseIcon();
            log.Info("Click on Team Status window Close icon.");

            //Click the Add Project Member window Done button
            Thread.Sleep(2000);
            projectsPage.ClickAddProjectMemberDoneBtn();
            log.Info("Click the Add Project Member window Done button.");

            //Delete Project
            DeleteProject();
            Thread.Sleep(2000);
        }

        [Test]
        public void Projects_081_VerifyProjectsTeamStatusDisplay()
        {
            Global.MethodName = "Projects_081_VerifyProjectsTeamStatusDisplay";

            //Create a new project
            Thread.Sleep(5000);
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(4));
            String projectName = readProjects.GetValue("AddProjectDetails", "projectName");
            projectName = projectName + builder;
            CreateProject(projectName);

            //Click on Add member icon
            Thread.Sleep(3000);
            projectsPage.ClickAddMemberIcon();
            log.Info("Click the Add member icon for the Project.");

            //Enter the Group Member Email and select users from suggestion
            String addMembersEmail = readProjects.GetValue("AddMultipleProjectMembers", "addMembersEmail");
            List<String> addMembersEmailList = addMembersEmail.Split(',').ToList();
            int noOfMember = addMembersEmailList.Count;
            Console.WriteLine("No of members: " + noOfMember);
            foreach (String value in addMembersEmailList)
            {
                projectsPage.EnterProjectMemberEmail(value);
                Console.WriteLine("Entered Project member: " + value);
                Thread.Sleep(2000);
                groupsPage.PressEnterKey();
                Thread.Sleep(5000);
            }

            //Click the Add Project Member window Done button
            Thread.Sleep(3000);
            projectsPage.ClickAddProjectMemberDoneBtn();
            log.Info("Click the Add Project Member window Done button.");

            //Again click on Add member icon
            Thread.Sleep(7000);
            projectsPage.ClickAddMemberIcon();
            log.Info("Click the Add member icon for the Project.");

            //Click on View Team Status link
            Thread.Sleep(5000);
            projectsPage.ClickViewTeamStatus();
            log.Info("Click on the View Team Status hyperlink.");

            //Assert Team member Type
            Thread.Sleep(2000);
            projectsPage.VerifyTeamMemberType();
            log.Info("Verify the Team Member Type.");

            //Assert Team member Project Role
            Thread.Sleep(2000);
            projectsPage.VerifyTeamMemberProjectRole();
            log.Info("Verify the Team Member Project Role.");

            //Assert Team member Status
            Thread.Sleep(2000);
            projectsPage.VerifyTeamMemberStatus();
            log.Info("Verify the Team Member Status.");

            //Click the Team Status window Close icon
            projectsPage.ClickTeamStatusCloseIcon();
            log.Info("Click on Team Status window Close icon.");

            //Click the Add Project Member window Done button
            Thread.Sleep(2000);
            projectsPage.ClickAddProjectMemberDoneBtn();
            log.Info("Click the Add Project Member window Done button.");

            //Delete Project
            DeleteProject();
            Thread.Sleep(2000);
        }

        [Test]
        public void Projects_083_VerifyClosedIvePostedProjects()
        {
            Global.MethodName = "Projects_083_VerifyClosedIvePostedProjects";

            //Create a new project
            Thread.Sleep(5000);
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(4));
            String projectName = readProjects.GetValue("AddProjectDetails", "projectName");
            projectName = projectName + builder;
            CreateProject(projectName);

            //Select Projects
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

            //Select Project status as Closed
            projectsPage.SelectStatusDropDown("Closed");
            log.Info("Select Project status as 'Closed'");
            Thread.Sleep(3000);

            //Click Projects menu option
            projectsPage.ClickProjectsMenu();
            log.Info("Click the Projects menu option.");
            Thread.Sleep(5000);

            //Click the All Projects Dropdown option
            projectsPage.ClickAllProjectsDropDown();
            log.Info("Click the All Projects dropdown.");
            Thread.Sleep(2000);

            //Select Closed option from All Projects Dropdown
            projectsPage.SelectAllProjectsClosed();
            log.Info("Select 'Closed' option from the All Projects dropdown.");
            Thread.Sleep(5000);

            //Verify created project should be displayed on the Projects page
            projectsPage.VerifyProjectNameOnPage(projectName);
            log.Info("Verify the Project Name on the Projects Page.");
            Thread.Sleep(2000);

            //Click the created project
            projectsPage.ClickProjectNameOnPage(projectName);
            log.Info("Click the Project Name on the Projects Page.");
            Thread.Sleep(3000);

            //Delete Project
            DeleteProject();
            Thread.Sleep(2000);
        }
    }
}