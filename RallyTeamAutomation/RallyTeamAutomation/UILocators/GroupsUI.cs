using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RallyTeam.UILocators
{
    public static class GroupsUI
    {
        public readonly static By groupsTab = By.XPath("//a[text()= 'Groups']");
        public readonly static By addGroupBtn = By.XPath("//button[contains(text(), 'Add Group')]");
        public readonly static By addGroupName = By.XPath("//input[@name= 'title']");
        public readonly static By addGroupType = By.XPath("//select[@name= 'userType']");
        public readonly static By addGroupUserIcon = By.XPath("//i[contains(@class, 'fa-user-plus')]");
        public readonly static By addGroupUserEmail = By.XPath("//input[@placeholder= 'Enter a name or email address to add']");
        public readonly static By addGroupUserDoneBtn = By.XPath("//a[text()= 'Add']");
        public readonly static By createBtn = By.XPath("//a[text()= 'Create']");
        public readonly static By cancelBtn = By.XPath("//a[text()= 'Cancel']");
        public readonly static By removeMemberIcon = By.XPath("//div[@class= 'rt-member__remove-container']//i[@tooltip= 'Remove User']");

        public readonly static By userAddedToGroup = By.XPath("//div[contains(@class,'rt-member ng-scope')]//a[contains(@class,'rt-member')]");


    }
}
