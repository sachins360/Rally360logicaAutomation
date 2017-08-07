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
    [Category("Invoicing")]
    public class InvoicingTest : BaseTestES
    {
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        static ReadData readInvoicing = new ReadData("Invoicing");
        static ReadData readPostProject = new ReadData("PostProject");

        //SignIn
        private void SignInDifferentUser()
        {
            String userName = readInvoicing.GetValue("SignInDifferentUser", "userName");
            String password = readInvoicing.GetValue("SignInDifferentUser", "password");
            authenticationPage.SetUserName(userName);
            authenticationPage.SetPassword(password);
            authenticationPage.ClickOnLoginButton();
        }

        //Create New Invoice
        public void CreateInvoice(String invoiceTitle, String projectName)
        {
            //Click New Invoice button
            Thread.Sleep(5000);
            invoicingPage.ClickNewInvoiceBtn();
            log.Info("Click the New Invoice button.");

            //Create New Invoice
            Thread.Sleep(5000);
            invoicingPage.EnterInvoiceTitle(invoiceTitle);
            log.Info("Enter the Invoice Title.");
            Thread.Sleep(1000);

            //Click the Due Date Field
            invoicingPage.ClickDueDateField();
            log.Info("Click Due Date Field.");
            Thread.Sleep(1000);

            //Select today's date
            invoicingPage.ClickTodaysDate();
            log.Info("Select today's date.");
            Thread.Sleep(2000);

            //Enter Invoice Total Amount
            String invoiceTotal = readInvoicing.GetValue("InvoiceDetails", "invoiceTotal");
            invoicingPage.EnterInvoiceTotal(invoiceTotal);
            log.Info("Enter the Invoice Total Amount");
            Thread.Sleep(1000);

            //Select Project
            invoicingPage.SelectProject(projectName);
            log.Info("Select Project.");
            Thread.Sleep(2000);

            //Enter Invoice Notes
            invoicingPage.EnterNotes("Invoice Notes");
            log.Info("Enter Invoice Notes");
            Thread.Sleep(2000);
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

        public void openFeatureTab()
        {
            //Click User Profile Icon
            Thread.Sleep(5000);
            userProfilePage.ClickUserProfileIcon();
            log.Info("Click User Profile Icon.");
            Thread.Sleep(2000);

            //Click Admin from the User Profile Options
            userProfilePage.ClickUserProfileOptions("Admin");
            log.Info("Click User Profile option 'Admin'.");
            Thread.Sleep(5000);

            //Click Features Tab
            groupsPage.ClickFeaturesTab();
            log.Info("Click Features Tab");
            Thread.Sleep(3000);

        }

        public void setPayorName(string _payorName)
        {

            commonPage.ScrollDown();
            //Set Designated Payor
            commonIssuePage.EnterInvoiceDesignatedPayor(_payorName);

            //click on save button
            _driver.SafeClick(DashboardUI.btnSave);
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
            String projectDesc = readPostProject.GetValue("AddProjectDetails", "projectDesc");
            postProjectPage.EnterProjectDescription(projectDesc);
            Thread.Sleep(1000);

            //Click Continue Button
            postProjectPage.ClickContinueBtn();
            log.Info("Click on the Continue button.");
            Thread.Sleep(5000);

            //Enter Skills
            commonPage.ScrollUp();
            String skills = readPostProject.GetValue("AddProjectDetails", "skills");
            postProjectPage.EnterSkillsNeeded(skills);
            Thread.Sleep(3000);
            commonPage.PressEnterKey();
            Thread.Sleep(2000);
            log.Info("Enter Skills.");

            String addMembersEmail = readPostProject.GetValue("AddProjectDetails", "memberEmail");
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

        [Test]
        public void Invoicing_001_CreateAndVerifyDraftInvoice()
        {
            Global.MethodName = "Invoicing_001_CreateAndVerifyDraftInvoice";

            //Post a new project
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(6));
            String projectName = readPostProject.GetValue("AddProjectDetails", "projectName");
            projectName = projectName + builder;
            PostNewProject(projectName);

            //Signout of the application
            Thread.Sleep(5000);
            authenticationPage.SignOut();
            log.Info("Click on the Signout button.");

            //Sign in with a different user
            Thread.Sleep(2000);
            SignInDifferentUser();
            log.Info("Sign in with different user.");

            //Click Invoicing menu option
            Thread.Sleep(5000);
            invoicingPage.ClickInvoicingMenu();
            log.Info("Click the Invoicing menu.");

            //Create Invoice
            String invoiceTitle = readInvoicing.GetValue("InvoiceDetails", "invoiceTitle");
            invoiceTitle = invoiceTitle + builder;
            CreateInvoice(invoiceTitle, projectName);

            //Click Save Draft button
            invoicingPage.ClickSafeDraft();
            log.Info("Click Save Draft button.");
            Thread.Sleep(5000);

            //Verify Invoice Displayed
            invoicingPage.VerifyInvoiceDisplayed(invoiceTitle);
            log.Info("Click the Project Name on the Projects Page.");
            Thread.Sleep(5000);

            //Signout of the application
            authenticationPage.SignOut();
            log.Info("Click on the Signout button.");

            //Login to the application
            Thread.Sleep(5000);
            authenticationPage.SetUserName(_workEmail);
            authenticationPage.SetPassword(_password);
            authenticationPage.ClickOnLoginButton();

            //Click the Marketplace tab
            Thread.Sleep(5000);
            marketplacePage.ClickMarketplaceTab();
            log.Info("Click the Marketplace tab.");
            Thread.Sleep(5000);

            //Enter the Project Name
            Thread.Sleep(5000);
            postProjectPage.SearchProjectName(projectName);
            log.Info("Enter the project name.");
            Thread.Sleep(1000);

            //Click Search button
            postProjectPage.ClickSearchBtn();
            log.Info("Click the Search button.");
            Thread.Sleep(15000);

            //Click the created project
            postProjectPage.ClickProjectNameOnPage(projectName);
            log.Info("Click the Project Name on the Projects Page.");
            Thread.Sleep(10000);

            /*//Select Completed Projects from the All Projects drop-down
            marketplacePage.SelectAllProjectsDropDown("Completed Projects");
            log.Info("Select Completed Projects from the drop-down.");
            Thread.Sleep(5000);*/

            //Click the created Project
            invoicingPage.ClickProjectNameOnPage(projectName);
            log.Info("Click the Project Name on the Projects Page.");
            Thread.Sleep(10000);

            //Delete Project
            DeleteProject();
        }

        [Test]
        public void Invoicing_002_SubmitInvoiceAndVerifyStatus()
        {
            Global.MethodName = "Invoicing_002_SubmitInvoiceAndVerifyStatus";

            //Post a new project
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(6));
            String projectName = readPostProject.GetValue("AddProjectDetails", "projectName");
            projectName = projectName + builder;
            PostNewProject(projectName);

            //Signout of the application
            Thread.Sleep(5000);
            authenticationPage.SignOut();
            log.Info("Click on the Signout button.");

            //Sign in with a different user
            Thread.Sleep(5000);
            SignInDifferentUser();
            log.Info("Sign in with different user.");

            //Click Invoicing menu option
            Thread.Sleep(5000);
            invoicingPage.ClickInvoicingMenu();
            log.Info("Click the Invoicing menu.");

            //Create Invoice
            String invoiceTitle = readInvoicing.GetValue("InvoiceDetails", "invoiceTitle");
            invoiceTitle = invoiceTitle + builder;
            CreateInvoice(invoiceTitle, projectName);

            //Click Submit button
            invoicingPage.ClickSubmitBtn();
            log.Info("Click Submit button.");
            Thread.Sleep(5000);

            //Verify Invoice Displayed
            invoicingPage.VerifyInvoiceDisplayed(invoiceTitle);
            log.Info("Verify Invoice is displayed.");
            Thread.Sleep(1000);

            //Verify Invoice Status
            invoicingPage.VerifyInvoiceStatus("Pending Approval");
            log.Info("Verify Invoice Title is Pending Approval.");
            Thread.Sleep(5000);

            //Signout of the application
            authenticationPage.SignOut();
            log.Info("Click on the Signout button.");

            //Login to the application
            Thread.Sleep(5000);
            authenticationPage.SetUserName(_workEmail);
            authenticationPage.SetPassword(_password);
            authenticationPage.ClickOnLoginButton();

            //Click the Marketplace tab
            Thread.Sleep(5000);
            marketplacePage.ClickMarketplaceTab();
            log.Info("Click the Marketplace tab.");
            Thread.Sleep(5000);

            //Enter the Project Name
            Thread.Sleep(5000);
            postProjectPage.SearchProjectName(projectName);
            log.Info("Enter the project name.");
            Thread.Sleep(1000);

            //Click Search button
            postProjectPage.ClickSearchBtn();
            log.Info("Click the Search button.");
            Thread.Sleep(15000);

            //Click the created project
            postProjectPage.ClickProjectNameOnPage(projectName);
            log.Info("Click the Project Name on the Projects Page.");
            Thread.Sleep(10000);

            //Delete Project
            DeleteProject();
        }

        [Test]
        public void Invoicing_003_ApproveInvoiceAndVerifyStatus()
        {
            Global.MethodName = "Invoicing_003_ApproveInvoiceAndVerifyStatus";

            //Post a new project
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(6));
            String projectName = readPostProject.GetValue("AddProjectDetails", "projectName");
            projectName = projectName + builder;
            PostNewProject(projectName);

            //Signout of the application
            Thread.Sleep(5000);
            authenticationPage.SignOut();
            log.Info("Click on the Signout button.");

            //Sign in with a different user
            Thread.Sleep(2000);
            SignInDifferentUser();
            log.Info("Sign in with different user.");

            //Click Invoicing menu option
            Thread.Sleep(5000);
            invoicingPage.ClickInvoicingMenu();
            log.Info("Click the Invoicing menu.");

            //Create Invoice
            String invoiceTitle = readInvoicing.GetValue("InvoiceDetails", "invoiceTitle");
            invoiceTitle = invoiceTitle + builder;
            CreateInvoice(invoiceTitle, projectName);

            //Click Submit button
            invoicingPage.ClickSubmitBtn();
            log.Info("Click Submit button.");
            Thread.Sleep(5000);

            //Signout of the application
            authenticationPage.SignOut();
            log.Info("Click on the Signout button.");

            //Login to the application
            Thread.Sleep(5000);
            authenticationPage.SetUserName(_workEmail);
            authenticationPage.SetPassword(_password);
            authenticationPage.ClickOnLoginButton();

            //Click Invoicing menu option
            Thread.Sleep(5000);
            invoicingPage.ClickInvoicingMenu();
            log.Info("Click the Invoicing menu.");

            //Click Invoice Displayed
            invoicingPage.ClickInvoiceDisplayed(invoiceTitle);
            log.Info("Click Invoice displayed.");
            Thread.Sleep(5000);

            //Enter Comments
            invoicingPage.EnterComments("Invoice Approved");
            log.Info("Invoice Approved.");
            Thread.Sleep(1000);

            //Click Approve button
            invoicingPage.ClickApproveBtn();
            log.Info("Click the Approve button.");
            Thread.Sleep(5000);

            //Verify Invoice Status
            invoicingPage.VerifyInvoiceStatus("Approved");
            log.Info("Verify Invoice Title is Approved.");
            Thread.Sleep(1000);

            //Click the Marketplace tab
            Thread.Sleep(5000);
            marketplacePage.ClickMarketplaceTab();
            log.Info("Click the Marketplace tab.");
            Thread.Sleep(5000);

            //Enter the Project Name
            Thread.Sleep(5000);
            postProjectPage.SearchProjectName(projectName);
            log.Info("Enter the project name.");
            Thread.Sleep(1000);

            //Click Search button
            postProjectPage.ClickSearchBtn();
            log.Info("Click the Search button.");
            Thread.Sleep(15000);

            //Click the created project
            postProjectPage.ClickProjectNameOnPage(projectName);
            log.Info("Click the Project Name on the Projects Page.");
            Thread.Sleep(10000);

            //Delete Project
            DeleteProject();
        }

        [Test]
        public void Invoicing_004_DenyInvoiceAndVerifyStatus()
        {
            Global.MethodName = "Invoicing_004_DenyInvoiceAndVerifyStatus";

            //Post a new project
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(6));
            String projectName = readPostProject.GetValue("AddProjectDetails", "projectName");
            projectName = projectName + builder;
            PostNewProject(projectName);

            //Signout of the application
            Thread.Sleep(5000);
            authenticationPage.SignOut();
            log.Info("Click on the Signout button.");

            //Sign in with a different user
            Thread.Sleep(5000);
            SignInDifferentUser();
            log.Info("Sign in with different user.");

            //Click Invoicing menu option
            Thread.Sleep(5000);
            invoicingPage.ClickInvoicingMenu();
            log.Info("Click the Invoicing menu.");

            //Create Invoice
            String invoiceTitle = readInvoicing.GetValue("InvoiceDetails", "invoiceTitle");
            invoiceTitle = invoiceTitle + builder;
            CreateInvoice(invoiceTitle, projectName);

            //Click Submit button
            invoicingPage.ClickSubmitBtn();
            log.Info("Click Submit button.");
            Thread.Sleep(7000);

            //Signout of the application
            authenticationPage.SignOut();
            log.Info("Click on the Signout button.");

            //Login to the application
            Thread.Sleep(5000);
            authenticationPage.SetUserName(_workEmail);
            authenticationPage.SetPassword(_password);
            authenticationPage.ClickOnLoginButton();

            //Click Invoicing menu option
            Thread.Sleep(7000);
            invoicingPage.ClickInvoicingMenu();
            log.Info("Click the Invoicing menu.");

            //Click Invoice Displayed
            invoicingPage.ClickInvoiceDisplayed(invoiceTitle);
            log.Info("Click Invoice displayed.");
            Thread.Sleep(5000);

            //Enter Comments
            invoicingPage.EnterComments("Invoice Approved");
            log.Info("Invoice Approved.");
            Thread.Sleep(1000);

            //Click Deny button
            invoicingPage.ClickDenyBtn();
            log.Info("Click the Deny button.");
            Thread.Sleep(5000);

            //Verify Invoice Status
            invoicingPage.VerifyInvoiceStatus("Denied");
            log.Info("Verify Invoice Title is Denied.");
            Thread.Sleep(1000);

            //Click the Marketplace tab
            Thread.Sleep(5000);
            marketplacePage.ClickMarketplaceTab();
            log.Info("Click the Marketplace tab.");
            Thread.Sleep(5000);

            //Enter the Project Name
            Thread.Sleep(5000);
            postProjectPage.SearchProjectName(projectName);
            log.Info("Enter the project name.");
            Thread.Sleep(1000);

            //Click Search button
            postProjectPage.ClickSearchBtn();
            log.Info("Click the Search button.");
            Thread.Sleep(15000);

            //Click the created project
            postProjectPage.ClickProjectNameOnPage(projectName);
            log.Info("Click the Project Name on the Projects Page.");
            Thread.Sleep(10000);

            //Delete Project
            DeleteProject();
        }

        [Test]
        public void Invoicing_005_MarkPaidInvoiceAndVerifyStatus()
        {
            Global.MethodName = "Invoicing_005_MarkPaidInvoiceAndVerifyStatus";

            ////Post a new project
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(4));
            String projectName = readInvoicing.GetValue("AddProjectDetails", "projectName");
            projectName = projectName + builder;
            PostNewProject(projectName);

            /*//Set Feature Tab
            openFeatureTab();
            log.Info("OPen Feature Tab.");

            //Set payor name
            setPayorName(_workEmail);
            log.Info("Enter payor name.");*/


            //Signout of the application
            Thread.Sleep(5000);
            authenticationPage.SignOut();
            log.Info("Click on the Signout button.");

            //Sign in with a different user
            Thread.Sleep(2000);
            SignInDifferentUser();
            log.Info("Sign in with different user.");

            //Click Invoicing menu option
            Thread.Sleep(5000);
            invoicingPage.ClickInvoicingMenu();
            log.Info("Click the Invoicing menu.");

            //Create Invoice
            String invoiceTitle = readInvoicing.GetValue("InvoiceDetails", "invoiceTitle");
            invoiceTitle = invoiceTitle + builder;
            CreateInvoice(invoiceTitle, projectName);

            //Click Submit button
            invoicingPage.ClickSubmitBtn();
            log.Info("Click Submit button.");
            Thread.Sleep(5000);

            //Signout of the application
            authenticationPage.SignOut();
            log.Info("Click on the Signout button.");

            //Login to the application
            Thread.Sleep(5000);
            authenticationPage.SetUserName(_workEmail);
            authenticationPage.SetPassword(_password);
            authenticationPage.ClickOnLoginButton();

            //Click Invoicing menu option
            Thread.Sleep(5000);
            invoicingPage.ClickInvoicingMenu();
            log.Info("Click the Invoicing menu.");

            //Click Invoice Displayed
            invoicingPage.ClickInvoiceDisplayed(invoiceTitle);
            log.Info("Click Invoice displayed.");
            Thread.Sleep(5000);

            //Click the Comments Div
            //invoicingPage.ClickCommentsDiv();
            //log.Info("Click the Comments Div.");
            //Thread.Sleep(1000);

            ////Enter Comments
            //invoicingPage.EnterComments("Invoice Approved");
            //log.Info("Invoice Approved.");
            //Thread.Sleep(1000);

            //Click Approve button
            invoicingPage.ClickApproveBtn();
            log.Info("Click the Approve button.");
            Thread.Sleep(5000);

            //Click Invoice Displayed
            invoicingPage.ClickInvoiceDisplayed(invoiceTitle);
            log.Info("Click Invoice displayed.");
            Thread.Sleep(5000);

            //Click Mark As Paid button
            invoicingPage.ClickMarkAsPaidBtn();
            log.Info("Click the Mark As Paid button.");
            Thread.Sleep(5000);

            //Verify Invoice Status
            invoicingPage.VerifyInvoiceStatus("Paid");
            log.Info("Verify Invoice Title is Paid.");
            Thread.Sleep(1000);

            //Click the Marketplace tab
            Thread.Sleep(5000);
            marketplacePage.ClickMarketplaceTab();
            log.Info("Click the Marketplace tab.");
            Thread.Sleep(5000);

            //Click the Browse button
            marketplacePage.ClickBrowseBtn();
            log.Info("Click the Browse button.");
            Thread.Sleep(5000);
           
            //Enter the Project Name
            Thread.Sleep(5000);
            marketplacePage.EnterSearchField(projectName);
            log.Info("Enter the project name.");
            Thread.Sleep(1000);

            //Select Completed Projects from the All Projects drop-down
           // marketplacePage.SelectAllProjectsDropDown("Completed Projects");
           // log.Info("Select Completed Projects from the drop-down.");
           // Thread.Sleep(10000);

            //Click the created Project
            invoicingPage.ClickProjectNameOnPage(projectName);
            log.Info("Click the Project Name on the Projects Page.");
            Thread.Sleep(10000);

            //Delete Project
            DeleteProject();
        }

        //[Test]
        //public void Invoicing_006_EditDraftInvoice()
        //{
        //    Global.MethodName = "Invoicing_006_EditDraftInvoice";

        //    //Post a new project
        //    StringBuilder builder = new StringBuilder();
        //    builder.Append(RandomString(6));
        //    String projectName = readPostProject.GetValue("AddProjectDetails", "projectName");
        //    projectName = projectName + builder;
        //    PostNewProject(projectName);

        //    //Signout of the application
        //    Thread.Sleep(5000);
        //    authenticationPage.SignOut();
        //    log.Info("Click on the Signout button.");

        //    //Sign in with a different user
        //    Thread.Sleep(2000);
        //    SignInDifferentUser();
        //    log.Info("Sign in with different user.");

        //    //Click Invoicing menu option
        //    Thread.Sleep(5000);
        //    invoicingPage.ClickInvoicingMenu();
        //    log.Info("Click the Invoicing menu.");

        //    //Create Invoice
        //    String invoiceTitle = readInvoicing.GetValue("InvoiceDetails", "invoiceTitle");
        //    invoiceTitle = invoiceTitle + builder;
        //    CreateInvoice(invoiceTitle, projectName);

        //    //Click Save Draft button
        //    invoicingPage.ClickSafeDraft();
        //    log.Info("Click Save Draft button.");
        //    Thread.Sleep(5000);

        //    //Click Invoice Displayed
        //    invoicingPage.ClickInvoiceDisplayed(invoiceTitle);
        //    log.Info("Click Invoice displayed.");
        //    Thread.Sleep(5000);

        //    //Edit Invoice Title
        //    invoicingPage.EnterInvoiceTitle("Edited Invoice");
        //    log.Info("Edit the Invoice Title.");
        //    Thread.Sleep(1000);

        //    //Click Save Draft button
        //    invoicingPage.ClickSafeDraft();
        //    log.Info("Click Save Draft button.");
        //    Thread.Sleep(5000);

        //    //Signout of the application
        //    authenticationPage.SignOut();
        //    log.Info("Click on the Signout button.");

        //    //Login to the application
        //    Thread.Sleep(5000);
        //    authenticationPage.SetUserName(_workEmail);
        //    authenticationPage.SetPassword(_password);
        //    authenticationPage.ClickOnLoginButton();

        //    //Click the Marketplace tab
        //    Thread.Sleep(5000);
        //    marketplacePage.ClickMarketplaceTab();
        //    log.Info("Click the Marketplace tab.");
        //    Thread.Sleep(5000);

        //    //Enter the Project Name
        //    Thread.Sleep(5000);
        //    postProjectPage.SearchProjectName(projectName);
        //    log.Info("Enter the project name.");
        //    Thread.Sleep(1000);

        //    //Click Search button
        //    postProjectPage.ClickSearchBtn();
        //    log.Info("Click the Search button.");
        //    Thread.Sleep(15000);

        //    //Click the created project
        //    postProjectPage.ClickProjectNameOnPage(projectName);
        //    log.Info("Click the Project Name on the Projects Page.");
        //    Thread.Sleep(10000);

        //    //Delete Project
        //    DeleteProject();
        //}

        [Test]
        public void Invoicing_007_DeleteDraftInvoice()
        {
            Global.MethodName = "Invoicing_007_DeleteDraftInvoice";

            //Post a new project
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(6));
            String projectName = readPostProject.GetValue("AddProjectDetails", "projectName");
            projectName = projectName + builder;
            PostNewProject(projectName);

            //Signout of the application
            Thread.Sleep(5000);
            authenticationPage.SignOut();
            log.Info("Click on the Signout button.");

            //Sign in with a different user
            Thread.Sleep(2000);
            SignInDifferentUser();
            log.Info("Sign in with different user.");

            //Click Invoicing menu option
            Thread.Sleep(5000);
            invoicingPage.ClickInvoicingMenu();
            log.Info("Click the Invoicing menu.");

            //Create Invoice
            String invoiceTitle = readInvoicing.GetValue("InvoiceDetails", "invoiceTitle");
            invoiceTitle = invoiceTitle + builder;
            CreateInvoice(invoiceTitle, projectName);

            //Click Save Draft button
            invoicingPage.ClickSafeDraft();
            log.Info("Click Save Draft button.");
            Thread.Sleep(5000);

            //Click Invoice Displayed
            invoicingPage.ClickInvoiceDisplayed(invoiceTitle);
            log.Info("Click Invoice displayed.");
            Thread.Sleep(5000);

            //Delete the Invoice
            invoicingPage.ClickDeleteIcon();
            log.Info("Delete the Invoice.");
            Thread.Sleep(3000);

            //Click the Delete Window Yes button
            invoicingPage.ClickDeleteWindowYesBtn();
            log.Info("Delete the Delete Window Yes button.");
            Thread.Sleep(5000);

            //Signout of the application
            authenticationPage.SignOut();
            log.Info("Click on the Signout button.");

            //Login to the application
            Thread.Sleep(5000);
            authenticationPage.SetUserName(_workEmail);
            authenticationPage.SetPassword(_password);
            authenticationPage.ClickOnLoginButton();

            //Click the Marketplace tab
            Thread.Sleep(5000);
            marketplacePage.ClickMarketplaceTab();
            log.Info("Click the Marketplace tab.");
            Thread.Sleep(5000);

            //Enter the Project Name
            Thread.Sleep(5000);
            postProjectPage.SearchProjectName(projectName);
            log.Info("Enter the project name.");
            Thread.Sleep(1000);

            //Click Search button
            postProjectPage.ClickSearchBtn();
            log.Info("Click the Search button.");
            Thread.Sleep(15000);

            //Click the created project
            postProjectPage.ClickProjectNameOnPage(projectName);
            log.Info("Click the Project Name on the Projects Page.");
            Thread.Sleep(10000);

            //Delete Project
            DeleteProject();
        }



    }
}
