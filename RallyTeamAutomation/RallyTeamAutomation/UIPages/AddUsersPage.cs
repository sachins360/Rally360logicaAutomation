using OpenQA.Selenium;
using RallyTeam.Util;
using RallyTeam.UILocators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Interactions;
using System.Collections;
using System.Threading;

namespace RallyTeam.UIPages
{
    public class AddUsersPage : BasePage
    {
        CommonMethods commonPage;

        public AddUsersPage(IWebDriver driver, int pageLoadTimeout)
            : base(driver, pageLoadTimeout)
        {
            commonPage = new CommonMethods(_driver, pageLoadTimeout);
        }
        //Press Enter Key
        public void PressEnterKey()
        {
            _driver.PressKeyBoardEnter();
        }
        //Press Tab Key
        public void PressTabKey()
        {
            _driver.PressKeyBoardTab();
        }
        //Click Add Users button
        public void ClickAddUsersBtn()
        {
            _driver.SafeClick(AddUsersUI.addUserBtn);
        }
        //Assert Let's build your marketplace! message
        public void VerifyLetsBuildYourMarketplaceMsg()
        {
            _assertHelper.AssertElementDisplayed(AddUsersUI.letsBuildYourMarketplaceMsg);
        }
        //Assert Upload your employees, external contractors, or contacts message
        public void VerifyUploadkMsg()
        {
            _assertHelper.AssertElementDisplayed(AddUsersUI.uploadMsg);
        }
        //Assert Close icon
        public void VerifyCloseIcon()
        {
            _assertHelper.AssertElementDisplayed(AddUsersUI.closeIcon);
        }
        public void ClickCloseIcon()
        {
            _driver.SafeClick(AddUsersUI.closeIcon);
        }
        public void ClickDownloadCSV()
        {
            _driver.SafeClick(AddUsersUI.downloadCSVTemp);
        }

        public void VerifyMayBeLaterOption()
        {
            _assertHelper.AssertElementDisplayed(AddUsersUI.mayBeLater);
        }
        
        //Assert Maybe Later option
        public void VerifyDownloadCSV()
        {
            _assertHelper.AssertElementDisplayed(AddUsersUI.downloadCSVTemp);
        }

        //Assert Google button
        public void VerifyGoogleBtn()
        {
            _assertHelper.AssertElementDisplayed(AddUsersUI.googleBtn);
        }

        //Assert Outlook button
        public void VerifyOutlookBtn()
        {
            _assertHelper.AssertElementDisplayed(AddUsersUI.outlookBtn);
        }

        //Assert CSV button
        public void VerifyCsvBtn()
        {
            _assertHelper.AssertElementDisplayed(AddUsersUI.csvBtn);
        }

        //Assert Email button
        public void VerifyEmailBtn()
        {
            _assertHelper.AssertElementDisplayed(AddUsersUI.emailBtn);
        }

        //Assert Rallyteam logo
        public void VerifyRallyteamLogo()
        {
            _assertHelper.AssertElementDisplayed(AddUsersUI.rallyTeamLogo);
        }

        //Assert Create Profile button
        public void VerifyCreateProfileBtn()
        {
            _assertHelper.AssertElementDisplayed(AddUsersUI.createProfileBtn);
        }

        //Click Email button
        public void ClickEmailBtn()
        {
            _driver.SafeClick(AddUsersUI.emailBtn);
            // _driver.ClickElementUsingJS(AddUsersUI.emailBtn);
        }

        //Tab to Email Button
        public void PressEmailBtn()
        {
            commonPage.PressTabKey();
            Thread.Sleep(1000);
            commonPage.PressTabKey();
            Thread.Sleep(1000);
            commonPage.PressEnterKey();
        }

        //Enter Email Addresses
        public void EnterEmailAddresses(String email)
        {
            _driver.SafeEnterText(AddUsersUI.emailAddressesInput, email);
        }

        //Click Email Add Users button
        public void ClickEmailAddUsersBtn()
        {
            _driver.SafeClick(AddUsersUI.emailAddUsersBtn);
        }


        //Click Mailinator Email Get Started Button
        public void ClickEmailGetStartedBtn()
        {
            _driver.SafeClick(AddUsersUI.emailGetStartedBtn);
        }

        //Click Finish button
        public void ClickFinishBtn()
        {
            _driver.SafeClick(AddUsersUI.finishBtn);
        }

        //Assert the email sender
        public void VerifyEmailSender()
        {
            _assertHelper.AssertElementDisplayed(AddUsersUI.harakiriEmailSender);
        }

        //Assert the email sender
        public void VerifyEmailSenderDoesnnotExist()
        {
            _assertHelper.AssertElementNotDisplayed(AddUsersUI.harakiriEmailSender);
        }

