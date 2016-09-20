using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Neo.IronLua;

namespace CodeBuild
{
    public class ExcuteBuildCode
    {
        /// <summary>
        /// 生成代码
        /// </summary>
        /// <param name="paBuildTables"></param>
        public void ExcuteCode(IEnumerable<BuildTable> paBuildTables)
        {
            var buildTables = paBuildTables.ToList();
            var tableName = buildTables.Select(x => x.Name).Distinct();
            foreach (var node in tableName)
            {
                var f = buildTables.FindAll(x => x.Name == node);
                var field = f.Select(x => x.ColName).ToArray();
                var types = f.Select(x => x.Xtype).ToArray();
                var str = GetBuild(node, field, types);
                ExcuteBuild(str);
            }
        }

        /// <summary>
        /// 执行生成底层
        /// </summary>
        /// <param name="dictionary"></param>
        private void ExcuteBuild(Dictionary<string, string> dictionary)
        {
            foreach (var node in dictionary)
            {
                var path = string.Format(PublicPath.BuildFilePath, node.Key);
                var newDri = path.Substring(0, path.LastIndexOf("\\", StringComparison.Ordinal));
                if (!File.Exists(newDri))
                {
                    Directory.CreateDirectory(newDri);
                }
                var writer = new StreamWriter(path);
                writer.Write(node.Value);
                writer.Close();
            }
        }

        /// <summary>
        /// 获取生成
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public Dictionary<string, string> GetBuild(string tableName, string[] a, int[] b)
        {
            var field = TableObject.GetTable(a);
            var types = TableObject.GetTable(b);
            Dictionary<string, string> str = LuaAssembly.AddressGetValue(PublicPath.Paths).BuildCode(tableName, field, types);
            return str;
        }

    }

    public class BuildTable : Entity
    {
        public string Name { get; set; }
        public int Xtype { get; set; }
        public string ColName { get; set; }
        public DateTime CreateTime { get; set; }
    }

    public static class TableObject
    {
        public static LuaTable GetTable(params string[] fields)
        {
            var types = new LuaTable();
            foreach (var t in fields)
            {
                types.ArrayList.Add(t);
            }
            return types;
        }

        public static LuaTable GetTable(params int[] fields)
        {
            var types = new LuaTable();
            foreach (var t in fields)
            {
                types.ArrayList.Add(t);
            }
            return types;
        }

        public static LuaTable GetTable(params object[] fields)
        {
            var types = new LuaTable();
            foreach (var t in fields)
            {
                types.ArrayList.Add(t);
            }
            return types;
        }

        public static LuaTable ToLuaTable<T>(this T entity) where T : class
        {
            var types = new LuaTable();
            foreach (var t in entity.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                types.Members.Add(new KeyValuePair<string, object>(t.Name, t.GetValue(entity)));
            }
            return types;
        }
    }
}