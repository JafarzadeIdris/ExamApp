using Exam.Application.Abstractions.Commands;
using Exam.Application.Abstractions.Error;


namespace Exam.Application.Features.Student.RemoveStudent
{
    public class RemoveStudentCommandHandler(IRepository<StudentEntity> repository,IUnitOfWork unitOfWork) : ICommandHandler<RemoveStudentCommand, Unit>
    {
        private readonly IRepository<StudentEntity> _repository = repository;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<Result<Unit, IDomainError>> Handle(RemoveStudentCommand request, CancellationToken cancellationToken)
        {
            await _repository.DeleteAsync(request.id, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Result.Success<Unit, IDomainError>(Unit.Value);
        }
    }
}
