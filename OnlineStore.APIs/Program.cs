
using Microsoft.EntityFrameworkCore;
using OnlineStore.Repository.Data;
using OnlineStore.Repository.Data.Contexts;

namespace OnlineStore.APIs
{
	public class Program
	{
		public static async Task Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.

			builder.Services.AddControllers();
			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();
			builder.Services.AddDbContext<StoreDbContext>(option =>
			{

				option.UseSqlServer(builder.Configuration.GetConnectionString(name: "DefaultConnection"));


			}
			


			);




			var app = builder.Build();

			////Apply any migrations
			//StoreDbContext Context = new StoreDbContext();
			//Context.Database.MigrateAsync();

			var scope= app.Services.CreateScope();
			var services=scope.ServiceProvider;
			var context= services.GetRequiredService<StoreDbContext>();
			var loggerFactory = services.GetRequiredService<ILoggerFactory>();


			try
			{
				await context.Database.MigrateAsync();

				await StoreDbContextSeed.SeedAsync(context);



			}
			catch (Exception ex)
			{
				var logger = loggerFactory.CreateLogger<Program>();
				logger.LogError(ex, message: "there is a problem during apply migrations ");
            }







			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseHttpsRedirection();

			app.UseAuthorization();


			app.MapControllers();

			app.Run();
		}
	}
}
