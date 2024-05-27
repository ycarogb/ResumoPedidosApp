using Microsoft.EntityFrameworkCore;
using ResumoPedidos.Domain;

namespace ResumoPedidos.Data
{
    public class ResumoPedidosContext : DbContext
    {
        private static readonly ILoggerFactory _logger = LoggerFactory.Create(p => p.AddConsole());
        
        public DbSet<Produto> Produto { get; set; }

        public DbSet<ResumoPedido>  ResumoPedidos { get; set; }

        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<ProdutoPedido> ProdutoPedido { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder
                .UseLoggerFactory(_logger)
                .EnableSensitiveDataLogging() //EF Core mostra no console os valores dos parametros para cada registros alterado na api
                .UseSqlServer("Server=(localdb)\\mssqllocaldb;Initial Catalog=Curso EFCore;Integrated Security=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ResumoPedidosContext).Assembly);
        }
    }
}