﻿using OpenQA.Selenium;
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
    public class MarketplacePage : BasePage
    {
        CommonMethods commonPage;

        public MarketplacePage(IWebDriver driver, int pageLoadTimeout)
            : base(driver, pageLoadTimeout)
        {
            commonPage = new CommonMethods(_driver, pageLoadTimeout);
        }
               

        //Click on Marketplace tab
        public void ClickMarketplaceTab()
        {
            _driver.CheckElementClickable(MarketPlaceUI.marketplaceTab);
            _driver.SafeClick(MarketPlaceUI.marketplaceTab);
        }

        //Click on Jobs tab
        public void ClickJobsTab()
        {
            _driver.SafeClick(MarketPlaceUI.jobTab);
        }

        //Click on Browse button
        public void ClickBrowseBtn()
        {
            _driver.SafeClick(MarketPlaceUI.browseBtn);
        }

        //Enter the Search text field
        public void EnterSearchField(String search)
        {
            _driver.SafeEnterText(MarketPlaceUI.searchText, search);
        }

        //Click the Search button
        public void ClickSearchBtn()
        {
            _driver.CheckElementVisibility(MarketPlaceUI.searchProjBtn);
            _driver.CheckElementClickable(MarketPlaceUI.searchProjBtn);
            _driver.SafeClick(MarketPlaceUI.searchProjBtn);
        }

        //Press Home Search button
        public void ClickHomeSearchBtn()
        {
            _driver.SafeClick(MarketPlaceUI.searchBtn);
        }

        //Select All Projects drop-down value
        public void SelectAllProjectsDropDown(String option)
        {
            _driver.SelectDropDownOption(option, MarketPlaceUI.allProjectsDropDown);
        }

        

        //Click the Project on Projects Page        
        public void ClickProjectSearchButton()
        {
            _driver.CheckElementVisibility(MarketPlaceUI.projectSearchButton);
            _driver.CheckElementClickable(MarketPlaceUI.projectSearchButton);
            _driver.ClickElementUsingJS(MarketPlaceUI.projectSearchButton);
        }


        //Click the Project on Projects Page        
        public void ClickProjectNameOnPage(String projectName)
        {
            _driver.CheckElementVisibility(ProjectsUI.ProjectNameOnPage(projectName));
            _driver.CheckElementClickable(ProjectsUI.ProjectNameOnPage(projectName));            
            _driver.ClickElementUsingJS(ProjectsUI.ProjectNameOnPage(projectName));
        }

        


    }
}
