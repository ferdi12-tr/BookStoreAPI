namespace BookStoreWebAPI.Models.Interfaces
{
    public interface IUserService
    {
        public IEnumerable<User> GetAllUsers();
        public User GetUserById(int id);
        public Task<User> GetUserByPasswordUsernameAsync(string username, string password);
        public Task<bool> AddUserAsync(User user);

    }
}
