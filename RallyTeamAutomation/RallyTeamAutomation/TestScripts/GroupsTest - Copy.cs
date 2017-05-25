
using NUnit.Framework;
using RallyTeam.UILocators;
using RallyTeam.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
//using RallyTeam.UIPages;

namespace RallyTeam.TestScripts
{
    //[Test]
    public class GroupsTest : BaseTest
    {
        static ReadData readGroups = new ReadData("Groups");

        [Test]
        public void TC01_VerifyGroupsOption()
        {
            groupsPage.VerifyGroupMenuOption();
            log.Info("Verify group menu icon");
        }

        [Test]
        public void TC02_VerifyGroupLeaderDropDown()
        {
            //Click on the side navigation link 'Groups' 
            Thread.Sleep(5000);
            groupsPage.clickGroupsMenu();
            log.Info("Click on the side navigation link 'Groups'");

            //Click on Add New Group button
            Thread.Sleep(5000);
            groupsPage.clickOnAddNewGroupButton();
            log.Info("Click on the Add New Group button at Groups page");

            //Verify the add new group form window
            Thread.Sleep(5000);
            groupsPage.assertAddGroupDialog();
            log.Info("Verify the add new group form window");

            //Verify the Selected Group Leader 
            Thread.Sleep(5000);
            String expectedGroupLeader = readGroups.GetValue("GroupLeader", "expectedGroupLeader");
            groupsPage.GetGroupLeaderSelectedOption(expectedGroupLeader);

            //Change the Group Leader
            String changeDefaultGroupLeader = readGroups.GetValue("GroupLeader", "changeDefaultGroupLeader");
            groupsPage.selectOptionFromGroupLeader(changeDefaultGroupLeader);
        }


        [Test]
        public void TC03_TestCreatePublicGroup()
        {
            //Click on the side navigation link 'Groups' 
            Thread.Sleep(5000);
            groupsPage.clickGroupsMenu();
            log.Info("Click on the side navigation link 'Groups'");

            //Click on Add New Group button
            Thread.Sleep(5000);
            groupsPage.clickOnAddNewGroupButton();
            log.Info("Click on the Add New Group button at Groups page");

            //Verify the add new group form window
            Thread.Sleep(5000);
            groupsPage.assertAddGroupDialog();
            log.Info("Verify the add new group form window");

            //Enter the Group Name
            Thread.Sleep(2000);
            String groupName = readGroups.GetValue("AddPublicGroupDetails", "groupName");
            groupsPage.enterNewGroupName(groupName);

            //Enter the Group Snippet
            Thread.Sleep(2000);
            String groupSnippet = readGroups.GetValue("AddPublicGroupDetails", "groupSnippet");
            groupsPage.enterNewGroupSnippet(groupSnippet);

            //Enter the Group Description
            Thread.Sleep(2000);
            commonPage.ScrollDown();
            Thread.Sleep(2000);
            String groupDesc = readGroups.GetValue("AddPublicGroupDetails", "groupDesc");
            groupsPage.enterNewGroupDescription(groupDesc);

            //Select a Group Leader
            Thread.Sleep(2000);
            String groupLeader = readGroups.GetValue("AddPublicGroupDetails", "groupLeader");
            groupsPage.selectOptionFromGroupLeader(groupLeader);

            //Select Group Visibility
            Thread.Sleep(2000);
            String groupVisibility = readGroups.GetValue("AddPublicGroupDetails", "groupVisibility");
            groupsPage.selectVisibility(groupVisibility);

            //Click on the create button at Add New Group form
            Thread.Sleep(2000);
            groupsPage.clickOnCreateButton();
        }

