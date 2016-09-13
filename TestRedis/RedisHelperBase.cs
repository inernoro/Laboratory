using System;
using System.Collections.Generic;
using System.Linq;
using Abp.Domain.Entities;
using Abp.UI;
using Newtonsoft.Json;
using ServiceStack.Redis;
using ServiceStack.Redis.Generic;

namespace TestRedis
{
    public class RedisHelperBase : IDisposable
    {
        #region 初始化

        public static string[] ConnStrings = { "127.0.0.1", "6380" };

        private RedisClient _redis = new RedisClient(ConnStrings[0], int.Parse(ConnStrings[1]));



        //缓存池
        //默认缓存过期时间单位秒
        public int SecondsTimeOut = 30 * 60;

        /// <summary>
        /// 缓冲池
        /// </summary>
        /// <param name="readWriteHosts"></param>
        /// <param name="readOnlyHosts"></param>
        /// <returns></returns>
        public static PooledRedisClientManager CreateManager(string[] readWriteHosts, string[] readOnlyHosts)
        {
            return new PooledRedisClientManager(readWriteHosts, readOnlyHosts,
                new RedisClientManagerConfig
                {
                    MaxWritePoolSize = readWriteHosts.Length * 5,
                    MaxReadPoolSize = readOnlyHosts.Length * 5,
                    AutoStart = true
                });
        }


        #endregion

        #region String 存储

        /// <summary> 
        /// 设置缓存
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">缓存建</param>
        /// <param name="t">缓存值</param>
        /// <param name="timeout">过期时间，单位秒,-1：不过期，0：默认过期时间</param>
        /// <returns></returns>
        public bool Set<T>(string key, T t, int timeout = 0)
        {

            if (timeout < 0) return _redis.Set(key, t);
            if (timeout > 0)
            {
                SecondsTimeOut = timeout;
            }
            var dtTimeOut = DateTime.Now.AddSeconds(SecondsTimeOut);
            return _redis.Set(key, t, dtTimeOut);
        }

