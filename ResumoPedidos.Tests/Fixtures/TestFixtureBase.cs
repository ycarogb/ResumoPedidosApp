using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace ResumoPedidos.Tests.Fixtures;

public abstract class TestFixtureBase
{
    public abstract IServiceProvider Provider { get; }

    public abstract HttpClient Client { get; }

    public IMapper Mapper => this.Provider.GetRequiredService<IMapper>();

    public T Resolve<T>() => this.Provider.GetService<T>();

    public ICollection<T> ResolveList<T>() => (ICollection<T>) this.Provider.GetServices<T>().ToList<T>();
}
