using Exam.Application.Common;
using Exam.Application.Dtos.Student;
using Exam.Application.Dtos.Teacher;

namespace Exam.Application.Features.Teacher.GetAllTeacher
{
    public class GetAllTeacherQueryHandler(IRepository<TeacherEntity> repository, IMapper mapper) 
        : IListQueryHandler<GetAllTeacherQuery, TeacherDto>
    {
        private readonly IRepository<TeacherEntity> _repository = repository;
        private readonly IMapper _mapper = mapper;

        public async Task<Result<PaginateResponse<TeacherDto>>> Handle(GetAllTeacherQuery request, CancellationToken cancellationToken)
        {
            var paginateEntity = await _repository.GetPaginationAsync(request.PageNumber, request.PageSize, cancellationToken: cancellationToken);

            var response = _mapper.Map<PaginateResponse<TeacherDto>>(paginateEntity);
            return Result.Success(response);
        }
    }
}
