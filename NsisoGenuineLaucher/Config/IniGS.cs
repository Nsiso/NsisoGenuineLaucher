using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NsisoGenuineLaucher.Config
{
    class IniGS
    {
        private static string _version;
        /// <summary>
        /// 启动器版本属性
        /// </summary>
        public static string version
        {
            get
            {
                _version = IniControl.ReadIni("laucher", "version");
                return _version;
            }
            set
            {
                _version = value;
                IniControl.WriteIni("laucher", "version", _version);
            }
        }

        private static string _lastVersion;
        /// <summary>
        /// 上一次minecraft启动版本
        /// </summary>
        public static string lastVersion
        {
            get
            {
                _lastVersion = IniControl.ReadIni("laucher", "lastVersion");
                return _lastVersion;
            }
            set
            {
                _lastVersion = value;
                IniControl.WriteIni("laucher", "lastVersion", _lastVersion);
            }
        }

        private static string _account;
        /// <summary>
        /// 正版用户名属性
        /// </summary>
        public static string account
        {
            get
            {
                _account = IniControl.ReadIni("userdata", "account");
                return _account;
            }
            set
            {
                _account = value;
                IniControl.WriteIni("userdata", "account", _account);
            }
        }

        private static string _password;
        /// <summary>
        /// 正版密码属性
        /// </summary>
        public static string password
        {
            get
            {
                _password = IniControl.ReadIni("userdata", "password");
                return _password;
            }
            set
            {
                _password = value;
                IniControl.WriteIni("userdata", "password", _password);
            }
        }

        private static bool _isTwitch;
        /// <summary>
        /// 是否Twitch正版登陆属性
        /// </summary>
        public static bool isTwitch
        {
            get
            {
                _isTwitch = Convert.ToBoolean(IniControl.ReadIni("userdata", "isTwitch"));
                return _isTwitch;
            }
            set
            {
                _isTwitch = value;
                IniControl.WriteIni("userdata", "isTwitch", Convert.ToString(_isTwitch));
            }
        }

        private static bool _isAutoMemory;
        /// <summary>
        /// 是否开启自动内存属性
        /// </summary>
        public static bool isAutoMemory
        {
            get
            {
                _isAutoMemory = Convert.ToBoolean(IniControl.ReadIni("setup", "isAutoMemory"));
                return _isAutoMemory;
            }
            set
            {
                _isAutoMemory = value;
                IniControl.WriteIni("setup", "isAutoMemory", Convert.ToString(_isAutoMemory));
            }
        }

        private static int _maxMemory;
        /// <summary>
        /// 最大内存属性
        /// </summary>
        public static int maxMemory
        {
            get
            {
                _maxMemory = Convert.ToInt32(IniControl.ReadIni("setup", "maxMemory"));
                return _maxMemory;
            }
            set
            {
                _maxMemory = value;
                IniControl.WriteIni("setup", "maxMemory", Convert.ToString(_maxMemory));
            }
        }

        private static bool _isAutoJava;
        /// <summary>
        /// 是否开启自动JAVA属性
        /// </summary>
        public static bool isAutoJava
        {
            get
            {
                _isAutoJava = Convert.ToBoolean(IniControl.ReadIni("setup", "isAutoJava"));
                return _isAutoJava;
            }
            set
            {
                _isAutoJava = value;
                IniControl.WriteIni("setup", "isAutoJava", Convert.ToString(_isAutoJava));
            }
        }

        private static string _javaPath;
        /// <summary>
        /// java路径属性
        /// </summary>
        public static string javaPath
        {
            get
            {
                _javaPath = IniControl.ReadIni("setup", "javaPath");
                return _javaPath;
            }
            set
            {
                _javaPath = value;
                IniControl.WriteIni("setup", "javaPath", _javaPath);
            }
        }

        private static bool _isAutoSize;
        /// <summary>
        /// 是否全屏属性
        /// </summary>
        public static bool isAutoSize
        {
            get
            {
                _isAutoSize = Convert.ToBoolean(IniControl.ReadIni("setup", "isAutoSize"));
                return _isAutoSize;
            }
            set
            {
                _isAutoSize = value;
                IniControl.WriteIni("setup", "isAutoSize", Convert.ToString(_isAutoSize));
            }
        }

        private static ushort _sizeX;
        /// <summary>
        /// X尺寸属性
        /// </summary>
        public static ushort sizeX
        {
            get
            {
                _sizeX = Convert.ToUInt16(IniControl.ReadIni("setup", "sizeX"));
                return _sizeX;
            }
            set
            {
                _sizeX = value;
                IniControl.WriteIni("setup", "sizeX", Convert.ToString(_sizeX));
            }
        }

        private static ushort _sizeY;
        /// <summary>
        /// Y尺寸属性
        /// </summary>
        public static ushort sizeY
        {
            get
            {
                _sizeY = Convert.ToUInt16(IniControl.ReadIni("setup", "sizeY"));
                return _sizeY;
            }
            set
            {
                _sizeY = value;
                IniControl.WriteIni("setup", "sizeY", Convert.ToString(_sizeY));
            }
        }

        private static bool _isAgentPath;
        /// <summary>
        /// 是否开启高级启动参数
        /// </summary>
        public static bool isAgentPath
        {
            get
            {
                _isAgentPath = Convert.ToBoolean(IniControl.ReadIni("setup", "isAgentPath"));
                return _isAgentPath;
            }
            set
            {
                _isAgentPath = value;
                IniControl.WriteIni("setup", "isAgentPath", Convert.ToString(_isAgentPath));
            }
        }

        private static string _agentPath;
        /// <summary>
        /// agentPath属性
        /// </summary>
        public static string agentPath
        {
            get
            {
                _agentPath = IniControl.ReadIni("setup", "agentPath");
                return _agentPath;
            }
            set
            {
                _agentPath = value;
                IniControl.WriteIni("setup", "agentPath", _agentPath);
            }
        }

        private static bool _isNoRemindAgain;
        /// <summary>
        /// 是否Twitch正版登陆属性
        /// </summary>
        public static bool isNoRemindAgain
        {
            get
            {
                _isNoRemindAgain = Convert.ToBoolean(IniControl.ReadIni("laucher", "isNoRemindAgain"));
                return _isNoRemindAgain;
            }
            set
            {
                _isNoRemindAgain = value;
                IniControl.WriteIni("laucher", "isNoRemindAgain", Convert.ToString(_isNoRemindAgain));
            }
        }

    }
}
