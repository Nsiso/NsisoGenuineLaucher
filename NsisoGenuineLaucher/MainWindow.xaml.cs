using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using NsisoGenuineLaucher.Config;
using KMCCC.Authentication;
using KMCCC.Launcher;
using System.Threading;

namespace NsisoGenuineLaucher
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Config.setConfig.checkini();
        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start("http://minecraft.net/zh-hans/store/minecraft/?ref=h");
        }

        private void Hyperlink_RequestNavigate2(object sender, RequestNavigateEventArgs e)
        {
            Process.Start("https://account.mojang.com/password");
        }

        //启动按钮点击后
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            var versions = App.Core.GetVersions().ToArray();
            var lastver = App.Core.GetVersion(IniGS.lastVersion);

            if (!Tools.checkTool.IsEmail(emailBox.Text))
            {
                DialogWindow.ShowWarn(this, "您没有正确输入正版邮箱", "请输入正确的邮箱，请检查填写正确，请勿留空");
            }
            else if (string.IsNullOrWhiteSpace(passwordBox.Password))
            {
                DialogWindow.ShowWarn(this, "您没有输入正版密码", "请检查您是否输入密码，请勿留空");
            }
            else if (versions.Length == 0)
            {
                DialogWindow.ShowWarn(this, "目录下没有游戏本体文件", "请确认目前启动器目录中存在.minecraft文件夹并且完整");
            }
            else if (versions.Length > 1 && string.IsNullOrWhiteSpace(IniGS.lastVersion))
            {
                DialogWindow.ShowWarn(this, "游戏有多个版本", "请进入设置界面设置您要启动的版本");
            }
            else
            {
                loading.Visibility = Visibility.Visible;
                if (versions.Length == 1)
                {
                    IniGS.lastVersion = versions.First().Id;
                }
                lastver = App.Core.GetVersion(IniGS.lastVersion);
                Tools.Download down = new Tools.Download();
                int los = down.IsLost(lastver);
                if (!IniGS.isNoRemindAgain && los > 0)
                {
                    Download a = new Download(lastver);
                    a.Owner = this;
                    a.Show();
                    loading.Visibility = Visibility.Hidden;
                }
                IniGS.account = emailBox.Text;
                IniGS.password = passwordBox.Password;
                IniGS.isTwitch = (bool)checkBox.IsChecked;
                
                var result = Start.StartGame.FromSetting();
                if (!result.Success)
                {
                    loading.Visibility = Visibility.Hidden;
                    switch (result.ErrorType)
                    {
                        case ErrorType.NoJAVA:
                            DialogWindow.ShowWarn(this, "启动错误:JAVA异常", "请确认您的电脑上已经正确安装完整的JAVA环境。请勿安装绿色版本JAVA");
                            break;
                        case ErrorType.AuthenticationFailed:
                            DialogWindow.ShowWarn(this, "启动错误:正版验证错误", "请检查您输入的正版账号密码是否正确");
                            break;
                        case ErrorType.OperatorException:
                            DialogWindow.ShowWarn(this, "启动错误:操作器故障", result.ErrorMessage);
                            break;
                        case ErrorType.Unknown:
                            DialogWindow.ShowWarn(this, "启动错误:未知故障", result.ErrorMessage);
                            break;
                        case ErrorType.UncompressingFailed:
                            DialogWindow.ShowWarn(this, "启动错误:解压错误", "可能出现文件损坏或者多开。请检查游戏libraries文件夹完整并不要多开.详细信息\n" + result.ErrorMessage);
                            break;
                        default:
                            DialogWindow.ShowWarn(this, "启动错误", "请截图发送给开发者获得技术支持.详细信息\n" + result.ErrorMessage);
                            break;
                    }
                }
                else
                {
                    App.Core.GameExit += Core_GameExit;
                }
            }
            
        }

        private void Core_GameExit(LaunchHandle arg1, int arg2)
        {
            this.Dispatcher.Invoke(new Action(delegate ()
            {
                loading.Visibility = Visibility.Hidden;
            }));
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            setWindow set = new setWindow();
            set.Owner = this;
            set.Show();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            emailBox.Text = IniGS.account;
            passwordBox.Password = IniGS.account;
            checkBox.IsChecked = IniGS.isTwitch;
        }
    }
}
