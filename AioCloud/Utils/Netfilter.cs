using System;
using System.Diagnostics;
using System.IO;
using System.ServiceProcess;

namespace AioCloud.Utils
{
    /// <summary>
    ///     nfapinet
    /// </summary>
    public static class Netfilter
    {
        /// <summary>
        ///     驱动名
        /// </summary>
        public static string DriverName = "Win-10.sys";

        /// <summary>
        ///     加载
        /// </summary>
        public static bool Load()
        {
            switch ($"{Environment.OSVersion.Version.Major}.{Environment.OSVersion.Version.Minor}")
            {
                case "10.0":
                    DriverName = "Win-10.sys";
                    break;
                case "6.3":
                case "6.2":
                    DriverName = "Win-8.sys";
                    break;
                case "6.1":
                case "6.0":
                    DriverName = "Win-7.sys";
                    break;
                default:
                    return false;
            }

            return Update();
        }

        /// <summary>
        ///     获取版本信息
        /// </summary>
        /// <param name="s">位置</param>
        /// <returns>版本信息</returns>
        public static string GetVersionInfo(string s)
        {
            return File.Exists(s) ? FileVersionInfo.GetVersionInfo(s).FileVersion : String.Empty;
        }

        /// <summary>
        ///     安装驱动
        /// </summary>
        /// <returns>是否安装成功</returns>
        public static bool Create()
        {
            // 复制驱动
            try
            {
                File.Copy($"Bin\\Driver\\Redir\\{DriverName}", $"{Environment.SystemDirectory}\\drivers\\netfilter2.sys");
            }
            catch (Exception)
            {
                return false;
            }

            // 注册驱动
            return nfapinet.NFAPI.nf_registerDriver("netfilter2") == nfapinet.NF_STATUS.NF_STATUS_SUCCESS;
        }

        /// <summary>
        ///     卸载驱动
        /// </summary>
        /// <returns>是否成功卸载</returns>
        public static bool Delete()
        {
            // 停止驱动运行
            try
            {
                var service = new ServiceController("netfilter2");
                if (service.Status == ServiceControllerStatus.Running)
                {
                    service.Stop();
                    service.WaitForStatus(ServiceControllerStatus.Stopped);
                }
            }
            catch (Exception)
            {
                return false;
            }

            // 取消注册驱动
            if (File.Exists($"{Environment.SystemDirectory}\\drivers\\netfilter2.sys"))
            {
                if (nfapinet.NFAPI.nf_unRegisterDriver("netfilter2") != nfapinet.NF_STATUS.NF_STATUS_SUCCESS)
                {
                    return false;
                }
            }

            // 删除驱动文件
            try
            {
                File.Delete($"{Environment.SystemDirectory}\\drivers\\netfilter2.sys");
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        ///     更新驱动文件
        /// </summary>
        /// <returns></returns>
        public static bool Update()
        {
            // 检查驱动是否已安装
            if (!File.Exists($"{Environment.SystemDirectory}\\drivers\\netfilter2.sys"))
            {
                return Create();
            }

            // 对比驱动文件版本
            if (!GetVersionInfo($"Bin\\Driver\\Redir\\{DriverName}").Equals(GetVersionInfo($"{Environment.SystemDirectory}\\drivers\\netfilter2.sys")))
            {
                // 卸载驱动
                if (!Delete())
                {
                    return false;
                }

                // 安装驱动
                if (!Create())
                {
                    return false;
                }
            }

            return true;
        }
    }
}
