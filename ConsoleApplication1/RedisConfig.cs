namespace ConsoleApplication1
{
    public static class RedisConfig
    {
        public static string ConnectionString { get; set; }

        public static string[] ConnStrings { get; set; }

        public static string Database { get; set; }

        public const int TimeDefaultValidTime = 1800;
    }
}