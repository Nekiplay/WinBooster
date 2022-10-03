using System.Collections.Generic;

namespace WinBooster.Optimize
{
    public class GybernateClass
    {
        /* Проверяем включение */
        public bool Activated()
        {
            List<string> cmdtext = new ProcessUtils().StartCmd("chcp 1251 & powercfg /a");
            foreach (string text in cmdtext)
            {
                string text1 = text;
                if (!string.IsNullOrEmpty(text1))
                {
                    if (text1.Contains("Режим гибернации не включен"))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        /* Включаем и выключаем */
        public void Enable(bool on)
        {
            new ProcessUtils().StartCmd("chcp 1251 & powercfg /h " + on.ToString().Replace("True", "on").Replace("False", "off"));
        }
    }
}
