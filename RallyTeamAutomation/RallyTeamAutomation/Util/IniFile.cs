/*==============================================================================================================================
 File Name    : Ini.cs
 ClassName    : Ini
 Summary      : Support file to read ini file
 ===============================================================================================================================
 History      :   Company            Date            Action              Author
                  360logica                         Initial Version      Ammar

 ===============================================================================================================================
 Remarks      :   Tests - 
 ===============================================================================================================================*/
using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using RallyTeam.Util;

namespace RallyTeam.Util
{

    public class IniFile
    {
        public string path;

        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

        public IniFile(string INIPath)
        {
            path = INIPath;
        }

        public void IniWriteValue(string Section, string Key, string Value)
        {
            WritePrivateProfileString(Section, Key, Value, this.path);
        }


        public string IniReadValue(string Section, string Key)
        {
            var errMsg = "ERROR-KEY_NOT_FOUND";
            var temp = new StringBuilder(255);
            var i = GetPrivateProfileString(Section, Key, errMsg, temp, 255, this.path);

            if (temp.ToString() == errMsg)
                throw new InvalidOperationException(errMsg);

            return temp.ToString();
        }

    }
}