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
    public class GroupsPage : BasePage
    {
        CommonMethods commonPage;

        public GroupsPage(IWebDriver driver, int pageLoadTimeout)
            : base(driver, pageLoadTimeout)
        {
            commonPage = new CommonMethods(_driver, pageLoadTimeout);
        }

        //Click Groups Tab
        public void ClickGroupsTab()
        {
            _driver.SafeClick(GroupsUI.groupsTab);
        }

        //Click Add Groups button
        public void ClickAddGroupBtn()
        {
            _driver.SafeClick(GroupsUI.addGroupBtn);
        }

        //Enter Group Name
        public void EnterGroupName(String groupName)
        {
            _driver.SafeEnterText(GroupsUI.addGroupName, groupName);
        }

        //Select Group Type
        public void SelectGroupType(String groupType)
        {
            _driver.SelectDropDownOption(groupType, GroupsUI.addGroupType);
        }

        //Click on Create button
        public void ClickCreateBtn()
        {
            _driver.SafeClick(GroupsUI.createBtn);
        }

        //Click on Cancel button
        public void ClickCancelBtn()
        {
            _driver.SafeClick(GroupsUI.cancelBtn);
        }

        //Click Add Member Icon
        public void ClickAddMemberIcon()
        {
            _driver.SafeClick(GroupsUI.addGroupUserIcon);
        }

        //Enter Group Member Name
        public void EnterGroupMemberEmail(String memberEmail)
        {
            _driver.SafeEnterText(GroupsUI.addGroupUserEmail, memberEmail);
        }

        //Click Done button
        public void ClickDoneBtn()
        {
            _driver.SafeClick(GroupsUI.addGroupUserDoneBtn);
        }

        //Press the Added Group Member remove icon
        public void ClickAddedMemberRemoveIcon()
        {
            _driver.WaitForElementAvailableAtDOM(GroupsUI.removeMemberIcon, 1);
            _driver.ClickElementUsingJS(GroupsUI.removeMemberIcon);
        }

        public void VerifyUserAddedToGroup(string memberName)
        {
            _assertHelper.AssertElementTextContains(GroupsUI.userAddedToGroup, memberName);
        }

      

    }
}
