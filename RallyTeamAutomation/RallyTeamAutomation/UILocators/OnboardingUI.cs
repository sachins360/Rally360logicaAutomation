using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace RallyTeam.UILocators
{
    public static class OnboardingUI
    {
        
        /*-----For onboarding purpose-----*/
        public static By completeEmail(String variable)
        {
            return By.XPath("//div[contains(text(), '" + variable + "')]");
        }
        public readonly static By weJustSentYouAnEmail = By.XPath("//div[contains(text(), 'We just sent you an email to the following address:')]");
        public readonly static By mailinatorInputEmail = By.XPath("//input[@id= 'inboxfield']");
        public readonly static By goButton = By.XPath("//button[contains(text(), 'Go!')]");
        public readonly static By emailSender = By.XPath("//td[contains(text(), 'Rallyteam')]");
        public readonly static By emailSubject = By.XPath("//div[contains(text(), '360logica invites you to our exclusive network')]");
        public readonly static By iframe = By.XPath("//iframe[@id= 'publicshowmaildivcontent']");
        public readonly static By verifyYourEmailBtn = By.XPath("//a[contains(text(),'Verify Your Email')]");
        //public readonly static By emailLink = By.XPath("//table[@class= 'twelve columns']//a[@class= 'need-a-link']");
        public readonly static By LetsGoBtn = By.XPath("//button[@type='submit']");
        public static By WelcomeUser(String variable)
        {
            return By.XPath("//div[contains(text(), 'Welcome " + variable + "!')]");
        }
        public readonly static By welcomeRallyTeam = By.XPath("//div[contains(text(), 'Welcome to Rallyteam!')]");
        public readonly static By getStartedBtn = By.XPath("//button[contains(text(), 'Get Started')]");
        public readonly static By linkedInConfirmationMsg = By.XPath("//div[contains(text(), 'Do you want to connect your LinkedIn profile?')]");
        public readonly static By linkedInBtn = By.XPath("//button[contains(@class, 'linkedinsso')]");
        public readonly static By linkedInNextBtn = By.XPath("//button[contains(text(), 'Next')]");
        public readonly static By skipLinedIn = By.XPath("//a[contains(text(), 'SKIP')]");
        public readonly static By uploadResumeMsg = By.XPath("//div[contains(text(), 'Would you like to upload your resume?')]");
        public readonly static By uploadResumeBtn = By.XPath("//button[contains(@class, 'resume')]");
        public readonly static By skipUploadResume = By.XPath("//a[contains(text(), 'SKIP')]");
        public readonly static By whatDoYouWorkIn = By.XPath("//div[contains(text(), 'What do you work in?')]");
        public readonly static By expertiseDropDown = By.XPath("//select[@name= 'jobfunction']");
        public readonly static By continueExpertiseBtn = By.XPath("//button[contains(text(), 'Continue')]");
        public readonly static By inputSkills = By.XPath("//input[contains(@placeholder, 'Type to add skills')]");
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
       
        public readonly static By harakiriRecruitedUserSubject = By.XPath("//div[contains(text(), 'great project for you in Rallyteam')]");
        public readonly static By harakiriInviteUserSubject = By.XPath("//div[contains(text(), 'welcomes you to our private talent marketplace')]");
        public readonly static By harakiriVerifyYourEmailBtn = By.XPath("//a[contains(text(),'Verify Your Email')]");
        //public readonly static By emailLink = By.XPath("//table[@class= 'twelve columns']//a[@class= 'need-a-link']");
        public readonly static By confirmationCode = By.XPath("//table[@class= 'twelve columns']//tbody/tr//td[1]//center[4]");
        

    }
}
