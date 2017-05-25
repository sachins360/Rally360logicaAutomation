using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RallyTeam.UILocators
{
    public static class VendorUI
    {
        public readonly static By vendorFirstWindow = By.XPath("//div[@class= 'modal-content']//div[contains(text(), 'Update!')]");
        public readonly static By getStartedBtn = By.XPath("//button[@type= 'submit']");
        public readonly static By vendorsTab = By.XPath("//a[contains(text(), 'Vendors')]");
        public readonly static By addVendorsBtn = By.XPath("//button[contains(text(), 'Add Vendor')]");
        public readonly static By companyName = By.XPath("//input[@name= 'name']");
        public readonly static By companyDesc = By.XPath("//textarea[@name= 'description']");
        public readonly static By services = By.XPath("//input[@placeholder= '+ add up to 5 services']");
        public readonly static By vendorOwner = By.XPath("//select[@name= 'selectedVendorOwner']");
        public readonly static By companyLocation = By.XPath("//input[@name= 'location']");
        public readonly static By companyPhone = By.XPath("//input[@name= 'phone']");
        public readonly static By companyWebsite = By.XPath("//input[@name= 'website']");
        public readonly static By skills = By.XPath("//input[@placeholder= '+ add skills']");
        public readonly static By companyFacebook = By.XPath("//input[@name= 'facebook']");
        public readonly static By companyTwitter = By.XPath("//input[@name= 'twitter']");
        public readonly static By companyLinkedIn = By.XPath("//input[@name= 'linkedIn']");
        public readonly static By createProfileBtn = By.XPath("//a[text()= 'Create Profile']");
        public readonly static By uploadCompanyLogo = By.XPath("//label[@for= 'profile-image-select']");
        public readonly static By uploadBackgroundPhoto = By.XPath("//label[@for= 'cover-image-select']");        
        public readonly static By groupDropDown = By.XPath("//td[@class= 'project-title']//select");
        public static By vendorNameOnProfile(string variable)
        {
            return By.XPath("//div[text()= '" + variable + "']");
        }
        public readonly static By vendorCreatedMsg = By.XPath("//div[contains(text(), 'Vendor successfully created.')]");
        






    }
}
