using CSharpFunctionalExtensions;
using Exam.Application.Abstractions.Commands;
using Exam.Application.Abstractions.Error;
using Exam.Application.Abstractions.Repository;
using Exam.Domain.Entities;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Exam.Application.Features.Exam.CreateExam
{
    //public class CreateExamCommandHandler : ICommandHandler<CreateExamCommand, Unit>
    //{
    //    private readonly IRepository<ExamEntity> _repository;
    //    private readonly IServiceScopeFactory _scopeFactory;

    //    public CreateExamCommandHandler(IRepository<ExamEntity> repository, IServiceScopeFactory scopeFactory)
    //    {
    //        _repository = repository;
    //        _scopeFactory = scopeFactory;
    //    }

    //    public Task<Result<Unit, IDomainError>> Handle(CreateExamCommand request, CancellationToken cancellationToken)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}
}
