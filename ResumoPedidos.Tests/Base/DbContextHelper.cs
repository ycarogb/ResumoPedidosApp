using System.Linq.Expressions;
using AutoMapper;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ResumoPedidos.Tests.Base;

public sealed class DbContextHelper<TAppDbContext, TTestDbContext>
    where TAppDbContext : DbContext
    where TTestDbContext : TAppDbContext
{
    private readonly IServiceProvider _serviceProvider;
    private readonly IMapper _mapper;

    public DbContextHelper(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
        _mapper = serviceProvider.GetRequiredService<IMapper>();
    }

    public Task<TEntity> SingleAsync<TModel, TEntity>(Expression<Func<TModel, bool>> filter = null)
        where TModel : class
        where TEntity : class
    {
        return SelectSingleAsync<TModel, TEntity>(filter == null ? (p => p) : (p => p.Where(filter)));
    }

    public Task<TModel> SingleAsync<TModel>(Expression<Func<TModel, bool>> filter = null)
        where TModel : class
    {
        return SelectSingleAsync<TModel>(filter == null ? (p => p) : (p => p.Where(filter)));
    }

    public async Task<TEntity> SelectSingleAsync<TModel, TEntity>(
        Func<IQueryable<TModel>, IQueryable<TModel>> selector)
        where TModel : class
        where TEntity : class
    {
        var model = await SelectSingleAsync<TModel>(selector);
        var entity = _mapper.Map<TEntity>(model);
        return entity;
    }

    public async Task<TModel> SelectSingleAsync<TModel>(
        Func<IQueryable<TModel>, IQueryable<TModel>> selector)
        where TModel : class
    {
        var dbContext = CreateDbContext();
        var query = selector(dbContext.Set<TModel>());
        var records = await query.ToListAsync();
        return records.Should().ContainSingle().Subject;
    }

    public Task<TModel> FirstAsync<TModel>(Expression<Func<TModel, bool>> filter = null)
        where TModel : class
    {
        var dbContext = CreateDbContext();
        return dbContext.Set<TModel>().FirstOrDefaultAsync(filter ?? (_ => true));
    }

    public async Task<TEntity> FirstAsync<TModel, TEntity>(Expression<Func<TModel, bool>> filter = null)
        where TModel : class
        where TEntity : class
    {
        var model = await FirstAsync<TModel>(filter);
        var entity = _mapper.Map<TEntity>(model);
        return entity;
    }

    public Task<List<TModel>> AllAsync<TModel>(Expression<Func<TModel, bool>> filter = null)
        where TModel : class
    {
        var dbContext = CreateDbContext();
        var query = dbContext.Set<TModel>().AsQueryable();
        if (filter != null) query = query.Where(filter);
        return query.ToListAsync();
    }

    public async Task<List<TEntity>> AllAsync<TModel, TEntity>(Expression<Func<TModel, bool>> filter = null)
        where TModel : class
        where TEntity : class
    {
        var models = await AllAsync<TModel>(filter);
        var entities = _mapper.Map<List<TEntity>>(models);
        return entities;
    }

    public async Task InsertAsync<TEntity, TModel>(IEnumerable<TEntity> entities)
        where TEntity : class
        where TModel : class
    {
        var models = _mapper.Map<List<TModel>>(entities);
        var dbContext = CreateDbContext();

        await dbContext.AddRangeAsync(models);
        await dbContext.SaveChangesAsync();
    }

    public Task InsertAsync<TEntity, TModel>(params TEntity[] entities)
        where TEntity : class
        where TModel : class
    {
        return InsertAsync<TEntity, TModel>((IEnumerable<TEntity>)entities);
    }

    public void CreateDatabase()
    {
        var dbContext = CreateDbContext();
        dbContext.Database.EnsureCreated();
    }

    public void DeleteDatabase()
    {
        var dbContext = CreateDbContext();
        dbContext.Database.EnsureDeleted();
    }

    public TTestDbContext CreateDbContext()
    {
        var instance = (TTestDbContext)Activator.CreateInstance(typeof(TTestDbContext), _serviceProvider)!;
        return instance;
    }
}
