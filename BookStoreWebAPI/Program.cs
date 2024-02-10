using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using BookStoreWebAPI.Extensions;
using Microsoft.AspNetCore.HttpOverrides;
using NLog;


namespace BookStoreWebAPI
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			LogManager.Setup().LoadConfigurationFromFile(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));

			// Add services to the container.
			builder.Services.ConfigureRepositoryManager();
			builder.Services.ConfigureServiceManager();

			builder.Services.AddControllers();
			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();

            //Set Cors Policy
            builder.Services.ConfigureCors();

			//configure IIS
			builder.Services.ConfigureIISIntegration();

			//Add log service
			builder.Services.ConfigureLoggerService();


			//serialize the included object to json
			builder.Services.AddControllers()
				.AddNewtonsoftJson(opt =>
								opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);


			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseSwagger();
				app.UseSwaggerUI();
			}
			else
			{
				app.UseHsts();
			}

			app.UseHttpsRedirection();

			app.UseStaticFiles();
			app.UseForwardedHeaders(new ForwardedHeadersOptions // forward proxy header to the current request
			{
				ForwardedHeaders = ForwardedHeaders.All
			});

            app.UseCors("CorsPolicy");
			
			app.UseAuthentication();

			app.UseAuthorization();

			app.MapControllers();

            app.Run();
		}
	}
}
