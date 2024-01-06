using BookStoreWebAPI.Models.Interfaces;

namespace BookStoreWebAPI.Models.Services
{
	public class AuthService : IAuthService
	{
		private readonly ITokenService tokenService;

        public AuthService(ITokenService tokenService)
        {
            this.tokenService = tokenService;
        }
        public async Task<UserLoginResponse> LoginUserAsync(UserLoginRequest request)
		{
			UserLoginResponse response = new();

			if (String.IsNullOrEmpty(request.Username) || String.IsNullOrEmpty(request.Password))
			{
				throw new ArgumentNullException(nameof(request));
			}

			if (request.Username == "Ferdi" && request.Password == "123")
			{
				var generatedToken = await tokenService.GenerateTokenAsync(new GenerateRequestToken
				{
					Username = request.Username,
				});
				response.AccessTokenExpireDate = generatedToken.TokenExpireDate;
				response.AuthenticateResult = true;
				response.AuthToken = generatedToken.Token;
			}

			return response;
		}
	}
}
