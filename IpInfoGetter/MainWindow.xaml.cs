using IpInfoGetter.Advanced;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Xml.Serialization;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using System.Diagnostics;

namespace IpInfoGetter
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        { 
            StartupConfig.ReadParams();
            InitializeComponent();
        }
        private void Rectangle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }  
        private void BtnMoreClick(object sender,RoutedEventArgs e)
        {
            string[] ipInfo = null;
            string fileName = "";
            OpenFileDialog fileDialog = new OpenFileDialog
            {
                Filter = "json (*.json)|*.json|All files (*.*)|*.*",
                Title = "Select file",
            };
            if(fileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (Regex.IsMatch(fileDialog.SafeFileName, @"w?.json") || Regex.IsMatch(fileDialog.SafeFileName, @"w?.xml"))
                {
                    fileName = fileDialog.SafeFileName;
                    ipInfo = GlobalProp.GetByFileName(fileDialog.FileName);
                }
            }
            if (ipInfo != null)
            {
                if (GetInformation(ipInfo[1],ipInfo[0]))
                {
                    Regex rx = new Regex(@"([0-9]{1,3}[\.]){3}[0-9]{1,3}");
                    Match match = rx.Match(fileName);
                    sourceTbox.Text = match.Value;
                }
            }
        }
        private void BtnSettingsClick(object sender, RoutedEventArgs e)
        {
            SettingsWindow swindow = new SettingsWindow();
            swindow.Owner = this;
            swindow.ShowDialog();
        }
        private void BtnSearchClick(object sender, RoutedEventArgs e)
        {
            GoSearch();
        }
        async private void BtnMyIPClickAsync(object sender, RoutedEventArgs e)
        {
            try
            {
                GlobalProp.Ip_address = await Task.Factory.StartNew(() =>  new WebClient().DownloadString(new Uri("https://api.ipify.org/")));
                sourceTbox.Text = GlobalProp.Ip_address;
            }
            catch (WebException)
            {
                System.Windows.MessageBox.Show("Connection with server is down", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
           
        }
        private void BtnCloseWindowClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void BtnMinisizedWindowClick(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
        private void TextBox_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if(e.Key == Key.Enter){ GoSearch(); }
            if (Regex.IsMatch(sourceTbox.Text, "[^0-9-.]"))
            { 
                sourceTbox.Text = sourceTbox.Text.Remove(sourceTbox.Text.Length - 1);
                sourceTbox.SelectionStart = sourceTbox.Text.Length;
            }
        }
        private void GoSearch()
        {
            if (IsCorrectIp(sourceTbox.Text))
            {
                GlobalProp.Ip_address = sourceTbox.Text;
                StartAsync();
            }
            else
                sourceTbox.Text = string.Empty;
        }
        async private void StartAsync()
        {
            string[] file = GlobalProp.IsFileExist() ? await Task.Factory.StartNew(() => GlobalProp.GetFileLocal()) : await Task.Factory.StartNew(() => GetInfoByNet());
            if (!(file == null))
            {
                GetInformation(file[0], file[1]);
            }
        }
        private bool GetInformation(string file, string mark)
        {
            try
            {
                if (mark == "ipwhois")
                {
                    IpWhoIS ipWhoIs = JsonConvert.DeserializeObject<IpWhoIS>(file);
                    ipWhoIs.SetOptions();
                    information_list.ItemsSource = ipWhoIs.information;
                }
                else if (mark == "ipapi")
                {
                    Ip_API ip_api = JsonConvert.DeserializeObject<Ip_API>(file);
                    ip_api.SetOptions();
                    information_list.ItemsSource = ip_api.information;
                }                                
                return true;
            }
            catch (WebException)
            {
                System.Windows.MessageBox.Show("Invalid public IP","Error",MessageBoxButton.OK,MessageBoxImage.Error);
            }
            catch (Exception)
            {
                System.Windows.MessageBox.Show("Invalid file", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            return false;
        }
        private string[] GetInfoByNet()
        {
            string url;
            if (StartupConfig.cboxCheckedAPI == null)
                url = $"https://free.ipwhois.io/json/{GlobalProp.Ip_address}";
            else
                url = GlobalProp.LongUrl;
            string file = "";
            WebRequest request = WebRequest.Create(url);
            try
            {
                using (WebResponse response = request.GetResponse())
                {
                    using (Stream stream = response.GetResponseStream())
                    {
                        using (StreamReader reader = new StreamReader(stream))
                        {
                            file = reader.ReadToEnd();
                        }
                    }
                }
                if(StartupConfig.isSaveFile)
                    GlobalProp.SaveFileAsync(GlobalProp.Ip_address, file);
                return new string[] { file, GlobalProp.FileMark };
            }
            catch (WebException)
            {
                System.Windows.Forms.MessageBox.Show("Error connection","Error");
                return null;
            }
        }
        private bool IsCorrectIp(string ip)
        {
            try
            {
                string[] oktets = ip.Split('.');
                if (int.Parse(oktets[0]) != 0 && oktets.TakeWhile(x => int.Parse(x) >= 0 && int.Parse(x) < 256).Count() == 4)
                {
                    return true;
                }
                else throw new Exception();
            }
            catch (Exception)
            {
                System.Windows.MessageBox.Show("Invalid IPv4 address\nTry again", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }            
        }
    }
}
