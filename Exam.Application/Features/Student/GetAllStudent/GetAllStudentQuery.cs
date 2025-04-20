using Exam.Application.Dtos.Student;

namespace Exam.Application.Features.Student.GetAllStudent
{
    public record GetAllStudentQuery: IListQuery<StudentDto>
    {
    }
}
