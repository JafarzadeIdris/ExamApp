using Exam.Application.Abstractions.Commands;
using Exam.Application.Abstractions.Error;
using MediatR;

namespace Exam.Application.Features.Teacher.RemoveTeacher
{
    public class RemoveTeacherCommandHandler(IRepository<TeacherEntity> repository,IUnitOfWork unitOfWork) : ICommandHandler<RemoveTeacherCommand, Unit>
    {
        private readonly IRepository<TeacherEntity> _repository = repository;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<Result<Unit, IDomainError>> Handle(RemoveTeacherCommand request, CancellationToken cancellationToken)
        {
            await _repository.DeleteAsync(request.id, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Result.Success<Unit, IDomainError>(Unit.Value);
        }
    }
}
