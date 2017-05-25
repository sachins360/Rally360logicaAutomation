﻿using System;
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
        public readonly static By myGrpTest = By.XPath("//h3[text()= 'My Groups']");


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
        public readonly static By messageIcon = By.XPath("//i[contains(@class, 'fa fa-envelope-o')]");
        public readonly static By messageCounter = By.XPath("//span[contains(@class, 'rt-top-navbar__messages-count')]");
        public static By increasedMessageCounter(string variable)
        {
            return By.XPath("//span[contains(@class, 'rt-top-navbar__messages-count')] and text()= '" + variable+"']");
        }

    }
}
