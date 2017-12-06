/*==============================================================================================================================
 File Name    : DriverExtender.cs
 ClassName    : DriverExtender
 Summary      : Contains webdriver customize functions.
 ===============================================================================================================================
 History      :   Company            Date            Action              Author
                  360logica                         Initial Version      Ammar

 ===============================================================================================================================
 Remarks      :   Tests - 
 ===============================================================================================================================*/

using OpenQA.Selenium;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.ObjectModel;
using log4net;
using System.Reflection;
using System.Diagnostics;
using OpenQA.Selenium.Interactions;
using System.Collections.Generic;
using System.Configuration;


namespace RallyTeam.Util
{
    static class DriverExtender
    {
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private static int timeout;
        public static string _browser = ConfigurationSettings.AppSettings["Browser"].ToLower();

        public static void setTimeOut(this IWebDriver driver, int timeOutValue)
        {
            timeout = timeOutValue;
        }

        public static string GetMethod(this By locator)
        {
            int methodStartIndex = locator.ToString().IndexOf("By.") + 3;
            int methodLength = locator.ToString().IndexOf(":") - methodStartIndex;
            return locator.ToString().Substring(methodStartIndex, methodLength);
        }

        public static string GetSelector(this By locator)
        {
            int selectorStartIndex = locator.ToString().IndexOf(": ") + 2;
            return locator.ToString().Substring(selectorStartIndex);
        }

        public static void switchFrameById(this IWebDriver driver, String locator)
        {
            DefaultWait<IWebDriver> wait = new DefaultWait<IWebDriver>(driver);
            wait.Until(ExpectedConditions.ElementIsVisible((By.Id(locator))));
            driver.SwitchTo().Frame(locator);
        }       

        //Attempts to select a drop-down value and throws exception if the element is unable to select option before timing out
        public static void SelectDropDownOption(this IWebDriver _driver, String option, By locator)
        {        
            DefaultWait<IWebDriver> wait = new DefaultWait<IWebDriver>(_driver);
            wait.Timeout = TimeSpan.FromSeconds(timeout);
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            try
            {
                /*if (_browser == "ie")
                {
                    IWebElement select = _driver.FindElement(locator);
                    IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
                    js.ExecuteScript("var select = arguments[0]; for (var i = 0; i < select.options.length; i++) { if (select.options[i].text == arguments[1]) { select.options[i].selected = true; } }", select, "Completed");
                }
                else
                {*/
                    new SelectElement(_driver.FindElement(locator)).SelectByText(option);
                //}
            }
            catch (Exception error)
            {
                //String error = "Element with locator:" + locator.ToString() + " is not clickable.";
                String e = error.ToString();
                Log.Error(e);
                throw new Exception(e);
            }
        }

