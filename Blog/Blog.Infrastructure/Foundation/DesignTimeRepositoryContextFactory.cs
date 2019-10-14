using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Blog.Infrastructure.Foundation
{
	public class DesignTimeRepositoryContextFactory : IDesignTimeDbContextFactory<BlogDbContext>
	{
		public BlogDbContext CreateDbContext(string[] args)
		{
			var builder = new ConfigurationBuilder()
				.SetBasePath(Directory.GetCurrentDirectory())
				.AddJsonFile("appsettings.json")
				.AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", true)
				.AddEnvironmentVariables();

			var config = builder.Build();
			var connectionString = config.GetConnectionString("BlogConnection");
			var optionsBuilder = new DbContextOptionsBuilder<BlogDbContext>();
			optionsBuilder.UseSqlServer(connectionString, x => x.MigrationsAssembly("Blog.Api"));

			return new BlogDbContext(optionsBuilder.Options);
		}
	}
}
