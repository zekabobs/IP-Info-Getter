using System.Windows;
using System.Windows.Input;

namespace IpInfoGetter
{

    public partial class SettingsWindow : Window
    {
        private Pages.MainSettingsPage main = new Pages.MainSettingsPage();
        private Pages.InformationPage inforamtion = new Pages.InformationPage();
        public SettingsWindow()
        {
            InitializeComponent();
        }
        private void BtnCloseWindowClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void Button_Main_Click(object sender, RoutedEventArgs e)
        {
            if (settingsFrame.Content != main)
                settingsFrame.Content = main;
        }
        private void Button_Information_Click(object sender, RoutedEventArgs e)
        {
            if (settingsFrame.Content != inforamtion)
                settingsFrame.Content = inforamtion;
        }

        private void SettingsFrame_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}
