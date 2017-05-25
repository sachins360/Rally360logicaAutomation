using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;


namespace RallyTeam.UILocators
{
    public static class BaseUI
    {
        public readonly static By logOut = By.XPath("//a[@id='lnkLogOf']");
        public readonly static By logoIcon = By.Id("lnkUserProfile");
    }
}
