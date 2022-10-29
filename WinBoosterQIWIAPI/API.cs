using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WinBoosterQIWIAPI
{
    public class API
    {
        public class Wallet
        {
            public _Balance_ Balance;
            public _Identification_ Identification;

            private readonly string token;
            public Wallet(string token)
            {
                this.token = token;
                this.Balance = new _Balance_(this.token);
                this.Identification = new _Identification_(this.token);
            }

            public class _Identification_
            {
                private string token;
                public _Identification_(string token)
                {
                    this.token = token;
                }
                public string Nickname(string phone)
                {
                    using (WebClient wc = new WebClient())
                    {
                        wc.Encoding = Encoding.UTF8;
                        wc.Headers.Set("authorization", "Bearer " + this.token);
                        string response = wc.DownloadString("https://edge.qiwi.com//qw-nicknames/v1/persons/" + phone + "/nickname");
                        string First_Name = Regex.Match(response, "\"nickname\":\"(.*)\",\"canChange\":(.*)").Groups[1].Value;
                        if (First_Name != "")
                        {
                            return First_Name;
                        }
                    }
                    return "";
                }
                public string First_Name(string phone)
                {
                    using (WebClient wc = new WebClient())
                    {
                        wc.Encoding = Encoding.UTF8;
                        wc.Headers.Set("authorization", "Bearer " + this.token);
                        string response = wc.DownloadString("https://edge.qiwi.com/identification/v1/persons/" + phone + "/identification");
                        string First_Name = Regex.Match(response, "\"firstName\":\"(.*)\",\"middleName\":\"(.*)\",\"lastName\":\"(.*)\"").Groups[1].Value;
                        if (First_Name != "")
                        {
                            return First_Name;
                        }
                    }
                    return "";
                }
                public string Middle_Name(string phone)
                {
                    using (WebClient wc = new WebClient())
                    {
                        wc.Encoding = Encoding.UTF8;
                        wc.Headers.Set("authorization", "Bearer " + this.token);
                        string response = wc.DownloadString("https://edge.qiwi.com/identification/v1/persons/" + phone + "/identification");
                        string Middle_Name = Regex.Match(response, "\"firstName\":\"(.*)\",\"middleName\":\"(.*)\",\"lastName\":\"(.*)\"").Groups[2].Value;
                        if (Middle_Name != "")
                        {
                            return Middle_Name;
                        }
                    }
                    return "";
                }
                public string Last_Name(string phone)
                {
                    using (WebClient wc = new WebClient())
                    {
                        wc.Encoding = Encoding.UTF8;
                        wc.Headers.Set("authorization", "Bearer " + this.token);
                        string response = wc.DownloadString("https://edge.qiwi.com/identification/v1/persons/" + phone + "/identification");
                        string Last_Name = Regex.Match(response, "\"lastName\":\"(.*)\",\"birthDate\":\"(.*)\"").Groups[1].Value;
                        if (Last_Name != "")
                        {
                            return Last_Name;
                        }
                    }
                    return "";
                }
                public string Phone()
                {
                    using (WebClient wc = new WebClient())
                    {
                        wc.Headers.Set("authorization", "Bearer " + this.token);
                        string response = wc.DownloadString("https://edge.qiwi.com/person-profile/v1/profile/current?authInfoEnabled=true&contractInfoEnabled=true&userInfoEnabled=true");
                        string phone = Regex.Match(response, "\"personId\":(.*),\"registrationDate\":\"(.*)\"").Groups[1].Value;
                        if (phone != "")
                        {
                            return phone;
                        }
                    }
                    return "";
                }
                public string Mail()
                {
                    using (WebClient wc = new WebClient())
                    {
                        wc.Headers.Set("authorization", "Bearer " + this.token);
                        string response = wc.DownloadString("https://edge.qiwi.com/person-profile/v1/profile/current?authInfoEnabled=true&contractInfoEnabled=true&userInfoEnabled=true");
                        string mail = Regex.Match(response, "\"boundEmail\":\"(.*)\",\"emailSettings\"").Groups[1].Value;
                        if (mail != "")
                        {
                            return mail;
                        }
                    }
                    return "";
                }
            }
            public class _Balance_
            {
                private string token;
                public _Transfer_ Transfer;

                public _Balance_(string token)
                {
                    this.token = token;
                    this.Transfer = new _Transfer_(this.token);
                }
                public class _Transfer_
                {
                    private string token;
                    public _Transfer_(string token)
                    {
                        this.token = token;
                    }

                    public bool QIWI_RUB_Phone(string phone, double ammount, string comment)
                    {
                        Int32 unixTimestamp = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;

                        string jsonv2 = "{\"id\":\"" + 1000 * unixTimestamp + "\",\"sum\":{\"amount\":" + ammount + ",\"currency\":\"" + "643" + "\"},\"paymentMethod\":{\"type\":\"Account\",\"accountId\":\"643\"},\"comment\":\"" + comment + "\",\"fields\":{\"account\":\"" + phone + "\"}}";

                        /* Отправка */
                        try
                        {
                            WebRequest request = WebRequest.Create("https://edge.qiwi.com/sinap/api/v2/terms/99/payments");
                            request.Method = "POST";
                            byte[] byteArray = System.Text.Encoding.UTF8.GetBytes(jsonv2);
                            request.ContentType = "application/json";
                            request.Headers["Authorization"] = "Bearer " + this.token;
                            request.ContentLength = byteArray.Length;

                            //записываем данные в поток запроса
                            using (Stream dataStream = request.GetRequestStream())
                            {
                                dataStream.Write(byteArray, 0, byteArray.Length);
                            }

                            WebResponse response = request.GetResponse();
                            using (Stream stream = response.GetResponseStream())
                            {
                                using (StreamReader reader = new StreamReader(stream))
                                {
                                    string read = reader.ReadToEnd();
                                    return true;
                                }
                            }
                        }
                        catch (WebException ex)
                        {
                            return false;
                        }
                        return false;
                    }
                    public enum CardType
                    {
                        Visa,
                        MasterCard,
                        MIR,
                        QIWI_Virtual,
                    }
                    public bool QIWI_RUB_Nickname(string phone, double ammount, string comment)
                    {
                        Int32 unixTimestamp = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;

                        string jsonv2 = "{\"id\":\"" + unixTimestamp * 1000 + "\",\"sum\":{\"amount\":1,\"currency\":\"643\"},\"paymentMethod\":{\"accountId\":\"643\",\"type\":\"Account\"},\"fields\":{\"account\":\"Nekiplay\",\"accountType\":\"nickname\",\"comment\":\"1\"}}";

                        /* Отправка */
                        try
                        {
                            WebRequest request = WebRequest.Create("https://edge.qiwi.com/sinap/api/v2/terms/99999/payments");
                            request.Method = "POST";
                            byte[] byteArray = System.Text.Encoding.UTF8.GetBytes(jsonv2);
                            request.ContentType = "application/json";
                            request.Headers["Authorization"] = "Bearer " + this.token;
                            request.ContentLength = byteArray.Length;

                            //записываем данные в поток запроса
                            using (Stream dataStream = request.GetRequestStream())
                            {
                                dataStream.Write(byteArray, 0, byteArray.Length);
                            }

                            WebResponse response = request.GetResponse();
                            using (Stream stream = response.GetResponseStream())
                            {
                                using (StreamReader reader = new StreamReader(stream))
                                {
                                    string read = reader.ReadToEnd();
                                    return true;
                                }
                            }
                            response.Close();
                        }
                        catch (WebException ex)
                        {
                            return false;
                        }
                        return false;
                    }
                    public bool QIWI_RUB_Card(CardType card, string cardadres, double ammount, string comment)
                    {
                        cardadres = cardadres.Replace(" ", "");
                        Int32 unixTimestamp = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;

                        string jsonv2 = "{\"id\":\"" + 1000 * unixTimestamp + "\",\"sum\":{\"amount\":" + ammount + ",\"currency\":\"" + "643" + "\"},\"paymentMethod\":{\"type\":\"Account\",\"accountId\":\"643\"},\"comment\":\"" + comment + "\",\"fields\":{\"account\":\"" + cardadres + "\"}}";

                        /* Отправка */
                        try
                        {
                            string id = "1963";
                            if (card == CardType.MasterCard)
                            {
                                id = "21013";
                            }
                            else if (card == CardType.Visa)
                            {
                                id = "1963";
                            }
                            else if (card == CardType.MIR)
                            {
                                id = "31652";
                            }
                            else if (card == CardType.QIWI_Virtual)
                            {
                                id = "22351";
                            }
                            WebRequest request = WebRequest.Create("https://edge.qiwi.com/sinap/api/v2/terms/" + id + "/payments");
                            request.Method = "POST";
                            byte[] byteArray = System.Text.Encoding.UTF8.GetBytes(jsonv2);
                            request.ContentType = "application/json";
                            request.Headers["Authorization"] = "Bearer " + this.token;
                            request.ContentLength = byteArray.Length;

                            //записываем данные в поток запроса
                            using (Stream dataStream = request.GetRequestStream())
                            {
                                dataStream.Write(byteArray, 0, byteArray.Length);
                            }

                            WebResponse response = request.GetResponse();
                            using (Stream stream = response.GetResponseStream())
                            {
                                using (StreamReader reader = new StreamReader(stream))
                                {
                                    string read = reader.ReadToEnd();
                                    return true;
                                }
                            }
                            response.Close();
                        }
                        catch
                        {
                            return false;
                        }
                    }
                }
                public double RUB(string phone)
                {
                    using (WebClient wc = new WebClient())
                    {
                        wc.Headers.Set("authorization", "Bearer " + this.token);
                        string response = wc.DownloadString("https://edge.qiwi.com/funding-sources/v2/persons/" + phone + "/accounts");
                        string rubles = Regex.Match(response, "\"balance\":{\"amount\":(.*),\"currency\":643}").Groups[1].Value;
                        if (rubles != "")
                        {
                            rubles = rubles.Replace(".", ",").Replace(" ", "");
                            double rub = double.Parse(rubles);
                            return rub;
                        }
                        else
                        {
                            return 0.0;
                        }
                    }
                }
                public double USD(string phone)
                {
                    using (WebClient wc = new WebClient())
                    {
                        wc.Headers.Set("authorization", "Bearer " + this.token);
                        string response = wc.DownloadString("https://edge.qiwi.com/funding-sources/v2/persons/" + phone + "/accounts");
                        string usds = Regex.Match(response, "{\"alias\":\"qw_wallet_usd\",\"fsAlias\":\"qb_wallet\",\"bankAlias\":\"QIWI\",\"title\":\"Qiwi Account\",\"type\":{\"id\":\"WALLET\",\"title\":\"Visa QIWI Wallet\"},\"hasBalance\":(.*),\"balance\":{\"amount\":(.*),\"currency\":840},\"currency\":840,\"defaultAccount\":(.*)}").Groups[2].Value;
                        if (usds != "")
                        {
                            usds = usds.Replace(" ", "").Replace(".", ",");
                            double usd = double.Parse(usds);
                            return usd;
                        }
                        else
                        {
                            return 0.0;
                        }
                    }
                }
            }
        }
        public class Donation
        {
            private readonly string token;

            private List<Action<Event>> onDonation { get; set; }
            public Donation(string token, List<Action<Event>> onDonation, bool updater = true)
            {
                this.token = token;
                this.onDonation = onDonation;
                if (updater)
                {
                    StartAsync();
                }
            }
            public Donation(string token, Action<Event> onDonation, bool updater = true)
            {
                this.token = token;
                this.onDonation = new List<Action<Event>>();
                this.onDonation.Add(onDonation);
                if (updater)
                {
                    StartAsync();
                }
            }
            public class Amount
            {
                public double value { get; set; }
                public string currency { get; set; }
            }

            public class Message
            {
                public string messageExtId { get; set; }
                public Amount amount { get; set; }
                public string senderName { get; set; }
                public string message { get; set; }
            }

            public class DonateResponse
            {
                public string widgetGroupExtId { get; set; }
                public int limit { get; set; }
                public List<Message> messages { get; set; }
            }
            public DonateResponse GetLastMessage()
            {
                using (WebClient wc = new WebClient())
                {
                    wc.Encoding = Encoding.UTF8;
                    string response = wc.DownloadString("https://donate.qiwi.com/api/stream/v1/statistics/" + token + "/last-messages?&limit=1");
                    DonateResponse myDeserializedClass = JsonConvert.DeserializeObject<DonateResponse>(response);
                    return myDeserializedClass;
                }
            }
            public string GetDonateLink(string login, string senderName, string message, double ammount, string currency = "RUB")
            {
                try
                {
                    string ammounts = (ammount.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture));
                    Int32 unixTimestamp = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
                    using (WebClient wc = new WebClient())
                    {

                        wc.Encoding = Encoding.UTF8;
                        wc.Headers.Set(HttpRequestHeader.ContentType, "application/json;charset=utf-8");
                        wc.Headers.Set(HttpRequestHeader.ContentEncoding, "br");
                        wc.Headers.Set(HttpRequestHeader.Cookie, "token-tail=" + (unixTimestamp * 1000) + "");
                        string link = UnicodeToUTF8(wc.UploadString("https://donate.qiwi.com/api/payment/v1/streamers/" + login + "/payments", "{\"amount\":{\"value\":\"" + ammounts + "\",\"currency\":\"" + currency + "\"},\"login\":\"" + login + "\",\"senderName\":\"" + senderName + "\",\"message\":\"" + message + "\"}"));
                        string linkdone = Regex.Match(link, "{\"redirectUrl\":\"(.*)\"}").Groups[1].Value;
                        return linkdone;
                    }
                }
                catch { }
                return "";
            }
            private string UnicodeToUTF8(string strFrom)
            {
                byte[] bytes = Encoding.Default.GetBytes(strFrom);

                return Encoding.UTF8.GetString(bytes);

            }

            public class Attributes
            {
                public string DONATION_SENDER { get; set; }
                public double DONATION_AMOUNT { get; set; }
                public string DONATION_CURRENCY { get; set; }
                public string DONATION_MESSAGE { get; set; }
            }

            public class Event
            {
                public string eventExtId { get; set; }
                public string type { get; set; }
                public string status { get; set; }
                public DateTime donateDatetime { get; set; }
                public Attributes attributes { get; set; }
                public List<object> voteResults { get; set; }
                public DateTime createDatetime { get; set; }
            }

            public class Donate
            {
                public string widgetGroupExtId { get; set; }
                public int limit { get; set; }
                public string queuePriority { get; set; }
                public List<Event> events { get; set; }
            }

            private void StartAsync()
            {
                ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                Task.Factory.StartNew(() =>
                {
                    while (true)
                    {
                        try
                        {
                            using (WebClient wc = new WebClient())
                            {
                                wc.Encoding = Encoding.UTF8;
                                string response = wc.DownloadString("https://donate.qiwi.com/api/stream/v1/widgets/" + this.token + "/events?&limit=1");
                                //Console.WriteLine(response);
                                Donate myDeserializedClass = JsonConvert.DeserializeObject<Donate>(response);
                                if (myDeserializedClass != null)
                                {
                                    foreach (Event e in myDeserializedClass.events)
                                    {
                                        if (e.type.Equals("DONATION"))
                                        {
                                            foreach (Action<Event> action in onDonation)
                                            {
                                                action(e);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        catch
                        {

                        }
                    }
                });
            }
        }
    }
}
