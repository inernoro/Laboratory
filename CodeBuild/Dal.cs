using System.Collections.Generic;
using System.Linq;

namespace CodeBuild
{
    /// <summary>
    /// 数据访问层
    /// </summary>
    public class Dal
    {
        readonly DapperRepositories _dapper = new DapperRepositories();

        public void BuildCode(string tableName)
        {
            string sql = LuaAssembly.AddressGetValue(PublicPath.BuildQuerySql).BuildCode().tables.ToString();
            var result = _dapper.Query<BuildTable>(sql, new { name = tableName });

            var excute = new ExcuteBuildCode();
            excute.ExcuteCode(result);

        }

        public List<IEnumerable<object>> SelectTableAndDatabase()
        {
            var result = _dapper.QueryMultiple(@"SELECT Name FROM Master..SysDatabases ORDER BY Name;
SELECT Name FROM SysObjects Where XType = 'U' ORDER BY Name; ", null, typeof(string), typeof(string));
            return result;
        }

        public List<string> GetTable()
        {
            var result = _dapper.Query<string>(@"select name from sys.tables");
            return result.ToList();
        }

    }
}