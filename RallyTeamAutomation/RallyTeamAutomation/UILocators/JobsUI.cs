using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RallyTeam.UILocators
{
    public static class JobsUI
    {
        //Input Fields
        public readonly static By reqIdInput = By.XPath("//input[@name= 'reqId']");
        public readonly static By typeSelect = By.XPath("(//select)[1]");
        public readonly static By statusSelect = By.XPath("(//select)[2]");
        public readonly static By titleInput = By.XPath("//input[@id= 'title']");
        public readonly static By categoryInput = By.XPath("//input[@id= 'category']");
        public readonly static By levelInput = By.XPath("//input[@id= 'level']");
        public readonly static By hiringMangerCrossIcon = By.XPath("//a[contains(@class, 'remove-button')]");
        public readonly static By hiringMangerInput = By.XPath("//input[@placeholder= 'Enter a name...']");
        public readonly static By teamInput = By.XPath("//input[@id= 'team']");
        public readonly static By locationInput = By.XPath("//input[@id= 'location']");
        public readonly static By remoteCheckbox = By.XPath("(//span[contains(@class, 'rt-checkbox')])[1]");
        public readonly static By onsiteCheckbox = By.XPath("(//span[contains(@class, 'rt-checkbox')])[2]");
        public readonly static By startDateInput = By.XPath("//input[@placeholder= 'Start Date']");
        public readonly static By jobDescInput = By.XPath("//span[@class= 'fr-placeholder' and text()='Please add a job description...']");
        public readonly static By reqQualificationInput = By.XPath("//span[@class= 'fr-placeholder' and text()='Enter the required qualifications you need from candidates']");
        public readonly static By desiredQualificationInput = By.XPath("//span[@class= 'fr-placeholder' and text()='Enter any desired qualifications you would like to see from candidates']");
        public readonly static By reqSkillsInput = By.XPath("//input[@placeholder='+ Add skills']");
        public readonly static By saveDraftBtn = By.XPath("//a[text()= 'Save Draft']");
        public readonly static By nextBtn = By.XPath("//a[text()= 'Next']");
        public readonly static By publishBtn = By.XPath("//a[text()= 'Publish']");

        //Job About Page
        public readonly static By jobSettings = By.XPath("//div[contains(@class, 'rt-job-actions')]//button");
        public static By jobSettingsOptions(string variable)
        {
            return By.XPath("//div[contains(@class, 'rt-job-actions')]//a[contains(text(), '" + variable + "')]");
        }
        public static By JobTitleAboutPage(String variable)
        {
            return By.XPath("//div[contains(@class, 'job__title') and text()='" + variable + "']");
        }
        public static By JobStatusAboutPage(String variable)
        {
            return By.XPath("//span[contains(@class, 'rt-job__status') and text()='" + variable + "']");
        }
        public static By JobLocationAboutPage(String variable)
        {
            return By.XPath("//span[text()='" + variable + "']");
        }
        public static By JobDescAboutPage(String variable)
        {
            return By.XPath("//p[text()='" + variable + "']");
        }
        public static By JobHiringManagerAboutPage(String variable)
        {
            return By.XPath("//a[text()='" + variable + "']");
        }
        public static By JobTeamAboutPage(String variable)
        {
            return By.XPath("//div[text()='" + variable + "']");
        }
        public static By JobLevelAboutPage(String variable)
        {
            return By.XPath("//div[text()='" + variable + "']");
        }
        public static By JobTypeAboutPage(String variable)
        {
            return By.XPath("//div[text()='" + variable + "']");
        }
        public static By JobStaffingOnsiteAboutPage(String variable)
        {
            return By.XPath("//span[contains(text(), '" + variable + "')]");
        }
        public static By JobStaffingRemoteAboutPage(String variable)
        {
            return By.XPath("//span[contains(text(), '" + variable + "')]");
        }
        public static By JobCategoryAboutPage(String variable)
        {
            return By.XPath("//div[text()='" + variable + "']");
        }
        public static By JobRequirementIdAboutPage(String variable)
        {
            return By.XPath("//div[text()='" + variable + "']");
        }
        public static By JobReqSkillsAboutPage(String variable)
        {
            return By.XPath("//a[contains(text(), '" + variable + "')]");
        }
        public static By JobReqQualificationsAboutPage(String variable)
        {
            return By.XPath("//p[text()='" + variable + "']");
        }
        public static By JobDesiredQualificationsAboutPage(String variable)
        {
            return By.XPath("//p[text()='" + variable + "']");
        }
        public readonly static By imInterestedBtn = By.XPath("//a[contains(text(), 'Interested')]");
        public readonly static By interestedBtn = By.XPath("//a[contains(text(), 'Interested') and @disabled='disabled']");
        public readonly static By editSaveBtn = By.XPath("//a[text()= 'Save']");
        public readonly static By promoteBtn = By.XPath("//button[text()= 'Promote']");




        //Mailinator Elements
        public readonly static By mailinatorInputEmail = By.XPath("//input[@id= 'inboxfield']");
        public readonly static By mailinatorJobInviteSubject = By.XPath("(//div[contains(text(), 'There is a new job opportunity available on the')])[1]");
        public readonly static By mailinatorJobInviteViewJobBtn = By.XPath("//a[contains(text(), 'View Job')]");
        public static By mailinatorJobTitle(String var)
        {
            return By.XPath("//b[contains(text(), '" + var + "')]");
        }

















    }
}