        /// <summary>
        /// 获取
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public T Get<T>(string key)
        {

            return _redis.Get<T>(key);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool Remove(string key)
        {

            return _redis.Remove(key);
        }

        /// <summary>
        /// 批量移除缓存
        /// </summary>
        /// <param name="keyList"></param>
        /// <returns></returns>
        public bool RemoveList(string[] keyList)
        {
            return _redis.RemoveEntry(keyList);
        }

        /// <summary>
        /// 字符串添加操作
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="t"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        public bool Add<T>(string key, T t, int timeout)
        {

            if (timeout < 0) return _redis.Add(key, t);
            if (timeout > 0)
            {
                SecondsTimeOut = timeout;
            }
            var resual = _redis.Add(key, t);
            _redis.Expire(key, SecondsTimeOut);
            return resual;
        }

        #endregion

        #region 其他

        /// <summary>
        /// 判断Key是否存在
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool ExistsKey(string key)
        {

            return _redis.Exists(key) != 0;
        }

        /// <summary>
        /// 距离过期时间还有多少秒
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public long Ttl(string key)
        {

            return _redis.Ttl(key);
        }

        /// <summary>
        /// 设置过期时间
        /// </summary>
        /// <param name="key"></param>
        /// <param name="seconds"></param>
        public void Expire(string key, int seconds)
        {

            _redis.Expire(key, seconds);
        }

        /// <summary>
        /// 递减并重置时间
        /// </summary>
        /// <param name="key"></param>
        /// <param name="number"></param>
        /// <returns></returns>
        public int Decr(string key, int number = 1)
        {

            return Convert.ToInt32(_redis.DecrBy(key, number));
        }

        /// <summary>
        /// 递增并重置时间
        /// </summary>
        /// <param name="key"></param>
        /// <param name="seconds"></param>
        /// <returns></returns>
        public int Incr(string key, int? seconds)
        {

            var count = Convert.ToInt32(_redis.Incr(key));
            if (seconds != null)
            {
                _redis.Expire(key, Convert.ToInt32(seconds));
            }
            return count;
        }

        /// <summary>
        /// 释放资源
        /// </summary>
        public void Dispose()
        {

            if (_redis != null)
            {
                _redis.Dispose();
                _redis = null;
            }
            GC.Collect();

        }

        /// <summary>
        /// 清空缓存
        /// </summary>
        public void FlushDb()
        {

            _redis.FlushDb();
        }

        /// <summary>
        /// 获取所有的Key
        /// </summary>
        /// <returns></returns>
        public List<string> GetAllKey()
        {

            return _redis.GetAllKeys();
        }

        #endregion


        #region 链表操作

        /// <summary>
        /// (New)根据IEnumerable数据添加链表
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="values"></param>
        /// <param name="timeout"></param>
        public void AddList<T>(IEnumerable<T> values, int timeout = 0)
        {
            var key = typeof(T).Name + "List";
            var iredisClient = _redis.As<T>();
            var redisList = iredisClient.Lists[key];
            redisList.AddRange(values);
            if (timeout < 0) return;
            if (timeout > 0)
            {
                SecondsTimeOut = timeout;
            }
            _redis.Expire(typeof(T).Name + "List", SecondsTimeOut);
        }

        /// <summary>
        /// (new)添加单个实体到链表中
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="item"></param>
        public void AddEntityToList<T>(string key, T item)
        {
            var iredisClient = _redis.As<string>();
            var redisList = iredisClient.Lists[key];
            redisList.Add(JsonConvert.SerializeObject(item));
            iredisClient.Save();

        }

        /// <summary>
        /// （new）根据类型自动判断并追加到list
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item"></param>
        public void AddEntityToList<T>(T item)
        {
            var key = GetListKey(item);
            AddEntityToList(key, item);

        }

        /// <summary>
        /// (New)获取简单链表
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public IRedisList<T> GetQuery<T>()
        {
            var iredisClient = _redis.As<T>();
            return iredisClient.Lists[typeof(T).Name + "List"];
        }

        /// <summary>
        /// (New)根据字符串获取链表基础
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="listId"></param>
        /// <returns></returns>

        public IRedisList<T> GetList<T>(string listId)
        {
            var iredisClient = _redis.As<T>();
            return iredisClient.Lists[listId];
        }

        /// <summary>
        /// (New)基础设施层，获取全部数据
        /// </summary>
        /// <returns></returns>
        public List<T> GetList<T>()
        {
            return GetList<T>(typeof(T).Name + "List").GetAll();
        }

        /// <summary>
        /// (New)获取链表全部数据并筛选
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public List<T> GetList<T>(Predicate<T> match)
        {
            var date = GetList<T>().FindAll(match);
            return date;
        }

        /// <summary>
        /// (New)获取链表全部数据并筛选条目
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public IEnumerable<T> GetList<T>(int start, int end)
        {
            throw new UserFriendlyException("没有完成该方法");
        }


        /// <summary>
        /// 根据lambada表达式获取符合条件的实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="func"></param>
        /// <returns></returns>
        [Obsolete]
        public T GetEntityFromList<T>(Func<T, bool> func)
        {
            var iredisClient = _redis.As<T>();
            var redisList = iredisClient.Lists[typeof(T).Name + "List"];
            var value = redisList.Where(func).FirstOrDefault();
            return value;
        }

        /// <summary>
        /// （New）覆盖这条数据,根据主键
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>

        public void AddOrUpdateEntityToList<T>(T t) where T : IEntity
        {
            var key = GetListKey(t);
            RemoveEntityForListItem(t);
            AddEntityToList(key, t);
        }

        /// <summary>
        /// （New）从RedisList中移除实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        public void RemoveEntityForListItem<T>(T t) where T : IEntity
        {
            var key = GetListKey(t);

            var iredisClient = _redis.As<string>();
            var redisList = iredisClient.Lists[key];
            var result = GetList<string>(key);
            for (var index = 0; index < result.Count; index++)
            {
                var boolean = (result[index].IndexOf("{Id:" + t.Id + ",", StringComparison.Ordinal) != -1
                    || result[index].IndexOf("{Id:\"" + t.Id + "\",", StringComparison.Ordinal) != -1);
                if (!boolean)
                    continue;
                redisList.RemoveAt(index);
                break;
            }

            iredisClient.Save();
        }

        /// <summary>
        /// 获取ListKey
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public static string GetListKey<T>(T t)
        {
            var key = t.GetType().Name;
            if (key.IndexOf("_", StringComparison.Ordinal) != -1)
            {
                key = key.Substring(0, key.IndexOf("_", StringComparison.Ordinal));
            }
            return key + "List";
        }


        public void GetHashValue()
        {



        }

        #endregion

    }
}