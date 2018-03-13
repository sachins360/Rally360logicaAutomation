using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace RallyTeam.UILocators
{
    public static class AddUsersUI
    {
        public readonly static By mailinatorInputEmail = By.XPath("//input[@id= 'inboxfield']");

        public readonly static By sendInviteBtn = By.XPath("//div[@class='text-center m-t-md']//a[text()='Send Invite']");
        public readonly static By addUserBtn = By.XPath("//button[contains(text(), 'Add Users')]");
        public readonly static By letsBuildYourMarketplaceMsg = By.XPath("//div[contains(text(), 'Let's build your marketplace!')]");
        public readonly static By uploadMsg = By.XPath("//div[contains(text(), 'Upload your employees, external contractors, or contacts')]");
        public readonly static By closeIcon = By.XPath("//i[@class= 'fa fa-times']");

        public readonly static By downloadCSVTemp = By.XPath("//div[@class='m-t-lg text-center']//a[contains(text(),'Download a .csv template')]");
     
        public readonly static By mayBeLater = By.XPath("//div[contains(text(), 'MAYBE LATER')]");
        public readonly static By googleBtn = By.XPath("//a[contains(@class, 'google-btn')]");
        public readonly static By outlookBtn = By.XPath("//a[contains(@class, 'outlook-btn')]");
        
        //public readonly static By csvBtn = By.XPath("//a[contains(@class, 'csv-btn')]");        
        public readonly static By csvBtn = By.XPath("html/body/div[11]/div/div/div[1]/div[2]/div[2]/a");

        public readonly static By emailBtn = By.XPath("//a[contains(@class, 'email-btn')]");
        public readonly static By rallyTeamLogo = By.XPath("//div[@class='rt-poweredby']//img");

        public readonly static By createProfileBtn = By.XPath("//a[contains(@class, 'create-btn')]");
        public readonly static By emailAddressesInput = By.XPath("//input[contains(@placeholder, '@domain.com')]");

        
        public readonly static By emailInviteMessage = By.XPath("//div[@class='m-b-md']//textarea[@name='message']");
        public readonly static By emailInviteSubject = By.XPath("//div[@class='m-b-md']//input[@name='subject']");
        public readonly static By emailAddUsersBtn = By.XPath("//a[contains(text(), 'Add Users')]");
        public readonly static By finishBtn = By.XPath("//a[contains(text(), 'Finish')]");
        //public readonly static By emailSender = By.XPath("//tbody[@id= 'mail_list_body']/[contains(text(), 'noreply@rallyteam.com')]");
        public readonly static By emailSubject = By.XPath("//div[contains(text(), 'Confirm your email address on Rallyteam')]");
        public readonly static By getStartedBtn = By.XPath("//button[contains(text(), 'Get Started')]");

        public readonly static By skipLinedIn = By.XPath("//a[contains(text(), 'SKIP')]");
        public readonly static By rightTick = By.XPath("//span[@class= 'fa-stack']");
        public readonly static By linkedInBtn = By.XPath("//button[@class='btn btn-block rt-btn--linkedin rt-btn--md']//img");////button[contains(@class, 'linkedin')]");
        public readonly static By linkedInBtnDisabled = By.XPath("//button[contains(@class, 'linkedin') and @disabled= 'disabled']");
        public readonly static By linkedInUserId = By.XPath("//input[@name= 'session_key']");
        public readonly static By linkedInPwd = By.XPath("//input[@name= 'session_password']");
        public readonly static By linkedInSignIn = By.XPath("//input[@name= 'signin']");

        public readonly static By letsRallyButtn = By.XPath("//a[@class='btn rt-btn rt-btn--l rt-btn--seagrass m-b-md']");

        public readonly static By signUpBtn = By.XPath("//div[@class='form-group']//div[@class='col-lg-12']//button[contains(@class,'btn btn-block m-t-xs rt-btn--md rt-btn')]");
        public readonly static By uploadResumeBtn = By.XPath("//button[contains(text(), 'Upload Your Resume')]");
        public readonly static By skipUploadResume = By.XPath("//a[contains(text(), 'SKIP')]");
        public readonly static By workDropDown = By.XPath("//select[@name= 'jobfunction']");
        public readonly static By continueBtn = By.XPath("//button[contains(text(), 'Continue')]");
        public readonly static By skillsDiv = By.XPath("//div[contains(@class, 'rt-tags-input-container')]");
        public readonly static By AllSkills = By.XPath("//ul[contains(@class, 'tag-list')]");
        public readonly static By continueSkillsBtn = By.XPath("//button[contains(text(), 'Continue')]");
        public readonly static By letsGetYouMatchedBtn = By.XPath("//button[@type='submit']");
        public readonly static By marketplace = By.XPath("//a[text()= 'MARKETPLACE']");
        public readonly static By skillNextBtn = By.XPath("//a[Contains(text(),'NEXT')]");
        //a[Contains(text(),'NEXT')]

        public readonly static By uploadedUserMessageDiv = By.XPath("//div[@class='rt-import-users-modal__three ng-scope']//div[@class='rt-round-modal__header text-center ng-binding']");




        /*-----For onboarding purpose-----*/
        public static By completeEmail(String variable)
        {
            return By.XPath("//div[contains(text(), '" + variable + "')]");
        }
        public readonly static By weJustSentYouAnEmail = By.XPath("//div[contains(text(), 'We just sent you an email to the following address:')]");
        public readonly static By goButton = By.XPath("//button[contains(text(), 'Go!')]");
        public readonly static By iframe = By.XPath("//iframe[@id= 'publicshowmaildivcontent']");
        public readonly static By verifyYourEmailBtn = By.XPath("//a[contains(text(),'Verify Your Email')]");
        //public readonly static By emailLink = By.XPath("//table[@class= 'twelve columns']//a[@class= 'need-a-link']");
        public readonly static By LetsGoBtn = By.XPath("//button[@type='submit']");
        public static By WelcomeUser(String variable)
        {
            return By.XPath("//div[contains(text(), 'Welcome " + variable + "!')]");
        }
        public readonly static By welcomeRallyTeam = By.XPath("//div[contains(text(), 'Welcome to Rallyteam!')]");
        public readonly static By expertiseDropDown = By.XPath("//select[@name= 'jobfunction']");
        public readonly static By continueExpertiseBtn = By.XPath("//button[contains(text(), 'Continue')]");
        public readonly static By inputSkills = By.XPath("//input[contains(@placeholder, 'Type in a skill or click on a skill below')]");
        public readonly static By viewMyProfileBtn = By.XPath("//button[text()= 'View My Profile']");
        public static By skillOne(String variable)
        {
            return By.XPath("//ul[@class= 'tag-list']//li[1]//span[contains(text(), '" + variable + "')]");
        }
        public static By skillTwo(String variable)
        {
            return By.XPath("//ul[@class= 'tag-list']//li[2]//span[contains(text(), '" + variable + "')]");
        }
        public readonly static By doneBtn = By.XPath("//button[contains(text(), 'Done')]");
        public readonly static By almostThere = By.XPath("//div[contains(text(), 'Almost there!')]");
        public readonly static By inputCodeOne = By.XPath("//div[@class= 'rt-authentication__input-group'][1]//input[1]");
        public readonly static By inputCodeTwo = By.XPath("//div[@class= 'rt-authentication__input-group'][1]//input[2]");
        public readonly static By inputCodeThree = By.XPath("//div[@class= 'rt-authentication__input-group'][1]//input[3]");
        public readonly static By inputCodeFour = By.XPath("//div[@class= 'rt-authentication__input-group'][2]//input[1]");
        public readonly static By inputCodeFive = By.XPath("//div[@class= 'rt-authentication__input-group'][2]//input[2]");
        public readonly static By inputCodeSix = By.XPath("//div[@class= 'rt-authentication__input-group'][2]//input[3]");
        public readonly static By letsRallyBtn = By.XPath("//a[text()= 'Let's Rally']");

        /*Harakiri elements*/
        public readonly static By harakiriInputEmail = By.XPath("//input[@id= 'inbox-name']");
        public readonly static By mailbBtn = By.XPath("//button[@id= 'getinbox']");
        public readonly static By harakiriEmailSender = By.XPath("//tbody[@id= 'mail_list_body']/tr[1]/td[contains(text(), '<noreply@rallyteam.com>')]");
        public readonly static By harakiriConfirmEmailSubject = By.XPath("//div[contains(text(), 'Confirm your email address on Rallyteam')]");
        public readonly static By harakiriInviteUserSubject = By.XPath("//div[contains(text(), 'welcomes you to our private talent marketplace')]");
        public readonly static By harakiriVerifyYourEmailBtn = By.XPath("//a[contains(text(),'Verify Your Email')]");
        //public readonly static By emailLink = By.XPath("//table[@class= 'twelve columns']//a[@class= 'need-a-link']");
        public readonly static By confirmationCode = By.XPath("//table[@class= 'twelve columns']//tbody/tr//td[1]//center[4]");
        public readonly static By emailGetStartedBtn = By.XPath("//a[contains(text(),'Get Started')]");
        public readonly static By signUpLink = By.XPath("//a[@class='col-xs-12']//span[@class='signup']");
        
        /*Create a Profile fields*/
        public readonly static By firstName = By.Name("firstName");
        public readonly static By lastName = By.Name("lastName");
        public readonly static By email = By.Name("email");
        public readonly static By availability = By.XPath("//span[contains(@class, 'rt-checkbox')]");
        public readonly static By hoursPerWeek = By.XPath("//input[contains(@placeholder, 'Enter your availability')]");
        public readonly static By title = By.Name("title");
        public readonly static By department = By.Name("department");
        public readonly static By codeCenter = By.XPath("(//th//strong)[2]");
        public readonly static By aboutMe = By.Name("bio"); ////ul[@class= 'tag-list'][1]//input[@placeholder= 'Add a tag'][4]
        public readonly static By myTopSkills = By.XPath("(//input[@class='input ng-pristine ng-untouched ng-valid'])[1]");
        public readonly static By otherSkills = By.XPath("(//input[@class='input ng-pristine ng-untouched ng-valid'])[2]");
        //public readonly static By industryDomainExpertise = By.XPath("//input[@placeholder= 'Add up to 3 tags']");
        public readonly static By languages = By.XPath("(//input[@class='input ng-pristine ng-untouched ng-valid'])[4]");
        public readonly static By devSkills = By.XPath("(//input[@class='input ng-pristine ng-untouched ng-valid'])[3]");
        public readonly static By linkedInUrl = By.Name("linkedInUrl");
        public readonly static By phone = By.Name("phone");
        public readonly static By address = By.Name("address");
        public readonly static By city = By.Name("city");
        public readonly static By stateProvince = By.Name("state");
        public readonly static By postalCode = By.Name("postalCode");
        public readonly static By country = By.Name("country");
        public readonly static By createBtn = By.XPath("//button[@value= 'Create']");
        public readonly static By cancelBtn = By.XPath("//a[contains(text(), 'Cancel')]");
        public static By addedUserName(string variable)
        {
            return By.XPath("//div[contains(text(), '"+variable+"')]");
        }

        public static By code(int i,int j)
        {
          
           return By.XPath("((//div[@class='rt-authentication__input-group'])["+i+"])//input["+j+"]");
           // return By.XPath("//div[contains(text(), '" + variable + "')]");
        }
    }
}
