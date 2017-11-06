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
    public class ProjectsPage : BasePage
    {
        CommonMethods commonPage;
        
        public ProjectsPage(IWebDriver driver, int pageLoadTimeout)
            : base(driver, pageLoadTimeout)
        {
            commonPage = new CommonMethods(_driver, pageLoadTimeout);
        }        

        //Verify Projects menu option
        public void VerifyProjectsMenuOption()
        {
            _assertHelper.AssertElementDisplayed(DashboardUI.sideNavBar("Projects"));
        }

        //Click on the Type of Project
        public void SelectProjectType(String projectType)
        {
            _driver.WaitForElementAvailableAtDOM(ProjectsUI.ProjectType(projectType), 1);
            _driver.SafeClick(ProjectsUI.ProjectType(projectType));
        }

        //Click on Projects menu option
        public void ClickProjectsMenu()
        {
            _driver.WaitForElementAvailableAtDOM(DashboardUI.sideNavBar("Projects"), 1);
            _driver.SafeClick(DashboardUI.sideNavBar("Projects"));
        }        

        //Click on 'Add project' button
        public void ClickOnAddProjectButton()
        {
            _driver.WaitForElementAvailableAtDOM(ProjectsUI.addProjectBtn, 1);
            _driver.SafeClick(ProjectsUI.addProjectBtn);
        }

        //Enter Project Name
        public void EnterProjectName(String projectName)
        {
            _driver.WaitForElementAvailableAtDOM(ProjectsUI.nameField, 1);
            _driver.SafeEnterText(ProjectsUI.nameField, projectName);
        }
       
        //Enter Project Description
        public void EnterProjectDescription(String projectDescription)
        {
            _driver.WaitForElementAvailableAtDOM(ProjectsUI.descriptionField, 1);
            _driver.SafeEnterText(ProjectsUI.descriptionField, projectDescription);
        }

        //Click Create button
        public void ClickOnCreateProjectBtn()
        {
            _driver.WaitForElementAvailableAtDOM(ProjectsUI.createBtn, 1);
            _driver.SafeClick(ProjectsUI.createBtn);
        }

        //Click the All Projects Dropdown option
        public void ClickAllProjectsDropDown()
        {
            _driver.WaitForElementAvailableAtDOM(ProjectsUI.allProjectDrpdwnLink, 1);
            _driver.SafeClick(ProjectsUI.allProjectDrpdwnLink);
        }

        //Select I've Posted option from All Projects Dropdown
        public void SelectAllProjectsIvePosted()
        {
            _driver.WaitForElementAvailableAtDOM(ProjectsUI.ProjTypeIvePosted, 1);
            _driver.ClickElementUsingAction(ProjectsUI.ProjTypeIvePosted);
        }

        //Select Recruiting option from All Projects Dropdown
        public void SelectAllProjectsRecruiting()
        {
            _driver.ClickElementUsingAction(ProjectsUI.ProjTypeRecruiting);
        }

        //Select In Progress option from All Projects Dropdown
        public void SelectAllProjectsInProgress()
        {
            _driver.WaitForElementAvailableAtDOM(ProjectsUI.ProjTypeInProgress, 1);
            _driver.ClickElementUsingAction(ProjectsUI.ProjTypeInProgress);
        }

        //Select Completed option from All Projects Dropdown
        public void SelectAllProjectsCompleted()
        {
            _driver.WaitForElementAvailableAtDOM(ProjectsUI.ProjTypeCompleted, 1);
            _driver.ClickElementUsingAction(ProjectsUI.ProjTypeCompleted);
        }

        //Press Mark Complete button at Complete Project window
        public void ClickMarkComplete()
        {
            _driver.WaitForElementAvailableAtDOM(ProjectsUI.completeProjMarkComplete, 1);
            _driver.SafeClick(ProjectsUI.completeProjMarkComplete);
        }

        //Select Closed option from All Projects Dropdown
        public void SelectAllProjectsClosed()
        {
            _driver.WaitForElementAvailableAtDOM(ProjectsUI.ProjTypeClosed, 1);
            _driver.ClickElementUsingAction(ProjectsUI.ProjTypeClosed);
        }

        //Verify the Project Name on Projects Page
        public void VerifyProjectNameOnPage(String projectName)
        {
            _assertHelper.AssertElementDisplayed(ProjectsUI.ProjectNameOnPage(projectName));
        }

        //Verify the Project Name on Projects Page is not displayed
        public void VerifyProjectNameOnPageNotDisplayed(String projectName)
        {
            _assertHelper.AssertElementNotDisplayed(ProjectsUI.ProjectNameOnPage(projectName));
        }

        //Click the Project on Projects Page
        public void ClickProjectNameOnPage(String projectName)
        {
            _driver.SafeClick(ProjectsUI.ProjectNameOnPage(projectName));
        }

        //Click on Delete Project Icon
        public void ClickDeleteProjectIcon()
        {
            _driver.SafeClick(ProjectsUI.deleteProjectIcon);
        }

        //Verify No Button from the Delete Group Window
        public void VerifyDeleteProjectWindow()
        {
            _assertHelper.AssertElementDisplayed(ProjectsUI.deleteProjectWindow);
        }

        //Verify No Button from the Delete Group Window
        public void VerifyDeleteProjectWindowNoBtn()
        {
            _assertHelper.AssertElementDisplayed(ProjectsUI.deleteProjectWindowNoBtn);
        }

        //Verify Yes Button from the Delete Group Window
        public void VerifyDeleteProjectWindowYesBtn()
        {
            _assertHelper.AssertElementDisplayed(ProjectsUI.deleteProjectWindowYesBtn);
        }

        //Press No Button from the Delete Project Window
        public void PressDeleteProjectWindowNoBtn()
        {
            _driver.SafeClick(ProjectsUI.deleteProjectWindowNoBtn);
        }

        //Press Yes Button from the Delete Project Window
        public void PressDeleteProjectWindowYesBtn()
        {        
            _driver.SafeClick(ProjectsUI.deleteProjectWindowYesBtn);
        }

        //Select a value from Stratus dropdown
        public void SelectStatusDropDown(String option)
        {
            _driver.WaitForElementAvailableAtDOM(ProjectsUI.statusDropDown, 1);
            _driver.SelectDropDownOption(option, ProjectsUI.statusDropDown);
        }

        //Click Stratus dropdown
        public void ClickStatusDropDown()
        {
            _driver.WaitForElementAvailableAtDOM(ProjectsUI.statusDropDown, 1);
            _driver.SafeClick(ProjectsUI.statusDropDown);
        }

        //Verify Request To Join button
        public void AsssertRequestToJoinBtn()
        {
            _driver.WaitForElementAvailableAtDOM(ProjectsUI.requestToJoinBtn, 1);
            _assertHelper.AssertElementDisplayed(ProjectsUI.requestToJoinBtn);
        }

        //Verify Request To Join button is not displayed
        public void AssertNoRequestToJoinBtn()
        {
            _assertHelper.AssertElementNotDisplayed(ProjectsUI.requestToJoinBtn);
        }

        //Press Request To Join button
        public void ClickRequestToJoinBtn()
        {
            _driver.ClickUsingSendKeys(ProjectsUI.requestToJoinBtn);
        }

        //Verify Request Sent button
        public void AsssertRequestSentBtn()
        {
            _assertHelper.AssertElementDisplayed(ProjectsUI.requestSentBtn);
        }

        //Click the Requested Member Icon
        public void ClickRequestedMember()
        {
            _driver.WaitForElementAvailableAtDOM(ProjectsUI.addRequestedMember, 1);
            _driver.SafeClick(ProjectsUI.addRequestedMember);
        }

        //Accept the Requested Member Icon
        public void AcceptRequestedMember()
        {
            _driver.WaitForElementAvailableAtDOM(ProjectsUI.pendingWindowAcceptIcon, 1);
            _driver.SafeClick(ProjectsUI.pendingWindowAcceptIcon);
        }

        //Decline the Requested Member Icon
        public void DeclineRequestedMember()
        {
            _driver.WaitForElementAvailableAtDOM(ProjectsUI.pendingWindowDeclineIcon, 1);
            _driver.SafeClick(ProjectsUI.pendingWindowDeclineIcon);
        }

        //Close Pending Window
        public void ClosePendingMemberWindow()
        {
            _driver.WaitForElementAvailableAtDOM(ProjectsUI.pendingWindowAcceptIcon, 1);
            _driver.SafeClick(ProjectsUI.pendingWindowCrossIcon);
        }

        //Verify Leave Project Icon
        public void LeaveProjectIcon()
        {
            _driver.WaitForElementAvailableAtDOM(ProjectsUI.leaveProjectIcon, 1);
            _assertHelper.AssertElementDisplayed(ProjectsUI.leaveProjectIcon);
        }

        //Press the Leave Project Icon
        public void ClickLeaveProjectIcon()
        {
            _driver.SafeClick(ProjectsUI.leaveProjectIcon);
        }

        //Press the Leave Project Window Yes button
        public void ClickLeaveProjectWindowYesBtn()
        {
            _driver.SafeClick(ProjectsUI.leaveProjectWindowYesBtn);
        }

        //Verify Share Project Icon
        public void ShareProjectIcon()
        {
            _driver.WaitForElementAvailableAtDOM(ProjectsUI.shareProjectIcon, 1);
            _assertHelper.AssertElementDisplayed(ProjectsUI.shareProjectIcon);
        }

        //Verify Successful Project creation message
        public void verifyProjectConfirmationMessage()
        {
            _driver.WaitForElementAvailableAtDOM(ProjectsUI.projectCreatedMsg, 1);
            _assertHelper.AssertElementDisplayed(ProjectsUI.projectCreatedMsg);
        }

        //Verify the fields displayed on the screen
        //Verify About tab on the Project Page
        public void VerifyAboutTab()
        {
            _driver.WaitForElementAvailableAtDOM(ProjectsUI.aboutTab, 1);
            _assertHelper.AssertElementDisplayed(ProjectsUI.aboutTab);
        }

        //Press About tab on the Project Page
        public void ClickAboutTab()
        {
            _driver.WaitForElementAvailableAtDOM(ProjectsUI.aboutTab, 1);
            _driver.SafeClick(ProjectsUI.aboutTab);
        }

        //Verify Discussions tab on the Project Page
        public void VerifyDiscussionsTab()
        {
            _driver.WaitForElementAvailableAtDOM(ProjectsUI.discussionTab, 1);
            _assertHelper.AssertElementDisplayed(ProjectsUI.discussionTab);
        }

        //Verify Tasks tab on the Project Page
        public void VerifyTasksTab()
        {
            _driver.WaitForElementAvailableAtDOM(ProjectsUI.tasksTab, 1);
            _assertHelper.AssertElementDisplayed(ProjectsUI.tasksTab);
        }

        //Click Tasks tab on the Project Page
        public void ClickTasksTab()
        {
            _driver.WaitForElementAvailableAtDOM(ProjectsUI.tasksTab, 1);
            _driver.SafeClick(ProjectsUI.tasksTab);
        }

        //Verify Files tab on the Project Page
        public void VerifyFilesTab()
        {
            _driver.WaitForElementAvailableAtDOM(ProjectsUI.filesTab, 1);
            _assertHelper.AssertElementDisplayed(ProjectsUI.filesTab);
        }

        //Verify Add Member Icon on the Project Page
        public void VerifyAddMemberIcon()
        {
            _driver.WaitForElementAvailableAtDOM(ProjectsUI.addMemberIcon, 1);
            _assertHelper.AssertElementDisplayed(ProjectsUI.addMemberIcon);
        }

        //Verify Share Project Icon on the Project Page
        public void VerifyShareProjectIcon()
        {
            _driver.WaitForElementAvailableAtDOM(ProjectsUI.shareProjectIcon, 1);
            _assertHelper.AssertElementDisplayed(ProjectsUI.shareProjectIcon);
        }

        //Verify Delete Project Icon on the Project Page
        public void VerifyDeleteProjectIcon()
        {
            _driver.WaitForElementAvailableAtDOM(ProjectsUI.deleteProjectIcon, 1);
            _assertHelper.AssertElementDisplayed(ProjectsUI.deleteProjectIcon);
        }

        //Verify Status on the Project Page
        public void VerifyStatus()
        {
            _driver.WaitForElementAvailableAtDOM(ProjectsUI.statusDropDown, 1);
            _assertHelper.AssertElementDisplayed(ProjectsUI.statusDropDown);
        }

        //Verify Start Date on the Project Page
        public void VerifyStartDate()
        {
            _driver.WaitForElementAvailableAtDOM(ProjectsUI.startDate, 1);
            _assertHelper.AssertElementDisplayed(ProjectsUI.startDate);
        }

        //Verify Due Date on the Project Page
        public void VerifyDueDate()
        {
            _driver.WaitForElementAvailableAtDOM(ProjectsUI.dueDate, 1);
            _assertHelper.AssertElementDisplayed(ProjectsUI.dueDate);
        }

        //Verify Location on the Project Page
        public void VerifyLocation()
        {
            _driver.WaitForElementAvailableAtDOM(ProjectsUI.location, 1);
            _assertHelper.AssertElementDisplayed(ProjectsUI.location);
        }

        //Verify Group on the Project Page
        public void VerifyGroup()
        {
            _driver.WaitForElementAvailableAtDOM(ProjectsUI.group, 1);
            _assertHelper.AssertElementDisplayed(ProjectsUI.group);
        }

        //Verify Event on the Project Page
        public void VerifyEvent()
        {
            _driver.WaitForElementAvailableAtDOM(ProjectsUI.eventSelect, 1);
            _assertHelper.AssertElementDisplayed(ProjectsUI.eventSelect);
        }

        //Verify Reward on the Project Page
        public void VerifyReward()
        {
            _driver.WaitForElementAvailableAtDOM(ProjectsUI.reward, 1);
            _assertHelper.AssertElementDisplayed(ProjectsUI.reward);
        }

        //Verify Project Owner on the Project Page
        public void VerifyOwner()
        {
            _driver.WaitForElementAvailableAtDOM(ProjectsUI.projectOwner, 1);
            _assertHelper.AssertElementDisplayed(ProjectsUI.projectOwner);
        }

        //Verify GitHub on the Project Page
        public void VerifyGitHub()
        {
            _driver.WaitForElementAvailableAtDOM(ProjectsUI.gitHubRepo, 1);
            _assertHelper.AssertElementDisplayed(ProjectsUI.gitHubRepo);
        }

        //Verify Mark Complete button on the Project Page
        public void VerifyMarkCompleteBtn()
        {
            _driver.WaitForElementAvailableAtDOM(ProjectsUI.markCompleteBtn, 1);
            _assertHelper.AssertElementDisplayed(ProjectsUI.markCompleteBtn);
        }

        //Press the Add Member Icon for Project
        public void ClickAddMemberIcon()
        {
            _driver.WaitForElementAvailableAtDOM(ProjectsUI.addMemberIcon, 1);
            _driver.SafeClick(ProjectsUI.addMemberIcon);
        }

        //Verify data on Add Project Member section
        public void VerifyAddProjectMemberWindowFields()
        {
            _driver.WaitForElementAvailableAtDOM(ProjectsUI.addSomeoneText, 1);
            _assertHelper.AssertElementDisplayed(ProjectsUI.addSomeoneText);
            _driver.WaitForElementAvailableAtDOM(ProjectsUI.searchSkillsText, 1);
            _assertHelper.AssertElementDisplayed(ProjectsUI.searchSkillsText);
            _driver.WaitForElementAvailableAtDOM(ProjectsUI.myTeamDiv, 1);
            _assertHelper.AssertElementDisplayed(ProjectsUI.myTeamDiv);
            _driver.WaitForElementAvailableAtDOM(ProjectsUI.doneBtn, 1);
            _assertHelper.AssertElementDisplayed(ProjectsUI.doneBtn);
        }

        //Press the Add Project Member window close icon
        public void ClickAddProjectMemberWindowCloseIcon()
        {
            _driver.WaitForElementAvailableAtDOM(ProjectsUI.closeAddMemberWindowIcon, 1);
            _driver.SafeClick(ProjectsUI.closeAddMemberWindowIcon);
        }

        //Enter Project Member Email
        public void EnterProjectMemberEmail(String memberEmail)
        {
            _driver.WaitForElementAvailableAtDOM(ProjectsUI.addSomeoneText, 1);
            _driver.SafeEnterText(ProjectsUI.addSomeoneText, memberEmail);
        }

        //Select user from suggestion list
        public void SelectUserfromSuggestion(String SuggItem)
        {
            _driver.WaitForElementAvailableAtDOM(GroupsUI.addMemberSuggList(SuggItem), 1);
            _driver.SafeClick(GroupsUI.addMemberSuggList(SuggItem));
        }

        //Press Project Add Member Window Done button
        public void ClickAddProjectMemberDoneBtn()
        {
            _driver.WaitForElementAvailableAtDOM(ProjectsUI.doneBtn, 1);
            _driver.SafeClick(ProjectsUI.doneBtn);
        }

        //Verify the Added Project Member confirmation message
        public void VerifyAddedMemberConfMsg()
        {
            _driver.WaitForElementAvailableAtDOM(ProjectsUI.addMemberConfirmationMsg, 1);
            _assertHelper.AssertElementDisplayed(ProjectsUI.addMemberConfirmationMsg);
        }

        //Press the Added Project Member remove icon
        public void ClickAddedMemberRemoveIcon()
        {
            _driver.WaitForElementAvailableAtDOM(ProjectsUI.addedMemberRemoveIcon, 1);
            _driver.SafeClick(ProjectsUI.addedMemberRemoveIcon);
        }

        //Verify the Remove Project Member Window
        public void VerifyRemoveMemberWindow()
        {
            _driver.WaitForElementAvailableAtDOM(ProjectsUI.removeMemberWindow, 1);
            _assertHelper.AssertElementDisplayed(ProjectsUI.removeMemberWindow);
        }

        //Verify the Remove Project Member Window No Button
        public void VerifyRemoveMemberNoBtn()
        {
            _driver.WaitForElementAvailableAtDOM(ProjectsUI.removeMemberNoBtn, 1);
            _assertHelper.AssertElementDisplayed(ProjectsUI.removeMemberNoBtn);
        }

        //Verify the Remove Project Member Window Yes Button
        public void VerifyRemoveMemberYesBtn()
        {
            _driver.WaitForElementAvailableAtDOM(ProjectsUI.removeMemberYesBtn, 1);
            _assertHelper.AssertElementDisplayed(ProjectsUI.removeMemberYesBtn);
        }

        //Press the Remove Project Member Window No Button
        public void PressRemoveMemberNoBtn()
        {
            _driver.WaitForElementAvailableAtDOM(ProjectsUI.removeMemberNoBtn, 1);
            _driver.SafeClick(ProjectsUI.removeMemberNoBtn);
        }

        //Press the Remove Project Member Window Yes Button
        public void PressRemoveMemberYesBtn()
        {
            _driver.WaitForElementAvailableAtDOM(ProjectsUI.removeMemberYesBtn, 1);
            _driver.SafeClick(ProjectsUI.removeMemberYesBtn);
        }

        //Assert Project Member is not deleted from the Project
        public void VerifyProjectMemberNameNotDeleted(String memberName)
        {
            _driver.WaitForElementAvailableAtDOM(ProjectsUI.VerifyProjectMemberName(memberName), 1);
            Console.WriteLine(ProjectsUI.VerifyProjectMemberName(memberName));
            _assertHelper.AssertElementDisplayed(ProjectsUI.VerifyProjectMemberName(memberName));
        }

        //Assert Project Member is deleted from the Project
        public void VerifyProjectMemberNameIsDeleted(String memberName)
        {
            _driver.WaitForElementAvailableAtDOM(ProjectsUI.VerifyProjectMemberName(memberName), 1);
            _assertHelper.AssertElementNotDisplayed(ProjectsUI.VerifyProjectMemberName(memberName));
        }

        //Assert the Project Name on the Projects Page
        public void VerifyProjectNameDashboard(String projectName)
        {
            _driver.WaitForElementAvailableAtDOM(ProjectsUI.VerifyProjectName(projectName), 1);
            _assertHelper.AssertElementDisplayed(ProjectsUI.VerifyProjectName(projectName));
        }

        //Edit Project Name
        public void EditProjectName(String editProjectName)
        {
            _driver.WaitForElementAvailableAtDOM(ProjectsUI.nameField, 1);
            _driver.SafeEnterText(ProjectsUI.nameField, editProjectName);
        }

        //Edit Start Date
        public void EditStartDate(String startDate)
        {
            _driver.WaitForElementAvailableAtDOM(ProjectsUI.startDate, 1);
            _driver.SafeEnterText(ProjectsUI.startDate, startDate);
        }

        //Edit Due Date
        public void EditDueDate(String dueDate)
        {
            _driver.WaitForElementAvailableAtDOM(ProjectsUI.dueDate, 1);
            _driver.SafeEnterText(ProjectsUI.dueDate, dueDate);
        }

        //Select Project Leader
        public void SelectOptionFromProjectOwner(String dropdwnoptn)
        {
            _driver.WaitForElementAvailableAtDOM(ProjectsUI.projectOwner, 1);
            _driver.SelectDropDownOption(dropdwnoptn, ProjectsUI.projectOwner);
        }

        //Assert the Name Required message 
        public void VerifyNameRequiredMsg()
        {
            _driver.WaitForElementAvailableAtDOM(ProjectsUI.nameRequired, 1);
            _assertHelper.AssertElementDisplayed(ProjectsUI.nameRequired);
        }

        //Assert the Description Required message
        public void VerifyDescRequiredMsg()
        {
            _driver.WaitForElementAvailableAtDOM(ProjectsUI.descRequired, 1);
            _assertHelper.AssertElementDisplayed(ProjectsUI.descRequired);
        }

        //Assert the error message when only Name left empty 
        public void VerifyNameEmptyMsg()
        {
            _driver.WaitForElementAvailableAtDOM(ProjectsUI.onlyNameEmptyMsg, 1);
            _assertHelper.AssertElementDisplayed(ProjectsUI.onlyNameEmptyMsg);
        }

        //Assert the error message when only Description left empty 
        public void VerifyDescEmptyMsg()
        {
            _driver.WaitForElementAvailableAtDOM(ProjectsUI.onlyDescEmptyMsg, 1);
            _assertHelper.AssertElementDisplayed(ProjectsUI.onlyDescEmptyMsg);
        }

        //Press the Add Project Window Close icon
        public void ClickAddProjectWindowCloseIcon()
        {
            _driver.SafeClick(ProjectsUI.createProjectCloseIcon);
        }

        /*Discussions Tab Testing under Projects Module*/
        //Press on Project's Discussion tab
        public void ClickProjectDiscussionTab()
        {
            _driver.WaitForElementAvailableAtDOM(ProjectsUI.discussionTab, 1);
            _driver.SafeClick(ProjectsUI.discussionTab);
        }

        //Assert the Discussions tab message div
        public void VerifyDiscussionsMsgDiv()
        {
            _driver.WaitForElementAvailableAtDOM(ProjectsUI.discussionMessageDiv, 1);
            _assertHelper.AssertElementDisplayed(ProjectsUI.discussionMessageDiv);
        }

        //Verify Add Member Icon on the Project Page
        public void VerifyDiscussionAddMemberIcon()
        {
            _driver.WaitForElementAvailableAtDOM(ProjectsUI.discussionAddMemberIcon, 1);
            _assertHelper.AssertElementDisplayed(ProjectsUI.discussionAddMemberIcon);
        }

        //Verify Share Project Icon on the Project Page
        public void VerifyDiscussionShareProjectIcon()
        {
            _driver.WaitForElementAvailableAtDOM(ProjectsUI.discussionShareProjectIcon, 1);
            _assertHelper.AssertElementDisplayed(ProjectsUI.discussionShareProjectIcon);
        }

        //Verify Delete Project Icon on the Project Page
        public void VerifyDiscussionDeleteProjectIcon()
        {
            _driver.WaitForElementAvailableAtDOM(ProjectsUI.discussionDeleteProjectIcon, 1);
            _assertHelper.AssertElementDisplayed(ProjectsUI.discussionDeleteProjectIcon);
        }

        //Click on Discussion tab Delete Project Icon
        public void ClickDiscussionDeleteProjectIcon()
        {
            _driver.SafeClick(ProjectsUI.discussionDeleteProjectIcon);
        }

        //Click the Message in the Text Area
        public void ClickMessageTextArea()
        {
            _driver.WaitForElementAvailableAtDOM(EventsUI.discussionTypeMessageArea, 1);
            _driver.ClickElementUsingAction(ProjectsUI.discussionTypeMessageArea);
        }

        //Enter the Message in the Text Area
        public void EnterMessageTextArea(String message)
        {
            _driver.WaitForElementAvailableAtDOM(ProjectsUI.discussionTypeMessageArea, 1);
            _driver.SafeEnterText(ProjectsUI.discussionTypeMessageArea, message);
        }

        //Press the Message Post button
        public void ClickMessagePostBtn()
        {
            _driver.WaitForElementAvailableAtDOM(ProjectsUI.discussionPostBtn, 1);
            _driver.SafeClick(GroupsUI.discussionPostBtn);
        }

        //Assert the Discussions tab Message Reply button
        public void VerifyDiscussionMsgReplyBtn()
        {
            _driver.WaitForElementAvailableAtDOM(ProjectsUI.discussionReplyBtn, 1);
            _assertHelper.AssertElementDisplayed(ProjectsUI.discussionReplyBtn);
        }

        //Press the Discussion Attachment Icon
        public void ClickDiscussionAttachIcon()
        {
            _driver.WaitForElementAvailableAtDOM(ProjectsUI.discussionAttachIcon, 1);
            _driver.SafeClick(ProjectsUI.discussionAttachIcon);
        }
        
        //Press View Team Status link
        public void ClickViewTeamStatus()
        {
            _driver.SafeClick(ProjectsUI.viewTeamStatus);
        }

        //Assert the Team member in the Project
        public void VerifyTeamMember(String teamMemberName)
        {
            _assertHelper.AssertElementDisplayed(ProjectsUI.VerifyProjectMemberName(teamMemberName));
        } 

        //Press Team Status Window Close icon
        public void ClickTeamStatusCloseIcon()
        {
            _driver.SafeClick(ProjectsUI.teamStatusCloseIcon);
        }

        //Assert Team member Type
        public void VerifyTeamMemberType()
        {
            _assertHelper.AssertElementTextContains(ProjectsUI.VerifyTeamStatusType, "Manual");
        }

        //Assert Team member Project Role
        public void VerifyTeamMemberProjectRole()
        {
            _assertHelper.AssertElementTextContains(ProjectsUI.VerifyTeamStatusProjectRole, "N/A");
        }

        //Assert Team member Type
        public void VerifyTeamMemberStatus()
        {
            _assertHelper.AssertElementTextContains(ProjectsUI.VerifyTeamStatus, "Added");
        }

        //Click Start Date field to open calendar
        public void ClickStartDateField()
        {
            _driver.SafeClick(ProjectsUI.startDate);
        }

        //Click todays date from calendar
        public void ClickTodaysDate()
        {
            _driver.SafeClick(ProjectsUI.todayDate);
        }


    }
}
