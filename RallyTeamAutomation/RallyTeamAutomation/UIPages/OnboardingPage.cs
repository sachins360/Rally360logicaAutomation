using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using RallyTeam.UILocators;
using RallyTeam.Util;
using System.Threading;
using RallyTeam.UILocators;

namespace RallyTeam.UIPages
{
    public class OnboardingPage : BasePage
    {
        CommonMethods commonPage;

        public OnboardingPage(IWebDriver driver, int pageLoadTimeout)
            : base(driver, pageLoadTimeout)
        {
            commonPage = new CommonMethods(_driver, pageLoadTimeout);
        }

        public OnboardingPage NavigateTo(String _URL)
        {
            _driver.Navigate().GoToUrl(_URL);
            return this;
        }

        //Assert the Please check your inbox message
        public void VerifyWeJustSentYouAnEmailMsg()
        {
            _assertHelper.AssertElementDisplayed(OnboardingUI.weJustSentYouAnEmail);
        }

        //Assert Resend Email button
        public void VerifyResendEmailbtn()
        {
            _assertHelper.AssertElementDisplayed(RegistrationUI.resendEmailBtn);
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

        //Assert the email sender
        public void VerifyEmailSender()
        {
            _assertHelper.AssertElementDisplayed(OnboardingUI.emailSender);
        }

        //Click the email Subject
        public void ClickEmailSubject()
        {
            _driver.ClickElementUsingAction(OnboardingUI.harakiriInviteUserSubject);
        }

        //Assert the email subject
        public void VerifyEmailSubject()
        {
            _assertHelper.AssertElementDisplayed(OnboardingUI.emailSender);
        }

        //Assert the Verify Your Email button
        public void VerifyYourEmailBtn()
        {
            _assertHelper.AssertElementDisplayed(OnboardingUI.verifyYourEmailBtn);
        }

        //Get the email link
        public String GetEmailLink()
        {
            return _driver.GetElementAttributeValue(OnboardingUI.harakiriVerifyYourEmailBtn, "href");
        }

        //Switch to iframe
        public void SwitchIframe()
        {
            _driver.switchFrameById("publicshowmaildivcontent");
        }

        //Click Let's Go button
        public void ClickLetsGoBtn()
        {
            _driver.SafeClick(OnboardingUI.LetsGoBtn);
        }

        //Assert Welcome User message
        public void VerifyWelcomeUserMsg(String userFirstName)
        {
            _assertHelper.AssertElementDisplayed(OnboardingUI.WelcomeUser(userFirstName));
        }

        //Assert Welcome RallyTeam message
        public void VerifyWelcomeRallyTeamMsg()
        {
            _assertHelper.AssertElementDisplayed(OnboardingUI.welcomeRallyTeam);
        }

        //Assert Get Started button
        public void VerifyGetStartedBtn()
        {
            _assertHelper.AssertElementDisplayed(OnboardingUI.getStartedBtn);
        }

        //Click Get Started button
        public void ClickGetStartedBtn()
        {
            _driver.WaitForElementAvailableAtDOM(OnboardingUI.getStartedBtn, 1);
            _driver.SafeClick(OnboardingUI.getStartedBtn);
        }

        //Assert LinkeDin Confirmation message
        public void VerifyLinkedInConfirmationMsg()
        {
            _assertHelper.AssertElementDisplayed(OnboardingUI.linkedInConfirmationMsg);
        }

        //Assert Connect with LinkedIn button
        public void VerifyConnectWithLinkedInbtn()
        {
            _assertHelper.AssertElementDisplayed(OnboardingUI.linkedInBtn);
        }

        //Assert Skip LinkedIn Option
        public void VerifySkipLinkedIn()
        {
            _assertHelper.AssertElementDisplayed(OnboardingUI.skipLinedIn);
        }
        
        //Click Skip LinkedIn Option
        public void ClickSkipLinkedIn()
        {
            _driver.WaitForElementAvailableAtDOM(OnboardingUI.skipLinedIn, 1);
            _driver.SafeClick(OnboardingUI.skipLinedIn);
        }

        //Click Next LinkedIn Option
        public void ClickNextLinkedIn()
        {
            _driver.SafeClick(OnboardingUI.linkedInNextBtn);
        }

        //Assert Upload Your Resume message
        public void VerifyUploadResumeMsg()
        {
            _assertHelper.AssertElementDisplayed(OnboardingUI.uploadResumeMsg);
        }

        //Assert Upload Your Resume button
        public void VerifyUploadYourResumeBtn()
        {
            _assertHelper.AssertElementDisplayed(OnboardingUI.uploadResumeBtn);
        }

        //Click Upload Your Resume button
        public void ClickUploadYourResumeBtn()
        {
            _assertHelper.AssertElementDisplayed(OnboardingUI.uploadResumeBtn);
        }

        //Assert Skip Upload Resume Option
        public void VerifySkipUploadResume()
        {
            _assertHelper.AssertElementDisplayed(OnboardingUI.skipUploadResume);
        }

        //Click Skip Upload Resume Option
        public void ClickSkipUploadResume()
        {
            _driver.WaitForElementAvailableAtDOM(OnboardingUI.skipUploadResume, 1);
            _driver.SafeClick(OnboardingUI.skipUploadResume);
        }
        
        //Assert Expertise Drop-Down
        public void VerifyExpertiseDropDown()
        {
            _assertHelper.AssertElementDisplayed(OnboardingUI.expertiseDropDown);
        }

        //Select Expertise Drop-Down
        public void SelectExpertiseDropDown(String expertise)
        {
            _driver.SelectDropDownOption(expertise, OnboardingUI.expertiseDropDown);
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

        //Assert ViewMyProfile button
        public void VerifyViewMyProfileBtn()
        {
            _assertHelper.AssertElementDisplayed(OnboardingUI.viewMyProfileBtn);
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

        //Assert SkillTwo
        public void AssertSkillTwo(string skill)
        {
            _driver.SafeClick(OnboardingUI.skillTwo(skill));
        }

        //Click Done button on Profile
        public void ClickDoneBtn()
        {
            _driver.ClickElementUsingAction(OnboardingUI.doneBtn);
        }

        /*//Count the number of skills and fail if more than 3
        public void CountSkillsAndFailIfMoreThanThree()
        {
            IWebElement ulItems = _driver.FindElement(OnboardingUI.AllSkills);
            IList<IWebElement> liItems = ulItems.FindElements(By.TagName("li"));
            int count = liItems.Count;
            Console.WriteLine("No Of Li items: " + count);
            if (count >= 4)
            {
                _assertHelper.AssertFailTestCase();
            }
        }*/

        //Get the Confirmation Code from Email
        public string GetConfirmationCode()
        {
            return _driver.GetElementText(OnboardingUI.confirmationCode);
        }
        
        //test
        public void test()
        {
            _driver.SafeClick(OnboardingUI.inputCodeOne);
        }

        //test
        public void testtwo()
        {
            _driver.FocusAndBlurUsingJS(OnboardingUI.inputCodeSix);
        }

        //Enter Code1
        public void EnterCodeOne(string codeOne)
        {
            _driver.EnterTextUsingAction(OnboardingUI.inputCodeOne, codeOne);

        }        

        //Enter Code2
        public void EnterCodeTwo(string codeTwo)
        {
            _driver.EnterTextUsingAction(OnboardingUI.inputCodeTwo, codeTwo);
        }

        //Enter Code3
        public void EnterCodeThree(string codeThree)
        {
            _driver.EnterTextUsingAction(OnboardingUI.inputCodeThree, codeThree);
        }

        //Enter Code4
        public void EnterCodeFour(string codeFour)
        {
            _driver.EnterTextUsingAction(OnboardingUI.inputCodeFour, codeFour);
        }

        //Enter Code
        public void EnterCodeFive(string codeFive)
        {
            _driver.EnterTextUsingAction(OnboardingUI.inputCodeFive, codeFive);
        }

        //Enter Code
        public void EnterCodeSix(string codeSix)
        {
            _driver.EnterTextUsingAction(OnboardingUI.inputCodeSix, codeSix);
        }        

        //Click Lets Rally button
        public void ClickLetsRallyBtn()
        {
            _driver.ClickElementUsingJS(OnboardingUI.letsRallyBtn);
        }

        
















    }
}
