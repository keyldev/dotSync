using sharpSync.Core.Classes;
using sharpSync.UI.Account;
using sharpSync.UI.Additional;
using sharpSync.UI.Authentication;
using sharpSync.UI.FTP;
using sharpSync.UI.Offline;
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

namespace sharpSync.UI.MainMenu
{
    /// <summary>
    /// Логика взаимодействия для Main.xaml
    /// </summary>
    public partial class MenuMain : Page
    {
        public MenuMain()
        {
            InitializeComponent();
            
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                string[] user = new string[4];
               // user = await API.getInfo(Login.userLogin);
               userNameLabel.Content = user[0] + " " + user[1];

                fMainContent.Navigate(new Home());
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void bAccount_Click(object sender, RoutedEventArgs e)
        {
            fMainContent.Navigate(new PersonalAccount());
        }

        private void bSettings_Click(object sender, RoutedEventArgs e)
        {
            fMainContent.Navigate(new Settings());
        }

        private void bHome_Click(object sender, RoutedEventArgs e)
        {
            fMainContent.Navigate(new Home());
        }

        private void bFTP_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                fMainContent.Navigate(new ShareFTP());
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }

        private void bLogout_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Login());
        }

        private void bBugReport_Click(object sender, RoutedEventArgs e)
        {
            fMainContent.Navigate(new BugReport());
        }
    }
}
