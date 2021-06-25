using sharpSync.Core.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
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

namespace sharpSync.UI.Authentication
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Page
    {
        string email_pattern = @"^(?("")(""[^""]+?""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,17}))$";
        string name_credentials = @"^[a-zA-ZА-Яа-я]";
        string password_pattern = @"^[a-zA-ZА-Яа-я0-9]";
        public Registration()
        {
            InitializeComponent();
        }

        private void bLogin_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Login());
        }

        private async void bSignUp_Click(object sender, RoutedEventArgs e)
        {
           
            if (!Regex.IsMatch(tbName.Text, name_credentials) || !Regex.IsMatch(tbSurname.Text, name_credentials))
            {
                PopupTip.Popup error_reg = new PopupTip.Popup("" +
                    "Имя/Фамилия должны содержать: А-Я, \nа-я, A-Z,a-z");
                error_reg.Show();
                return;
            }
            if(!Regex.IsMatch(tbEmail.Text,email_pattern))
            {
                PopupTip.Popup error_reg = new PopupTip.Popup("Ошибка.\n" +
                    "Перепроверьте правильность Email");
                error_reg.Show();
                return;
            }
            if(!Regex.IsMatch(tbPassword.Password, password_pattern))
            {
                PopupTip.Popup error_reg = new PopupTip.Popup("Ошибка.\n" +
                   "Пароль может содержать только: A-Z, a-z\n0-9");
                error_reg.Show();
                return;
            }
            WebClient client = new WebClient();
            string reg_ip = client.DownloadString("https://api.ipify.org");
            var result = await API.regUser(tbName.Text, tbSurname.Text, tbLogin.Text, tbEmail.Text, tbPassword.Password, reg_ip);
            if ((bool)result)
            {
                NavigationService.Navigate(new Login());
            }
            else
            {
                PopupTip.Popup sample = new PopupTip.Popup($"Ошибка регистрации\n");
                sample.Show();
            }
        }
    }
}
