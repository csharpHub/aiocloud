using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace AioCloud.Utils
{
    /// <summary>
    ///     多语言
    /// </summary>
    public static class i18N
    {
        /// <summary>
        ///     语言代码
        /// </summary>
        public static string Code;

        /// <summary>
        ///     翻译数据
        /// </summary>
        public static Hashtable List;

        /// <summary>
        ///     加载
        /// </summary>
        public static void Load()
        {
            List = new Hashtable();

            if (Global.Language.Code.Equals("default"))
            {
                Code = CultureInfo.CurrentCulture.Name;
            }

            if (Code.Equals("en-US"))
            {
                return;
            }

            if (!File.Exists($"i18N\\{Code}.json"))
            {
                return;
            }

            var text = File.ReadAllText($"i18N\\{Code}.json");
            var list = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, string>>(text);
            if (list != null)
            {
                foreach (var v in list)
                {
                    List.Add(v.Key, v.Value);
                }
            }
        }

        /// <summary>
        ///     翻译
        /// </summary>
        /// <param name="s">需要翻译的文本</param>
        /// <returns>翻译完毕的文本</returns>
        public static string Get(string s)
        {
            return List.Contains(s) ? List[s].ToString() : s;
        }

        /// <summary>
        ///     翻译
        /// </summary>
        /// <param name="s">需要翻译的文本</param>
        /// <returns>翻译完毕的文本</returns>
        public static string Get(params string[] ss)
        {
            var sb = new StringBuilder();
            foreach (var s in ss)
            {
                sb.Append(Get(s));
            }

            return sb.ToString();
        }

        /// <summary>
        ///     获取语言列表
        /// </summary>
        /// <returns></returns>
        public static List<string> GetList()
        {
            var list = new List<string> { "default" };

            if (!Directory.Exists("i18N"))
            {
                return list;
            }

            var di = new DirectoryInfo("i18N");
            foreach (var f in di.GetFiles("*.json"))
            {
                if (f.Length < 0)
                {
                    continue;
                }

                list.Add(f.Name);
            }

            return list;
        }
    }
}
