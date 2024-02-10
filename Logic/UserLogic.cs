using QuinielaComunitaria.Models;
using QuinielaComunitaria.Services;

namespace QuinielaComunitaria.Logic
{
    public class UserLogic
    {
        private readonly UserService userService;

        public UserLogic()
        {
            userService = new UserService();
        }

        public async Task<User> AddUser(string name)
        {
            var user = new User { Name = name };
            await userService.SetUser(user);
            return user;
        }

        public async Task<List<User>> GetUsers()
        {
            var users = await userService.GetUsers();
            return users;
        }
    }
}