using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;

namespace NewRedisTest
{
    public class DapperHelper
    {

        public static string ConnString = "Server=192.168.31.31;database=Cloud;uid=sa;pwd=1qaz@WSX;Packet Size=8192;Max Pool Size=1000";
        //public static string ConnString = "Server=123.56.129.104;database=Cloud;uid=e2eDeveloper;pwd=1qazXSW@1qazXSW@;Packet Size=8192;Max Pool Size=1000";
        /// <summary>
        /// 列表查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="proc"></param>
        /// <param name="procParams"></param>
        /// <returns></returns>
        public static List<T> Query<T>(string proc, DynamicParameters procParams)
        {
            using (IDbConnection conn = new SqlConnection(ConnString))
            {
                return conn.Query<T>(proc).ToList();
            }
        }

        /// <summary>
        /// 列表查询所有
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static List<T> QueryAll<T>()
        {
            var name = typeof(T).Name;
            using (IDbConnection conn = new SqlConnection(ConnString))
            {
                return conn.Query<T>("select  * from " + name).ToList();
            }
        }

        /// <summary>
        /// 查询一行
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static IEnumerable<T> QueryFrist<T>()
        {
            var name = typeof(T).Name;
            using (IDbConnection conn = new SqlConnection(ConnString))
            {
                return conn.Query<T>("select * from " + name);
            }
        }

        /// <summary>
        /// 取数据，执行存储过程，带参数
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="proc"></param>
        /// <param name="procParams"></param>
        /// <returns></returns>
        public static List<T> InnerQuery<T>(string proc, DynamicParameters procParams)
        {
            using (IDbConnection conn = new SqlConnection(ConnString))
            {
                return conn.Query<T>(proc, procParams, commandType: CommandType.StoredProcedure).ToList();
            }

        }

        /// <summary>
        /// 取数据，执行存储过程，无参数
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="proc"></param>
        /// <returns></returns>
        public static List<T> InnerQuery<T>(string proc)
        {
            using (IDbConnection conn = new SqlConnection(ConnString))
            {
                return conn.Query<T>(proc, commandType: CommandType.StoredProcedure).ToList();
            }
        }

        /// <summary>
        /// 取数据，返回多个结果集的读取方式
        /// </summary>
        /// <typeparam name="T">返回类型</typeparam>
        /// <param name="proc">存储过程名</param>
        /// <param name="procParams">参数</param>
        /// <param name="readResult">对结果集的处理函数</param>
        /// <returns></returns>
        public static T InnerQueryMultiple<T>(string proc, DynamicParameters procParams, Func<Dapper.SqlMapper.GridReader, T> readResult)
        {
            IDbConnection conn = null;
            Dapper.SqlMapper.GridReader reader = null;

            try
            {
                conn = new SqlConnection(ConnString);

                reader = conn.QueryMultiple(proc, procParams, commandType: CommandType.StoredProcedure);

                return readResult(reader);

            }
            finally
            {
                reader?.Dispose();
                conn?.Dispose();
            }


        }

        /// <summary>
        /// 查询操作，无参数，返回第一行第一列结果
        /// </summary>
        /// <param name="proc">读取的存储过程</param>
        /// <returns></returns>
        public static T InnerQueryScalar<T>(string proc)
        {
            using (IDbConnection conn = new SqlConnection(ConnString))
            {
                return conn.ExecuteScalar<T>(proc, commandType: CommandType.StoredProcedure);
            }
        }

        /// <summary>
        /// 查询操作，需参数，返回第一行第一列结果
        /// </summary>
        /// <param name="proc">读取的存储过程</param>
        /// <param name="procParams">参数</param>
        /// <returns></returns>
        public static T InnerQueryScalar<T>(string proc, DynamicParameters procParams)
        {
            using (IDbConnection conn = new SqlConnection(ConnString))
            {
                return conn.ExecuteScalar<T>(proc, procParams, commandType: CommandType.StoredProcedure);
            }
        }

        /// <summary>
        /// 执行更新数据库的操作，返回操作结果
        /// </summary>
        /// <param name="proc">更新数据的存储过程</param>
        /// <returns>操作结果：1成功0失败</returns>
        public static int InnerExecuteScalar(string proc)
        {
            using (IDbConnection conn = new SqlConnection(ConnString))
            {
                return conn.ExecuteScalar<int>(proc, commandType: CommandType.StoredProcedure);
            }
        }

        /// <summary>
        /// 执行PROC，返回影响行数
        /// </summary>
        /// <param name="proc"></param>
        /// <returns></returns>
        public static int InnerExecute(string proc)
        {
            using (IDbConnection conn = new SqlConnection(ConnString))
            {
                return conn.Execute(proc, commandType: CommandType.StoredProcedure);
            }
        }

        /// <summary>
        /// 执行SQL，返回影响行数
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="sqlParams">参数</param>
        /// <returns></returns>
        public static int InnerExecuteSql(string sql, DynamicParameters sqlParams)
        {
            using (IDbConnection conn = new SqlConnection(ConnString))
            {
                return conn.Execute(sql, sqlParams, commandType: CommandType.Text);
            }
        }


        /// <summary>
        /// 执行PROC，返回影响行数
        /// </summary>
        /// <param name="proc"></param>
        /// <param name="procParams">参数</param>
        /// <returns></returns>
        public static int InnerExecute(string proc, DynamicParameters procParams)
        {
            using (IDbConnection conn = new SqlConnection(ConnString))
            {
                return conn.Execute(proc, procParams, commandType: CommandType.StoredProcedure);
            }
        }

        /// <summary>
        /// 执行SQL，返回影响行数
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static int InnerExecuteText(string sql)
        {
            using (IDbConnection conn = new SqlConnection(ConnString))
            {
                return conn.Execute(sql, commandType: CommandType.Text);
            }
        }
        /// <summary>
        /// 执行存储过程，无参数,长时间 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="proc"></param>
        /// <returns></returns>
        public static List<T> InnerQueryLongTime<T>(string proc)
        {
            using (IDbConnection conn = new SqlConnection(ConnString))
            {
                return conn.Query<T>(proc, commandType: CommandType.StoredProcedure, commandTimeout: 600).ToList();
            }
        }
    }
}