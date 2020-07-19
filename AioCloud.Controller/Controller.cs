namespace AioCloud.Controller
{
    public class Controller : Interface.IController
    {
        /// <summary>
        ///     游戏
        /// </summary>
        public Model.Game LastGame;

        public bool Enable(Model.Game rix)
        {
            return false;
        }

        public void Disable()
        {

        }
    }
}
