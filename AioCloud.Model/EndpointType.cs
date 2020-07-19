namespace AioCloud.Model
{
    /// <summary>
    ///     终点类型
    /// </summary>
    public enum EndpointType : int
    {
        /// <summary>
        ///     Socks5
        /// </summary>
        Socks5,

        /// <summary>
        ///     Shadowsocks
        /// </summary>
        Shadowsocks,

        /// <summary>
        ///     ShadowsocksR
        /// </summary>
        ShadowsocksR,

        /// <summary>
        ///     Trojan
        /// </summary>
        Trojan,

        /// <summary>
        ///     VMess
        /// </summary>
        VMess
    }
}
