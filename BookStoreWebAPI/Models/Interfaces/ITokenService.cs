namespace BookStoreWebAPI.Models.Interfaces
{
	public interface ITokenService
	{
		public Task<GenerateResponseToken> GenerateTokenAsync(GenerateRequestToken request);
	}
}
