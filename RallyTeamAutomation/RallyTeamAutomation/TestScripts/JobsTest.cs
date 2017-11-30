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
using System.Configuration;

namespace RallyTeam.TestScripts
{
    [TestFixture("ExternalStormURL", "chrome", Category = "JobsChromePreprod")]
    [TestFixture("ExternalStormURL", "firefox", Category = "JobsFirefoxPreprod")]
    [TestFixture("Production", "chrome", Category = "JobsChromeProduction")]
    [TestFixture("Production", "firefox", Category = "JobsFirefoxProduction")]
    [Parallelizable(ParallelScope.Fixtures)]
    public class JobsTest : BaseTestES
    {
        public JobsTest(string urlKey, string Browser) : base(urlKey, Browser)
        {
            String url = urlKey;
        }

        static ReadData readJob = new ReadData("Jobs");
        StringBuilder builder, builder2;

        //SignIn
        private void SignInDifferentUser(String userName, String password)
        {
            authenticationPage.SetUserName(userName);
            authenticationPage.SetPassword(password);
            authenticationPage.ClickOnLoginButton();
        }

        //Delete Job
        public void DeleteJob()
        {
            //Click Settings Icon
            commonPage.ScrollUp();
            Thread.Sleep(1000);
            jobsPage.ClickSettingsIcon();
            log.Info("Click Settings Icon");
            Thread.Sleep(3000);

            //Select Job Settings Option
            jobsPage.SelectJobOption("Delete Job");
            log.Info("Select Delete Job option.");
            Thread.Sleep(3000);

            //Press Delete Project Window Yes buttonm
            postProjectPage.PressDeleteProjectWindowYesBtn();
            log.Info("Press Delete Project Window Yes button.");
        }

        public void PostNewJob(String jobTitle)
        {
            //Click Job Posting option
            Thread.Sleep(3000);
            postProjectPage.ClickCreateProjectJobBtn();
            Thread.Sleep(1000);
            postProjectPage.ClickJobPosting();
            Thread.Sleep(5000);

            //Enter the Job Title
            jobsPage.EnterTitle(jobTitle);
            Thread.Sleep(1000);

            //Enter the Job Description
            commonPage.HalfScrollDown(500);
            Thread.Sleep(1000);
            String jobDesc = readJob.GetValue("AddJobDetails", "jobDesc");
            jobsPage.EnterJobDesc(jobDesc);
            Thread.Sleep(1000);

            //Enter Skills
            commonPage.ScrollDown();
            Thread.Sleep(1000);
            String skills = readJob.GetValue("AddJobDetails", "skills");
            jobsPage.EnterRequiredSkills(skills);
            Thread.Sleep(3000);
            commonPage.PressEnterKey();
            Thread.Sleep(2000);
            log.Info("Enter Skills.");

            //Click Next Button
            jobsPage.ClickNextBtn();
            log.Info("Click on the Next button.");
            Thread.Sleep(5000);

            //Click Publish button
            commonPage.ScrollDown();
            Thread.Sleep(1000);
            jobsPage.ClickPublishBtn();
            log.Info("Click Publish Button");
            Thread.Sleep(7000);
        }

        [Test, CustomRetry(_reTryCount)]
        public void Jobs_001_PostNewJobAndVerifyData()
        {
            //Post a new project
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(6));
            String jobTitle = readJob.GetValue("AddJobDetails", "jobTitle");
            jobTitle = jobTitle + builder;

            //Click Job Posting option
            Thread.Sleep(3000);
            postProjectPage.ClickCreateProjectJobBtn();
            Thread.Sleep(1000);
            postProjectPage.ClickJobPosting();
            Thread.Sleep(5000);

            //Enter the Job Req Id
            String reqId = readJob.GetValue("AddJobDetails", "reqId");
            jobsPage.EnterReqId(reqId);
            Thread.Sleep(1000);

            //Select Job Type
            String type = readJob.GetValue("AddJobDetails", "type");
            jobsPage.SelectType(type);
            Thread.Sleep(1000);

            //Enter the Job Title
            jobsPage.EnterTitle(jobTitle);
            Thread.Sleep(1000);

            //Enter the Job Category
            String jobCategory = readJob.GetValue("AddJobDetails", "jobCategory");
            jobsPage.EnterCategory(jobCategory);
            log.Info("Enter Job Category.");
            Thread.Sleep(1000);

