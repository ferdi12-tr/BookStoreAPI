using BookStoreWebAPI.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BookStoreWebAPI.Models.Services
{
    public class UserService : IUserService
    {
        private readonly DataContext dataContext;
        public UserService()
        {
            dataContext = new DataContext();
        }
        public async Task<bool> AddUserAsync(User user)
        {
            try
            {
                dataContext.User?.Add(user);
                await dataContext.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public IEnumerable<User> GetAllUsers()
        {
            try
            {
                var users = dataContext.User?.ToList();
                return users;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public User GetUserById(int id)
        {
            try
            {
                var user = dataContext.User?.Find(id);
                return user;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public async Task<User> GetUserByPasswordUsernameAsync(string username, string password)
        {
            try
            {
                var user = await dataContext.User.FirstOrDefaultAsync(x => String.Equals(password, x.Password) && String.Equals(username, x.Username));

				return user;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
    }
}
