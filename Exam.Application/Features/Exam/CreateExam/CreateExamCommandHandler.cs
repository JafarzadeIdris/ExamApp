using CSharpFunctionalExtensions;
using Exam.Application.Abstractions.Commands;
using Exam.Application.Abstractions.Error;
using MediatR;

namespace Exam.Application.Features.Exam.CreateExam
{
    public class CreateExamCommandHandler(IRepository<ExamEntity> repository, IMapper mapper, IUnitOfWork unitOfWork) : ICommandHandler<CreateExamCommand, Unit>
    {
        private readonly IRepository<ExamEntity> _repository = repository;
        private readonly IMapper _mapper = mapper;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<Result<Unit, IDomainError>> Handle(CreateExamCommand request, CancellationToken cancellationToken)
        {

            ExamEntity entity = _mapper.Map<ExamEntity>(request);
            await _repository.AddAsync(entity, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return Result.Success<Unit, IDomainError>(Unit.Value);
        }
    }
}
