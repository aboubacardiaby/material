using Material.Web.Models;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace material.web.Data.Repositories
{
    public class MaterialRepository: Repository<MaterialEntity>, IMaterialRepository
    {
        public MaterialRepository( MaterialDBContext context): base(context)
        { }
        public async Task AddMaterialAsync(MaterialEntity material)
        {
            await _context.Materials.AddAsync(material);
        }

        public Task<IEnumerable<MaterialEntity>> GetAllMaterialsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<MaterialEntity> GetMaterialByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
        Task IMaterialRepository.UpdateMaterialAsync(MaterialEntity material)
        {
            throw new NotImplementedException();
        }
    }
}