        [Test]
        public void TC04_TestCreatePrivateGroup()
        {
            //Click on the side navigation link 'Groups' 
            Thread.Sleep(5000);
            groupsPage.clickGroupsMenu();
            log.Info("Click on the side navigation link 'Groups'");

            //Click on Add New Group button
            Thread.Sleep(5000);
            groupsPage.clickOnAddNewGroupButton();
            log.Info("Click on the Add New Group button at Groups page");

            //Verify the add new group form window
            Thread.Sleep(5000);
            groupsPage.assertAddGroupDialog();
            log.Info("Verify the add new group form window");

            //Enter the Group Name
            Thread.Sleep(2000);
            String groupName = readGroups.GetValue("AddPrivateGroupDetails", "groupName");
            groupsPage.enterNewGroupName(groupName);

            //Enter the Group Snippet
            Thread.Sleep(2000);
            String groupSnippet = readGroups.GetValue("AddPrivateGroupDetails", "groupSnippet");
            groupsPage.enterNewGroupSnippet(groupSnippet);

            //Enter the Group Description
            Thread.Sleep(2000);
            commonPage.ScrollDown();
            Thread.Sleep(2000);
            String groupDesc = readGroups.GetValue("AddPrivateGroupDetails", "groupDesc");
            groupsPage.enterNewGroupDescription(groupDesc);

            //Select a Group Leader
            Thread.Sleep(2000);
            String groupLeader = readGroups.GetValue("AddPrivateGroupDetails", "groupLeader");
            groupsPage.selectOptionFromGroupLeader(groupLeader);

            //Select Group Visibility
            Thread.Sleep(2000);
            String groupVisibility = readGroups.GetValue("AddPrivateGroupDetails", "groupVisibility");
            groupsPage.selectVisibility(groupVisibility);

            //Click on the create button at Add New Group form
            Thread.Sleep(2000);
            groupsPage.clickOnCreateButton();
        }

        [Test]
        public void TC05_SettingsOptionGrpLeader()
        {
            //Click Settings option
            Thread.Sleep(5000);
            groupsPage.ClickSettingsOption();
            log.Info("Click on the Settings option after Group is created.");

            //Verify Settings Options value 'Add Member'
            groupsPage.GetSettingsOptionsValues("Add Members");
            log.Info("Verified Settings option value: 'Add Members'");
            Thread.Sleep(2000);

            //Verify Settings Options value 'Manage Members'
            groupsPage.GetSettingsOptionsValues("Manage Members");
            log.Info("Verified Settings option value: 'Manage Member'");
            Thread.Sleep(2000);

            //Verify Settings Options value 'Edit Group'
            groupsPage.GetSettingsOptionsValues("Edit Group");
            log.Info("Verified Settings option value: 'Edit Group'");
            Thread.Sleep(2000);

            //Verify Settings Options value 'Delete Group'
            groupsPage.GetSettingsOptionsValues("Delete Group");
            log.Info("Verified Settings option value: 'Delete Group'");
            Thread.Sleep(2000);
        }

        [Test]
        public void TC06_ClickAddMemberAndVerify()
        {
            //Click Add Group Member Icon
            groupsPage.ClickOnAddMemberIcon();
            log.Info("Click on the Add Member Icon after Group is created.");
            Thread.Sleep(5000);

            //Verify Add Member Window
            groupsPage.AssertAddGroupMemberDialog();
            log.Info("Verify the Add Group Member Window.");
            Thread.Sleep(2000);

            //Verify the Add button
            groupsPage.AssertAddWindowAddButton();
            log.Info("Verify the Add Window Add button.");
            Thread.Sleep(2000);
        }

        [Test]
        public void TC07_AddMemberInGroup()
        {
            //Enter the Group Member Email
            String addMemberEmail = readGroups.GetValue("AddGroupMember", "addMemberEmail");
            groupsPage.EnterGroupMemberEmail(addMemberEmail);
            log.Info("Entered " + addMemberEmail + " into Add Member Text field ");
            Thread.Sleep(5000);

            //Select user from suggestion
            String addMemberName = readGroups.GetValue("AddGroupMember", "addMemberName");
            groupsPage.SelectUserfromSuggestion(addMemberName);
            log.Info("User selected successfully.");
            Thread.Sleep(5000);

            //Click the Add button
            groupsPage.ClickAddWindowAddButton();
            log.Info("Click on Add Window Add button.");
            Thread.Sleep(2000);

            //Verify the added member confirmation message
            String messageText = "(" + addMemberEmail + ") has been added.";
            groupsPage.VerifyAddedMemberConfMsg(messageText);
            log.Info("Verified group member added confirmation message.");
            Thread.Sleep(5000);
        }

