namespace AioCloud.Model
{
    /// <summary>
    ///     状态
    /// </summary>
    public enum StatusInfo : int
    {
        /// <summary>
        ///     等待中
        /// </summary>
        Waiting,

        /// <summary>
        ///     启动中
        /// </summary>
        Starting,

        /// <summary>
        ///     已启动
        /// </summary>
        Started,

        /// <summary>
        ///     停止中
        /// </summary>
        Stopping,

        /// <summary>
        ///     已停止
        /// </summary>
        Stopped,

        /// <summary>
        ///     退出中
        /// </summary>
        Terminating
    }
}
