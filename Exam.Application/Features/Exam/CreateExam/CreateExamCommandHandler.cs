using CSharpFunctionalExtensions;
using Exam.Application.Abstractions.Commands;
using Exam.Application.Repositories;
using Exam.Domain.Entities;

namespace Exam.Application.Features.Exam.CreateExam
{
    public class CreateExamCommandHandler : ICommandHandler<CreateExamCommand, Guid>
    {
        private readonly IRepository<ExamEntity> _repository;

        public CreateExamCommandHandler(IRepository<ExamEntity> repository)
        {
            _repository = repository;
        }

        public async Task<Result<Guid>> Handle(CreateExamCommand request, CancellationToken cancellationToken)
        {
                var response = await _repository.AddAsync(new ExamEntity { Name = "Test", Id = Guid.NewGuid() }, cancellationToken);

            return await Task.FromResult(Result.Success<Guid>(Guid.NewGuid()));
        }
    }
}
