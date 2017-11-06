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

namespace RallyTeam.UIPages
{
    public class InviteUsersPage : BasePage
    {
        CommonMethods commonPage;

        public InviteUsersPage(IWebDriver driver, int pageLoadTimeout)
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

        //Click Invite Users button
        public void ClickInviteUsersBtn()
        {
            _driver.SafeClick(InviteUsersUI.inviteUserBtn);
        }

        //Assert Let's expand your network! message
        public void VerifyLetsExpandYourNetworkMsg()
        {
            _assertHelper.AssertElementDisplayed(InviteUsersUI.letsExpandYourNetworkMsg);
        }

        //Assert Upload your employees, external contractors, or contacts message
        public void VerifyUploadkMsg()
        {
            _assertHelper.AssertElementDisplayed(InviteUsersUI.uploadMsg);
        }        

        //Assert Close icon
        public void VerifyCloseIcon()
        {
            _assertHelper.AssertElementDisplayed(InviteUsersUI.closeIcon);
        }

        //Assert Maybe Later option
        public void VerifyMayBeLaterOption()
        {
            _assertHelper.AssertElementDisplayed(InviteUsersUI.mayBeLater);
        }

        //Assert Google button
        public void VerifyGoogleBtn()
        {
            _assertHelper.AssertElementDisplayed(InviteUsersUI.googleBtn);
        }

        //Assert Outlook button
        public void VerifyOutlookBtn()
        {
            _assertHelper.AssertElementDisplayed(InviteUsersUI.outlookBtn);
        }

        //Assert CSV button
        public void VerifyCsvBtn()
        {
            _assertHelper.AssertElementDisplayed(InviteUsersUI.csvBtn);
        }

        //Assert Email button
        public void VerifyEmailBtn()
        {
            _assertHelper.AssertElementDisplayed(InviteUsersUI.emailBtn);
        }

        //Click Email button
        public void ClickEmailBtn()
        {
            _driver.SafeClick(InviteUsersUI.emailBtn);
        }

        //Enter Email Addresses
        public void EnterEmailAddresses(String email)
        {
            _driver.SafeEnterText(InviteUsersUI.emailAddressesInput, email);
        }

        //Click Send Invites button
        public void ClickSendInvitesBtn()
        {
            _driver.SafeClick(InviteUsersUI.sendInvitesBtn);
        }

        //Click Finish button
        public void ClickFinishBtn()
        {
            _driver.SafeClick(InviteUsersUI.finishBtn);
        }

        //Assert the email sender
        public void VerifyEmailSender()
        {
            _assertHelper.AssertElementDisplayed(OnboardingUI.emailSender);
        }

        //Click the email sender
        public void ClickEmailSender()
        {
            _driver.ClickElementUsingAction(OnboardingUI.emailSender);
        }

        //Assert the email subject
        public void VerifyEmailSubject()
        {
            _assertHelper.AssertElementDisplayed(OnboardingUI.emailSender);
        }

        //Assert the Let's Rally Button
        public void VerifyLetsRallyBtn()
        {
            _assertHelper.AssertElementDisplayed(InviteUsersUI.letsRallyBtn);
        }

        //Get the email link
        public String GetEmailLink()
        {
            return _driver.GetElementAttributeValue(OnboardingUI.verifyYourEmailBtn, "href");
        }

    }
}
