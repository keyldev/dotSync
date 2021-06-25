using sharpSync.UI.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace sharpSync.UI.Offline
{
    /// <summary>
    /// Логика взаимодействия для OfflineMainMenu.xaml
    /// </summary>
    public partial class OfflineMainMenu : Page
    {
        public OfflineMainMenu()
        {
            InitializeComponent();
        }

        private void bFTP_Click(object sender, RoutedEventArgs e)
        {
            fMainContent.Navigate(new OfflineFTP());
        }

        private void bLogout_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Login());
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            fMainContent.Navigate(new OfflineWelcome());
        }
    }
}
