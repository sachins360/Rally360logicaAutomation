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
    public class DirectoryPage : BasePage
    {
        CommonMethods commonPage;

        public DirectoryPage(IWebDriver driver, int pageLoadTimeout)
            : base(driver, pageLoadTimeout)
        {
            commonPage = new CommonMethods(_driver, pageLoadTimeout);
        }

        //Click User Profile Icon
        public void ClickUserProfileIcon()
        {
            _driver.ClickElementUsingAction(DashboardUI.userIcon);
        }

        //Click Request Feedback button
        public void ClickRequestFeedbackBtn()
        {
            _driver.SafeClick(DirectoryUI.requestFeedbackBtn);
        }

        //Select Request Feedback Project
        public void SelectRequestFeedbackProject(String projectName)
        {
            _driver.SafeSelectDropDownText(DirectoryUI.requestFeedbackProject, projectName);
        }

        //Click the Endorse button
        public void ClickEndorseBtn()
        {
            _driver.SafeClick(DirectoryUI.endorseBtn);
        }

        //Select Project DropDown
        public void SelectProjectDropDown(String projectName)
        {
            _driver.SelectDropDownOption(projectName, DirectoryUI.projectDropDown);
        }

        //Click the Awesome rating
        public void ClickAwesomeRating()
        {
            _driver.SafeClick(DirectoryUI.awesome);
        }

        //Click the Goog rating
        public void ClickGoodRating()
        {
            _driver.SafeClick(DirectoryUI.good);
        }

        //Click the Not Good rating
        public void ClickNotGoodRating()
        {
            _driver.SafeClick(DirectoryUI.notGood);
        }

        //Enter Feedback
        public void EnterFeedback(String feedback)
        {
            _driver.SafeEnterText(DirectoryUI.projectFeedback, feedback);
        }

        //Click the Endorse User button
        public void ClickEndorseUserBtn()
        {
            _driver.SafeClick(DirectoryUI.endorseUserBtn);
        }

        //Click Send button
        public void ClickSendBtnForFeedback()
        {
            _driver.SafeClick(DirectoryUI.sendBtn);
        }

        //Click User Profile option
        public void ClickUserProfileOptions(String variable)
        {
            _driver.SafeClick(DashboardUI.UserIconOptions(variable));
        }






        //Click on Direcotry Tab
        public void ClickDirectoryTab()
        {
            _driver.SafeClick(DirectoryUI.directoryTab);
        }

        //Assert Search text box
        public void VerifySearchBox()
        {
            _assertHelper.AssertElementDisplayed(DirectoryUI.searchDirectoryBox);
        }
        
        //Enter Search text box
        public void EnterSearchBox(String search)
        {
            _driver.WaitForElementAvailableAtDOM(DirectoryUI.searchDirectoryBox, 1);
            _driver.SafeEnterText(DirectoryUI.searchDirectoryBox, search);
        }

        //Assert Search Button
        public void VerifySearchBtn()
        {
            _assertHelper.AssertElementDisplayed(DirectoryUI.searchBtn);
        }

        //Click Search Button
        public void ClickSearchBtn()
        {
            _driver.WaitForElementAvailableAtDOM(DirectoryUI.searchBtn, 1);
            _driver.SafeClick(DirectoryUI.searchBtn);
        }

        //Assert Reset Button
        public void VerifyResetBtn()
        {
            _assertHelper.AssertElementDisplayed(DirectoryUI.resetBtn);
        }

        //Click Reset Button
        public void ClickResetBtn()
        {
            _driver.WaitForElementAvailableAtDOM(DirectoryUI.resetBtn, 1);
            _driver.SafeClick(DirectoryUI.resetBtn);
        }

        //Click Vendors Tab
        public void ClickVendorsTab()
        {
            _driver.WaitForElementAvailableAtDOM(DirectoryUI.vendorsTab, 1);
            _driver.SafeClick(DirectoryUI.vendorsTab);
        }

        //Click People Tab
        public void ClickPeopleTab()
        {
            _driver.WaitForElementAvailableAtDOM(DirectoryUI.peopleTab, 1);
            _driver.SafeClick(DirectoryUI.peopleTab);
        }

        //Assert Talent Pool filter
        public void VerifyTalentPoolFilter()
        {
            _assertHelper.AssertElementDisplayed(DirectoryUI.talentPoolFilter);
        }

        //Select Talent Pool filter
        public void SelectTalentPoolFilter(String option)
        {
            _driver.WaitForElementAvailableAtDOM(DirectoryUI.talentPoolFilter, 1);
            _driver.SelectDropDownOption(option, DirectoryUI.talentPoolFilter);
        }

        //Assert Roles filter
        public void VerifyRolesFilter()
        {
            _assertHelper.AssertElementDisplayed(DirectoryUI.rolesFilter);
        }

        //Select Roles filter
        public void SelectRolesFilter(String option)
        {
            _driver.WaitForElementAvailableAtDOM(DirectoryUI.rolesFilter, 1);
            _driver.SelectDropDownOption(option, DirectoryUI.rolesFilter);
        }

        //Assert Available For filter
        public void VerifyAvailableForFilter()
        {
            _assertHelper.AssertElementDisplayed(DirectoryUI.availableForFilter);
        }

        //Select Available For filter
        public void SelectAvailableForFilter(String option)
        {
            _driver.WaitForElementAvailableAtDOM(DirectoryUI.availableForFilter, 1);
            _driver.SelectDropDownOption(option, DirectoryUI.availableForFilter);
        }

        //Assert Location filter
        public void VerifyLocationFilter()
        {
            _assertHelper.AssertElementDisplayed(DirectoryUI.locationFilter);
        }

        //Enter Location filter
        public void EnterLocationFilter(String option)
        {
            _driver.WaitForElementAvailableAtDOM(DirectoryUI.locationFilter, 1);
            _driver.SafeEnterText(DirectoryUI.locationFilter, option);            
        }

        //Assert Endorsed By filter
        public void VerifyEndorsedByFilter()
        {
            _assertHelper.AssertElementDisplayed(DirectoryUI.endorsedByFilter);
        }

        //Enter Endorsed By filter
        public void EnterEndorsedByFilter(String option)
        {
            _driver.WaitForElementAvailableAtDOM(DirectoryUI.endorsedByFilter, 1);
            _driver.SafeEnterText(DirectoryUI.endorsedByFilter, option);
        }

        //Assert Vendor Location filter
        public void VerifyVendorLocationFilter()
        {
            _assertHelper.AssertElementDisplayed(DirectoryUI.locationVendorFilter);
        }

        //Enter Vendor Location filter
        public void EnterVendorLocationFilter(String option)
        {
            _driver.WaitForElementAvailableAtDOM(DirectoryUI.locationVendorFilter, 1);
            _driver.SafeEnterText(DirectoryUI.locationVendorFilter, option);
        }

        //Assert User Name search is displayed
        public void VerifyUserContainerUserName(String userName)
        {
            _assertHelper.AssertElementDisplayed(DirectoryUI.userContainerUserName(userName));
        }

        //Click User Name search is displayed
        public void ClickUserContainerUserName(String userName)
        {
            _driver.SafeClick(DirectoryUI.userContainerUserName(userName));
        }

        //Assert Role Name search is displayed
        public void VerifyUserContainerRoleName(String roleName)
        {
            _assertHelper.AssertElementDisplayed(DirectoryUI.userContainerRoleName(roleName));
        }

        //Assert Initials is displayed
        public void VerifyUserContainerInitials(String initials)
        {
            _assertHelper.AssertElementDisplayed(DirectoryUI.userContainerInitials(initials));
        }

        //Assert Title is displayed
        public void VerifyUserContainerTitle(String title)
        {
            _assertHelper.AssertElementDisplayed(DirectoryUI.userContainerTitle(title));
        }

        //Assert Location is displayed
        public void VerifyUserContainerLocation(String location)
        {
            _assertHelper.AssertElementDisplayed(DirectoryUI.userContainerLocation(location));
        }

        //Assert Availability is displayed
        public void VerifyUserContainerAvailability(String availability)
        {
            _assertHelper.AssertElementDisplayed(DirectoryUI.userContainerAvailability(availability));
        }

        //Assert Skills is displayed
        public void VerifyUserContainerSkills(String skills)
        {
            _assertHelper.AssertElementDisplayed(DirectoryUI.userContainerSkills(skills));
        }

        //Assert Message link is displayed
        public void VerifyUserContainerMessage()
        {
            _assertHelper.AssertElementDisplayed(DirectoryUI.userContainerMessage);
        }

        //Click Message link
        public void ClickUserContainerMessage()
        {
            _driver.SafeClick(DirectoryUI.userContainerMessage);
        }

        //Assert Message Confirmation
        public void VerifyUserConfirmationMessage()
        {
            _assertHelper.AssertElementDisplayed(DirectoryUI.messageConfirmation);
        }

        //Click Back to search results
        public void ClickBackToSearchResults()
        {
            _driver.SafeClick(DirectoryUI.backToSearchResults);
        }

        //Assert Empty Result Page
        public void VerifyEmptyPageMessage()
        {
            _assertHelper.AssertElementDisplayed(DirectoryUI.emptyResult);
        }

        //Assert Vendor Name search is displayed
        public void VerifyVendorContainerVendorName(String vendorName)
        {
            _assertHelper.AssertElementDisplayed(DirectoryUI.vendorContainerVendorName(vendorName));
        }

        //Click Add Talent Pool Icon
        public void ClickAddTalentPoolIcom()
        {
            _driver.SafeClick(DirectoryUI.talentPoolPlusIcon);
        }

        //Enter Talent Pool Skills
        public void EnterSkillsTalentPool(String option)
        {
            _driver.WaitForElementAvailableAtDOM(DirectoryUI.skillsTalentPool, 1);
            _driver.SafeEnterText(DirectoryUI.skillsTalentPool, option);
        }

        //Enter Talent Pool Languages
        public void EnterLanguagesTalentPool(String option)
        {
            _driver.WaitForElementAvailableAtDOM(DirectoryUI.languagesTalentPool, 1);
            _driver.SafeEnterText(DirectoryUI.languagesTalentPool, option);
        }

        //Enter Talent Pool Skills
        public void EnterSkillsToDevelopTalentPool(String option)
        {
            _driver.WaitForElementAvailableAtDOM(DirectoryUI.skillsToDevelopTalentPool, 1);
            _driver.SafeEnterText(DirectoryUI.skillsToDevelopTalentPool, option);
        }

        //Enter Talent Pool Location
        public void EnterLocationTalentPool(String option)
        {
            _driver.WaitForElementAvailableAtDOM(DirectoryUI.locationTalentPool, 1);
            _driver.SafeEnterText(DirectoryUI.locationTalentPool, option);
        }

        //Enter Talent Pool Department
        public void EnterDepartmentTalentPool(String option)
        {
            _driver.WaitForElementAvailableAtDOM(DirectoryUI.departmentTalentPool, 1);
            _driver.SafeEnterText(DirectoryUI.departmentTalentPool, option);
        }

        //Enter  Title
        public void EnterTitleTalentPool(String option)
        {
            _driver.WaitForElementAvailableAtDOM(DirectoryUI.titleTalentPool, 1);
            _driver.SafeEnterText(DirectoryUI.titleTalentPool, option);
        }

        //Select Talent Pool Roles
        public void SelectRolesTalentPool(String option)
        {
            _driver.WaitForElementAvailableAtDOM(DirectoryUI.rolesTalentPool, 1);
            _driver.SelectDropDownOption(option, DirectoryUI.rolesTalentPool);
        }

        //Select Talent Pool Available For 
        public void SelectAvailableForTalentPool(String option)
        {
            _driver.WaitForElementAvailableAtDOM(DirectoryUI.availableForTalentPool, 1);
            _driver.SelectDropDownOption(option, DirectoryUI.availableForTalentPool);
        }

        //Enter Talent Pool Name
        public void EnterTalentPoolName(String option)
        {
            _driver.SafeEnterText(DirectoryUI.nameTalentPool, option);
        }

        //Enter Talent Pool Save button
        public void ClickTalentPoolSaveBtn()
        {
            _driver.SafeClick(DirectoryUI.saveBtnTalentPool);
        }

        //Assert Talent Pool is displayed in Talent Pool drop-down
        public void VerifyTalentPoolDisplayed(String option)
        {
            _assertHelper.AssertElementDisplayed(DirectoryUI.talentPoolFilterOption(option));
        }

        //Assert Talent Pool not displayed in Talent Pool drop-down
        public void VerifyTalentPoolNotDisplayed(String option)
        {
            _assertHelper.AssertElementNotDisplayed(DirectoryUI.talentPoolFilterOption(option));
        }

        //Enter Skills text box
        public void EnterSkillsBox(String search)
        {
            _driver.WaitForElementAvailableAtDOM(DirectoryUI.skillsTalentPool, 1);
            _driver.SafeEnterText(DirectoryUI.skillsTalentPool, search);
        }

        //Click Private talent Pool Check-box
        public void ClickPrivateTalentPool()
        {
            _driver.WaitForElementAvailableAtDOM(DirectoryUI.privateTalentPool, 1);
            _driver.SafeClick(DirectoryUI.privateTalentPool);
        }
































        /*

        //Enter Browse Search 
        public void EnterBrowseSearch(String search)
        {
            _driver.WaitForElementAvailableAtDOM(DirectoryUI.browseSearch, 1);
            _driver.SafeEnterText(DirectoryUI.browseSearch, search);
        }

        //Click Span Search button
        public void ClickSpanSearch()
        {
            _driver.SafeClick(DirectoryUI.spanSearchBtn);
        }

        //Assert the user container displayed
        public void VerifyUserContainer()
        {
            _assertHelper.AssertElementDisplayed(DirectoryUI.userContainer);
        }

        //Move to user container
        public void MoveToUserContainer()
        {
            _driver.MoveToElementUsingAction(DirectoryUI.userContainer);
        }

        //Assert the Message button
        public void VerifyMessageBtn()
        {
            _assertHelper.AssertElementDisplayed(DirectoryUI.messageBtn);
        }

        //Assert the Message button not displayed
        public void VerifyMessageBtnNotDisplayed()
        {
            _assertHelper.AssertElementNotDisplayed(DirectoryUI.messageBtn);
        }

        //Press the Message button
        public void ClickMessageBtn()
        {
            _driver.SafeClick(DirectoryUI.messageBtn);
        }

        //Assert the View Profile button
        public void VerifyViewProfileBtn()
        {
            _assertHelper.AssertElementDisplayed(DirectoryUI.viewProfileBtn);
        }

        //Assert the Send Message Window non external storm
        public void VerifySendMessageWindow()
        {
            _assertHelper.AssertElementDisplayed(DirectoryUI.sendMsgWindowOld);
        }

        //Assert the New Message Window
        public void VerifyNewMessageWindow()
        {
            _assertHelper.AssertElementDisplayed(DirectoryUI.newMessageWindow);
        }

        //Enter message in text area
        public void EnterMessage(String message)
        {
            _driver.SafeEnterText(DirectoryUI.msgTextAera, message);
        }

        //Press the Send button
        public void ClickSendBtn()
        {
            _driver.SafeClick(DirectoryUI.sendMessageBtn);
        }

        //Assert the New Message Window button
        public void VerifyMessagConversationWindow()
        {
            _assertHelper.AssertElementDisplayed(DirectoryUI.messageConversationWindow);
        }

        //Assert the Message Posted
        public void VerifyNewMessagwPosted(String message)
        {
            _assertHelper.AssertElementDisplayed(DirectoryUI.messagePosted(message));
        }

        //Press the View Profile button
        public void ClickViewProfileBtn()
        {
            _driver.SafeClick(PeopleUI.viewProfileBtn);
        }

        //Assert the User Profile User Name
        public void VerifyUserName(String userName)
        {
            _assertHelper.AssertElementDisplayed(PeopleUI.userName(userName));
        }

        //Assert the User Profile Messag button
        public void VerifyUserProfileMessageBtn()
        {
            _assertHelper.AssertElementDisplayed(PeopleUI.userProfileMessageBtn);
        }

        //Assert the User Profile About Me
        public void VerifyAboutMe()
        {
            _assertHelper.AssertElementDisplayed(PeopleUI.aboutMe);
        }

        //Assert the User Profile Skills & Endorsements
        public void VerifySkillsEndorsements()
        {
            _assertHelper.AssertElementDisplayed(PeopleUI.skillsANdEndorsements);
        }

        //Assert the User Profile Industry/Domain Expertise
        public void VerifyIndustryDomainExpertise()
        {
            _assertHelper.AssertElementDisplayed(PeopleUI.industryDomain);
        }

        //Assert the User Profile Languages
        public void VerifyLanguages()
        {
            _assertHelper.AssertElementDisplayed(PeopleUI.languages);
        }

        //Assert the User Profile Interests
        public void VerifyDevelopmentSkills()
        {
            _assertHelper.AssertElementDisplayed(PeopleUI.developmentSkills);
        }

        //Assert the User Profile Projects
        public void VerifyProjects()
        {
            _assertHelper.AssertElementDisplayed(PeopleUI.projects);
        }

        //Click Adcance search link
        public void ClickAdvanceSearchLink()
        {
            _driver.SafeClick(PeopleUI.advanceLink);
        }

        //Click Adcance search link on the main page
        public void ClickAdvanceSearchMainPage()
        {
            _driver.SafeClick(PeopleUI.browseAdvanceLink);
        }

        //Assert the Advance Search Name
        public void VerifyName()
        {
            _assertHelper.AssertElementDisplayed(PeopleUI.name);
        }

        //Enter the Advance Search Name
        public void EnterAdvanceSearchName(String name)
        {
            _driver.SafeEnterText(PeopleUI.name, name);
        }

        //Assert the Advance Search Skills Needed
        public void VerifySkillsNeeded()
        {
            _assertHelper.AssertElementDisplayed(PeopleUI.skillsNeeded);
        }

        //Assert the Advance Search Job Function
        public void VerifyJobFunction()
        {
            _assertHelper.AssertElementDisplayed(PeopleUI.jobFunction);
        }

        //Assert the Advance Search Location
        public void VerifyLocation()
        {
            _assertHelper.AssertElementDisplayed(PeopleUI.location);
        }

        //Assert the Advance Search Industry/Domain Expertise
        public void VerifyAdvSearchIndustryDomainExpertise()
        {
            _assertHelper.AssertElementDisplayed(PeopleUI.advSearchIndustryDomain);
        }

        //Assert the Advance Search Endorsed By
        public void VerifyEndorsedBy()
        {
            _assertHelper.AssertElementDisplayed(PeopleUI.endorsedBy);
        }

        //Assert the Advance Search Availability
        public void VerifyAvailability()
        {
            _assertHelper.AssertElementDisplayed(PeopleUI.availability);
        }

        //Assert the Advance Search Type
        public void VerifyType()
        {
            _assertHelper.AssertElementDisplayed(PeopleUI.type);
        }

        //Click the User Profile Messag button
        public void ClickUserProfileMessageBtn()
        {
            _driver.SafeClick(PeopleUI.userProfileMessageBtn);
        }

        

        //Click the Advance Search button
        public void ClickAdvanceSearchBtn()
        {
            _driver.SafeClick(PeopleUI.searchBtn);
        }

        //Get Endorsement Count
        public String GetEndorsementCount()
        {
            return _driver.GetElementText(PeopleUI.endorsementCount);
        }

        

        //Enter the Project Title
        public void EnterProjectTitle(String projectTitle)
        {
            _driver.SafeEnterText(PeopleUI.projectTitle, projectTitle);
        }

        //Enter the Project Description
        public void EnterProjectDescription(String projectDesc)
        {
            _driver.SafeEnterText(PeopleUI.projectDesc, projectDesc);
        }

        

        

        //Enter Skills Endorsed
        public void EnterSkills(String skillName)
        {
            _driver.SafeEnterText(PeopleUI.skills, skillName);
        }

        

        //Get Top Skill Name
        public String GetTopSkillName()
        {
            String a = _driver.GetElementText(PeopleUI.topSkillName);
            return a;
        }

        //Get Top Skill Count
        public String GetTopSkillCount()
        {
            String a = _driver.GetElementText(PeopleUI.topSkillCount);
            return a;
        }

        //Verify the Increased Top Skill Value
        public void VerifyIncreasedTopSkillCount(string counter)
        {
            _assertHelper.AssertElementDisplayed(PeopleUI.increasedTopSkillCount(counter));
        }

        

        

        

        //Enter Feedback From
        public void EnterFeedbackFrom(String feedbackFrom)
        {
            _driver.SafeEnterText(PeopleUI.feedbackFrom, feedbackFrom);
        }

        //Enter Optional Message
        public void EnterOptionalMessage(String message)
        {
            _driver.SafeEnterText(PeopleUI.optionalMessage, message);
        }

        */


    }
}
