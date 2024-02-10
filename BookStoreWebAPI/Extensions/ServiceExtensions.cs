using Contracts;
using LoggerService;
using Repository;
using Service;
using Service.Contracts;

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

		/// <summary>
		/// Custom Logger service with NLog
		/// </summary>
		/// <param name="services"></param>
		public static void ConfigureLoggerService(this IServiceCollection services) =>
			services.AddSingleton<ILoggerManager, LoggerManager>();

		/// <summary>
		/// Service to manage repository
		/// </summary>
		public static void ConfigureRepositoryManager(this IServiceCollection services) =>
			services.AddScoped<IRepositoryManager, RepositoryManager>();

		/// <summary>
		/// Custom service manager 
		/// </summary>
		public static void ConfigureServiceManager(this IServiceCollection services) =>
			services.AddScoped<IServiceManager, ServiceManager>();
	}

}
