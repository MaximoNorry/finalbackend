using AlmacenMvc.Data;
using AlmacenMvc.Models;
using Microsoft.EntityFrameworkCore;

namespace AlmacenMvc.Repositories
{
    public class ArticuloRepository : IArticuloRepository
    {
        private readonly AlmacenContext _context;

        public ArticuloRepository(AlmacenContext context)
        {
            _context = context;
        }

        public async Task<List<Articulo>> GetAllAsync()
        {
            return await _context.Articulos.ToListAsync();
        }

        public async Task<Articulo?> GetByIdAsync(int id)
        {
            return await _context.Articulos.FindAsync(id);
        }

        public async Task AddAsync(Articulo articulo)
        {
            await _context.Articulos.AddAsync(articulo);
        }

        public Task UpdateAsync(Articulo articulo)
        {
            _context.Articulos.Update(articulo);
            return Task.CompletedTask;
        }

        public async Task DeleteAsync(int id)
        {
            var articulo = await GetByIdAsync(id);
            if (articulo != null)
            {
                _context.Articulos.Remove(articulo);
            }
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
