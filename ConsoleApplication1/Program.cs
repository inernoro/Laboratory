using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using StackExchange.Redis;

namespace ConsoleApplication1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            

        }

        public static List<KeyValueStruct> ToMap<T>(T o)
        {
            var map = new List<KeyValueStruct>();
            var t = typeof(T);
            var pi = t.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (var p in pi)
            {
                var mi = p.GetGetMethod();
                if (mi != null && mi.IsPublic)
                {
                    map.Add(new KeyValueStruct
                    {
                        Name = p.Name,
                        Value = mi.Invoke(o, null)?.ToString()
                    });
                }
            }
            return map;
        }


        public static T GetModel<T>(List<KeyValueStruct> dr) where T : new()
        {
            var model = new T();
            var propertyLst = model.GetType().GetProperties();
            foreach (var property in propertyLst)
            {
                //键  
                var name = dr.Find(x => x.Name == property.Name);
                if (name.Value == null)
                    continue;
                try
                {
                    property.SetValue(model, name.Value, null); //为model赋值
                }
                catch (Exception)
                {
                    // ignored
                }
            }
            return model;
        }

        /// <summary>
        /// 获取Hash值
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="span"></param>
        /// <returns></returns>
        public static string HGet(string key, string value, int span = RedisConfig.TimeDefaultValidTime)
        {
            return Database.HashGet(key, value);
        }

        /// <summary>
        /// 获取所有对象
        /// </summary>
        /// <param name="key"></param> 
        /// <returns></returns>
        public static IEnumerable<KeyValueStruct> HGet(string key)
        {
            var value = Database.HashGetAll(key);
            return value.Select(node => new KeyValueStruct(node.Name, node.Value));
        }


        /// <summary>
        /// 设置某个字段值
        /// </summary>
        /// <param name="key"></param>
        /// <param name="hashField"></param>
        /// <param name="value"></param>
        /// <param name="span"></param>
        public static void HSet(string key, string hashField, string value, int span = RedisConfig.TimeDefaultValidTime)
        {
            Database.HashSet(key, hashField, value);
            SetExpire(key);

        }
        /// <summary>
        /// 批量添加键值
        /// </summary>
        /// <param name="key"></param>
        /// <param name="entry"></param>
        /// <param name="span"></param>
        public static void HSet(string key, KeyValueStruct[] entry, int span = RedisConfig.TimeDefaultValidTime)
        {
            var list = entry.Select(node => new HashEntry(node.Name, node.Value)).ToArray();
            Database.HashSet(key, list);
            SetExpire(key);
        }

        /// <summary>
        /// 设置有效时间
        /// </summary>
        /// <param name="key"></param>
        /// <param name="span"></param>
        public static void SetExpire(string key, int span = RedisConfig.TimeDefaultValidTime)
        {
            var date = DateTime.Now.AddSeconds(span);
            Database.KeyExpire(key, date);

        }

        #region 初始化

        private static ConnectionMultiplexer _redis;

        private static readonly object Locker = new object();

        private static readonly IDatabase Database = Manager.GetDatabase();

        public static ConnectionMultiplexer Manager
        {
            get
            {
                if (_redis == null)
                {
                    lock (Locker)
                    {
                        if (_redis != null) return _redis;

                        _redis = GetManager(RedisConfig.ConnectionString);
                        return _redis;
                    }
                }

                return _redis;
            }
        }

        private static ConnectionMultiplexer GetManager(string connectionString = null)
        {
            if (string.IsNullOrEmpty(connectionString))
            {
                connectionString = RedisConfig.ConnectionString;
            }

            return ConnectionMultiplexer.Connect(connectionString);
        }

        #endregion
    }
}

