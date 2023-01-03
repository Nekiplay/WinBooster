using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using WinBooster.Native;

namespace WinBooster.Optimize
{
    public class EnergyClass
    {
        /* Получение текущих схем электропитанмя */
        public List<Tuple<string, string, bool>> ListSchemes()
        {
            var list = new List<Tuple<string, string, bool>>();
            List<string> cmdtext = new ProcessUtils().StartCmd("chcp 1251 & powercfg /L");
            foreach (string text in cmdtext)
            {
                string text1 = text;
                if (!string.IsNullOrEmpty(GetSchemeID(text1)))
                {
                    text1 = text1.Replace(" (", "&");
                    text1 = text1.Replace(")", "&");
                    string type = Regex.Match(text1, "&(.*)&").Groups[1].Value;
                    string id = GetSchemeID(text1);
                    if (text1.Contains("*"))
                    {
                        list.Add(new Tuple<string, string, bool>(id, type, true));
                    }
                    else
                    {
                        list.Add(new Tuple<string, string, bool>(id, type, false));
                    }
                }
            }
            return list;
        }
        /* Получение ID схемы из списка текста в CMD */
        private string GetSchemeID(List<string> cmdtext)
        {
            string id = "";
            foreach (string text in cmdtext)
            {
                if (string.IsNullOrEmpty(id))
                {
                    id = GetSchemeID(text);
                }
            }
            return id;
        }
        /* Получение ID схемы из текста в CMD */
        private string GetSchemeID(string text)
        {
            string text1 = text;
            if (!string.IsNullOrEmpty(text1))
            {
                if (text1.Contains("GUID"))
                {
                    text1 = text1.Replace(" (", "&");
                    text1 = text1.Replace(")", "&");
                    string id = Regex.Match(text1, "GUID схемы питания: (.*) &").Groups[1].Value;
                    return id;
                }
            }
            return "";
        }
        /* Создание схема с максимальной производительностью */
        public string CreateMaximum()
        {
            List<string> cmdtext = new ProcessUtils().StartCmd("chcp 1251 & powercfg -duplicatescheme e9a42b02-d5df-448d-aa00-03f14749eb61");
            return GetSchemeID(cmdtext);
        }
        /* Установка активной схемы */
        public void SetActiv(string id)
        {
            new ProcessUtils().StartCmd("chcp 1251 & powercfg -SETACTIVE " + id);
        }
        /* Удаление схема */
        public void Delete(string id)
        {
            new ProcessUtils().StartCmd("chcp 1251 & powercfg /d " + id);
        }
        /* Включение и выключение */
        public void Enable(bool on)
        {
            List<Tuple<string, string, bool>> schems = ListSchemes();
            if (on)
            {
                bool find = false;
                foreach (var s in schems)
                {
                    if (s.Item2 == "Максимальная производительность")
                    {
                        find = true;
                        SetActiv(s.Item1);
                        break;
                    }
                }
                if (!find)
                {
                    string id = CreateMaximum();
                    if (!string.IsNullOrEmpty(id))
                    {
                        SetActiv(id);
                    }
                }
            }
            else
            {
                string standart = "";
                foreach (var s in schems)
                {
                    if (s.Item2 == "Сбалансированная")
                    {
                        SetActiv(s.Item1);
                        standart = s.Item1;
                    }
                }
                foreach (var s in schems)
                {
                    if (s.Item2 == "Максимальная производительность")
                    {
                        if (!string.IsNullOrEmpty(standart))
                        {
                            SetActiv(standart);
                        }
                        Delete(s.Item1);
                    }
                }
            }
        }
    }
}
