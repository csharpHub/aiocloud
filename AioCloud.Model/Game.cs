using System.Collections.Generic;

namespace AioCloud.Model
{
    public class Game
    {
        /// <summary>
        ///     备注
        /// </summary>
        public string Remark;

        /// <summary>
        ///     TCP 终点
        /// </summary>
        public string TCPEndpoint;

        /// <summary>
        ///     UDP 终点
        /// </summary>
        public string UDPEndpoint;

        /// <summary>
        ///     模式
        /// </summary>
        public GameMode Mode;

        /// <summary>
        ///     规则
        /// </summary>
        public List<string> Rule;
    }
}
