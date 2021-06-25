using sharpSync.Core.Classes;
using sharpSync.Core.Models;
using sharpSync.UI.Additional;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace sharpSync.UI.FTP
{
    /// <summary>
    /// Логика взаимодействия для ShareFTP.xaml
    /// </summary>
    public partial class ShareFTP : Page
    {
        public static string IP_PORT;
        public static string LOGIN;
        public static string PASSWORD;

        private string _previousAddress = "ftp://";
        List<FileDirectoryInfo> list;
        FTPClient client;
        public ShareFTP()
        {
            InitializeComponent();
            
            tbFTPAddress.Text = IP_PORT;
        }
        string file = "";
        private void Rectangle_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                file = files[0];
                for (int i = 0; i < files.Length; i++)
                {
                    FileInfo fileInfo = new FileInfo(files[i]);
                    string filename = System.IO.Path.GetFileName(files[i]);
                    
                    /////////////
                    string fileRes;
                    if (filename.Contains(".png"))
                        fileRes = "png.png";
                    else if (filename.Contains(".jpg"))
                        fileRes = "jpg.png";
                    else if (filename.Contains(".mp4") || filename.Contains(".3gp"))
                        fileRes = "mpg.png";
                    else if (filename.Contains(".mov"))
                        fileRes = "mov.png";
                    else if (filename.Contains(".doc"))
                        fileRes = "doc.png";
                    else if (filename.Contains(".html"))
                        fileRes = "html.png";
                    else if (filename.Contains(".xaml") || filename.Contains(".xml"))
                        fileRes = "xml.png";
                    else fileRes = "default_file.png";
                    //////////////
                    var uriImageSource = new Uri(@"/sharpSync;component/Assets/icons/files_icon/" + fileRes, UriKind.RelativeOrAbsolute);
                    filesList.Items.Add(new FileUploadingDetail()
                    {
                        FileName = filename,
                        FileImage = new BitmapImage(uriImageSource),
                        FileSize = string.Format("{0} {1}", (fileInfo.Length / 1.049e+6).ToString("0.0"), "Mb")

                    });
                }
            }
        }
        private string _IP = "";
        private void tbConnectIP_TextChanged(object sender, TextChangedEventArgs e)
        {
            _IP = tbConnectIP.Text;
        }
        string _PORT = "";
        private void tbPort_TextChanged(object sender, TextChangedEventArgs e)
        {
            _PORT = tbPort.Text;
        }
        string dirname = "";
        private void bSetData_Click(object sender, RoutedEventArgs e)
        {
            tbFTPAddress.Text = "ftp://" + _IP + ":" + _PORT + dirname;
            try
            {
                // Создаем объект подключения по FTP
                if (tbLogin.Text != "login" && tbLogin.Text != "" && tbPassword.Text != "password" && tbPassword.Text != "")
                    client = new FTPClient("ftp://" + tbConnectIP.Text + ":" + tbPort.Text + "/" + dirname, tbLogin.Text, tbPassword.Text);
                else
                    client = new FTPClient("ftp://" + tbConnectIP.Text + ":" + tbPort.Text +"/" + dirname);
                // Регулярное выражение, которое ищет информацию о папках и файлах 
                // в строке ответа от сервера
                Regex regex = new Regex(@"^([d-])([rwxt-]{3}){3}\s+\d{1,}\s+.*?(\d{1,})\s+(\w+\s+\d{1,2}\s+(?:\d{4})?)(\d{1,2}:\d{2})?\s+(.+?)\s?$",
                    RegexOptions.Compiled | RegexOptions.Multiline | RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace);

                // Получаем список корневых файлов и папок
                // Используется LINQ to Objects и регулярные выражения
                list = client.ListDirectoryDetails().Select(s =>
                {
                   // string folder_path = "Assets/icons/";
                    string folder_path = @"/sharpSync;component/Assets/icons/";
                    Match match = regex.Match(s);
                    if (match.Length > 5)
                    {
                        // Устанавливаем тип, чтобы отличить файл от папки (используется также для установки рисунка)
                        //string type = match.Groups[1].Value == "d" ? "folder.png" : "file_icons/ai.png";
                        string type = "file.png";
                        if (match.Groups[1].Value == "d")
                        {
                            type = folder_path + "folder.png";
                        }
                        else
                        {
                            if (match.Groups[6].Value.Contains(".png"))
                                type = folder_path+"files_icon/png.png";
                            else if (match.Groups[6].Value.Contains(".jpg"))
                                type = folder_path + "files_icon/jpg.png";
                            else if (match.Groups[6].Value.Contains(".mp4"))
                                type = folder_path + "files_icon/mpg.png";
                            else if (match.Groups[6].Value.Contains(".mov"))
                                type = folder_path + "files_icon/mov.png";
                            else if (match.Groups[6].Value.Contains(".3gp"))
                                type = folder_path + "files_icon/mpg.png";
                            else if(match.Groups[6].Value.Contains(".pdf"))
                                type = folder_path + "files_icon/pdf.png";
                            else if (match.Groups[6].Value.Contains(".xlsx"))
                                type = folder_path + "files_icon/xls.png";
                            else if (match.Groups[6].Value.Contains(".docx") || match.Groups[6].Value.Contains(".doc"))
                                type = folder_path + "files_icon/doc.png";
                            else if (match.Groups[6].Value.Contains(".mp3"))
                                type = folder_path + "files_icon/mp3.png";
                            else
                                type = "Resources/file.png";
                        }

                        // Размер задаем только для файлов, т.к. для папок возвращается
                        // размер ярлыка 4кб, а не самой папки
                        string size = "";
                        if (type == "file.png")
                            size = (Int32.Parse(match.Groups[3].Value.Trim()) / 1024).ToString() + " кБ";

                        return new FileDirectoryInfo(size, type, match.Groups[6].Value, match.Groups[4].Value, "ftp://" + tbConnectIP.Text + ":" + tbPort.Text);
                    }
                    else return new FileDirectoryInfo();
                }).ToList();

                

                // Добавить поле, которое будет возвращать пользователя на директорию выше
                //file.Add(new FileTemplate("a", "folder.png", "test", "test"));
                // Отобразить список в ListView
                files.DataContext = list;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString() + ": \n" + ex.Message);
            }
        }
        private void bUploadFiles_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //FTPUploadFile(file);
                client.FTPUploadFile(file, "/bluetooth/");
                //for (int i = 0; i < file.Count; i++)
                //    await client.FTPUploadFile(file[i], dirname);
                // file = null;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
        string prevAdress = "";
        private void StackPanel_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount >= 2)
            {
                FileDirectoryInfo fdi = (FileDirectoryInfo)(sender as StackPanel).DataContext;
                if (fdi.Type.Contains("folder.png"))
                {
                    try
                    {
                       // MessageBox.Show(fdi.Name.ToString() + "Working");
                        prevAdress = tbConnectIP.Text + ":" + tbPort.Text + "/"+ dirname;
                       // MessageBox.Show(prevAdress.ToString());
                        dirname += "/" + fdi.Name + "/";
                        bSetData_Click(null, null);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
                else
                {
                    try
                    {
                        if (!Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "/Downloads/"))
                            Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "/Downloads");
                        
                        client.DownloadFile(fdi.Name, AppDomain.CurrentDomain.BaseDirectory + "/Downloads/" + fdi.Name);
                        //client.DownloadFile("ftp://192.168.0.101:3721/" + fdi.Name, AppDomain.CurrentDomain.BaseDirectory+ fdi.Name);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            }
        }

        private void bGoBack_Click(object sender, RoutedEventArgs e)
        {
            tbFTPAddress.Text = "ftp://" + prevAdress;
            dirname = "/";
            //MessageBox.Show(tbFTPAddress.Text);
            bSetData_Click(null, null);
        }

        private void bGoForward_Click(object sender, RoutedEventArgs e)
        {

        }

        private void bClearList_Click(object sender, RoutedEventArgs e)
        {
            filesList.Items.Clear();
        }
    }
    public class FileDirectoryInfo
    {
        string fileSize;
        string type;
        string name;
        string date;
        public string adress;

        public string FileSize
        {
            get { return fileSize; }
            set { fileSize = value; }
        }

        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Date
        {
            get { return date; }
            set { date = value; }
        }

        public FileDirectoryInfo() { }

        public FileDirectoryInfo(string fileSize, string type, string name, string date, string adress)
        {
            FileSize = fileSize;
            Type = type;
            Name = name;
            Date = date;
            this.adress = adress;
        }

    }
}
