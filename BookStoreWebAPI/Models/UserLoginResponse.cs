namespace BookStoreWebAPI.Models
{
	public class UserLoginResponse
	{
        public User? CurrentUser { get; set; }
        public bool AuthenticateResult { get; set; }
        public string? AuthToken { get; set; }
        public DateTime AccessTokenExpireDate { get; set; }

    }
}
