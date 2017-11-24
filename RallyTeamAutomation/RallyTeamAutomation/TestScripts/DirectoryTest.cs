using NUnit.Framework;
using RallyTeam.UILocators;
using RallyTeam.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace RallyTeam.TestScripts
{
    [TestFixture("ExternalStormURL", "chrome", Category = "DirectoryChromePreprod")]
    [TestFixture("ExternalStormURL", "firefox", Category = "DirectoryFirefoxPreprod")]
    [TestFixture("ExternalStormURL", "ie", Category = "DirectoryIEPreprod")]
    [TestFixture("Production", "chrome", Category = "DirectoryChromeProduction")]
    [TestFixture("Production", "firefox", Category = "DirectoryFirefoxProduction")]
    [Parallelizable(ParallelScope.Fixtures)]
    public class DirectoryTest : BaseTestES
    {
        public DirectoryTest(string urlKey, string Browser) : base(urlKey, Browser)
        {
            String url = urlKey;
            String b = Browser;
        }

        static ReadData readDirectory = new ReadData("Directory");
        static ReadData readUserProfile = new ReadData("UserProfile");
        
        //SignIn
        private void SignInDifferentUser(String userName, String password)
        {
            authenticationPage.SetUserName(userName);
            authenticationPage.SetPassword(password);
            authenticationPage.ClickOnLoginButton();
        }

        //Delete Project
        public void DeleteProject()
        {
            //Click Settings Icon
            postProjectPage.ClickSettingsIcon();
            log.Info("Click Settings Icon");
            Thread.Sleep(3000);

            //Select Project Settings Option
            postProjectPage.SelectProjectOption("Delete Project");
            log.Info("Select Delete Project option.");
            Thread.Sleep(3000);

            //Press Delete Project Window Yes button
            postProjectPage.PressDeleteProjectWindowYesBtn();
            log.Info("Press Delete Project Window Yes button.");
        }

        //Delete Talent Pool
        public void DeleteTalentPool()
        {
            //Click Edit Talent Pool link
            commonPage.ScrollUp();
            Thread.Sleep(1000);
            directoryPage.ClickEditTalentPool();
            log.Info("Click Edit Talent Pool link");
            Thread.Sleep(3000);

            //Click Delete Talent Pool icon
            commonPage.ScrollDown();
            Thread.Sleep(2000);
            directoryPage.ClickDeleteTalentPool();
            log.Info("Click Delete Talent Pool icon");
            Thread.Sleep(3000);

            //Click Delete Talent Pool Yes button
            directoryPage.ClickDeleteTalentPoolYesBtn();
            log.Info("Press Delete Project Window Yes button.");
        }

        //Post a Project
        public void PostNewProject(String projectName)
        {
            //Click Post Project tab
            Thread.Sleep(3000);
            postProjectPage.ClickPostProject();
            Thread.Sleep(5000);

            //Enter the Project Name
            postProjectPage.EnterProjectName(projectName);
            Thread.Sleep(1000);

            //Enter the Project Description
            commonPage.PressTabKey();
            Thread.Sleep(2000);
            String projectDesc = readDirectory.GetValue("AddProjectDetails", "projectDesc");
            postProjectPage.EnterProjectDescription(projectDesc);
            Thread.Sleep(1000);

            //Click Continue Button
            postProjectPage.ClickContinueBtn();
            log.Info("Click on the Continue button.");
            Thread.Sleep(5000);

            //Enter Skills
            commonPage.ScrollUp();
            String skills = readDirectory.GetValue("AddProjectDetails", "skills");
            postProjectPage.EnterSkillsNeeded(skills);
            Thread.Sleep(3000);
            commonPage.PressEnterKey();
            Thread.Sleep(2000);
            log.Info("Enter Skills.");

            String addMembersEmail = readDirectory.GetValue("AddProjectDetails", "memberEmail");
            List<String> addMembersEmailList = addMembersEmail.Split(',').ToList();
            int noOfMember = addMembersEmailList.Count;
            foreach (String value in addMembersEmailList)
            {
                postProjectPage.EnterMemberName(value);
                Thread.Sleep(2000);
                commonPage.PressEnterKey();
                Thread.Sleep(5000);
                postProjectPage.ClickAddBtn();
                log.Info("Click Add button.");
                Thread.Sleep(3000);
            }

            //Click Continue Button
            postProjectPage.ClickContinueBtn();
            log.Info("Click on the Continue button.");
            Thread.Sleep(10000);

            //Click Publish button
            commonPage.ScrollDown();
            Thread.Sleep(2000);
            postProjectPage.ClickPublishBtn();
            log.Info("Click Publish Button");
            Thread.Sleep(7000);
        }

        private int getIndexofNumber(string cell)
        {
            int indexofNum = -1;
            foreach (char c in cell)
            {
                indexofNum++;
                if (Char.IsDigit(c))
                {
                    return indexofNum;
                }
            }
            return indexofNum;
        }

        [Test, CustomRetry(2)]
        public void Directory_001_VerifyDirectoryPage()
        {
            //Click Directory Tab
            Thread.Sleep(2000);
            directoryPage.ClickDirectoryTab();
            log.Info("Click the Directory tab.");
            Thread.Sleep(3000);

            //Verify Search Box
            directoryPage.VerifySearchBox();
            log.Info("Verify the Search Box on Directory tab.");

            //Verify Search Button
            directoryPage.VerifySearchBtn();
            log.Info("Verify the Search Button on Directory tab.");

            //Verify Talent Pool Filter
            directoryPage.VerifyTalentPoolFilter();
            log.Info("Verify the Talent Pool Filter on Peoples tab.");

            //Verify Roles Filter
            directoryPage.VerifyRolesFilter();
            log.Info("Verify the Roles Filter on Peoples tab.");

            //Verify Available For Filter
            directoryPage.VerifyAvailableForFilter();
            log.Info("Verify the Available For Filter on Peoples tab.");

            //Verify Location Filter
            directoryPage.VerifyLocationFilter();
            log.Info("Verify the Location Filter on Peoples tab.");

            //Verify Endorsed By Filter
            commonPage.ScrollDown();
            Thread.Sleep(1000);
            directoryPage.VerifyEndorsedByFilter();
            log.Info("Verify the Endorsed By Filter on Peoples tab.");

            //Verify Reset Button
            directoryPage.VerifyResetBtn();
            log.Info("Verify the Reset button on Directory tab.");

            //Click Vendors tab
            commonPage.ScrollUp();
            Thread.Sleep(1000);
            directoryPage.ClickVendorsTab();
            log.Info("Click Vendors tab.");
            Thread.Sleep(3000);

            //Verify Vendor Location Filter
            directoryPage.VerifyVendorLocationFilter();
            log.Info("Verify the Vendor Location Filter on Vendors tab.");
        }

        [Test, CustomRetry(2)]
        public void Directory_002_SearchPeopleByNameAndMetadata()
        {
            //Click Directory Tab
            Thread.Sleep(2000);
            directoryPage.ClickDirectoryTab();
            log.Info("Click the Directory tab.");
            Thread.Sleep(3000);

            //Enter user name 
            String userName = "bob lawson";
            directoryPage.EnterSearchBox(userName);
            log.Info("Enter the Search text on the main search box.");
            Thread.Sleep(1000);

            //Click Search button
            directoryPage.ClickSearchBtn();
            log.Info("Click on the Search button on the main page");
            Thread.Sleep(5000);

            //Verify User container User Name is displayed
            directoryPage.VerifyUserContainerUserName(userName);
            log.Info("Verify searched user is displayed.");
            Thread.Sleep(1000);

            //Enter Title 
            String title = "bobTitle";
            directoryPage.EnterSearchBox(title);
            log.Info("Enter Title on the main search box.");
            Thread.Sleep(1000);

            //Click Search button
            directoryPage.ClickSearchBtn();
            log.Info("Click on the Search button on the main page");
            Thread.Sleep(5000);

            //Verify User container User Name is displayed
            directoryPage.VerifyUserContainerUserName(userName);
            log.Info("Verify searched user is displayed.");
            Thread.Sleep(1000);

            //Enter Department 
            String department = "QCT";
            directoryPage.EnterSearchBox(department);
            log.Info("Enter Department on the main search box.");
            Thread.Sleep(1000);

            //Click Search button
            directoryPage.ClickSearchBtn();
            log.Info("Click on the Search button on the main page");
            Thread.Sleep(5000);

            //Verify User container User Name is displayed
            directoryPage.VerifyUserContainerUserName(userName);
            log.Info("Verify searched user is displayed.");

            //Enter Top Skill 
            String topSkill = "FilterBob";
            directoryPage.EnterSearchBox(topSkill);
            Thread.Sleep(2000);
            commonPage.PressEnterKey();
            log.Info("Enter Top Skill on the main search box.");
            Thread.Sleep(1000);

            //Click Search button
            directoryPage.ClickSearchBtn();
            log.Info("Click on the Search button on the main page");
            Thread.Sleep(2000);

            //Verify User container User Name is displayed
            directoryPage.VerifyUserContainerUserName(userName);
            log.Info("Verify searched user is displayed.");

            //Enter Other Skill 
            String otherSkill = "Bob Top";
            directoryPage.EnterSearchBox(otherSkill);
            Thread.Sleep(2000);
            commonPage.PressEnterKey();
            log.Info("Enter Other Skill on the main search box.");
            Thread.Sleep(1000);

            //Click Search button
            directoryPage.ClickSearchBtn();
            log.Info("Click on the Search button on the main page");
            Thread.Sleep(5000);

            //Verify User container User Name is displayed
            directoryPage.VerifyUserContainerUserName(userName);
            log.Info("Verify searched user is displayed.");

            //Enter Language 
            String language = "Hindi";
            directoryPage.EnterSearchBox(language);
            Thread.Sleep(2000);
            commonPage.PressEnterKey();
            log.Info("Enter Language on the main search box.");
            Thread.Sleep(1000);

            //Click Search button
            directoryPage.ClickSearchBtn();
            log.Info("Click on the Search button on the main page");
            Thread.Sleep(5000);

            //Verify User container User Name is displayed
            directoryPage.VerifyUserContainerUserName(userName);
            log.Info("Verify searched user is displayed.");
        }

        [Test, CustomRetry(2)]
        public void Directory_003_SearchUserByRolesFilter()
        {
            //Click Directory Tab
            Thread.Sleep(2000);
            directoryPage.ClickDirectoryTab();
            log.Info("Click the Directory tab.");
            Thread.Sleep(3000);

            //Select Role
            String userName = "Aa Directory";
            String roleName = "AUTOMATION_ROLE";
            directoryPage.SelectRolesFilter(roleName);
            log.Info("Select the Roles Filter.");
            Thread.Sleep(1000);

            //Click Search button
            directoryPage.ClickSearchBtn();
            log.Info("Click on the Search button on the main page");
            Thread.Sleep(5000);

            //Verify User container User Name is displayed
            directoryPage.VerifyUserContainerUserName(userName);
            log.Info("Verify searched user is displayed.");
            Thread.Sleep(1000);
        }

        [Test, CustomRetry(2)]
        public void Directory_004_SearchUserByAvailableForFilter()
        {
            //Click Directory Tab
            Thread.Sleep(2000);
            directoryPage.ClickDirectoryTab();
            log.Info("Click the Directory tab.");
            Thread.Sleep(3000);

            //Select Available For
            String userName = "Aa Directory";
            String availableFor = "Short Term Project";
            directoryPage.SelectAvailableForFilter(availableFor);
            log.Info("Select the Available For Filter.");
            Thread.Sleep(1000);

            //Click Search button
            directoryPage.ClickSearchBtn();
            log.Info("Click on the Search button on the main page");
            Thread.Sleep(5000);

            //Verify User container User Name is displayed
            directoryPage.VerifyUserContainerUserName(userName);
            log.Info("Verify searched user is displayed.");
            Thread.Sleep(1000);
        }

        [Test, CustomRetry(2)]
        public void Directory_005_SearchUserByLocationFilter()
        {
            //Click Directory Tab
            Thread.Sleep(2000);
            directoryPage.ClickDirectoryTab();
            log.Info("Click the Directory tab.");
            Thread.Sleep(3000);

            //Enter Location
            String userName = "bob lawson";
            String location = "Singapore";
            commonPage.HalfScrollDown(500);
            Thread.Sleep(1000);
            directoryPage.EnterLocationFilter(location);
            Thread.Sleep(2000);
            commonPage.PressDownArrowKey();
            Thread.Sleep(1000);
            commonPage.PressEnterKey();
            log.Info("EnterLocation.");
            Thread.Sleep(5000);

            //Verify User container User Name is displayed
            commonPage.ScrollUp();
            Thread.Sleep(1000);
            directoryPage.VerifyUserContainerUserName(userName);
            log.Info("Verify searched user is displayed.");
            Thread.Sleep(1000);
        }

        [Test, CustomRetry(2)]
        public void Directory_006_SearchUserByEndorsedBy()
        {
            //Click Directory Tab
            Thread.Sleep(2000);
            directoryPage.ClickDirectoryTab();
            log.Info("Click the Directory tab.");
            Thread.Sleep(3000);

            //Enter Endorsed By
            String userName = "bob lawson";
            String endorsedBy = "ammark@360logica.com";
            commonPage.HalfScrollDown(500);
            Thread.Sleep(1000);
            directoryPage.EnterEndorsedByFilter(endorsedBy);
            Thread.Sleep(2000);
            commonPage.PressDownArrowKey();
            Thread.Sleep(1000);
            commonPage.PressEnterKey();
            log.Info("Enter Endorsed By.");
            Thread.Sleep(5000);

            //Verify User container User Name is displayed
            commonPage.ScrollUp();
            Thread.Sleep(1000);
            directoryPage.VerifyUserContainerUserName(userName);
            log.Info("Verify searched user is displayed.");
            Thread.Sleep(1000);
        }

        [Test, CustomRetry(2)]
        public void Directory_007_SearchUserByAllFilters()
        {
            //Click Directory Tab
            Thread.Sleep(2000);
            directoryPage.ClickDirectoryTab();
            log.Info("Click the Directory tab.");
            Thread.Sleep(3000);

            //Enter user name 
            String userName = "bob lawson";
            directoryPage.EnterSearchBox(userName);
            log.Info("Enter the Search text on the main search box.");
            Thread.Sleep(1000);

            //Select Role
            String roleName = "Employee";
            directoryPage.SelectRolesFilter(roleName);
            log.Info("Select the Roles Filter.");
            Thread.Sleep(1000);

            //Select Available For
            String availableFor = "Regression Project";
            directoryPage.SelectAvailableForFilter(availableFor);
            log.Info("Select the Available For Filter.");
            Thread.Sleep(1000);

            //Enter Location
            String location = "Singapore";
            commonPage.HalfScrollDown(500);
            Thread.Sleep(1000);
            directoryPage.EnterLocationFilter(location);
            Thread.Sleep(2000);
            commonPage.PressDownArrowKey();
            Thread.Sleep(1000);
            commonPage.PressEnterKey();
            log.Info("EnterLocation.");
            Thread.Sleep(5000);

            //Enter Endorsed By
            String endorsedBy = "ammark@360logica.com";            
            directoryPage.EnterEndorsedByFilter(endorsedBy);
            Thread.Sleep(2000);
            commonPage.PressDownArrowKey();
            Thread.Sleep(1000);
            commonPage.PressEnterKey();
            log.Info("Enter Endorsed By.");
            Thread.Sleep(5000);

            //Verify User container User Name is displayed
            commonPage.ScrollUp();
            Thread.Sleep(1000);
            directoryPage.VerifyUserContainerUserName(userName);
            log.Info("Verify searched user is displayed.");
            Thread.Sleep(1000);
        }

        [Test, CustomRetry(2)]
        public void Directory_008_VerifyUserCard()
        {
            //Click Directory Tab
            Thread.Sleep(2000);
            directoryPage.ClickDirectoryTab();
            log.Info("Click the Directory tab.");
            Thread.Sleep(3000);

            //Enter user name 
            String userName = "bob lawson";
            directoryPage.EnterSearchBox(userName);
            log.Info("Enter the Search text on the main search box.");
            Thread.Sleep(1000);

            //Click Search button
            directoryPage.ClickSearchBtn();
            log.Info("Click on the Search button on the main page");
            Thread.Sleep(5000);

            //Verify User container User Name is displayed
            commonPage.ScrollUp();
            Thread.Sleep(1000);
            directoryPage.VerifyUserContainerUserName(userName);
            log.Info("Verify searched user is displayed.");

            //Verify User container Role Name is displayed
            Thread.Sleep(3000);
            directoryPage.VerifyUserContainerRoleName("Employee");
            log.Info("Verify searched user Role Name is displayed.");

            //Verify User container Initials are displayed
            directoryPage.VerifyUserContainerInitials("bl");
            log.Info("Verify searched user Initials are displayed.");

            //Verify User container Title is displayed
            directoryPage.VerifyUserContainerTitle("bobTitle");
            log.Info("Verify searched user Title is displayed.");

            //Verify User container Location is displayed
            directoryPage.VerifyUserContainerLocation("Singapore");
            log.Info("Verify searched user Location is displayed.");

            //Verify User container Skills is displayed
            directoryPage.VerifyUserContainerSkills("Testing");
            log.Info("Verify searched user Skills is displayed.");

            //Verify User container Message Icon is displayed
            directoryPage.VerifyUserContainerMessage();
            log.Info("Verify searched user Message Icon is displayed.");
        }

        [Test, CustomRetry(2)]
        public void Directory_009_ClickUserCardAndReturn()
        {
            //Click Directory Tab
            Thread.Sleep(2000);
            directoryPage.ClickDirectoryTab();
            log.Info("Click the Directory tab.");
            Thread.Sleep(3000);

            //Enter user name 
            String userName = "bob lawson";
            directoryPage.EnterSearchBox(userName);
            log.Info("Enter the Search text on the main search box.");
            Thread.Sleep(1000);

            //Click Search button
            directoryPage.ClickSearchBtn();
            log.Info("Click on the Search button on the main page");
            Thread.Sleep(5000);

            //Click User Name
            directoryPage.ClickUserContainerUserName(userName);
            log.Info("Click on the User Name");
            Thread.Sleep(5000);

            //Click Back to search results
            directoryPage.ClickBackToSearchResults();
            log.Info("Click on Back to search results");
            Thread.Sleep(5000);

            //Verify User container User Name is displayed
            directoryPage.VerifyUserContainerUserName(userName);
            log.Info("Verify searched user is displayed.");
        }

        [Test, CustomRetry(2)]
        public void Directory_010_SearchInvalidData()
        {
            //Click Directory Tab
            Thread.Sleep(2000);
            directoryPage.ClickDirectoryTab();
            log.Info("Click the Directory tab.");
            Thread.Sleep(3000);

            //Enter Invalid Search Content             
            directoryPage.EnterSearchBox("78345ghgjfdsf");
            log.Info("Enter the Search text on the main search box.");
            Thread.Sleep(1000);

            //Click Search button
            directoryPage.ClickSearchBtn();
            log.Info("Click on the Search button on the main page");


            //Verify empty page is displayed on People Tab
            directoryPage.VerifyEmptyPageMessage();
            log.Info("Verify empty page is displayed on People Tab");

            //Click Vendors tab
            directoryPage.ClickVendorsTab();
            log.Info("Click Vendors tab.");
            Thread.Sleep(3000);

            //Verify emoty page is displayed on People Tab
            directoryPage.VerifyEmptyPageMessage();
            log.Info("Verify empty page is displayed on People Tab");
        }

        [Test, CustomRetry(2)]
        public void Directory_011_SearchVendorByNameAndMetadata()
        {
            //Click Directory Tab
            Thread.Sleep(2000);
            directoryPage.ClickDirectoryTab();
            log.Info("Click the Directory tab.");
            Thread.Sleep(3000);

            //Click Vendors tab
            directoryPage.ClickVendorsTab();
            log.Info("Click Vendors tab.");
            Thread.Sleep(3000);

            //Enter Vendor name 
            String vendorName = "Captain";
            directoryPage.EnterSearchBox(vendorName);
            log.Info("Enter the Search text on the main search box.");
            Thread.Sleep(1000);

            //Click Search button
            directoryPage.ClickSearchBtn();
            log.Info("Click on the Search button on the main page");
            Thread.Sleep(5000);

            //Verify Vendor container Vendor Name is displayed
            directoryPage.VerifyVendorContainerVendorName(vendorName);
            log.Info("Verify searched vendor is displayed.");

            //Enter Owner Name 
            String ownerName = "Steve Smith";
            directoryPage.EnterSearchBox(ownerName);
            log.Info("Enter Owner Name on the main search box.");
            Thread.Sleep(1000);

            //Click Search button
            directoryPage.ClickSearchBtn();
            log.Info("Click on the Search button on the main page");
            Thread.Sleep(5000);

            //Verify Vendor container Vendor Name is displayed
            directoryPage.VerifyVendorContainerVendorName(vendorName);
            log.Info("Verify searched vendor is displayed.");

            //Enter Skills 
            String skills = "Banking";
            directoryPage.EnterSearchBox(skills);
            log.Info("Enter Skills on the main search box.");
            Thread.Sleep(1000);

            //Click Search button
            directoryPage.ClickSearchBtn();
            log.Info("Click on the Search button on the main page");
            Thread.Sleep(5000);

            //Verify Vendor container Vendor Name is displayed
            directoryPage.VerifyVendorContainerVendorName(vendorName);
            log.Info("Verify searched vendor is displayed.");
        }

        [Test, CustomRetry(2)]
        public void Directory_012_SearchVendorByLocationFilter()
        {
            //Click Directory Tab
            Thread.Sleep(2000);
            directoryPage.ClickDirectoryTab();
            log.Info("Click the Directory tab.");
            Thread.Sleep(3000);

            //Click Vendors tab
            directoryPage.ClickVendorsTab();
            log.Info("Click Vendors tab.");
            Thread.Sleep(3000);

            //Enter Vendors Location
            String vendorName = "Captain";
            String location = "Noida";
            directoryPage.EnterVendorLocationFilter(location);
            Thread.Sleep(2000);
            commonPage.PressDownArrowKey();
            Thread.Sleep(1000);
            commonPage.PressEnterKey();
            log.Info("Enter Location.");
            Thread.Sleep(5000);

            //Verify Vendor container Vendor Name is displayed
            directoryPage.VerifyVendorContainerVendorName(vendorName);
            log.Info("Verify searched vendor is displayed.");
        }


        [Test, CustomRetry(2)]
        public void Directory_013_SendMessageAndVerify()
        {
            //Click Directory Tab
            Thread.Sleep(2000);
            directoryPage.ClickDirectoryTab();
            log.Info("Click the Directory tab.");
            Thread.Sleep(3000);

            //Enter user name 
            String userName = "bob lawson";
            directoryPage.EnterSearchBox(userName);
            log.Info("Enter the Search text on the main search box.");
            Thread.Sleep(1000);

            //Click Search button
            directoryPage.ClickSearchBtn();
            log.Info("Click on the Search button on the main page");
            Thread.Sleep(5000);

            //Click Message button
            directoryPage.ClickUserContainerMessage();
            log.Info("Click on Message Link.");
            Thread.Sleep(3000);           

            //Enter message in the text area
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(4));
            String message = "Hi User ";
            message = message + builder;
            directMessagingPage.EnterTextArea(message);
            log.Info("Enter the message.");
            Thread.Sleep(2000);

            //Click Send button
            directMessagingPage.ClickSendBtn();
            log.Info("Click Send button.");
            Thread.Sleep(2000);

            //Verify Message is sent confirmation message
            directoryPage.VerifyUserConfirmationMessage();
            log.Info("Verify confirmaion message.");

            //Click Vendors tab
            directoryPage.ClickVendorsTab();
            log.Info("Click Vendors tab.");
            Thread.Sleep(3000);

            //Enter Vendor name 
            String vendorName = "Captain";
            directoryPage.EnterSearchBox(vendorName);
            log.Info("Enter the Search text on the main search box.");
            Thread.Sleep(1000);

            //Click Search button
            directoryPage.ClickSearchBtn();
            log.Info("Click on the Search button on the main page");
            Thread.Sleep(5000);

            //Click Message button
            directoryPage.ClickUserContainerMessage();
            log.Info("Click on Message Link.");
            Thread.Sleep(3000);

            //Enter message in the text area            
            directMessagingPage.EnterTextArea(message);
            log.Info("Enter the message.");
            Thread.Sleep(2000);

            //Click Send button
            directMessagingPage.ClickSendBtn();
            log.Info("Click Send button.");
            Thread.Sleep(2000);

            //Verify Message is sent confirmation message
            directoryPage.VerifyUserConfirmationMessage();
            log.Info("Verify confirmaion message.");
        }

        [Test, CustomRetry(2)]
        public void Directory_014_CreaateTalentPool()
        {
            //Click Directory Tab
            Thread.Sleep(2000);
            directoryPage.ClickDirectoryTab();
            log.Info("Click the Directory tab.");
            Thread.Sleep(3000);

            //Click Add Talent Pool Icon
            directoryPage.ClickAddTalentPoolIcom();
            log.Info("Click Add Talent Pool Icon.");
            Thread.Sleep(3000);

            //Enter Talent Pool Name
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(6));
            String talentPoolName = "Talent Pool ";
            talentPoolName = talentPoolName + builder;
            commonPage.ScrollDown();
            Thread.Sleep(1000);
            directoryPage.EnterTalentPoolName(talentPoolName);
            log.Info("Enter Talent Pool Name");
            Thread.Sleep(1000);

            //Click Save button
            directoryPage.ClickTalentPoolSaveBtn();
            log.Info("Click Talent Pool Save button");
            Thread.Sleep(5000);

            //Verify Talent Pool displayed now in Talent Pool drop-down
            directoryPage.VerifyTalentPoolDisplayed(talentPoolName);
            log.Info("Verify Talent Pool is displayed now in Talent Pool drop-down");

            //Select Talent Pool Name from the Talent Pool drop-down
            directoryPage.SelectTalentPoolFilter(talentPoolName);
            log.Info("Select Talent Pool Name from the Talent Pool drop-down");
            Thread.Sleep(3000);

            //Delete Talent Pool
            DeleteTalentPool();
        }

        [Test, CustomRetry(2)]
        public void Directory_015_VerifyUsersPerSkillsInTalentPool()
        {
            //Click Directory Tab
            Thread.Sleep(2000);
            directoryPage.ClickDirectoryTab();
            log.Info("Click the Directory tab.");
            Thread.Sleep(3000);

            //Click Add Talent Pool Icon
            directoryPage.ClickAddTalentPoolIcom();
            log.Info("Click Add Talent Pool Icon.");
            Thread.Sleep(3000);

            //Enter Skills
            String userName = "bob lawson";
            String skill = "FilterBob";
            directoryPage.EnterSkillsTalentPool(skill);
            Thread.Sleep(2000);
            commonPage.PressEnterKey();
            log.Info("Enter Skill in the Skills search.");
            Thread.Sleep(1000);

            //Enter Talent Pool Name
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(6));
            String talentPoolName = "Talent Pool ";
            talentPoolName = talentPoolName + builder;
            commonPage.ScrollDown();
            Thread.Sleep(1000);
            directoryPage.EnterTalentPoolName(talentPoolName);
            log.Info("Enter Talent Pool Name");
            Thread.Sleep(1000);

            //Click Save button
            directoryPage.ClickTalentPoolSaveBtn();
            log.Info("Click Talent Pool Save button");
            Thread.Sleep(5000);

            //Select Talent Pool Name from the Talent Pool drop-down
            directoryPage.SelectTalentPoolFilter(talentPoolName);
            log.Info("Select Talent Pool Name from the Talent Pool drop-down");
            Thread.Sleep(3000);

            //Verify User container User Name is displayed
            directoryPage.VerifyUserContainerUserName(userName);
            log.Info("Verify searched user is displayed.");

            //Delete Talent Pool
            DeleteTalentPool();
        }

        [Test, CustomRetry(2)]
        public void Directory_016_VerifyUsersPerLanguageInTalentPool()
        {
            //Click Directory Tab
            Thread.Sleep(2000);
            directoryPage.ClickDirectoryTab();
            log.Info("Click the Directory tab.");
            Thread.Sleep(3000);

            //Click Add Talent Pool Icon
            directoryPage.ClickAddTalentPoolIcom();
            log.Info("Click Add Talent Pool Icon.");
            Thread.Sleep(3000);

            //Enter Language
            String userName = "bob lawson";
            String language = "Hindi";
            directoryPage.EnterLanguagesTalentPool(language);
            Thread.Sleep(2000);
            commonPage.PressEnterKey();
            log.Info("Enter Language in the search.");
            Thread.Sleep(1000);

            //Enter Talent Pool Name
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(6));
            String talentPoolName = "Talent Pool ";
            talentPoolName = talentPoolName + builder;
            commonPage.ScrollDown();
            Thread.Sleep(1000);
            directoryPage.EnterTalentPoolName(talentPoolName);
            log.Info("Enter Talent Pool Name");
            Thread.Sleep(1000);

            //Click Save button
            directoryPage.ClickTalentPoolSaveBtn();
            log.Info("Click Talent Pool Save button");
            Thread.Sleep(5000);

            //Select Talent Pool Name from the Talent Pool drop-down
            directoryPage.SelectTalentPoolFilter(talentPoolName);
            log.Info("Select Talent Pool Name from the Talent Pool drop-down");
            Thread.Sleep(3000);

            //Verify User container User Name is displayed
            directoryPage.VerifyUserContainerUserName(userName);
            log.Info("Verify searched user is displayed.");

            //Delete Talent Pool
            DeleteTalentPool();
        }

        [Test, CustomRetry(2)]
        public void Directory_017_VerifyUsersPerSkillsToDevelopInTalentPool()
        {
            //Click Directory Tab
            Thread.Sleep(2000);
            directoryPage.ClickDirectoryTab();
            log.Info("Click the Directory tab.");
            Thread.Sleep(3000);

            //Click Add Talent Pool Icon
            directoryPage.ClickAddTalentPoolIcom();
            log.Info("Click Add Talent Pool Icon.");
            Thread.Sleep(3000);

            //Enter Skills To Develop
            String userName = "bob lawson";
            String skillsToDevelop = "Oracle";
            directoryPage.EnterSkillsToDevelopTalentPool(skillsToDevelop);
            Thread.Sleep(2000);
            commonPage.PressEnterKey();
            log.Info("Enter Skills To Develop in the search.");
            Thread.Sleep(1000);

            //Enter Talent Pool Name
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(6));
            String talentPoolName = "Talent Pool ";
            talentPoolName = talentPoolName + builder;
            commonPage.ScrollDown();
            Thread.Sleep(1000);
            directoryPage.EnterTalentPoolName(talentPoolName);
            log.Info("Enter Talent Pool Name");
            Thread.Sleep(1000);

            //Click Save button
            directoryPage.ClickTalentPoolSaveBtn();
            log.Info("Click Talent Pool Save button");
            Thread.Sleep(5000);

            //Select Talent Pool Name from the Talent Pool drop-down
            directoryPage.SelectTalentPoolFilter(talentPoolName);
            log.Info("Select Talent Pool Name from the Talent Pool drop-down");
            Thread.Sleep(3000);

            //Verify User container User Name is displayed
            directoryPage.VerifyUserContainerUserName(userName);
            log.Info("Verify searched user is displayed.");

            //Delete Talent Pool
            DeleteTalentPool();
        }

        [Test, CustomRetry(2)]
        public void Directory_018_VerifyUsersPerLocationInTalentPool()
        {
            //Click Directory Tab
            Thread.Sleep(2000);
            directoryPage.ClickDirectoryTab();
            log.Info("Click the Directory tab.");
            Thread.Sleep(3000);

            //Click Add Talent Pool Icon
            directoryPage.ClickAddTalentPoolIcom();
            log.Info("Click Add Talent Pool Icon.");
            Thread.Sleep(3000);

            //Enter Location
            String userName = "bob lawson";
            String location = "Singapore";
            directoryPage.EnterLocationTalentPool(location);
            Thread.Sleep(2000);
            commonPage.PressDownArrowKey();
            Thread.Sleep(1000);
            commonPage.PressEnterKey();
            log.Info("Enter Location in the search.");
            Thread.Sleep(1000);

            //Enter Talent Pool Name
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(6));
            String talentPoolName = "Talent Pool ";
            talentPoolName = talentPoolName + builder;
            commonPage.ScrollDown();
            Thread.Sleep(1000);
            directoryPage.EnterTalentPoolName(talentPoolName);
            log.Info("Enter Talent Pool Name");
            Thread.Sleep(1000);

            //Click Save button
            directoryPage.ClickTalentPoolSaveBtn();
            log.Info("Click Talent Pool Save button");
            Thread.Sleep(5000);

            //Select Talent Pool Name from the Talent Pool drop-down
            directoryPage.SelectTalentPoolFilter(talentPoolName);
            log.Info("Select Talent Pool Name from the Talent Pool drop-down");
            Thread.Sleep(3000);

            //Verify User container User Name is displayed
            directoryPage.VerifyUserContainerUserName(userName);
            log.Info("Verify searched user is displayed.");

            //Delete Talent Pool
            DeleteTalentPool();
        }

        [Test, CustomRetry(2)]
        public void Directory_019_VerifyUsersPerDepartmentInTalentPool()
        {
            //Click Directory Tab
            Thread.Sleep(2000);
            directoryPage.ClickDirectoryTab();
            log.Info("Click the Directory tab.");
            Thread.Sleep(3000);

            //Click Add Talent Pool Icon
            directoryPage.ClickAddTalentPoolIcom();
            log.Info("Click Add Talent Pool Icon.");
            Thread.Sleep(3000);

            //Enter Department
            String userName = "bob lawson";
            String department = "QCT";
            directoryPage.EnterDepartmentTalentPool(department);
            log.Info("Enter Department in the search.");
            Thread.Sleep(1000);

            //Enter Talent Pool Name
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(6));
            String talentPoolName = "Talent Pool ";
            talentPoolName = talentPoolName + builder;
            commonPage.ScrollDown();
            Thread.Sleep(1000);
            directoryPage.EnterTalentPoolName(talentPoolName);
            log.Info("Enter Talent Pool Name");
            Thread.Sleep(1000);

            //Click Save button
            directoryPage.ClickTalentPoolSaveBtn();
            log.Info("Click Talent Pool Save button");
            Thread.Sleep(5000);

            //Select Talent Pool Name from the Talent Pool drop-down
            directoryPage.SelectTalentPoolFilter(talentPoolName);
            log.Info("Select Talent Pool Name from the Talent Pool drop-down");
            Thread.Sleep(3000);

            //Verify User container User Name is displayed
            directoryPage.VerifyUserContainerUserName(userName);
            log.Info("Verify searched user is displayed.");

            //Delete Talent Pool
            DeleteTalentPool();
        }

        [Test, CustomRetry(2)]
        public void Directory_020_VerifyUsersPerTitleInTalentPool()
        {
            //Click Directory Tab
            Thread.Sleep(2000);
            directoryPage.ClickDirectoryTab();
            log.Info("Click the Directory tab.");
            Thread.Sleep(3000);

            //Click Add Talent Pool Icon
            directoryPage.ClickAddTalentPoolIcom();
            log.Info("Click Add Talent Pool Icon.");
            Thread.Sleep(3000);

            //Enter Title
            String userName = "bob lawson";
            String title = "bobTitle";
            directoryPage.EnterTitleTalentPool(title);
            log.Info("Enter Title in the search.");
            Thread.Sleep(1000);

            //Enter Talent Pool Name
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(6));
            String talentPoolName = "Talent Pool ";
            talentPoolName = talentPoolName + builder;
            commonPage.ScrollDown();
            Thread.Sleep(1000);
            directoryPage.EnterTalentPoolName(talentPoolName);
            log.Info("Enter Talent Pool Name");
            Thread.Sleep(1000);

            //Click Save button
            directoryPage.ClickTalentPoolSaveBtn();
            log.Info("Click Talent Pool Save button");
            Thread.Sleep(5000);

            //Select Talent Pool Name from the Talent Pool drop-down
            directoryPage.SelectTalentPoolFilter(talentPoolName);
            log.Info("Select Talent Pool Name from the Talent Pool drop-down");
            Thread.Sleep(3000);

            //Verify User container User Name is displayed
            directoryPage.VerifyUserContainerUserName(userName);
            log.Info("Verify searched user is displayed.");

            //Delete Talent Pool
            DeleteTalentPool();
        }

        [Test, CustomRetry(2)]
        public void Directory_021_VerifyUsersPerRoleInTalentPool()
        {
            //Click Directory Tab
            Thread.Sleep(2000);
            directoryPage.ClickDirectoryTab();
            log.Info("Click the Directory tab.");
            Thread.Sleep(3000);

            //Click Add Talent Pool Icon
            directoryPage.ClickAddTalentPoolIcom();
            log.Info("Click Add Talent Pool Icon.");
            Thread.Sleep(3000);

            //Select Role
            String userName = "Aa Directory";
            String roleName = "AUTOMATION_ROLE";
            directoryPage.SelectRolesTalentPool(roleName);
            log.Info("Select the Roles Filter.");
            Thread.Sleep(1000);

            //Enter Talent Pool Name
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(6));
            String talentPoolName = "Talent Pool ";
            talentPoolName = talentPoolName + builder;
            commonPage.ScrollDown();
            Thread.Sleep(1000);
            directoryPage.EnterTalentPoolName(talentPoolName);
            log.Info("Enter Talent Pool Name");
            Thread.Sleep(1000);

            //Click Save button
            directoryPage.ClickTalentPoolSaveBtn();
            log.Info("Click Talent Pool Save button");
            Thread.Sleep(5000);

            //Select Talent Pool Name from the Talent Pool drop-down
            directoryPage.SelectTalentPoolFilter(talentPoolName);
            log.Info("Select Talent Pool Name from the Talent Pool drop-down");
            Thread.Sleep(3000);

            //Verify User container User Name is displayed
            directoryPage.VerifyUserContainerUserName(userName);
            log.Info("Verify searched user is displayed.");

            //Delete Talent Pool
            DeleteTalentPool();
        }

        [Test, CustomRetry(2)]
        public void Directory_022_VerifyUsersPerAvailabilityInTalentPool()
        {
            //Click Directory Tab
            Thread.Sleep(2000);
            directoryPage.ClickDirectoryTab();
            log.Info("Click the Directory tab.");
            Thread.Sleep(3000);

            //Click Add Talent Pool Icon
            directoryPage.ClickAddTalentPoolIcom();
            log.Info("Click Add Talent Pool Icon.");
            Thread.Sleep(3000);

            //Select Available For
            String userName = "Aa Directory";
            String availableFor = "Short Term Project";
            directoryPage.SelectAvailableForTalentPool(availableFor);
            log.Info("Select the Available For Filter.");
            Thread.Sleep(1000);

            //Enter Talent Pool Name
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(6));
            String talentPoolName = "Talent Pool ";
            talentPoolName = talentPoolName + builder;
            commonPage.ScrollDown();
            Thread.Sleep(1000);
            directoryPage.EnterTalentPoolName(talentPoolName);
            log.Info("Enter Talent Pool Name");
            Thread.Sleep(1000);

            //Click Save button
            directoryPage.ClickTalentPoolSaveBtn();
            log.Info("Click Talent Pool Save button");
            Thread.Sleep(5000);

            //Select Talent Pool Name from the Talent Pool drop-down
            directoryPage.SelectTalentPoolFilter(talentPoolName);
            log.Info("Select Talent Pool Name from the Talent Pool drop-down");
            Thread.Sleep(3000);

            //Verify User container User Name is displayed
            directoryPage.VerifyUserContainerUserName(userName);
            log.Info("Verify searched user is displayed.");

            //Delete Talent Pool
            DeleteTalentPool();
        }

        [Test, CustomRetry(2)]
        public void Directory_023_VerifyUsersPerAllFieldsInTalentPool()
        {
            //Click Directory Tab
            Thread.Sleep(2000);
            directoryPage.ClickDirectoryTab();
            log.Info("Click the Directory tab.");
            Thread.Sleep(3000);

            //Click Add Talent Pool Icon
            directoryPage.ClickAddTalentPoolIcom();
            log.Info("Click Add Talent Pool Icon.");
            Thread.Sleep(3000);

            //Enter Skills
            String userName = "bob lawson";
            String skill = "FilterBob";
            directoryPage.EnterSkillsTalentPool(skill);
            Thread.Sleep(2000);
            commonPage.PressEnterKey();
            log.Info("Enter Skill in the Skills search.");
            Thread.Sleep(1000);

            //Enter Language
            String language = "Hindi";
            directoryPage.EnterLanguagesTalentPool(language);
            Thread.Sleep(2000);
            commonPage.PressEnterKey();
            log.Info("Enter Language in the search.");
            Thread.Sleep(1000);

            //Enter Skills To Develop
            String skillsToDevelop = "Oracle";
            directoryPage.EnterSkillsToDevelopTalentPool(skillsToDevelop);
            Thread.Sleep(2000);
            commonPage.PressEnterKey();
            log.Info("Enter Skills To Develop in the search.");
            Thread.Sleep(1000);

            //Enter Location
            String location = "Singapore";
            directoryPage.EnterLocationTalentPool(location);
            Thread.Sleep(2000);
            commonPage.PressDownArrowKey();
            Thread.Sleep(1000);
            commonPage.PressEnterKey();
            log.Info("Enter Location in the search.");
            Thread.Sleep(1000);            

            //Enter Department
            String department = "QCT";
            directoryPage.EnterDepartmentTalentPool(department);
            log.Info("Enter Department in the search.");
            Thread.Sleep(1000);

            //Enter Title
            String title = "bobTitle";
            directoryPage.EnterTitleTalentPool(title);
            log.Info("Enter Title in the search.");
            Thread.Sleep(1000);

            //Select Role
            String roleName = "Employee";
            directoryPage.SelectRolesTalentPool(roleName);
            log.Info("Select the Roles Filter.");
            Thread.Sleep(1000);

            //Select Available For
            String availableFor = "Regression Project";
            directoryPage.SelectAvailableForTalentPool(availableFor);
            log.Info("Select the Available For Filter.");
            Thread.Sleep(1000);

            //Enter Talent Pool Name
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(6));
            String talentPoolName = "Talent Pool ";
            talentPoolName = talentPoolName + builder;
            commonPage.ScrollDown();
            Thread.Sleep(1000);
            directoryPage.EnterTalentPoolName(talentPoolName);
            log.Info("Enter Talent Pool Name");
            Thread.Sleep(1000);

            //Click Save button
            directoryPage.ClickTalentPoolSaveBtn();
            log.Info("Click Talent Pool Save button");
            Thread.Sleep(5000);

            //Select Talent Pool Name from the Talent Pool drop-down
            directoryPage.SelectTalentPoolFilter(talentPoolName);
            log.Info("Select Talent Pool Name from the Talent Pool drop-down");
            Thread.Sleep(3000);

            //Verify User container User Name is displayed
            directoryPage.VerifyUserContainerUserName(userName);
            log.Info("Verify searched user is displayed.");

            //Delete Talent Pool
            DeleteTalentPool();
        }

        [Test, CustomRetry(2)]
        public void Directory_024_VerifyPublicPrivateTalentPool()
        {
            //Click Directory Tab
            Thread.Sleep(2000);
            directoryPage.ClickDirectoryTab();
            log.Info("Click the Directory tab.");
            Thread.Sleep(3000);

            //Click Add Talent Pool Icon
            directoryPage.ClickAddTalentPoolIcom();
            log.Info("Click Add Talent Pool Icon.");
            Thread.Sleep(3000);

            //Enter Talent Pool Name
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(6));
            String talentPoolName = "Talent Pool ";
            talentPoolName = talentPoolName + builder;
            commonPage.ScrollDown();
            Thread.Sleep(1000);
            directoryPage.EnterTalentPoolName(talentPoolName);
            log.Info("Enter Talent Pool Name");
            Thread.Sleep(1000);

            //Click Save button
            directoryPage.ClickTalentPoolSaveBtn();
            log.Info("Click Talent Pool Save button");
            Thread.Sleep(5000);

            //Click Add Talent Pool Icon
            directoryPage.ClickAddTalentPoolIcom();
            log.Info("Click Add Talent Pool Icon.");
            Thread.Sleep(3000);

            //Enter Talent Pool Name
            StringBuilder builderTwo = new StringBuilder();
            builderTwo.Append(RandomString(6));
            String talentTwoPoolName = "Talent Pool ";
            talentTwoPoolName = talentTwoPoolName + builderTwo;
            commonPage.ScrollDown();
            Thread.Sleep(1000);
            directoryPage.EnterTalentPoolName(talentTwoPoolName);
            log.Info("Enter Talent Pool Name");
            Thread.Sleep(1000);

            //Click Private talent Pool Check-box
            directoryPage.ClickPrivateTalentPool();
            log.Info("Click Private talent Pool Check-box");
            Thread.Sleep(5000);

            //Click Save button
            directoryPage.ClickTalentPoolSaveBtn();
            log.Info("Click Talent Pool Save button");
            Thread.Sleep(5000);

            //Click marketplace tab
            marketplacePage.ClickMarketplaceTab();
            Thread.Sleep(5000);

            //Signout of the application
            authenticationPage.SignOut();
            log.Info("Click on the Signout button.");
            Thread.Sleep(5000);

            //Sign in with a different user
            String userName = readDirectory.GetValue("SignInDifferentUser", "userName");
            String password = readDirectory.GetValue("SignInDifferentUser", "password");
            SignInDifferentUser(userName, password);
            log.Info("Sign in with different user.");

            //Click Directory Tab
            Thread.Sleep(3000);
            directoryPage.ClickDirectoryTab();
            log.Info("Click the Directory tab.");
            Thread.Sleep(3000);

            //Verify Talent Pool displayed now in Talent Pool drop-down
            directoryPage.VerifyTalentPoolDisplayed(talentPoolName);
            log.Info("Verify Talent Pool is displayed now in Talent Pool drop-down");

            //Verify Second Talent Pool not displayed in Talent Pool drop-down
            directoryPage.VerifyTalentPoolNotDisplayed(talentTwoPoolName);
            log.Info("Verify Second Talent Pool not displayed in Talent Pool drop-down");
        }        

    }
}
