namespace CodeBuild
{
    public static class PublicPath
    {

        /// <summary>
        /// 生成地址，需要选择，否则是C盘
        /// </summary>
        public static string BuildFilePath = "C:\\Temp\\{0}.cs";
        /// <summary>
        /// 代码生成器sql地址
        /// </summary>
        public static string BuildQuerySql = System.AppDomain.CurrentDomain.BaseDirectory + "CodeBuildAppService.lua";
        /// <summary>
        /// 生成器模板
        /// </summary>
        public static string Paths = System.AppDomain.CurrentDomain.BaseDirectory + "BuildCodeExcuteStrategy.lua";

        /// <summary>
        /// 链接字符串
        /// </summary>
        public static string MasterConnectionString { get; set; } = "Server=inernoro.sqlserver.rds.aliyuncs.com,3433;database=CloudPlatform;uid=inernoro;pwd=KONGque00;";


    }
}