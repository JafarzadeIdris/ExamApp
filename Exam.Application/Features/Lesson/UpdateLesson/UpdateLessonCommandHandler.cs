using Exam.Application.Abstractions.Commands;
using Exam.Application.Abstractions.Error;
using MediatR;

namespace Exam.Application.Features.Lesson.UpdateLesson
{
    public class UpdateLessonCommandHandler(IRepository<LessonEntity> repository, IMapper mapper, IUnitOfWork unitOfWork) : ICommandHandler<UpdateLessonCommand, Unit>
    {
        private readonly IRepository<LessonEntity> _repository = repository;
        private readonly IMapper _mapper = mapper;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<Result<Unit, IDomainError>> Handle(UpdateLessonCommand request, CancellationToken cancellationToken)
        {
            LessonEntity entity = _mapper.Map<LessonEntity>(request);
            _repository.Update(entity);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Result.Success<Unit, IDomainError>(Unit.Value);
        }
    }
}
