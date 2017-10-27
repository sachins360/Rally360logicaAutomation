﻿using RallyTeam.Util;
using System.Configuration;
using OpenQA.Selenium;
using System;
using log4net;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Safari;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Edge;
using System.Drawing;
using System.Reflection;
using System.Text;
using System.Threading;
using NUnit.Framework;
using System.Linq;
using OpenQA.Selenium.PhantomJS;
using RallyTeam.UIPages;
using NUnit.Framework.Interfaces;
using System.Diagnostics;
using System.Collections.Generic;

namespace RallyTeam.TestScripts
{
    
    public class BaseTestES : IDisposable
    {
        protected IWebDriver _driver;
        protected AssertHelper _assertHelper;
        protected static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        //user details
        protected string _workEmail = ConfigurationSettings.AppSettings["workEmail"];
        protected string _password = ConfigurationSettings.AppSettings["password"];

        protected int _pageLoadTimeout = Convert.ToInt32(ConfigurationSettings.AppSettings["PageLoadTimeout"]);

        protected int _announcementPopupTimeout = Convert.ToInt32(ConfigurationSettings.AppSettings["AnnouncementPopupTimeout"]);
        protected int _loginConfirmTimeout = Convert.ToInt32(ConfigurationSettings.AppSettings["LoginConfirmTimeout"]);

        public string _browser = ConfigurationSettings.AppSettings["Browser"].ToLower();
        protected int _browserWidth = Convert.ToInt32(ConfigurationSettings.AppSettings["BrowserWidth"]);
        protected int _browserHeight = Convert.ToInt32(ConfigurationSettings.AppSettings["BrowserHeight"]);
        private string _testURL = ConfigurationSettings.AppSettings["URL"];
        public string _externalStormURL = ConfigurationSettings.AppSettings["ExternalStormURL"];
        public string _productionURL = ConfigurationSettings.AppSettings["Production"];

        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        protected AuthenticationPage authenticationPage;
        protected CommonMethods commonPage;
        protected DashboardPage dashboardPage;
        protected UserProfilePage userProfilePage;
        protected PostProjectPage postProjectPage;
        protected MarketplacePage marketplacePage;
        protected DirectMessagingPage directMessagingPage;
        protected DirectoryPage directoryPage;
        protected InvoicingPage invoicingPage;
        protected AddUsersPage addUsersPage;
        protected VendorPage vendorPage;
        protected NotificationsPage notificationsPage;
        protected RegistrationPage registrationPage;
        protected GroupsPage groupsPage;
        protected CommonIssuesPage commonIssuePage;
        protected JobsPage jobsPage;

        String BaseUrl;
        public BaseTestES(string urlKey)
        {
            //BaseUrl = urlKey;
            BaseUrl = ConfigurationManager.AppSettings[urlKey];
            //Environment = environment;
        }

        /*public enum Environment
        {
            Preprod,
            Production,
            Hotfix,
            Development
        }

        public class Settings
        {
            public static string PreprodUrl { get { return "some url"; } }
            public static string ProductionUrl { get { return "some url"; } }
        }

        public Dictionary<Environment, string> PossibleEnvironments
        {
            get
            {
                return new Dictionary<Environment, string>()
                {
                    { Environment.Preprod, Settings.PreprodUrl },
                    { Environment.Production, Settings.ProductionUrl },
                };
            }
        }

        public Environment CurrentEnvironment { get; set; }

        protected string CurrentEnvironmentURL
        {
            get
            {
                string url;
                if (PossibleEnvironments.TryGetValue(CurrentEnvironment, out url))
                {
                    return url;
                }

                throw new InvalidOperationException(string.Format("The current environment ({0}) is not valid or does not have a mapped URL!", CurrentEnvironment));
            }
        }

        public BaseTestES(Environment environment)
        {
            CurrentEnvironment = environment;
        }*/



        [SetUp]
        public void TestSetUp()
        {
            _driver = GetDriver();
            dashboardPage = new DashboardPage(_driver, _pageLoadTimeout);
            commonPage = new CommonMethods(_driver, _pageLoadTimeout);
            authenticationPage = new AuthenticationPage(_driver, _pageLoadTimeout);
            postProjectPage = new PostProjectPage(_driver, _pageLoadTimeout);
            marketplacePage = new MarketplacePage(_driver, _pageLoadTimeout);
            directMessagingPage = new DirectMessagingPage(_driver, _pageLoadTimeout);
            directoryPage = new DirectoryPage(_driver, _pageLoadTimeout);
            invoicingPage = new InvoicingPage(_driver, _pageLoadTimeout);
            addUsersPage = new AddUsersPage(_driver, _pageLoadTimeout);
            registrationPage = new RegistrationPage(_driver, _pageLoadTimeout);
            userProfilePage = new UserProfilePage(_driver, _pageLoadTimeout);
            commonIssuePage = new CommonIssuesPage(_driver, _pageLoadTimeout);
            vendorPage = new VendorPage(_driver, _pageLoadTimeout);
            notificationsPage = new NotificationsPage(_driver, _pageLoadTimeout);
            groupsPage = new GroupsPage(_driver, _pageLoadTimeout);
            jobsPage = new JobsPage(_driver, _pageLoadTimeout);

            _assertHelper = new AssertHelper(_driver, _pageLoadTimeout);
            _driver.Manage().Window.Maximize();
            _driver.Url = BaseUrl;
            _driver.setTimeOut(_pageLoadTimeout);

            if (_browser == "phantomjs")
            {
                _driver.Manage().Window.Size = new Size(_browserWidth, _browserHeight);
            }
            Log.Info("Setup test");

            Global.MethodName = "TestSetup";
            commonPage.RefreshPage();
            Thread.Sleep(5000);
            authenticationPage.SetUserName(_workEmail);
            authenticationPage.SetPassword(_password);
            authenticationPage.ClickOnLoginButton();
            //Thread.Sleep(3000);
            //authenticationPage.CloseAnnouncementPopup(_announcementPopupTimeout);           
            //Thread.Sleep(2000);
        }

