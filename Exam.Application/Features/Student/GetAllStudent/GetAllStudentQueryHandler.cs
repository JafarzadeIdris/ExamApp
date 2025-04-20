using Exam.Application.Dtos.Student;

namespace Exam.Application.Features.Student.GetAllStudent
{
    public class GetAllStudentQueryHandler(IRepository<StudentEntity> repository, IMapper mapper) : IListQueryHandler<GetAllStudentQuery, StudentDto>
    {
        private readonly IRepository<StudentEntity> _repository = repository;
        private readonly IMapper _mapper=mapper ;

        public async Task<Result<List<StudentDto>>> Handle(GetAllStudentQuery request, CancellationToken cancellationToken)
        {
            var allStudentEntity = await _repository.GetAllAsync(null, cancellationToken: cancellationToken);
            return Result.Success(_mapper.Map<List<StudentDto>>(allStudentEntity));
        }
    }
}
