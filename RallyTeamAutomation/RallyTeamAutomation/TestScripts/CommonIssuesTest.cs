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

namespace RallyTeam.TestScripts
{
    [TestFixture("ExternalStormURL", "chrome", Category = "CommonIssuesChromePreprod")]
    [TestFixture("ExternalStormURL", "firefox", Category = "CommonIssuesFirefoxPreprod")]
    [TestFixture("Production", "chrome", Category = "CommonIssuesChromeProduction")]
    [TestFixture("Production", "firefox", Category = "CommonIssuesFirefoxProduction")]
    //[Parallelizable(ParallelScope.Fixtures)]
    public class CommonIssuesTest : BaseTestES
    {
        public CommonIssuesTest(string urlKey, string Browser) : base(urlKey, Browser)
        {
            String url = urlKey;
        }
        static ReadData commonIssues = new ReadData("CommonIssues");

        //SignIn
        private void SignInDifferentUser()
        {
            String userName = commonIssues.GetValue("SignInDifferentUser", "userName");
            String password = commonIssues.GetValue("SignInDifferentUser", "password");
            authenticationPage.SetUserName(userName);
            authenticationPage.SetPassword(password);
            authenticationPage.ClickOnLoginButton();
        }

        [Test, CustomRetry(_reTryCount)]
        public void CommonIssues_001_VerifyDeactivatedUserLogin()
        {
            Global.MethodName = "CommonIssues_001_VerifyDeactivatedUserLogin";

            /*//Click User Profile Icon
            Thread.Sleep(5000);
            userProfilePage.ClickUserProfileIcon();
            log.Info("Click the User Profile Icon.");
            Thread.Sleep(2000);

            //Select the User Profile Option 'Admin'
            userProfilePage.ClickUserProfileOptions("Admin");
            log.Info("Click User Profile option 'Admin'.");
            Thread.Sleep(5000);

            //Click Users tab
            userProfilePage.ClickManageUsersTab();
            log.Info("Click Users Tab.");
            Thread.Sleep(3000);

            //Search the user
            userProfilePage.EnterSearchUser("deactivated@harakirimail.com");
            log.Info("Search a user.");
            Thread.Sleep(1000);
            commonPage.PressEnterKey();
            Thread.Sleep(5000);

            //Verify if the user is deactivated. If not, deactivate it
            commonIssuePage.DeaactivateUser();
            log.Info("Deactivate the user, if not already deactivated.");
            Thread.Sleep(5000);*/

            //Signout of the application
            Thread.Sleep(5000);
            authenticationPage.SignOut();
            log.Info("Click on the Signout button.");
            Thread.Sleep(5000);

            //Sign in with deactivated user
            authenticationPage.SetUserName("deactivated@harakirimail.com");
            authenticationPage.SetPassword("Logica360");
            authenticationPage.ClickOnLoginButton();
            Thread.Sleep(5000);
            commonIssuePage.VerifyDeactivateUserMsg();
        }

        [Test, CustomRetry(_reTryCount)]
        public void CommonIssues_002_VerifyNoErrorOnOpeningUserProfile()
        {
            Global.MethodName = "CommonIssues_002_VerifyNoErrorOnOpeningUserProfile";

            Thread.Sleep(5000);
            directoryPage.ClickUserProfileIcon();
            log.Info("Click the User Profile Icon.");
            Thread.Sleep(2000);

            //Select the User Profile Option 'Profile'
            directoryPage.ClickUserProfileOptions("Profile");
            log.Info("Click User Profile option 'Profile'.");

            //Verify error message not displayed on opening profile page
            commonIssuePage.VerifyErrorMsgNotDisplayedOpeningUserProfile();
            log.Info("Verify error message not displayed on opening profile page.");
            Thread.Sleep(2000);
        }





















    }
}
