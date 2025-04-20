using Exam.Application.Dtos.Teacher;

namespace Exam.Application.Features.Teacher.GetAllTeacher
{
    public class GetAllTeacherQueryHandler(IRepository<TeacherEntity> repository, IMapper mapper) : IListQueryHandler<GetAllTeacherQuery, TeacherDto>
    {
        private readonly IRepository<TeacherEntity> _repository = repository;
        private readonly IMapper _mapper=mapper ;

        public async Task<Result<List<TeacherDto>>> Handle(GetAllTeacherQuery request, CancellationToken cancellationToken)
        {
            var allTeacherEntity = await _repository.GetAllAsync(null, cancellationToken: cancellationToken);
            return Result.Success(_mapper.Map<List<TeacherDto>>(allTeacherEntity));
        }
    }
}
