using sharpSync.Core.Classes;
using sharpSync.UI.Authentication;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
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
using System.Windows.Threading;
using System.Xml;

namespace sharpSync.UI.Updater
{
    /// <summary>
    /// Логика взаимодействия для Update.xaml
    /// </summary>
    public partial class Update : Page, INotifyPropertyChanged
    {
        private static Assembly assembly = Assembly.GetEntryAssembly();
        private string _version = $"{assembly.GetName().Version}";

        private const string _URL_XAML = "https://www.dropbox.com/s/dgnmsj3cu8l0x4n/version.xml?dl=1";

        private const string _URL_FILES = "https://www.dropbox.com/s/c8u35li32uz2pqv/course_work.exe?dl=1";
        private string _programmPath = AppDomain.CurrentDomain.BaseDirectory;
        private static string _filePath = AppDomain.CurrentDomain.BaseDirectory + "version.xml";

        private string _currentAppVersion;

        public event PropertyChangedEventHandler PropertyChanged;

        void NotifyPropertyChanged([CallerMemberName] string name = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        public Update()
        {
            InitializeComponent();
        }
        private void showLogin() => NavigationService.Navigate(new Login());
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                _currentAppVersion = _getVersion();

                percentLabel.Content = _currentAppVersion;
                if (_version.Equals(_currentAppVersion))
                {
                    percentLabel.Content = "Обновление не требуется. v" + _version;
                    showLogin();

                }
                else { percentLabel.Content = "Приступаю к обновлению..."; _downloadUpdate(); }
            }
            catch (WebException ex)
            {
                //MessageBox.Show(ex.Message.ToString());
                //SampleWindow sample = new SampleWindow(ex.Message);
                //sample.Show();
                downloadProgressBar.Foreground = new SolidColorBrush(Color.FromArgb(255, 5, 5, 1));
                downloadProgressBar.Value = 100;
                percentLabel.Content = "Ошибка проверки обновления.. " + ex.ToString();
                //SampleWindow sample = new SampleWindow(ex.Message);
                //sample.Show();
                //  Task.Delay(3000);
                NavigationService.Navigate(new Offline.OfflineMainMenu());

            }
        }
        private void _downloadUpdate()
        {
            WebClient client = new WebClient();
            client.DownloadFileCompleted += (o, e) =>
            {
                downloadProgressBar.Value = 100;
                percentLabel.Content = "Обновление завершено.. перезапустите приложение";

            };
            client.DownloadProgressChanged += (o, e) =>
            {
                downloadProgressBar.Value = e.ProgressPercentage;
                percentLabel.Content = e.BytesReceived / 1024 + "/" + e.TotalBytesToReceive  / 1024 + "Kb";
            };
            client.DownloadFileAsync(new Uri(_URL_FILES), AppDomain.CurrentDomain.BaseDirectory + "sharp.exe");
        }
        private string _getVersion()
        {
            string version = null;
            XmlDocument xml = new XmlDocument();
            xml.Load(_URL_XAML);
            foreach (XmlNode node in xml.DocumentElement)
            {
                if (node.LocalName == "version")
                {
                    version = node.FirstChild.Value;
                    return version;
                }
            }
            return null;
        }
    }

}
