using Exam.Application.Abstractions.Commands;
using Exam.Application.Abstractions.Error;
using MediatR;

namespace Exam.Application.Features.Student.UpdateStudent
{
    public class UpdateStudentCommandHandler(IRepository<StudentEntity> repository, IMapper mapper, IUnitOfWork unitOfWork) : ICommandHandler<UpdateStudentCommand, Unit>
    {
        private readonly IRepository<StudentEntity> _repository = repository;
        private readonly IMapper _mapper = mapper;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<Result<Unit, IDomainError>> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {
            StudentEntity entity = _mapper.Map<StudentEntity>(request);
            _repository.Update(entity);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Result.Success<Unit, IDomainError>(Unit.Value);
        }
    }
}
