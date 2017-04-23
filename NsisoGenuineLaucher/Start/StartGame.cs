using KMCCC.Authentication;
using KMCCC.Launcher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static KMCCC.Launcher.Reporter;

namespace NsisoGenuineLaucher.Start
{
    class StartGame
    {
        /// <summary>
        /// 从配置文件中启动（默认）
        /// </summary>
        public static LaunchResult FromSetting()
        {
            try
            {
                //取消自动报告
                SetReportLevel(ReportLevel.None);

                //保存最新启动版本
                var core = LauncherCore.Create();
                KMCCC.Launcher.Version ver;
                try
                {
                    ver = core.GetVersion(Config.IniGS.lastVersion);
                }
                catch
                {
                    ver = core.GetVersions().First();
                }

                //设置自动选项的最佳值
                if (Config.IniGS.isAutoMemory)
                {
                    Tools.GetBest.setBestMemory();
                }

                //设置java路径
                if (Config.IniGS.isAutoJava)
                {
                    Tools.GetBest.SetJavaPath();
                }
                else
                {
                    App.Core.JavaPath = Config.IniGS.javaPath;
                }

                //启动核心初始化
                LaunchOptions Options = new LaunchOptions();
                Options.Version = ver;
                Options.MaxMemory = Config.IniGS.maxMemory;

                Options.VersionType = "NsisoLaucher";

                //设置窗口大小
                if (Config.IniGS.isAutoSize)
                {
                    Options.Size = new WindowSize { FullScreen = true };
                }
                else
                {
                    Options.Size = new WindowSize { Width = Config.IniGS.sizeX, Height = Config.IniGS.sizeY };
                }

                //正版验证器
                Options.Authenticator = new YggdrasilLogin(Config.IniGS.account, Config.IniGS.password, Config.IniGS.isTwitch);

                var result = App.Core.Launch(Options);
                return result;
            }
            catch
            {
                LaunchResult result = new LaunchResult();
                result.ErrorType = ErrorType.Unknown;
                result.ErrorMessage = "启动游戏时启动器内部出现问题。请联系开发人员";
                return result;
            }
        }
    }
}
