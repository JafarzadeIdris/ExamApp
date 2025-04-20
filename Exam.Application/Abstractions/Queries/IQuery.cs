using CSharpFunctionalExtensions;
using MediatR;


namespace Exam.Application.Abstractions.Queries
{
    public interface IListQuery<TResponse> : IRequest<Result<List<TResponse>>>
        where TResponse : notnull
    { }
    public interface ISingleQuery<TResponse> : IRequest<Result<TResponse>>
        where TResponse : notnull
    { }

}
