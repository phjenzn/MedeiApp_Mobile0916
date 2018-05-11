using System;
using SQLite;
namespace MedeiApp.Sqlite
{
    public interface ISQLiteDb
    {
        SQLiteAsyncConnection GetConnection();
    }
}
