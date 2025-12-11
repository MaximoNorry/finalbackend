using AlmacenMvc.Models;

namespace AlmacenMvc.Repositories
{
    public interface IArticuloRepository
    {
        Task<List<Articulo>> GetAllAsync();
        Task<Articulo?> GetByIdAsync(int id);
        Task AddAsync(Articulo articulo);
        Task UpdateAsync(Articulo articulo);
        Task DeleteAsync(int id);
        Task SaveChangesAsync();
    }
}
