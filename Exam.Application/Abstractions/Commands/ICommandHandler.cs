using CSharpFunctionalExtensions;
using Exam.Application.Abstractions.Error;
using MediatR;

namespace Exam.Application.Abstractions.Commands
{

    public interface ICommandHandler<TRequest, TResponse> : IRequestHandler<TRequest, Result<TResponse, IDomainError>>
        where TRequest : ICommand<TResponse>
        where TResponse : notnull
    { }

    public interface ICommandHandler<TRequest> : IRequestHandler<TRequest, Result<Unit>>
        where TRequest : ICommand
    { }
}
