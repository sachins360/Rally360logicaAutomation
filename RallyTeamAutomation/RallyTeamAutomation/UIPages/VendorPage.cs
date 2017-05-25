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

namespace RallyTeam.UIPages
{
    public class VendorPage : BasePage
    {
        CommonMethods commonPage;

        public VendorPage(IWebDriver driver, int pageLoadTimeout)
            : base(driver, pageLoadTimeout)
        {
            commonPage = new CommonMethods(_driver, pageLoadTimeout);
        }

        //Press Vendors tab
        public void ClickVendorsTab()
        {
            _driver.SafeClick(VendorUI.vendorsTab);
        }

        //Click Add Vendors button
        public void ClickAddVendorsBtn()
        {
            _driver.SafeClick(VendorUI.addVendorsBtn);
        }

        //Enter Comapny Name
        public void EnterCompanyName(string companyName)
        {
            _driver.SafeEnterText(VendorUI.companyName, companyName);
        }

        //Enter Comapny Description
        public void EnterCompanyDesc(string companyDesc)
        {
            _driver.SafeEnterText(VendorUI.companyDesc, companyDesc);
        }

        //Enter Services
        public void EnterServices(string services)
        {
            _driver.SafeEnterText(VendorUI.services, services);
        }

        //Select Vendor Owner
        public void SelectVendorOwner(string vendorOwner)
        {
            _driver.SelectDropDownOption(vendorOwner, VendorUI.vendorOwner);
        }

        //Enter Company Location
        public void EnterCompanyLocation(string location)
        {
            _driver.SafeEnterText(VendorUI.companyLocation, location);
        }

        //Enter Company Phone
        public void EnterCompanyPhone(string phone)
        {
            _driver.SafeEnterText(VendorUI.companyPhone, phone);
        }

        //Enter Company Website
        public void EnterCompanyWebsite(string website)
        {
            _driver.SafeEnterText(VendorUI.companyWebsite, website);
        }

        //Enter Skills
        public void EnterSkills(string skills)
        {
            _driver.SafeEnterText(VendorUI.skills, skills);
        }

        //Enter Company Facebook
        public void EnterCompanyFacebook(string facebook)
        {
            _driver.SafeEnterText(VendorUI.companyFacebook, facebook);
        }

        //Enter Company Twitter
        public void EnterCompanyTwitter(string twitter)
        {
            _driver.SafeEnterText(VendorUI.companyTwitter, twitter);
        }

        //Enter Company LinkedIn
        public void EnterCompanyLinkedIn(string linkedIn)
        {
            _driver.SafeEnterText(VendorUI.companyLinkedIn, linkedIn);
        }

        //Click Upload Company Logo link
        public void ClickUploadCompanyLogo()
        {
            _driver.SafeClick(VendorUI.uploadCompanyLogo);
        }

        //Click Upload Background Photo link
        public void ClickUploadBackgroundPhoto()
        {
            _driver.SafeClick(VendorUI.uploadBackgroundPhoto);
        }

        //Click Upload Company Logo link
        public void ClickCreateProfile()
        {
            _driver.SafeClick(VendorUI.createProfileBtn);
        }

        //Select Group as Vendor
        public void SelectGroup()
        {
            _driver.SelectDropDownOption("Vendor", VendorUI.groupDropDown);
        }

        //Assert Vendor First Time Window
        public void VerifyVendorFirstWindow()
        {
            _assertHelper.AssertElementDisplayed(VendorUI.vendorFirstWindow);
        }

        //Click Get Started Button
        public void ClickGetStartedBtn()
        {
            _driver.SafeClick(VendorUI.getStartedBtn);
        }

        //Assert Vendor Name on Vendor Profile Page
        public void VerifyVendorName(string vendorName)
        {
            _assertHelper.AssertElementDisplayed(VendorUI.vendorNameOnProfile(vendorName));
        }

        //Assert Vendor Created Message
        public void VerifyVendorCreatedMsg()
        {
            _assertHelper.AssertElementDisplayed(VendorUI.vendorCreatedMsg);
        }
    }
}
