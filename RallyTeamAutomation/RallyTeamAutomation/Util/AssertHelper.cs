/*==============================================================================================================================
 File Name    : AssertHelper.cs
 ClassName    : AssertHelper
 Summary      : Contains Assertion functions.
 ===============================================================================================================================
 History      :   Company            Date            Action              Author
                  360logica                         Initial Version      Ammar

 ===============================================================================================================================
 Remarks      :   Tests - 
 ===============================================================================================================================*/
using log4net;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RallyTeam.Util
{
    public class AssertHelper
    {
        private IWebDriver _driver;
        public int PageLoadTimeout { get; set; }
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public AssertHelper(IWebDriver driver, int pageLoadTimeout)
        {
            _driver = driver;
            PageLoadTimeout = pageLoadTimeout;
        }

        public void AssertFailTestCase()
        {
            Assert.Fail();
        }

        public void AssertTitleIs(string Title)
        {
            DefaultWait<IWebDriver> wait = new DefaultWait<IWebDriver>(_driver);
            try
            {
                wait.Until<bool>(ExpectedConditionsExtender.TitleIs(Title));
            }
            catch (WebDriverTimeoutException)
            {
                UtilityHelper.TakeScreenshot(_driver);
                String error = "Expected title to be \"" + Title + "\" but was \"" + _driver.Title + "\".";
                Log.Error(error);
                Assert.Fail(error);
            }
        }

        public void AssertDescendantElementByTextIsVisible(By ancestorLocator, By descendantLocator, string descendantText)
        {
            try
            {
                _driver.SafeFindDescendantElementByText(ancestorLocator, descendantLocator, descendantText);
            }
            catch (NoSuchElementException)
            {
                UtilityHelper.TakeScreenshot(_driver);
                String error = "Expected ancestor element (" + ancestorLocator.ToString() + ") to contain descendant element (" + descendantLocator.ToString() + ") with text \"" + descendantText + "\" but did not.";
                Log.Error(error);
                Assert.Fail(error);
            }
        }

        public void AssertElementTextIs(By locator, string text)
        {
            DefaultWait<IWebDriver> wait = new DefaultWait<IWebDriver>(_driver);
            wait.Timeout = TimeSpan.FromSeconds(PageLoadTimeout);
            try
            {
                _driver.WaitForElementText(locator, text);
            }
            catch (NoSuchElementException)
            {
                UtilityHelper.TakeScreenshot(_driver);
                String error = "Expected element (" + locator.ToString() + ") to exist but did not.";
                Log.Error(error);
                Assert.Fail(error);
            }
            catch (InvalidElementStateException)
            {
                UtilityHelper.TakeScreenshot(_driver);
                String error = "Expected element (" + locator.ToString() + ") to have text equal to \"" + text + "\" but did not.";
                Log.Error(error);
                Assert.Fail(error);
            }
        }

        public void AssertElementTextContains(By locator, string containedText)
        {
            DefaultWait<IWebDriver> wait = new DefaultWait<IWebDriver>(_driver);
            wait.Timeout = TimeSpan.FromSeconds(PageLoadTimeout);
            try
            {
                _driver.WaitForElementTextToContain(locator, containedText);
            }
            catch (NoSuchElementException)
            {
                UtilityHelper.TakeScreenshot(_driver);
                String error = "Expected element (" + locator.ToString() + ") to exist but did not.";
                Log.Error(error);
                Assert.Fail(error);
            }
            catch (InvalidElementStateException)
            {
                UtilityHelper.TakeScreenshot(_driver);
                String error = "Expected element (" + locator.ToString() + ") to have text containing \"" + containedText + "\" but did not.";
                Log.Error(error);
                Assert.Fail(error);
            }
        }

        public void AssertHiddenElementTextContains(By locator, string containedText)
        {
            DefaultWait<IWebDriver> wait = new DefaultWait<IWebDriver>(_driver);
            wait.Timeout = TimeSpan.FromSeconds(PageLoadTimeout);
            try
            {
                _driver.WaitForHiddenElementTextToContain(locator, containedText);
            }
            catch (NoSuchElementException)
            {
                UtilityHelper.TakeScreenshot(_driver);
                String error = "Expected hidden element (" + locator.ToString() + ") to exist but did not.";
                Log.Error(error);
                Assert.Fail(error);
            }
            catch (InvalidElementStateException)
            {
                UtilityHelper.TakeScreenshot(_driver);
                String error = "Expected hidden element (" + locator.ToString() + ") to have text containing \"" + containedText + "\" but did not.";
                Log.Error(error);
                Assert.Fail(error);
            }
        }

        //Verify an element present or not but does not throw exception if element not found
        public Boolean AssertElementDisplayedNoError(By locator)
        {
            DefaultWait<IWebDriver> wait = new DefaultWait<IWebDriver>(_driver);
            wait.Timeout = TimeSpan.FromSeconds(PageLoadTimeout);
            try
            {
                Assert.IsTrue(_driver.FindElementFlexible(locator).Displayed);
                return true;
            }
            catch (NoSuchElementException e)
            {
                return false;
            }            
            catch (Exception e)
            {
                return false;
            }
        }

        public void AssertElementDisplayed(By locator)
        {
            DefaultWait<IWebDriver> wait = new DefaultWait<IWebDriver>(_driver);
            wait.Timeout = TimeSpan.FromSeconds(PageLoadTimeout);
            try
            {
                Console.WriteLine("111");
                Assert.IsTrue(_driver.FindElementFlexible(locator).Displayed);
                Console.WriteLine("222");
            }
            catch (NoSuchElementException e)
            {
                UtilityHelper.TakeScreenshot(_driver);
                String error = "Expected element (" + locator.ToString() + ") to be present but did not.";
                Log.Error(error);
                Console.WriteLine("333");
                Console.WriteLine("Exception is: " + e.Message + e.StackTrace);
                Assert.Fail(error);
                Console.WriteLine("444");
            }
            catch (InvalidElementStateException e)
            {
                UtilityHelper.TakeScreenshot(_driver);
                String error = "Expected element (" + locator.ToString() + ") to be displayed but did not.";
                Log.Error(error);
                Console.WriteLine("555");
                Console.WriteLine("Exception is: " + e.Message + e.StackTrace);
                Assert.Fail(error);
                Console.WriteLine("666");
            }
            catch (AssertionException e)
            {
                UtilityHelper.TakeScreenshot(_driver);
                String error = "Expected element (" + locator.ToString() + ") to be displayed but did not.";
                Log.Error(error);
                Console.WriteLine("777");
                Console.WriteLine("Exception is: " + e.Message + e.StackTrace);
                Assert.Fail(error);
                Console.WriteLine("888");
            }    
            catch (Exception e)
            {
                UtilityHelper.TakeScreenshot(_driver);
                String error = "Expected element (" + locator.ToString() + ") to be displayed but did not.";
                Log.Error(error);
                Console.WriteLine("999");
                Console.WriteLine("Exception is: " + e.Message + e.StackTrace);
                Assert.Fail(error);
                Console.WriteLine("000");
            }        
        }

        public void AssertElementNotDisplayed(By locator)
        {
            DefaultWait<IWebDriver> wait = new DefaultWait<IWebDriver>(_driver);
            wait.Timeout = TimeSpan.FromSeconds(PageLoadTimeout);
            bool displayed = false;
            try
            {
                // Assert.IsTrue(_driver.FindElementFlexible(locator).Displayed);
                displayed = _driver.FindElementFlexible(locator).Displayed;
                if (displayed == true)
                {
                    Console.WriteLine("1displayed: " + displayed);
                    Assert.IsTrue(false, "displayed");
                }                
            }
            catch (Exception e)
            {                
                if (displayed == true)
                {
                    UtilityHelper.TakeScreenshot(_driver);
                    Assert.Fail();
                    //Console.WriteLine("Exception is: " + e.Message + e.StackTrace);
                    //throw new AssertionException("Expected element (" + locator.ToString() + ") should not be displayed but it did." + e.StackTrace);
                }
            }
        }

        public void AssertIntsEqual(int one, int two)
        {
            try
            {
                Assert.IsTrue(one == two);
            }
            catch (AssertionException)
            {
                UtilityHelper.TakeScreenshot(_driver);
                String error = "Expected object (" + one.ToString() + ") to equal (" + two.ToString() + ") but did not.";
                Log.Error(error);
                Assert.Fail(error);
            }
        }

        public void AssertGreater(int one, int two)
        {
            try
            {
                // Assert.Greater(one, two);
            }
            catch (AssertionException)
            {
                UtilityHelper.TakeScreenshot(_driver);
                String error = "Expected object (" + one.ToString() + ") to be greater than (" + two.ToString() + ") but is not.";
                Log.Error(error);
                Assert.Fail(error);
            }

        }

        public void AssertTimeStampFormat(By locator)
        {
            String transcriptTime = _driver.FindElement(locator).Text;

            Regex rFormatTest = new Regex("[0-9][0-9]:[0-9][0-9]:[0-9][0-9]");

            bool bFormatTest = rFormatTest.Match(transcriptTime).Success;

            try
            {
                Assert.IsTrue(bFormatTest);
            }
            catch (AssertionException)
            {
                UtilityHelper.TakeScreenshot(_driver);
                String error = "Expected timestamp (" + transcriptTime.ToString() + ") to be in valid format but was not.";
                Log.Error(error);
                Assert.Fail(error);
            }

        }

        public void AssertStringContains(String one, String two)
        {
            try
            {
                Assert.IsTrue(one.Contains(two));
            }
            catch (AssertionException)
            {
                UtilityHelper.TakeScreenshot(_driver);
                String error = "Expected string (" + one.ToString() + ") to contain (" + two.ToString() + ") but did not.";
                Log.Error(error);
                Assert.Fail(error);
            }
        }

        //Assert element is enabled
        public void AssertElementIsEnabled(By locator)
        {
            DefaultWait<IWebDriver> wait = new DefaultWait<IWebDriver>(_driver);
            wait.Timeout = TimeSpan.FromSeconds(PageLoadTimeout);
            try
            {
                Assert.IsTrue(_driver.FindElementFlexible(locator).Enabled);
            }
            catch (NoSuchElementException)
            {
                UtilityHelper.TakeScreenshot(_driver);
                String error = "Expected element (" + locator.ToString() + ") to be present but did not.";
                Log.Error(error);
                Assert.Fail(error);
            }
            catch (InvalidElementStateException)
            {
                UtilityHelper.TakeScreenshot(_driver);
                String error = "Expected element (" + locator.ToString() + ") to be enabled but did not.";
                Log.Error(error);
                Assert.Fail(error);
            }
            catch (AssertionException)
            {
                UtilityHelper.TakeScreenshot(_driver);
                String error = "Expected element (" + locator.ToString() + ") to be enabled but did not.";
                Log.Error(error);
                Assert.Fail(error);
            }
        }

        /*
        public void AssertElementTextDoesNotEqual(By locator, string text)
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(PageLoadTimeout));
            try
            {
                wait.Until<bool>(ExpectedConditionsExtender.ElementTextIsNot(locator, text));
            }
            catch (WebDriverTimeoutException)
            {
                Assert.Fail("Text in element [" + locator.ToString() + "] was equal to [" + text + "]");
            }
        }

        public void AssertHiddenElementTextEquals(By locator, string text)
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(PageLoadTimeout));
            try
            {
                wait.Until<bool>(ExpectedConditionsExtender.HiddenElementTextIs(locator, text));
            }
            catch (WebDriverTimeoutException)
            {
                Assert.Fail("Text in element [" + locator.ToString() + "] was not equal to [" + text + "]");
            }
        }

        public void AssertHiddenElementTextIsNot(By locator, string text)
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(PageLoadTimeout));
            try
            {
                wait.Until<bool>(ExpectedConditionsExtender.HiddenElementTextIsNot(locator, text));
            }
            catch (WebDriverTimeoutException)
            {
                Assert.Fail("Text in element [" + locator.ToString() + "] was equal to [" + text + "]");
            }
        }
        */
    }
}