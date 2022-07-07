using CM.Infrastructure.Context;
using CM.Infrastructure.Repositories.Specifications;
using Microsoft.EntityFrameworkCore;

namespace CM.Infrastructure.Repositories;

public class RepositoryBase<TEntity>
    where TEntity : class
{
    protected ApplicationDbContext Context { get; }

    public RepositoryBase(ApplicationDbContext context)
    {
        Context = context;
    }

    public virtual async Task CreateAsync(TEntity entity)
    {
        Context.Add(entity);
        await Context.SaveChangesAsync();
    }

    public async Task DeleteAsync(TEntity entity)
    {
        Context.Remove(entity);
        await Context.SaveChangesAsync();
    }

    public IQueryable<TEntity> GetAll()
    {
        return Context.Set<TEntity>().AsQueryable();
    }

    public async Task<List<TEntity>> GetAllBySpecsAsync(Specification<TEntity> specs)
    {
        return await GetAll().Where(specs.ToExpression()).ToListAsync();
    }

    public async Task<TEntity?> GetSingleBySpecsAsync(Specification<TEntity> specs)
    {
        return await GetAll().Where(specs.ToExpression()).SingleOrDefaultAsync();
    }

    public async Task<TEntity> UpdateAsync(TEntity entity)
    {
        var updatedEntity = Context.Update(entity);
        await Context.SaveChangesAsync();

        return updatedEntity.Entity;
    }

    public async Task<int> UpdateManyAsync(IEnumerable<TEntity> entities)
    {
        foreach (var entity in entities)
        {
            Context.Update(entity);
        }

        return await Context.SaveChangesAsync();
    }
}