using System.Collections.Generic;
using System.IO;
using Neo.IronLua;
using System.Linq;

namespace CodeBuild
{
    public static class LuaAssembly
    { 

        /// <summary>
        /// 根据地址动态加载
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        public static dynamic AddressGetValue(string address)
        {
            return ExecuteScript(GetScript(address));
        }

        /// <summary>
        /// 执行脚本文件并返回结果集
        /// </summary>
        /// <param name="script">脚本</param>
        /// <returns></returns>
        public static dynamic ExecuteScript(string script)
        {
            dynamic create = new Lua().CreateEnvironment();
            create.dochunk(script, "LuaHelper.lua");
            return create;
        }


        /// <summary>
        /// 根据地址获取脚本
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string GetScript(string path)
        {
            using (var reader = new StreamReader(path))
            {
                return reader.ReadToEnd();
            }
        }
    }
}