using sharpSync.Core.Classes;
using sharpSync.UI.MainMenu;
using sharpSync.UI.Offline;
using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace sharpSync.UI.Authentication
{

    /// <summary>
    /// Логика взаимодействия для Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        public Login()
        {
            InitializeComponent();  
        }

        private void bRegistration_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Registration());
        }
        public static string userLogin; // костыль на получение логина и фулл инфы по логину, аха

        private async void bLogin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                WebClient client = new WebClient();
                string last_ip = client.DownloadString("https://api.ipify.org");
                
                userLogin = tbLogin.Text;
                /* string pattern = @"^(?("")(""[^""]+?""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                 @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,17}))$";
                 string regex_pattern = @"^[a-zA-Z0-9]$";*/
                // NavigationService.Navigate(new MenuMain());
                var result = await API.logUser(tbLogin.Text, tbPassword.Password, last_ip);
                if (result)
                {
                    //userLogin = tbLogin.Text;
                    NavigationService.Navigate(new MenuMain());
                    
                }
                else
                {
                    PopupTip.Popup pop = new PopupTip.Popup("Ошибка авторизации");
                    pop.Show();
                }
                //var result = await API.logUser(tbLogin.Text, tbPassword.Password);
                //if (result)
                //{
                //    //userLogin = tbLogin.Text;
                //    NavigationService.Navigate(new MenuMain());
                //}
                //else
                //{
                //    PopupTip.Popup pop = new PopupTip.Popup("Ошибка авторизации");
                //    pop.Show();
                //}
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void bOfflineMode_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new OfflineMainMenu());
        }
    }
}
