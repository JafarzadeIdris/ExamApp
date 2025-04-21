using Exam.Application.Abstractions.Commands;
using Exam.Application.Abstractions.Error;
using MediatR;


namespace Exam.Application.Features.Exam.RemoveExam
{
    public class RemoveExamCommandHandler(IRepository<ExamEntity> repository, IUnitOfWork unitOfWork) : ICommandHandler<RemoveExamCommand, Unit>
    {
        private readonly IRepository<ExamEntity> _repository = repository;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<Result<Unit, IDomainError>> Handle(RemoveExamCommand request, CancellationToken cancellationToken)
        {
            await _repository.DeleteAsync(request.id, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Result.Success<Unit, IDomainError>(Unit.Value);
        }
    }
}
