namespace BookStoreWebAPI.Models.Interfaces
{
	public interface IAuthService
	{
		public Task<UserLoginResponse> LoginUserAsync(UserLoginRequest request);
    }
}
