using Exam.Application.Abstractions.Commands;
using Exam.Application.Abstractions.Error;


namespace Exam.Application.Features.Teacher.UpdateTeacher
{
    public class UpdateTeacherCommandHandler(IRepository<TeacherEntity> repository, IMapper mapper, IUnitOfWork unitOfWork) : ICommandHandler<UpdateTeacherCommand, Unit>
    {
        private readonly IRepository<TeacherEntity> _repository = repository;
        private readonly IMapper _mapper = mapper;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<Result<Unit, IDomainError>> Handle(UpdateTeacherCommand request, CancellationToken cancellationToken)
        {
            TeacherEntity entity = _mapper.Map<TeacherEntity>(request);
            _repository.Update(entity);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Result.Success<Unit, IDomainError>(Unit.Value);
        }
    }
}
