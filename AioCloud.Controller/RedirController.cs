namespace AioCloud.Controller
{
    public class RedirController : Interface.IController
    {
        /// <summary>
        ///     守护
        /// </summary>
        public Tool.Guard Guard;

        public bool Enable(Model.Game rix)
        {
            // 创建守护
            this.Guard = new Tool.Guard();

            return false;
        }

        public void Disable()
        {
            this.Guard.Disable();
        }
    }
}
