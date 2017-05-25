using OpenQA.Selenium;
using RallyTeam.Util;
using RallyTeam.UILocators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Interactions;
using System.Collections;

namespace RallyTeam.UIPages
{
    public class UserProfilePage : BasePage
    {
        CommonMethods commonPage;

        public UserProfilePage(IWebDriver driver, int pageLoadTimeout)
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

        //Assert User Profile Icon
        public void VerifyUserProfileIcon()
        {
            _assertHelper.AssertElementDisplayed(DashboardUI.userIcon);
        }

        //Assert User Icon tooltip
        public void VerifyUserTooltip(String userName)
        {
            _assertHelper.AssertElementDisplayed(DashboardUI.userProfileTooltip(userName));
        }

        //Click User Profile Icon
        public void ClickUserProfileIcon()
        {
            _driver.ClickElementUsingAction(DashboardUI.userIcon);
        }

        //Assert User Profile option
        public void VerifyUserProfileOptions(String variable)
        {
            _assertHelper.AssertElementDisplayed(DashboardUI.UserIconOptions(variable));
        }

        //Assert User Profile option not displayed
        public void VerifyUserProfileOptionNotDisplayed(String variable)
        {
            _assertHelper.AssertElementNotDisplayed(DashboardUI.UserIconOptions(variable));
        }

        //Click User Profile option
        public void ClickUserProfileOptions(String variable)
        {
            _driver.SafeClick(DashboardUI.UserIconOptions(variable));
        }

        //Assert User Details Window is displayed
        public void VerifyUserDetailsWindow()
        {
            _assertHelper.AssertElementDisplayed(UserProfileUI.userDetailsDiv);
        }

        //Click Edit Profile Icon
        public void ClickEditProfileIcon()
        {
            _driver.SafeClick(UserProfileUI.editProfileIcon);
        }

        //Assert Edit Profile Window is displayed
        public void VerifyEditProfileWindow()
        {
            _assertHelper.AssertElementDisplayed(UserProfileUI.editProfilePage);
        }

        //Assert Edit Profile Window First Name
        public void VerifyEditProfileFirstName()
        {
            _assertHelper.AssertElementDisplayed(UserProfileUI.editFirstName);
        }

        //Enter Edit Profile Window First Name
        public void EnterEditProfileFirstName(String firstName)
        {
            _driver.SafeEnterText(UserProfileUI.editFirstName, firstName);
        }

        //Assert Edit Profile Window Last Name
        public void VerifyEditProfileLastName()
        {
            _assertHelper.AssertElementDisplayed(UserProfileUI.editLastName);
        }

        //Enter Edit Profile Window Last Name
        public void EnterEditProfileLastName(String lastName)
        {
            _driver.SafeEnterText(UserProfileUI.editLastName, lastName);
        }

        //Assert Edit Profile Window Email
        public void VerifyEditProfileEmail()
        {
            _assertHelper.AssertElementDisplayed(UserProfileUI.editEmail);
        }

        //Assert Edit Profile Window Title
        public void VerifyEditProfileTitle()
        {
            _assertHelper.AssertElementDisplayed(UserProfileUI.editTitle);
        }

        //Enter Edit Profile Window Title
        public void EnterEditProfileTitle(String title)
        {
            _driver.SafeEnterText(UserProfileUI.editTitle, title);
        }

        //Assert Edit Profile Window Department
        public void VerifyEditProfileDepartment()
        {
            _assertHelper.AssertElementDisplayed(UserProfileUI.editDepartment);
        }

        //Assert Edit Profile Window About Me
        public void VerifyEditProfileAboutMe()
        {
            _assertHelper.AssertElementDisplayed(UserProfileUI.editAboutMe);
        }

        //Enter Edit Profile Window About Me
        public void EnterEditProfileAboutMe(String aboutMe)
        {
            _driver.SafeEnterText(UserProfileUI.editAboutMe, aboutMe);
        }

        //Assert Edit Profile Window My Top Skills
        public void VerifyEditProfileMyTopSkills()
        {
            _assertHelper.AssertElementDisplayed(UserProfileUI.editMyTopSkills);
        }

        //Assert Edit Profile Window Other Skills
        public void VerifyEditProfileOtherSkills()
        {
            _assertHelper.AssertElementDisplayed(UserProfileUI.editOtherSkills);
        }

        //Assert Edit Profile Window Industry/Domain Expertise
        public void VerifyEditProfileIndustryDomainExpertise()
        {
            _assertHelper.AssertElementDisplayed(UserProfileUI.editIndustryDomainExpertise);
        }