            //Enter the Job Level
            commonPage.HalfScrollDown(500);
            Thread.Sleep(1000);
            String jobLevel = readJob.GetValue("AddJobDetails", "jobLevel");
            jobsPage.EnterLevel(jobLevel);
            log.Info("Enter Job Level.");
            Thread.Sleep(1000);

            //Enter the Job Team
            String jobTeam = readJob.GetValue("AddJobDetails", "jobTeam");
            jobsPage.EnterTeam(jobTeam);
            log.Info("Enter Job Team.");
            Thread.Sleep(1000);

            //Enter the Job Location
            commonPage.HalfScrollDown(500);
            Thread.Sleep(1000);
            String jobLocation = readJob.GetValue("AddJobDetails", "jobLocation");
            jobsPage.EnterLocation(jobLocation);
            Thread.Sleep(2000);
            commonPage.PressDownArrowKey();
            Thread.Sleep(1000);
            commonPage.PressEnterKey();
            log.Info("Select Job Location.");
            Thread.Sleep(1000);

            //Select Remote Checkbox
            jobsPage.ClickRemoteCheckbox();
            log.Info("Select Remote check-box.");
            Thread.Sleep(2000);

            //Select Onsite Checkbox
            jobsPage.ClickOnsiteCheckbox();
            log.Info("Select Onsite check-box.");
            Thread.Sleep(2000);

            //Click the Start Date Field
            postProjectPage.ClickStartDateField();
            log.Info("Click Start Date Field.");
            Thread.Sleep(1000);

            //Select today's date
            postProjectPage.ClickTodaysDate();
            log.Info("Select today's date.");
            Thread.Sleep(2000);

            //Enter the Job Description
            String jobDesc = readJob.GetValue("AddJobDetails", "jobDesc");
            jobsPage.EnterJobDesc(jobDesc);
            Thread.Sleep(1000);

            //Enter the Required Qualifications
            commonPage.ScrollDown();
            Thread.Sleep(1000);
            String reqQualifications = readJob.GetValue("AddJobDetails", "reqQualifications");
            jobsPage.EnterRequiredQualification(reqQualifications);
            Thread.Sleep(1000);

            //Enter the Desired Qualifications
            String desiredQualifications = readJob.GetValue("AddJobDetails", "desiredQualifications");
            jobsPage.EnterDesiredQualification(desiredQualifications);
            Thread.Sleep(1000);

            //Enter Skills
            String skills = readJob.GetValue("AddJobDetails", "skills");
            jobsPage.EnterRequiredSkills(skills);
            Thread.Sleep(3000);
            commonPage.PressEnterKey();
            Thread.Sleep(2000);
            log.Info("Enter Skills.");

            //Click Next Button
            jobsPage.ClickNextBtn();
            log.Info("Click on the Next button.");
            Thread.Sleep(5000);

            //Click Publish button
            commonPage.ScrollDown();
            Thread.Sleep(2000);
            jobsPage.ClickPublishBtn();
            log.Info("Click Publish Button");
            Thread.Sleep(7000);

            //Verify About tab Job Title after creation
            jobsPage.VerifyTitleAboutPage(jobTitle);

            //Verify About tab Job Status after creation
            jobsPage.VerifyStatusAboutPage("Open");

            //Verify About tab Job Location after creation
            jobsPage.VerifyLocationAboutPage(jobLocation);

            //Verify About tab Job Description after creation
            jobsPage.VerifyDescriptionAboutPage(jobDesc);

            //Verify About tab Job Required Skills after creation
            jobsPage.VerifyReqSkillsAboutPage(skills);

            //Verify About tab Job Required Qualification after creation
            jobsPage.VerifyRequiredQualificationsAboutPage(reqQualifications);

            //Verify About tab Job Hiring Manager after creation
            jobsPage.VerifyHiringManagerAboutPage("Automation AdminUser");

            //Verify About tab Job Team after creation
            jobsPage.VerifyTeamAboutPage(jobTeam);

            //Verify About tab Job Level after creation
            jobsPage.VerifyLevelAboutPage(jobLevel);

            //Verify About tab Job Type after creation
            jobsPage.VerifyTypeAboutPage(type);

            //Verify About tab Job Staffing Onsite after creation
            jobsPage.VerifyStaffingOnsiteAboutPage("On-Site");

            //Verify About tab Job Staffing Remote after creation
            jobsPage.VerifyStaffingRemoteAboutPage("Remote");

