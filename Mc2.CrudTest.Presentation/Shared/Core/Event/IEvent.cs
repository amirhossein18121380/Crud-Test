using MediatR;

namespace Mc2.CrudTest.Presentation.Shared.Core.Event;
public interface IEvent : INotification
{
    Guid EventId => Guid.NewGuid();
    public DateTime OccurredOn => DateTime.Now;
    public string EventType => GetType().AssemblyQualifiedName;
}
