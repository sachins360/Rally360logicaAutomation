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
    public class PostProjectPage : BasePage
    {
        CommonMethods commonPage;

        public PostProjectPage(IWebDriver driver, int pageLoadTimeout)
            : base(driver, pageLoadTimeout)
        {
            commonPage = new CommonMethods(_driver, pageLoadTimeout);
        }

        //Click Create Project/Job button
        public void ClickCreateProjectJobBtn()
        {
            _driver.WaitForElementAvailableAtDOM(PostProjectUI.createProjectJobBtn, 1);
            _driver.SafeClick(PostProjectUI.createProjectJobBtn);
        }

        //Click New Project option
        public void ClickNewProject()
        {
            _driver.WaitForElementAvailableAtDOM(PostProjectUI.newProjectOption, 1);
            _driver.SafeClick(PostProjectUI.newProjectOption);
        }

        //Click Job Posting Project option
        public void ClickJobPosting()
        {
            _driver.WaitForElementAvailableAtDOM(PostProjectUI.jobPostingOption, 1);
            _driver.SafeClick(PostProjectUI.jobPostingOption);
        }

        //Verify Post a Project option
        public void VerifyPostProjectOption()
        {
            _assertHelper.AssertElementDisplayed(PostProjectUI.postAProjectTab);
        }

        //Click on Projects menu option
        public void ClickPostProject()
        {
            _driver.WaitForElementAvailableAtDOM(PostProjectUI.postAProjectTab, 1);
            _driver.SafeClick(PostProjectUI.postAProjectTab);
        }

        //Enter Project Name
        public void EnterProjectName(String projectName)
        {
            _driver.WaitForElementAvailableAtDOM(PostProjectUI.projectName, 1);
            _driver.SafeEnterText(PostProjectUI.projectName, projectName);
        }

        //Enter Project Description
        public void EnterProjectDescription(String projectDescription)
        {
            _driver.WaitForElementAvailableAtDOM(PostProjectUI.projectDesc, 1);
            _driver.EnterTextUsingAction(PostProjectUI.projectDesc, projectDescription);
        }

        //Enter Project Deliverables
        public void EnterProjectDeliverables(String projectDeliverables)
        {
            _driver.WaitForElementAvailableAtDOM(PostProjectUI.projectDelv, 1);
            _driver.EnterTextUsingAction(PostProjectUI.projectDelv, projectDeliverables);
        }

        //Select Project Category
        public void SelectProjectCategory(String projectCategory)
        {
            _driver.WaitForElementAvailableAtDOM(PostProjectUI.projectCategory, 1);
            _driver.SelectDropDownOption(projectCategory, PostProjectUI.projectCategory);
        }

        //Select Project Type
        public void SelectProjectType(String projectType)
        {
            _driver.WaitForElementAvailableAtDOM(PostProjectUI.projectType, 1);
            _driver.SelectDropDownOption(projectType, PostProjectUI.projectType);
        }

        //Click Startd Date field
        public void ClickStartDateField()
        {
            _driver.WaitForElementAvailableAtDOM(PostProjectUI.startDate, 1);
            _driver.SafeClick(PostProjectUI.startDate);
        }

        //Click Todays Date from Calender Icon
        public void ClickTodaysDate()
        {
            _driver.ClickElementUsingAction(PostProjectUI.todayDate);
        }

        //Click Ongoing checkbox
        public void ClickOngoingCheckbox()
        {
            _driver.SafeClick(PostProjectUI.ongoingCheckbox);
        }

        //Click Back button
        public void ClickBackBtn()
        {
            _driver.SafeClick(PostProjectUI.backBtn);
        }

        //Click Save Draft button
        public void ClickSaveDraftBtn()
        {
            _driver.SafeClick(PostProjectUI.saveDraftBtn);
        }

        //Click Continue button
        public void ClickContinueBtn()
        {
            _driver.SafeClick(PostProjectUI.continueBtn);
        }

        //Click Submit for  appraval button
        public void ClickSubmitForApprovalButton()
        {
            _driver.SafeClick(PostProjectUI.submitForApprovalBtn);
        }


        //Enter Skills Needed
        public void EnterSkillsNeeded(String skillsNeeded)
        {
            _driver.WaitForElementAvailableAtDOM(PostProjectUI.skillsNeeded, 1);
            _driver.SafeEnterText(PostProjectUI.skillsNeeded, skillsNeeded);
        }


        public void ClickMarketPlaceMenu()
        {
            _driver.SafeClick(PostProjectUI.marketPlaceMenu);
        }

        //Enter Project Location
        public void EnterProjectLocation(String projectLocation)
        {
            _driver.WaitForElementAvailableAtDOM(PostProjectUI.projectLocation, 1);
            _driver.SafeEnterText(PostProjectUI.projectLocation, projectLocation);
        }

        //Click Remote Checkbox
        public void ClickRemoteCheckbox()
        {
            _driver.SafeClick(PostProjectUI.remoteCheckbox);
        }

        //Click Onsite Checkbox
        public void ClickOnsiteCheckbox()
        {
            _driver.SafeClick(PostProjectUI.onsiteCheckbox);
        }

        //Select Staff
        public void SelectStaff(String staff)
        {
            _driver.WaitForElementAvailableAtDOM(PostProjectUI.staff, 1);
            _driver.SelectDropDownOption(staff, PostProjectUI.staff);
        }

        //Select Expected Time Commitment
        public void SelectExpectedTimeCommt(String expectedTimeCommt)
        {
            _driver.WaitForElementAvailableAtDOM(PostProjectUI.expectedTimeCommt, 1);
            _driver.SelectDropDownOption(expectedTimeCommt, PostProjectUI.expectedTimeCommt);
        }

        //Enter Members Needed
        public void EnterMembersNeeded(String noOfMembers)
        {
            _driver.WaitForElementAvailableAtDOM(PostProjectUI.membersNeeded, 1);
            _driver.SafeEnterText(PostProjectUI.membersNeeded, noOfMembers);
        }

        //Enter Member Name
        public void EnterMemberName(String memberName)
        {
            _driver.WaitForElementAvailableAtDOM(PostProjectUI.memberName, 1);
            _driver.SafeEnterText(PostProjectUI.memberName, memberName);
        }

        //Enter Vendor Name
        public void EnterVendorName(String vendorName)
        {
            _driver.WaitForElementAvailableAtDOM(PostProjectUI.vendorName, 1);
            _driver.SafeEnterText(PostProjectUI.vendorName, vendorName);
        }

        //Click Add button
        public void ClickAddBtn()
        {
            _driver.SafeClick(PostProjectUI.addBtn);
        }

        //Click Add button
        public void ClickProjectAddBtn()
        {
            _driver.SafeClick(PostProjectUI.addProjectBtn);
        }

        //Click Add Vendor button
        public void ClickAddVendorBtn()
        {
            _driver.ClickUsingSendKeys(PostProjectUI.addBtn);
        }

        //Click Publish button
        public void ClickPublishBtn()
        {
            _driver.SafeClick(PostProjectUI.publishBtn);
        }
        //Click Private project radio button
        public void ClickPrivateProjectRdoBtn()
        {
            _driver.SafeClick(PostProjectUI.privateRdoBtn);
        }

        //Verify the About tab on Projects Page
        public void VerifyAboutTabOnPage()
        {
            _assertHelper.AssertElementDisplayed(PostProjectUI.aboutTab);
        }

        //Verify Recruit Tag on about page for admin
        public void VerifyRecruitLinkOnAboutPage()
        {
            _assertHelper.AssertElementDisplayed(PostProjectUI.Recruiting);
        }
        //Verify Pending tag on about page for admin
        public void VerifyPendingTagOnAboutPage()
        {
            _assertHelper.AssertElementDisplayed(PostProjectUI.Pending);
        }


        //Click Approve button on about page for admin
        public void clickApproveButtonOnAboutPage()
        {
            _driver.SafeClick(PostProjectUI.approveBtn);            
        }

        //Verify Deny button on about page for admin
        public void ClickDenyButtonOnAboutPage()
        {
            _driver.SafeClick(PostProjectUI.denyButton);
        }

        //Verify Approve button on about page for admin
        public void VerifyApproveButtonOnAboutPage()
        {
            _assertHelper.AssertElementDisplayed(PostProjectUI.approveBtn);
        }

        //Verify Deny button on about page for admin
        public void VerifyDenyButtonOnAboutPage()
        {
            _assertHelper.AssertElementDisplayed(PostProjectUI.denyButton);
        }


        //Verify the Project Draft Status in the Marketplace
        public void VerifyProjectDraftStatusMarketplace()
        {
            _assertHelper.AssertElementDisplayed(MarketPlaceUI.projectDraftStatus);
        }

        //Verify the Project Name on About page
        public void VerifyProjectName(string projectName)
        {
            _assertHelper.AssertElementDisplayed(PostProjectUI.aboutProjectName(projectName));
        }

        //Verify the Project Description on About page
        public void VerifyProjectDesc(string projectDesc)
        {
            _assertHelper.AssertElementDisplayed(PostProjectUI.aboutProjectDesc(projectDesc));
        }

        //Verify the Project Deliverables on About page
        public void VerifyProjectDelv(string projectDelv)
        {
            _assertHelper.AssertElementDisplayed(PostProjectUI.aboutProjectDelv(projectDelv));
        }

        //Verify the Project Skills on About page
        public void VerifyProjectSkills(string skills)
        {
            _assertHelper.AssertElementDisplayed(PostProjectUI.aboutProjectSkills(skills));
        }

        //Verify the Project Type on About page
        public void VerifyProjectType(string type)
        {
            _assertHelper.AssertElementDisplayed(PostProjectUI.aboutProjectType(type));
        }

        //Verify the Project Location on About page
        public void VerifyProjectLocation(string location)
        {
            _assertHelper.AssertElementDisplayed(PostProjectUI.aboutProjectLocation(location));
        }

        //Verify the Project Staff on About page
        public void VerifyProjectStaffOnsite()
        {
            _assertHelper.AssertElementDisplayed(PostProjectUI.aboutProjectStaffingOnsite());
        }

        //Verify the Project Staff on About page
        public void VerifyProjectStaffRemote()
        {
            _assertHelper.AssertElementDisplayed(PostProjectUI.aboutProjectStaffingRemote());
        }

        //Verify the Project Category on About page
        public void VerifyProjectCategory(string category)
        {
            _assertHelper.AssertElementDisplayed(PostProjectUI.aboutProjectCategory(category));
        }

        //Verify the Project Hours on About page
        public void VerifyProjectHours(string hours)
        {
            _assertHelper.AssertElementDisplayed(PostProjectUI.aboutProjectType(hours));
        }

        //Verify Member Name on About Page
        public void VerifyMemberName(String memberName)
        {
            _assertHelper.AssertElementDisplayed(PostProjectUI.aboutMemberName(memberName));
        }

       

        //Verify Member Name on About Page
        public void VerifyMemberNameNotDisplayed(String memberName)
        {
            _assertHelper.AssertElementNotDisplayed(PostProjectUI.aboutMemberName(memberName));
        }

        //Click Settings Icon
        public void ClickSettingsIcon()
        {
            _driver.CheckElementClickable(PostProjectUI.projectSettings);
            _driver.SafeClick(PostProjectUI.projectSettings);
        }

        //Select Project Option
        public void SelectProjectOption(string option)
        {
            _driver.SafeClick(PostProjectUI.projectSettingsOptions(option));
        }

        //Verify General Tab
        public void VerifyGeneralTab()
        {
            _assertHelper.AssertElementDisplayed(PostProjectUI.generalTab);
        }

        //Verify Staffing Info Tab
        public void VerifyStaffingInfoTab()
        {
            _assertHelper.AssertElementDisplayed(PostProjectUI.staffingInfoTab);
        }

        //Click Staffing Info Tab
        public void ClickStaffingInfoTab()
        {
            _driver.SafeClick(PostProjectUI.staffingInfoTab);
        }

        //Click Save Button
        public void ClickSaveBtn()
        {
            _driver.SafeClick(PostProjectUI.saveBtn);
        }

        //Click Remove Member Icon
        public void ClickRemoveMemberIcon()
        {
            _driver.SafeClick(PostProjectUI.removeMemberIcon);
        }

        //Verify Member Name Not Exists on About Page
        public void VerifyMemberNotExists(String memberName)
        {
            _assertHelper.AssertElementNotDisplayed(PostProjectUI.aboutMemberName(memberName));
        }

        //Click Manage Team Save Button
        public void ClickManageTeamSaveBtn()
        {
            _driver.ClickElementUsingJS(PostProjectUI.manageTeamSaveBtn);
        }

        //Press Mark Complete button on Project About Page
        public void ClickMarkCompleteBtn()
        {
            _driver.CheckElementVisibility(PostProjectUI.aboutProjectMarkCompleteBtn);
            _driver.CheckElementClickable(PostProjectUI.aboutProjectMarkCompleteBtn);
            _driver.ClickElementUsingAction(PostProjectUI.aboutProjectMarkCompleteBtn);
        }

        //Select Awesome Rating User1
        public void SelectAwesomeRatingUserOne()
        {
            _driver.CheckElementVisibility(PostProjectUI.markCompleteAwesomeMember1);
            _driver.CheckElementClickable(PostProjectUI.markCompleteAwesomeMember1);
            _driver.SafeClick(PostProjectUI.markCompleteAwesomeMember1);
        }

        //Select Awesome Rating User2
        public void SelectAwesomeRatingUserTwo()
        {
            _driver.CheckElementVisibility(PostProjectUI.markCompleteAwesomeMember2);
            _driver.CheckElementClickable(PostProjectUI.markCompleteAwesomeMember2);
            _driver.SafeClick(PostProjectUI.markCompleteAwesomeMember2);
        }

        //Press Complete Project button
        public void ClickCompleteProjectBtn()
        {
            _driver.SafeClick(PostProjectUI.CompleteProjectBtn);
        }
        public void ClickSidePointonCompleteProjectBtn()
        {
            _driver.SafeClick(PostProjectUI.CompleteProjectPointBtn);
        }

        //Verify the Update Metrics Button
        public void VerifyUpdateMetricsBtn()
        {
            _assertHelper.AssertElementDisplayed(PostProjectUI.aboutProjectUpdateMetricsBtn);
        }

        //Verify the Completed Status on About Page
        public void VerifyCompletedStatus()
        {
            _assertHelper.AssertElementDisplayed(PostProjectUI.aboutProjectCompletedStatus);
        }

        //Verify the In Progress Status on About Page
        public void VerifyInProgressStatus()
        {
            _assertHelper.AssertElementDisplayed(PostProjectUI.aboutProjectInProgressStatus);
        }

        //Verify the Closed Status on About Page
        public void VerifyClosedStatus()
        {
            _assertHelper.AssertElementDisplayed(PostProjectUI.aboutProjectClosedStatus);
        }

        //Press Yes Button from the Delete Project Window
        public void PressDeleteProjectWindowYesBtn()
        {
            _driver.SafeClick(PostProjectUI.deleteProjectWindowYesBtn);
        }

        //Select Project Status
        public void SelectProjectStatus(string status)
        {
            _driver.VerifyDropDownOption(PostProjectUI.projectStatusDropDownOption(status));
            _driver.SelectDropDownOption(status, PostProjectUI.projectStatusDropDown);
        }

        //Select Project Owner
        public void SelectProjectOwner(string owner)
        {
            _driver.SelectDropDownOption(owner, PostProjectUI.projectOwnerDropDown);
        }

        //Enter Project Name in Search field
        public void SearchProjectName(String projectName)
        {
            _driver.CheckElementVisibility(MarketPlaceUI.searchText);
            _driver.SafeEnterText(MarketPlaceUI.searchText, projectName);
        }

        //Press Search button
        public void ClickSearchBtn()
        {
            _driver.SafeClick(MarketPlaceUI.searchBtn);
        }

        //Click the Project on Projects Page
        public void ClickProjectNameOnPage(String projectName)
        {
            _driver.CheckElementClickable(MarketPlaceUI.ProjectNameOnPage(projectName));
            _driver.ClickElementUsingJS(MarketPlaceUI.ProjectNameOnPage(projectName));
        }

        public void ClickRecProjectNameOnPage(String projectName)
        {
            _driver.ClickElementUsingJS(MarketPlaceUI.ProjectNameOnPage(projectName));
        }
        //Click the Project on Projects Page
        public void ClickRemoveFromProject()
        {
            _driver.SafeClick(PostProjectUI.removeProjectButton);
        }

        //Press Request To Join button
        public void ClickRequestToJoinBtn()
        {
            _driver.SafeClick(PostProjectUI.requestToJoinBtn);
        }

        //Verify Request To Join button
        public void AssertRequestToJoinBtn()
        {
            _assertHelper.AssertElementDisplayed(PostProjectUI.requestToJoinBtn);
        }

        //Verify Requested button
        public void AsssertRequestSentBtn()
        {
            _assertHelper.AssertElementDisplayed(PostProjectUI.requestedBtn);
        }

        //Click Requested User Accept Icon
        public void RequestedUserAcceptIcon()
        {
            _driver.ClickElementUsingJS(PostProjectUI.manageTeamAcceptIcon);
        }

        //Click Requested User Reject Icon
        public void RequestedUserRejectIcon()
        {
            _driver.SafeClick(PostProjectUI.manageTeamRejectIcon);
        }

        //Select Private Radio option
        public void ClickPrivateRadioOption()
        {
            _driver.SafeClick(PostProjectUI.privateRadio);
        }

        //Verify Private icon for Private Project
        public void AssertPrivateIcon()
        {
            _assertHelper.AssertElementDisplayed(PostProjectUI.privateProjectIcon);
        }

        //Click Private icon for Private Project
        public void ClickPrivateIcon()
        {
            _driver.SafeClick(PostProjectUI.privateProjectIcon);
        }

        //Click Promote button
        public void ClickPromoteBtn()
        {
            _driver.ClickElementUsingJS(PostProjectUI.promoteBtn);
        }

        //Verify Promote Project Success Message
        public void VerifyPromoteProjectSuccessMsg()
        {
            _assertHelper.AssertElementDisplayed(PostProjectUI.promoteSuccessMsg);
        }

        //Click the Go Rally Button
        public void ClickGORallyButton()
        {
            _driver.SafeClick(PostProjectUI.goRallyButton);
        }

        //Verify join project button
        public void VerifyJoinProjectButton()
        {
            _assertHelper.AssertElementDisplayed(PostProjectUI.joinProjectButton);
        }

        //Verify Project tabs
        public void VerifyProjectTabs(String tabName)
        {
            int count = getTabIndex(tabName);
            _assertHelper.AssertElementDisplayed(PostProjectUI.projectTabName(count, tabName));
        }


        public int getTabIndex(string tabName)
        {
            switch (tabName)
            {
                case "Discussions":
                    return 2;
                case "Tasks":
                    return 3;
                case "Files":
                    return 4;
                default:
                    return 0;
            }
        }






















































































        //Verify the Suggested Member Name
        public void VerifySuggestedMemberName(String suggestedMemberName)
        {
            _assertHelper.AssertElementDisplayed(PostProjectUI.suggestedMemberName(suggestedMemberName));
        }



        //Press Complete Project window
        public void ClickCompleteProjectWindow()
        {
            _driver.SafeClick(ProjectsUI.completeProjectWindow);
        }



        //Select Closed option from All Projects Dropdown
        public void SelectAllProjectsClosed()
        {
            _driver.WaitForElementAvailableAtDOM(ProjectsUI.ProjTypeClosed, 1);
            _driver.ClickElementUsingAction(ProjectsUI.ProjTypeClosed);
        }

        //Click on Delete Project Icon
        public void ClickDeleteProjectIcon()
        {
            _driver.ClickElementUsingJS(PostProjectUI.deleteProjectIcon);
        }



        //Select a value from Stratus dropdown
        public void SelectStatusDropDown(String option)
        {
            _driver.SelectDropDownOption(option, ProjectsUI.statusDropDown);
        }

        //Click Stratus dropdown
        public void ClickStatusDropDown()
        {
            _driver.WaitForElementAvailableAtDOM(ProjectsUI.statusDropDown, 1);
            _driver.SafeClick(ProjectsUI.statusDropDown);
        }

        //Edit Project Name
        public void EditProjectName(String editProjectName)
        {
            _driver.WaitForElementAvailableAtDOM(ProjectsUI.nameField, 1);
            _driver.SafeEnterText(ProjectsUI.nameField, editProjectName);
        }

        //Select Project Leader
        public void SelectOptionFromProjectOwner(String dropdwnoptn)
        {
            _driver.WaitForElementAvailableAtDOM(ProjectsUI.projectOwner, 1);
            _driver.SafeSelectDropDownText(ProjectsUI.projectOwner, dropdwnoptn);
        }

        //Press the Add Member Icon for Project
        public void ClickAddMemberIcon()
        {
            _driver.WaitForElementAvailableAtDOM(ProjectsUI.addMemberIcon, 1);
            _driver.SafeClick(ProjectsUI.addMemberIcon);
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
            _driver.WaitForElementAvailableAtDOM(PostProjectUI.addMemberSuggList(SuggItem), 1);
            _driver.SafeClick(PostProjectUI.addMemberSuggList(SuggItem));
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
            _driver.WaitForElementAvailableAtDOM(PostProjectUI.addedMemberRemoveIcon, 1);
            _driver.ClickElementUsingJS(PostProjectUI.addedMemberRemoveIcon);
        }

        //Press the Remove Project Member Window Yes Button
        public void PressRemoveMemberYesBtn()
        {
            _driver.WaitForElementAvailableAtDOM(ProjectsUI.removeMemberYesBtn, 1);
            _driver.SafeClick(ProjectsUI.removeMemberYesBtn);
        }

        //Assert Project Member is deleted from the Project
        public void VerifyProjectMemberNameIsDeleted(String memberName)
        {
            _driver.WaitForElementAvailableAtDOM(ProjectsUI.VerifyProjectMemberName(memberName), 1);
            _assertHelper.AssertElementNotDisplayed(ProjectsUI.VerifyProjectMemberName(memberName));
        }


        //Click Private Project checkbox
        public void ClickPrivateProjectCheckBox()
        {
            _driver.SafeClick(PostProjectUI.privateProjectCheckbox);
        }

        //Verify Project is not displayed message
        public void AssertProjectNotDisplayedMsg()
        {
            _assertHelper.AssertElementDisplayed(PostProjectUI.nothingDisplayedMsg);
        }

        //Press on Project's Discussion tab
        public void ClickDiscussionTab()
        {
            _driver.SafeClick(ProjectsUI.discussionTab);
        }

        //Click the Message in the Text Area
        public void ClickMessageTextArea()
        {
            _driver.ClickElementUsingAction(ProjectsUI.discussionTypeMessageArea);
        }

        //Enter the Message in the Text Area
        public void EnterMessageTextArea(String message)
        {
            // _driver.SafeClick(ProjectsUI.discussionTypeMessageArea);
            _driver.SafeEnterText(ProjectsUI.discussionTypeMessageArea, message);
        }

        //Press the Message Post button
        public void ClickMessagePostBtn()
        {
            _driver.SafeClick(PostProjectUI.discussionPostBtn);
        }

        //Click the Project on Projects Page
        public void ClickAboutPageLeaveProjectBtn()
        {
            _driver.SafeClick(PostProjectUI.aboutProjectleaveProjectBtn);
        }
    }
}
