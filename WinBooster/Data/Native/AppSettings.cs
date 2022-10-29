using System.IO;
using System.Web.Script.Serialization;

namespace WinBooster
{
    public class AppSettings<T> where T : new()
    {
        private const string DEFAULT_FILENAME = "settings.json";

        public void Save(string fileName = DEFAULT_FILENAME)
        {
            string text = (new JavaScriptSerializer()).Serialize(this);
            File.WriteAllText(fileName, text);
        }

        public static void Save(T pSettings, string fileName = DEFAULT_FILENAME)
        {
            string text = (new JavaScriptSerializer()).Serialize(pSettings);
            File.WriteAllText(fileName, text);
        }

        public static T Load(string fileName = DEFAULT_FILENAME)
        {
            T t = new T();
            if (File.Exists(fileName))
            {
                string text = File.ReadAllText(fileName);
                t = (new JavaScriptSerializer()).Deserialize<T>(text);
            }
            return t;
        }
    }
}
