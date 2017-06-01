using log4net;
using NUnit.Framework;
using RallyTeam.UILocators;
using RallyTeam.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RallyTeam.TestScripts
{
    [TestFixture]
    [Category("Vendors")]
    public class VendorTest : BaseTestES
    {
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        AddUsersTest addUsersTest = new AddUsersTest();
        StringBuilder builder;
        String email;

        public void GoToAddUser()
        {
            builder = new StringBuilder();
            builder.Append(RandomString(6));

            //Click User Profile Icon
            userProfilePage.ClickUserProfileIcon();
            log.Info("Click the User Profile Icon.");
            Thread.Sleep(2000);

            //Select the User Profile Option 'Admin'
            userProfilePage.ClickUserProfileOptions("Admin");
            log.Info("Click User Profile option 'Admin'.");
            Thread.Sleep(5000);

            //Click Add Users button
            addUsersPage.ClickAddUsersBtn();
            log.Info("Click Add Users button.");
            Thread.Sleep(5000);
        }

        //SignIn
        private void SignInDifferentUser(string username, string password)
        {
            authenticationPage.SetUserName(username);
            authenticationPage.SetPassword(password);
            authenticationPage.ClickOnLoginButton();
        }

        /*[Test]
        public void Vendor_001_AdminAddsVendorProfile()
        {
            Global.MethodName = "Vendor_001_AdminAddsVendorProfile";
            Thread.Sleep(5000);

            builder = new StringBuilder();
            builder.Append(RandomString(6));
            
            //Click User Profile Icon
            userProfilePage.ClickUserProfileIcon();
            log.Info("Click the User Profile Icon.");
            Thread.Sleep(2000);

            //Select the User Profile Option 'Admin'
            userProfilePage.ClickUserProfileOptions("Admin");
            log.Info("Click User Profile option 'Admin'.");
            Thread.Sleep(5000);

            //Click Vendors Tab
            vendorPage.ClickVendorsTab();
            log.Info("Click Vendors tab.");
            Thread.Sleep(5000);

            //Click Add Vendors button
            vendorPage.ClickAddVendorsBtn();
            log.Info("Click Add Vendors button.");
            Thread.Sleep(5000);

            //Enter Company Name
            vendorPage.EnterCompanyName(builder.ToString());
            log.Info("Enter Vendor Company Name.");
            Thread.Sleep(2000);

            //Enter Company Description
            vendorPage.EnterCompanyDesc("TestDescOne");
            log.Info("Enter Vendor Company Description.");
            Thread.Sleep(2000);

            //Enter Services
            for (int i = 1; i <= 5; i++)
            {
                vendorPage.EnterServices(i.ToString());
                log.Info("Enter Vendor Company Services.");
                commonPage.PressEnterKey();
                Thread.Sleep(2000);
            }

            //Select Vendor Owner
            vendorPage.SelectVendorOwner("mayank sharma");
            log.Info("Select Vendor Owner.");
            Thread.Sleep(2000);

            //Enter Company Location
            vendorPage.EnterCompanyLocation("India");
            log.Info("Enter Vendor Company Location.");
            Thread.Sleep(2000);

            //Enter Company Phone
            vendorPage.EnterCompanyPhone("9871002500");
            log.Info("Enter Vendor Company Phone.");
            Thread.Sleep(2000);

            //Enter Company Website
            vendorPage.EnterCompanyWebsite("www.vendorindia.com");
            log.Info("Enter Vendor Company Website.");
            Thread.Sleep(2000);

            //Enter Skills
            vendorPage.EnterSkills("Testing");
            log.Info("Enter Skills.");
            Thread.Sleep(2000);
            commonPage.PressEnterKey();
            Thread.Sleep(2000);

            //Enter Company Facebook
            vendorPage.EnterCompanyFacebook("www.fb.com");
            log.Info("Enter Vendor Company Facebook.");
            Thread.Sleep(2000);

            //Enter Company Twitter
            vendorPage.EnterCompanyTwitter("www.twt.com");
            log.Info("Enter Vendor Company Twitter.");
            Thread.Sleep(2000);

            //Enter Company LinkedIn
            vendorPage.EnterCompanyLinkedIn("www.link.com");
            log.Info("Enter Vendor Company LinkedIn.");
            Thread.Sleep(2000);

            //Click Create Profile button
            vendorPage.ClickCreateProfile();
            log.Info("Click Create Profile button.");
            Thread.Sleep(4000);

            //Verify Vendor Created Message
            vendorPage.VerifyVendorCreatedMsg();
            log.Info("Verify Vendor Created Message.");
        }

        [Test]
        public void Vendor_002_NewVendorUserCreateVendorProfile()
        {
            Global.MethodName = "Vendor_002_NewVendorUserCreateVendorProfile";
            Thread.Sleep(5000);
            GoToAddUser();

            //Click Email button
            addUsersPage.ClickEmailBtn();
            log.Info("Click Email button.");
            Thread.Sleep(5000);

            //Enter Email Address
            email = builder + "@harakirimail.com";
            addUsersPage.EnterEmailAddresses(email);
            log.Info("Enter Email Address.");
            commonPage.PressTabKey();
            Thread.Sleep(2000);

            //Click Add Users button
            addUsersPage.ClickEmailAddUsersBtn();
            log.Info("Click Add Users button.");
            Thread.Sleep(5000);

            //Click Finish button
            addUsersPage.ClickFinishBtn();
            log.Info("Click Finish button.");
            Thread.Sleep(5000);

            //Navigate to the user inbox
            commonPage.NavigateToUrl("https://www.harakirimail.com/");
            log.Info("Navigate to the mailinator site.");
            Thread.Sleep(7000);

            //Enter Harakirimail Email address
            addUsersPage.EnterHarakirimailEmail(email);
            log.Info("Enter email address.");
            Thread.Sleep(2000);

            //Press Enter key
            commonPage.PressEnterKey();
            Thread.Sleep(5000);

            //Click the Email Subject
            addUsersPage.ClickEmailSubject();
            log.Info("Click the Email Subject.");
            Thread.Sleep(5000);

            //Click Get Started button
            addUsersPage.ClickGetStartedBtn();
            log.Info("Click the Get Started Button.");

            //Enter First Name on the screen
            registrationPage.EnterFirstName(builder.ToString());
            log.Info("Enter First Name on the screen.");
            Thread.Sleep(2000);

            //Enter Last Name on the screen
            registrationPage.EnterLastName(builder.ToString());
            log.Info("Enter Last Name on the screen.");
            Thread.Sleep(2000);

            //Click SignUp button on the screen
            registrationPage.ClickSignUpBtn();
            log.Info("Click SignUp button on the screen.");
            Thread.Sleep(5000);

            //Enter Create a Password field on the screen
            registrationPage.EnterCreatePwdFields("Logica360");
            log.Info("Enter Create a Password field on the screen.");
            Thread.Sleep(2000);

            //Enter Confirm Password field on the screen
            registrationPage.EnterConfirmPwdFields("Logica360");
            log.Info("Enter Confirm Password field on the screen.");
            Thread.Sleep(2000);

            //Click All Done Button on the screen
            registrationPage.ClickAllDoneBtn();
            log.Info("Click All Done button on the screen.");
            Thread.Sleep(7000);

            //Verify the Get Started button
            addUsersPage.VerifyGetStartedBtn();
            log.Info("Verify Get Started button.");

            //Click Get Started button
            addUsersPage.ClickGetStartedBtn();
            log.Info("Click Get Staerted button.");
            Thread.Sleep(5000);

            //Click Linkedin Next button
            addUsersPage.ClickNextLinkedIn();
            log.Info("Click Next button on LinkedIn Page.");
            Thread.Sleep(5000);

            //Select Expertise
            addUsersPage.SelectExpertiseDropDown("Information Technology");
            log.Info("Select Expertise.");
            Thread.Sleep(2000);

            //Click Expertise Continue button
            addUsersPage.ClickExpertiseContinueBtn();
            log.Info("Click Expertise Continue button.");
            Thread.Sleep(5000);

            //Enter Skills
            addUsersPage.EnterSkills("Android");
            Thread.Sleep(2000);
            commonPage.PressEnterKey();
            Thread.Sleep(2000);
            addUsersPage.EnterSkills("Computer science");
            Thread.Sleep(2000);
            commonPage.PressEnterKey();
            Thread.Sleep(2000);

            //Click View My Profile button
            addUsersPage.ClickViewMyProfileBtn();
            log.Info("Click View My Profile button.");
            Thread.Sleep(5000);                  

            //Click Done button on Profile
            commonPage.ScrollUp();
            Thread.Sleep(2000);
            addUsersPage.ClickDoneBtn();
            log.Info("Click Done button.");
            Thread.Sleep(5000);

            try
            {
                vendorPage.VerifyVendorFirstWindow();
            }

            catch(Exception e)
            { 
                //Signout of the application
                Thread.Sleep(5000);
                authenticationPage.SignOut();
                log.Info("Click on the Signout button.");

                //SignIn with Admin
                Thread.Sleep(5000);
                SignInDifferentUser("ammark@360logica.com", "Logica360");

                //Click User Profile Icon
                Thread.Sleep(5000);
                userProfilePage.ClickUserProfileIcon();
                log.Info("Click the User Profile Icon.");
                Thread.Sleep(2000);

                //Select the User Profile Option 'Admin'
                userProfilePage.ClickUserProfileOptions("Admin");
                log.Info("Click User Profile option 'Admin'.");
                Thread.Sleep(5000);

                //Enter Search User Email Id
                userProfilePage.EnterSearchUser(email);
                log.Info("Enter search user email id.");
                Thread.Sleep(2000);

                //Press Enter Key
                userProfilePage.PressEnterKey();
                Thread.Sleep(2000);

                //Change group to Vendor
                vendorPage.SelectGroup();
                log.Info("Change the user group to Vendor");
                Thread.Sleep(2000);

                //Signout of the application
                Thread.Sleep(5000);
                authenticationPage.SignOut();
                log.Info("Click on the Signout button.");

                //SignIn with new Vendor
                Thread.Sleep(5000);
                SignInDifferentUser(email, "Logica360");
            }

            //Click Get Started button
            Thread.Sleep(5000);
            vendorPage.ClickGetStartedBtn();
            log.Info("Click Get Started Button.");

            //Enter Company Name
            Thread.Sleep(5000);
            vendorPage.EnterCompanyName(builder.ToString()+" Vendor");
            log.Info("Enter Vendor Company Name.");
            Thread.Sleep(2000);

            //Enter Company Description
            vendorPage.EnterCompanyDesc("TestDesc");
            log.Info("Enter Vendor Company Description.");
            Thread.Sleep(2000);

            //Enter Services
            for (int i = 1; i <= 5; i++)
            {
                vendorPage.EnterServices(i.ToString());
                log.Info("Enter Vendor Company Services.");
                commonPage.PressEnterKey();
                Thread.Sleep(2000);
            }

            //Enter Company Location
            vendorPage.EnterCompanyLocation("India");
            log.Info("Enter Vendor Company Location.");
            Thread.Sleep(2000);

            //Enter Company Phone
            vendorPage.EnterCompanyPhone("9871002500");
            log.Info("Enter Vendor Company Phone.");
            Thread.Sleep(2000);

            //Enter Company Website
            vendorPage.EnterCompanyWebsite("www.vendorindia.com");
            log.Info("Enter Vendor Company Website.");
            Thread.Sleep(2000);

            //Enter Skills
            vendorPage.EnterSkills("Testing");
            log.Info("Enter Skills.");
            Thread.Sleep(2000);
            commonPage.PressEnterKey();
            Thread.Sleep(2000);

            //Enter Company Facebook
            vendorPage.EnterCompanyFacebook("www.fb.com");
            log.Info("Enter Vendor Company Facebook.");
            Thread.Sleep(2000);

            //Enter Company Twitter
            vendorPage.EnterCompanyTwitter("www.twt.com");
            log.Info("Enter Vendor Company Twitter.");
            Thread.Sleep(2000);

            //Enter Company LinkedIn
            vendorPage.EnterCompanyLinkedIn("www.link.com");
            log.Info("Enter Vendor Company LinkedIn.");
            Thread.Sleep(2000);

            //Click Create Profile button
            vendorPage.ClickCreateProfile();
            log.Info("Click Create Profile button.");
            Thread.Sleep(4000);

            //Verify Vendor Created Message
            vendorPage.VerifyVendorCreatedMsg();
            log.Info("Verify Vendor Created Message.");
        }*/
    }
}
