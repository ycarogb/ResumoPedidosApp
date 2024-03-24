using Bogus.DataSets;
using ResumoPedidos.ResumoPedidos.Tests.Base;
using ResumoPedidos.Tests.Fixtures;

namespace ResumoPedidos.Tests.Base;

public class ResumoPedidosTestBase : IDisposable
{
    protected TestDbContextHelper DbHelpers { get; }

    public ResumoPedidosTestBase(ResumoPedidoTestFixture fixture)
    {
        fixture.EnsureReady(GetType());
        DbHelpers = new TestDbContextHelper(fixture.Provider);

        Date.SystemClock = () => new DateTime(2000, 1, 1);
        DbHelpers.DeleteDatabases();
        DbHelpers.CreateDatabases();
    }

    public void Dispose()
    {
        DbHelpers.DeleteDatabases();
    }
}
