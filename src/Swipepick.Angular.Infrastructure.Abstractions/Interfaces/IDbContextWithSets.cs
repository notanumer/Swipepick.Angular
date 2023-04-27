using Microsoft.EntityFrameworkCore;

namespace Swipepick.Angular.Infrastructure.Abstractions.Interfaces;

public interface IDbContextWithSets
{
    DbSet<TEntity> Set<TEntity>() where TEntity : class;

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
