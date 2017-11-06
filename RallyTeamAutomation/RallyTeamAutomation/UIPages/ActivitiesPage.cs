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
    public class ActivitiesPage : BasePage
    {
        CommonMethods commonPage;

        public ActivitiesPage(IWebDriver driver, int pageLoadTimeout)
            : base(driver, pageLoadTimeout)
        {
            commonPage = new CommonMethods(_driver, pageLoadTimeout);
        }

        public ActivitiesPage NavigateTo(String _URL)
        {
            _driver.Navigate().GoToUrl(_URL);
            return this;
        }

        //Press Tab Key
        public void PressArrowDownKey()
        {
            _driver.PressKeyBoardDownArrow();
        }

        //Click on Activities menu option
        public void clickActivitiesMenu()
        {
            _driver.WaitForElementAvailableAtDOM(DashboardUI.sideNavBar("Activities"), 1);
            _driver.SafeClick(DashboardUI.sideNavBar("Activities"));
        }

        //Assert Activities Feed Page
        public void VerifyActivityFeedPage()
        {
            _assertHelper.AssertElementDisplayed(ActivitiesUI.activityFeedPage);
        }

        //Assert the Group/Event/Project Name
        public void VerifyNameActivity(String name)
        {
            _assertHelper.AssertElementDisplayed(ActivitiesUI.nameActivity(name));
        }

        //Assert the Group/Event/Project Name not displayed
        public void VerifyNameActivityNotDisplayed(String name)
        {
            _assertHelper.AssertElementNotDisplayed(ActivitiesUI.nameActivity(name));
        }

        //Assert the user name for Activity
        public void VerifyUserNameActivity(String userName)
        {
            _assertHelper.AssertElementDisplayed(ActivitiesUI.userNameActivity(userName));
        }

        //Assert Create New Event Activity
        public void VerifyCreateEventActivity()
        {
            _assertHelper.AssertElementDisplayed(ActivitiesUI.createNewEventActivity);
        }

        //Assert Create New Group Activity
        public void VerifyCreateGroupActivity()
        {
            _assertHelper.AssertElementDisplayed(ActivitiesUI.createNewGroupActivity);
        }

        //Assert Create New Project Activity
        public void VerifyCreateProjectActivity()
        {
            _assertHelper.AssertElementDisplayed(ActivitiesUI.createNewProjectActivity);
        }

        //Assert Join New Event Activity
        public void VerifyJoinEventActivity()
        {
            _assertHelper.AssertElementDisplayed(ActivitiesUI.joinEventActivity);
        }

        //Assert Join New Group Activity
        public void VerifyJoinGroupActivity()
        {
            _assertHelper.AssertElementDisplayed(ActivitiesUI.joinGroupActivity);
        }

        //Assert Join New Project Activity
        public void VerifyJoinProjectActivity()
        {
            _assertHelper.AssertElementDisplayed(ActivitiesUI.joinProjectActivity);
        }

        //Assert Complete Project Activity
        public void VerifyCompleteProjectActivity()
        {
            _assertHelper.AssertElementDisplayed(ActivitiesUI.completeProjectActivity);
        }

        //Click the Activity Edit Icon
        public void ClickEditActivityIcon()
        {
            _driver.SafeClick(ActivitiesUI.editIcon);
        }

        //Assert the Activity Edit Icon Not Displayed
        public void VerifyEditActivityIconNotDisplayed()
        {
            _assertHelper.AssertElementNotDisplayed(ActivitiesUI.editIcon);
        }

        //Assert Edit Message Option
        public void VerifyEditMessageOption()
        {
            _assertHelper.AssertElementDisplayed(ActivitiesUI.editMessageOption);
        }

        //Assert Delete Message Option
        public void VerifyDeleteMessageOption()
        {
            _assertHelper.AssertElementDisplayed(ActivitiesUI.deleteMessageOption);
        }

        //Click Edit Message Option
        public void ClickEditMessageOption()
        {
            _driver.SafeClick(ActivitiesUI.editMessageOption);
        }

        //Click Delete Message Option
        public void ClickDeleteMessageOption()
        {
            _driver.SafeClick(ActivitiesUI.deleteMessageOption);
        }

        //Assert Edit Div Text Area
        public void VerifyEditDivTextArea()
        {
            _assertHelper.AssertElementDisplayed(ActivitiesUI.editDiv);
        }        

        //Assert Edit Div Attachment Icon
        public void VerifyEditDivAttachmentIcon()
        {
            _assertHelper.AssertElementDisplayed(ActivitiesUI.editDivAttachmentIcon);
        }

        //Assert Edit Div Cancel Button
        public void VerifyEditDivCancelBtn()
        {
            _assertHelper.AssertElementDisplayed(ActivitiesUI.editDivCancelBtn);
        }

        //Assert Edit Div Post Button
        public void VerifyEditDivPostButton()
        {
            _assertHelper.AssertElementDisplayed(ActivitiesUI.editDivPostBtn);
        }

        //Click Edit Div Text Area
        public void ClickEditDivTextArea()
        {
            _driver.SafeClick(ActivitiesUI.editDiv);
        }

        //Enter Edit Div Text Area
        public void EnterEditDivTextArea(String message)
        {
            _driver.SafeEnterText(ActivitiesUI.editDivText, message);
        }

        //Click Edit Div Post Button
        public void ClickEditDivPostButton()
        {
            _driver.SafeClick(ActivitiesUI.editDivPostBtn);
        }        

    }
}
