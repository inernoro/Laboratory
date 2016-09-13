using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ProtoBuf;
using ServiceStack.Redis;
using StackExchange.Redis;
using TestRedis;

namespace NewRedisTest
{
    class Program
    {

        static void Main(string[] args)
        {

            var _redis = new RedisClient("127.0.0.1", 6380);

            var redis = ConnectionMultiplexer.Connect("127.0.0.1:6380");

            var db = redis.GetDatabase();

            while (true)
            {

                var watch = new Stopwatch();

                watch.Start();
                var userlist = DapperHelper.QueryFrist<UserInfo>();
                watch.Stop();
                var stringstr = JsonConvert.SerializeObject(userlist);
                Console.WriteLine("dapper :" + watch.ElapsedMilliseconds);

                var watch1 = new Stopwatch();
                watch1.Start();
                db.StringSet("abc", stringstr);
                watch1.Stop();
                Console.WriteLine("ex setTime : " + watch1.ElapsedMilliseconds);

                var watch2 = new Stopwatch();
                watch2.Start();
                db.StringGet("abc");
                watch2.Stop();
                Console.WriteLine("ex getTime : " + watch2.ElapsedMilliseconds);

                Console.ReadKey();
            }

        }
    }
}