        [Test]
        public void TC08_AddMultipleMembersInGroup()
        {
            //Click Add Group Member Icon
            groupsPage.ClickOnAddMemberIcon();
            log.Info("Click on the Add Member Icon after Group is created.");
            Thread.Sleep(5000);

            //Enter the Group Member Email and select users from suggestion
            String addMembersEmail = readGroups.GetValue("AddMultipleGroupMembers", "addMembersEmail");
            List<String> addMembersEmailList = addMembersEmail.Split(',').ToList();
            int noOfMember = addMembersEmailList.Count;
            foreach (String value in addMembersEmailList)
            {
                groupsPage.EnterGroupMemberEmail(value);
                Thread.Sleep(2000);
                groupsPage.PressEnterKey();
                Thread.Sleep(5000);
            }

            //Click the Add button
            groupsPage.ClickAddWindowAddButton();
            log.Info("Click on Add Window Add button.");
            Thread.Sleep(2000);

            //Verify the added member confirmation message
            String messageText = noOfMember + " Members have been added.";
            groupsPage.VerifyAddedMemberConfMsg(messageText);
            log.Info("Verified group member added confirmation message.");
            Thread.Sleep(2000);
        }

        [Test]
        public void TC09_ClickAddMemberAndClose()
        {
            //Click Add Group Member Icon
            groupsPage.ClickOnAddMemberIcon();
            log.Info("Click on the Add Member Icon after Group is created.");
            Thread.Sleep(5000);

            //Verify Add Member Window
            groupsPage.AssertAddGroupMemberDialog();
            log.Info("Verify the Add Group Member Window.");
            Thread.Sleep(2000);

            //Enter the Group Member Email
            String addMemberEmail = readGroups.GetValue("DoNotAddMember", "addMemberEmail");
            groupsPage.EnterGroupMemberEmail(addMemberEmail);
            log.Info("Entered " + addMemberEmail + " into Add Member Text field ");
            Thread.Sleep(5000);

            //Select user from suggestion
            String addMemberName = readGroups.GetValue("DoNotAddMember", "addMemberName");
            groupsPage.SelectUserfromSuggestion(addMemberName);
            log.Info("User selected successfully.");
            Thread.Sleep(2000);

            //Click Add Member Window Close Icon
            groupsPage.ClickAddWindMemberWindowCloseIcon();
            log.Info("Close icon clicked successfully.");
            Thread.Sleep(2000);
        }

        [Test]
        public void TC10_ClickManageMembersAndVerify()
        {
            //Click Settings option
            Thread.Sleep(2000);
            groupsPage.ClickSettingsOption();
            log.Info("Click on the Settings option after Group is created.");

            //Click Settings Options value 'Manage Members'
            groupsPage.ClickSettingsOptionsValues("Manage Members");
            log.Info("Verified Settings option value: 'Manage Members'");
            Thread.Sleep(2000);

            //Verify Manage Member Window
            groupsPage.AssertManageGroupMemberDialog();
            log.Info("Verify the Manage Group Member Window.");
            Thread.Sleep(2000);

            //Click Add Member Window Close Icon
            groupsPage.ClickAddWindMemberWindowCloseIcon();
            log.Info("Close icon clicked successfully.");
            Thread.Sleep(2000);
        }

        [Test]
        public void TC11_VerifyManageMembersRemoveCancel()
        {
            //Click Settings option
            Thread.Sleep(2000);
            groupsPage.ClickSettingsOption();
            log.Info("Click on the Settings option after Group is created.");

            //Click Settings Options value 'Manage Members'
            groupsPage.ClickSettingsOptionsValues("Manage Members");
            log.Info("Verified Settings option value: 'Manage Members'");
            Thread.Sleep(5000);

            //Click cross icon of second record
            groupsPage.ClickManageMemberSecondCrossIcon();
            log.Info("Click on Cross icon of the second member");
            Thread.Sleep(2000);

            //Verify Manage Member Window Remove Button
            groupsPage.AssertManageMemberRemoveBtn();
            log.Info("Verify the Manage Group Member Remove Button.");
            Thread.Sleep(2000);

            //Verify Manage Member Window Cancel Button
            groupsPage.AssertManageMemberCancelBtn();
            log.Info("Verify the Manage Group Member Cancel Button.");
            Thread.Sleep(2000);

            //Click Add Member Window Close Icon
            groupsPage.ClickAddWindMemberWindowCloseIcon();
            log.Info("Close icon clicked successfully.");
            Thread.Sleep(2000);
        }

