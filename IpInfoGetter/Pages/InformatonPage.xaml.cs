using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace IpInfoGetter.Pages
{
    public partial class InformationPage : Page
    {
        public InformationPage()
        {
            InitializeComponent();
        }

        private void TxtBlockCopyAPI_MouseDown(object sender, MouseButtonEventArgs e)
        {       
            Clipboard.SetText((sender as TextBlock).Text.Substring((sender as TextBlock).Text.IndexOf('-') + 1));
        }
        private void TxtBlockFeedBack_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Clipboard.SetText((sender as TextBlock).Text);
        }
    }
}
