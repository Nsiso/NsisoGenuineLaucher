using NsisoGenuineLaucher.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NsisoGenuineLaucher.Tools
{
    class GetBest
    {
        /// <summary>
        /// 设置最佳内存
        /// </summary>
        public static void setBestMemory()
        {
            try
            {
                int bestMemory = 0;
                ulong Runmemory = KMCCC.Tools.SystemTools.GetRunmemory();
                if (KMCCC.Tools.SystemTools.GetArch() == "64")
                {
                    if (Runmemory > 4096)
                    {
                        bestMemory = 2048;
                    }
                    else if (Runmemory > 2048)
                    {
                        bestMemory = 1024;
                    }
                }
                else if (KMCCC.Tools.SystemTools.GetArch() == "32")
                {
                    if (Runmemory > 3072)
                    {
                        bestMemory = 2048;
                    }
                    else
                    {
                        bestMemory = 1024;
                    }
                }
                else
                {
                    bestMemory = 1024;
                }
                IniGS.maxMemory = bestMemory;
            }
            catch
            {
            }
        }

        public static void SetJavaPath()
        {
            try
            {
                IniGS.javaPath = KMCCC.Tools.SystemTools.FindJava().Last();
            }
            catch
            {
            }
        }
    }
}
