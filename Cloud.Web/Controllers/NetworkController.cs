using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cloud.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Cloud.Web.Controllers
{
    public class NetworkController : Controller
    {
        private const string url = "http://am.e2e100.com";
        //private const string url = "http://localhost:58888";
        [HttpPost]
        public string Call(CallObject obj)
        {
            obj.Url = url + obj.Url;
            var str = string.Empty;
            switch (obj.Type.ToLower())
            {
                case "get":
                    var value = obj.Data == null
                        ? null
                        : JsonConvert.DeserializeObject<Dictionary<string, string>>(obj.Data);
                    str = Network.DoGet(obj.Url, value).Result;
                    break;
                case "post":
                    str = Network.DoPost(obj.Url, obj.Data ?? "{}").Result;
                    break;
            }
            return str;
        }
    }
}
