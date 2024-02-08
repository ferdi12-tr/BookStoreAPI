namespace BookStoreWebAPI.Extensions
{
	public static class ServiceExtensions
	{
		/// <summary>
		/// Custom extension method for configure Cors Policy
		/// </summary>
		public static void ConfigureCors(this IServiceCollection services) =>
			services.AddCors(options =>
			{
				options.AddPolicy("CorsPolicy", builder =>
					builder.AllowAnyOrigin()
						.AllowAnyMethod()
						.AllowAnyHeader());
			});

		/// <summary>
		/// Custom extension method for configure IIS Integration
		/// </summary>
		public static void ConfigureIISIntegration(this IServiceCollection services) =>
			services.Configure<IISOptions>(options =>
			{
				// leave with default options
			});
	}

}
