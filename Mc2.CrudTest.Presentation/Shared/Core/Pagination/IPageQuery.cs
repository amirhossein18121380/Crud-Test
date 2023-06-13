namespace Mc2.CrudTest.Presentation.Shared.Core.Pagination;

using MediatR;

public interface IPageQuery<out TResponse> : IPageRequest, IRequest<TResponse>
    where TResponse : class
{ }
