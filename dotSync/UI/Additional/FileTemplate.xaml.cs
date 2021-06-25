using sharpSync.Core.Models;
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
    /// Логика взаимодействия для FileTemplate.xaml
    /// </summary>
    public partial class FileTemplate : UserControl
    {
        public FileTemplate()
        {
            InitializeComponent();
            
            this.MouseEnter += (o, e) =>
            {
                this.Background = new SolidColorBrush(Color.FromArgb(30, 0, 66, 241));
            };
            this.MouseLeave += (o, e) =>
            {
                this.Background = new SolidColorBrush(Color.FromArgb(0, 255, 255, 255));
            };
        }
        public string FileName
        {
            get { return nameLabel.Content.ToString(); }
            set { nameLabel.Content = value; }
        }

    }
}
