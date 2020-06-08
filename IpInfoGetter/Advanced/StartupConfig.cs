using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IpInfoGetter
{
    static class StartupConfig
    {
        public static string LastFolder = "";
        public static string cboxCheckedAPI = "";
        public static bool isSaveFile = false;
        public static bool isShowTime = true;
        public static bool isStartWithSystem = false;

        static public void SetAutoload(bool set)
        {
            RegistryKey rk = null;
            try
            {
                rk = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run\\", true);
                if (set)
                {
                    rk.SetValue("IpInfoGetter", "\"" + AppDomain.CurrentDomain.BaseDirectory + "who is.exe" + "\"");
                }
                else
                {
                    rk.DeleteValue("IpInfoGeter", false);
                }
            }
            finally { if (rk != null) rk.Close(); }
        }
        private static string regKey = "SoftWare\\IpGetter";

        public static void WriteParams()
        {
            RegistryKey rk = null;
            try
            {
                rk = Registry.CurrentUser.CreateSubKey(regKey);
                if (rk == null) return;
                rk.SetValue("LastFolder",LastFolder);
                rk.SetValue("Current URL", cboxCheckedAPI);
                rk.SetValue("IsSaveFile",isSaveFile);
                rk.SetValue("IsShowTime",isShowTime);
                rk.SetValue("isStartWithSystem", isStartWithSystem);
            }
            finally { if (rk != null) rk.Close(); }
        }
        public static void ReadParams()
        {
            RegistryKey rk = null;
            try
            {
                rk = Registry.CurrentUser.OpenSubKey(regKey);
                if (rk == null) return;
                LastFolder = (string)rk.GetValue("LastFolder");
                cboxCheckedAPI = (string)rk.GetValue("Current URL");
                isSaveFile = Convert.ToBoolean(rk.GetValue("IsSaveFile",false));
                isShowTime = Convert.ToBoolean(rk.GetValue("IsShowTime",false));
                isStartWithSystem = Convert.ToBoolean(rk.GetValue("isStartWithSystem", false));
            }
            finally { if (rk != null) rk.Close(); }
        }
    }
}
