using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;


namespace IpInfoGetter.Pages
{
    public partial class MainSettingsPage : Page 
    {
        
        public MainSettingsPage()
        {   
            InitializeComponent();
            StartUp();

            App.LanguageChanged += LanguageChanged;
            CultureInfo currLang = App.Language;

            //Заполняем меню смены языка:
            langauge.Items.Clear();
            foreach (var lang in App.Languages)
            {
                ComboBoxItem menuLang = new ComboBoxItem();
                menuLang.Content = lang.DisplayName;
                menuLang.Tag = lang;
                menuLang.IsSelected = lang.Equals(currLang);
                menuLang.Selected += ChangeLanguageClick;
                langauge.Items.Add(menuLang);
            }
        }

        private void LanguageChanged(Object sender, EventArgs e)
        {
            CultureInfo currLang = App.Language;

            //Отмечаем нужный пункт смены языка как выбранный язык
            foreach (ComboBoxItem i in langauge.Items)
            {
                CultureInfo ci = i.Tag as CultureInfo;
                i.IsSelected = ci != null && ci.Equals(currLang);
            }
        }
        private void ChangeLanguageClick(Object sender, EventArgs e)
        {
            ComboBoxItem mi = sender as ComboBoxItem;
            if (mi != null)
            {
                CultureInfo lang = mi.Tag as CultureInfo;
                if (lang != null)
                {
                    App.Language = lang;
                }
            }

        }

        private void BtnSelectPathClick(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.FolderBrowserDialog folderDialog = new System.Windows.Forms.FolderBrowserDialog();
            folderDialog.ShowNewFolderButton = false;
            folderDialog.SelectedPath = AppDomain.CurrentDomain.BaseDirectory;
            System.Windows.Forms.DialogResult result = folderDialog.ShowDialog();

            if (result == System.Windows.Forms.DialogResult.OK)
            {
                string path = folderDialog.SelectedPath;
                lblFilesPath.Text = path;
            }
        }
        private void StartUp()
        {
            StartupConfig.ReadParams();

            cboxCheckAPI.SelectedIndex = GlobalProp.Urls.IndexOf(StartupConfig.cboxCheckedAPI);
            lblFilesPath.Text = StartupConfig.LastFolder;
            isStartWithSystem.IsChecked = StartupConfig.isStartWithSystem;
            isSaveFiles.IsChecked = StartupConfig.isSaveFile;
            isShowTime.IsChecked = StartupConfig.isShowTime;
        }
        private void Button_Save_Click(object sender, RoutedEventArgs e)
        {
            ComboBoxItem i = (ComboBoxItem)cboxCheckAPI.SelectedItem;
            
            StartupConfig.LastFolder = (string)lblFilesPath.Text;
            StartupConfig.cboxCheckedAPI = (string)i.Content;
            StartupConfig.isShowTime = Convert.ToBoolean(isShowTime.IsChecked);           
            if ((bool)isStartWithSystem.IsChecked != StartupConfig.isStartWithSystem)
                StartupConfig.SetAutoload((bool)isStartWithSystem.IsChecked);
            StartupConfig.isStartWithSystem = Convert.ToBoolean(isStartWithSystem.IsChecked);
            StartupConfig.isSaveFile = Convert.ToBoolean(isSaveFiles.IsChecked);
            StartupConfig.WriteParams();
        }
    }
}
