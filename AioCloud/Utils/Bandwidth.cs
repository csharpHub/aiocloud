using System;

namespace AioCloud.Utils
{
    /// <summary>
    ///     流量
    /// </summary>
    public static class Bandwidth
    {
        /// <summary>
        ///     计算流量
        /// </summary>
        /// <param name="bandwidth">流量</param>
        /// <returns>带单位的流量字符串</returns>
        public static string Compute(ulong bandwidth)
        {
            String[] units = { "KB", "MB", "GB", "TB", "PB" };
            double result = bandwidth;

            var i = -1;
            do
            {
                i++;
            } while ((result /= 1024) > 1024);

            if (result < 0)
            {
                result = 0;
            }

            return String.Format("{0} {1}", Math.Round(result, 2), units[i]);
        }
    }
}
