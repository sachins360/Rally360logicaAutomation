using RallyTeam.Util;
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
using AventStack.ExtentReports;
using NUnit.Framework.Internal;

namespace RallyTeam.TestScripts
{
    public class BaseTestWithoutLogin : IDisposable
    {
        protected IWebDriver _driver;
        protected AssertHelper _assertHelper;
        protected static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        //public static ExtentReports extent;
        //public static ExtentTest test;

        public const int _reTryCount = 3;
        //user details
        protected string _workEmail = ConfigurationSettings.AppSettings["workEmail"];
        protected string _password = ConfigurationSettings.AppSettings["password"];

        protected int _pageLoadTimeout = Convert.ToInt32(ConfigurationSettings.AppSettings["PageLoadTimeout"]);
        protected int _loginConfirmTimeout = Convert.ToInt32(ConfigurationSettings.AppSettings["LoginConfirmTimeout"]);

        protected string _browser = ConfigurationSettings.AppSettings["Browser"].ToLower();
        protected int _browserWidth = Convert.ToInt32(ConfigurationSettings.AppSettings["BrowserWidth"]);
        protected int _browserHeight = Convert.ToInt32(ConfigurationSettings.AppSettings["BrowserHeight"]);
        private string _testURL = ConfigurationSettings.AppSettings["URL"];
        public string _externalStormURL = ConfigurationSettings.AppSettings["ExternalStormURL"];
        public string _productionURL = ConfigurationSettings.AppSettings["Production"];

        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        protected AuthenticationPage authenticationPage;
        protected RegistrationPage registrationPage;
        protected DashboardPage dashboardPage;
        protected CommonMethods commonPage;

        String BaseUrl;
        String Browser;
        public BaseTestWithoutLogin(string urlKey, string browser = "chrome")
        {
            BaseUrl = ConfigurationManager.AppSettings[urlKey];
            Browser = browser;
        }

        /*[OneTimeSetUp]
        public void StartReport()
        {
            //*********Extent Report Generation One Time Setup*********
            String rootPath = AppDomain.CurrentDomain.BaseDirectory;
            ExtentHtmlReporter htmlReporter = new ExtentHtmlReporter(rootPath + "\\Report" + "\\ExecutionResult.html");
            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
        }*/

        [SetUp]
        public void TestSetUp()
        {
            _driver = GetDriver();
            authenticationPage = new AuthenticationPage(_driver, _pageLoadTimeout);
            registrationPage = new RegistrationPage(_driver, _pageLoadTimeout);

            //*********Extent Report Generation*********
            var currentContext = TestContext.CurrentContext;
            var testName = currentContext.Test.Name;
            String filename = this.GetType().FullName + "." + testName;
            Global.test = Global.extent.CreateTest(filename);
            Global.test.AssignAuthor("360Logica");

            _assertHelper = new AssertHelper(_driver, _pageLoadTimeout);
            //if (!Browser.Contains("edge"))
            if (!Browser.Contains("firefox"))
                _driver.Manage().Window.Maximize();
            _driver.Url = BaseUrl;
            _driver.setTimeOut(_pageLoadTimeout);

            if (_browser == "phantomjs")
            {
                _driver.Manage().Window.Size = new Size(_browserWidth, _browserHeight);
            }
            Log.Info("Setup test");


            dashboardPage = new DashboardPage(_driver, _pageLoadTimeout);
            commonPage = new CommonMethods(_driver, _pageLoadTimeout);
        }

        [TearDown]
        public void TearDown()
        {
            try
            {
                var currentContext = TestContext.CurrentContext;
                var currentContext2 = TestExecutionContext.CurrentContext;
                var message = TestContext.CurrentContext.Result.Message;
                var stackTrace = TestContext.CurrentContext.Result.StackTrace;
                if (currentContext.Result.Outcome != ResultState.Success)
                {
                    var testName = currentContext.Test.Name;
                    String rootPath = AppDomain.CurrentDomain.BaseDirectory;
                    String filename = rootPath + "\\Report\\" + this.GetType().FullName + "." + testName + "_" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + ".png";
                    Console.WriteLine("filename: " + filename);
                    UtilityHelper.TakeScreenshot(_driver, filename);
                    Global.test.Log(Status.Fail, stackTrace + message);
                }
                Log.Info("Teardown test");
                _driver.Quit();
            }
            catch { _driver.Dispose(); }
        }

        public IWebDriver GetDriver()
        {
            switch (_browser)
            {
                case "chrome":
                    System.Environment.SetEnvironmentVariable("webdriver.chrome.driver", "chromedriver.exe");
                    //var options = new ChromeOptions();

                    ChromeOptions options = new ChromeOptions();
                    //DesiredCapabilities capabilities = DesiredCapabilities.Chrome();
                    options.AddArguments("--disable-extensions");
                    options.AddArguments("-ignore-certificate-errors");
                    //options.AddArguments("start-maximized");
                    options.AddArgument("test-type");
                    options.AddArguments("disable-infobars");
                    options.ToCapabilities();
                    options.AddArguments("no-sandbox");
                    //capabilities.SetCapability("chrome.binary", @"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe");
                    //capabilities.SetCapability(ChromeOptions.Capability, options);
                    var chromeDriver = new ChromeDriver(options);
                    chromeDriver.Manage().Window.Position = new Point(0, 0);
                    chromeDriver.Manage().Window.Size = new Size(2200, 1200);
                    return chromeDriver;
                case "firefox":
                    System.Environment.SetEnvironmentVariable("webdriver.gecko.driver", "geckodriver.exe");
                    var driver = new FirefoxDriver();
                    //driver.Manage().Window.Position = new Point(0, 0);
                    //driver.Manage().Window.Size = new Size(2000, 1000);
                    return driver;
                case "ie":
                    System.Environment.SetEnvironmentVariable("webdriver.ie.driver", "IEDriverServer.exe");
                    return new InternetExplorerDriver();
                case "phantomjs":
                    System.Environment.SetEnvironmentVariable("phantomjs.binary.path", "phantomjs.exe");
                    return new PhantomJSDriver();
                case "safari":
                    return new SafariDriver();
                case "edge":
                    System.Environment.SetEnvironmentVariable("webdriver.edge.driver", "MicrosoftWebDriver.exe");
                    return new EdgeDriver();
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

        ~BaseTestWithoutLogin()
        {
            Dispose(false);
        }
    }
}
