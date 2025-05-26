using Material.Web.Models;

namespace material.web.Data.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<T> Repository<T>() where T : class;

        // Specific repositories
      IRepository<MaterialEntity> MaterialRepository { get; }

        int Complete();
        Task<int> CompleteAsync();
    }
}
