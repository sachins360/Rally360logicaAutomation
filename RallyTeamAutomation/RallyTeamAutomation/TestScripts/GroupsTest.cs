﻿using NUnit.Framework;
using RallyTeam.UILocators;
using RallyTeam.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace RallyTeam.TestScripts
{
    [TestFixture]
    [Category("Groups")]
    public class GroupsTest : BaseTestES
    {    
                
        [Test]
        public void Groups_001_CreateEmployeeGroup()
        {
            Global.MethodName = "Groups_001_CreateEmployeeGroup";

            //Click User Profile Icon
            Thread.Sleep(5000);
            userProfilePage.ClickUserProfileIcon();
            log.Info("Click User Profile Icon.");
            Thread.Sleep(2000);

            //Click Admin from the User Profile Options
            userProfilePage.ClickUserProfileOptions("Admin");
            log.Info("Click User Profile option 'Admin'.");
            Thread.Sleep(5000);

            //Click Groups Tab
            groupsPage.ClickGroupsTab();
            log.Info("Click Groups Tab");
            Thread.Sleep(3000);

            //Click Add Group Button
            groupsPage.ClickAddGroupBtn();
            log.Info("Click Add Group Button");
            Thread.Sleep(5000);

            //Enter Group Name
            String groupName;
            StringBuilder builder;
            builder = new StringBuilder();
            builder.Append(RandomString(4));
            groupName = builder.ToString();
            groupsPage.EnterGroupName(groupName);
            log.Info("Enter Group Name");
            Thread.Sleep(1000);

            //Select Group Type Employee
            groupsPage.SelectGroupType("Employee");
            log.Info("Select Group Type as Employee");
            Thread.Sleep(2000);

            //Click Create button
            groupsPage.ClickCreateBtn();
            log.Info("Click Create button");
            Thread.Sleep(5000);
        }

        [Test]
        public void Groups_002_CreateExternalUserGroup()
        {
            Global.MethodName = "Groups_002_CreateExternalUserGroup";

            //Click User Profile Icon
            Thread.Sleep(5000);
            userProfilePage.ClickUserProfileIcon();
            log.Info("Click User Profile Icon.");
            Thread.Sleep(2000);

            //Click Admin from the User Profile Options
            userProfilePage.ClickUserProfileOptions("Admin");
            log.Info("Click User Profile option 'Admin'.");
            Thread.Sleep(5000);

            //Click Groups Tab
            groupsPage.ClickGroupsTab();
            log.Info("Click Groups Tab");
            Thread.Sleep(3000);

            //Click Add Group Button
            groupsPage.ClickAddGroupBtn();
            log.Info("Click Add Group Button");
            Thread.Sleep(5000);

            //Enter Group Name
            String groupName;
            StringBuilder builder;
            builder = new StringBuilder();
            builder.Append(RandomString(4));
            groupName = builder.ToString();
            groupsPage.EnterGroupName(groupName);
            log.Info("Enter Group Name");
            Thread.Sleep(1000);

            //Select Group Type External User
            groupsPage.SelectGroupType("External User");
            log.Info("Select Group Type as External User");
            Thread.Sleep(2000);

            //Click Create button
            groupsPage.ClickCreateBtn();
            log.Info("Click Create button");
            Thread.Sleep(5000);
        }

        [Test]
        public void Groups_003_CreateVendorGroup()
        {
            Global.MethodName = "Groups_003_CreateVendorGroup";

            //Click User Profile Icon
            Thread.Sleep(5000);
            userProfilePage.ClickUserProfileIcon();
            log.Info("Click User Profile Icon.");
            Thread.Sleep(2000);

            //Click Admin from the User Profile Options
            userProfilePage.ClickUserProfileOptions("Admin");
            log.Info("Click User Profile option 'Admin'.");
            Thread.Sleep(5000);

            //Click Groups Tab
            groupsPage.ClickGroupsTab();
            log.Info("Click Groups Tab");
            Thread.Sleep(3000);

            //Click Add Group Button
            groupsPage.ClickAddGroupBtn();
            log.Info("Click Add Group Button");
            Thread.Sleep(5000);

            //Enter Group Name
            String groupName;
            StringBuilder builder;
            builder = new StringBuilder();
            builder.Append(RandomString(4));
            groupName = builder.ToString();
            log.Info("Enter Group Name");
            Thread.Sleep(1000);

            //Select Group Type Vendor
            groupsPage.SelectGroupType("Vendor");
            log.Info("Select Group Type as Vendor");
            Thread.Sleep(2000);

            //Click Create button
            groupsPage.ClickCreateBtn();
            log.Info("Click Create button");
            Thread.Sleep(5000);
        }

        [Test]
        public void Groups_004_AddMemberToGroup()
        {
            Global.MethodName = "Groups_004_AddMemberToGroup";

            //Click User Profile Icon
            Thread.Sleep(5000);
            userProfilePage.ClickUserProfileIcon();
            log.Info("Click User Profile Icon.");
            Thread.Sleep(2000);

            //Click Admin from the User Profile Options
            userProfilePage.ClickUserProfileOptions("Admin");
            log.Info("Click User Profile option 'Admin'.");
            Thread.Sleep(5000);

            //Click Groups Tab
            groupsPage.ClickGroupsTab();
            log.Info("Click Groups Tab");
            Thread.Sleep(3000);

            //Click Add Group Button
            groupsPage.ClickAddGroupBtn();
            log.Info("Click Add Group Button");
            Thread.Sleep(5000);

            //Enter Group Name
            String groupName;
            StringBuilder builder;
            builder = new StringBuilder();
            builder.Append(RandomString(4));
            groupName = builder.ToString();
            log.Info("Enter Group Name");
            Thread.Sleep(1000);

            //Click Add Member Icon
            groupsPage.ClickAddMemberIcon();
            log.Info("Click Add member icon");
            Thread.Sleep(3000);

            //Enter User Email Address
            groupsPage.EnterGroupMemberEmail("smith@mailinator.com");
            log.Info("Enter a user email address");
            Thread.Sleep(3000);
            commonPage.PressEnterKey();
            Thread.Sleep(3000);

            //click Done Button
            groupsPage.ClickDoneBtn();
            log.Info("Click Done button");
            Thread.Sleep(5000);

            //Click Create button
            groupsPage.ClickCreateBtn();
            log.Info("Click Create button");
            Thread.Sleep(5000);
        }

        [Test]
        public void Groups_005_RemoveMemberFromGroup()
        {
            Global.MethodName = "Groups_005_RemoveMemberFromGroup";

            //Click User Profile Icon
            Thread.Sleep(5000);
            userProfilePage.ClickUserProfileIcon();
            log.Info("Click User Profile Icon.");
            Thread.Sleep(2000);

            //Click Admin from the User Profile Options
            userProfilePage.ClickUserProfileOptions("Admin");
            log.Info("Click User Profile option 'Admin'.");
            Thread.Sleep(5000);

            //Click Groups Tab
            groupsPage.ClickGroupsTab();
            log.Info("Click Groups Tab");
            Thread.Sleep(3000);

            //Click Add Group Button
            groupsPage.ClickAddGroupBtn();
            log.Info("Click Add Group Button");
            Thread.Sleep(5000);

            //Enter Group Name
            String groupName;
            StringBuilder builder;
            builder = new StringBuilder();
            builder.Append(RandomString(4));
            groupName = builder.ToString();
            log.Info("Enter Group Name");
            Thread.Sleep(1000);

            //Click Add Member Icon
            groupsPage.ClickAddMemberIcon();
            log.Info("Click Add member icon");
            Thread.Sleep(3000);

            //Enter User Email Address
            groupsPage.EnterGroupMemberEmail("smith@mailinator.com");
            log.Info("Enter a user email address");
            Thread.Sleep(3000);
            commonPage.PressEnterKey();
            Thread.Sleep(3000);

            //click Done Button
            groupsPage.ClickDoneBtn();
            log.Info("Click Done button");
            Thread.Sleep(5000);

            //Click the added member remove icon
            postProjectPage.ClickAddedMemberRemoveIcon();
            log.Info("Click group member added remove icon.");
            Thread.Sleep(2000);

            //Click Create button
            groupsPage.ClickCreateBtn();
            log.Info("Click Create button");
            Thread.Sleep(5000);
        }

    }

}
