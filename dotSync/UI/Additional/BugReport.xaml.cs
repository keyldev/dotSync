using sharpSync.Core.Classes;
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

namespace sharpSync.UI.Additional
{
    /// <summary>
    /// Логика взаимодействия для BugReport.xaml
    /// </summary>
    public partial class BugReport : Page
    {
        public BugReport()
        {
            InitializeComponent();
        }

        private async void bSubmit_Click(object sender, RoutedEventArgs e)
        {
            if (tbBugText.Text.Equals("Суть") && tbBugTopic.Text.Equals("Тема"))
                return;

            var result = await API.reportBug(Login.userLogin, tbBugTopic.Text, tbBugText.Text);
            if (result)
                MessageBox.Show("Баг успешно отправлен.");
            else
                MessageBox.Show("Баг успешно не отправлен.");
        }
    }
}
