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


			// Other
			services.AddScoped<IUnitOfWork, UnitOfWork<BlogDbContext>>();

			return services;
		}
	}
}
