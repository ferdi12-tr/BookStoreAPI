using BookStoreWebAPI.Models.Interfaces;

namespace BookStoreWebAPI.Models.Services
{
	public class AuthService : IAuthService
	{
		private readonly ITokenService tokenService;
		private readonly IUserService userService;

        public AuthService(ITokenService tokenService, IUserService userService)
        {
            this.tokenService = tokenService;
            this.userService = userService;

        }
        public async Task<UserLoginResponse> LoginUserAsync(UserLoginRequest request)
		{
			UserLoginResponse response = new();

			if (String.IsNullOrEmpty(request.Username) || String.IsNullOrEmpty(request.Password))
			{
				throw new ArgumentNullException(nameof(request));
			}

			var user = userService.GetUserByPasswordUsername(request.Username, request.Password);

			if (user != null)
			{
				var generatedToken = await tokenService.GenerateTokenAsync(new GenerateRequestToken
				{
					Username = request.Username,
				});
				response.AccessTokenExpireDate = generatedToken.TokenExpireDate;
				response.AuthenticateResult = true;
				response.AuthToken = generatedToken.Token;
			}
			else
			{
                throw new UnauthorizedAccessException();
            }

			return response;
		}
	}
}
