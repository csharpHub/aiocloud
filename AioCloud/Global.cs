using System;
using System.Collections.Generic;
using System.IO;

namespace AioCloud
{
    /// <summary>
    ///     全局变量
    /// </summary>
    public static class Global
    {
        /// <summary>
        ///     通用设置
        /// </summary>
        public static Model.Config.Global Generic;

        /// <summary>
        ///     语言设置
        /// </summary>
        public static Model.Config.Language Language;

        /// <summary>
        ///     游戏列表
        /// </summary>
        public static List<Model.Game> List;

        /// <summary>
        ///     加载配置
        /// </summary>
        public static void Load()
        {
            // 设置当前目录
            Directory.SetCurrentDirectory(AppDomain.CurrentDomain.BaseDirectory);

            if (!Directory.Exists("Data"))
            {
                Directory.CreateDirectory("Data");
            }

            if (!Directory.Exists("i18N"))
            {
                Directory.CreateDirectory("i18N");
            }

            if (!Directory.Exists("Logs"))
            {
                Directory.CreateDirectory("Logs");
            }

            if (File.Exists("Data\\Global"))
            {
                var text = File.ReadAllText("Data\\Global");
                Generic = Newtonsoft.Json.JsonConvert.DeserializeObject<Model.Config.Global>(text);
            }
            else
            {
                Generic = new Model.Config.Global();
            }

            if (File.Exists("Data\\Language"))
            {
                var text = File.ReadAllText("Data\\Language");
                Language = Newtonsoft.Json.JsonConvert.DeserializeObject<Model.Config.Language>(text);
            }
            else
            {
                Language = new Model.Config.Language();
            }

            if (File.Exists("Data\\List"))
            {
                var text = File.ReadAllText("Data\\List");
                List = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Model.Game>>(text);
            }
            else
            {
                List = new List<Model.Game>();
            }

            Utils.i18N.Load();
        }

        /// <summary>
        ///     保存配置
        /// </summary>
        public static void Save()
        {
            File.WriteAllText("Data\\Global", Newtonsoft.Json.JsonConvert.SerializeObject(Generic));
            File.WriteAllText("Data\\Language", Newtonsoft.Json.JsonConvert.SerializeObject(Language));
            File.WriteAllText("Data\\List", Newtonsoft.Json.JsonConvert.SerializeObject(List));
        }
    }
}
