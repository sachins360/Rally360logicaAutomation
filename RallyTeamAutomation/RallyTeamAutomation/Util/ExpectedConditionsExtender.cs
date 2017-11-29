/*==============================================================================================================================
 File Name    : ExpectedConditionsExtender.cs
 ClassName    : ExpectedConditionsExtender
 Summary      : Contains expected customize functions of webdriver
 ===============================================================================================================================
 History      :   Company            Date            Action              Author
                  360logica                         Initial Version      Ammar

 ===============================================================================================================================
 Remarks      :   Tests - 
 ===============================================================================================================================*/
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace RallyTeam.Util
{
    static class ExpectedConditionsExtender
    {
        //Expected condition that is fulfilled by the title being the expected value.
        public static Func<IWebDriver, bool> TitleIs(string title)
        {
            return ExpectedConditions.TitleIs(title);
        }

        //Expected condition that is fulfilled by the element with the specified locator being enabled, displayed, and not null.
        public static Func<IWebDriver, IWebElement> ElementIsVisible(By locator)
        {
            return ExpectedConditions.ElementIsVisible(locator);
        }

        //Expected condition that is fulfilled by the element with the specified locator being found.
        public static Func<IWebDriver, IWebElement> ElementExists(By locator)
        {
            return ExpectedConditions.ElementExists(locator);
        }

        //Expected condition that is fulfilled by the element with the specified locator being found.
        public static bool IsElementVisible(this IWebDriver driver, By locator)
        {
            try
            {
                return driver.FindElement(locator).Displayed;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        //Expected condition to check visibility of element
        public static void CheckElementVisibility(this IWebDriver driver, By locator)
        {
            try
            {
               WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
               wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(locator));               
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }

        }

        //Expected condition to check element clickable
        public static void CheckElementClickable(this IWebDriver driver, By locator)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
                wait.Until(ExpectedConditions.ElementToBeClickable(locator));

            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
        }

        //Expected condition to check visibility of element
        public static void CheckElementDisabled(this IWebDriver driver, By locator)
        {
            try
            {
                bool b = driver.FindElement(locator).Enabled;
                if(b)
                    throw new Exception();
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }

        }

        //Expected condition that is fulfilled by the element with the specified locator being found.
        public static bool IsElementPresent(this IWebDriver driver, By locator)
        {
            try
            {
                return driver.FindElement(locator).Enabled;
            }
            catch (Exception)
            {
                return false;
            }
        }


        //Expected condition that is fulfilled by the element with the specified locator having the expected text entered in it.
        public static Func<IWebDriver, bool> TextEnteredInElement(By locator, string text, int timeout)
        {
            Func<IWebDriver, bool> textEnteredInElement = delegate (IWebDriver driver)
            {
                IWebElement element = driver.SafeFindElement(locator);
                try
                {
                    
                    element.Click();
                    element.Clear();
                    element.SendKeys(Keys.Delete);
                    element.SendKeys(Keys.Clear);
                    element.SendKeys(Keys.Backspace);
                    element.SendKeys(Keys.Backspace);
                    element.SendKeys(text);
                    return true;
                }
                catch
                {
                    return false;
                }
            };
            return textEnteredInElement;
        }

        public static Func<IWebDriver, bool> TextAppendInElement(By locator, string text, int timeout)
        {
            Func<IWebDriver, bool> textEnteredInElement = delegate (IWebDriver driver)
            {
                IWebElement element = driver.SafeFindElement(locator);
                try
                {

                    element.Click();
                   // element.Clear();
                    //element.SendKeys(Keys.Delete);
                    //element.SendKeys(Keys.Clear);
                    //element.SendKeys(Keys.Backspace);
                    //element.SendKeys(Keys.Backspace);
                    element.SendKeys(text);
                    return true;
                }
                catch
                {
                    return false;
                }
            };
            return textEnteredInElement;
        }

        //Expected condition that is fulfilled by the element with the specified locator having the expected text entered in it.
        public static Func<IWebDriver, bool> KeyEnterInElement(By locator, int timeout)
        {
            Func<IWebDriver, bool> keyEnterInElement = delegate (IWebDriver driver)
            {
                IWebElement element = driver.SafeFindElement(locator);
                try
                {
                    element.SendKeys(Keys.Enter);
                    return true;
                }
                catch
                {
                    return false;
                }
            };
            return keyEnterInElement;
        }

        //Expected condition that is fulfilled by the element with the specified locator being clicked successfully.
        public static Func<IWebDriver, bool> ElementClicked(By locator, int timeout)
        {
            Func<IWebDriver, bool> elementClicked = delegate (IWebDriver driver)
            {
                IWebElement element = driver.SafeFindElement(locator);
                try
                {
                    element.Click();
                    return true;
                }
                catch
                {
                    return false;
                }
            };
            return elementClicked;
        }

        //Expected condition that is fulfilled by the relative element (which can only be found in relation to the known element locator) being enabled, displayed, and not null.
        public static Func<IWebDriver, IWebElement> RelativeElementIsVisible(By knownElementLocator, By relativeLocator, int timeout)
        {
            Func<IWebDriver, IWebElement> relativeElementExists = delegate (IWebDriver driver)
            {
                IWebElement knownElement = driver.SafeFindElement(knownElementLocator);
                try
                {
                    IWebElement relativeElement = knownElement.FindElement(relativeLocator);
                    return (relativeElement != null && relativeElement.Displayed && relativeElement.Enabled) ? relativeElement : null;
                }
                catch
                {
                    return null;
                }
            };
            return relativeElementExists;
        }

        //Expected condition that is fulfilled by the relative element (which can only be found in relation to the known element locator) being clicked successfully.
        public static Func<IWebDriver, bool> RelativeElementClicked(By knownElementLocator, By relativeLocator, int timeout)
        {
            Func<IWebDriver, bool> relativeElementClicked = delegate (IWebDriver driver)
            {
                IWebElement relativeElement = driver.SafeFindRelativeElement(knownElementLocator, relativeLocator, timeout);
                try
                {
                    relativeElement.Click();
                    return true;
                }
                catch
                {
                    return false;
                }
            };
            return relativeElementClicked;
        }

        //Expected condition that is fulfilled by an element with the specified locator and containing the specfied text being visible under the parent element.
        public static Func<IWebDriver, IWebElement> DescendantElementByTextIsVisible(By ancestorLocator, By descendantLocator, string text, int timeout)
        {
            Func<IWebDriver, IWebElement> descendantElementByTextExists = delegate (IWebDriver driver)
            {
                IWebElement ancestorElement = driver.SafeFindElement(ancestorLocator);
                try
                {
                    //Get a collection of elements which have the descendant locator and are descendants of the parent.
                    ReadOnlyCollection<IWebElement> elements = ancestorElement.FindElements(descendantLocator);
                    //Loop through the elements and once we find the one whose text matches what we want return it.
                    foreach (IWebElement element in elements)
                    {
                        if (element.Text == text)
                        {
                            return element;
                        }
                    }
                    return null;
                }
                catch
                {
                    return null;
                }
            };
            return descendantElementByTextExists;
        }

        //Expected condition that is fulfilled by an element with the specified locator and containing the specfied text being visible under the parent element.
        public static Func<IWebDriver, bool> DescendantElementByTextClicked(By ancestorLocator, By descendantLocator, string text, int timeout)
        {
            Func<IWebDriver, bool> descendantElementByTextClicked = delegate (IWebDriver driver)
            {
                IWebElement element = driver.SafeFindDescendantElementByText(ancestorLocator, descendantLocator, text);
                try
                {
                    element.Click();
                    return true;
                }
                catch
                {
                    return false;
                }
            };
            return descendantElementByTextClicked;
        }

        //Expected condition that is fulfilled by an element (which can only be found in relation to the known element located using its locator and text) being visible.
        public static Func<IWebDriver, IWebElement> ElementRelativeToElementByTextIsVisible(By knownElementLocator, string knownElementText, By relativeLocator, int timeout)
        {
            Func<IWebDriver, IWebElement> elementRelativeToElementByTextIsVisible = delegate (IWebDriver driver)
            {
                IWebElement knownElement = driver.SafeFindElementByText(knownElementLocator, knownElementText);
                try
                {
                    return knownElement.FindElement(relativeLocator);
                }
                catch
                {
                    return null;
                }
            };
            return elementRelativeToElementByTextIsVisible;
        }

        //Expected condition that is fulfilled by an element with the specified locator and text being found and another element located at a relative position to it being
        //clicked successfully.
        public static Func<IWebDriver, bool> ElementRelativeToElementByTextClicked(By knownElementLocator, string knownElementText, By relativeLocator, int timeout)
        {
            Func<IWebDriver, bool> elementRelativeToElementByTextClicked = delegate (IWebDriver driver)
            {
                IWebElement relativeElement = driver.SafeFindElementRelativeToElementByText(knownElementLocator, knownElementText, relativeLocator, timeout);
                try
                {
                    relativeElement.Click();
                    return true;
                }
                catch
                {
                    return false;
                }
            };
            return elementRelativeToElementByTextClicked;
        }

        //Expected condition that is fulfilled by finding and mousing over an element.
        public static Func<IWebDriver, bool> ElementMousedOver(By locator, int timeout)
        {
            Func<IWebDriver, bool> elementMousedOver = delegate (IWebDriver driver)
            {
                IWebElement element = driver.SafeFindElement(locator);
                Actions builder = new Actions(driver);
                try
                {
                    builder.MoveToElement(element).Build().Perform();
                    return true;
                }
                catch
                {
                    return false;
                }
            };
            return elementMousedOver;
        }

        //Expected condition that is fulfilled by finding a hidden element and its text being equal to the expected value.
        public static Func<IWebDriver, bool> HiddenElementTextIs(By locator, string text, int timeout)
        {
            Func<IWebDriver, bool> hiddenElementTextIs = delegate (IWebDriver driver)
            {
                IWebElement element = driver.SafeFindHiddenElement(locator);
                try
                {
                    return driver.GetHiddenElementText(element).Equals(text);
                }
                catch
                {
                    return false;
                }
            };
            return hiddenElementTextIs;
        }

        //Expected condition that is fulfilled by finding a hidden element and its text not being equal to the given value.
        public static Func<IWebDriver, bool> HiddenElementTextIsNot(By locator, string text, int timeout)
        {
            Func<IWebDriver, bool> hiddenElementTextIsNot = delegate (IWebDriver driver)
            {
                IWebElement element = driver.SafeFindHiddenElement(locator);
                try
                {
                    return !driver.GetHiddenElementText(element).Equals(text);
                }
                catch
                {
                    return false;
                }
            };
            return hiddenElementTextIsNot;
        }

        //Expected condition that is fulfilled by the text of the element at the specified locator being the specified string.
        public static Func<IWebDriver, bool> ElementTextIs(By locator, string text, int timeout)
        {
            Func<IWebDriver, bool> elementTextIs = delegate (IWebDriver driver)
            {
                IWebElement element = driver.SafeFindElement(locator);
                try
                {
                    return element.Text.Equals(text);
                }
                catch
                {
                    return false;
                }
            };
            return elementTextIs;
        }

        //Expected condition that is fulfilled by the text of the element at the specified locator containing the the specified string.
        public static Func<IWebDriver, bool> ElementTextContains(By locator, string containedText, int timeout)
        {
            Func<IWebDriver, bool> elementTextContains = delegate (IWebDriver driver)
            {
                IWebElement element = driver.SafeFindElement(locator);
                try
                {
                    return (element.Text.IndexOf(containedText) != -1);
                }
                catch
                {
                    return false;
                }
            };
            return elementTextContains;
        }

        //Expected condition that is fulfilled by the text of the element at the specified locator containing the the specified string.
        public static Func<IWebDriver, bool> HiddenElementTextContains(By locator, string containedText, int timeout)
        {
            Func<IWebDriver, bool> hiddenElementTextContains = delegate (IWebDriver driver)
            {
                IWebElement element = driver.SafeFindHiddenElement(locator);
                try
                {
                    return (driver.GetHiddenElementText(element).IndexOf(containedText) != -1);
                }
                catch
                {
                    return false;
                }
            };
            return hiddenElementTextContains;
        }


        public static Func<IWebDriver, ReadOnlyCollection<IWebElement>> ElementsExist(By locator)
        {
            Func<IWebDriver, ReadOnlyCollection<IWebElement>> elementsExist = delegate (IWebDriver driver)
            {
                try
                {
                    return driver.FindElements(locator);
                }
                catch
                {
                    return null;
                }
            };
            return elementsExist;
        }

        //Expected condition that is fulfilled by the element with the specified locator being enabled, displayed, and not null.
        public static void ElementIsVisibleAtDom(By locator, int maxTime)
        {
            int time = maxTime * 1000;
            Thread.Sleep(time);
        }
    }
}
