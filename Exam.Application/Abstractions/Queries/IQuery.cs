using CSharpFunctionalExtensions;
using MediatR;


namespace Exam.Application.Abstractions.Queries
{
    public interface IRequestBase { }
    public interface IQuery<TResponse> : IRequest<Result<TResponse>>
        where TResponse : notnull
    { }
    public interface IQuery :  IRequest<Result>
    { }
}
