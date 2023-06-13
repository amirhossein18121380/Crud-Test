using MediatR;

namespace Mc2.CrudTest.Presentation.Shared.Core.CQRS;

public interface ICommand : ICommand<Unit>
{
}

public interface ICommand<out T> : IRequest<T>
    where T : notnull
{
}
