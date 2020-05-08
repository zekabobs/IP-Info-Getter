using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;

namespace IpInfoGetter
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        { 
            StartupConfig.ReadParams();
            if (!(StartupConfig.isShowTime))
            {
                //tBlockTime.Visibility = Visibility.Collapsed ;
            }
            InitializeComponent();
        }
        private void Rectangle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }  
        private void BtnMoreClick(object sender,RoutedEventArgs e)
        {
            string ipInfo = "";
            string fileName = "";
            OpenFileDialog fileDialog = new OpenFileDialog
            {
                Filter = "json (*.json)|*.json|All files (*.*)|*.*",
                Title = "Select file",
                
            };
            if(fileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (Regex.IsMatch(fileDialog.FileName, @"\w?.json"))
                {
                    fileName = fileDialog.FileName.Substring(fileDialog.FileName.LastIndexOf("\\")+1);
                    ipInfo = GlobalProp.GetJsonByFileName(fileDialog.FileName);
                }
            }
            if (ipInfo != string.Empty)
            {
                if (GetInformation(ipInfo))
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
        async private void BtnMyIPClick(object sender, RoutedEventArgs e)
        {
            try
            {
                GlobalProp.Ip_address = await Task.Factory.StartNew(() =>  new WebClient().DownloadString(new Uri("https://api.ipify.org")));
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
                Start();
            }
            else
                sourceTbox.Text = string.Empty;
        }
        async private void Start()
        {
            string json = GlobalProp.IsJsonExist() ? await Task.Factory.StartNew(() => GlobalProp.GetJsonFileLocal()) : await Task.Factory.StartNew(() => GetJsonNet());
            if (!(json == string.Empty))
            {
                GetInformation(json);
            }
        }
        private bool GetInformation(string json)
        {
            try
            {
                IpInfo ip_info_json = JsonConvert.DeserializeObject<IpInfo>(json);
                ip_info_json.SetOptions();
                information_list.ItemsSource = ip_info_json.information;
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
        private string GetJsonNet()
        {
            string url = $"http://free.ipwhois.io/json/{GlobalProp.Ip_address}?Lang={GlobalProp.Lang}";
            string json = "";
            WebRequest request = WebRequest.Create(url);
            try
            {
                using (WebResponse response = request.GetResponse())
                {
                    using (Stream stream = response.GetResponseStream())
                    {
                        using (StreamReader reader = new StreamReader(stream))
                        {
                            json = reader.ReadToEnd();
                        }
                    }
                }
                if(StartupConfig.isSaveFile)
                    GlobalProp.SaveJsonFile(GlobalProp.Ip_address, json);
                return json;
            }
            catch (WebException)
            {
                System.Windows.Forms.MessageBox.Show("Error connection","Error");
                return json;
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
