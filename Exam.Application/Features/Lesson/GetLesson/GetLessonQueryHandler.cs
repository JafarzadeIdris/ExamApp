using Exam.Application.Dtos.Lesson;
using Exam.Application.Features.Lesson.Lesson;

namespace Exam.Application.Features.Lesson.GetLesson
{
    public class GetLessonQueryHandler(IRepository<LessonEntity> repository, IMapper mapper) : ISingleQueryHandler<GetLessonQuery, LessonDto>
    {
        private readonly IRepository<LessonEntity> _repository = repository;
        private readonly IMapper _mapper = mapper;

        public async Task<Result<LessonDto>> Handle(GetLessonQuery request, CancellationToken cancellationToken)
        {
            var lessonEntity = await _repository.GetByIdAsync(request.id, cancellationToken);
            return Result.Success(_mapper.Map<LessonDto>(lessonEntity));
        }
    }

}
