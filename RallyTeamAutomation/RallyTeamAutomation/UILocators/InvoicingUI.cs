using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RallyTeam.UILocators
{
    public static class InvoicingUI
    {
        public readonly static By invoicingMenu = By.XPath("//ul[contains(@class, 'dropdown-menu')]//a[text()= 'Invoicing']");
        public readonly static By newInvoiceBtn = By.XPath("//span[contains(text(), 'New Invoice')]");
        public readonly static By allInvoicesDropDown = By.XPath("//h2[contains(text(), 'All Invoices')]");
        public readonly static By allInvoicesOption = By.XPath("//ul[@class= 'dropdown-menu']//li[contains(text(), 'All Invoices')]");
        public readonly static By draftOption = By.XPath("//ul[@class= 'dropdown-menu']//li[contains(text(), 'Draft')]");
        public readonly static By pendingApprovalOption = By.XPath("//ul[@class= 'dropdown-menu']//li[contains(text(), 'Pending Approval')]");
        public readonly static By approvedOption = By.XPath("//ul[@class= 'dropdown-menu']//li[contains(text(), 'Approved')]");
        public readonly static By deniedOption = By.XPath("//ul[@class= 'dropdown-menu']//li[contains(text(), 'Denied')]");
        public readonly static By paidOption = By.XPath("//ul[@class= 'dropdown-menu']//li[contains(text(), 'Paid')]");
        public readonly static By awesome = By.XPath("//div[contains(@class, 'awesome')]");
        public static By invoiceDisplayed(String variable)
        {
            return By.XPath("//div[contains(@class, 'invoicing__table-item')]//div[contains(text(), '" + variable + "')]");
        }
        public static By invoiceStatus(String variable)
        {
            return By.XPath("//div[@class= 'ng-scope']//div[2]//div[contains(text(), '" + variable + "')]");
        }


        //New Invoice Fields
        public readonly static By invoiceTitle = By.XPath("//input[@name= 'title']");
        public readonly static By dueDate = By.XPath("//input[@name= 'dueBy']");
        public readonly static By dueDateCalendar = By.XPath("//i[@class= 'fa fa-calendar']");
        public readonly static By todayDate = By.XPath("//table[contains(@class, 'table-condensed')]//td[@class= 'today day']");
        public readonly static By invoiceTotal = By.XPath("//input[@name= 'cost']");
        public readonly static By projectName = By.XPath("//select[@name= 'selectedProject']");
        public readonly static By approver = By.XPath("//div[contains(@class= 'no-gutter')]//div[1]");
        public readonly static By invoiceFrom = By.XPath("//div[@class= 'row clearfix no-gutter']//div[2]");
        public readonly static By notes = By.XPath("//textarea[@placeholder= 'Enter notes for this invoice']");
        public readonly static By attachmentIcon = By.XPath("//i[@class= 'fa fa-plus']");
        public readonly static By saveDraftBtn = By.XPath("//a[text()= 'Save Draft']");
        public readonly static By submitBtn = By.XPath("//a[text()= 'Submit']");
        public readonly static By deleteIcon = By.XPath("//i[@class= 'fa fa-trash']");
        public readonly static By deleteWindowYesBtn = By.XPath("//div[@class= 'modal-content']//a[text()= 'Yes']");

        //Invoice details for Approver
        public readonly static By denyBtn = By.XPath("//a[text()= 'Deny']");
        public readonly static By approveBtn = By.XPath("//a[text()= 'Approve']");
        public readonly static By comments = By.XPath("//span[contains(@class, 'fr-placeholder')And (text()='Add a comment...')]");
        //public readonly static By comments = By.XPath("//form[contains(@class, 'chat-form')]//span[contains(@class, 'fr-placeholder')]");


        public readonly static By markAsPaidBtn = By.XPath("//a[text()= 'Mark As Paid']");


    }
}
