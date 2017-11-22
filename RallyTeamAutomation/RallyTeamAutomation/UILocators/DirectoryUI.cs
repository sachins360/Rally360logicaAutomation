using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RallyTeam.UILocators
{
    public static class DirectoryUI
    {
        public readonly static By directoryTab = By.XPath("//a[text()= 'DIRECTORY']");
        public readonly static By peopleTab = By.XPath("//a[contains(text(), 'People')]");
        public readonly static By vendorsTab = By.XPath("//a[contains(text(), 'Vendors')]");
        public readonly static By resetBtn = By.XPath("//button[text()= 'Reset']");
        public readonly static By searchDirectoryBox = By.XPath("//input[@placeholder='Search by name, skills or expertise...']");
        public readonly static By searchBtn = By.XPath("//button[text()= 'Search']");


        //Filters
        public readonly static By talentPoolFilter = By.XPath("(//div[@class= 'rt-directory__filters']//select)[1]");
        public readonly static By rolesFilter = By.XPath("(//div[@class= 'rt-directory__filters']//select)[2]");
        public readonly static By availableForFilter = By.XPath("(//div[@class= 'rt-directory__filters']//select)[3]");
        public readonly static By locationFilter = By.XPath("//input[@id= 'user-search-location']");
        public readonly static By endorsedByFilter = By.XPath("//input[@placeholder= 'Enter a name...']");
        public readonly static By locationVendorFilter = By.XPath("//input[@id= 'vendor-search-location']");

        //Results
        public static By userContainerUserName(String variable)
        {
            return By.XPath("//div[@class= 'rt-directory__results']//strong[contains(text(), '" + variable + "')]");
        }
        public static By vendorContainerVendorName(String variable)
        {
            return By.XPath("//div[contains(@class,'rt-user-container--vendor')]//strong[contains(text(), '" + variable + "')]");
        }
        public static By userContainerRoleName(String variable)
        {
            return By.XPath("//div[@class= 'rt-directory__results']//div[contains(text(), '" + variable+"')]");
        }
        public static By userContainerInitials(String variable)
        {
            return By.XPath("//div[@class= 'rt-user-container']//div[contains(text(), '" + variable + "')]");
        }
        public static By userContainerTitle(String variable)
        {
            return By.XPath("//div[@class= 'rt-user-container']//div[contains(text(), '" + variable + "')]");
        }
        public static By userContainerLocation(String variable)
        {
            return By.XPath("//div[@class= 'rt-user-container']//span[contains(text(), '" + variable + "')]");
        }
        public static By userContainerAvailability(String variable)
        {
            return By.XPath("//div[@class= 'rt-user-container']//div[contains(text(), '" + variable + "')]");
        }
        public static By userContainerSkills(String variable)
        {
            return By.XPath("//div[@class= 'rt-user-container']//span[contains(text(), '" + variable + "')]");
        }
        public readonly static By userContainerMessage = By.XPath("//span[text()= 'Message']");
        public readonly static By backToSearchResults = By.XPath("//a[contains(text(), 'Back to search results')]");
        public readonly static By emptyResult = By.XPath("//div[contains(text(), 'Oops... Looks like we have no results for that search!')]");
        public readonly static By messageConfirmation = By.XPath("//div[contains(text(), 'Your message was sent!')]");

        //Talent Pool
        public static By talentPoolFilterOption(String var)
        {
            return By.XPath("(//div[@class= 'rt-directory__filters']//select)[1]//option[@label='"+var+"']");
        }
        public readonly static By talentPoolPlusIcon = By.XPath("//a[contains(text(), 'Talent Pool')]");
        public readonly static By skillsTalentPool = By.XPath("//form[@name='talentPoolForm']//input[@placeholder= 'Enter skills...']");
        public readonly static By languagesTalentPool = By.XPath("//form[@name='talentPoolForm']//input[@placeholder= 'Enter languages...']");
        public readonly static By skillsToDevelopTalentPool = By.XPath("//form[@name='talentPoolForm']//input[@placeholder= 'Enter skills to develop...']");
        public readonly static By locationTalentPool = By.XPath("//form[@name='talentPoolForm']//input[@id= 'location']");
        public readonly static By departmentTalentPool = By.XPath("//form[@name='talentPoolForm']//input[@placeholder= 'Enter a department...']");
        public readonly static By titleTalentPool = By.XPath("//form[@name='talentPoolForm']//input[@placeholder= 'Enter a title...']");
        public readonly static By rolesTalentPool = By.XPath("(//form[@name='talentPoolForm']//select)[1]");
        public readonly static By availableForTalentPool = By.XPath("(//form[@name='talentPoolForm']//select)[2]");
        public readonly static By nameTalentPool = By.XPath("//form[@name='talentPoolForm']//input[@name= 'name']");
        public readonly static By saveBtnTalentPool = By.XPath("//a[contains(text(), 'Save')]");
        public readonly static By privateTalentPool = By.XPath("//form[@name='talentPoolForm']//div[contains(@class, 'col-xs')]/span[2]//input");
        public readonly static By editTalentPool = By.XPath("//a[text()= 'Edit Talent Pool']");
        public readonly static By deleteTalentPool = By.XPath("//div[@class= 'modal-content']//i[@class= 'fa fa-trash']");
        public readonly static By deleteTalentPoolYesBtn = By.XPath("//a[text()= 'Yes']");

        public readonly static By messageBtn = By.XPath("//a[text() ='Message']");
        public readonly static By viewProfileBtn = By.XPath("//a[text() ='View Profile']");
        public readonly static By sendMsgWindowOld = By.XPath("//h4[contains(text(), 'Send a Message')]");
        public readonly static By newMessageWindow = By.XPath("//div[contains(text(), 'New Message')]");
        public readonly static By msgTextAera = By.XPath("//div[@class='modal-content']//textarea[@name ='body']");
        public readonly static By sendMessageBtn = By.XPath("//button[text() ='Send']");
        public readonly static By messageConversationWindow = By.XPath("//div[text() ='Message Conversation']");
        public static By messagePosted(String variable)
        {
            return By.XPath("//div[contains(text(), '" + variable + "')]");
        }

        //Advance Search
        public readonly static By name = By.Name("location");
        public readonly static By skillsNeeded = By.XPath("//input[@placeholder= 'What skills are you looking for?']");
        public readonly static By jobFunction = By.XPath("//input[@placeholder= 'What job positions are you looking for?']");
        public readonly static By location = By.XPath("//input[@placeholder= 'I am looking for people in these locations...']");
        public readonly static By advSearchIndustryDomain = By.XPath("//tags-input[contains(@placeholder, 'looking for experts in these industries or domains')]");
        public readonly static By endorsedBy = By.XPath("//input[@placeholder= 'I am looking for people who were endorsed by...']");
        public readonly static By availability = By.XPath("//div[@class= 'row m-b-sm']//div[1]//select");
        public readonly static By type = By.XPath("//div[@class= 'row m-b-sm']//div[2]//select");

        //User Profile
        public static By userName(String variable)
        {
            return By.XPath("//div[contains(@class, 'rt-user-profile__details__name') and contains(text(), '" + variable + "')]");
        }
        public readonly static By topSkills = By.XPath("//div[text() ='Top Skills']");
        public readonly static By userProfileMessageBtn = By.XPath("//button[text() ='Message']");
        public readonly static By aboutMe = By.XPath("//div[text() ='About Me']");
        public readonly static By skillsANdEndorsements = By.XPath("//div[contains(text(), 'Skills')]");
        public readonly static By industryDomain = By.XPath("//div[text() ='Industry/Domain Expertise']");
        public readonly static By languages = By.XPath("//div[text() ='Languages']");
        public readonly static By developmentSkills = By.XPath("//div[text() ='Skills To Develop']");
        public readonly static By projects = By.XPath("//div[text() ='Projects']");
        public readonly static By topSkillName = By.XPath("//div[contains(@class, 'rt-user-profile__basic-info')]/span");
        public readonly static By topSkillCount = By.XPath("//div[contains(@class, 'rt-user-profile__basic-info')]/span/a");
        public static By increasedTopSkillCount(string variable)
        {
            return By.XPath("//div[contains(@class, 'rt-user-profile__basic-info')]/span/a[text()= '" + variable + "']");
        }

        //Endorse User fields
        public readonly static By endorseBtn = By.XPath("//button[@type= 'button' and text()= 'Endorse']");
        public readonly static By projectTitle = By.XPath("//input[@placeholder= 'Select or type in your project title']");
        public readonly static By projectDesc = By.XPath("//textarea[@placeholder= 'Enter a description of the project']");
        //public readonly static By awesome = By.XPath("//div[contains(@class, 'awesome')]");
        public readonly static By awesome = By.XPath("//div[contains(@class, 'text-center')]//div[@tooltip='Awesome']");
        public readonly static By good = By.XPath("//div[@class='text-center']//div[@tooltip='Good']");
        public readonly static By notGood = By.XPath("//div[@class='text-center']//div[@tooltip='Not good']");
        //public readonly static By notGood = By.XPath("//div[contains(@class, 'not-good')]");
        public readonly static By projectFeedback = By.XPath("//textarea[@name= 'feedback']");
        public readonly static By skills = By.XPath("//input[@placeholder= '+ add skills']");
        public readonly static By endorsementCount = By.XPath("//div[@class= 'ng-hide']//div[@class= 'row m-t-xs ng-scope']//div[2]");
        public readonly static By endorseUserBtn = By.XPath("//div[3]/button");
        //public readonly static By projectDropDown = By.XPath("//select[@id= 'rt-selectedProject']");
        public readonly static By projectDropDown = By.XPath("//select[@id='rt-selectedProject']");
        

        //Request feedback fields
        public readonly static By requestFeedbackBtn = By.XPath("//button[text()= 'Request Feedback']");
        public readonly static By requestFeedbackProject = By.XPath("//select[@name= 'selectProject']");
        public readonly static By feedbackFrom = By.XPath("//input[@placeholder= 'Type a name or email']");
        public readonly static By optionalMessage = By.XPath("//textarea");
        public readonly static By sendBtn = By.XPath("//button[text()= 'Send']");
        
    }
}
