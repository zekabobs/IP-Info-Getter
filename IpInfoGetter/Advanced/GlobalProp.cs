
using System.IO;
using System.Threading.Tasks;

namespace IpInfoGetter
{
    static class GlobalProp
    {
        static public string IpUrl {get; } =  $"http://free.ipwhois.io/json/{Ip_address}?Lang={Lang}";
        static public string Ip_address { get; set; } = "";
        static public string Lang { get; set; } = "";
        static public bool IsJsonExist()
        {
            try
            {
                if (File.Exists(StartupConfig.LastFolder + $"\\json\\{Ip_address}.json"))
                    return true;
            }
            catch { }
            return false;
        }
        static public string GetJsonFileLocal()
        {
            using (StreamReader reader = new StreamReader(StartupConfig.LastFolder + $"\\json\\{Ip_address}.json"))
            {
                return reader.ReadToEnd();
            }
        }
        static async public void SaveJsonFile(string ip, string json)
        {
            if(StartupConfig.isSaveFile)
                await Task.Factory.StartNew(() =>
                {
                    if (!Directory.Exists(StartupConfig.LastFolder + $"\\json\\"))
                        Directory.CreateDirectory(StartupConfig.LastFolder + $"\\json\\");
                    using (StreamWriter writer = new StreamWriter(StartupConfig.LastFolder + $"\\json\\{ip}.json"))
                    {
                        writer.Write(json);
                    }
                });
        }
        static public string GetJsonByFileName(string path)
        {
            try {
                if (path == string.Empty)
                    throw new System.Exception();
                using (StreamReader reader = new StreamReader($"{path}"))
                {
                    return reader.ReadToEnd();
                }
            }
            catch
            { System.Windows.Forms.MessageBox.Show("Неверный файл"); return ""; }
        }
    }
}
