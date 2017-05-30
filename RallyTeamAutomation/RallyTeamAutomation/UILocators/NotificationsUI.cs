using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RallyTeam.UILocators
{
    public static class NotificationsUI
    {
        public readonly static By notificationsIcon = By.XPath("//i[contains(@class, 'fa-bell-o')]");
        public readonly static By notificationsSeeAll = By.XPath("//div[contains(@class,'text-center rt-notification')]/a[contains(text(),'See All')]");

        //Project Assigned
        public readonly static By notificationsWindowProjectAssigned = By.XPath("//div[contains(@class, 'rt-notification__width')]//strong[contains(text(), 'been assigned')]");
        public readonly static By projectAssigned = By.XPath("//a[contains(text(), 'been assigned a Project')]");
        public static By projectAssignedSubject(string variable1, string variable2)
        {
            return By.XPath("//div[contains(@class, 'mail-box')]//a[contains(text(), '" + variable1+" assigned "+variable2+" to you.')]");
        }

        //Project Join Request
        public readonly static By notificationsWindowProjectJoinRequest = By.XPath("//div[contains(@class, 'rt-notification__width')]//strong[contains(text(), 'You have a new reque')]");
        public readonly static By projectJoinRequest = By.XPath("//a[contains(text(), 'You have a new request')]");
        public static By projectJoinRequestSubject(string variable1, string variable2)
        {
            return By.XPath("//div[contains(@class, 'mail-box')]//a[contains(text(), '" + variable1+" requests to join your project "+variable2+"')]");
        }

        //User Recruited to a Project
        public readonly static By notificationsWindowUserReqcruitedToProject = By.XPath("//div[contains(@class, 'rt-notification__width')]//strong[contains(text(), 'You have a new invit')]");
        public readonly static By userReqcruitedToProject = By.XPath("//a[contains(text(), 'You have a new invite')]");
        public static By UserReqcruitedToProjectSubject(string variable1, string variable2)
        {
            return By.XPath("//div[contains(@class, 'mail-box')]//a[contains(text(), '" + variable1+ " invites you to check out the project " + variable2+"')]");
        }

        //User is added to a Project
        public readonly static By notificationsWindowUserAddedToProject = By.XPath("//div[contains(@class, 'rt-notification__width')]//strong[contains(text(), 'Congrats! You have j')]");
        public readonly static By userAddedToProject = By.XPath("//a[contains(text(), 'Congrats! You have just joined a new project!')]");
        public static By userAddedToProjectSubject(string variable1, string variable2)
        {
            return By.XPath("//div[contains(@class, 'mail-box')]//a[contains(text(), '" + variable1 + " added you to " + variable2 + "')]");
        }

        //User removed from a Project
        public readonly static By notificationsWindowUserRemovedFromProject = By.XPath("//div[contains(@class, 'rt-notification__width')]//strong[contains(text(), 'been removed')]");
        public readonly static By userRemovedFromProject = By.XPath("//a[contains(text(), 'You have been removed from a project')]");
        public static By userRemovedFromProjectSubject(string variable1, string variable2)
        {
            return By.XPath("//div[contains(@class, 'mail-box')]//a[contains(text(), '" + variable1 + " has removed you from " + variable2 + "')]");
        }

        //User was mentioned in a Project with @all
        //public readonly static By notificationsWindowUserMentionedInProjectWithAll = By.XPath("//div[contains(@class, 'rt-notification__width')]//strong[contains(text(), 'You were mentioned i')]");

        public readonly static By notificationsWindowUserMentionedInProjectWithAll = By.XPath("//div[contains(@class, 'rt-notification__width')]//strong[contains(text(), 'Congrats! You have just joined')]");

        public readonly static By userMentionedInProjectWithAll = By.XPath("//a[contains(text(), 'You were mentioned in Project')]");

        public static By userMentionedInProjectWithAl(string projectName)
        {
            return By.XPath("//div[contains(@class, 'mail-box ng-scope')]//a[contains(text(), '" + projectName + "')]");
        }
        public static By userMentionedInProjectWithAllSubject(string variable1, string variable2)
        {
            return By.XPath("//div[contains(@class, 'mail-box')]//a[contains(text(), '"+variable2+"')]");
        }

        //Invoice Requires Approval
        public readonly static By notificationsWindowInvoiceRequiresApproval = By.XPath("//div[contains(@class, 'rt-notification__width')]//strong[contains(text(), 'An invoice requires')]");
        public readonly static By invoiceRequiresApproval = By.XPath("//a[contains(text(), 'An invoice requires payment')]");
        public static By invoiceRequiresApprovalSubject(string variable1)
        {
            return By.XPath("//div[contains(@class, 'mail-box')]//a[contains(text(), '" + variable1 + " submitted an invoice that requires your approval')]");
        }

        //Your Invoice was Approved
        public readonly static By notificationsWindowInvoiceApproved = By.XPath("//div[contains(@class, 'rt-notification__width')]//strong[contains(text(), 'Your invoice was app')]");
        public readonly static By invoiceApproved = By.XPath("//a[contains(text(), 'Your invoice was approved')]");
        public static By invoiceApprovedSubject(string variable1, string variable2)
        {
            return By.XPath("//div[contains(@class, 'mail-box')]//a[contains(text(), '" + variable1 + " has approved your invoice "+variable2+"')]");
        }

        //Your Invoice was Denied
        public readonly static By notificationsWindowInvoiceDenied = By.XPath("//div[contains(@class, 'rt-notification__width')]//strong[contains(text(), 'Your invoice was not')]");
        public readonly static By invoiceDenied = By.XPath("//a[contains(text(), 'Your invoice was not approved')]");
        public static By invoiceDeniedSubject(string variable1, string variable2)
        {
            return By.XPath("//div[contains(@class, 'mail-box')]//a[contains(text(), '" + variable1 + " has denied your invoice " + variable2 + "')]");
        }

        //An Invoice Requires Payment
        public readonly static By notificationsWindowInvoiceRequiresPayment = By.XPath("//div[contains(@class, 'rt-notification__width')]//strong[contains(text(), 'An invoice requires')]");
        public readonly static By invoiceRequiresPayment = By.XPath("//a[contains(text(), 'An invoice requires payment')]");
        public static By invoiceRequiresPaymentSubject(string variable1)
        {
            return By.XPath("//div[contains(@class, 'mail-box')]//a[contains(text(), '" + variable1 + " has approved an invoice for payment')]");
        }

        //User Receives Feedback
        public readonly static By notificationsWindowUserReceivesFeedback = By.XPath("//div[contains(@class, 'rt-notification__width')]//strong[contains(text(), 'You have received feedback')]");
        public readonly static By userReceivesFeedback = By.XPath("//a[contains(text(), 'You have received feedback')]");
        public static By userReceivesFeedbackSubject(string variable1, string variable2)
        {
            return By.XPath("//div[contains(@class, 'mail-box')]//a[contains(text(), '" + variable1 + " has given you feedback on "+variable2+"')]");
        }

        //User Requests Feedback
        public readonly static By notificationsWindowUserRequestsFeedback = By.XPath("//div[contains(@class, 'rt-notification__width')]//strong[contains(text(), 'Someone has requested feedback from you')]");
        public readonly static By userRequestsFeedback = By.XPath("//a[contains(text(), 'Someone has requested feedback from you')]");
        public static By userRequestsFeedbackSubject(string variable1, string variable2)
        {
            return By.XPath("//div[contains(@class, 'mail-box')]//a[contains(text(), '" + variable1+" has requested feedback from you on "+variable2+"')]");
        }
    }
        
    
}
