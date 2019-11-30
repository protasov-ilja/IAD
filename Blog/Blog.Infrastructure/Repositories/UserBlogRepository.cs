using Blog.Application.Repositories;
using Blog.Core.Models;
using Blog.Infrastructure.Foundation;
using Repositories;
using System.Threading.Tasks;

namespace Blog.Infrastructure.Repositories
{
	public class UserBlogRepository : Repository<UserBlog>, IUserBlogRepository
	{
		private BlogDbContext _context;

		public UserBlogRepository(BlogDbContext context) : base(context)
		{
			_context = context;
		}

		public async Task<User> GetAsync(int id)
		{
			var s = _context.Set<SubscriberOfBlog>();
			var u = _context.Set<User>();
			var b = _context.Set<UserBlog>();
			var x = from subscribe in s
					join user in u on subscribe.UserId equals id
					join userBlog in b on subscribe.UserBlogId equals userBlog.Id
					select new { userBlog.Name, userBlog.Id };



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

			return await Entities.FirstOrDefaultAsync(user => user.Id == id);
		}

		public async Task<User> GetAsync(string login)
		{
			return await Entities.FirstOrDefaultAsync(user => user.Login == login);
		}
	}
}
