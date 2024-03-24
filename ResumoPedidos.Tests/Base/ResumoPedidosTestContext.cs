using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Logging;
using ResumoPedidos.Data;

public class ResumoPedidosTestContext : ResumoPedidosContext
{
    private readonly ILoggerFactory _loggerFactory;
    
    public ResumoPedidosTestContext()
    {
        _loggerFactory = LoggerFactory.Create(builder => builder.AddFilter("Microsoft", LogLevel.Information).AddConsole());
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ResumoPedidosContext).Assembly);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer();
        optionsBuilder.ConfigureWarnings(p => p.Ignore(RelationalEventId.AmbientTransactionWarning));
        optionsBuilder.EnableDetailedErrors();
        optionsBuilder.EnableSensitiveDataLogging();
        optionsBuilder.UseLoggerFactory(_loggerFactory);
    }
}
