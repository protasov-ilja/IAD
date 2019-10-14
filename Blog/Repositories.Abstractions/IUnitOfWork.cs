using System.Threading.Tasks;

namespace Repositories.Abstractions
{
	public interface IUnitOfWork
	{
		void Commit();
		Task CommitAsync();
	}

}
