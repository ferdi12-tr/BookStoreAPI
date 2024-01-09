using BookStoreWebAPI.Models.Interfaces;

namespace BookStoreWebAPI.Models.Services
{
    public class UserService : IUserService
    {
        private readonly DataContext dataContext;
        public UserService()
        {
            dataContext = new DataContext();
        }
        public bool AddUser(User user)
        {
            try
            {
                dataContext.Add(user);
                dataContext.SaveChanges();
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

        public User GetUserByPasswordUsername(string username, string password)
        {
            try
            {
                var user = dataContext.User.FirstOrDefault(x => String.Equals(password, x.Password) && String.Equals(username, x.Username));
                return user;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
    }
}
