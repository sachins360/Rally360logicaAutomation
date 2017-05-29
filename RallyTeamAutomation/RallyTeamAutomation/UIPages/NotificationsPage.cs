using OpenQA.Selenium;
using RallyTeam.Util;
using RallyTeam.UILocators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Interactions;

namespace RallyTeam.UIPages
{
    public class NotificationsPage : BasePage
    {
        CommonMethods commonPage;

        public NotificationsPage(IWebDriver driver, int pageLoadTimeout)
            : base(driver, pageLoadTimeout)
        {
            commonPage = new CommonMethods(_driver, pageLoadTimeout);
        }        

        //Click on Notifications Icon
        public void ClickNotificationsIcon()
        {
            _driver.ClickElementUsingAction(NotificationsUI.notificationsIcon);
        }

        //Click See All link
        public void ClickSeeAll()
        {
            _driver.SafeClick(NotificationsUI.notificationsSeeAll);
        }

        //Verify short Project Assigned notification 
        public void VerifyProjectAssignedNotificationWindow()
        {
            _assertHelper.AssertElementDisplayed(NotificationsUI.notificationsWindowProjectAssigned);
        }

        //Verify Project Assigned Notification
        public void VerifyProjectAssigned()
        {
            _assertHelper.AssertElementDisplayed(NotificationsUI.projectAssigned);
        }

        //Verify Project Assigned Notification Subject
        public void VerifyProjectAssignedSubject(string projectAssignedBy, string projectName)
        {
            _assertHelper.AssertElementDisplayed(NotificationsUI.projectAssignedSubject(projectAssignedBy, projectName));
        }

        //Verify short Project Join Request notification 
        public void VerifyProjectJoinRequestNotificationWindow()
        {
            _assertHelper.AssertElementDisplayed(NotificationsUI.notificationsWindowProjectJoinRequest);
        }

        //Verify Project Join Request Notification
        public void VerifyProjectJoinRequest()
        {
            _assertHelper.AssertElementDisplayed(NotificationsUI.projectJoinRequest);
        }

        //Verify Project Join Request Notification Subject
        public void VerifyProjectJoinRequestSubject(string userName, string projectName)
        {
            _assertHelper.AssertElementDisplayed(NotificationsUI.projectJoinRequestSubject(userName, projectName));
        }

        //Verify short User Recruited to Project notification 
        public void VerifyUserRecruitedToProjectNotificationWindow()
        {
            _assertHelper.AssertElementDisplayed(NotificationsUI.notificationsWindowUserReqcruitedToProject);
        }

        //Verify User Recruited to Project otification
        public void VerifyUserRecruitedToProject()
        {
            _assertHelper.AssertElementDisplayed(NotificationsUI.userReqcruitedToProject);
        }

        //Verify User Recruited to Project Notification Subject
        public void VerifyUserRecruitedToProjectSubject(string userName, string projectName)
        {
            _assertHelper.AssertElementDisplayed(NotificationsUI.UserReqcruitedToProjectSubject(userName, projectName));
        }

        //Verify short User Added to Project notification 
        public void VerifyUserAddedToProjectNotificationWindow()
        {
            _assertHelper.AssertElementDisplayed(NotificationsUI.notificationsWindowUserAddedToProject);
        }

        //Verify User Added to Project Notification
        public void VerifyUserAddedToProject()
        {
            _assertHelper.AssertElementDisplayed(NotificationsUI.userAddedToProject);
        }

        //Verify User Added to Project Notification Subject
        public void VerifyUserAddedToProjectSubject(string userName, string projectName)
        {
            _assertHelper.AssertElementDisplayed(NotificationsUI.userAddedToProjectSubject(userName, projectName));
        }

        //Verify short User Removed from Project notification 
        public void VerifyUserRemovedFromProjectNotificationWindow()
        {
            _assertHelper.AssertElementDisplayed(NotificationsUI.notificationsWindowUserRemovedFromProject);
        }

        //Verify User Removed from Project Notification
        public void VerifyUserRemovedFromProject()
        {
            _assertHelper.AssertElementDisplayed(NotificationsUI.userRemovedFromProject);
        }

        //Verify User Removed from Project Notification Subject
        public void VerifyUserRemovedFromProjectSubject(string userName, string projectName)
        {
            _assertHelper.AssertElementDisplayed(NotificationsUI.userRemovedFromProjectSubject(userName, projectName));
        }

        //Verify short User Mentioned In Project WIth All notification 
        public void VerifyUserMentionedInProjectWIthAllNotificationWindow()
        {
            _assertHelper.AssertElementDisplayed(NotificationsUI.notificationsWindowUserMentionedInProjectWithAll);
        }

        //Verify User Mentioned In Project WIth All Notification
        public void VerifyUserMentionedInProjectWIthAll(string projectName=null)
        {
            _assertHelper.AssertElementDisplayed(NotificationsUI.userMentionedInProjectWithAl(projectName));
        }

