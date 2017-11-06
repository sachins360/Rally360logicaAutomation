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
    public class PeoplePage : BasePage
    {
        CommonMethods commonPage;

        public PeoplePage(IWebDriver driver, int pageLoadTimeout)
            : base(driver, pageLoadTimeout)
        {
            commonPage = new CommonMethods(_driver, pageLoadTimeout);
        }

        //Press Enter Key
        public void PressEnterKey()
        {
            _driver.PressKeyBoardEnter();
        }

        //Press Tab Key
        public void PressTabKey()
        {
            _driver.PressKeyBoardTab();
        }

        //Verify People menu option
        public void VerifyPeopleMenuOption()
        {
            _assertHelper.AssertElementDisplayed(DashboardUI.sideNavBar("People"));
        }

        //Click on People menu option
        public void ClickPeopleMenu()
        {
            _driver.WaitForElementAvailableAtDOM(DashboardUI.sideNavBar("People"), 1);
            _driver.SafeClick(DashboardUI.sideNavBar("People"));
        }

        //Click on People tab(ES)
        public void ClickPeopleTab()
        {
            _driver.SafeClick(PeopleUI.peopleTab);
        }

        //Assert Search text box
        public void VerifySearchBox()
        {
            _assertHelper.AssertElementDisplayed(PeopleUI.searchBox);
        }

        //Assert Adcance search link text box
        public void VerifyAdvanceSearchLink()
        {
            _assertHelper.AssertElementDisplayed(PeopleUI.advanceLink);
        }

        //Enter Search text box
        public void EnterSearchBox(String search)
        {
            _driver.WaitForElementAvailableAtDOM(PeopleUI.searchBox, 1);
            _driver.SafeEnterText(PeopleUI.searchBox, search);
        }

        //Enter Browse Search 
        public void EnterBrowseSearch(String search)
        {
            _driver.WaitForElementAvailableAtDOM(PeopleUI.browseSearch, 1);
            _driver.SafeEnterText(PeopleUI.browseSearch, search);
        }

        //Click Span Search button
        public void ClickSpanSearch()
        {
            _driver.SafeClick(PeopleUI.spanSearchBtn);
        }

        //Assert the user container displayed
        public void VerifyUserContainer()
        {
            _assertHelper.AssertElementDisplayed(PeopleUI.userContainer);
        }

        //Move to user container
        public void MoveToUserContainer()
        {
            _driver.MoveToElementUsingAction(PeopleUI.userContainer);
        }

        //Assert the Message button
        public void VerifyMessageBtn()
        {
            _assertHelper.AssertElementDisplayed(PeopleUI.messageBtn);
        }

        //Assert the Message button not displayed
        public void VerifyMessageBtnNotDisplayed()
        {
            _assertHelper.AssertElementNotDisplayed(PeopleUI.messageBtn);
        }

        //Press the Message button
        public void ClickMessageBtn()
        {
            _driver.SafeClick(PeopleUI.messageBtn);
        }

        //Assert the View Profile button
        public void VerifyViewProfileBtn()
        {
            _assertHelper.AssertElementDisplayed(PeopleUI.viewProfileBtn);
        }

        //Assert the Send Message Window non external storm
        public void VerifySendMessageWindow()
        {
            _assertHelper.AssertElementDisplayed(PeopleUI.sendMsgWindowOld);
        }

        //Assert the New Message Window
        public void VerifyNewMessageWindow()
        {
            _assertHelper.AssertElementDisplayed(PeopleUI.newMessageWindow);
        }

        //Enter message in text area
        public void EnterMessage(String message)
        {
            _driver.SafeEnterText(PeopleUI.msgTextAera, message);
        }

        //Press the Send button
        public void ClickSendBtn()
        {
            _driver.SafeClick(PeopleUI.sendMessageBtn);
        }

        //Assert the New Message Window button
        public void VerifyMessagConversationWindow()
        {
            _assertHelper.AssertElementDisplayed(PeopleUI.messageConversationWindow);
        }

        //Assert the Message Posted
        public void VerifyNewMessagwPosted(String message)
        {
            _assertHelper.AssertElementDisplayed(PeopleUI.messagePosted(message));
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

        //Assert User Name search is displayed
        public void VerifyUserContainerUserName(String userName)
        {
            _assertHelper.AssertElementDisplayed(PeopleUI.userContainerUserName(userName));
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

        //Click the Endorse button
        public void ClickEndorseBtn()
        {
            _driver.SafeClick(PeopleUI.endorseBtn);
        }

        //Select Project DropDown
        public void SelectProjectDropDown(String projectName)
        {
            _driver.SelectDropDownOption(projectName, PeopleUI.projectDropDown);
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

        //Click the Awesome rating
        public void ClickAwesomeRating()
        {
            _driver.SafeClick(PeopleUI.awesome);
        }

        //Click the Goog rating
        public void ClickGoodRating()
        {
            _driver.SafeClick(PeopleUI.good);
        }

        //Click the Not Good rating
        public void ClickNotGoodRating()
        {
            _driver.SafeClick(PeopleUI.notGood);
        }

        //Enter Feedback
        public void EnterFeedback(String feedback)
        {
            _driver.SafeEnterText(PeopleUI.projectFeedback, feedback);
        }

        //Enter Skills Endorsed
        public void EnterSkills(String skillName)
        {
            _driver.SafeEnterText(PeopleUI.skills, skillName);
        }

        //Click the Endorse User button
        public void ClickEndorseUserBtn()
        {
            _driver.SafeClick(PeopleUI.endorseUserBtn);
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

        //Click User Profile Icon
        public void ClickUserProfileIcon()
        {
            _driver.ClickElementUsingAction(DashboardUI.userIcon);
        }

        //Click User Profile option
        public void ClickUserProfileOptions(String variable)
        {
            _driver.SafeClick(DashboardUI.UserIconOptions(variable));
        }

        //Click Request Feedback button
        public void ClickRequestFeedbackBtn()
        {
            _driver.SafeClick(PeopleUI.requestFeedbackBtn);
        }

        //Select Request Feedback Project
        public void SelectRequestFeedbackProject(String projectName)
        {
            _driver.SafeSelectDropDownText(PeopleUI.requestFeedbackProject, projectName);
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

        //Click Send button
        public void ClickSendBtnForFeedback()
        {
            _driver.SafeClick(PeopleUI.sendBtn);
        }


    }
}
