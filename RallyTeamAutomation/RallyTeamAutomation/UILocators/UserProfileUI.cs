using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RallyTeam.UILocators
{
    public static class UserProfileUI
    {
        public readonly static By userDetailsDiv = By.XPath("//div[text()='User Details']");
        public static By userName(String variable)
        {
            return By.XPath("//div[contains(@class, 'rt-user-profile__details__name') and contains(text(), '" + variable + "')]");
        }
        public readonly static By topSkills = By.XPath("//div[text() ='Top Skills']");
        public readonly static By userProfileMessageBtn = By.XPath("//button[text() ='Message']");
        public readonly static By aboutMe = By.XPath("//div[text() ='About Me']");
        public static By aboutMeData(String variable)
        {
            return By.XPath("//div[text()= '" + variable + "']");
        }
        public static By titleData(String variable)
        {
            return By.XPath("//div[text()= '" + variable + "']");
        }

        public readonly static By userSearchButton = By.XPath("//div[@class='input-group-btn']//button[@type= 'submit']//i[@class='fa fa-search']");
        public readonly static By skillsANdEndorsements = By.XPath("//div[contains(text(), 'Skills')]");
        public readonly static By industryDomain = By.XPath("//div[text() ='Industry/Domain Expertise']");
        public readonly static By languages = By.XPath("//div[text() ='Languages']");
        public readonly static By interests = By.XPath("//div[text() ='Interests']");
        public readonly static By projects = By.XPath("//div[text() ='Projects']");
        public readonly static By mandatoryErrorMsg = By.XPath("//span[text()= 'Please correct the errors in the form to continue.']");
        public readonly static By errorOpeningUserProfile = By.XPath("//div[contains(text(), 'error')]");

        //Edit Profile
        public readonly static By editProfileIcon = By.XPath("//i[@class= 'fa fa-pencil-square-o']");
        public readonly static By settingsProfileBtn = By.XPath("//button[@class= 'rt-settings-btn btn dropdown-toggle']");
        public static By settingsProfileOptions(String variable)
        {
            return By.XPath("//div[@class= 'clearfix ng-scope']//ul[@class= 'dropdown-menu']//a[contains(text(), '" + variable + "')]");
        }
        public readonly static By editProfilePage = By.XPath("//div[text()= 'Edit Profile']");
        public readonly static By editFirstName = By.Name("firstName");
        public readonly static By editLastName = By.Name("lastName");
        public readonly static By editEmail = By.Name("email");
        public readonly static By editTitle = By.Name("title");
        public readonly static By editDepartment = By.Name("department");
        public readonly static By editAboutMe = By.Name("bio");
        public readonly static By editMyTopSkills = By.XPath("//label[text()= 'My Top Skills']");
        public readonly static By editOtherSkills = By.XPath("//label[text()= 'Other Skills']");
        public readonly static By editIndustryDomainExpertise = By.XPath("//label[text()= 'Industry / Domain Expertise']");
        public readonly static By editLanguages = By.XPath("//label[text()= 'Languages']"); 
        public readonly static By editInterestedIn = By.XPath("//label[text()= 'Interested In']");
        public readonly static By editLinkedInUrl = By.Name("linkedInUrl");
        public readonly static By editPhone = By.Name("phone");
        public readonly static By editAddress = By.Name("address");
        public readonly static By editCity = By.Name("city");
        public readonly static By editStateProvince = By.Name("state");
        public readonly static By editPostalCode = By.Name("postalCode");
        public readonly static By editCountry = By.Name("country");
        public readonly static By editAvailableToHelp = By.XPath("//ins[1]");
        public readonly static By editEmailNotifications = By.XPath("//ins[2]");
        public readonly static By editOldPassword = By.Id("oldPassword");
        public readonly static By editNewPassword = By.Name("newpassword");
        public readonly static By editConfirmPassword = By.Name("confirmpassword");
        public readonly static By editProfileBuilderBtn = By.XPath("//button[contains(text(), 'Profile Builder')]");
        public readonly static By editSaveBtn = By.XPath("//button[contains(text(), 'Save')]");
        public readonly static By editCancelBtn = By.XPath("//a[contains(text(), 'Cancel')]");


        //Profile Builder
        public readonly static By profileBuilderWindow = By.XPath("//div[@class= 'modal-content']"); 
        public readonly static By profileBuilderConnectLinkedInBtn = By.XPath("//button[contains(@class, 'rt-btn--linkedin')]");
        public readonly static By profileBuilderUploadResumeBtn = By.XPath("//button[contains(@class, 'rt-btn--primary')]");
        public readonly static By profileBuilderCloseBtn = By.XPath("//button[text()= 'Close']");


        //Admin
        public readonly static By deactivate = By.XPath("//input[@class= 'ng-untouched ng-valid ng-dirty ng-valid-parse']");
        public readonly static By activate = By.XPath("//input[@class= 'ng-pristine ng-untouched ng-valid']");
        public readonly static By toggle = By.XPath("//label[@class= 'switch']//i");
        public readonly static By featuresTab = By.XPath("//a[text()='Features']");
        public readonly static By manageUsersTab = By.XPath("//a[text()='Users']");
        public readonly static By groupsTab = By.XPath("//a[text()='Groups']");
        public readonly static By groupColumn = By.XPath("//table[contains(@class, 'table table-hover')]//thead/tr//strong[text()= 'Group']");
        public readonly static By notesColumn = By.XPath("//table[contains(@class, 'table table-hover')]//thead/tr//strong[text()= 'Notes']");
        public readonly static By userNameLink = By.XPath("//table[contains(@class, 'table table-hover')]//tbody/tr[1]/td[1]//a");
        public readonly static By adminCheckBox = By.XPath("//table[contains(@class, 'table table-hover')]//tbody/tr[1]/td[5]//input");
        public readonly static By viewNotesLink = By.XPath("//table[contains(@class, 'table table-hover')]//tbody/tr[1]/td[6]//a");
        public readonly static By searchUser = By.XPath("//input[@placeholder= 'Search']");
        public readonly static By viewNotesWindow = By.XPath("//div[contains(text(), 'Notes on')]");
        public readonly static By addNoteTextArea = By.XPath("//textarea[@name= 'body']");
        public readonly static By addNoteBtn = By.XPath("//button[@class='btn btn-sm rt-btn--primary pull-right']//strong[contains(text(), 'Add note')]");
        public readonly static By viewNoteCloseIcon = By.XPath("//div[@class= 'modal-content']//i[@class= 'fa fa-times']");
        public static By viewAddedNote(String variable)
        {
            return By.XPath("//div[contains(text(), '" + variable+ "')]");
        }

        public readonly static By abcd = By.XPath("//div[@class= 'modal-content']//div[2]//div//div[1]//div");

        public readonly static By resendInvite = By.XPath("//div[@class='ng-scope']//a[@ng-click='userVm.resendInvite(user)']");


    }
    
}
