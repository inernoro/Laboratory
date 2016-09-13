using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Configuration.Startup;
using Abp.Runtime.Caching;
using Abp.Runtime.Caching.Configuration;
using Castle.MicroKernel.Registration;
using NSubstitute;
using Shouldly;
using StackExchange.Redis;
using Xunit;

namespace TestRedis
{
    public class Program : TestBaseWithLocalIocManager
    {
        //   private readonly ITypedCache<string, MyCacheItem> _cache; 

        public Program()
        {
        }

        private static void Main(string[] args)
        {
            var p = new Program();

            p.Simple_Get_Set_Test();
        }


        [Theory]
        public void Simple_Get_Set_Test()
        {
            while (true)
            {
                var dt = DateTime.Now;
                var data = DapperHelper.QueryAll<UserInfo>();
                Console.WriteLine((DateTime.Now - dt).TotalMilliseconds);
                Console.ReadKey();
            }

        }

        [Serializable]
        public class MyCacheItem
        {
            public int Value { get; set; }
            public string Name { get; set; }
        }
    }
}
