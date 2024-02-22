using Microsoft.EntityFrameworkCore;
using ResumoPedidos.Domain;

namespace ResumoPedidos.Data
{
    public class ResumoPedidosContext : DbContext
    {
        
        public DbSet<Produto> Produto { get; set; }

        public DbSet<ResumoPedido>  ResumoPedidos { get; set; }

        public DbSet<Cliente> Cliente { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Initial Catalog=Curso EFCore;Integrated Security=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ResumoPedidosContext).Assembly);
        }
    }
}