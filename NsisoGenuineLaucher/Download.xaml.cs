using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace NsisoGenuineLaucher
{
    /// <summary>
    /// Download.xaml 的交互逻辑
    /// </summary>
    public partial class Download : Window
    {

        private List<string> lostFlieList = new List<string>();
        private KMCCC.Launcher.Version version;

        public Download(KMCCC.Launcher.Version ver)
        {
            InitializeComponent();
            version = ver;
        }

        private void button_Copy_Click(object sender, RoutedEventArgs e)
        {
            if ((bool)checkBox.IsChecked)
            {
                Config.IniGS.isNoRemindAgain = true;
            }
            this.Close();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            grid1.Visibility = Visibility.Hidden;
            grid2.Visibility = Visibility.Visible;
            if ((bool)checkBox.IsChecked)
            {
                Config.IniGS.isNoRemindAgain = true;
            }
            listView.ItemsSource = lostFlieList;
            Thread down = new Thread(() => downl(version));
            down.Start();
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Tools.Download down = new Tools.Download();
            textBlock.Text = down.IsLost(version).ToString();
            lostFlieList = down.CountlostFlie;
        }

        private void Rectangle_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        
        private void downl (KMCCC.Launcher.Version ver)
        {
            Tools.Download down = new Tools.Download();
            down.DownloadLostFlie(version);
            this.Dispatcher.Invoke(new Action(delegate ()
            {
                textBlock1.Text = "下载已完成！";
                prog.IsIndeterminate = false;
            }));
        }
    }
}
