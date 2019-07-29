using System;
using Microsoft.Data.Sqlite;

namespace WebApp.Controllers
{
    public static class ConnectionStrings
    {
        private static string sqliteFile = "AppData/db.db";
		public static SqliteConnectionStringBuilder sqliteDB = new SqliteConnectionStringBuilder() { DataSource = sqliteFile };
    }
}
