using Exam.Application.Common;
using Exam.Application.Dtos.Lesson;

namespace Exam.Application.Features.Lesson.GetAllLesson
{
    public class GetAllLessonQueryHandler(IRepository<LessonEntity> repository, IMapper mapper) : IListQueryHandler<GetAllLessonQuery, LessonDto>
    {
        private readonly IRepository<LessonEntity> _repository = repository;
        private readonly IMapper _mapper = mapper;

        public async Task<Result<PaginateResponse<LessonDto>>> Handle(GetAllLessonQuery request, CancellationToken cancellationToken)
        {
            var paginateEntity = await _repository.GetPaginationAsync(request.PageNumber, request.PageSize, cancellationToken: cancellationToken);

            var response = _mapper.Map<PaginateResponse<LessonDto>>(paginateEntity);
            return Result.Success(response);
        }
    }
}
