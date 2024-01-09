namespace BookStoreWebAPI.Models.Interfaces
{
    public interface IUserService
    {
        public IEnumerable<User> GetAllUsers();
        public User GetUserById(int id);
        public User GetUserByPasswordUsername(string username, string password);
        public bool AddUser(User user);

    }
}