            //Verify About tab Job Desired Qualification after creation
            commonPage.ScrollDown();
            Thread.Sleep(1000);
            jobsPage.VerifyDesiredQualificationsAboutPage(desiredQualifications);

            //Verify About tab Job Req Id after creation
            jobsPage.VerifyReqIdAboutPage(reqId);

            //Delete Project
            commonPage.ScrollUp();
            Thread.Sleep(1000);
            DeleteJob();
        }

        [Test, CustomRetry(_reTryCount)]
        public void Jobs_002_SendInterestAndViewCandidates()
        {
            //Post a new project
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(6));
            String jobTitle = readJob.GetValue("AddJobDetails", "jobTitle");
            jobTitle = jobTitle + builder;
            PostNewJob(jobTitle);

            //Signout of the application
            Thread.Sleep(5000);
            authenticationPage.SignOut();
            log.Info("Click on the Signout button.");

            //Sign in with a different user
            Thread.Sleep(5000);
            String userName = readJob.GetValue("SignInDifferentUser", "userName");
            String password = readJob.GetValue("SignInDifferentUser", "password");
            SignInDifferentUser(userName, password);
            log.Info("Sign in with different user.");

            //Enter the Job Title
            Thread.Sleep(5000);
            jobsPage.SearchJob(jobTitle);
            log.Info("Enter the Job Title.");
            Thread.Sleep(1000);

            //Click Search button
            jobsPage.ClickSearchBtn();
            log.Info("Click the Search button.");
            Thread.Sleep(15000);

            //Click Jobs Tab
            marketplacePage.ClickJobsTab();
            log.Info("Click the Jobs Tab.");
            Thread.Sleep(3000);

            //Click the created Job
            jobsPage.ClickJobOnPage(jobTitle);
            log.Info("Click the Job Title on the Jobs Tab.");
            Thread.Sleep(10000);

            //Verify Settings option not displayed
            jobsPage.VerifySettingsIconNotDisplayed();
            log.Info("Verify Settings option not displayed.");

            //Click I'm Interested button
            jobsPage.ClickImInterestedBtn();
            log.Info("Click I'm Interested button displayed on screen.");
            Thread.Sleep(5000);

            //Verify the Interested button displayed on screen or not
            jobsPage.AsssertInterestedBtn();
            log.Info("Verify Interested button displayed on screen.");
            Thread.Sleep(1000);

            //Signout of the application
            Thread.Sleep(5000);
            authenticationPage.SignOut();
            log.Info("Click on the Signout button.");

            //Login to the application
            authenticationPage.SetUserName(_workEmail);
            authenticationPage.SetPassword(_password);
            authenticationPage.ClickOnLoginButton();

            //Enter the Job Title
            Thread.Sleep(5000);
            jobsPage.SearchJob(jobTitle);
            log.Info("Enter the Job Title.");
            Thread.Sleep(1000);

            //Click Search button
            jobsPage.ClickSearchBtn();
            log.Info("Click the Search button.");
            Thread.Sleep(15000);

            //Click Jobs Tab
            marketplacePage.ClickJobsTab();
            log.Info("Click the Jobs Tab.");
            Thread.Sleep(3000);

            //Click the created Job
            jobsPage.ClickJobOnPage(jobTitle);
            log.Info("Click the Job Title on the Jobs Tab.");
            Thread.Sleep(10000);

