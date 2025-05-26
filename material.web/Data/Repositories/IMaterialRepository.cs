using Material.Web.Models;

namespace material.web.Data.Repositories
{
    public interface IMaterialRepository:IRepository<MaterialEntity>
    {
        Task<IEnumerable<MaterialEntity>> GetAllMaterialsAsync();
        Task<MaterialEntity> GetMaterialByIdAsync(int id);
        Task AddMaterialAsync(MaterialEntity material);
        Task UpdateMaterialAsync(MaterialEntity material);
    }
}
