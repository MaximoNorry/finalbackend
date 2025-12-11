using AlmacenMvc.Models;
using Microsoft.EntityFrameworkCore;

namespace AlmacenMvc.Data
{
    public class AlmacenContext : DbContext
    {
        public AlmacenContext(DbContextOptions<AlmacenContext> options)
            : base(options)
        {
        }

        public DbSet<Articulo> Articulos { get; set; }
    }
}
