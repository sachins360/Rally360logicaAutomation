using OpenQA.Selenium;
using RallyTeam.Util;
using RallyTeam.UILocators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Interactions;

namespace RallyTeam.UIPages
{
    public class JobsPage : BasePage
    {
        CommonMethods commonPage;

        public JobsPage(IWebDriver driver, int pageLoadTimeout)
            : base(driver, pageLoadTimeout)
        {
            commonPage = new CommonMethods(_driver, pageLoadTimeout);
        }

        //Click Job Posting Project option
        public void ClickJobPosting()
        {
            _driver.WaitForElementAvailableAtDOM(PostProjectUI.jobPostingOption, 1);
            _driver.SafeClick(PostProjectUI.jobPostingOption);
        }

        //Enter Requirement Id
        public void EnterReqId(String option)
        {
            _driver.WaitForElementAvailableAtDOM(JobsUI.reqIdInput, 1);
            _driver.SafeEnterText(JobsUI.reqIdInput, option);
        }

        //Select Type
        public void SelectType(String option)
        {
            _driver.WaitForElementAvailableAtDOM(JobsUI.typeSelect, 1);
            _driver.SelectDropDownOption(option, JobsUI.typeSelect);
        }

        //Select Status
        public void SelectStatus(String option)
        {
            _driver.WaitForElementAvailableAtDOM(JobsUI.statusSelect, 1);
            _driver.SelectDropDownOption(option, JobsUI.statusSelect);
        }

        //Enter Title
        public void EnterTitle(String option)
        {
            _driver.WaitForElementAvailableAtDOM(JobsUI.titleInput, 1);
            _driver.SafeEnterText(JobsUI.titleInput, option);
        }

        //Enter Category
        public void EnterCategory(String option)
        {
            _driver.WaitForElementAvailableAtDOM(JobsUI.categoryInput, 1);
            _driver.SafeEnterText(JobsUI.categoryInput, option);
        }

        //Enter Level
        public void EnterLevel(String option)
        {
            _driver.WaitForElementAvailableAtDOM(JobsUI.levelInput, 1);
            _driver.SafeEnterText(JobsUI.levelInput, option);
        }

        //Enter Hiring Manager
        public void EnterHiringManager(String option)
        {
            _driver.WaitForElementAvailableAtDOM(JobsUI.hiringMangerInput, 1);
            _driver.SafeEnterText(JobsUI.hiringMangerInput, option);
        }

        //Enter Team
        public void EnterTeam(String option)
        {
            _driver.WaitForElementAvailableAtDOM(JobsUI.teamInput, 1);
            _driver.SafeEnterText(JobsUI.teamInput, option);
        }

        //Enter Location
        public void EnterLocation(String option)
        {
            _driver.WaitForElementAvailableAtDOM(JobsUI.locationInput, 1);
            _driver.SafeEnterText(JobsUI.locationInput, option);
        }

        //Click Remote Checkbox
        public void ClickRemoteCheckbox()
        {
            _driver.SafeClick(JobsUI.remoteCheckbox);
        }

        //Click Onsite Checkbox
        public void ClickOnsiteCheckbox()
        {
            _driver.SafeClick(JobsUI.onsiteCheckbox);
        }

        //Enter Job Description
        public void EnterJobDesc(String option)
        {
            _driver.WaitForElementAvailableAtDOM(JobsUI.jobDescInput, 1);
            _driver.EnterTextUsingAction(JobsUI.jobDescInput, option);
        }

        //Enter Required Qualification
        public void EnterRequiredQualification(String option)
        {
            _driver.WaitForElementAvailableAtDOM(JobsUI.reqQualificationInput, 1);
            _driver.EnterTextUsingAction(JobsUI.reqQualificationInput, option);
        }

        //Enter Desired Qualification
        public void EnterDesiredQualification(String option)
        {
            _driver.WaitForElementAvailableAtDOM(JobsUI.desiredQualificationInput, 1);
            _driver.EnterTextUsingAction(JobsUI.desiredQualificationInput, option);
        }

        //Enter Required Skills
        public void EnterRequiredSkills(String option)
        {
            _driver.WaitForElementAvailableAtDOM(JobsUI.reqSkillsInput, 1);
            _driver.SafeEnterText(JobsUI.reqSkillsInput, option);
        }

        //Click Next Button
        public void ClickNextBtn()
        {
            _driver.WaitForElementAvailableAtDOM(JobsUI.nextBtn, 1);
            _driver.SafeClick(JobsUI.nextBtn);
        }

        //Click Save Draft Button
        public void ClickSaveDraftBtn()
        {
            _driver.WaitForElementAvailableAtDOM(JobsUI.saveDraftBtn, 1);
            _driver.SafeClick(JobsUI.saveDraftBtn);
        }

        //Click Publish Button
        public void ClickPublishBtn()
        {
            _driver.WaitForElementAvailableAtDOM(JobsUI.publishBtn, 1);
            _driver.SafeClick(JobsUI.publishBtn);
        }        

        //Click Settings Icon
        public void ClickSettingsIcon()
        {
            _driver.SafeClick(JobsUI.jobSettings);
        }

        //Verify Settings Icon not displayed
        public void VerifySettingsIconNotDisplayed()
        {
            _assertHelper.AssertElementNotDisplayed(JobsUI.jobSettings);
        }

        //Select Job Option
        public void SelectJobOption(string option)
        {
            _driver.SafeClick(JobsUI.jobSettingsOptions(option));
        }

        //Assert Job Title on About Page
        public void VerifyTitleAboutPage(String option)
        {
            _assertHelper.AssertElementDisplayed(JobsUI.JobTitleAboutPage(option));
        }

