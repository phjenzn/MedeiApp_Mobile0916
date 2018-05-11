using System;
using System.IO;
using MedeiApp.Sqlite;
using SQLite;
using Xamarin.Forms;
using MedeiApp.iOS.SQLiteIOS;

[assembly: Dependency(typeof(SQLiteDb))]
namespace MedeiApp.iOS.SQLiteIOS
{
    public class SQLiteDb  : ISQLiteDb
    {
        public SQLiteDb()
        {
        }

        public SQLiteAsyncConnection GetConnection()
        {
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentsPath, "..", "Library", "Databases");

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            return new SQLiteAsyncConnection(path);
        }
    }
}
