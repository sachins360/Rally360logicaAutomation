using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RallyTeam
{
    [SetUpFixture]
    public class Global
    {
        public static string MethodName = string.Empty;
        public static int tempCount = 3;
        public static ExtentReports extent;
        public static ExtentTest test;
        [OneTimeSetUp]
        public void StartReport()
        {
            //*********Extent Report Generation One Time Setup*********
            string rootPath = AppDomain.CurrentDomain.BaseDirectory;
            ExtentHtmlReporter htmlReporter = new ExtentHtmlReporter(rootPath + "\\ExecutionResult.html");
            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
            Console.WriteLine("I am printed.");
        }
        [OneTimeTearDown]
        public void EndReport()
        {
            extent.Flush();
        }


    }
}
