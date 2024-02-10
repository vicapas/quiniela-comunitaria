using QuinielaComunitaria.Models;

namespace QuinielaComunitaria.Services
{
    public class UserService
    {
        public async Task<User?> GetUser(string id)
        {
            var db = await Db.GetDb();
            return await db.Table<User>().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<int> SetUser(User user)
        {
            var db = await Db.GetDb();
            if (user.Id == null)
            {
                user.Id = Guid.NewGuid().ToString();
                return await db.InsertAsync(user);
            }
            else return await db.UpdateAsync(user);
        }

        public async Task<List<User>> GetUsers()
        {
            var db = await Db.GetDb();
            return await db.Table<User>().ToListAsync();
        }
    }
}