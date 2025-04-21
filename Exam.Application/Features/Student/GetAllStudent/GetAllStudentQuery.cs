using Exam.Application.Common;
using Exam.Application.Dtos.Student;

namespace Exam.Application.Features.Student.GetAllStudent
{
    public record GetAllStudentQuery: IListQuery<StudentDto>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
