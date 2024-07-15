using API_FuruiFukuInc.Models;

using Microsoft.EntityFrameworkCore;

namespace API_FuruiFukuInc.Resources
{
    public class APIDBContext : DbContext
    {
        public APIDBContext(DbContextOptions<APIDBContext> options) : base(options) { }

        public DbSet<Usuario> Usuario { get; set; }

        public DbSet<Ventas> Ventas { get; set; }
    }
}
