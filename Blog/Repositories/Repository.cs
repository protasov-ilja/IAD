using Microsoft.EntityFrameworkCore;
using Repositories.Abstractions;
using System.Collections.Generic;

namespace Repositories
{
	public class Repository<TEnitiy> : IRepository<TEnitiy> where TEnitiy : class
	{
		private readonly DbContext DbContext;
		protected DbSet<TEnitiy> Entities => DbContext.Set<TEnitiy>();

		public Repository(DbContext dbContext)
		{
			DbContext = dbContext;
		}

		public void Add(TEnitiy entity)
		{
			DbContext.Add(entity);
		}

		public void AddRange(List<TEnitiy> entities)
		{
			DbContext.AddRange(entities);
		}

		public void Remove(TEnitiy entity)
		{
			DbContext.Remove(entity);
		}
	}
}
