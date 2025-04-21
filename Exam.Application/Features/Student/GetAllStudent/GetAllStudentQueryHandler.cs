using Exam.Application.Common;
using Exam.Application.Dtos.Student;

namespace Exam.Application.Features.Student.GetAllStudent
{
    public class GetAllStudentQueryHandler(IRepository<StudentEntity> repository, IMapper mapper) : IListQueryHandler<GetAllStudentQuery, StudentDto>
    {
        private readonly IRepository<StudentEntity> _repository = repository;
        private readonly IMapper _mapper = mapper;


        public async Task<Result<PaginateResponse<StudentDto>>> Handle(GetAllStudentQuery request, CancellationToken cancellationToken)
        {
            var paginateEntity = await _repository.GetPaginationAsync(request.PageNumber, request.PageSize, cancellationToken: cancellationToken);

            var response = _mapper.Map<PaginateResponse<StudentDto>>(paginateEntity);
            return Result.Success(response);
        }
    }
}
