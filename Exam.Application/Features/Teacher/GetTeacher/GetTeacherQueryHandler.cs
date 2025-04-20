using Exam.Application.Dtos.Teacher;

namespace Exam.Application.Features.Teacher.GetTeacher
{
    public class GetTeacherQueryHandler(IRepository<TeacherEntity> repository, IMapper mapper) : ISingleQueryHandler<GetTeacherQuery, TeacherDto>
    {
        private readonly IRepository<TeacherEntity> _repository = repository;
        private readonly IMapper _mapper = mapper;

        public async Task<Result<TeacherDto>> Handle(GetTeacherQuery request, CancellationToken cancellationToken)
        {
            var teacherEntity = await _repository.GetByIdAsync(request.id, cancellationToken);
            return Result.Success(_mapper.Map<TeacherDto>(teacherEntity));
        }
    }

}
