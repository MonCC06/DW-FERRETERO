using Ferretero.Models;
using Microsoft.EntityFrameworkCore;

namespace Ferretero.Datos
{
    public class AplicationDbContext : DbContext
    {
        public AplicationDbContext(DbContextOptions<AplicationDbContext> options) : base(options)
        {
        }

        // Aca iremos creando basados en el modelo las respectivas tablas en la BD
        public DbSet<Categoria> categoria { get; set; }
        public DbSet<TipoAplicacion> TipoAplicaciones { get; set; }

        public DbSet<Producto> Producto { get; set; }
    }
}

