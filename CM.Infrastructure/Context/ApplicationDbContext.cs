using CM.Infrastructure.Entities.Base;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace CM.Infrastructure.Context;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        if (modelBuilder == null)
        {
            throw new ArgumentNullException(nameof(modelBuilder));
        }

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    public override int SaveChanges()
    {
        OnBeforeSaving();
        return base.SaveChanges();
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        OnBeforeSaving();
        return await base.SaveChangesAsync(cancellationToken);
    }

    private void OnBeforeSaving()
    {
        var addedEntities = ChangeTracker
            .Entries<Entity>()
            .Where(e => e.State == EntityState.Added);

        var updatedEntities = ChangeTracker
            .Entries<Entity>()
            .Where(e => e.State == EntityState.Modified);

        foreach (var entry in addedEntities)
        {
            var entity = entry.Entity;
            entity.CreatedOn = entity.UpdatedOn = DateTime.UtcNow;
        }

        foreach (var entry in updatedEntities)
        {
            var entity = entry.Entity;
            entity.UpdatedOn = DateTime.UtcNow;
        }
    }
}