        //Assert Edit Profile Window Languages
        public void VerifyEditProfileLanguages()
        {
            _assertHelper.AssertElementDisplayed(UserProfileUI.editLanguages);
        }

        //Assert Edit Profile Window Interested In
        public void VerifyEditProfileInterestedIn()
        {
            _assertHelper.AssertElementDisplayed(UserProfileUI.editInterestedIn);
        }

        //Assert Edit Profile Window LinkedIn Url
        public void VerifyEditProfileLinkedInUrl()
        {
            _assertHelper.AssertElementDisplayed(UserProfileUI.editLinkedInUrl);
        }

        //Assert Edit Profile Window Phone
        public void VerifyEditProfilePhone()
        {
            _assertHelper.AssertElementDisplayed(UserProfileUI.editPhone);
        }

        //Assert Edit Profile Window Address
        public void VerifyEditProfileAddress()
        {
            _assertHelper.AssertElementDisplayed(UserProfileUI.editAddress);
        }

        //Assert Edit Profile Window City
        public void VerifyEditProfileCity()
        {
            _assertHelper.AssertElementDisplayed(UserProfileUI.editCity);
        }

        //Assert Edit Profile Window State/Province
        public void VerifyEditProfileStateProvince()
        {
            _assertHelper.AssertElementDisplayed(UserProfileUI.editStateProvince);
        }

        //Assert Edit Profile Window Postal Code
        public void VerifyEditProfilePostalCode()
        {
            _assertHelper.AssertElementDisplayed(UserProfileUI.editPostalCode);
        }

        //Assert Edit Profile Window Country
        public void VerifyEditProfileCountry()
        {
            _assertHelper.AssertElementDisplayed(UserProfileUI.editCountry);
        }

        //Assert Edit Profile Window Available to Help
        public void VerifyEditProfileAvailableHelp()
        {
            _assertHelper.AssertElementDisplayed(UserProfileUI.editAvailableToHelp);
        }

        //Assert Edit Profile Window Email Notifications
        public void VerifyEditProfileEmailNotifications()
        {
            _assertHelper.AssertElementDisplayed(UserProfileUI.editEmailNotifications);
        }

        //Assert Edit Profile Window Old Password
        public void VerifyEditProfileOldPassword()
        {
            _assertHelper.AssertElementDisplayed(UserProfileUI.editOldPassword);
        }

        //Assert Edit Profile Window New Password
        public void VerifyEditProfileNewPassword()
        {
            _assertHelper.AssertElementDisplayed(UserProfileUI.editNewPassword);
        }

        //Assert Edit Profile Window Confirm Password
        public void VerifyEditProfilConfirmPassword()
        {
            _assertHelper.AssertElementDisplayed(UserProfileUI.editOldPassword);
        }

        //Assert Edit Profile Window Profile Builder Button
        public void VerifyEditProfilProfileBuilderBtn()
        {
            _assertHelper.AssertElementDisplayed(UserProfileUI.editProfileBuilderBtn);
        }

        //Assert Edit Profile Window Save Button
        public void VerifyEditProfilSaveBtn()
        {
            _assertHelper.AssertElementDisplayed(UserProfileUI.editSaveBtn);
        }

        //Assert Edit Profile Window Cancel Button
        public void VerifyEditProfilCancelBtn()
        {
            _assertHelper.AssertElementDisplayed(UserProfileUI.editCancelBtn);
        }

        //Press Edit Profile Window Save button
        public void ClickEditProfileSaveBtn()
        {
            _driver.SafeClick(UserProfileUI.editSaveBtn);
        }

        //Assert Mandatory Field Error Message
        public void VerifyMandatoryFieldErrorMsg()
        {
            _assertHelper.AssertElementDisplayed(UserProfileUI.mandatoryErrorMsg);
        }

        //Assert User Profile About Me
        public void VerifyUserProfileAboutMe(String aboutMe)
        {
            _assertHelper.AssertElementDisplayed(UserProfileUI.aboutMeData(aboutMe));
        }

        //Assert User Profile Title
        public void VerifyUserProfileTitle(String title)
        {
            _assertHelper.AssertElementDisplayed(UserProfileUI.aboutMeData(title));
        }

        //Click Edit Profile Window Profile Builder Button
        public void ClickEditProfilProfileBuilderBtn()
        {
            _driver.SafeClick(UserProfileUI.editProfileBuilderBtn);
        }

        //Assert Profile Builder Window
        public void VerifyProfileBuilderWindow()
        {
            _assertHelper.AssertElementDisplayed(UserProfileUI.profileBuilderWindow);
        }

        //Assert Profile Builder Connect With LinkedIn Button
        public void VerifyProfileBuilderConnectLinkedInBtn()
        {
            _assertHelper.AssertElementDisplayed(UserProfileUI.profileBuilderConnectLinkedInBtn);
        }

