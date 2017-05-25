using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RallyTeam.UILocators;
using RallyTeam.Util;
using OpenQA.Selenium;
using RallyTeam.UILocators;

namespace RallyTeam.UIPages
{
    public abstract class BasePage
    {
        protected IWebDriver _driver;
        protected AssertHelper _assertHelper;
        protected static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public int PageLoadTimeout { get; set; }

        public BasePage(IWebDriver driver, int pageLoadTimeout)
        {
            _driver = driver;
            _assertHelper = new AssertHelper(driver, pageLoadTimeout);
            PageLoadTimeout = pageLoadTimeout;
        }

        // Click on logout
        public AuthenticationPage LogOut()
        {
            _driver.SafeClick(BaseUI.logOut);
            return new AuthenticationPage(_driver, PageLoadTimeout);
        }
    }
}
