using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace ClearTest
{
    internal class Program
    {
        //public static string ConnString = "Server=192.168.31.31;database=Cloud;uid=sa;pwd=1qaz@WSX;Packet Size=8192;Max Pool Size=1000";
        public static string ConnString = "Server=123.56.129.104;database=Cloud;uid=e2eDeveloper;pwd=1qazXSW@1qazXSW@;Packet Size=8192;Max Pool Size=1000";

        /// <summary>
        /// 列表查询所有
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static IEnumerable<T> QueryAll<T>()
        {
            using (IDbConnection conn = new SqlConnection(ConnString))
            {
                return conn.Query<T>(@"SELECT * FROM [Cloud].[dbo].[UserInfo]");
            }
        }

        private static void Main(string[] args)
        {
            while (true)
            {
                var sw = new Stopwatch();
                sw.Start();
                var data = QueryAll<UserInfo>();
                sw.Stop();
                Console.WriteLine(sw.ElapsedMilliseconds + "," + data.Count());
                Console.ReadKey();
            }
        }
    }
}
