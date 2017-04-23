using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace NsisoGenuineLaucher.Config
{
    class setConfig
    {
        private const string LaucherVersion = "1.0.0";
        /// <summary>
        /// 填补一个空的setting.ini配置文件
        /// </summary>
        public static void newini()
        {
            try
            {
                IniGS.version = LaucherVersion;
                IniGS.lastVersion = "";
                IniGS.isNoRemindAgain = false;
                //authenticator
                IniGS.isTwitch = false;
                IniGS.account = "";
                IniGS.password = "";
                //memory
                IniGS.isAutoMemory = true;
                IniGS.maxMemory = 1024;
                //java
                IniGS.isAutoJava = true;
                IniGS.javaPath = "";
                //size
                IniGS.isAutoSize = true;
                IniGS.sizeX = 1028;
                IniGS.sizeY = 768;
                //agentPath
                IniGS.isAgentPath = false;
                IniGS.agentPath = "";

                //设置最佳内存
                Tools.GetBest.setBestMemory();
            }
            catch
            {
            }
        }



        /// <summary>
        /// 检查ini文件是否存在并且版本正确，否则新建
        /// </summary>
        public static void checkini()
        {
            try
            {
                string nowVer = "";
                if (Directory.Exists(@"Config") == false)
                {
                    Directory.CreateDirectory("Config");
                    setConfig.newini();

                }

                else if (File.Exists(@"Config\Setting.ini") == false)
                {
                    setConfig.newini();
                }
                else
                {
                    nowVer = IniGS.version;
                    if (nowVer != LaucherVersion)
                    {
                        File.Delete(@"Config\Setting.ini");
                        setConfig.newini();
                    }
                }
            }
            catch
            {
            }
        }

        /// <summary>
        /// ini文件是否正常
        /// </summary>
        public static bool isRightIni()
        {
            try
            {
                string nowVer = "";
                if (!Directory.Exists(@"Config") || !File.Exists(@"Config\Setting.ini"))
                {
                    return false;
                }
                else
                {
                    nowVer = IniGS.version;
                    if (nowVer != LaucherVersion)
                    {
                        return false;
                    }
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        
    }
}
