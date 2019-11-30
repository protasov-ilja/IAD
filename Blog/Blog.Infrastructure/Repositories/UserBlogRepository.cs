using Blog.Application.Repositories;
using Blog.Core.Models;
using Blog.Infrastructure.Foundation;
using Repositories;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Blog.Infrastructure.Repositories
{
	public class UserBlogRepository : Repository<UserBlog>, IUserBlogRepository
	{
		private BlogDbContext _context;

		public UserBlogRepository(BlogDbContext context) : base(context)
		{
			_context = context;
		}

		public async Task<UserBlog> GetAsync(int id)
		{
			var asd = from subscribe in _context.Set<SubscriberOfBlog>()
					  join user in _context.Set<User>().Where(x => x.Id == id) on subscribe.UserId equals user.Id
					  join userBlog in _context.Set<UserBlog>() on subscribe.UserBlogId equals userBlog.Id
					  select new { userBlog.Id, userBlog.Name, userBlog.Info };

			//			.Phones.Join(db.Companies, // второй набор
			//			p => p.CompanyId, // свойство-селектор объекта из первого набора
			//			c => c.Id, // свойство-селектор объекта из второго набора
			//			(p, c) => new // результат
			//{
			//				Name = p.Name,
			//				Company = c.Name,
			//				Price = p.Price
			//			});
			//		foreach (var p in phones)
			//			Console.WriteLine("{0} ({1}) - {2}", p.Name, p.Company, p.Price);

			return await Entities.FirstOrDefaultAsync(s => s.Id == id);
		}

		public async Task<UserBlog> GetAsync(string login)
		{
			return await Entities.FirstOrDefaultAsync(user => user.Id == login);
		}
	}
}
