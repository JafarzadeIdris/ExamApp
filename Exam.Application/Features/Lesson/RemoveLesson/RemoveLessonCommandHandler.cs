using Exam.Application.Abstractions.Commands;
using Exam.Application.Abstractions.Error;
using MediatR;


namespace Exam.Application.Features.Lesson.RemoveLesson
{
    public class RemoveLessonCommandHandler(IRepository<LessonEntity> repository, IUnitOfWork unitOfWork) : ICommandHandler<RemoveLessonCommand, Unit>
    {
        private readonly IRepository<LessonEntity> _repository = repository;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<Result<Unit, IDomainError>> Handle(RemoveLessonCommand request, CancellationToken cancellationToken)
        {
            await _repository.DeleteAsync(request.id, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Result.Success<Unit, IDomainError>(Unit.Value);
        }
    }
}
