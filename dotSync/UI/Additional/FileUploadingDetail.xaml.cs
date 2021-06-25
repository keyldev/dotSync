using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
    /// Логика взаимодействия для FileUploadingDetail.xaml
    /// </summary>
    public partial class FileUploadingDetail : UserControl, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string name = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));


        public string FileName
        {
            get { return fileName.Text; }
            set
            {
                fileName.Text = value;
                NotifyPropertyChanged();
            }
        }

        public string FileSize
        {
            get { return fileSize.Text; }
            set
            {
                fileSize.Text = value;
                NotifyPropertyChanged();
            }
        }

        private ImageSource myVar;

        public ImageSource FileImage
        {
            get { return myVar; }
            set
            {
                myVar = value;
                imageFile.Source = myVar;
            }
        }

        public FileUploadingDetail()
        {
            InitializeComponent();
        }
    }
}
