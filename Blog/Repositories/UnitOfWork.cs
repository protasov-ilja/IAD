using Microsoft.EntityFrameworkCore;
using Repositories.Abstractions;
using System.Threading.Tasks;

namespace Repositories
{
	public class UnitOfWork<T> : IUnitOfWork
		 where T : DbContext
	{
		protected readonly T DbContext;

		public UnitOfWork(T dbContext)
		{
			DbContext = dbContext;
		}

		public void Commit()
		{
			DbContext.SaveChanges();
		}

		public async Task CommitAsync()
		{
			await DbContext.SaveChangesAsync();
		}
	}
}
