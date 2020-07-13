namespace AngularBlog.Common
{
    public static class Constants
    {
        //TODO enum
        public static class DbTypes
        {
            public const string MySql = "MySQL";
            public const string Oracle = "Oracle";
        }
        
        public const string DbTypeKey = "DB_TYPE";

        public const string ConnectionStringTemplate = "ConnectionString:{0}";
        
        public const string AppSettingsKey = "AppSettings";
    }
}