        [Test]
        public void TC12_ClickManageMembersCancelBtn()
        {
            //Click Settings option
            Thread.Sleep(2000);
            groupsPage.ClickSettingsOption();
            log.Info("Click on the Settings option after Group is created.");

            //Click Settings Options value 'Manage Members'
            groupsPage.ClickSettingsOptionsValues("Manage Members");
            log.Info("Verified Settings option value: 'Manage Members'");
            Thread.Sleep(5000);

            //Click cross icon of second record
            groupsPage.ClickManageMemberSecondCrossIcon();
            log.Info("Click on Cross icon of the second member");
            Thread.Sleep(2000);

            //Click Manage Member Window Cancel Button
            groupsPage.PressManageMemberCancelBtn();
            log.Info("Click Manage Group Member Cancel Button.");
            Thread.Sleep(2000);

            //Verify Manage Member Window Remove Button
            groupsPage.AssertManageMemberNoRemoveBtn();
            log.Info("Verify the Manage Group Member Remove Button.");
            Thread.Sleep(2000);

            //Verify Manage Member Window Cancel Button
            groupsPage.AssertManageMemberNoCancelBtn();
            log.Info("Verify the Manage Group Member Cancel Button.");
            Thread.Sleep(2000);

            //Click Add Member Window Close Icon
            groupsPage.ClickAddWindMemberWindowCloseIcon();
            log.Info("Close icon clicked successfully.");
            Thread.Sleep(2000);
        }

        /*[Test]
        public void TC13_ClickManageMembersRemoveBtn()
        {
            //Click Settings option
            Thread.Sleep(2000);
            groupsPage.ClickSettingsOption();
            log.Info("Click on the Settings option after Group is created.");

            //Click Settings Options value 'Manage Members'
            groupsPage.ClickSettingsOptionsValues("Manage Members");
            log.Info("Verified Settings option value: 'Manage Members'");
            Thread.Sleep(5000);

            //Click cross icon of second record
            groupsPage.ClickManageMemberSecondCrossIcon();
            log.Info("Click on Cross icon of the second member");
            Thread.Sleep(2000);

            //Click Manage Member Window Remove Button
            groupsPage.PressManageMemberRemoveBtn();
            log.Info("Click Manage Group Member Remove Button.");
            Thread.Sleep(2000);
                        
            //Click Add Member Window Close Icon
            groupsPage.ClickAddWindMemberWindowCloseIcon();
            log.Info("Close icon clicked successfully.");
            Thread.Sleep(2000);
        }*/

        [Test]
        public void TC14_ClickManageMembersCloseIcon()
        {
            //Click Settings option
            Thread.Sleep(2000);
            groupsPage.ClickSettingsOption();
            log.Info("Click on the Settings option after Group is created.");

            //Click Settings Options value 'Manage Members'
            groupsPage.ClickSettingsOptionsValues("Manage Members");
            log.Info("Verified Settings option value: 'Manage Members'");
            Thread.Sleep(5000);

            //Click Add Member Window Close Icon
            groupsPage.ClickAddWindMemberWindowCloseIcon();
            log.Info("Close icon clicked successfully.");
            Thread.Sleep(2000);
        }

