using OpenQA.Selenium;
using RallyTeam.Util;
using RallyTeam.UILocators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Interactions;
using System.Threading;

namespace RallyTeam.UIPages
{
    public class InvoicingPage : BasePage
    {
        CommonMethods commonPage;

        public InvoicingPage(IWebDriver driver, int pageLoadTimeout)
            : base(driver, pageLoadTimeout)
        {
            commonPage = new CommonMethods(_driver, pageLoadTimeout);
        }

        //Click Awesome rating
        public void ClickAwesomeRating()
        {
            _driver.SafeClick(InvoicingUI.awesome);
        }

        //Click on Invoicing option
        public void ClickInvoicingMenu()
        {
            _driver.ClickElementUsingAction(DashboardUI.userIcon);
            Thread.Sleep(2000);
            _driver.SafeClick(InvoicingUI.invoicingMenu);
        }

        //Click New Invoice button
        public void ClickNewInvoiceBtn()
        {
            _driver.SafeClick(InvoicingUI.newInvoiceBtn);
        }

        //Enter Invoice Title
        public void EnterInvoiceTitle(String invoiceTitle)
        {
            _driver.SafeEnterText(InvoicingUI.invoiceTitle, invoiceTitle);
        }
        
        //Click Due Date Calender Icon
        public void ClickDueDateField()
        {
            _driver.ClickElementUsingAction(InvoicingUI.dueDate);
        }

        //Click Due Date Calender Icon
        public void ClickTodaysDate()
        {
            _driver.ClickElementUsingAction(InvoicingUI.todayDate);
        }

        //Enter Invoice Amount
        public void EnterInvoiceTotal(String invoiceTotal)
        {
            _driver.SafeEnterText(InvoicingUI.invoiceTotal, invoiceTotal);
        }

        //Select The Project
        public void SelectProject(String projectName)
        {
            _driver.SelectDropDownOption(projectName, InvoicingUI.projectName);
        }

        //Enter Invoice Notes
        public void EnterNotes(String notes)
        {
            _driver.SafeEnterText(InvoicingUI.notes, notes);
        }

        //Click Save Darft button
        public void ClickSafeDraft()
        {
            _driver.SafeClick(InvoicingUI.saveDraftBtn);
        }

        //Click Submit button
        public void ClickSubmitBtn()
        {
            _driver.SafeClick(InvoicingUI.submitBtn);
        }

        //Verify Invoice Displayed
        public void VerifyInvoiceDisplayed(String invoiceTitle)
        {
            _assertHelper.AssertElementDisplayed(InvoicingUI.invoiceDisplayed(invoiceTitle));
        }

        //Verify Invoice Status
        public void VerifyInvoiceStatus(String status)
        {
            _assertHelper.AssertElementDisplayed(InvoicingUI.invoiceStatus(status));
        }

        //Click the Comments Div
        public void ClickCommentsDiv()
        {
            _driver.SafeClick(InvoicingUI.comments);
        }

        //Enter the Comments
        public void EnterComments(String comments)
        {
            _driver.SafeEnterText(InvoicingUI.comments, comments);
        }

        //Click Invoice Displayed
        public void ClickInvoiceDisplayed(String invoiceTitle)
        {
            _driver.SafeClick(InvoicingUI.invoiceDisplayed(invoiceTitle));
        }

        //Click the Approve button
        public void ClickApproveBtn()
        {
            _driver.SafeClick(InvoicingUI.approveBtn);
        }

        //Click the Comments Div
        public void ClickDenyBtn()
        {
            _driver.SafeClick(InvoicingUI.denyBtn);
        }

        //Click the Mark As Paid button
        public void ClickMarkAsPaidBtn()
        {
            _driver.SafeClick(InvoicingUI.markAsPaidBtn);
        }

        //Click the Delete Icon
        public void ClickDeleteIcon()
        {
            _driver.SafeClick(InvoicingUI.deleteIcon);
        }

        //Click the Delete Window Yes Button
        public void ClickDeleteWindowYesBtn()
        {
            _driver.SafeClick(InvoicingUI.deleteWindowYesBtn);
        }

        //Click the Project on Projects Page
        public void ClickProjectNameOnPage(String projectName)
        {
            _driver.ClickElementUsingJS(ProjectsUI.ProjectNameOnPage(projectName));
        }

    }
}
