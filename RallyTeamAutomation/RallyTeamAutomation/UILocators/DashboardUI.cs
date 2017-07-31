using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;


namespace RallyTeam.UILocators
{
    public static class DashboardUI
    {
        public readonly static By rallyNowHdr = By.XPath("//div[text()='RallyNow']");
        public static By sideNavBar(String variable)
        {
            return By.XPath("//ul[@class='nav']//span[text()= '" + variable+"']");
        }

        public readonly static By sideNavBarTest = By.XPath("//ul[@class='nav']/li[5]/a/span");

        public readonly static By configureLink = By.XPath("(//a[text()= 'Configure'])[1]");
        public readonly static By btnSave = By.XPath("//div[@class='m-t-md m-b-sm clearfix text-center']//a[@class='btn rt-btn--primary rt-btn--md']");
        
        public readonly static By myGrpTest = By.XPath("//h3[text()= 'My Groups']");
        public readonly static By adminSwitch = By.XPath("//div[@class='col-md-1 settings-info']//label");

        public readonly static By allAdminDiv = By.XPath("//div[@class='settings-item row ng-scope']");

        public readonly static By payerNametxt = By.XPath("//input[@placeholder='Enter a user to be designated payor']");
        public readonly static By payerNameCrossIcon = By.XPath("//a[contains(text(),'×')]");


        //div[@class='settings-item row ng-scope'][6]//div[contains(text(),'Projects: Approval Required')]

        public static By projectApprovalDiv(int variable)
        {
            return By.XPath("//div[@class='settings-item row ng-scope'][" + variable + "]//div[contains(text(),'Projects: Approval Required')]");
        }

        public static By invoiceAndPaymentDiv(int variable)
        {
            return By.XPath("//div[@class='settings-item row ng-scope']["+ variable + "]//div[text()='Invoicing and Payments']");
        }

        public static By invoiceAndPaymentSwitch(int variable)
        {
            return By.XPath("//div[@class='settings-item row ng-scope']["+ variable + "]//label");
        }
        public static By projectApprovalSwitch(int variable)
        {
            return By.XPath("//div[@class='settings-item row ng-scope'][" + variable + "]//label");
        }


        public readonly static By userIcon = By.XPath("//li[contains(@class, 'rt-top-navbar__profile')]//span[contains(@class, 'rt-avatar-container')]//*[contains(@class, 'rt-avatar')]");
        public readonly static By userIconToolTip = By.XPath("//ul[contains(@class, 'rt-top-navbar__icons')]//span[contains(@class, 'rt-avatar-container')]");
        public static By userProfileTooltip(String variable)
        {
            return By.XPath("//ul[contains(@class, 'rt-top-navbar__icons')]//span[contains(@class, 'rt-avatar-container')]//*[@tooltip='" + variable + "']");
        }
        public static By UserIconOptions(String variable)
        {
            return By.XPath("//ul[contains(@class, 'dropdown-menu')]//a[contains(text(), '" + variable + "')]");
        }
        public readonly static By plusIcon = By.XPath("//ul[contains(@class, 'rt-top-navbar__icons')]//i[contains(@class, 'fa fa-plus-square')]");
        public readonly static By signOut = By.XPath("//ul[contains(@class, 'dropdown-menu')]//a[contains(text(), 'Sign out')]");
        public static By plusIconOptions(String variable)
        {
            return By.XPath("//ul[contains(@class, 'dropdown-menu')]//a[contains(text(), '"+variable+"')]");
        }
        public readonly static By searchText = By.Name("searchTerm");
        //public readonly static By messageIcon = By.XPath("//i[contains(@class, 'fa fa-envelope-o')]");
        //public readonly static By messageIcon = By.XPath("//li[@class='rt-top-navbar__messages rt-top-navbar__icon ng-scope']//a//i[contains(@class, 'fa fa-envelope-o')]");
        public readonly static By messageIcon = By.XPath("//li[@class='rt-top-navbar__messages rt-top-navbar__icon ng-scope']//a");
        public readonly static By messageCounter = By.XPath("//span[contains(@class, 'rt-top-navbar__messages-count')]");
        public static By increasedMessageCounter(string variable)
        {

            return By.XPath("//span[contains(@class, 'rt-top-navbar__messages-count')] and text()="+ variable+"]");

        }
    }
}
