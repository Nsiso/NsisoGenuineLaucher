using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    /// setWindow.xaml 的交互逻辑
    /// </summary>
    public partial class setWindow : Window
    {
        public setWindow()
        {
            InitializeComponent();
        }

        private void button_Copy_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(comboBox.Text))
            {
                DialogWindow.ShowWarn(this, "您没有选择游戏版本", "请检查您是否正确选择或检查目录下是否存在游戏本体文件");
                return;
            }
            else
            {
                Config.IniGS.lastVersion = comboBox.Text;
            }

            if (string.IsNullOrWhiteSpace(comboBox1.Text))
            {
                DialogWindow.ShowWarn(this, "您没有选择JAVA", "请检查您是否正确选择JAVA或检查系统是否安装JAVA");
                return;
            }
            else
            {
                Config.IniGS.javaPath = comboBox1.Text;
            }

            if ((bool)checkBox.IsChecked)
            {
                if (!Tools.checkTool.IsNumber(textBox.Text) || !Tools.checkTool.IsNumber(textBox_Copy.Text))
                {
                    DialogWindow.ShowWarn(this, "输入的窗口大小错误", "请检查您输入的窗口大小是否正确");
                    return;
                }
                else
                {
                    Config.IniGS.isAutoSize = false;
                    Config.IniGS.sizeX = Convert.ToUInt16(textBox.Text);
                    Config.IniGS.sizeY = Convert.ToUInt16(textBox_Copy.Text);
                }
            }
            else
            {
                Config.IniGS.isAutoSize = true;
            }

            if ((bool)checkBox1.IsChecked)
            {
                if (!Tools.checkTool.IsNumber(textBox1.Text))
                {
                    DialogWindow.ShowWarn(this, "输入的内存大小错误", "请检查您输入的内存大小是否正确");
                    return;
                }
                else
                {
                    Config.IniGS.isAutoMemory = false;
                    Config.IniGS.maxMemory = Convert.ToInt32(textBox1.Text);
                }
            }
            else
            {
                Config.IniGS.isAutoMemory = true;
            }

            if ((bool)checkBox2.IsChecked)
            {
                if (string.IsNullOrWhiteSpace(textBox2.Text))
                {
                    DialogWindow.ShowWarn(this, "输入的启动参数为空", "请检查您是否输入启动参数或关闭启动参数功能");
                    return;
                }
                else
                {
                    Config.IniGS.isAgentPath = true;
                    Config.IniGS.agentPath = textBox2.Text;
                }
            }
            else
            {
                Config.IniGS.isAgentPath = false;
            }

            DialogWindow.ShowWarn(this, "保存成功！", "所有配置已经成功保存");
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var versions = App.Core.GetVersions().ToArray();
            comboBox.ItemsSource = versions;//绑定数据源
            comboBox1.ItemsSource = KMCCC.Tools.SystemTools.FindJava().ToArray();
            comboBox.SelectedIndex = 0;
            comboBox1.SelectedIndex = 0;
            runMemoryBox.Text = KMCCC.Tools.SystemTools.GetRunmemory().ToString();
            comboBox.Text = Config.IniGS.lastVersion;
            comboBox1.Text = Config.IniGS.javaPath;
            checkBox.IsChecked =! Config.IniGS.isAutoSize;
            textBox.Text = Config.IniGS.sizeX.ToString();
            textBox_Copy.Text = Config.IniGS.sizeY.ToString();
            checkBox1.IsChecked =! Config.IniGS.isAutoMemory;
            textBox1.Text = Config.IniGS.maxMemory.ToString();
            checkBox2.IsChecked = Config.IniGS.isAgentPath;
            textBox2.Text = Config.IniGS.agentPath;
        }
    }
}
