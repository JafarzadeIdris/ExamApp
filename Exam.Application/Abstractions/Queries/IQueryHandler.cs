using CSharpFunctionalExtensions;
using MediatR;

namespace Exam.Application.Abstractions.Queries
{
    public interface IQueryHandler<TRequest, TResponse> : IRequestHandler<TRequest, Result<TResponse>>
       where TRequest : IQuery<TResponse>
       where TResponse : notnull
    { }
}