        [Test]
        public void TC15_ClickEditGroupAndVerify()
        {
            //Click Settings option
            Thread.Sleep(2000);
            groupsPage.ClickSettingsOption();
            log.Info("Click on the Settings option after Group is created.");

            //Click Settings Options value 'Edit Group'
            groupsPage.ClickSettingsOptionsValues("Edit Group");
            log.Info("Verified Settings option value: 'Edit Group'");
            Thread.Sleep(2000);

            //Verify Edit Group Window
            groupsPage.AssertEditGroupDialog();
            log.Info("Verify the Edit Group Member Window.");
            Thread.Sleep(2000);

            //Verify Group Name displayed
            groupsPage.AssertGroupName();
            log.Info("Verify the Group Name field.");
            Thread.Sleep(2000);

            //Verify Group Snippet displayed
            groupsPage.AssertGroupSnippet();
            log.Info("Verify the Group Snippet field.");
            Thread.Sleep(2000);

            //Verify Group Description displayed
            groupsPage.AssertGroupDescription();
            log.Info("Verify the Group Description field.");
            Thread.Sleep(2000);

            //Verify Group Leader displayed
            groupsPage.AssertGroupLeader();
            log.Info("Verify the Group Leader field.");
            Thread.Sleep(2000);

            //Verify Group Visibility displayed
            groupsPage.AssertVisibility();
            log.Info("Verify the Group Visibility field.");
            Thread.Sleep(2000);

            //Click Edit Group Window Close Icon
            groupsPage.ClickEditGroupWindowCloseIcon();
            log.Info("Close icon clicked successfully.");
            Thread.Sleep(2000);
        }

        [Test]
        public void TC16_EditGroupName()
        {
            //Click Settings option
            Thread.Sleep(2000);
            groupsPage.ClickSettingsOption();
            log.Info("Click on the Settings option after Group is created.");

            //Click Settings Options value 'Edit Group'
            groupsPage.ClickSettingsOptionsValues("Edit Group");
            log.Info("Verified Settings option value: 'Edit Group'");
            Thread.Sleep(2000);

            //Verify Edit Group Window
            groupsPage.AssertEditGroupDialog();
            log.Info("Verify the Edit Group Member Window.");
            Thread.Sleep(2000);

            //Edit Group Name
            String editGroupName = readGroups.GetValue("EditGroup", "editGroupName");
            groupsPage.enterNewGroupName(editGroupName);
            Thread.Sleep(2000);

            //Click Edit Group Window Save Button
            groupsPage.ClickEditGroupWindowSaveBtn();
            log.Info("Save clicked successfully.");
            Thread.Sleep(5000);

            //Verify the Edited Group Name on the group dashboard
            groupsPage.VerifyGroupNameDashboard(editGroupName);
            log.Info("Verified edited group Name");
            Thread.Sleep(2000);
        }

        [Test]
        public void TC17_EditGroupSnippet()
        {
            //Click Settings option
            Thread.Sleep(2000);
            groupsPage.ClickSettingsOption();
            log.Info("Click on the Settings option after Group is created.");

            //Click Settings Options value 'Edit Group'
            groupsPage.ClickSettingsOptionsValues("Edit Group");
            log.Info("Verified Settings option value: 'Edit Group'");
            Thread.Sleep(2000);

            //Verify Edit Group Window
            groupsPage.AssertEditGroupDialog();
            log.Info("Verify the Edit Group Member Window.");
            Thread.Sleep(2000);

            //Edit Group Snippet
            String editGroupSnippet = readGroups.GetValue("EditGroup", "editGroupSnippet");
            groupsPage.enterNewGroupSnippet(editGroupSnippet);
            Thread.Sleep(2000);

            //Click Edit Group Window Save Button
            groupsPage.ClickEditGroupWindowSaveBtn();
            log.Info("Save clicked successfully.");
            Thread.Sleep(5000);

            //Verify the Edited Group Snippet on the group dashboard
            groupsPage.VerifyGroupSnippetDashboard(editGroupSnippet);
            log.Info("Verified edited group Snippet");
            Thread.Sleep(2000);
        }

