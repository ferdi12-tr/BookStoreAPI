using BookStoreWebAPI.Models.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BookStoreWebAPI.Models.Services
{
	public class TokenService : ITokenService
	{
		IConfiguration configuration;
        public TokenService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public Task<GenerateResponseToken> GenerateTokenAsync(GenerateRequestToken request)
		{
			SymmetricSecurityKey symmetricSecurityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(configuration["AppSettings:Secret"]));
			var dateTime = DateTime.Now;
			JwtSecurityToken jwt = new JwtSecurityToken(
				issuer: configuration["AppSettings:ValidIssuer"],
				audience: configuration["AppSettings:ValidAudience"],
				claims: new List<Claim>
				{
					new Claim("Username", request.Username)
				},
				notBefore: dateTime,
				expires: dateTime.AddMinutes(10),
				signingCredentials: new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256)
				);
			return Task.FromResult(new GenerateResponseToken
			{
				Token = new JwtSecurityTokenHandler().WriteToken(jwt),
				TokenExpireDate = dateTime.AddMinutes(10),
			});
		}
	}
}
