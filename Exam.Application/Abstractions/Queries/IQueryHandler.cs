using Exam.Application.Common;

namespace Exam.Application.Abstractions.Queries
{
    public interface ISingleQueryHandler<TRequest, TResponse>: IRequestHandler<TRequest, Result<TResponse>>
    where TRequest : ISingleQuery<TResponse>
    where TResponse : notnull
    { }

    public interface IListQueryHandler<TRequest, TResponse>: IRequestHandler<TRequest, Result<PaginateResponse<TResponse>>>
        where TRequest : IListQuery<TResponse>
        where TResponse : notnull
    { }
}
