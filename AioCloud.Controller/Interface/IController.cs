namespace AioCloud.Controller.Interface
{
    public interface IController
    {
        /// <summary>
        ///     启用
        /// </summary>
        /// <returns>是否成功</returns>
        bool Enable(Model.Game rix);

        /// <summary>
        ///     禁用
        /// </summary>
        void Disable();
    }
}