        [TearDown]
        public void TearDown()
        {
            try
            {
                var currentContext = TestContext.CurrentContext;
                if (currentContext.Result.Outcome != ResultState.Success)
                {
                    var testName = currentContext.Test.Name;
                    String filename = "Screenshots\\" + this.GetType().FullName + "." + testName + "_" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + ".png";
                    Console.WriteLine("filename: " + filename);
                    UtilityHelper.TakeScreenshot(_driver, filename);
                }
                Log.Info("Teardown test");
                _driver.Quit();
            }
            catch { _driver.Dispose(); }
        }
        public IWebDriver GetDriver()
        {
            string path = System.IO.Directory.GetCurrentDirectory();
            switch (_browser)
            {
                case "chrome":
                    System.Environment.SetEnvironmentVariable("webdriver.chrome.driver", "chromedriver.exe");
                    //var options = new ChromeOptions();

                    ChromeOptions options = new ChromeOptions();
                    //DesiredCapabilities capabilities = DesiredCapabilities.Chrome();
                    options.AddArguments("--disable-extensions");
                    options.AddArguments("-ignore-certificate-errors");
                    options.AddArgument("test-type");
                    options.AddArguments("disable-infobars");
                    options.ToCapabilities();
                    //capabilities.SetCapability("chrome.binary", @"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe");
                    //capabilities.SetCapability(ChromeOptions.Capability, options);
                    return new ChromeDriver(options);
                case "firefox":
                    System.Environment.SetEnvironmentVariable("webdriver.chrome.driver", "geckodriver.exe");
                    return new FirefoxDriver();
                case "ie":
                    System.Environment.SetEnvironmentVariable("webdriver.ie.driver", "IEDriverServer.exe");
                    InternetExplorerOptions ieoptions = new InternetExplorerOptions { EnableNativeEvents = false, RequireWindowFocus = true };
                    ieoptions.AddAdditionalCapability("disable-popup-blocking", true);
                    return new InternetExplorerDriver(AppDomain.CurrentDomain.BaseDirectory + ConfigurationManager.AppSettings["IDEServerPath"], ieoptions, TimeSpan.FromSeconds(90));
                case "edge":
                    Console.WriteLine("path: " + path);
                    //System.setProperty("webdriver.edge.driver", "C:\\Program Files (x86)\\Microsoft Web Driver\\MicrosoftWebDriver.exe");
                    System.Environment.SetEnvironmentVariable("webdriver.edge.driver", "MicrosoftWebDriver.exe");
                    return new EdgeDriver();

                case "phantomjs":
                    System.Environment.SetEnvironmentVariable("phantomjs.binary.path", "phantomjs.exe");
                    return new PhantomJSDriver();
                case "safari":
                    return new SafariDriver();
                default:
                    return null;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {

            }
        }

        //Generate random string
        private static Random random = new Random((int)DateTime.Now.Ticks);
        protected string RandomString(int size)
        {
            StringBuilder builder = new StringBuilder();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            return builder.ToString().ToLower();
        }

        // Generate random number
        public static string RandomNumber(int length)
        {
            const string chars = "0123456789";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        protected void acceptAlertMultipleTime(int count)
        {
            for (int i = 0; i < count; i++)
            {
                acceptAlert();
                Thread.Sleep(1000);
            }
        }
        protected void acceptAlert()
        {
            string alertText = "";
            IAlert alert = null;

            {
                if (alert == null)
                {
                    try
                    {
                        alert = _driver.SwitchTo().Alert();
                        alert.Accept();
                    }
                    catch (Exception ex)
                    { System.Threading.Thread.Sleep(50); }
                }
                else
                {
                    try
                    {
                        alert.Accept();
                        alertText = alert.Text;
                    }
                    catch (Exception ex)
                    {
                        if (ex.Message.Equals("No alert is present")) alertText = "Already Accepted";
                        else System.Threading.Thread.Sleep(50);

                    }
                }
            }
        }
        ~BaseTestES()
        {
            Dispose(false);
        }
    }
}
