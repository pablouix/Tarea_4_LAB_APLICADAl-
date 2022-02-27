
using Microsoft.EntityFrameworkCore;
using RegistroProductosDetalles.Entidades;


namespace RegistroProductosDetalles.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Productos> productos { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source = Data\\Productos.db");
        }

        public Contexto(DbContextOptions<Contexto> options)
            : base(options)
        { }

        public Contexto()
        {
        }
    }
}