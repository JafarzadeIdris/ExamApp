using Exam.Application.Common;
using Exam.Application.Dtos.Exam;
using Exam.Application.Dtos.Teacher;
using Exam.Domain.Entities;

namespace Exam.Application.Features.Exam.GetAllExam
{
    public class GetAllExamQueryHandler(IExamRepository examRepository, IMapper mapper) : IListQueryHandler<GetAllExamQuery, ExamDto>
    {
        private readonly IExamRepository _examRepository = examRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<Result<PaginateResponse<ExamDto>>> Handle(GetAllExamQuery request, CancellationToken cancellationToken)
        {
            var paginateEntity = await _examRepository.GetAllExamWithLessonAndStudent(request.PageNumber, request.PageSize, cancellationToken: cancellationToken);

            var response = _mapper.Map<PaginateResponse<ExamDto>>(paginateEntity);
            return Result.Success(response);
        }
    }
}
