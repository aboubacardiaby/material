using Material.Web.Models;

namespace material.web.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MaterialDBContext _context;
        private readonly Dictionary<Type, object> _repositories;
        private IMaterialRepository _materialRepository;
        public IRepository<MaterialEntity> MaterialRepository => _materialRepository ??= new MaterialRepository(_context);

        public UnitOfWork(MaterialDBContext context)
        {
            _context = context;
            _repositories = new Dictionary<Type, object>();
        }

       

        public IRepository<T> Repository<T>() where T : class
        {
            var type = typeof(T);

            if (!_repositories.ContainsKey(type))
            {
                _repositories[type] = new Repository<T>(_context);
            }

            return (IRepository<T>)_repositories[type];
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}