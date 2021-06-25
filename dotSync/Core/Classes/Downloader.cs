using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace sharpSync.Core.Classes
{
    class Downloader
    {
        private const string _URL_XAML = "https://www.dropbox.com/s/dgnmsj3cu8l0x4n/version.xml?dl=1";
        private const string _URL_FILES = "https://www.dropbox.com/s/c8u35li32uz2pqv/course_work.exe?dl=1";
        private string _programmPath = AppDomain.CurrentDomain.BaseDirectory;
        private static string _filePath = AppDomain.CurrentDomain.BaseDirectory + "version.xml";

        
        private string _currentAppVersion;
        public Downloader()
        {

        }
        public string getVersion()
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
        public void startUpdate()
        {
            Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "/temp");
            
            WebClient wc = new WebClient();
            wc.DownloadProgressChanged += (o, e) =>
            {
                ProgressPercentage = e.ProgressPercentage;
            };
            wc.DownloadFileCompleted += (o, e) =>
            {
                ProgressPercentage = 100;
                Process.Start(AppDomain.CurrentDomain.BaseDirectory + "temp_launcher.exe");
                App.Current.Shutdown();
            };
            
            wc.DownloadFileAsync(new Uri(_URL_FILES), "/temp/sharpSync.temp");
        }
        private double _progressPercentage;

        public double ProgressPercentage
        {
            get { return _progressPercentage; }
            set { _progressPercentage = value; }
        }

    }
}
