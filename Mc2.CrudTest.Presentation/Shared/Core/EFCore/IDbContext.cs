using Mc2.CrudTest.Presentation.Shared.Core.Event;
using Microsoft.EntityFrameworkCore;

namespace Mc2.CrudTest.Presentation.Shared.Core.EFCore;

public interface IDbContext
{
    DbSet<TEntity> Set<TEntity>() where TEntity : class;
    IReadOnlyList<IDomainEvent> GetDomainEvents();
    Task ExecuteTransactionalAsync(CancellationToken cancellationToken = default);
}
