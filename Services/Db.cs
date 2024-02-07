using QuinielaComunitaria.Models;
using SQLite;

namespace QuinielaComunitaria.Services
{
    public class Db
    {
        const string DbFileName = "quinieladb.db3";
        static string DbPath = Path.Combine(FileSystem.AppDataDirectory, DbFileName);
        const SQLiteOpenFlags Flags = SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create |
            SQLiteOpenFlags.SharedCache;
        SQLiteAsyncConnection? Database;

        public async Task Init()
        {
            if (Database is not null) return;
            Database = new SQLiteAsyncConnection(DbPath, Flags);
            var result = await Database.CreateTableAsync<User>();
        }
    }
}