using Exam.Application.Abstractions.Commands;
using Exam.Application.Abstractions.Error;


namespace Exam.Application.Features.Student.CreateStudent
{
    public class CreateStudentCommandHandler(IRepository<StudentEntity> repository, IMapper mapper, IUnitOfWork unitOfWork) : ICommandHandler<CreateStudentCommand, Unit>
    {
        private readonly IRepository<StudentEntity> _repository = repository;
        private readonly IMapper _mapper = mapper;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<Result<Unit, IDomainError>> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            StudentEntity entity = _mapper.Map<StudentEntity>(request);
            await _repository.AddAsync(entity, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Result.Success<Unit, IDomainError>(Unit.Value);
        }
    }
}
