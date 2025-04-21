using Exam.Application.Dtos.Exam;

namespace Exam.Application.Features.Exam.GetExam
{
    public class GetExamQueryHandler(IRepository<ExamEntity> repository, IMapper mapper) : ISingleQueryHandler<GetExamQuery, ExamDto>
    {
        private readonly IRepository<ExamEntity> _repository = repository;
        private readonly IMapper _mapper = mapper;

        public async Task<Result<ExamDto>> Handle(GetExamQuery request, CancellationToken cancellationToken)
        {
            var examEntity = await _repository.GetByIdAsync(request.id, cancellationToken);
            return Result.Success(_mapper.Map<ExamDto>(examEntity));
        }
    }

}
