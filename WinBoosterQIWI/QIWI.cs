using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WinBoosterQIWI
{
    public class QIWI
    {
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
