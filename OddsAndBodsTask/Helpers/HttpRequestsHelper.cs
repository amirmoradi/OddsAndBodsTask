using Newtonsoft.Json;
using System;
using System.Net;
using System.Text;

namespace OddsAndBodsTask.Helpers
{
    public class HttpRequestsHelper
    {
        public static dynamic ExecuteGetRequest<T>(string url)
        {
            using (var client = new WebClient())
            {
                try
                {
                    SetProtocol();
                    client.Encoding = Encoding.UTF8;
                    var response = client.DownloadString(url);
                    if (typeof(T) == typeof(string) && response == "") return "";
                    if (typeof(T) == typeof(WebHeaderCollection)) return client.ResponseHeaders;
                    return JsonConvert.DeserializeObject<T>(response);
                }
                catch (Exception exc)
                {
                    LogHelper.SubmitLog(exc.Message, LogType.Error);
                    return exc.Message;
                }
            }
        }

        public static void SetProtocol()
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
        }
    }
}
