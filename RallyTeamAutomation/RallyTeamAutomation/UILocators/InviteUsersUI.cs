using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace RallyTeam.UILocators
{
    public static class InviteUsersUI
    {
        public readonly static By inviteUserBtn = By.XPath("//button[contains(text(), 'Invite Users')]");
        public readonly static By letsExpandYourNetworkMsg = By.XPath("//div[contains(text(), 'Let's expand your network!')]");
        public readonly static By uploadMsg = By.XPath("//div[contains(text(), 'Upload your employees, external contractors, or contacts')]");
        public readonly static By closeIcon = By.XPath("//i[@class= 'fa fa-times']");
        public readonly static By mayBeLater = By.XPath("//div[contains(text(), 'MAYBE LATER')]");
        public readonly static By googleBtn = By.XPath("//a[contains(@class, 'google-btn')]");
        public readonly static By outlookBtn = By.XPath("//a[contains(@class, 'outlook-btn')]"); 
        public readonly static By csvBtn = By.XPath("//a[contains(@class, 'csv-btn')]");        
        public readonly static By emailBtn = By.XPath("//a[contains(@class, 'email-btn')]");
        public readonly static By emailAddressesInput = By.XPath("//div[@class= 'rt-round-modal__body']//textarea");
        public readonly static By sendInvitesBtn = By.XPath("//a[contains(text(), 'Send Invites')]");
        public readonly static By finishBtn = By.XPath("//a[contains(text(), 'Finish')]");
        public readonly static By emailSender = By.XPath("//div[contains(text(), 'noreply@rallyteam.com')]");
        public readonly static By emailSubject = By.XPath("//div[contains(text(), 'Confirm your email address on Rallyteam')]");
        public readonly static By letsRallyBtn = By.XPath("//a[contains(text(), 'Verify')]");

        public readonly static By skipLinedIn = By.XPath("//a[contains(text(), 'SKIP')]");
        public readonly static By uploadResumeMsg = By.XPath("//div[contains(text(), 'Would you like to upload your resume?')]");
        public readonly static By uploadResumeBtn = By.XPath("//button[contains(@class, 'resume')]");
        public readonly static By skipUploadResume = By.XPath("//a[contains(text(), 'SKIP')]");
        public readonly static By whatDoYouWorkIn = By.XPath("//div[contains(text(), 'What do you work in?')]");
        public readonly static By workDropDown = By.XPath("//select[@name= 'jobfunction']");
        public readonly static By continueBtn = By.XPath("//button[contains(text(), 'Continue')]");
        public readonly static By areTheseYourTopSkills = By.XPath("//div[contains(text(), 'Are these your top three skills?')]");
        public readonly static By skillsDiv = By.XPath("//div[contains(@class, 'rt-tags-input-container')]");
        public readonly static By AllSkills = By.XPath("//ul[contains(@class, 'tag-list')]");
        public readonly static By continueSkillsBtn = By.XPath("//button[contains(text(), 'Continue')]");
        public readonly static By whatAreYouInterestedInMsg = By.XPath("//div[contains(text(), 'What are you interested in?')]");
        public readonly static By interestsDiv = By.XPath("//div[contains(@class, 'rt-tags-input-container')]");
        public readonly static By interestsInput = By.XPath("//tags-input[@id= 'interested-skills']//input[contains(@class, 'input')]");
        public readonly static By letsGetYouMatchedBtn = By.XPath("//button[@type='submit']");
        public readonly static By marketplace = By.XPath("//a[text()= 'MARKETPLACE']");










    }
}
