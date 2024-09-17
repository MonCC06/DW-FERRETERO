using Ferretero.Models;
using Microsoft.EntityFrameworkCore;

namespace Ferretero.Datos
{
    public class AplicationDbContext : DbContext
    {
        public AplicationDbContext(DbContextOptions<AplicationDbContext> options) : base(options)
        {


        }
        //Aca iremos Creando basados en el modelo las respectivas tablas en la bd 

        public DbSet<Categoria>categoria{get;set;}

        public DbSet<TipoAplicacion> tipoAplicacion { get; set;}

        public DbSet<>

    }
}