        //Click the email sender
        public void ClickEmailSender()
        {
            _driver.ClickElementUsingAction(AddUsersUI.harakiriEmailSender);
        }

        //Assert the email subject
        public void VerifyEmailSubject()
        {
            _assertHelper.AssertElementDisplayed(AddUsersUI.harakiriInviteUserSubject);
        }

        //Assert the Get Started Button
        public void VerifyGetStartedBtn()
        {
            _assertHelper.AssertElementDisplayed(AddUsersUI.getStartedBtn);
        }

        //Click the Get Started Button
        public void ClickGetStartedBtn()
        {
            _driver.SafeClick(AddUsersUI.getStartedBtn);
        }

        //Assert the Email Get Started Button
        public void VerifyEmailGetStartedBtn()
        {
            _assertHelper.AssertElementDisplayed(AddUsersUI.emailGetStartedBtn);
        }

        //Click the Email Get Started Button
        public void ClickMailinatorEmailGetStartedBtn()
        {
            _driver.SafeClick(AddUsersUI.emailGetStartedBtn);
        }

        //Get the email link
        public String GetEmailLink()
        {
            return _driver.GetElementAttributeValue(AddUsersUI.verifyYourEmailBtn, "href");
        }

        //Click Upload Your Resume button
        public void ClickUploadYourResumeBtn()
        {
            _driver.SafeClick(AddUsersUI.uploadResumeBtn);
        }

        //Click LinkedIn button
        public void ClickLinkedInBtn()
        {
            _driver.SafeClick(AddUsersUI.linkedInBtn);
        }

        //Switch to LinkedIn Window
        public void SwitchLinkedInWindow()
        {
            _driver.SwitchTo().Window(_driver.WindowHandles.Last());
        }

        //Switch to Original Window
        public void SwitchOriginalWindow()
        {
            _driver.SwitchTo().Window(_driver.WindowHandles.First());
        }

        //Enter LinkedIn UsernId
        public void EnterLinkedInUserId(string userid)
        {
            _driver.SafeEnterText(AddUsersUI.linkedInUserId, userid);
        }

        //Enter LinkedIn User Pwd
        public void EnterLinkedInPwd(string password)
        {
            _driver.SafeEnterText(AddUsersUI.linkedInPwd, password);
        }

        //Click LinkedIn SignIn button
        public void EnterLinkedInSignInBtn()
        {
            _driver.SafeClick(AddUsersUI.linkedInSignIn);
        }

        //Assert the LinkedIn button disabled
        public void VerifyLinkedInDisabled()
        {
            _assertHelper.AssertElementDisplayed(AddUsersUI.linkedInBtnDisabled);
        }

        //Assert the Confirm tickmark
        public void VerifyConfirmTickmark()
        {
            _assertHelper.AssertElementDisplayed(AddUsersUI.rightTick);
        }

        //Click Create a Profile Icon
        public void ClickCreateProfileBtn()
        {
            _driver.SafeClick(AddUsersUI.createProfileBtn);
        }

        //Tab and Press Create a Profile Icon
        public void PressCreateProfileBtn()
        {
            commonPage.PressTabKey();
            Thread.Sleep(1000);
            commonPage.PressTabKey();
            Thread.Sleep(1000);
            commonPage.PressTabKey();
            Thread.Sleep(1000);
            commonPage.PressEnterKey();
        }

        //Enter First Name
        public void EnterFirstName(String firstName)
        {
            _driver.SafeEnterText(AddUsersUI.firstName, firstName);
        }

        //Enter Last Name
        public void EnterLastName(String lastName)
        {
            _driver.SafeEnterText(AddUsersUI.lastName, lastName);
        }

        //Enter Email
        public void EnterEmail(String email)
        {
            _driver.SafeEnterText(AddUsersUI.email, email);
        }

        //Select Availability Check-box
        public void SelectAvailability()
        {
            _driver.SafeClick(AddUsersUI.availability);
        }

        //Enter Hours Per Week
        public void EnterHoursPerWeek(String hoursPerWeek)
        {
            _driver.SafeEnterText(AddUsersUI.hoursPerWeek, hoursPerWeek);
        }

        //Enter Title
        public void EnterTitle(String title)
        {
            _driver.SafeEnterText(AddUsersUI.title, title);
        }

        //Enter Department
        public void EnterDepartment(String department)
        {
            _driver.SafeEnterText(AddUsersUI.department, department);
        }

        //Enter About Me
        public void EnterAboutMe(String aboutMe)
        {
            _driver.SafeEnterText(AddUsersUI.aboutMe, aboutMe);
        }

        //Enter My Top Skills
        public void EnterMyTopSkills(String myTopSkills)
        {
            _driver.SafeEnterText(AddUsersUI.myTopSkills, myTopSkills);
        }

