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
using System.Collections.ObjectModel;

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

        //Click Feature Tab
        public void ClickFeaturesTab()
        {
            _driver.SafeClick(GroupsUI.FeaturesTab);
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
        //Select Group color
        public void SelectRoleColor(String roleColor)
        {
            _driver.SafeClick(GroupsUI.colorCodeSelect);
            Thread.Sleep(1000);
            _driver.SafeClick(GroupsUI.selectColor(roleColor));
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



        public void VerifyGroupDeleteIcon()
        {
            ReadOnlyCollection<IWebElement> lstGroup = _driver.SafeFindElements(GroupsUI.groupsDeleteIcon);
            if (lstGroup != null)
            {
                int count = lstGroup.Count;
                _assertHelper.AssertElementDisplayed(GroupsUI.getGroupsDeleteIcon(Convert.ToString(count)));
            }
        }

        public void VerifyGroupEditIcon()
        {
            ReadOnlyCollection<IWebElement> lstGroup = _driver.SafeFindElements(GroupsUI.groupsDeleteIcon);
            if (lstGroup != null)
            {
                int count = lstGroup.Count;
                _assertHelper.AssertElementDisplayed(GroupsUI.getGroupsEditIcon(Convert.ToString(count)));
            }
        }
        public void ClickGroupSaveButton()
        {
            _driver.SafeClick(GroupsUI.groupsSaveButton);
        }

        public void ClickEmployeeCheckbox()
        {
            _driver.SafeClick(GroupsUI.checkboxEmployee);
        }

        public void ClickGroupEditIcon()
        {
            ReadOnlyCollection<IWebElement> lstGroup = _driver.SafeFindElements(GroupsUI.groupsDeleteIcon);
            if (lstGroup != null)
            {
                int count = lstGroup.Count;
                _driver.SafeClick(GroupsUI.getGroupsEditIcon(Convert.ToString(count)));
            }
        }

        public void ClickSystemGroupEditIcon()
        {
            //ReadOnlyCollection<IWebElement> lstGroup = _driver.SafeFindElements(GroupsUI.groupsDeleteIcon);
           // if (lstGroup != null)
            {
                int count = 3;
                _driver.SafeClick(GroupsUI.getGroupsEditIcon(Convert.ToString(count)));
            }
        }
        public void CheckedDirectMessageCheckbox()
        {
            bool chkDirectMsgChecked = _driver.IsElementVisible(GroupsUI.chkDirectMessageChecked);
            bool chkDirectMsgUnChecked = _driver.IsElementVisible(GroupsUI.chkDirectMessageUnchecked);
            if (chkDirectMsgUnChecked)
            {
                _driver.SafeClick(GroupsUI.chkDirectMessageUnchecked);
            }
        }
        public void UnCheckedDirectMessageCheckbox()
        {
            bool flagDirectMsgChecked = _driver.IsElementVisible(GroupsUI.chkDirectMessageChecked);
          //  bool flagDirectMsgUnChecked = _driver.IsElementVisible(GroupsUI.chkDirectMessageUnchecked);


            if (flagDirectMsgChecked)
            {
                _driver.SafeClick(GroupsUI.chkDirectMessageChecked);
            }
        }


        public void VerifySystemGroupDeleteIcon(int count=3)
        {
            ReadOnlyCollection<IWebElement> lstGroup = _driver.SafeFindElements(GroupsUI.groupsDeleteIcon);
            if (lstGroup != null)
            {                
                _assertHelper.AssertElementNotDisplayed(GroupsUI.getGroupsDeleteIcon(Convert.ToString(count)));
            }
        }

        public void DeleteExistingGroup()
        {
            ReadOnlyCollection<IWebElement> lstGroup = _driver.SafeFindElements(GroupsUI.groupsDeleteIcon);
            if (lstGroup != null)
            {
                int count = lstGroup.Count;              
                _driver.SafeClick(GroupsUI.getGroupsDeleteIcon(Convert.ToString(count)));
            }
        }
    }
}