        //Assert Job Status on About Page
        public void VerifyStatusAboutPage(String option)
        {
            _assertHelper.AssertElementDisplayed(JobsUI.JobStatusAboutPage(option));
        }

        //Assert Job Location on About Page
        public void VerifyLocationAboutPage(String option)
        {
            _assertHelper.AssertElementDisplayed(JobsUI.JobLocationAboutPage(option));
        }

        //Assert Job Description on About Page
        public void VerifyDescriptionAboutPage(String option)
        {
            _assertHelper.AssertElementDisplayed(JobsUI.JobDescAboutPage(option));
        }

        //Assert Job Hiring Manager on About Page
        public void VerifyHiringManagerAboutPage(String option)
        {
            _assertHelper.AssertElementDisplayed(JobsUI.JobHiringManagerAboutPage(option));
        }

        //Assert Job Required Skills on About Page
        public void VerifyReqSkillsAboutPage(String option)
        {
            _assertHelper.AssertElementDisplayed(JobsUI.JobReqSkillsAboutPage(option));
        }

        //Assert Job Required Qualifications on About Page
        public void VerifyRequiredQualificationsAboutPage(String option)
        {
            _assertHelper.AssertElementDisplayed(JobsUI.JobReqQualificationsAboutPage(option));
        }

        //Assert Job Team on About Page
        public void VerifyTeamAboutPage(String option)
        {
            _assertHelper.AssertElementDisplayed(JobsUI.JobTeamAboutPage(option));
        }

        //Assert Job Level on About Page
        public void VerifyLevelAboutPage(String option)
        {
            _assertHelper.AssertElementDisplayed(JobsUI.JobLevelAboutPage(option));
        }

        //Assert Job Type on About Page
        public void VerifyTypeAboutPage(String option)
        {
            _assertHelper.AssertElementDisplayed(JobsUI.JobTypeAboutPage(option));
        }

        //Assert Job Staffing Onsite on About Page
        public void VerifyStaffingOnsiteAboutPage(String option)
        {
            _assertHelper.AssertElementDisplayed(JobsUI.JobStaffingOnsiteAboutPage(option));
        }

        //Assert Job Staffing Remote on About Page
        public void VerifyStaffingRemoteAboutPage(String option)
        {
            _assertHelper.AssertElementDisplayed(JobsUI.JobStaffingRemoteAboutPage(option));
        }

        //Assert Job Category on About Page
        public void VerifyCategoryAboutPage(String option)
        {
            _assertHelper.AssertElementDisplayed(JobsUI.JobCategoryAboutPage(option));
        }

        //Assert Job DESIRED Qualifications on About Page
        public void VerifyDesiredQualificationsAboutPage(String option)
        {
            _assertHelper.AssertElementDisplayed(JobsUI.JobDesiredQualificationsAboutPage(option));
        }

        //Assert Job Requirement Id on About Page
        public void VerifyReqIdAboutPage(String option)
        {
            _assertHelper.AssertElementDisplayed(JobsUI.JobRequirementIdAboutPage(option));
        }

        //Search Job Title in Search field
        public void SearchJob(String option)
        {
            _driver.SafeEnterText(MarketPlaceUI.searchText, option);
        }

        //Press Search button
        public void ClickSearchBtn()
        {
            _driver.SafeClick(MarketPlaceUI.searchBtn);
        }

        //Click the Job on Jobs Page
        public void ClickJobOnPage(String option)
        {
            _driver.ClickElementUsingJS(MarketPlaceUI.jobTitleOnPage(option));
        }

        //Press I'm Interested button
        public void ClickImInterestedBtn()
        {
            _driver.SafeClick(JobsUI.imInterestedBtn);
        }

        //Assert I'm Interested button not displayed
        public void VerifyImInterestedBtnNotDisplayed()
        {
            _assertHelper.AssertElementNotDisplayed(JobsUI.imInterestedBtn);
        }

        //Assert I'm Interested button displayed
        public void VerifyImInterestedBtnDisplayed()
        {
            _assertHelper.AssertElementDisplayed(JobsUI.imInterestedBtn);
        }

        //Assert Interested button
        public void AsssertInterestedBtn()
        {
            _assertHelper.AssertElementDisplayed(JobsUI.interestedBtn);
        }

        //Press Edit Save button
        public void ClickEditSaveBtn()
        {
            _driver.SafeClick(JobsUI.editSaveBtn);
        }

        //Press Promote button
        public void ClickPromoteBtn()
        {
            _driver.SafeClick(JobsUI.promoteBtn);
        }

        //Select Filled Jobs From Marketplace Filter
        public void SelectShowMeJobMarketplaceFilter(String option)
        {
            _driver.SelectDropDownOption(option, MarketPlaceUI.showMeJob);
        }

        //Click Invite Job Email Subject
        public void ClickInviteJobSubject()
        {
            _driver.SafeClick(JobsUI.mailinatorJobInviteSubject);
        }

        //Assert Invite Job Email View Job Btn
        public void VerifyJobViewJobBtn()
        {
            _driver.SafeClick(JobsUI.mailinatorJobInviteViewJobBtn);
        }

        //Assert Invite Job Email Job Title
        public void VerifyJobEmailTitle(String option)
        {
            _driver.SafeClick(JobsUI.mailinatorJobTitle(option));
        }

        //Switch to iframe
        public void SwitchIframe(String option)
        {
            _driver.switchFrameById(option);
        }

        //Press Hiring Manager cross icon
        public void ClickHiringManagerCrossIcon()
        {
            _driver.SafeClick(JobsUI.hiringMangerCrossIcon);
        }

    }
}