        //Enter Other Skills
        public void EnterOtherSkills(String otherSkills)
        {
            _driver.SafeEnterText(AddUsersUI.otherSkills, otherSkills);
        }

        /*//Enter Industry / Domain Expertise
        public void EnterIndustryDomainExpertise(String industryDomainExpertise)
        {
            _driver.SafeEnterText(AddUsersUI.industryDomainExpertise, industryDomainExpertise);
        }*/

        //Enter Languages
        public void EnterLanguages(String languages)
        {
            _driver.SafeEnterText(AddUsersUI.languages, languages);
        }

        //Enter Interested In
        public void EnterDevelopmentSkills(String devSkills)
        {
            _driver.SafeEnterText(AddUsersUI.devSkills, devSkills);
        }

        //Enter LinkedIn Url
        public void EnterLinkedInUrl(String linkedInUrl)
        {
            _driver.SafeEnterText(AddUsersUI.linkedInUrl, linkedInUrl);
        }

        //Enter Phone
        public void EnterPhone(String phone)
        {
            _driver.SafeEnterText(AddUsersUI.phone, phone);
        }

        //Enter Address
        public void EnterAddress(String address)
        {
            _driver.SafeEnterText(AddUsersUI.address, address);
        }

        //Enter City
        public void EnterCity(String city)
        {
            _driver.SafeEnterText(AddUsersUI.city, city);
        }

        //Enter State/Province
        public void EnterStateProvince(String stateProvince)
        {
            _driver.SafeEnterText(AddUsersUI.stateProvince, stateProvince);
        }

        //Enter Postal Code
        public void EnterPostalCode(String postalCode)
        {
            _driver.SafeEnterText(AddUsersUI.postalCode, postalCode);
        }

        //Enter Country
        public void EnterCountry(String country)
        {
            _driver.SafeEnterText(AddUsersUI.country, country);
        }

        //Click Create button
        public void ClickCreate()
        {
            _driver.SafeClick(AddUsersUI.createBtn);
        }

        //Verify the added user
        public void VerifyAddedUserName(string fullName)
        {
            _assertHelper.AssertElementDisplayed(AddUsersUI.addedUserName(fullName));
        }

        //Switch to iframe
        public void SwitchIframe()
        {
            _driver.switchFrameById("publicshowmaildivcontent");
        }

        //Select Expertise Drop-Down
        public void SelectExpertiseDropDown(String expertise)
        {
            _driver.SelectDropDownOption(expertise, OnboardingUI.expertiseDropDown);
        }

        //Click Next LinkedIn Option
        public void ClickNextLinkedIn()
        {
            _driver.SafeClick(OnboardingUI.linkedInNextBtn);
        }

        //Click Expertise Continue button
        public void ClickExpertiseContinueBtn()
        {
            _driver.SafeClick(OnboardingUI.continueExpertiseBtn);
        }

        //Enter Skills
        public void EnterSkills(string skill)
        {
            _driver.SafeEnterText(OnboardingUI.inputSkills, skill);
        }

        //Enter Harakirimail Inout Email Address
        public void EnterHarakirimailEmail(String email)
        {
            _driver.SafeEnterText(OnboardingUI.harakiriInputEmail, email);
        }

        //Click Mailinator Go button
        public void ClickGoBtn()
        {
            _driver.SafeClick(OnboardingUI.goButton);
        }

        //Click ViewMyProfile button
        public void ClickViewMyProfileBtn()
        {
            _driver.SafeClick(OnboardingUI.viewMyProfileBtn);
        }

        //Assert SkillOne
        public void AssertSkillOne(string skill)
        {
            _driver.SafeClick(OnboardingUI.skillOne(skill));
        }

        //Click Done button on Profile
        public void ClickDoneBtn()
        {
            _driver.ClickElementUsingAction(OnboardingUI.doneBtn);
        }

        //Click sign-up button
        public void ClickSignUpBtn()
        {
            _driver.SafeClick(AddUsersUI.signUpBtn);
        }

        //Assert SkillTwo
        public void AssertSkillTwo(string skill)
        {
            _driver.SafeClick(OnboardingUI.skillTwo(skill));
        }

        //Click the email Subject
        public void ClickEmailSubject()
        {
            _driver.ClickElementUsingAction(OnboardingUI.harakiriInviteUserSubject);
        }

        //Click the email Subject
        public void ClickRecruitedEmailSubject()
        {
            _driver.ClickElementUsingAction(OnboardingUI.harakiriRecruitedUserSubject);
        }

        

        public void VerifyUploadedUser()
        {
           _assertHelper.AssertElementTextContains(AddUsersUI.uploadedUserMessageDiv, "You've just uploaded 0 users!");
        }


    }
}
