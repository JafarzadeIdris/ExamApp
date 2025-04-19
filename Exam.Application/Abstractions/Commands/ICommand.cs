using CSharpFunctionalExtensions;
using Exam.Application.Abstractions.Error;
using MediatR;


namespace Exam.Application.Abstractions.Commands
{
    public interface ICommand<TResponse> :  IRequest<Result<TResponse, IDomainError>>
         where TResponse : notnull
    { }

    public interface ICommand :  IRequest<Result<Unit>> { }
}
