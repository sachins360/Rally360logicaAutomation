﻿using log4net;
using NUnit.Framework;
using RallyTeam.UILocators;
using RallyTeam.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RallyTeam.TestScripts
{
    [TestFixture]
    [Category("Notifications")]
    public class NotificationsTest : BaseTestES
    {
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        static ReadData readNotifications = new ReadData("Notifications");
        static ReadData readPostProject = new ReadData("PostProject");

        //SignIn
        private void SignInDifferentUser(string userName, string password)
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

            //Click Continue Button
            postProjectPage.ClickContinueBtn();
            log.Info("Click on the Continue button.");
            Thread.Sleep(5000);

            //Enter Skills
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

        //Create New Invoice
        public void CreateInvoice(String invoiceTitle, String projectName)
        {
            //Click New Invoice button
            Thread.Sleep(5000);
            invoicingPage.ClickNewInvoiceBtn();
            log.Info("Click the New Invoice button.");

            //Create New Invoice
            Thread.Sleep(5000);
            invoicingPage.EnterInvoiceTitle(invoiceTitle);
            log.Info("Enter the Invoice Title.");
            Thread.Sleep(1000);

            //Click the Due Date Field
            invoicingPage.ClickDueDateField();
            log.Info("Click Due Date Field.");
            Thread.Sleep(1000);

            //Select today's date
            invoicingPage.ClickTodaysDate();
            log.Info("Select today's date.");
            Thread.Sleep(2000);

            //Enter Invoice Total Amount
            String invoiceTotal = readNotifications.GetValue("InvoiceDetails", "invoiceTotal");
            invoicingPage.EnterInvoiceTotal(invoiceTotal);
            log.Info("Enter the Invoice Total Amount");
            Thread.Sleep(1000);

            //Select Project
            invoicingPage.SelectProject(projectName);
            log.Info("Select Project.");
            Thread.Sleep(2000);

            //Enter Invoice Notes
            invoicingPage.EnterNotes("Invoice Notes");
            log.Info("Enter Invoice Notes");
            Thread.Sleep(2000);
        }

        [Test]
        public void Notifications_001_ProjectAssignment()
        {
            Global.MethodName = "Notifications_001_ProjectAssignment";

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

            //Change Project Owner
            String addMembersName = readPostProject.GetValue("AddProjectDetails", "memberName");
            List<String> addMembersNameList = addMembersName.Split(',').ToList();
            postProjectPage.SelectProjectOwner(addMembersNameList[0]);
            String addMembersEmail = readPostProject.GetValue("AddProjectDetails", "memberEmail");
            List<String> addMembersEmailList = addMembersEmail.Split(',').ToList();
            log.Info("Change Project Owner.");
            Thread.Sleep(3000);

            //Click Save Button
            postProjectPage.ClickSaveBtn();
            log.Info("Click on the Save button.");
            Thread.Sleep(5000);
                        
            //Signout of the application
            authenticationPage.SignOut();
            log.Info("Click on the Signout button.");
            Thread.Sleep(5000);

            String password = readNotifications.GetValue("SignInDifferentUser", "password");
            SignInDifferentUser(addMembersEmailList[0], password);
            Thread.Sleep(7000);

            //Click Notifications Icon
            notificationsPage.ClickNotificationsIcon();
            log.Info("Click on the Notifications Icon at top.");
            Thread.Sleep(5000);

            //Verify the short notification on the Notification Window
            notificationsPage.VerifyProjectAssignedNotificationWindow();
            log.Info("Verify the short notification on the Notification Window.");
            Thread.Sleep(1000);

            //Click See All link
            notificationsPage.ClickSeeAll();
            log.Info("Click See All link.");
            Thread.Sleep(7000);

            //Verify the Project Assigned Notification
            notificationsPage.VerifyProjectAssigned();
            log.Info("Verify the Project Assigned Notification.");
            Thread.Sleep(2000);

            //Verify the Project Assigned notification on the Notifications Page
            String loggedInUserName = readNotifications.GetValue("LoggedInUserName", "username");
            notificationsPage.VerifyProjectAssignedSubject(loggedInUserName, projectName);
            log.Info("Verify Project Assigned notification on the Notifications Page.");
            Thread.Sleep(2000);

            //Click the Marketplace tab
            marketplacePage.ClickMarketplaceTab();
            log.Info("Click the Marketplace tab.");
            Thread.Sleep(5000);            

            //Enter the Project Name
            Thread.Sleep(2000);
            postProjectPage.SearchProjectName(projectName);
            log.Info("Enter the project name.");
            Thread.Sleep(2000);

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
        public void Notifications_002_ProjectOwnerPendingJoinRequest()
        {
            Global.MethodName = "Notifications_002_ProjectOwnerPendingJoinRequest";

            //Post a new project
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(6));
            String projectName = readPostProject.GetValue("AddProjectDetails", "projectName");
            projectName = projectName + builder;
            PostNewProject(projectName);                          

            //Signout of the application
            authenticationPage.SignOut();
            log.Info("Click on the Signout button.");
            Thread.Sleep(5000);

            //Sign in with different user
            String username = readNotifications.GetValue("AddProjectDetails", "joinRequestUsername");
            String password = readNotifications.GetValue("AddProjectDetails", "joinRequestPwd");
            SignInDifferentUser(username, password);
            Thread.Sleep(7000);

            //Enter the Project Name
            Thread.Sleep(2000);
            postProjectPage.SearchProjectName(projectName);
            log.Info("Enter the project name.");
            Thread.Sleep(2000);

            //Click Search button
            postProjectPage.ClickSearchBtn();
            log.Info("Click the prSearch button.");
            Thread.Sleep(15000);

            //Click the created project
            postProjectPage.ClickProjectNameOnPage(projectName);
            log.Info("Click the Project Name on the Projects Page.");
            Thread.Sleep(5000);

            //Click Request to Join button displayed on the screen
            postProjectPage.ClickRequestToJoinBtn();
            log.Info("Click Request To Join button displayed on screen.");
            Thread.Sleep(5000);

            //Signout of the application
            Thread.Sleep(5000);
            authenticationPage.SignOut();
            log.Info("Click on the Signout button.");

            //Login to the application
            Thread.Sleep(5000);
            authenticationPage.SetUserName(_workEmail);
            authenticationPage.SetPassword(_password);
            authenticationPage.ClickOnLoginButton();

            //Click Notifications Icon
            Thread.Sleep(7000);            
            notificationsPage.ClickNotificationsIcon();
            log.Info("Click on the Notifications Icon at top.");
            Thread.Sleep(5000);

            //Verify the Project Join Request short notification on the Notification Window
            notificationsPage.VerifyProjectJoinRequestNotificationWindow();
            log.Info("Verify the Project Join Request short notification on the Notification Window.");
            Thread.Sleep(1000);

            //Click See All link
            notificationsPage.ClickSeeAll();
            log.Info("Click See All link.");
            Thread.Sleep(7000);

            //Verify the Project Join Request Notification on Notifications Page
            notificationsPage.VerifyProjectJoinRequest();
            log.Info("Verify the Project Join Request  Notification.");
            Thread.Sleep(1000);

            //Verify the Project Join Request notification subject on the Notifications Page
            String name = readNotifications.GetValue("AddProjectDetails", "joinRequestName");
            notificationsPage.VerifyProjectJoinRequestSubject(name, projectName);
            log.Info("Verify Project Join Request notification subject on the Notifications Page.");
            Thread.Sleep(2000);

            //Click the Marketplace tab
            marketplacePage.ClickMarketplaceTab();
            log.Info("Click the Marketplace tab.");
            Thread.Sleep(5000);

            //Enter the Project Name
            Thread.Sleep(2000);
            postProjectPage.SearchProjectName(projectName);
            log.Info("Enter the project name.");
            Thread.Sleep(2000);

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
        public void Notifications_003_UserRecruitedToProject()
        {
            Global.MethodName = "Notifications_003_UserRecruitedToProject";

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

            //Signout of the application
            authenticationPage.SignOut();
            log.Info("Click on the Signout button.");
            Thread.Sleep(5000);

            //Sign in with different user
            String username = readNotifications.GetValue("SignInDifferentUser", "username");
            String password = readNotifications.GetValue("SignInDifferentUser", "password");
            SignInDifferentUser(username, password);
            Thread.Sleep(7000);
            
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

            //Verify the User Recruited to Project notification subject on the Notifications Page
            String loggedInUserName = readNotifications.GetValue("LoggedInUserName", "username");
            //notificationsPage.VerifyUserRecruitedToProjectSubject(loggedInUserName, projectName);
            log.Info("Verify User Recruited to Project notification subject on the Notifications Page.");
            Thread.Sleep(2000);

            //Signout of the application
            authenticationPage.SignOut();
            log.Info("Click on the Signout button.");
            Thread.Sleep(5000);

            //Login to the application
            Thread.Sleep(5000);
            authenticationPage.SetUserName(_workEmail);
            authenticationPage.SetPassword(_password);
            authenticationPage.ClickOnLoginButton();
            
            //Enter the Project Name
            Thread.Sleep(5000);
            postProjectPage.SearchProjectName(projectName);
            log.Info("Enter the project name.");
            Thread.Sleep(2000);

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
        public void Notifications_004_UserAddedToProject()
        {
            Global.MethodName = "Notifications_004_UserAddedToProject";

            //Post a new project
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(6));
            String projectName = readNotifications.GetValue("AddProjectDetails", "projectName");
            projectName = projectName + builder;
            PostNewProject(projectName);

            //Signout of the application
            authenticationPage.SignOut();
            log.Info("Click on the Signout button.");
            Thread.Sleep(5000);

            //Sign in with different user
            String userName = readNotifications.GetValue("AddProjectMember", "addMemberEmail");
            String password = readNotifications.GetValue("AddProjectMember", "password");
            SignInDifferentUser(userName, password);
            Thread.Sleep(7000);

            //Click Notifications Icon
            notificationsPage.ClickNotificationsIcon();
            log.Info("Click on the Notifications Icon at top.");
            Thread.Sleep(5000);

            //Verify the User Added to Project short notification on the Notification Window
            notificationsPage.VerifyUserAddedToProjectNotificationWindow();
            log.Info("Verify the User Added to Project short notification on the Notification Window.");
            Thread.Sleep(1000);

            //Click See All link
            notificationsPage.ClickSeeAll();
            log.Info("Click See All link.");
            Thread.Sleep(7000);

            //Verify the User Added to Project Notification on Notifications Page
            notificationsPage.VerifyUserAddedToProject();
            log.Info("Verify the User Added to Project Notification on Notifications Page.");
            Thread.Sleep(1000);

            //Verify the User Added to Project notification subject on the Notifications Page
            String loggedInUserName = readNotifications.GetValue("LoggedInUserName", "username");
            notificationsPage.VerifyUserAddedToProjectSubject(loggedInUserName, projectName);
            log.Info("Verify User Added to Project notification subject on the Notifications Page.");
            Thread.Sleep(2000);

            //Signout of the application
            authenticationPage.SignOut();
            log.Info("Click on the Signout button.");
            Thread.Sleep(5000);

            //Login to the application
            Thread.Sleep(5000);
            authenticationPage.SetUserName(_workEmail);
            authenticationPage.SetPassword(_password);
            authenticationPage.ClickOnLoginButton();

            //Enter the Project Name
            Thread.Sleep(5000);
            postProjectPage.SearchProjectName(projectName);
            log.Info("Enter the project name.");
            Thread.Sleep(2000);

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
        public void Notifications_005_UserRemovedFromProject()
        {
            Global.MethodName = "Notifications_005_UserRemovedFromProject";

            //Post a new project
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(6));
            String projectName = readNotifications.GetValue("AddProjectDetails", "projectName");
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

            //Click Save Button
            postProjectPage.ClickManageTeamSaveBtn();
            log.Info("Click on the Save button.");
            Thread.Sleep(5000);

            //Signout of the application
            authenticationPage.SignOut();
            log.Info("Click on the Signout button.");
            Thread.Sleep(5000);

            //Sign in with different user
            String userName = readNotifications.GetValue("RemovedProjectMember", "removedMemberEmail");
            String password = readNotifications.GetValue("RemovedProjectMember", "password");
            SignInDifferentUser(userName, password);
            Thread.Sleep(7000);

            //Click Notifications Icon
            notificationsPage.ClickNotificationsIcon();
            log.Info("Click on the Notifications Icon at top.");
            Thread.Sleep(5000);

            //Verify the User Removed From Project short notification on the Notification Window
            notificationsPage.VerifyUserRemovedFromProjectNotificationWindow();
            log.Info("Verify the User Removed From Project short notification on the Notification Window.");
            Thread.Sleep(1000);

            //Click See All link
            notificationsPage.ClickSeeAll();
            log.Info("Click See All link.");
            Thread.Sleep(7000);

            //Verify the User Added to Project Notification on Notifications Page
            notificationsPage.VerifyUserRemovedFromProject();
            log.Info("Verify the User Removed From Project Notification on Notifications Page.");
            Thread.Sleep(1000);

            //Verify the User Removed From Project notification subject on the Notifications Page
            String loggedInUserName = readNotifications.GetValue("LoggedInUserName", "username");
            notificationsPage.VerifyUserRemovedFromProjectSubject(loggedInUserName, projectName);
            log.Info("Verify User Added to Project notification subject on the Notifications Page.");
            Thread.Sleep(2000);

            //Signout of the application
            authenticationPage.SignOut();
            log.Info("Click on the Signout button.");
            Thread.Sleep(5000);

            //Login to the application
            Thread.Sleep(5000);
            authenticationPage.SetUserName(_workEmail);
            authenticationPage.SetPassword(_password);
            authenticationPage.ClickOnLoginButton();

            //Enter the Project Name
            Thread.Sleep(5000);
            postProjectPage.SearchProjectName(projectName);
            log.Info("Enter the project name.");
            Thread.Sleep(2000);

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
        public void Notifications_006_UserMentionedInProjectWithAll()
        {
            Global.MethodName = "Notifications_006_UserMentionedInProjectWithAll";

            //Post a new project
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(6));
            String projectName = readNotifications.GetValue("AddProjectDetails", "projectName");
            projectName = projectName + builder;
            PostNewProject(projectName);

            //Go to Discussions Page
            postProjectPage.ClickDiscussionTab();
            log.Info("Click on the Discussions tab.");
            Thread.Sleep(5000);

            commonPage.PressTabKey();
            Thread.Sleep(1000);
            commonPage.PressTabKey();
            Thread.Sleep(1000);
            commonPage.PressTabKey();
            Thread.Sleep(1000);            

            //Enter the Message in Text Area
            postProjectPage.EnterMessageTextArea("Hi @all");
            log.Info("Enter message in Discussion.");
            Thread.Sleep(6000);
            commonPage.PressEnterKey();
            Thread.Sleep(2000);

            //Click the Post button for the message
            postProjectPage.ClickMessagePostBtn();
            log.Info("Click the Post button for the message.");
            Thread.Sleep(7000);

            //Signout of the application
            authenticationPage.SignOut();
            log.Info("Click on the Signout button.");
            Thread.Sleep(5000);

            //Sign in with different user
            String userName = readNotifications.GetValue("AddProjectMember", "addMemberEmail");
            String password = readNotifications.GetValue("AddProjectMember", "password");
            SignInDifferentUser(userName, password);
            Thread.Sleep(7000);

            //Click Notifications Icon
            notificationsPage.ClickNotificationsIcon();
            log.Info("Click on the Notifications Icon at top.");
            Thread.Sleep(5000);

            //Verify the User Mentioned In Project WIth All on the Notification Window
            notificationsPage.VerifyUserMentionedInProjectWIthAllNotificationWindow();
            log.Info("Verify the User Mentioned In Project WIth All short notification on the Notification Window.");
            Thread.Sleep(1000);

            //Click See All link
            notificationsPage.ClickSeeAll();
            log.Info("Click See All link.");
            Thread.Sleep(7000);

            //Verify the User Mentioned In Project WIth All on Notifications Page
            notificationsPage.VerifyUserMentionedInProjectWIthAll();
            log.Info("Verify the User Mentioned In Project WIth All Notification on Notifications Page.");
            Thread.Sleep(1000);

            //Verify the User Mentioned In Project WIth All subject on the Notifications Page
            String loggedInUserName = readNotifications.GetValue("LoggedInUserName", "username");
            notificationsPage.VerifyUserMentionedInProjectWIthAllSubject(loggedInUserName, "Hi @all");
            log.Info("Verify User Mentioned In Project WIth All notification subject on the Notifications Page.");
            Thread.Sleep(2000);

            //Signout of the application
            authenticationPage.SignOut();
            log.Info("Click on the Signout button.");
            Thread.Sleep(5000);

            //Login to the application
            Thread.Sleep(5000);
            authenticationPage.SetUserName(_workEmail);
            authenticationPage.SetPassword(_password);
            authenticationPage.ClickOnLoginButton();

            //Enter the Project Name
            Thread.Sleep(5000);
            postProjectPage.SearchProjectName(projectName);
            log.Info("Enter the project name.");
            Thread.Sleep(2000);

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
        public void Notifications_013_UserMentionedInProject()
        {
            Global.MethodName = "Notifications_013_UserMentionedInProject";

            //Post a new project
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(6));
            String projectName = readNotifications.GetValue("AddProjectDetails", "projectName");
            projectName = projectName + builder;
            PostNewProject(projectName);

            //Go to Discussions Page
            postProjectPage.ClickDiscussionTab();
            log.Info("Click on the Discussions tab.");
            Thread.Sleep(5000);

            commonPage.PressTabKey();
            Thread.Sleep(1000);
            commonPage.PressTabKey();
            Thread.Sleep(1000);
            commonPage.PressTabKey();
            Thread.Sleep(1000);

            //Enter the Message in Text Area
            postProjectPage.EnterMessageTextArea("Hi @anup");
            log.Info("Enter message in Discussion.");
            Thread.Sleep(6000);
            commonPage.PressEnterKey();
            Thread.Sleep(2000);

            //Click the Post button for the message
            postProjectPage.ClickMessagePostBtn();
            log.Info("Click the Post button for the message.");
            Thread.Sleep(7000);

            //Signout of the application
            authenticationPage.SignOut();
            log.Info("Click on the Signout button.");
            Thread.Sleep(5000);

            //Sign in with different user
            String userName = readNotifications.GetValue("AddProjectMember", "addMemberEmail");
            String password = readNotifications.GetValue("AddProjectMember", "password");
            SignInDifferentUser(userName, password);
            Thread.Sleep(7000);

            //Click Notifications Icon
            notificationsPage.ClickNotificationsIcon();
            log.Info("Click on the Notifications Icon at top.");
            Thread.Sleep(5000);

            //Verify the User Mentioned In Project WIth All on the Notification Window
            notificationsPage.VerifyUserMentionedInProjectWIthAllNotificationWindow();
            log.Info("Verify the User Mentioned In Project WIth All short notification on the Notification Window.");
            Thread.Sleep(1000);

            //Click See All link
            notificationsPage.ClickSeeAll();
            log.Info("Click See All link.");
            Thread.Sleep(7000);

            //Verify the User Mentioned In Project WIth All on Notifications Page
            notificationsPage.VerifyUserMentionedInProjectWIthAll();
            log.Info("Verify the User Mentioned In Project WIth All Notification on Notifications Page.");
            Thread.Sleep(1000);

            //Verify the User Mentioned In Project WIth All subject on the Notifications Page
            String loggedInUserName = readNotifications.GetValue("LoggedInUserName", "username");
            notificationsPage.VerifyUserMentionedInProjectWIthAllSubject(loggedInUserName, "Hi @anupkumar");
            log.Info("Verify User Mentioned In Project WIth All notification subject on the Notifications Page.");
            Thread.Sleep(2000);

            //Signout of the application
            authenticationPage.SignOut();
            log.Info("Click on the Signout button.");
            Thread.Sleep(5000);

            //Login to the application
            Thread.Sleep(5000);
            authenticationPage.SetUserName(_workEmail);
            authenticationPage.SetPassword(_password);
            authenticationPage.ClickOnLoginButton();

            //Enter the Project Name
            Thread.Sleep(5000);
            postProjectPage.SearchProjectName(projectName);
            log.Info("Enter the project name.");
            Thread.Sleep(2000);

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
        public void Notifications_007_InvoiceRequiresApproval()
        {
            Global.MethodName = "Notifications_007_InvoiceRequiresApproval";

            //Post a new project
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(6));
            String projectName = readNotifications.GetValue("AddProjectDetails", "projectName");
            projectName = projectName + builder;
            PostNewProject(projectName);            

            //Signout of the application
            authenticationPage.SignOut();
            log.Info("Click on the Signout button.");
            Thread.Sleep(5000);

            //Sign in with different user
            String userName = readNotifications.GetValue("AddProjectMember", "addMemberEmail");
            String password = readNotifications.GetValue("AddProjectMember", "password");
            SignInDifferentUser(userName, password);
            Thread.Sleep(7000);

            //Click Invoicing menu option
            invoicingPage.ClickInvoicingMenu();
            log.Info("Click the Invoicing menu.");
            Thread.Sleep(5000);

            //Create Invoice
            String invoiceTitle = readNotifications.GetValue("InvoiceDetails", "invoiceTitle");
            invoiceTitle = invoiceTitle + builder;
            CreateInvoice(invoiceTitle, projectName);

            //Click Submit button
            invoicingPage.ClickSubmitBtn();
            log.Info("Click Submit button.");
            Thread.Sleep(5000);

            //Signout of the application
            authenticationPage.SignOut();
            log.Info("Click on the Signout button.");
            Thread.Sleep(5000);

            //Login to the application
            authenticationPage.SetUserName(_workEmail);
            authenticationPage.SetPassword(_password);
            authenticationPage.ClickOnLoginButton();
            Thread.Sleep(5000);
            
            //Click Notifications Icon
            notificationsPage.ClickNotificationsIcon();
            log.Info("Click on the Notifications Icon at top.");
            Thread.Sleep(5000);

            //Verify the Invoice Requires Approval on the Notification Window
            notificationsPage.VerifyInvoiceRequiresApprovalNotificationWindow();
            log.Info("Verify the Invoice Requires Approval short notification on the Notification Window.");
            Thread.Sleep(1000);

            //Click See All link
            notificationsPage.ClickSeeAll();
            log.Info("Click See All link.");
            Thread.Sleep(7000);

            //Verify the Invoice Requires Approval on Notifications Page
            notificationsPage.VerifyInvoiceRequiresApproval();
            log.Info("Verify the Invoice Requires Approval Notification on Notifications Page.");
            Thread.Sleep(1000);

            //Verify the Invoice Requires Approval subject on the Notifications Page
            String addMemberName = readNotifications.GetValue("AddProjectMember", "addMemberName");
            notificationsPage.VerifyInvoiceRequiresApprovalSubject(addMemberName);
            log.Info("Verify Invoice Requires Approval notification subject on the Notifications Page.");
            Thread.Sleep(2000);

            //Click the Marketplace tab
            marketplacePage.ClickMarketplaceTab();
            log.Info("Click the Marketplace tab.");
            Thread.Sleep(5000);

            //Enter the Project Name
            Thread.Sleep(5000);
            postProjectPage.SearchProjectName(projectName);
            log.Info("Enter the project name.");
            Thread.Sleep(2000);

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
        public void Notifications_008_InvoiceApproved()
        {
            Global.MethodName = "Notifications_008_InvoiceApproved";

            //Post a new project
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(6));
            String projectName = readNotifications.GetValue("AddProjectDetails", "projectName");
            projectName = projectName + builder;
            PostNewProject(projectName);

            //Signout of the application
            authenticationPage.SignOut();
            log.Info("Click on the Signout button.");
            Thread.Sleep(5000);

            //Sign in with different user
            String userName = readNotifications.GetValue("AddProjectMember", "addMemberEmail");
            String password = readNotifications.GetValue("AddProjectMember", "password");
            SignInDifferentUser(userName, password);
            Thread.Sleep(7000);

            //Click Invoicing menu option
            invoicingPage.ClickInvoicingMenu();
            log.Info("Click the Invoicing menu.");
            Thread.Sleep(5000);

            //Create Invoice
            String invoiceTitle = readNotifications.GetValue("InvoiceDetails", "invoiceTitle");
            invoiceTitle = invoiceTitle + builder;
            CreateInvoice(invoiceTitle, projectName);

            //Click Submit button
            invoicingPage.ClickSubmitBtn();
            log.Info("Click Submit button.");
            Thread.Sleep(5000);

            //Signout of the application
            authenticationPage.SignOut();
            log.Info("Click on the Signout button.");
            Thread.Sleep(5000);

            //Login to the application
            authenticationPage.SetUserName(_workEmail);
            authenticationPage.SetPassword(_password);
            authenticationPage.ClickOnLoginButton();
            Thread.Sleep(5000);

            //Click Invoicing menu option
            invoicingPage.ClickInvoicingMenu();
            log.Info("Click the Invoicing menu.");
            Thread.Sleep(2000);

            //Click Invoice Displayed
            invoicingPage.ClickInvoiceDisplayed(invoiceTitle);
            log.Info("Click Invoice displayed.");
            Thread.Sleep(5000);           

            //Click Approve button
            invoicingPage.ClickApproveBtn();
            log.Info("Click the Approve button.");
            Thread.Sleep(5000);

            //Signout of the application
            authenticationPage.SignOut();
            log.Info("Click on the Signout button.");
            Thread.Sleep(5000);

            //Sign in with different user
            SignInDifferentUser(userName, password);
            Thread.Sleep(7000);

            //Click Notifications Icon
            notificationsPage.ClickNotificationsIcon();
            log.Info("Click on the Notifications Icon at top.");
            Thread.Sleep(5000);

            //Verify the Invoice Approved on the Notification Window
            notificationsPage.VerifyInvoiceApprovedNotificationWindow();
            log.Info("Verify the Invoice Approved short notification on the Notification Window.");
            Thread.Sleep(1000);

            //Click See All link
            notificationsPage.ClickSeeAll();
            log.Info("Click See All link.");
            Thread.Sleep(7000);

            //Verify the Invoice Approved on Notifications Page
            notificationsPage.VerifyInvoiceApproved();
            log.Info("Verify the Invoice Approved Notification on Notifications Page.");
            Thread.Sleep(1000);

            //Verify the Invoice Approved subject on the Notifications Page
            String loggedInUserName = readNotifications.GetValue("LoggedInUserName", "username");
            notificationsPage.VerifyInvoiceApprovedSubject(loggedInUserName, invoiceTitle);
            log.Info("Verify Invoice Approved notification subject on the Notifications Page.");
            Thread.Sleep(2000);

            //Signout of the application
            authenticationPage.SignOut();
            log.Info("Click on the Signout button.");
            Thread.Sleep(5000);

            //Login to the application
            authenticationPage.SetUserName(_workEmail);
            authenticationPage.SetPassword(_password);
            authenticationPage.ClickOnLoginButton();
            Thread.Sleep(5000);

            //Enter the Project Name
            postProjectPage.SearchProjectName(projectName);
            log.Info("Enter the project name.");
            Thread.Sleep(2000);

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
        public void Notifications_009_InvoiceDenied()
        {
            Global.MethodName = "Notifications_009_InvoiceDenied";

            //Post a new project
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(6));
            String projectName = readNotifications.GetValue("AddProjectDetails", "projectName");
            projectName = projectName + builder;
            PostNewProject(projectName);

            //Signout of the application
            authenticationPage.SignOut();
            log.Info("Click on the Signout button.");
            Thread.Sleep(5000);

            //Sign in with different user
            String userName = readNotifications.GetValue("AddProjectMember", "addMemberEmail");
            String password = readNotifications.GetValue("AddProjectMember", "password");
            SignInDifferentUser(userName, password);
            Thread.Sleep(7000);

            //Click Invoicing menu option
            invoicingPage.ClickInvoicingMenu();
            log.Info("Click the Invoicing menu.");
            Thread.Sleep(5000);

            //Create Invoice
            String invoiceTitle = readNotifications.GetValue("InvoiceDetails", "invoiceTitle");
            invoiceTitle = invoiceTitle + builder;
            CreateInvoice(invoiceTitle, projectName);

            //Click Submit button
            invoicingPage.ClickSubmitBtn();
            log.Info("Click Submit button.");
            Thread.Sleep(5000);

            //Signout of the application
            authenticationPage.SignOut();
            log.Info("Click on the Signout button.");
            Thread.Sleep(5000);

            //Login to the application
            authenticationPage.SetUserName(_workEmail);
            authenticationPage.SetPassword(_password);
            authenticationPage.ClickOnLoginButton();
            Thread.Sleep(5000);

            //Click Invoicing menu option
            invoicingPage.ClickInvoicingMenu();
            log.Info("Click the Invoicing menu.");
            Thread.Sleep(2000);

            //Click Invoice Displayed
            invoicingPage.ClickInvoiceDisplayed(invoiceTitle);
            log.Info("Click Invoice displayed.");
            Thread.Sleep(5000);

            //Click Deny button
            invoicingPage.ClickDenyBtn();
            log.Info("Click the Deny button.");
            Thread.Sleep(5000);

            //Signout of the application
            authenticationPage.SignOut();
            log.Info("Click on the Signout button.");
            Thread.Sleep(5000);

            //Sign in with different user
            SignInDifferentUser(userName, password);
            Thread.Sleep(7000);

            //Click Notifications Icon
            notificationsPage.ClickNotificationsIcon();
            log.Info("Click on the Notifications Icon at top.");
            Thread.Sleep(5000);

            //Verify the Invoice Denied on the Notification Window
            notificationsPage.VerifyInvoiceDeniedNotificationWindow();
            log.Info("Verify the Invoice Denied short notification on the Notification Window.");
            Thread.Sleep(1000);

            //Click See All link
            notificationsPage.ClickSeeAll();
            log.Info("Click See All link.");
            Thread.Sleep(7000);

            //Verify the Invoice Denied on Notifications Page
            notificationsPage.VerifyInvoiceDenied();
            log.Info("Verify the Invoice Denied Notification on Notifications Page.");
            Thread.Sleep(1000);

            //Verify the Invoice Denied subject on the Notifications Page
            String loggedInUserName = readNotifications.GetValue("LoggedInUserName", "username");
            notificationsPage.VerifyInvoiceDeniedSubject(loggedInUserName, invoiceTitle);
            log.Info("Verify Invoice Denied notification subject on the Notifications Page.");
            Thread.Sleep(2000);

            //Signout of the application
            authenticationPage.SignOut();
            log.Info("Click on the Signout button.");
            Thread.Sleep(5000);

            //Login to the application
            authenticationPage.SetUserName(_workEmail);
            authenticationPage.SetPassword(_password);
            authenticationPage.ClickOnLoginButton();
            Thread.Sleep(5000);

            //Enter the Project Name
            postProjectPage.SearchProjectName(projectName);
            log.Info("Enter the project name.");
            Thread.Sleep(2000);

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
        public void Notifications_010_InvoiceApproved()
        {
            Global.MethodName = "Notifications_010_InvoiceApproved";

            //Post a new project
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(6));
            String projectName = readNotifications.GetValue("AddProjectDetails", "projectName");
            projectName = projectName + builder;
            PostNewProject(projectName);

            //Signout of the application
            authenticationPage.SignOut();
            log.Info("Click on the Signout button.");
            Thread.Sleep(5000);

            //Sign in with different user
            String userName = readNotifications.GetValue("AddProjectMember", "addMemberEmail");
            String password = readNotifications.GetValue("AddProjectMember", "password");
            SignInDifferentUser(userName, password);
            Thread.Sleep(7000);

            //Click Invoicing menu option
            invoicingPage.ClickInvoicingMenu();
            log.Info("Click the Invoicing menu.");
            Thread.Sleep(5000);

            //Create Invoice
            String invoiceTitle = readNotifications.GetValue("InvoiceDetails", "invoiceTitle");
            invoiceTitle = invoiceTitle + builder;
            CreateInvoice(invoiceTitle, projectName);

            //Click Submit button
            invoicingPage.ClickSubmitBtn();
            log.Info("Click Submit button.");
            Thread.Sleep(5000);

            //Signout of the application
            authenticationPage.SignOut();
            log.Info("Click on the Signout button.");
            Thread.Sleep(5000);

            //Login to the application
            authenticationPage.SetUserName(_workEmail);
            authenticationPage.SetPassword(_password);
            authenticationPage.ClickOnLoginButton();
            Thread.Sleep(5000);

            //Click Invoicing menu option
            invoicingPage.ClickInvoicingMenu();
            log.Info("Click the Invoicing menu.");
            Thread.Sleep(2000);

            //Click Invoice Displayed
            invoicingPage.ClickInvoiceDisplayed(invoiceTitle);
            log.Info("Click Invoice displayed.");
            Thread.Sleep(5000);

            //Click Approve button
            invoicingPage.ClickApproveBtn();
            log.Info("Click the Approve button.");
            Thread.Sleep(5000);            

            //Click Notifications Icon
            notificationsPage.ClickNotificationsIcon();
            log.Info("Click on the Notifications Icon at top.");
            Thread.Sleep(5000);

            //Verify the Invoice Requires Payment on the Notification Window
            notificationsPage.VerifyInvoiceRequiresPaymentNotificationWindow();
            log.Info("Verify the Invoice Requires Payment short notification on the Notification Window.");
            Thread.Sleep(1000);

            //Click See All link
            notificationsPage.ClickSeeAll();
            log.Info("Click See All link.");
            Thread.Sleep(7000);

            //Verify the Invoice Requires Payment on Notifications Page
            notificationsPage.VerifyInvoiceRequiresPayment();
            log.Info("Verify the Invoice Requires Payment Notification on Notifications Page.");
            Thread.Sleep(1000);

            //Verify the Invoice Requires Payment subject on the Notifications Page
            String loggedInUserName = readNotifications.GetValue("LoggedInUserName", "username");
            notificationsPage.VerifyInvoiceRequiresPaymentSubject(loggedInUserName);
            log.Info("Verify Invoice Requires Payment notification subject on the Notifications Page.");
            Thread.Sleep(2000);

            //Click the Marketplace tab
            marketplacePage.ClickMarketplaceTab();
            log.Info("Click the Marketplace tab.");
            Thread.Sleep(5000);

            //Enter the Project Name
            postProjectPage.SearchProjectName(projectName);
            log.Info("Enter the project name.");
            Thread.Sleep(2000);

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
        public void Notifications_011_UserReceivesFeedback()
        {
            Global.MethodName = "Notifications_011_UserReceivesFeedback";

            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(4));
            String projectName = "Endorse Project ";
            projectName = projectName + builder;
            PostNewProject(projectName);

            //Click User Icon
            userProfilePage.ClickUserProfileIcon();
            log.Info("Click the User Profile Icon.");
            Thread.Sleep(2000);

            //Select the User Profile Option 'Admin'
            userProfilePage.ClickUserProfileOptions("Admin");
            log.Info("Click User Profile option 'Admin'.");
            Thread.Sleep(2000);

            //Enter Search User Email Id
            String memberName = readNotifications.GetValue("AddProjectMember", "addMemberEmail");
            userProfilePage.EnterSearchUser(memberName);
            log.Info("Enter search user email id.");
            Thread.Sleep(2000);

            //Press Enter Key
            userProfilePage.PressEnterKey();
            Thread.Sleep(2000);

            //Click the searched user
            userProfilePage.ClickSearchedUser();
            log.Info("Click the searched user.");
            Thread.Sleep(5000);

            //Click Endorse button
            peoplePage.ClickEndorseBtn();
            log.Info("Click on Endorse button.");
            Thread.Sleep(10000);

            //Select Project DropDown
            peoplePage.SelectProjectDropDown(projectName);
            log.Info("Select Project DropDown.");
            Thread.Sleep(2000);

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

            //Signout of the application
            authenticationPage.SignOut();
            log.Info("Click on the Signout button.");
            Thread.Sleep(5000);

            //Sign in with different user
            String userName = readNotifications.GetValue("AddProjectMember", "addMemberEmail");
            String password = readNotifications.GetValue("AddProjectMember", "password");
            SignInDifferentUser(userName, password);
            Thread.Sleep(7000);

            //Click Notifications Icon
            notificationsPage.ClickNotificationsIcon();
            log.Info("Click on the Notifications Icon at top.");
            Thread.Sleep(5000);

            //Verify the User Receives Feedback on the Notification Window
            notificationsPage.VerifyUserReceivesFeedbackNotificationWindow();
            log.Info("Verify the User Receives Feedback short notification on the Notification Window.");
            Thread.Sleep(1000);

            //Click See All link
            notificationsPage.ClickSeeAll();
            log.Info("Click See All link.");
            Thread.Sleep(7000);

            //Verify the User Receives Feedback on Notifications Page
            notificationsPage.VerifyUserReceivesFeedback();
            log.Info("Verify the User Receives Feedback Notification on Notifications Page.");
            Thread.Sleep(1000);

            //Verify the User Receives Feedback subject on the Notifications Page
            String loggedInUserName = readNotifications.GetValue("LoggedInUserName", "username");
            notificationsPage.VerifyUserReceivesFeedbackSubject(loggedInUserName, projectName);
            log.Info("Verify User Receives Feedback notification subject on the Notifications Page.");
            Thread.Sleep(2000);

            //Signout of the application
            authenticationPage.SignOut();
            log.Info("Click on the Signout button.");
            Thread.Sleep(5000);

            //Login to the application
            authenticationPage.SetUserName(_workEmail);
            authenticationPage.SetPassword(_password);
            authenticationPage.ClickOnLoginButton();
            Thread.Sleep(5000);

            //Enter the Project Name
            postProjectPage.SearchProjectName(projectName);
            log.Info("Enter the project name.");
            Thread.Sleep(2000);

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
        public void Notifications_012_UserRequestsFeedback()
        {
            Global.MethodName = "Notifications_012_UserRequestsFeedback";

            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(4));
            String projectName = "Endorse Project ";
            projectName = projectName + builder;
            PostNewProject(projectName);

            //Signout of the application
            authenticationPage.SignOut();
            log.Info("Click on the Signout button.");
            Thread.Sleep(5000);

            //Sign in with different user
            String userName = readNotifications.GetValue("AddProjectMember", "addMemberEmail");
            String password = readNotifications.GetValue("AddProjectMember", "password");
            SignInDifferentUser(userName, password);
            Thread.Sleep(7000);

            //Click User Profile Icon
            userProfilePage.ClickUserProfileIcon();
            log.Info("Click the User Profile Icon.");
            Thread.Sleep(2000);

            //Select the User Profile Option 'Profile'
            userProfilePage.ClickUserProfileOptions("Profile");
            log.Info("Click User Profile option 'Profile'.");
            Thread.Sleep(2000);
            
            //Click Request Feedback button
            peoplePage.ClickRequestFeedbackBtn();
            log.Info("Click on Request Feedback button.");
            Thread.Sleep(10000);

            //Select Request Feedback Project DropDown
            peoplePage.SelectRequestFeedbackProject(projectName);
            log.Info("Select Project DropDown.");
            Thread.Sleep(3000);

            //Click Request Feedback Send button
            peoplePage.ClickSendBtnForFeedback();
            log.Info("Click Request Feedback Send button.");
            Thread.Sleep(5000);

            //Signout of the application
            authenticationPage.SignOut();
            log.Info("Click on the Signout button.");
            Thread.Sleep(5000);

            //Login to the application
            authenticationPage.SetUserName(_workEmail);
            authenticationPage.SetPassword(_password);
            authenticationPage.ClickOnLoginButton();
            Thread.Sleep(5000);

            //Click Notifications Icon
            notificationsPage.ClickNotificationsIcon();
            log.Info("Click on the Notifications Icon at top.");
            Thread.Sleep(5000);

            //Verify the User Requests Feedback on the Notification Window
            notificationsPage.VerifyUserRequestsFeedbackNotificationWindow();
            log.Info("Verify the User Requests Feedback short notification on the Notification Window.");
            Thread.Sleep(1000);

            //Click See All link
            notificationsPage.ClickSeeAll();
            log.Info("Click See All link.");
            Thread.Sleep(7000);

            //Verify the User Requests Feedback on Notifications Page
            notificationsPage.VerifyUserRequestsFeedback();
            log.Info("Verify the User Requests Feedback Notification on Notifications Page.");
            Thread.Sleep(3000);

            //Verify the User Requests Feedback subject on the Notifications Page
            String username = readNotifications.GetValue("AddProjectMember", "addMemberName");
            notificationsPage.VerifyUserRequestsFeedbackSubject(username, projectName);
            log.Info("Verify User Requests Feedback notification subject on the Notifications Page.");
            Thread.Sleep(2000);

            //Click the Marketplace tab
            marketplacePage.ClickMarketplaceTab();
            log.Info("Click the Marketplace tab.");
            Thread.Sleep(5000);

            //Enter the Project Name
            postProjectPage.SearchProjectName(projectName);
            log.Info("Enter the project name.");
            Thread.Sleep(2000);

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

















    }
}
