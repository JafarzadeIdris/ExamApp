using Exam.Application.Abstractions.Commands;
using Exam.Application.Abstractions.Error;
using MediatR;


namespace Exam.Application.Features.Lesson.CreateLesson
{
    public class CreateLessonCommandHandler(IRepository<LessonEntity> repository, IMapper mapper, IUnitOfWork unitOfWork) : ICommandHandler<CreateLessonCommand, Unit>
    {
        private readonly IRepository<LessonEntity> _repository = repository;
        private readonly IMapper _mapper = mapper;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<Result<Unit, IDomainError>> Handle(CreateLessonCommand request, CancellationToken cancellationToken)
        {
            LessonEntity entity = _mapper.Map<LessonEntity>(request);
            await _repository.AddAsync(entity, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Result.Success<Unit, IDomainError>(Unit.Value);
        }
    }
}
