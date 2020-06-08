using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace IpInfoGetter
{
    static class GlobalProp
    {
        public static List<string> Urls { get; } = new List<string>()
        {
            "http://free.ipwhois.io",
            "http://ip-api.com",
        };
        static public string FileMark
        {
            get
            {
                if (StartupConfig.cboxCheckedAPI == Urls[0])
                    return "ipwhois";
                else if (StartupConfig.cboxCheckedAPI == Urls[1])
                    return "ipapi";
                else return "none";
            }
        }
        static public string LongUrl
        {
            get
            {
               return StartupConfig.cboxCheckedAPI + $"/json/{Ip_address}";
            }
        }
        static public string Ip_address { get; set; } = "";
        static public bool IsFileExist()
        {
            try
            {
                if (File.Exists(StartupConfig.LastFolder + $"\\Saved\\{Ip_address}.json"))
                {
                    return true;
                }
            }
            catch { }
            return false;
        }
        static public string[] GetFileLocal()
        {
            using (StreamReader reader = new StreamReader(StartupConfig.LastFolder + $"\\Saved\\{Ip_address}.$json"))
            {
                return new string[] { reader.ReadLine(), reader.ReadToEnd() };
            }
        }
        static async public void SaveFileAsync(string ip, string data)
        {
            if(StartupConfig.isSaveFile)
                await Task.Factory.StartNew(() =>
                {
                    if (!Directory.Exists(StartupConfig.LastFolder + $"\\Saved\\"))
                        Directory.CreateDirectory(StartupConfig.LastFolder + $"\\Saved\\");
                    using (StreamWriter writer = new StreamWriter(StartupConfig.LastFolder + $"\\Saved\\{ip}.json"))
                    {
                        writer.WriteLine(FileMark);
                        writer.Write(data);
                    }
                });
        }
        static public string[] GetByFileName(string path)
        {
            try {
                if (path == string.Empty)
                    throw new System.Exception();
                using (StreamReader reader = new StreamReader(path))
                {
                    return new string[] { reader.ReadLine(), reader.ReadToEnd() };
                }
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("Incorrert file");
                return null;
            }
        }
        static private bool FileExists()
        {
            return false;
        }

    }
}