        [Test]
        public void TC18_EditGroupDescription()
        {
            //Click Settings option
            Thread.Sleep(2000);
            groupsPage.ClickSettingsOption();
            log.Info("Click on the Settings option after Group is created.");

            //Click Settings Options value 'Edit Group'
            groupsPage.ClickSettingsOptionsValues("Edit Group");
            log.Info("Verified Settings option value: 'Edit Group'");
            Thread.Sleep(2000);

            //Verify Edit Group Window
            groupsPage.AssertEditGroupDialog();
            log.Info("Verify the Edit Group Member Window.");
            Thread.Sleep(2000);
                        
            //Edit Group Description
            String editGroupDesc = readGroups.GetValue("EditGroup", "editGroupDesc");
            groupsPage.enterNewGroupDescription(editGroupDesc);
            Thread.Sleep(2000);
            commonPage.ScrollUp();
            Thread.Sleep(2000);

            //Click Edit Group Window Save Button
            groupsPage.ClickEditGroupWindowSaveBtn();
            log.Info("Save clicked successfully.");
            Thread.Sleep(6000);

            //Verify the Edited Group Desc on the group dashboard
            commonPage.ScrollDown();
            Thread.Sleep(3000);
            groupsPage.VerifyGroupDescDashboard(editGroupDesc);
            log.Info("Verified edited group Desc");
            Thread.Sleep(2000);
        }

        [Test]
        public void TC19_CancelEditGroupDescription()
        {
            //Click Settings option
            commonPage.ScrollUp();
            Thread.Sleep(2000);
            Thread.Sleep(2000);
            groupsPage.ClickSettingsOption();
            log.Info("Click on the Settings option after Group is created.");

            //Click Settings Options value 'Edit Group'
            groupsPage.ClickSettingsOptionsValues("Edit Group");
            log.Info("Verified Settings option value: 'Edit Group'");
            Thread.Sleep(2000);

            //Verify Edit Group Window
            groupsPage.AssertEditGroupDialog();
            log.Info("Verify the Edit Group Member Window.");
            Thread.Sleep(2000);
                        
            //Click Edit Group Window Cancel Button
            groupsPage.ClickEditGroupWindowCancelBtn();
            log.Info("Save clicked successfully.");
            Thread.Sleep(6000);                       
        }

        [Test]
        public void TC21_EditGroupLeader()
        {
            //Click Settings option
            commonPage.ScrollUp();
            Thread.Sleep(2000);
            groupsPage.ClickSettingsOption();
            log.Info("Click on the Settings option after Group is created.");

            //Click Settings Options value 'Edit Group'
            groupsPage.ClickSettingsOptionsValues("Edit Group");
            log.Info("Verified Settings option value: 'Edit Group'");
            Thread.Sleep(2000);

            //Verify Edit Group Window
            groupsPage.AssertEditGroupDialog();
            log.Info("Verify the Edit Group Member Window.");
            Thread.Sleep(2000);

            //Edit Group Leader
            String editgroupLeader = readGroups.GetValue("EditGroup", "editgroupLeader");
            groupsPage.selectOptionFromGroupLeader(editgroupLeader);
            Thread.Sleep(2000);
            commonPage.ScrollUp();
            Thread.Sleep(2000);

            //Click Edit Group Window Save Button
            groupsPage.ClickEditGroupWindowSaveBtn();
            log.Info("Save clicked successfully.");
            Thread.Sleep(5000);

            //Click Settings option
            groupsPage.ClickSettingsOption();
            Thread.Sleep(2000);

            //Verify Settings Options value 'Leave Group'
            groupsPage.GetSettingsOptionsValues("Leave Group");
            log.Info("Verified Settings option value: 'Leave Group'");
            Thread.Sleep(2000);
        }

        [Test]
        public void TC22_ClickDeleteGroupAndVerify()
        {
            //Click Settings option
            commonPage.ScrollUp();
            Thread.Sleep(2000);
            groupsPage.ClickSettingsOption();
            log.Info("Click on the Settings option after Group is created.");

            //Click Settings Options value 'Delete Group'
            groupsPage.ClickSettingsOptionsValues("Delete Group");
            log.Info("Verified Settings option value: 'Delete Group'");
            Thread.Sleep(2000);

            //Verify Delete Group Window
            groupsPage.VerifyDeleteGroupWindow();
            log.Info("Verify the Delete Group Member Window.");
            Thread.Sleep(2000);

            //Verify Delete Group Window No Button 
            groupsPage.VerifyDeleteGroupWindowNoBtn();
            log.Info("Verify the Delete Group Member Window No Button.");
            Thread.Sleep(2000);

            //Verify Delete Group Window Yes Button 
            groupsPage.VerifyDeleteGroupWindowYesBtn();
            log.Info("Verify the Delete Group Member Window.");
            Thread.Sleep(2000);

            //Close the Delete Group Window Close icon
            groupsPage.PressDeleteGroupWindowCrossIcon();
            log.Info("Close the Delete Group Member Window.");
            Thread.Sleep(2000);
        }

