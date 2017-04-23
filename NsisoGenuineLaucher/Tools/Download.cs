using KMCCC.Launcher;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace NsisoGenuineLaucher.Tools
{
    class Download
    {
        public List<string> CountlostFlie = new List<string>();

        /// <summary>
        /// 检查选中版本是否丢失游戏运行库文件并返回丢失数量
        /// </summary>
        /// <param name="ver">检查的版本</param>
        /// <returns></returns>
        public int IsLost(KMCCC.Launcher.Version ver)
        {
            CountlostFlie.Clear();//清空列表，防止重新启动后，列表重复
            var core = LauncherCore.Create();
            try
            {
                var libs = ver.Libraries.Select(lib => core.GetLibPath(lib));
                var natives = ver.Natives.Select(native => core.GetNativePath(native));

                foreach (string libflie in libs)
                {
                    if (!File.Exists(libflie))
                    {
                        CountlostFlie.Add(libflie);
                    }
                }

                foreach (string libflie in natives)
                {
                    if (!File.Exists(libflie))
                    {
                        CountlostFlie.Add(libflie);
                    }
                }
                return CountlostFlie.Count;

            }
            catch
            {
                return 0;
            }
        }

        public List<string> lostFlie = new List<string>();

        /// <summary>
        /// 下载丢失的文件
        /// </summary>
        /// <param name="ver">要下载的版本</param>
        public void DownloadLostFlie(KMCCC.Launcher.Version ver)
        {
            try
            {
                var core = LauncherCore.Create();

                var libs = ver.Libraries.Select(lib => core.GetLibPath(lib));
                var natives = ver.Natives.Select(native => core.GetNativePath(native));

                foreach (string libflie in libs)
                {
                    if (!File.Exists(libflie))
                    {
                        lostFlie.Add(libflie);
                        downloadLib(libflie);
                    }
                }

                foreach (string libflie in natives)
                {
                    if (!File.Exists(libflie))
                    {
                        lostFlie.Add(libflie);
                        downloadLib(libflie);
                    }
                }

                return;
            }
            catch
            {

            }
        }

        /// <summary>
        /// 实现下载
        /// </summary>
        /// <param name="libflie">libpath</param>
        public void downloadLib(string libflie)
        {
            try
            {
                if (!Directory.Exists(libflie.Substring(0, libflie.LastIndexOf("\\") + 1)))
                {
                    Directory.CreateDirectory(libflie.Substring(0, libflie.LastIndexOf("\\") + 1));
                }
                string lostFlieUrl = libflie.Substring(libflie.IndexOf(@"\.minecraft\libraries"));
                string URLHead = @"http:\\bmclapi.bangbang93.com";
                string URLBody = lostFlieUrl.Substring(lostFlieUrl.IndexOf(@"\libraries"));
                string URLPath = libflie;
                string URLe = URLHead + URLBody;
                string URL = URLe.Replace(@"\", "/");
                System.Net.HttpWebRequest Myrq = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(URL);
                System.Net.HttpWebResponse myrp = (System.Net.HttpWebResponse)Myrq.GetResponse();
                Stream st = myrp.GetResponseStream();
                Stream so = new FileStream(URLPath, FileMode.Create);
                byte[] by = new byte[1024];
                int osize = st.Read(by, 0, (int)by.Length);
                while (osize > 0)
                {
                    so.Write(by, 0, osize);
                    osize = st.Read(by, 0, (int)by.Length);
                }
                so.Close();
                st.Close();
                myrp.Close();
                Myrq.Abort();
            }
            catch
            {

            }
        }
    }
}
