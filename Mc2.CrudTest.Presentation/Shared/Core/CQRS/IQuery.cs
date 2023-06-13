using MediatR;

namespace Mc2.CrudTest.Presentation.Shared.Core.CQRS;

public interface IQuery<out T> : IRequest<T>
    where T : notnull
{
}
