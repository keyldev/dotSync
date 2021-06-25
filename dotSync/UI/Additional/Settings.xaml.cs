using sharpSync.UI.FTP;
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
//using Core = sharpSync.Core.Classes.API;
namespace sharpSync.UI.Additional
{
    /// <summary>
    /// Логика взаимодействия для Settings.xaml
    /// </summary>
    public partial class Settings : Page
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void bApply_Click(object sender, RoutedEventArgs e)
        {
            ShareFTP.IP_PORT = "ftp://" + tbHostIP.Text + ":" + tbHostPort.Text;
           
        }
    }
}
