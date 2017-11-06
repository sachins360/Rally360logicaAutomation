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
    [Category("UserProfile")]
    public class UserProfileTest : BaseTest
    {
        static ReadData readUserProfile = new ReadData("UserProfile");

        //SignIn
        private void SignInDifferentUser()
        {
            String userName = readUserProfile.GetValue("SignInDifferentUser", "userName");
            String password = readUserProfile.GetValue("SignInDifferentUser", "password");
            authenticationPage.SetUserName(userName);
            authenticationPage.SetPassword(password);
            authenticationPage.ClickOnLoginButton();
        }

        [Test]
        public void UserProfile_001_VerifyUserIcon()
        {
            Global.MethodName = "UserProfile_001_VerifyUserIcon";

            userProfilePage.VerifyUserProfileIcon();
            log.Info("Verify User Profile icon");
            Thread.Sleep(2000);
        }

        [Test]
        public void UserProfile_002_VerifyUserIconAfterClick()
        {
            Global.MethodName = "UserProfile_002_VerifyUserIconAfterClick";

            /*//Verify the User Profile icon tooltip
            String loggedInUserName = readUserProfile.GetValue("UserProfile", "loggedInUserName");
            userProfilePage.VerifyUserTooltip(loggedInUserName);
            log.Info("Verify the USer Profile icon tooltip.");
            Thread.Sleep(2000);*/

            //Click User Profile Icon
            userProfilePage.ClickUserProfileIcon();
            log.Info("Click the User Profile Icon.");
            Thread.Sleep(2000);

            //Verify User Profile option 'Profile'
            userProfilePage.VerifyUserProfileOptions("Profile");
            log.Info("Verify User Profile option 'Profile'.");
            Thread.Sleep(1000);

            //Verify User Profile option 'Support'
            userProfilePage.VerifyUserProfileOptions("Support");
            log.Info("Verify User Profile option 'Support'.");
            Thread.Sleep(1000);

            //Verify User Profile option 'Sign out'
            userProfilePage.VerifyUserProfileOptions("Sign out");
            log.Info("Verify User Profile option 'Sign out'.");
            Thread.Sleep(1000);
        }

        [Test]
        public void UserProfile_003_VerifyUserDetailsWindow()
        {
            Global.MethodName = "UserProfile_003_VerifyUserDetailsWindow";

            //Click User Profile Icon
            userProfilePage.ClickUserProfileIcon();
            log.Info("Click the User Profile Icon.");
            Thread.Sleep(2000);

            //Select the User Profile Option 'Profile'
            userProfilePage.ClickUserProfileOptions("Profile");
            log.Info("Click User Profile option 'Profile'.");
            Thread.Sleep(2000);

            //Verify User Details Window is displayed
            userProfilePage.VerifyUserDetailsWindow();
            log.Info("Verify User Details Window displayed.");
            Thread.Sleep(1000);
        }

        [Test]
        public void UserProfile_004_VerifyUserDetailsWindowData()
        {
            Global.MethodName = "UserProfile_004_VerifyUserDetailsWindowData";

            //Click User Profile Icon
            userProfilePage.ClickUserProfileIcon();
            log.Info("Click the User Profile Icon.");
            Thread.Sleep(2000);

            //Select the User Profile Option 'Profile'
            userProfilePage.ClickUserProfileOptions("Profile");
            log.Info("Click User Profile option 'Profile'.");
            Thread.Sleep(2000);

            //Verify User Details Window is displayed
            userProfilePage.VerifyUserDetailsWindow();
            log.Info("Verify User Details Window displayed.");
            Thread.Sleep(1000);

            //Assert the User Profile User Name
            String loggedInUserName = readUserProfile.GetValue("UserProfile", "loggedInUserName");
            peoplePage.VerifyUserName(loggedInUserName);
            log.Info("Verify User Profile User Name.");
            Thread.Sleep(2000);                     
            
            //Assert the User Profile Skills & Endorsements
            peoplePage.VerifySkillsEndorsements();
            log.Info("Verify User Profile Skills & Endorsements.");
            Thread.Sleep(2000);

            //Assert the User Profile Industry/Domain Expertise
            peoplePage.VerifyIndustryDomainExpertise();
            log.Info("Verify User Profile Industry/Domain Expertise.");
            Thread.Sleep(2000);

            //Assert the User Profile Languages
            peoplePage.VerifyLanguages();
            log.Info("Verify User Profile Languages.");
            Thread.Sleep(2000);

            //Assert the User Profile Interests
            peoplePage.VerifyInterests();
            log.Info("Verify User Profile Interests.");
            Thread.Sleep(2000);

            //Assert the User Profile Projects
            peoplePage.VerifyProjects();
            log.Info("Verify User Profile Projects.");
            Thread.Sleep(2000);
        }

        [Test]
        public void UserProfile_006_VerifyEditProfileWindow()
        {
            Global.MethodName = "UserProfile_006_VerifyEditProfileWindow";

            //Click User Profile Icon
            userProfilePage.ClickUserProfileIcon();
            log.Info("Click the User Profile Icon.");
            Thread.Sleep(2000);

            //Select the User Profile Option 'Profile'
            userProfilePage.ClickUserProfileOptions("Profile");
            log.Info("Click User Profile option 'Profile'.");
            Thread.Sleep(2000);

            //Click the Edit Profile Icon
            userProfilePage.ClickEditProfileIcon();
            log.Info("Click on the Edit Profile Icon.");
            Thread.Sleep(2000);

            //Verify Edit Profile Window is displayed
            userProfilePage.VerifyEditProfileWindow();
            log.Info("Verify Edit Profile Window displayed.");            
        }

        [Test]
        public void UserProfile_007_VerifyEditProfileFields()
        {
            Global.MethodName = "UserProfile_007_VerifyEditProfileFields";

            //Click User Profile Icon
            userProfilePage.ClickUserProfileIcon();
            log.Info("Click the User Profile Icon.");
            Thread.Sleep(2000);

            //Select the User Profile Option 'Profile'
            userProfilePage.ClickUserProfileOptions("Profile");
            log.Info("Click User Profile option 'Profile'.");
            Thread.Sleep(2000);

            //Click the Edit Profile Icon
            userProfilePage.ClickEditProfileIcon();
            log.Info("Click on the Edit Profile Icon.");
            Thread.Sleep(2000);

            //Verify Edit Profile Window Profile Builder button
            userProfilePage.VerifyEditProfilProfileBuilderBtn();
            log.Info("Verify Edit Profile Window Profile Builder button is displayed.");
            Thread.Sleep(1000);

            //Verify Edit Profile Window Save button
            userProfilePage.VerifyEditProfilSaveBtn();
            log.Info("Verify Edit Profile Window Save button is displayed.");
            Thread.Sleep(1000);

            //Verify Edit Profile Window Cancel button
            userProfilePage.VerifyEditProfilCancelBtn();
            log.Info("Verify Edit Profile Window Cancel button is displayed.");
            Thread.Sleep(1000);

            //Verify Edit Profile Window First Name
            userProfilePage.VerifyEditProfileFirstName();
            log.Info("Verify Edit Profile Window First Name is displayed.");
            Thread.Sleep(1000);

            //Verify Edit Profile Window Last Name
            userProfilePage.VerifyEditProfileLastName();
            log.Info("Verify Edit Profile Window Last Name is displayed.");
            Thread.Sleep(1000);

            //Verify Edit Profile Window Email
            userProfilePage.VerifyEditProfileEmail();
            log.Info("Verify Edit Profile Window Email is displayed.");
            Thread.Sleep(1000);

            //Verify Edit Profile Window Title
            userProfilePage.VerifyEditProfileTitle();
            log.Info("Verify Edit Profile Window Title is displayed.");
            Thread.Sleep(1000);

            //Verify Edit Profile Window Department
            userProfilePage.VerifyEditProfileEmail();
            log.Info("Verify Edit Profile Window Email is displayed.");
            Thread.Sleep(1000);

            //Verify Edit Profile Window About Me
            userProfilePage.VerifyEditProfileAboutMe();
            log.Info("Verify Edit Profile Window About Me is displayed.");
            Thread.Sleep(1000);

            //Verify Edit Profile Window My Top Skills
            userProfilePage.VerifyEditProfileMyTopSkills();
            log.Info("Verify Edit Profile Window My Top Skills is displayed.");
            Thread.Sleep(1000);

            //Verify Edit Profile Window Other Skills
            userProfilePage.VerifyEditProfileOtherSkills();
            log.Info("Verify Edit Profile Window Other Skills is displayed.");
            Thread.Sleep(1000);

            //Verify Edit Profile Window Industry/Domain Expertise
            userProfilePage.VerifyEditProfileIndustryDomainExpertise();
            log.Info("Verify Edit Profile Window Industry/Domain Expertise is displayed.");
            Thread.Sleep(1000);

            //Verify Edit Profile Window Languages
            userProfilePage.VerifyEditProfileLanguages();
            log.Info("Verify Edit Profile Window Languages is displayed.");
            Thread.Sleep(1000);

            //Verify Edit Profile Window Interested In 
            userProfilePage.VerifyEditProfileInterestedIn();
            log.Info("Verify Edit Profile Window Interested In is displayed.");
            Thread.Sleep(1000);

            //Verify Edit Profile Window LinkedIn Url
            userProfilePage.VerifyEditProfileLinkedInUrl();
            log.Info("Verify Edit Profile Window LinkedIn Url is displayed.");
            Thread.Sleep(1000);

            //Verify Edit Profile Window Phone
            userProfilePage.VerifyEditProfilePhone();
            log.Info("Verify Edit Profile Window Phone is displayed.");
            Thread.Sleep(1000);

            //Verify Edit Profile Window Address
            userProfilePage.VerifyEditProfileAddress();
            log.Info("Verify Edit Profile Window Address is displayed.");
            Thread.Sleep(1000);

            //Verify Edit Profile Window City
            userProfilePage.VerifyEditProfileCity();
            log.Info("Verify Edit Profile Window City is displayed.");
            Thread.Sleep(1000);

            //Verify Edit Profile Window State/Province
            userProfilePage.VerifyEditProfileStateProvince();
            log.Info("Verify Edit Profile Window Email is displayed.");
            Thread.Sleep(1000);

            //Verify Edit Profile Window Postal Code
            userProfilePage.VerifyEditProfilePostalCode();
            log.Info("Verify Edit Profile Window Postal Code is displayed.");
            Thread.Sleep(1000);

            //Verify Edit Profile Window Country
            userProfilePage.VerifyEditProfileCountry();
            log.Info("Verify Edit Profile Window Country is displayed.");
            Thread.Sleep(1000);

            /*//Verify Edit Profile Window Old Password
            userProfilePage.VerifyEditProfileOldPassword();
            log.Info("Verify Edit Profile Window Old Password is displayed.");
            Thread.Sleep(1000);

            //Verify Edit Profile Window New Password
            userProfilePage.VerifyEditProfileNewPassword();
            log.Info("Verify Edit Profile Window New Password is displayed.");
            Thread.Sleep(1000);

            //Verify Edit Profile Window Confirm Password
            userProfilePage.VerifyEditProfilConfirmPassword();
            log.Info("Verify Edit Profile Window Confirm Password is displayed.");*/
        }

        [Test]
        public void UserProfile_008_ClearFirstNameAndVerify()
        {
            Global.MethodName = "UserProfile_008_ClearFirstNameAndVerify";

            //Click User Profile Icon
            userProfilePage.ClickUserProfileIcon();
            log.Info("Click the User Profile Icon.");
            Thread.Sleep(2000);

            //Select the User Profile Option 'Profile'
            userProfilePage.ClickUserProfileOptions("Profile");
            log.Info("Click User Profile option 'Profile'.");
            Thread.Sleep(2000);

            //Click the Edit Profile Icon
            userProfilePage.ClickEditProfileIcon();
            log.Info("Click on the Edit Profile Icon.");
            Thread.Sleep(2000);

            //Enter empty Edit Profile Window First Name
            userProfilePage.EnterEditProfileFirstName("");
            log.Info("Enter empty Edit Profile Window First Name.");
            Thread.Sleep(1000);

            //Click Save button
            userProfilePage.ClickEditProfileSaveBtn();
            log.Info("Click Edit Profile Window Save button.");
            Thread.Sleep(2000);

            //Verify Mandatory Field error message
            userProfilePage.VerifyMandatoryFieldErrorMsg();
            log.Info("Verify Mandatory Field error message is displayed.");
            Thread.Sleep(1000);
        }

        [Test]
        public void UserProfile_009_ClearLastNameAndVerify()
        {
            Global.MethodName = "UserProfile_009_ClearLastNameAndVerify";

            //Click User Profile Icon
            userProfilePage.ClickUserProfileIcon();
            log.Info("Click the User Profile Icon.");
            Thread.Sleep(2000);

            //Select the User Profile Option 'Profile'
            userProfilePage.ClickUserProfileOptions("Profile");
            log.Info("Click User Profile option 'Profile'.");
            Thread.Sleep(2000);

            //Click the Edit Profile Icon
            userProfilePage.ClickEditProfileIcon();
            log.Info("Click on the Edit Profile Icon.");
            Thread.Sleep(2000);

            //Enter empty Edit Profile Window Last Name
            userProfilePage.EnterEditProfileLastName("");
            log.Info("Enter empty Edit Profile Window Last Name.");
            Thread.Sleep(3000);

            commonPage.ScrollUp();
            Thread.Sleep(2000);

            //Click Save button
            userProfilePage.ClickEditProfileSaveBtn();
            log.Info("Click Edit Profile Window Save button.");
            Thread.Sleep(2000);

            //Verify Mandatory Field error message
            userProfilePage.VerifyMandatoryFieldErrorMsg();
            log.Info("Verify Mandatory Field error message is displayed.");
            Thread.Sleep(1000);
        }

        [Test]
        public void UserProfile_027_EditDataAndVerify()
        {
            Global.MethodName = "UserProfile_027_EditDataAndVerify";

            //Click User Profile Icon
            userProfilePage.ClickUserProfileIcon();
            log.Info("Click the User Profile Icon.");
            Thread.Sleep(2000);

            //Select the User Profile Option 'Profile'
            userProfilePage.ClickUserProfileOptions("Profile");
            log.Info("Click User Profile option 'Profile'.");
            Thread.Sleep(2000);

            //Click the Edit Profile Icon
            userProfilePage.ClickEditProfileIcon();
            log.Info("Click on the Edit Profile Icon.");
            Thread.Sleep(2000);

            //Enter Edit Profile Window Title
            String editTitle = readUserProfile.GetValue("UserProfile", "editTitle");
            userProfilePage.EnterEditProfileTitle(editTitle);
            log.Info("Enter empty Edit Profile Window Title.");
            Thread.Sleep(1000);

            //Enter Edit Profile Window About Me
            String editAboutMe = readUserProfile.GetValue("UserProfile", "editAboutMe");
            userProfilePage.EnterEditProfileAboutMe(editAboutMe);
            log.Info("Enter empty Edit Profile Window About Me.");
            Thread.Sleep(1000);

            //Click Save button
            commonPage.ScrollUp();
            Thread.Sleep(2000);
            userProfilePage.ClickEditProfileSaveBtn();
            log.Info("Click Edit Profile Window Save button.");
            Thread.Sleep(3000);

            //Verify updated About Me
            userProfilePage.VerifyUserProfileAboutMe(editAboutMe);
            log.Info("Verify update About Me is displayed.");
            Thread.Sleep(1000);

            //Verify updated Title
            userProfilePage.VerifyUserProfileTitle(editTitle);
            log.Info("Verify update Title is displayed.");
        }

        [Test]
        public void UserProfile_028_VerifyProfileBuilderFields()
        {
            Global.MethodName = "UserProfile_028_VerifyProfileBuilderFields";

            //Click User Profile Icon
            userProfilePage.ClickUserProfileIcon();
            log.Info("Click the User Profile Icon.");
            Thread.Sleep(2000);

            //Select the User Profile Option 'Profile'
            userProfilePage.ClickUserProfileOptions("Profile");
            log.Info("Click User Profile option 'Profile'.");
            Thread.Sleep(2000);

            //Click the Edit Profile Icon
            userProfilePage.ClickEditProfileIcon();
            log.Info("Click on the Edit Profile Icon.");
            Thread.Sleep(2000);

            //Click Edit Profile Window Profile Builder button
            userProfilePage.ClickEditProfilProfileBuilderBtn();
            log.Info("Click Edit Profile Window Profile Builder button.");
            Thread.Sleep(5000);

            //Verify Profile Builder window
            userProfilePage.VerifyProfileBuilderWindow();
            log.Info("Verify Profile Builder Window is displayed.");
            Thread.Sleep(1000);

            //Verify Profile Builder Connect With LinkedIn button
            userProfilePage.VerifyProfileBuilderConnectLinkedInBtn();
            log.Info("Verify Profile Builder Connect With LinkedIn button is displayed.");
            Thread.Sleep(1000);

            //Verify Profile Builder Upload Resume button
            userProfilePage.VerifyProfileBuilderUploadResumeBtn();
            log.Info("Verify Profile Builder Upload Resume button is displayed.");
            Thread.Sleep(1000);

            //Verify Profile Builder Close button
            userProfilePage.VerifyProfileBuilderCloseBtn();
            log.Info("Verify Profile Builder Close button is displayed.");            
        }

        [Test]
        public void ENG2177_001_VerifyAdminOption()
        {
            Global.MethodName = "ENG2177_001_VerifyAdminOption";

            //Click User Profile Icon
            userProfilePage.ClickUserProfileIcon();
            log.Info("Click the User Profile Icon.");
            Thread.Sleep(2000);

            //Verify User Profile option 'Admin'
            userProfilePage.VerifyUserProfileOptions("Admin");
            log.Info("Verify User Profile option 'Admin'.");
            Thread.Sleep(1000);

            //Select the User Profile Option 'Admin'
            userProfilePage.ClickUserProfileOptions("Admin");
            log.Info("Click User Profile option 'Admin'.");
            Thread.Sleep(5000);

            //Verify Features tab
            userProfilePage.VerifyFeaturesTab();
            log.Info("Verify Features tab is displayed.");
            Thread.Sleep(1000);

            //Verify Users tab
            userProfilePage.VerifyManageUsersTab();
            log.Info("Verify Manage Users tab is displayed.");
            Thread.Sleep(1000);

            //Verify Groups tab
            userProfilePage.VerifyGroupsTab();
            log.Info("Verify Groups tab is displayed.");
        }

        [Test]
        public void ENG2177_002_VerifyAdminColumn()
        {
            Global.MethodName = "ENG2177_002_VerifyAdminColumn";

            //Click User Profile Icon
            userProfilePage.ClickUserProfileIcon();
            log.Info("Click the User Profile Icon.");
            Thread.Sleep(2000);
            
            //Select the User Profile Option 'Admin'
            userProfilePage.ClickUserProfileOptions("Admin");
            log.Info("Click User Profile option 'Admin'.");
            Thread.Sleep(2000);

            //Click Manage Users tab
            userProfilePage.ClickManageUsersTab();
            log.Info("Click Manage Users tab.");
            Thread.Sleep(4000);

            //Verify Group column
            userProfilePage.VerifyGroupColumn();
            log.Info("Verify Admin column is displayed.");
        }
        /*
        [Test]
        public void ENG2177_003_VerifyAdminOptionForNonAdminUser()
        {
            Global.MethodName = "ENG2177_003_VerifyAdminOptionForNonAdminUser";

            //Click User Profile Icon
            userProfilePage.ClickUserProfileIcon();
            log.Info("Click the User Profile Icon.");
            Thread.Sleep(2000);

            //Select the User Profile Option 'Admin'
            userProfilePage.ClickUserProfileOptions("Admin");
            log.Info("Click User Profile option 'Admin'.");
            Thread.Sleep(2000);

            //Click Manage Users tab
            userProfilePage.ClickManageUsersTab();
            log.Info("Click Manage Users tab.");
            Thread.Sleep(2000);

            //Enter Search User Email Id
            String searchUser = readUserProfile.GetValue("Admin", "searchUser");
            userProfilePage.EnterSearchUser(searchUser);
            log.Info("Enter search user email id.");
            Thread.Sleep(2000);

            //Press Enter Key
            userProfilePage.PressEnterKey();
            Thread.Sleep(2000);

            //Click the Admin check-box
            userProfilePage.ClickAdminCheckBox();
            log.Info("Click Admin check-box.");
            Thread.Sleep(1000);

            //Signout of the application
            authenticationPage.SignOut();
            log.Info("Click on the Signout button.");
            Thread.Sleep(5000);

            //Sign in with a different user
            SignInDifferentUser();
            log.Info("Sign in with different user.");
            Thread.Sleep(2000);

            //Click User Profile Icon
            userProfilePage.ClickUserProfileIcon();
            log.Info("Click the User Profile Icon.");
            Thread.Sleep(2000);

            //Verify User Profile option 'Admin' is not displayed
            userProfilePage.VerifyUserProfileOptionNotDisplayed("Admin");
            log.Info("Verify User Profile option 'Admin' is not displayed.");
            Thread.Sleep(1000);
            userProfilePage.ClickUserProfileIcon();
            Thread.Sleep(1000);

            //*****Steps to make the user Admin again*******
            //Signout of the application
            authenticationPage.SignOut();
            log.Info("Click on the Signout button.");

            //Login to the application
            Thread.Sleep(5000);
            authenticationPage.SetUserName(_workEmail);
            authenticationPage.SetPassword(_password);
            authenticationPage.ClickOnLoginButton();
            authenticationPage.VerifyHomeScreen();

            //Click User Profile Icon
            userProfilePage.ClickUserProfileIcon();
            log.Info("Click the User Profile Icon.");
            Thread.Sleep(2000);

            //Select the User Profile Option 'Admin'
            userProfilePage.ClickUserProfileOptions("Admin");
            log.Info("Click User Profile option 'Admin'.");
            Thread.Sleep(2000);

            //Click Manage Users tab
            userProfilePage.ClickManageUsersTab();
            log.Info("Click Manage Users tab.");
            Thread.Sleep(2000);

            //Enter Search User Email Id
            userProfilePage.EnterSearchUser(searchUser);
            log.Info("Enter search user email id.");
            Thread.Sleep(2000);

            //Press Enter Key
            userProfilePage.PressEnterKey();
            Thread.Sleep(2000);

            //Click the Admin check-box
            userProfilePage.ClickAdminCheckBox();
            log.Info("Click Admin check-box.");
            Thread.Sleep(1000);
        }

        [Test]
        public void ENG2177_004_VerifyEditOtherUserOptionForNonAdminUser()
        {
            Global.MethodName = "ENG2177_004_VerifyEditOtherUserOptionForNonAdminUser";

            //Click User Profile Icon
            userProfilePage.ClickUserProfileIcon();
            log.Info("Click the User Profile Icon.");
            Thread.Sleep(2000);

            //Select the User Profile Option 'Admin'
            userProfilePage.ClickUserProfileOptions("Admin");
            log.Info("Click User Profile option 'Admin'.");
            Thread.Sleep(2000);

            //Click Manage Users tab
            userProfilePage.ClickManageUsersTab();
            log.Info("Click Manage Users tab.");
            Thread.Sleep(2000);

            //Enter Search User Email Id
            String searchUser = readUserProfile.GetValue("Admin", "searchUser");
            userProfilePage.EnterSearchUser(searchUser);
            log.Info("Enter search user email id.");
            Thread.Sleep(2000);

            //Press Enter Key
            userProfilePage.PressEnterKey();
            Thread.Sleep(2000);

            //Click the Admin check-box
            userProfilePage.ClickAdminCheckBox();
            log.Info("Click Admin check-box.");
            Thread.Sleep(1000);

            //Signout of the application
            authenticationPage.SignOut();
            log.Info("Click on the Signout button.");
            Thread.Sleep(5000);

            //Sign in with a different user
            SignInDifferentUser();
            log.Info("Sign in with different user.");
            Thread.Sleep(2000);

            //Click People menu option
            Thread.Sleep(2000);
            peoplePage.ClickPeopleMenu();
            log.Info("Click the People menu option.");
            Thread.Sleep(3000);

            //Enter the Search text
            String peopleSearchUser = readUserProfile.GetValue("Admin", "peopleSearchUser");
            peoplePage.EnterSearchBox(peopleSearchUser);
            log.Info("Enter the Search text.");
            Thread.Sleep(3000);

            //Press enter key
            peoplePage.PressEnterKey();
            Thread.Sleep(3000);

            //Move to User Container
            peoplePage.MoveToUserContainer();
            log.Info("Move to user container.");
            Thread.Sleep(2000);

            //Click View Profile button
            peoplePage.ClickViewProfileBtn();
            log.Info("Click on Message button.");
            Thread.Sleep(3000);

            //Verify Settings Profile button not displayed
            userProfilePage.VerifySettingsProfileBtnNotDisplayed();
            log.Info("Verify Settings Profile button is not displayed.");
            Thread.Sleep(2000);

            //*****Steps to make the user Admin again*******
            //Signout of the application
            authenticationPage.SignOut();
            log.Info("Click on the Signout button.");

            //Login to the application
            Thread.Sleep(5000);
            authenticationPage.SetUserName(_workEmail);
            authenticationPage.SetPassword(_password);
            authenticationPage.ClickOnLoginButton();
            authenticationPage.VerifyHomeScreen();

            //Click User Profile Icon
            userProfilePage.ClickUserProfileIcon();
            log.Info("Click the User Profile Icon.");
            Thread.Sleep(2000);

            //Select the User Profile Option 'Admin'
            userProfilePage.ClickUserProfileOptions("Admin");
            log.Info("Click User Profile option 'Admin'.");
            Thread.Sleep(2000);

            //Click Manage Users tab
            userProfilePage.ClickManageUsersTab();
            log.Info("Click Manage Users tab.");
            Thread.Sleep(2000);

            //Enter Search User Email Id
            userProfilePage.EnterSearchUser(searchUser);
            log.Info("Enter search user email id.");
            Thread.Sleep(2000);

            //Press Enter Key
            userProfilePage.PressEnterKey();
            Thread.Sleep(2000);

            //Click the Admin check-box
            userProfilePage.ClickAdminCheckBox();
            log.Info("Click Admin check-box.");
            Thread.Sleep(1000);
        }

        [Test]
        public void ENG2177_005_VerifyEditOtherUserOptionForAdminUser()
        {
            Global.MethodName = "ENG2177_005_VerifyEditOtherUserOptionForAdminUser";
                        
            //Click People menu option
            Thread.Sleep(2000);
            peoplePage.ClickPeopleMenu();
            log.Info("Click the People menu option.");
            Thread.Sleep(3000);

            //Enter the Search text
            String peopleSearchUserByAdmin = readUserProfile.GetValue("Admin", "peopleSearchUserByAdmin");
            peoplePage.EnterSearchBox(peopleSearchUserByAdmin);
            log.Info("Enter the Search text.");
            Thread.Sleep(3000);

            //Press enter key
            peoplePage.PressEnterKey();
            Thread.Sleep(3000);

            //Move to User Container
            peoplePage.MoveToUserContainer();
            log.Info("Move to user container.");
            Thread.Sleep(2000);

            //Click View Profile button
            peoplePage.ClickViewProfileBtn();
            log.Info("Click on Message button.");
            Thread.Sleep(3000);

            //Verify Settings Profile button is displayed
            userProfilePage.VerifySettingsProfileBtn();
            log.Info("Verify Settings Profile button is displayed.");
            Thread.Sleep(2000);

            //Click the Settings Profile button
            userProfilePage.ClickSettingsProfileBtn();
            log.Info("Click the User Settings Profile button.");
            Thread.Sleep(1000);

            //Select Edit Profile from the Settings options
            userProfilePage.SelectSettingProfileOption("Edit Profile");
            log.Info("Select 'Edit Profile' from the Settings Profile options.");
            Thread.Sleep(3000);

            //Verify Edit Profile Window is displayed
            userProfilePage.VerifyEditProfileWindow();
            log.Info("Verify Edit Profile Window displayed.");
        }
        */
        [Test]
        public void ENG2177_006_EditOtherUserProfileByAdminUser()
        {
            Global.MethodName = "ENG2177_006_EditOtherUserProfileByAdminUser";

            //Click People menu option
            Thread.Sleep(2000);
            peoplePage.ClickPeopleMenu();
            log.Info("Click the People menu option.");
            Thread.Sleep(3000);

            //Enter the Search text
            String peopleSearchUserByAdmin = readUserProfile.GetValue("Admin", "peopleSearchUserByAdmin");
            peoplePage.EnterSearchBox(peopleSearchUserByAdmin);
            log.Info("Enter the Search text.");
            Thread.Sleep(3000);

            //Press enter key
            peoplePage.PressEnterKey();
            Thread.Sleep(5000);

            //Move to User Container
            peoplePage.MoveToUserContainer();
            log.Info("Move to user container.");
            Thread.Sleep(2000);

            //Click View Profile button
            peoplePage.ClickViewProfileBtn();
            log.Info("Click on Message button.");
            Thread.Sleep(5000);
                        
            //Click the Settings Profile button
            userProfilePage.ClickSettingsProfileBtn();
            log.Info("Click the User Settings Profile button.");
            Thread.Sleep(2000);

            //Select Edit Profile from the Settings options
            userProfilePage.SelectSettingProfileOption("Edit Profile");
            log.Info("Select 'Edit Profile' from the Settings Profile options.");
            Thread.Sleep(3000);

            //Enter Edit Profile Window Title
            String editTitle = readUserProfile.GetValue("Admin", "editTitle");
            userProfilePage.EnterEditProfileTitle(editTitle);
            log.Info("Enter empty Edit Profile Window Title.");
            Thread.Sleep(1000);

            //Enter Edit Profile Window About Me
            String editAboutMe = readUserProfile.GetValue("Admin", "editAboutMe");
            userProfilePage.EnterEditProfileAboutMe(editAboutMe);
            log.Info("Enter empty Edit Profile Window About Me.");
            Thread.Sleep(1000);

            //Click Save button
            commonPage.ScrollUp();
            userProfilePage.ClickEditProfileSaveBtn();
            log.Info("Click Edit Profile Window Save button.");
            Thread.Sleep(3000);

            //Verify updated About Me
            userProfilePage.VerifyUserProfileAboutMe(editAboutMe);
            log.Info("Verify update About Me is displayed.");
            Thread.Sleep(1000);

            //Verify updated Title
            userProfilePage.VerifyUserProfileTitle(editTitle);
            log.Info("Verify update Title is displayed.");
        }    
        
    }
}