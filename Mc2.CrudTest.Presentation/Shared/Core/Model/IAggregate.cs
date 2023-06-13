using Mc2.CrudTest.Presentation.Shared.Core.Event;

namespace Mc2.CrudTest.Presentation.Shared.Core.Model;

public interface IAggregate<T> : IAggregate, IEntity<T>
{
}

public interface IAggregate : IEntity
{
    IReadOnlyList<IDomainEvent> DomainEvents { get; }
    IEvent[] ClearDomainEvents();
}
