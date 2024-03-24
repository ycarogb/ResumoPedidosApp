using ResumoPedidos.Data;
using ResumoPedidos.Tests.Base;

namespace ResumoPedidos.ResumoPedidos.Tests.Base;

public class TestDbContextHelper
{
    public TestDbContextHelper(IServiceProvider serviceProvider)
    {
        Context = new DbContextHelper<ResumoPedidosContext, ResumoPedidosTestContext>(serviceProvider);
    }
    
    public DbContextHelper<ResumoPedidosContext, ResumoPedidosTestContext> Context { get; }
    
    public void CreateDatabases()
    {
        Context.CreateDatabase();
    }
    
    public void DeleteDatabases()
    {
        Context.DeleteDatabase();
    }
}
