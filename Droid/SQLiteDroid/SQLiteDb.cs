using System;
using System.IO;
using MedeiApp.Droid.SQLiteDroid;
using SQLite;
using Xamarin.Forms;
using MedeiApp.Sqlite;

[assembly: Dependency(typeof(SQLiteDb))]

namespace MedeiApp.Droid.SQLiteDroid
{
    public class SQLiteDb : ISQLiteDb
    {
        public SQLiteDb()
        {
        }

        public SQLiteAsyncConnection GetConnection()
        {
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentsPath, "MySQLite.db4");

            return new SQLiteAsyncConnection(path);
        }
    }
}