            //Delete Project
            DeleteJob();
        }

        [Test, CustomRetry(_reTryCount)]
        public void Jobs_003_FilledJobs()
        {
            //Post a new project
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(6));
            String jobTitle = readJob.GetValue("AddJobDetails", "jobTitle");
            jobTitle = jobTitle + builder;
            PostNewJob(jobTitle);

            //Click Settings Icon
            commonPage.ScrollUp();
            Thread.Sleep(1000);
            jobsPage.ClickSettingsIcon();
            log.Info("Click Settings Icon");
            Thread.Sleep(3000);

            //Select Job Settings Option Edit Job Posting
            jobsPage.SelectJobOption("Edit Job Posting");
            log.Info("Select Edit Job option.");
            Thread.Sleep(3000);

            //Select Filled Status
            jobsPage.SelectStatus("Filled");
            log.Info("Select Delete Job option.");
            Thread.Sleep(3000);

            //Click Edit Save button
            commonPage.ScrollDown();
            Thread.Sleep(1000);
            jobsPage.ClickEditSaveBtn();
            log.Info("Click Edit Save button.");
            Thread.Sleep(5000);

            //Signout of the application
            Thread.Sleep(5000);
            authenticationPage.SignOut();
            log.Info("Click on the Signout button.");

            //Sign in with a different user
            Thread.Sleep(5000);
            String userName = readJob.GetValue("SignInDifferentUser", "userName");
            String password = readJob.GetValue("SignInDifferentUser", "password");
            SignInDifferentUser(userName, password);
            log.Info("Sign in with different user.");

            //Enter the Job Title
            Thread.Sleep(5000);
            jobsPage.SearchJob(jobTitle);
            log.Info("Enter the Job Title.");
            Thread.Sleep(1000);

            //Click Search button
            jobsPage.ClickSearchBtn();
            log.Info("Click the Search button.");
            Thread.Sleep(15000);

            //Click Jobs Tab
            marketplacePage.ClickJobsTab();
            log.Info("Click the Jobs Tab.");
            Thread.Sleep(3000);

            //Verify empty page is displayed on Jobs Tab
            directoryPage.VerifyEmptyPageMessage();
            log.Info("Verify empty page is displayed on People Tab");

            //Signout of the application
            Thread.Sleep(5000);
            authenticationPage.SignOut();
            log.Info("Click on the Signout button.");

            //Login to the application
            authenticationPage.SetUserName(_workEmail);
            authenticationPage.SetPassword(_password);
            authenticationPage.ClickOnLoginButton();

            //Enter the Job Title
            Thread.Sleep(5000);
            jobsPage.SearchJob(jobTitle);
            log.Info("Enter the Job Title.");
            Thread.Sleep(1000);

            //Click Search button
            jobsPage.ClickSearchBtn();
            log.Info("Click the Search button.");
            Thread.Sleep(15000);

            //Click Jobs Tab
            marketplacePage.ClickJobsTab();
            log.Info("Click the Jobs Tab.");
            Thread.Sleep(3000);

            //Select Filled Job
            jobsPage.SelectShowMeJobMarketplaceFilter("Filled Jobs");
            log.Info("Select Filled Job.");
            Thread.Sleep(3000);

            //Click the created Job
            jobsPage.ClickJobOnPage(jobTitle);
            log.Info("Click the Job Title on the Jobs Tab.");
            Thread.Sleep(10000);

            //Delete Project
            DeleteJob();
        }

        [Test, CustomRetry(_reTryCount)]
        public void Jobs_004_CancelledJobs()
        {
            //Post a new project
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(6));
            String jobTitle = readJob.GetValue("AddJobDetails", "jobTitle");
            jobTitle = jobTitle + builder;
            PostNewJob(jobTitle);

            //Click Settings Icon
            jobsPage.ClickSettingsIcon();
            log.Info("Click Settings Icon");
            Thread.Sleep(3000);

            //Select Job Settings Option Edit Job Posting
            jobsPage.SelectJobOption("Edit Job Posting");
            log.Info("Select Delete Job option.");
            Thread.Sleep(3000);

            //Select Filled Status
            jobsPage.SelectStatus("Cancelled");
            log.Info("Select Delete Job option.");
            Thread.Sleep(3000);

            //Click Edit Save button
            commonPage.ScrollDown();
            Thread.Sleep(1000);
            jobsPage.ClickEditSaveBtn();
            log.Info("Click Edit Save button.");
            Thread.Sleep(5000);

            //Signout of the application
            Thread.Sleep(5000);
            authenticationPage.SignOut();
            log.Info("Click on the Signout button.");

            //Sign in with a different user
            Thread.Sleep(5000);
            String userName = readJob.GetValue("SignInDifferentUser", "userName");
            String password = readJob.GetValue("SignInDifferentUser", "password");
            SignInDifferentUser(userName, password);
            log.Info("Sign in with different user.");

            //Enter the Job Title
            Thread.Sleep(5000);
            jobsPage.SearchJob(jobTitle);
            log.Info("Enter the Job Title.");
            Thread.Sleep(1000);

            //Click Search button
            jobsPage.ClickSearchBtn();
            log.Info("Click the Search button.");
            Thread.Sleep(15000);

            //Click Jobs Tab
            marketplacePage.ClickJobsTab();
            log.Info("Click the Jobs Tab.");
            Thread.Sleep(3000);

            //Verify empty page is displayed on Jobs Tab
            directoryPage.VerifyEmptyPageMessage();
            log.Info("Verify empty page is displayed on People Tab");

            //Signout of the application
            Thread.Sleep(5000);
            authenticationPage.SignOut();
            log.Info("Click on the Signout button.");

            //Login to the application
            authenticationPage.SetUserName(_workEmail);
            authenticationPage.SetPassword(_password);
            authenticationPage.ClickOnLoginButton();

            //Enter the Job Title
            Thread.Sleep(5000);
            jobsPage.SearchJob(jobTitle);
            log.Info("Enter the Job Title.");
            Thread.Sleep(1000);

            //Click Search button
            jobsPage.ClickSearchBtn();
            log.Info("Click the Search button.");
            Thread.Sleep(15000);

            //Click Jobs Tab
            marketplacePage.ClickJobsTab();
            log.Info("Click the Jobs Tab.");
            Thread.Sleep(3000);

            //Select Filled Job
            jobsPage.SelectShowMeJobMarketplaceFilter("Cancelled Jobs");
            log.Info("Select Filled Job.");
            Thread.Sleep(3000);

            //Click the created Job
            jobsPage.ClickJobOnPage(jobTitle);
            log.Info("Click the Job Title on the Jobs Tab.");
            Thread.Sleep(10000);

            //Delete Project
            DeleteJob();
        }

        [Test, CustomRetry(_reTryCount)]
        public void Jobs_005_VerifyNotificationPublishedJob()
        {
            //Post a new project
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(6));
            String jobTitle = readJob.GetValue("AddJobDetails", "jobTitle");
            jobTitle = jobTitle + builder;
            PostNewJob(jobTitle);
            
            //Navigate to the user inbox
            commonPage.NavigateToUrl("https://www.mailinator.com/");
            log.Info("Navigate to the mailinator site.");
            Thread.Sleep(5000);

            //Enter Mailinator Email address
            addUsersPage.EnterMailinatorEmail("bobl@mailinator.com");
            log.Info("Enter email address.");
            Thread.Sleep(2000);

            //Click on Go button
            addUsersPage.ClickGoBtn();
            log.Info("Click Go button.");
            Thread.Sleep(5000);

            //Click the Email Subject
            jobsPage.ClickInviteJobSubject();
            log.Info("Click the Email Subject.");
            Thread.Sleep(5000);

            //Switch to Iframe
            jobsPage.SwitchIframe("msg_body");
            Thread.Sleep(2000);

            //Verify the Job Title
            //jobsPage.VerifyJobEmailTitle(jobTitle);
            //log.Info("Verify Job Title in Invite Job Email.");

            //Verify the Job View Job Button
            commonPage.ScrollDown();
            Thread.Sleep(1000);
            jobsPage.VerifyJobViewJobBtn();
            log.Info("Verify Job View Job Button in Invite Job Email.");           
        }

        [Test]
        [CustomRetry(_reTryCount)]
        public void Jobs_006_VerifyNotificationPromoteJob()
        {
            //Post a new project
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(6));
            String jobTitle = readJob.GetValue("AddJobDetails", "jobTitle");
            jobTitle = jobTitle + builder;
            PostNewJob(jobTitle);

            //Click Settings Icon
            jobsPage.ClickSettingsIcon();
            log.Info("Click Settings Icon");

            //Select Job Settings Option View Candidates
            jobsPage.SelectJobOption("Edit Job Posting");
            log.Info("Select Promote Job option.");
            Thread.Sleep(3000);

            //Edit Job Skill
            commonPage.ScrollDown();
            Thread.Sleep(1000);
            String additionalSkill = readJob.GetValue("AddJobDetails", "additionalSkill");
            jobsPage.EnterRequiredSkills(additionalSkill);
            Thread.Sleep(3000);
            commonPage.PressEnterKey();
            Thread.Sleep(2000);
            log.Info("Enter Skills.");

            //Click Save button
            jobsPage.ClickEditSaveBtn();
            log.Info("Click Save button.");

            //Click Settings Icon
            jobsPage.ClickSettingsIcon();
            log.Info("Click Settings Icon");

            //Select Job Settings Option View Candidates
            jobsPage.SelectJobOption("View Candidates");
            log.Info("Select Promote Job option.");
            Thread.Sleep(3000);

            //Click Promote button
            jobsPage.ClickPromoteJobBtn();
            log.Info("Click Promote Job button.");

            ////Enter Additional Skills
            //String additionalSkill = readJob.GetValue("AddJobDetails", "additionalSkill");
            //jobsPage.EnterRequiredSkills(additionalSkill);
            //Thread.Sleep(3000);
            //commonPage.PressEnterKey();
            //Thread.Sleep(2000);
            //log.Info("Enter Skills.");

            //Click Promote button
            jobsPage.ClickPromoteBtn();
            log.Info("Click Promote button.");
            Thread.Sleep(20000);

            //Click Back button
            jobsPage.ClickJobsViewCandidatesBackBtn();
            log.Info("Click Back button.");
            
            //Navigate to the user inbox
            commonPage.NavigateToUrl("https://www.mailinator.com/");
            log.Info("Navigate to the mailinator site.");
            Thread.Sleep(5000);

            //Enter Mailinator Email address
            addUsersPage.EnterMailinatorEmail("naveenb@mailinator.com");
            log.Info("Enter email address.");
            Thread.Sleep(2000);

            //Click on Go button
            addUsersPage.ClickGoBtn();
            log.Info("Click Go button.");
            Thread.Sleep(5000);

            //Click the Email Subject
            jobsPage.ClickInviteJobSubject();
            log.Info("Click the Email Subject.");
            Thread.Sleep(5000);

            //Switch to Iframe
            jobsPage.SwitchIframe("msg_body");
            Thread.Sleep(2000);

            //Verify the Job Title
            jobsPage.VerifyJobEmailTitle(jobTitle);
            log.Info("Verify Job Title in Invite Job Email.");

            //Verify the Job View Job Button
            commonPage.ScrollDown();
            Thread.Sleep(1000);
            jobsPage.VerifyJobViewJobBtn();
            log.Info("Verify Job View Job Button in Invite Job Email.");
        }

        [Test, CustomRetry(_reTryCount)]
        public void Jobs_007_ChangeHiringManagerAndVerify()
        {
            //Post a new project
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(6));
            String jobTitle = readJob.GetValue("AddJobDetails", "jobTitle");
            jobTitle = jobTitle + builder;
            PostNewJob(jobTitle);

            //Click Settings Icon
            jobsPage.ClickSettingsIcon();
            log.Info("Click Settings Icon");
            Thread.Sleep(3000);

            //Select Job Settings Option Edit Job Posting
            jobsPage.SelectJobOption("Edit Job Posting");
            log.Info("Select Promote Job option.");
            Thread.Sleep(3000);

            //Remove Hiring Manager
            jobsPage.ClickHiringManagerCrossIcon();
            log.Info("Remove Hiring Manager.");
            Thread.Sleep(3000);

            //Enter New Hiring Manager            
            String newHiringManager = readJob.GetValue("AddJobDetails", "newHiringManager");
            jobsPage.EnterHiringManager(newHiringManager);
            Thread.Sleep(3000);
            commonPage.PressEnterKey();
            Thread.Sleep(2000);
            log.Info("Enter New Hiring Manager.");

            //Click Edit Save button
            commonPage.ScrollDown();
            Thread.Sleep(1000);
            jobsPage.ClickEditSaveBtn();
            log.Info("Click Edit Save button.");
            Thread.Sleep(5000);

            //Verify I'm Interested button gets displayed
            jobsPage.VerifyImInterestedBtnDisplayed();
            log.Info("Verify I'm Interested button gets displayed.");

            //Verify Settings option still displayed as logged in user is Admin
            jobsPage.VerifySettingsIconDisplayed();
            log.Info("Verify Settings option still displayed as logged in user is Admin.");

            //Signout of the application
            Thread.Sleep(5000);
            authenticationPage.SignOut();
            log.Info("Click on the Signout button.");

            //Sign in with a different user
            Thread.Sleep(5000);
            String userName = readJob.GetValue("SignInDifferentUser", "userName");
            String password = readJob.GetValue("SignInDifferentUser", "password");
            SignInDifferentUser(userName, password);
            log.Info("Sign in with different user.");

            //Enter the Job Title
            Thread.Sleep(5000);
            jobsPage.SearchJob(jobTitle);
            log.Info("Enter the Job Title.");
            Thread.Sleep(1000);

            //Click Search button
            jobsPage.ClickSearchBtn();
            log.Info("Click the Search button.");
            Thread.Sleep(10000);

            //Click Jobs Tab
            marketplacePage.ClickJobsTab();
            log.Info("Click the Jobs Tab.");
            Thread.Sleep(3000);

            //Click the created Job
            jobsPage.ClickJobOnPage(jobTitle);
            log.Info("Click the Job Title on the Jobs Tab.");
            Thread.Sleep(5000);

            //Delete Job
            DeleteJob();
        }
    }
}
