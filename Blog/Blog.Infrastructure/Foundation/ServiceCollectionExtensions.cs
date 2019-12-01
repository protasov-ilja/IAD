using Blog.Application.AppServices.Authentification;
using Blog.Application.AppServices.Blogs;
using Blog.Application.Repositories;
using Blog.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Repositories;
using Repositories.Abstractions;

namespace Blog.Infrastructure.Foundation
{
	public static class ServiceCollectionExtensions
	{
		public static IServiceCollection AddDependencies(this IServiceCollection services)
		{
			// AppServices
			services.AddScoped<IAccountService, AccountService>();
			services.AddScoped<IBlogsService, BlogsService>();

			// Repositories
			services.AddScoped<IUserRepository, UserRepository>();
			services.AddScoped<IUserBlogRepository, UserBlogRepository>();

			// Other
			services.AddScoped<IUnitOfWork, UnitOfWork<BlogDbContext>>();
			
			return services;
		}
	}
}
