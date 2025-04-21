using CSharpFunctionalExtensions;
using Exam.Application.Common;
using MediatR;


namespace Exam.Application.Abstractions.Queries
{
    public interface IListQuery<TResponse> : IRequest<Result<PaginateResponse<TResponse>>>
        where TResponse : notnull
    { }
    public interface ISingleQuery<TResponse> : IRequest<Result<TResponse>>
        where TResponse : notnull
    { }

}
