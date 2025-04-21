using Exam.Application.Abstractions.Commands;
using Exam.Application.Abstractions.Error;
using MediatR;

namespace Exam.Application.Features.Exam.UpdateExam
{
    public class UpdateExamCommandHandler(IRepository<ExamEntity> repository, IMapper mapper, IUnitOfWork unitOfWork) : ICommandHandler<UpdateExamCommand, Unit>
    {
        private readonly IRepository<ExamEntity> _repository = repository;
        private readonly IMapper _mapper = mapper;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<Result<Unit, IDomainError>> Handle(UpdateExamCommand request, CancellationToken cancellationToken)
        {
            ExamEntity entity = _mapper.Map<ExamEntity>(request);
            _repository.Update(entity);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Result.Success<Unit, IDomainError>(Unit.Value);
        }
    }
}
