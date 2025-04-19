using CSharpFunctionalExtensions;
using MediatR;


namespace Exam.Application.Abstractions.Commands
{
    public interface ICommand<TResponse> :  IRequest<Result<TResponse>>
         where TResponse : notnull
    { }

    public interface ICommand :  IRequest<Result<Unit>> { }
}
