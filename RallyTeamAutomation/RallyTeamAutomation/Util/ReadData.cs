/*==============================================================================================================================
 File Name    : ReadINIFile.cs
 ClassName    : ReadINIFile
 Summary      : Created to read ini file data
 ===============================================================================================================================
 History      :   Company            Date            Action              Author
                  360logica                         Initial Version      Ammar

 ===============================================================================================================================
 Remarks      :   Tests - 
 ===============================================================================================================================*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RallyTeam.Util;
using System.IO;

namespace RallyTeam.Util
{
    public class ReadData
    {
        private String Value;
        private String fileName;

        public ReadData(String fileName)
        {
            this.fileName = fileName;
        }

        public String GetValue(String file, String type, String key)
        {
            IniFile ini = GetIniFile();
            Value = ini.IniReadValue(type, key);
            return Value;
        }

        public String GetValue(String type, String key)
        {
            string path = "H:\\AutomationCSharp\\Rally360logicaAutomation\\RallyTeamAutomation\\RallyTeamAutomation";
            //string path = System.IO.Directory.GetCurrentDirectory();
            IniFile ini = new IniFile(path + "\\TestData\\" + fileName + ".ini");
            Console.WriteLine("current directory path: "+System.IO.Directory.GetCurrentDirectory());
            Console.WriteLine("actual path: " + System.IO.Directory.GetCurrentDirectory() + "\\TestData\\" + fileName + ".ini");
            Value = ini.IniReadValue(type, key);
            return Value;
        }

        public void SetValue(String type, String key, String value)
        {
            IniFile ini = GetIniFile();
            ini.IniWriteValue(type, key, value);
        }

        public int RandomNumber()
        {
            Random random = new Random();
            return random.Next(new System.DateTime().Millisecond);
        }

         private IniFile GetIniFile()
         {
           return new IniFile(Path.Combine(Directory.GetCurrentDirectory(), "TestData", this.fileName + ".ini"));
         }

        // Generate random number
        public static string RandomNumber(int length)
        {
            const string chars = "0123456789";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
