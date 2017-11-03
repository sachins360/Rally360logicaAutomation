/*==============================================================================================================================
 File Name    : UtilityHelper.cs
 ClassName    : UtilityHelper
 Summary      : Utility to capture screenshot 
 ===============================================================================================================================
 History      :   Company            Date            Action              Author
                  360logica                         Initial Version      Ammar

 ===============================================================================================================================
 Remarks      :   Tests - 
 ===============================================================================================================================*/
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using log4net;
using System.Reflection;
using System.IO;
using System;

namespace RallyTeam.Util
{
    public class UtilityHelper
    {
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public static String TakeScreenshot(IWebDriver driver)
        {
            String filename = "Screenshots\\AutomationScreenShot_" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + ".png";
            return TakeScreenshot(driver, filename);
        }


        public static String TakeScreenshot(IWebDriver driver, String filename)
        {
            // Take screenshot
            Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
            // Create directory if doesn't exist
            Directory.CreateDirectory(Path.GetDirectoryName(filename));
            // Save file
            ss.SaveAsFile(filename, ScreenshotImageFormat.Png);
            Log.InfoFormat("Screenshot saved at: {0}", filename);
            return filename;
        }
    }
}