        //Verify User Mentioned In Project WIth All Notification Subject
        public void VerifyUserMentionedInProjectWIthAllSubject(string userName, string text)
        {
            _assertHelper.AssertElementDisplayed(NotificationsUI.userMentionedInProjectWithAllSubject(userName, text));
        }

        //Verify short Invoice Requires Approval notification 
        public void VerifyInvoiceRequiresApprovalNotificationWindow()
        {
            _assertHelper.AssertElementDisplayed(NotificationsUI.notificationsWindowInvoiceRequiresApproval);
        }

        //Verify Invoice Requires Approval Notification
        public void VerifyInvoiceRequiresApproval()
        {
            _assertHelper.AssertElementDisplayed(NotificationsUI.invoiceRequiresApproval);
        }

        //Verify Invoice Requires Approval Notification Subject
        public void VerifyInvoiceRequiresApprovalSubject(string userName)
        {
            _assertHelper.AssertElementDisplayed(NotificationsUI.invoiceRequiresApprovalSubject(userName));
        }

        //Verify short Invoice Approved notification 
        public void VerifyInvoiceApprovedNotificationWindow()
        {
            _assertHelper.AssertElementDisplayed(NotificationsUI.notificationsWindowInvoiceApproved);
        }

        //Verify Invoice Approved Notification
        public void VerifyInvoiceApproved()
        {
            _assertHelper.AssertElementDisplayed(NotificationsUI.invoiceApproved);
        }

        //Verify Invoice Approved Notification Subject
        public void VerifyInvoiceApprovedSubject(string userName, string invoiceName)
        {
            _assertHelper.AssertElementDisplayed(NotificationsUI.invoiceApprovedSubject(userName, invoiceName));
        }

        //Verify short Invoice Denied notification 
        public void VerifyInvoiceDeniedNotificationWindow()
        {
            _assertHelper.AssertElementDisplayed(NotificationsUI.notificationsWindowInvoiceDenied);
        }

        //Verify Invoice Denied Notification
        public void VerifyInvoiceDenied()
        {
            _assertHelper.AssertElementDisplayed(NotificationsUI.invoiceDenied);
        }

        //Verify Invoice Denied Notification Subject
        public void VerifyInvoiceDeniedSubject(string userName, string invoiceName)
        {
            _assertHelper.AssertElementDisplayed(NotificationsUI.invoiceDeniedSubject(userName, invoiceName));
        }

        //Verify short Invoice Requires Payment notification 
        public void VerifyInvoiceRequiresPaymentNotificationWindow()
        {
            _assertHelper.AssertElementDisplayed(NotificationsUI.notificationsWindowInvoiceRequiresPayment);
        }

        //Verify Invoice Requires Payment Notification
        public void VerifyInvoiceRequiresPayment()
        {
            _assertHelper.AssertElementDisplayed(NotificationsUI.invoiceRequiresPayment);
        }

        //Verify Invoice Requires Payment Notification Subject
        public void VerifyInvoiceRequiresPaymentSubject(string userName)
        {
            _assertHelper.AssertElementDisplayed(NotificationsUI.invoiceRequiresPaymentSubject(userName));
        }

        //Verify short User Receives Feedback notification 
        public void VerifyUserReceivesFeedbackNotificationWindow()
        {
            _assertHelper.AssertElementDisplayed(NotificationsUI.notificationsWindowUserReceivesFeedback);
        }

        //Verify User Receives Feedback Notification
        public void VerifyUserReceivesFeedback()
        {
            _assertHelper.AssertElementDisplayed(NotificationsUI.userReceivesFeedback);
        }

        //Verify User Receives Feedback Notification Subject
        public void VerifyUserReceivesFeedbackSubject(string userName, string projectName)
        {
            _assertHelper.AssertElementDisplayed(NotificationsUI.userReceivesFeedbackSubject(userName, projectName));
        }

        //Verify short User Requests Feedback notification 
        public void VerifyUserRequestsFeedbackNotificationWindow()
        {
            _assertHelper.AssertElementDisplayed(NotificationsUI.notificationsWindowUserRequestsFeedback);
        }

        //Verify User Requests Feedback Notification
        public void VerifyUserRequestsFeedback()
        {
            _assertHelper.AssertElementDisplayed(NotificationsUI.userRequestsFeedback);
        }

        //Verify User Requests Feedback Notification Subject
        public void VerifyUserRequestsFeedbackSubject(string userName, string projectName)
        {
            _driver.WaitForElementAvailableAtDOM(NotificationsUI.userRequestsFeedbackSubject(userName, projectName), 1);
            _assertHelper.AssertElementDisplayed(NotificationsUI.userRequestsFeedbackSubject(userName, projectName));
        }


    }
}
