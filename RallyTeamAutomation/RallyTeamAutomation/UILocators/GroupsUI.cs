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

        public readonly static By checkboxEmployee = By.XPath("//div[@class='rt-checkbox fa m-r-sm col-sm-2 ng-scope fa-check-square-o']");

   
        public readonly static By groupsSaveButton = By.XPath("//div[@class='text-right']//a[text()='Save']");
        //public readonly static By groupsSaveButton = By.XPath("//div[@class='text-right']//a[@class='btn rt-btn--l rt-btn--primary m-r-md ng-binding']");
        public readonly static By groupsDeleteIcon = By.XPath("//div[@class='ng-scope ng-isolate-scope']/div");
        public readonly static By chkDirectMessageChecked = By.XPath("(//div[@class='m-t-md'])[4]//span[@class='rt-checkbox fa m-r-md fa-check-square-o']");
        public readonly static By chkDirectMessageUnchecked = By.XPath("(//div[@class='m-t-md'])[4]//span[@class='rt-checkbox fa m-r-md fa-square-o']");
        public readonly static By groupsTab = By.XPath("//a[text()= 'Roles']");
        public readonly static By FeaturesTab = By.XPath("//a[text()= 'Features']");
        
        public readonly static By featuresTab = By.XPath("//ul[@class='nav nav-tabs']//li[@class='ng-scope active']//a[text()='Features']");
        public readonly static By addGroupBtn = By.XPath("//button[contains(text(), 'Add Role')]");
        public readonly static By addGroupName = By.XPath("//input[@name= 'groupName']");
        public readonly static By colorCodeSelect = By.XPath("//button[contains(@class, 'rt-colorpicker__button')]");
        public static By selectColor(string var)
        {
            return By.XPath("//ul[contains(@class, 'rt-colorpicker__dropdown')]//li["+var+"]");
        }
        public readonly static By addGroupType = By.XPath("//select[@name= 'userType']");
        public readonly static By addGroupUserIcon = By.XPath("//i[contains(@class, 'fa-user-plus')]");
        public readonly static By addGroupUserEmail = By.XPath("//input[@placeholder= 'Enter a name or email address to add']");
        public readonly static By addGroupUserDoneBtn = By.XPath("//a[text()= 'Add']");
        public readonly static By createBtn = By.XPath("//a[text()= 'Create']");
        public readonly static By cancelBtn = By.XPath("//a[text()= 'Cancel']");
        public readonly static By removeMemberIcon = By.XPath("//div[@class= 'rt-member__remove-container']//i[@tooltip= 'Remove User']");

        public readonly static By userAddedToGroup = By.XPath("//div[contains(@class,'rt-member ng-scope')]//a[contains(@class,'rt-member')]");

        public static By getGroupsDeleteIcon(string variable)
        {
            
            return By.XPath("//div[@class ='ng-scope ng-isolate-scope']//div[" + variable + "]//div//i[contains(@ng-if,'role.isCustom')]");
        }
        public static By getGroupsEditIcon(string variable)
        {
            return By.XPath("//div[@class ='ng-scope ng-isolate-scope']//div[" + variable + "]//div//i[1]");
        }
    }
}
