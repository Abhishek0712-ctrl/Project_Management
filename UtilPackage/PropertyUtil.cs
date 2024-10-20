using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Globalization;

namespace UtilPackage
{
    public class PropertyUtil
    {
        private static IConfiguration _config;
        static string s = null;
        static PropertyUtil()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("C:\\Users\\abhis\\OneDrive\\Desktop\\Foundation Technical Training\\Project_Management\\UtilPackage\\appsettings.json", optional: true, reloadOnChange: true);
            _config = builder.Build();
        }
        public static string getPropertyString(string key)
        {
            s=_config.GetConnectionString("dbCn");
            return s;
        }
    }
}
