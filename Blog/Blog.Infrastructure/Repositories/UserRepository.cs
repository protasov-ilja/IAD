using Blog.Application.Repositories;
using Blog.Core.Models;
using Blog.Infrastructure.Foundation;
using Microsoft.EntityFrameworkCore;
using Repositories;
using System.Threading.Tasks;

namespace Blog.Infrastructure.Repositories
{
	public class UserRepository : Repository<User>, IUserRepository
	{
		public UserRepository(BlogDbContext context) : base(context)
		{
		}

		public async Task<User> GetAsync(int id)
		{
			return await Entities.FirstOrDefaultAsync(user => user.Id == id);
		}

		public async Task<User> GetAsync(string login)
		{
			return await Entities.FirstOrDefaultAsync(user => user.Login == login);
		}
	}
}
