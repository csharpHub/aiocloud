namespace AioCloud.Model
{
    /// <summary>
    ///     终点
    /// </summary>
    public class Endpoint
    {
        /// <summary>
        ///     类型
        /// </summary>
        public EndpointType Type;

        /// <summary>
        ///     群组
        /// </summary>
        public string Group;

        /// <summary>
        ///     备注
        /// </summary>
        public string Remark;

        /// <summary>
        ///     主机名
        /// </summary>
        public string Hostname;

        /// <summary>
        ///     端口
        /// </summary>
        public int Port;

        /// <summary>
        ///     密码
        /// </summary>
        public string Password;

        /// <summary>
        ///     加密
        /// </summary>
        public string EncryptMethod;

        /// <summary>
        ///     协议 [SSR]
        /// </summary>
        public string Proto;

        /// <summary>
        ///     协议参数 [SSR]
        /// </summary>
        public string ProtoParam;

        /// <summary>
        ///     混淆 [SSR]
        /// </summary>
        public string OBFS;

        /// <summary>
        ///     混淆参数 [SSR]
        /// </summary>
        public string OBFSParam;
    }
}
