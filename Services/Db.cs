using QuinielaComunitaria.Models;
using SQLite;

namespace QuinielaComunitaria.Services
{
    public class Db
    {
        static SQLiteAsyncConnection? DataBase;

        static string DatabasePath => Path.Combine(FileSystem.AppDataDirectory, "quinieladb.db3");
        const SQLiteOpenFlags FLAGS = SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create |
            SQLiteOpenFlags.SharedCache;

        public static async Task<SQLiteAsyncConnection> GetDb()
        {
            if (DataBase == null)
            {
                DataBase = new(DatabasePath, FLAGS);
                _ = await DataBase.CreateTableAsync<User>();
            }
            return DataBase;
        }
    }
}