        [Test]
        public void TC23_ClickDeleteGroupWindowNoBtn()
        {
            //Click Settings option
            commonPage.ScrollUp();
            Thread.Sleep(2000);
            groupsPage.ClickSettingsOption();
            log.Info("Click on the Settings option after Group is created.");

            //Click Settings Options value 'Delete Group'
            groupsPage.ClickSettingsOptionsValues("Delete Group");
            log.Info("Verified Settings option value: 'Delete Group'");
            Thread.Sleep(2000);
                        
            //Click the Delete Group Window No Button
            groupsPage.PressDeleteGroupWindowNoBtn();
            log.Info("Click the Delete Group Member Window No Button.");
            Thread.Sleep(2000);

            //Verify Group is not deleted
            String editGroupName = readGroups.GetValue("EditGroup", "editGroupName");
            groupsPage.VerifyGroupNameDashboard(editGroupName);
            log.Info("Verified edited group Name");
            Thread.Sleep(2000);
        }

        [Test]
        public void TC24_ClickDeleteGroupWindowYesBtn()
        {
            //Click Settings option
            commonPage.ScrollUp();
            Thread.Sleep(2000);
            groupsPage.ClickSettingsOption();
            log.Info("Click on the Settings option after Group is created.");

            //Click Settings Options value 'Delete Group'
            groupsPage.ClickSettingsOptionsValues("Delete Group");
            log.Info("Verified Settings option value: 'Delete Group'");
            Thread.Sleep(2000);

            //Click the Delete Group Window Yes Button
            groupsPage.PressDeleteGroupWindowYesBtn();
            log.Info("Click the Delete Group Member Window Yes Button.");
            Thread.Sleep(2000);

            //Verify Group deleted confirmation message
            groupsPage.VerifyDeleteGroupConfMsg();
            log.Info("Verify the deleted group confirmation message.");
            Thread.Sleep(2000);
        }

        [Test]
        public void TC25_CreateGroupWithoutName()
        {
            //Click on the side navigation link 'Groups' 
            Thread.Sleep(5000);
            groupsPage.clickGroupsMenu();
            log.Info("Click on the side navigation link 'Groups'");

            //Click on Add New Group button
            Thread.Sleep(5000);
            groupsPage.clickOnAddNewGroupButton();
            log.Info("Click on the Add New Group button at Groups page");

            //Verify the add new group form window
            Thread.Sleep(5000);
            groupsPage.assertAddGroupDialog();
            log.Info("Verify the add new group form window");
                        
            //Enter the Group Snippet
            Thread.Sleep(2000);
            String groupSnippet = readGroups.GetValue("AddPublicGroupDetails", "groupSnippet");
            groupsPage.enterNewGroupSnippet(groupSnippet);

            //Enter the Group Description
            Thread.Sleep(2000);
            commonPage.ScrollDown();
            Thread.Sleep(2000);
            String groupDesc = readGroups.GetValue("AddPublicGroupDetails", "groupDesc");
            groupsPage.enterNewGroupDescription(groupDesc);

            //Select a Group Leader
            Thread.Sleep(2000);
            String groupLeader = readGroups.GetValue("AddPublicGroupDetails", "groupLeader");
            groupsPage.selectOptionFromGroupLeader(groupLeader);

            //Select Group Visibility
            Thread.Sleep(2000);
            String groupVisibility = readGroups.GetValue("AddPublicGroupDetails", "groupVisibility");
            groupsPage.selectVisibility(groupVisibility);

            //Click on the create button at Add New Group form
            Thread.Sleep(2000);
            groupsPage.clickOnCreateButton();

            //Verify the error message for not entering the Group Name
            Thread.Sleep(2000);
            groupsPage.VerifyGroupErrorMsg();
            log.Info("Verify the error message for not entering Group Name.");

        }

    }
}