using Exam.Application.Dtos.Student;

namespace Exam.Application.Features.Student.GetStudent
{
    public class GetStudentQueryHandler(IRepository<StudentEntity> repository, IMapper mapper) : ISingleQueryHandler<GetStudentQuery, StudentDto>
    {
        private readonly IRepository<StudentEntity> _repository = repository;
        private readonly IMapper _mapper = mapper;

        public async Task<Result<StudentDto>> Handle(GetStudentQuery request, CancellationToken cancellationToken)
        {
            var studentEntity = await _repository.GetByIdAsync(request.id, cancellationToken);
            return Result.Success(_mapper.Map<StudentDto>(studentEntity));
        }
    }

}