        //Verifies the drop-down option before trying to select the same
        public static void VerifyDropDownOption(this IWebDriver _driver, By locator)
        {                       
            try
            {
                WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(20));
                wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(locator));            
            }
            catch (Exception error)
            {
                //String error = "Element with locator:" + locator.ToString() + " is not clickable.";
                String e = error.ToString();
                Log.Error(e);
                throw new Exception(e);
            }
        }

        //Move to particular element using Action Class
        public static void RightClickElementUsingAction(this IWebDriver _driver, By locator)
        {
            //IWebElement element = _driver.FindElement(locator);
            Actions action = new Actions(_driver).ContextClick(_driver.FindElement(locator));
            action.Build().Perform();
        }

        //Move to particular element using Action Class
        public static void MoveToElementUsingAction(this IWebDriver _driver, By locator)
        {
            //IWebElement element = _driver.FindElement(locator);
            Actions action = new Actions(_driver);
            action.MoveToElement(_driver.FindElement(locator)).Build().Perform();
        }

        //Click a particular element using Action Class
        public static void ClickElementUsingAction(this IWebDriver _driver, By locator)
        {
            IWebElement element = _driver.FindElement(locator);
            if (element != null)
            {
                Actions action = new Actions(_driver);
                action.MoveToElement(element).Click().Perform();
            }
        }

        //Drag and drop a particular element using Action Class
        public static void DragAndDropElementUsingAction(this IWebDriver _driver, By sourcelocator, By destinationLocator)
        {
            IWebElement sourceElement = _driver.FindElement(sourcelocator);
            IWebElement destinationElement = _driver.FindElement(destinationLocator);
            Actions action = new Actions(_driver);
            action.DragAndDrop(sourceElement, destinationElement).Build().Perform();
        }

        //Pressing enter key using Action Class
        public static void PressKeyBoardEnter(this IWebDriver _driver)
        {
            Actions action = new Actions(_driver);
            action.SendKeys(OpenQA.Selenium.Keys.Enter).Build().Perform();
        }

        //Pressing Tab key using Action Class
        public static void PressKeyBoardTab(this IWebDriver _driver)
        {
            Actions action = new Actions(_driver);
            action.SendKeys(OpenQA.Selenium.Keys.Tab).Build().Perform();
        }

        //Pressing Down Arrow key using Action Class
        public static void PressKeyBoardDownArrow(this IWebDriver _driver)
        {
            Actions action = new Actions(_driver);
            action.SendKeys(OpenQA.Selenium.Keys.ArrowDown).Build().Perform();
        }

        //Attempts to find an element until the timeout is reached and only throws an exception if the element is not visible before timing out.
        public static IWebElement SafeFindElement(this IWebDriver driver, By locator,int timeout=120)
        {
            DefaultWait<IWebDriver> wait = new DefaultWait<IWebDriver>(driver);
            wait.Timeout = TimeSpan.FromSeconds(timeout);
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            try
            {
                return wait.Until<IWebElement>(ExpectedConditionsExtender.ElementIsVisible(locator));
            }
            catch (WebDriverTimeoutException)
            {
                String error = "Unable to locate element: {\"method\":\"" + locator.GetMethod() + "\",\"selector\":\"" + locator.GetSelector() + "\"}";

                // Get stackframe with index of 3 to get the calling method from stacktrace
                // We look for 3rd index because we want to ignore this exception when being called from FlexibleClick()
                // Flows from DriverHelper.FlexibleClick (3) -> Wait.Until (2) -> ExpectedConditionsExtender.ElementClicked (1) -> SafeFindElement (0)
                string methodName = new StackFrame(3).GetMethod().Name;

                // If we are not calling from FlexibleClick, take the screenshot and log the error
                if (methodName != "FlexibleClick")
                {
                    UtilityHelper.TakeScreenshot(driver);
                    Log.Error(error);
                }
                // otherwise, do not take a screenshot and log the error
                else
                {
                    Log.Info("WebDriverTimeoutException ignored from FlexibleClick");
                    Log.Error(error);
                }

                throw new NoSuchElementException(error);
            }
        }

        //Attempts to find an element but does not throw an exception if the element can not be found.
        public static IWebElement FindElementFlexible(this IWebDriver driver, By locator,int timeout=120)
        {
            DefaultWait<IWebDriver> wait = new DefaultWait<IWebDriver>(driver);
            wait.Timeout = TimeSpan.FromSeconds(timeout);
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            try
            {
                return wait.Until<IWebElement>(ExpectedConditionsExtender.ElementIsVisible(locator));
            }
            catch (WebDriverTimeoutException)
            {
                return null;
            }
        }


        //Attempts to find an element text but does not throw an exception if the element can not be found.
        public static String GetElementText(this IWebDriver driver, By locator)
        {
            DefaultWait<IWebDriver> wait = new DefaultWait<IWebDriver>(driver);
            wait.Timeout = TimeSpan.FromSeconds(timeout);
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            try
            {
                return wait.Until<IWebElement>(ExpectedConditionsExtender.ElementIsVisible(locator)).Text;                
            }
            catch (Exception error)
            {
                String e = error.ToString();
                Log.Error(e);
                throw new Exception(e);
            }
        }

        //Attempts to find an element but does not throw an exception if the element can not be found.
        public static String GetElementAttributeValue(this IWebDriver driver, By locator, String attribute)
        {
            DefaultWait<IWebDriver> wait = new DefaultWait<IWebDriver>(driver);
            wait.Timeout = TimeSpan.FromSeconds(timeout);
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            try
            {
                return wait.Until<IWebElement>(ExpectedConditionsExtender.ElementIsVisible(locator)).GetAttribute(attribute);
            }
            catch (Exception error)
            {
                String e = error.ToString();
                Log.Error(e);
                throw new Exception(e); 
            }
        }


        //Attempts to find an element with the specified text until the timeout is reached and only throws an exception if the element
        //containing the designated text is not visible before timing out.
        public static IWebElement SafeFindElementByText(this IWebDriver driver, string text)
        {
            try
            {
                return driver.SafeFindDescendantElementByText(By.TagName("html"), By.XPath("//*"), text);
            }
            catch (NoSuchElementException)
            {
                String error = "Unable to locate element: {\"method\":\"Text\",\"selector\":\"" + text + "\"}";
                Log.Error(error);
                throw new NoSuchElementException(error);
            }
        }

        //Attempts to find an element with the specified locator and text until the timeout is reached and only throws an exception if an element
        //containing the designated text is not visible before timing out.
        public static IWebElement SafeFindElementByText(this IWebDriver driver, By locator, string text)
        {
            try
            {
                return driver.SafeFindDescendantElementByText(By.TagName("html"), locator, text);
            }
            catch (NoSuchElementException)
            {
                String error = "Unable to locate element: {\"method\":\"" + locator.GetMethod() + "\",\"selector\":\"" + locator.GetSelector() + "\",\"text\":\"" + text + "\"}";
                Log.Error(error);
                throw new NoSuchElementException(error);
            }
        }

        //Attempts to find an element by its text but does not throw an exception if the element cannot be found
        public static IWebElement FindElementByTextFlexible(this IWebDriver driver, string text)
        {
            try
            {
                return driver.SafeFindDescendantElementByText(By.TagName("html"), By.XPath("//*"), text);
            }
            catch (NoSuchElementException)
            {
                return null;
            }
        }

        //Attempts to find an element by its text and locator but does not throw an exception if the element cannot be found
        public static IWebElement FindElementByTextFlexible(this IWebDriver driver, By locator, string text)
        {
            DefaultWait<IWebDriver> wait = new DefaultWait<IWebDriver>(driver);
            wait.Timeout = TimeSpan.FromSeconds(timeout);
            try
            {
                return driver.SafeFindDescendantElementByText(By.TagName("html"), locator, text);
            }
            catch (NoSuchElementException)
            {
                return null;
            }
        }

        //Attempts to find an element by its text in a descendant line from a parent element and throws an exception if the element is not visible before timing out.
        public static IWebElement SafeFindDescendantElementByText(this IWebDriver driver, By ancestorLocator, By descendantLocator, string text)
        {
            DefaultWait<IWebDriver> wait = new DefaultWait<IWebDriver>(driver);
            wait.Timeout = TimeSpan.FromSeconds(timeout);
            try
            {
                return wait.Until<IWebElement>(ExpectedConditionsExtender.DescendantElementByTextIsVisible(ancestorLocator, descendantLocator, text, timeout));
            }
            catch (WebDriverTimeoutException)
            {
                String error = "Unable to locate element: {\"ancestorMethod\":\"" + ancestorLocator.GetMethod() + "\",\"ancestorSelector\":\"" + ancestorLocator.GetSelector() + "\",\"descendantMethod\":\"" + descendantLocator.GetMethod() + "\",\"descendantSelector\":\"" + descendantLocator.GetSelector() + "\",\"text\":\"" + text + "\"}";
                Log.Error(error);
                throw new NoSuchElementException(error);
            }
        }

        //Attempts to find an element (which can only be found relative to a known element) until the timeout is reached and only throws an exception if the
        //element is not visible before timing out.
        public static IWebElement SafeFindRelativeElement(this IWebDriver driver, By knownElementLocator, By relativeLocator, int timeout)
        {
            DefaultWait<IWebDriver> wait = new DefaultWait<IWebDriver>(driver);
            wait.Timeout = TimeSpan.FromSeconds(timeout);
            try
            {
                return wait.Until<IWebElement>(ExpectedConditionsExtender.RelativeElementIsVisible(knownElementLocator, relativeLocator, timeout));
            }
            catch (WebDriverTimeoutException)
            {
                String error = "Unable to locate element: {\"knownElementMethod\":\"" + knownElementLocator.GetMethod() + "\",\"knownElementSelector\":\"" + knownElementLocator.GetSelector() + "\",\"relativeMethod\":\"" + relativeLocator.GetMethod() + "\",\"relativeSelector\":\"" + relativeLocator.GetSelector() + "\"}";
                Log.Error(error);
                throw new NoSuchElementException(error);
            }
        }

        //Attempts to find an element (which can only be found relative to a known element that has been found using its locator and text).
        public static IWebElement SafeFindElementRelativeToElementByText(this IWebDriver driver, By knownElementLocator, string knownElementText, By relativeLocator, int timeout)
        {
            DefaultWait<IWebDriver> wait = new DefaultWait<IWebDriver>(driver);
            wait.Timeout = TimeSpan.FromSeconds(timeout);
            try
            {
                return wait.Until<IWebElement>(ExpectedConditionsExtender.ElementRelativeToElementByTextIsVisible(knownElementLocator, knownElementText, relativeLocator, timeout));
            }
            catch (WebDriverTimeoutException)
            {
                String error = "Unable to locate element: {\"knownElementMethod\":\"" + knownElementLocator.GetMethod() + "\",\"knownElementSelector\":\"" + knownElementLocator.GetSelector() + "\",\"knownElementText\":\"" + knownElementText + "\",\"relativeMethod\":\"" + relativeLocator.GetMethod() + "\",\"relativeSelector\":\"" + relativeLocator.GetSelector() + "\"}";
                Log.Error(error);
                throw new NoSuchElementException(error);
            }
        }

        //Attempts to find an element with the specified locator regardless of its visibility.
        public static IWebElement SafeFindHiddenElement(this IWebDriver driver, By locator)
        {
            DefaultWait<IWebDriver> wait = new DefaultWait<IWebDriver>(driver);
            wait.Timeout = TimeSpan.FromSeconds(timeout);
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            try
            {
                return wait.Until<IWebElement>(ExpectedConditionsExtender.ElementExists(locator));
            }
            catch (WebDriverTimeoutException)
            {
                String error = "Unable to locate hidden element: {\"method\":\"" + locator.GetMethod() + "\",\"selector\":\"" + locator.GetSelector() + "\"}";
                Log.Error(error);
                throw new NoSuchElementException(error);
            }
        }

       

        //Attempts to enter text into an element until the timeout is reached and only throws an exception if the element is unable to be used before timing out.
        public static void SafeEnterText(this IWebDriver driver, By locator, string text)
        {
            DefaultWait<IWebDriver> wait = new DefaultWait<IWebDriver>(driver);
            wait.Timeout = TimeSpan.FromSeconds(timeout);
            try
            {
                wait.Until<bool>(ExpectedConditionsExtender.TextEnteredInElement(locator, text, timeout));
            }
            catch (WebDriverTimeoutException)
            {
                String error = "Unable to send text to element: {\"method\":\"" + locator.GetMethod() + "\",\"selector\":\"" + locator.GetSelector() + "\"}";
                Log.Error(error);
                throw new Exception(error);
            }
        }   


        public static void SafeAppendText(this IWebDriver driver, By locator, string text)
        {
            DefaultWait<IWebDriver> wait = new DefaultWait<IWebDriver>(driver);
            wait.Timeout = TimeSpan.FromSeconds(timeout);
            try
            {
                wait.Until<bool>(ExpectedConditionsExtender.TextAppendInElement(locator, text, timeout));
            }
            catch (WebDriverTimeoutException)
            {
                String error = "Unable to send text to element: {\"method\":\"" + locator.GetMethod() + "\",\"selector\":\"" + locator.GetSelector() + "\"}";
                Log.Error(error);
                throw new Exception(error);


            }
        }

        //Attempts to enter text into an element until the timeout is reached and only throws an exception if the element is unable to be used before timing out.
        public static void EnterTextByKeyPress(this IWebDriver driver, By locator, string text)
        {
            DefaultWait<IWebDriver> wait = new DefaultWait<IWebDriver>(driver);
            wait.Timeout = TimeSpan.FromSeconds(timeout);
            try
            {
                wait.Until<bool>(ExpectedConditionsExtender.TextEnteredInElement(locator, text, timeout));

                driver.FindElement(locator).SendKeys(Keys.NumberPad2);

            }
            catch (WebDriverTimeoutException)
            {
                String error = "Unable to send text to element: {\"method\":\"" + locator.GetMethod() + "\",\"selector\":\"" + locator.GetSelector() + "\"}";
                Log.Error(error);
                throw new Exception(error);
            }
        }

        //Enter text using Action class
        public static void EnterTextUsingAction(this IWebDriver driver, By locator, string text)
        {
            IWebElement element = driver.FindElement(locator);
            Actions action = new Actions(driver);
            Actions seriesOfActions = action.MoveToElement(element).Click().SendKeys(element, text);
            seriesOfActions.Perform();
        }

        //Enter text using Action class
        public static void Test(this IWebDriver driver, By locator, string text)
        {
            IWebElement element = driver.FindElement(locator);
            Actions action = new Actions(driver);
            action.SendKeys(text).Perform();
        }

        //Scroll to element using JS
        public static void ScrollWindowToElement(this IWebDriver driver, By locator)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true);", driver.FindElement(locator));
        }

        //Enter text using JS
        public static void EnterTextUsingJS(this IWebDriver driver, By locator, string text)
        {
            IWebElement element = driver.FindElement(locator);
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            //js.ExecuteScript("document."+ driver.FindElement(locator) + ".value = 'R';");
            
            js.ExecuteScript("arguments[0].value= '"+ text + "';", driver.FindElement(locator));
        }

        //Attempts to enter text into an element until the timeout is reached and only throws an exception if the element is unable to be used before timing out.
        public static void SafePressEnterKey(this IWebDriver driver, By locator)
        {
            DefaultWait<IWebDriver> wait = new DefaultWait<IWebDriver>(driver);
            wait.Timeout = TimeSpan.FromSeconds(timeout);
            try
            {
                wait.Until<bool>(ExpectedConditionsExtender.KeyEnterInElement(locator, timeout));
            }
            catch (WebDriverTimeoutException)
            {
                String error = "Unable to send text to element: {\"method\":\"" + locator.GetMethod() + "\",\"selector\":\"" + locator.GetSelector() + "\"}";
                Log.Error(error);
                throw new Exception(error);
            }
        }

        //Attempts to click an element until the timeout is reached and only throws an exception if the element is unable to be clicked before timing out
        public static void SafeClick(this IWebDriver driver, By locator)
        {
            DefaultWait<IWebDriver> wait = new DefaultWait<IWebDriver>(driver);
            wait.Timeout = TimeSpan.FromSeconds(timeout);
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            try
            {
                wait.Until<IWebElement>(ExpectedConditionsExtender.ElementIsVisible(locator));
                wait.Until<bool>(ExpectedConditionsExtender.ElementClicked(locator, timeout));
            }
            catch (Exception error)
            {
                //String error = "Element with locator:" + locator.ToString() + " is not clickable.";
                String e = error.ToString();
                Log.Error(e);
                throw new Exception(e);
            }
            DriverExtender._waitForJStoLoad(driver);
        }

        //Attempts to click an element until the timeout is reached and only throws an exception if the element is unable to be clicked before timing out
        public static void ClickUsingSendKeys(this IWebDriver driver, By locator)
        {
            DefaultWait<IWebDriver> wait = new DefaultWait<IWebDriver>(driver);
            wait.Timeout = TimeSpan.FromSeconds(timeout);
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            try
            {
                driver.FindElement(locator).SendKeys(Keys.Enter);
            }
            catch (Exception error)
            {
                
            }
            DriverExtender._waitForJStoLoad(driver);
        }


        //Attempts to find an element by its text in a descendant line from a parent element and throws an exception if the element is not visible before timing out.
        public static bool SafeClickDescendantElementByText(this IWebDriver driver, By ancestorLocator, By descendantLocator, string text)
        {
            DefaultWait<IWebDriver> wait = new DefaultWait<IWebDriver>(driver);
            wait.Timeout = TimeSpan.FromSeconds(timeout);
            try
            {
                return wait.Until<bool>(ExpectedConditionsExtender.DescendantElementByTextClicked(ancestorLocator, descendantLocator, text, timeout));
            }
            catch (WebDriverTimeoutException)
            {
                String error = "Unable to locate element: {\"ancestorMethod\":\"" + ancestorLocator.GetMethod() + "\",\"ancestorSelector\":\"" + ancestorLocator.GetSelector() + "\",\"descendantMethod\":\"" + descendantLocator.GetMethod() + "\",\"descendantSelector\":\"" + descendantLocator.GetSelector() + "\",\"text\":\"" + text + "\"}";
                Log.Error(error);
                throw new NoSuchElementException(error);
            }
        }

        //Attempts to click an element (which can only be found relative to a known element) until the timeout is reached and only throws an exception if the
        //element is unable to be clicked before timing out.
        public static void SafeClickRelativeElement(this IWebDriver driver, By knownElementLocator, By relativeLocator)
        {
            DefaultWait<IWebDriver> wait = new DefaultWait<IWebDriver>(driver);
            wait.Timeout = TimeSpan.FromSeconds(timeout);
            wait.Until<bool>(ExpectedConditionsExtender.RelativeElementClicked(knownElementLocator, relativeLocator, timeout));
        }

        //Attempts to click an element (which can only be found relative to a known element that has been located based on its text and locator).
        public static void SafeClickElementRelativeToElementByText(this IWebDriver driver, By knownElementLocator, string knownElementText, By relativeLocator)
        {
            DefaultWait<IWebDriver> wait = new DefaultWait<IWebDriver>(driver);
            wait.Timeout = TimeSpan.FromSeconds(timeout);
            wait.Until<bool>(ExpectedConditionsExtender.ElementRelativeToElementByTextClicked(knownElementLocator, knownElementText, relativeLocator, timeout));
        }

        //Attempts to mouse over an element and throws an exception if it can not be moused over before timing out.
        public static void MouseOver(this IWebDriver driver, By locator)
        {
            DefaultWait<IWebDriver> wait = new DefaultWait<IWebDriver>(driver);
            wait.Timeout = TimeSpan.FromSeconds(timeout);
            wait.Until<bool>(ExpectedConditionsExtender.ElementMousedOver(locator, timeout));
        }

        //Attemps to click an element but does not throw an exception if the element can not be clicked.
        public static void FlexibleClick(this IWebDriver driver, By locator)
        {
            DefaultWait<IWebDriver> wait = new DefaultWait<IWebDriver>(driver);
            wait.Timeout = TimeSpan.FromSeconds(timeout);
            try
            {
                wait.Until<bool>(ExpectedConditionsExtender.ElementClicked(locator, timeout));
            }
            catch
            {

            }
        }

        //Finds a hidden element and waits for the text of that element to be the specified value.
        public static void WaitForElementText(this IWebDriver driver, By locator, string text)
        {
            DefaultWait<IWebDriver> wait = new DefaultWait<IWebDriver>(driver);
            wait.Timeout = TimeSpan.FromSeconds(timeout);
            try
            {
                wait.Until<bool>(ExpectedConditionsExtender.ElementTextIs(locator, text, timeout));
            }
            catch (WebDriverTimeoutException)
            {
                String error = "Element text did not become expected value before timing out: {\"method\":\"" + locator.GetMethod() + "\",\"selector\":\"" + locator.GetSelector() + "\",\"expectedValue\":\"" + text + "\"}";
                Log.Error(error);
                throw new WebDriverTimeoutException(error);
            }
        }

        //Finds a hidden element and waits for the element visible
        public static IWebElement WaitForElementVisible(this IWebDriver driver, By locator)
        {
            DriverExtender._waitForJStoLoad(driver);

            DefaultWait<IWebDriver> wait = new DefaultWait<IWebDriver>(driver);
            wait.Timeout = TimeSpan.FromSeconds(timeout);
            try
            {
                return wait.Until<IWebElement>(ExpectedConditionsExtender.ElementIsVisible(locator));
            }
            catch (WebDriverTimeoutException)
            {
                String error = "Element text did not become expected value before timing out: {\"method\":\"" + locator.GetMethod() + "\",\"selector\":\"" + locator.GetSelector() + "\",\"expectedValue:\"}";
                Log.Error(error);
                throw new WebDriverTimeoutException(error);
            }
        }

        //Finds a hidden element and waits for the text of that element to be the specified value.
        public static void WaitForHiddenElementText(this IWebDriver driver, By locator, string text)
        {
            DefaultWait<IWebDriver> wait = new DefaultWait<IWebDriver>(driver);
            wait.Timeout = TimeSpan.FromSeconds(timeout);
            try
            {
                wait.Until<bool>(ExpectedConditionsExtender.HiddenElementTextIs(locator, text, timeout));
            }
            catch (WebDriverTimeoutException)
            {
                throw new WebDriverTimeoutException("Hidden element text did not become expected value before timing out: {\"method\":\"" + locator.GetMethod() + "\",\"selector\":\"" + locator.GetSelector() + "\",\"expectedValue\":\"" + text + "\"}");
            }
        }

        //Finds a hidden element and waits for the text of that element to not be the specified value.
        public static void WaitForHiddenElementTextNot(this IWebDriver driver, By locator, string text)
        {
            DefaultWait<IWebDriver> wait = new DefaultWait<IWebDriver>(driver);
            wait.Timeout = TimeSpan.FromSeconds(timeout);
            try
            {
                wait.Until<bool>(ExpectedConditionsExtender.HiddenElementTextIsNot(locator, text, timeout));
            }
            catch (WebDriverTimeoutException)
            {
                String error = "Hidden element text did not change from expected value before timing out: {\"method\":\"" + locator.GetMethod() + "\",\"selector\":\"" + locator.GetSelector() + "\",\"expectedValue\":\"" + text + "\"}";
                Log.Error(error);
                throw new WebDriverTimeoutException(error);
            }
        }

        //Finds an element and waits for the text of that element to contain the specified value.
        public static void WaitForElementTextToContain(this IWebDriver driver, By locator, string text)
        {
            DefaultWait<IWebDriver> wait = new DefaultWait<IWebDriver>(driver);
            wait.Timeout = TimeSpan.FromSeconds(timeout);
            try
            {
                wait.Until<bool>(ExpectedConditionsExtender.ElementTextContains(locator, text, timeout));
            }
            catch (WebDriverTimeoutException)
            {
                String error = "Hidden element text did not contain expected value before timing out: {\"method\":\"" + locator.GetMethod() + "\",\"selector\":\"" + locator.GetSelector() + "\",\"expectedValue\":\"" + text + "\"}";
                Log.Error(error);
                throw new WebDriverTimeoutException(error);
            }
        }

        //Finds a hidden element and waits for the text of that element to contain the specified value.
        public static void WaitForHiddenElementTextToContain(this IWebDriver driver, By locator, string text)
        {
            DefaultWait<IWebDriver> wait = new DefaultWait<IWebDriver>(driver);
            wait.Timeout = TimeSpan.FromSeconds(timeout);
            try
            {
                wait.Until<bool>(ExpectedConditionsExtender.HiddenElementTextContains(locator, text, timeout));
            }
            catch (WebDriverTimeoutException)
            {
                String error = "Hidden element text did not contain expected value before timing out: {\"method\":\"" + locator.GetMethod() + "\",\"selector\":\"" + locator.GetSelector() + "\",\"expectedValue\":\"" + text + "\"}";
                Log.Error(error);
                throw new WebDriverTimeoutException(error);
            }
        }

        //Gets the text value of a hidden element using the locator.
        public static string GetHiddenElementText(this IWebDriver driver, By locator)
        {
            return ((IJavaScriptExecutor)driver).ExecuteScript("return arguments[0].innerHTML", driver.SafeFindHiddenElement(locator)).ToString();
        }

        //Clicks Element using Javascript
        public static void ClickElementUsingJS(this IWebDriver driver, By locator)
        {            
            DefaultWait<IWebDriver> wait = new DefaultWait<IWebDriver>(driver);
            wait.Timeout = TimeSpan.FromSeconds(timeout);
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            try
            {
                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                js.ExecuteScript("arguments[0].scrollIntoView(true);", driver.FindElement(locator));
                js.ExecuteScript("arguments[0].click();", driver.FindElement(locator));                
            }
            catch (Exception error)
            {

            }
            DriverExtender._waitForJStoLoad(driver);
        }

        //Clicks Element using Javascript
        public static void FocusAndBlurUsingJS(this IWebDriver driver, By locator)
        {
            DefaultWait<IWebDriver> wait = new DefaultWait<IWebDriver>(driver);
            wait.Timeout = TimeSpan.FromSeconds(timeout);
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            try
            {
                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                js.ExecuteScript("arguments[0].focus(); arguments[0].blur(); return true", driver.FindElement(locator));
            }
            catch (Exception error)
            {

            }
            DriverExtender._waitForJStoLoad(driver);
        }



        //Gets the text value of a hidden element using an already found element.
        public static string GetHiddenElementText(this IWebDriver driver, IWebElement element)
        {
            return ((IJavaScriptExecutor)driver).ExecuteScript("return arguments[0].innerHTML", element).ToString();
        }

        public static void SwitchToMostRecentWindow(this IWebDriver driver)
        {
            driver.SwitchTo().Window(driver.WindowHandles[driver.WindowHandles.Count - 1]);
        }

        public static void SwitchToOriginalWindow(this IWebDriver driver)
        {
            driver.SwitchTo().Window(driver.WindowHandles[0]);
        }

        public static ReadOnlyCollection<IWebElement> SafeFindElements(this IWebDriver driver, By locator)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            try
            {
                return wait.Until<ReadOnlyCollection<IWebElement>>(ExpectedConditionsExtender.ElementsExist(locator));
            }
            catch (WebDriverTimeoutException)
            {
                //Assert.Fail(locator.ToString() + " not found within " + timeout + " seconds.");
                return null;
            }
        }

        //Attempts to click an element until the timeout is reached and only throws an exception if the element is unable to be clicked before timing out
        public static void SafeSelectDropDownText(this IWebDriver driver, By locator, string value)
        {
            DefaultWait<IWebDriver> wait = new DefaultWait<IWebDriver>(driver);
            wait.Timeout = TimeSpan.FromSeconds(timeout);
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            try
            {


                new SelectElement(driver.FindElement(locator)).SelectByText(value);
            }
            catch (WebDriverTimeoutException)
            {
                String error = "Element with locator:" + locator.ToString() + " is not dropdown.";
                Log.Error(error);
                throw new InvalidElementStateException(error);
            }
        }

        //Wait for Loading
        public static void WaitForLoading(this IWebDriver driver, By locator, string value)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            try
            {
                wait.Until(ExpectedConditions.InvisibilityOfElementWithText(locator, value));
            }
            catch (WebDriverTimeoutException)
            {
                String error = "Element text did not become expected value before timing out: {\"method\":\"" + locator.GetMethod() + "\",\"selector\":\"" + locator.GetSelector() + "\",\"expectedValue\":\"" + value + "\"}";
                Log.Error(error);
                throw new WebDriverTimeoutException(error);
            }
        }


        public static void ScrollWindow(this IWebDriver driver, By locator)
        {
            IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;
            IWebElement element = driver.FindElement(locator);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView();", element);
        }

        //Get Tooltip value
        public static string GetTooltipValue(this IWebDriver driver, By locator)
        {
            DefaultWait<IWebDriver> wait = new DefaultWait<IWebDriver>(driver);
            wait.Timeout = TimeSpan.FromSeconds(timeout);
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            try
            {
                Actions action = new Actions(driver);
                action.MoveToElement(driver.FindElement(locator)).Build().Perform();
                String tooltipText = driver.FindElement(locator).GetAttribute("title");
                return tooltipText;
            }
            catch (WebDriverTimeoutException)
            {
                String error = "Element with locator:" + locator.ToString() + " is not dropdown.";
                Log.Error(error);
                throw new InvalidElementStateException(error);
            }
        }

        //Get User Name through ToolTip value
        public static string GetUserNameTooltipValue(this IWebDriver driver, By locator)
        {
            DefaultWait<IWebDriver> wait = new DefaultWait<IWebDriver>(driver);
            wait.Timeout = TimeSpan.FromSeconds(timeout);
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            try
            {
                Actions action = new Actions(driver);
                action.MoveToElement(driver.FindElement(locator)).Build().Perform();
                String tooltipText = driver.FindElement(locator).GetAttribute("tooltip");
                return tooltipText;
            }
            catch (WebDriverTimeoutException)
            {
                String error = "Element with locator:" + locator.ToString() + " is not dropdown.";
                Log.Error(error);
                throw new InvalidElementStateException(error);
            }
        }

        private static Boolean _waitForJStoLoad(this IWebDriver driver)
        {
            IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;

            //while (true)
            //{
            //    try
            //    {
            //        if ((long)jse.ExecuteScript("return jQuery.active") == 0)
            //            return true;
            //    }
            //    catch (Exception) { }
            //}


            while (true)
            {
                try
                {
                    Object rsltJs = jse.ExecuteScript("return document.readyState");
                    if (rsltJs == null)
                    {
                        rsltJs = "";
                    }
                    if (rsltJs.ToString().Equals("complete") || rsltJs.ToString().Equals("loaded"))
                        return true;
                }
                catch (Exception) { }
            }
        }

        //Finds a hidden element and waits for the element visible
        public static void WaitForElementAvailableAtDOM(this IWebDriver driver, By locator, int maxTime)
        {
            

            DefaultWait<IWebDriver> wait = new DefaultWait<IWebDriver>(driver);
            wait.Timeout = TimeSpan.FromSeconds(timeout);
            try
            {
                ExpectedConditionsExtender.ElementIsVisibleAtDom(locator, maxTime);
            }
            catch (WebDriverTimeoutException)
            {
                String error = "Element text did not become expected value before timing out: {\"method\":\"" + locator.GetMethod() + "\",\"selector\":\"" + locator.GetSelector() + "\",\"expectedValue:\"}";
                Log.Error(error);
                throw new WebDriverTimeoutException(error);
            }
        }

        //Finds a hidden element and waits for the element visible
        public static void WaitForElementVisibility(this IWebDriver driver, By locator)
        {


            DefaultWait<IWebDriver> wait = new DefaultWait<IWebDriver>(driver);
            wait.Timeout = TimeSpan.FromSeconds(timeout);
            try
            {
                ExpectedConditionsExtender.CheckElementVisibility(driver, locator);
            }
            catch (WebDriverTimeoutException)
            {
                String error = "Element was not visible : {\"method\":\"" + locator.GetMethod() + "\",\"selector\":\"" + locator.GetSelector() + "\",\"expectedValue:\"}";
                Log.Error(error);
                throw new WebDriverTimeoutException(error);
            }
        }
    }
}
