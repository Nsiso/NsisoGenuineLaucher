using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using KMCCC.Launcher;

namespace NsisoGenuineLaucher
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        public static LauncherCore Core = LauncherCore.Create();
    }
}
