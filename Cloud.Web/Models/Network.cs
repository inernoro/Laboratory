using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Cloud.Web.Models
{
    public static class Network
    {

        /// <summary>
        /// HttpClient实现Post请求
        /// </summary>
        public static Task<string> DoPost(string url, string parament)
        {
            var handler = new HttpClientHandler
            {
                AutomaticDecompression = DecompressionMethods.GZip
            };
            using (var http = new HttpClient(handler))
            {
                HttpContent content = new StringContent(parament);
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var response = http.PostAsync(url, content).Result;
                response.EnsureSuccessStatusCode();
                var resultValue = response.Content.ReadAsStringAsync();
                return resultValue;
            }
        }

        /// <summary>
        /// HttpClient实现Get请求
        /// </summary>
        public static Task<string> DoGet(string url, IEnumerable<KeyValuePair<string, string>> dictionary = null)
        {
            if (dictionary == null)
                dictionary = new Dictionary<string, string>();
            var handler = new HttpClientHandler
            {
                AutomaticDecompression = DecompressionMethods.GZip
            };
            using (var http = new HttpClient(handler))
            {
                url += GetUrl(dictionary.ToList());
                var getMessage = http.GetAsync(url);
                getMessage.Wait();
                var response = getMessage.Result;
                response.EnsureSuccessStatusCode();
                return response.Content.ReadAsStringAsync();
            }
        }

        public static string GetUrl(List<KeyValuePair<string, string>> dictionary)
        {
            if (!dictionary.Any())
            {
                return "";
            }
            if (dictionary.Count > 1)
            {
                return "?" + dictionary.Aggregate(string.Empty, (x, y) => x += "&" + y.Key + "=" + y.Value).Substring(1);
            }
            return "?" + dictionary.First().Key + "=" + dictionary.First().Value;
        }
    }
}