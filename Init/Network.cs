using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace Init
{
    public static class Network
    {

        #region CookieBase 

        /// <summary>
        /// HttpClient实现Post请求
        /// </summary>
        private static string DoPostLogin(string url, string parament, CookieContainer cookie)
        {
            var handler = new HttpClientHandler
            {
                AutomaticDecompression = DecompressionMethods.GZip,
                CookieContainer = cookie
            };
            using (var http = new HttpClient(handler))
            {
                HttpContent content = new StringContent(parament);
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var response = http.PostAsync(url, content).Result;
                response.EnsureSuccessStatusCode();
                cookie = handler.CookieContainer;
                var resultValue = response.Content.ReadAsStringAsync().Result;
                return resultValue;
            }
        }

        /// <summary>
        /// HttpClient实现Get请求
        /// </summary>
        private static string DoGetLogin(string url, string parament, CookieContainer cookie)
        {
            var handler = new HttpClientHandler
            {
                AutomaticDecompression = DecompressionMethods.GZip,
                CookieContainer = cookie
            };
            using (var http = new HttpClient(handler))
            {
                var getMessage = http.GetAsync(url);
                getMessage.Wait();
                var response = getMessage.Result;
                cookie = handler.CookieContainer;
                response.EnsureSuccessStatusCode();
                return response.Content.ReadAsStringAsync().Result;
            }
        }

        #endregion

        #region CookieBaseNotLogin

        /// <summary>
        /// HttpClient实现Post请求
        /// </summary>
        public static string DoPost(string url, string parament)
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
                var resultValue = response.Content.ReadAsStringAsync().Result;
                return resultValue;
            }
        }

        /// <summary>
        /// HttpClient实现Get请求
        /// </summary>
        public static string DoGet(string url, Dictionary<string, string> dictionary = null)
        {
            if (dictionary == null)
                dictionary = new Dictionary<string, string>();
            var handler = new HttpClientHandler
            {
                AutomaticDecompression = DecompressionMethods.GZip
            };
            using (var http = new HttpClient(handler))
            {
                var content = new FormUrlEncodedContent(dictionary);
                var getMessage = http.GetAsync(url);
                getMessage.Wait();
                var response = getMessage.Result;
                response.EnsureSuccessStatusCode();
                return response.Content.ReadAsStringAsync().Result;
            }
        }


        #endregion
    }
}