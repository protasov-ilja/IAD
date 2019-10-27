using Blog.Core.Models;
using Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Application.Repositories
{
	public interface IUserRepository : IRepository<User>
	{
		Task<User> GetAsync(int id);
		Task<User> GetAsync(string login);
	}
}