        //Assert Profile Builder Connect With LinkedIn Button
        public void VerifyProfileBuilderUploadResumeBtn()
        {
            _assertHelper.AssertElementDisplayed(UserProfileUI.profileBuilderUploadResumeBtn);
        }

        //Assert Profile Builder Connect With LinkedIn Button
        public void VerifyProfileBuilderCloseBtn()
        {
            _assertHelper.AssertElementDisplayed(UserProfileUI.profileBuilderCloseBtn);
        }

        //Assert Features tab
        public void VerifyFeaturesTab()
        {
            _assertHelper.AssertElementDisplayed(UserProfileUI.featuresTab);
        }

        //Assert Users tab
        public void VerifyManageUsersTab()
        {
            _assertHelper.AssertElementDisplayed(UserProfileUI.manageUsersTab);
        }

        //Assert Groups tab
        public void VerifyGroupsTab()
        {
            _assertHelper.AssertElementDisplayed(UserProfileUI.groupsTab);
        }

        //Click Manage Users tab
        public void ClickManageUsersTab()
        {
            _driver.SafeClick(UserProfileUI.manageUsersTab);
        }

        //Assert Group column
        public void VerifyGroupColumn()
        {
            _assertHelper.AssertElementDisplayed(UserProfileUI.groupColumn);
        }

        //Assert Notes column
        public void VerifyNotesColumn()
        {
            _assertHelper.AssertElementDisplayed(UserProfileUI.notesColumn);
        }

        //Assert View Notes hyperlink
        public void VerifyViewNotesLink()
        {
            _assertHelper.AssertElementDisplayed(UserProfileUI.viewNotesLink);
        }

        //Click View Notes hyperlink
        public void ClickViewNotesLink()
        {
            _driver.SafeClick(UserProfileUI.viewNotesLink);
        }

        //Enter the Search User field
        public void EnterSearchUser(String searchUser)
        {
            _driver.SafeEnterText(UserProfileUI.searchUser, searchUser);
        }

        //Click the Searched User
        public void ClickSearchedUser()
        {
            _driver.SafeClick(UserProfileUI.userNameLink);
        }

        //Click the Admin check-box
        public void ClickAdminCheckBox()
        {
            _driver.SafeClick(UserProfileUI.adminCheckBox);
        }

        //Click Settings Profile button
        public void ClickSettingsProfileBtn()
        {
            _driver.SafeClick(UserProfileUI.settingsProfileBtn);
        }

        //Assert Settings Profile button Not Displayed
        public void VerifySettingsProfileBtnNotDisplayed()
        {
            _assertHelper.AssertElementNotDisplayed(UserProfileUI.settingsProfileBtn);
        }

        //Assert Settings Profile button Displayed
        public void VerifySettingsProfileBtn()
        {
            _assertHelper.AssertElementDisplayed(UserProfileUI.settingsProfileBtn);
        }

        //Select User Profile option
        public void SelectSettingProfileOption(String variable)
        {
            _driver.SafeClick(UserProfileUI.settingsProfileOptions(variable));
        }

        //Assert View Notes Window Displayed
        public void VerifyViewNotesWindow()
        {
            _assertHelper.AssertElementDisplayed(UserProfileUI.viewNotesWindow);
        }

        //Assert View Notes TextArea Displayed
        public void VerifyViewNotesTextArea()
        {
            _assertHelper.AssertElementDisplayed(UserProfileUI.addNoteTextArea);
        }

        //Assert View Notes Add Note button Displayed
        public void VerifyViewNotesAddNoteBtn()
        {
            _assertHelper.AssertElementDisplayed(UserProfileUI.addNoteBtn);
        }

        //Click View Notes Add Note button
        public void ClickViewNotesAddNoteBtn()
        {
            _driver.SafeClick(UserProfileUI.addNoteBtn);
        }

        //Assert View Notes Window Displayed
        public void VerifyViewNotesCloseIcon()
        {
            _assertHelper.AssertElementDisplayed(UserProfileUI.viewNoteCloseIcon);
        }

        //Enter View Notes TextArea
        public void EnterViewNotesTextArea(String note)
        {
            _driver.SafeEnterText(UserProfileUI.addNoteTextArea, note);
        }

        //Assert View Notes added Note
        public void VerifyViewNotesAddedNote(String note)
        {
            _assertHelper.AssertElementDisplayed(UserProfileUI.viewAddedNote(note));
        }

        public String letsDoIt()
        {
            String a = _driver.GetElementText(UserProfileUI.abcd);
            return a;
        }



    }
}
