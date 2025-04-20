using Exam.Application.Dtos.Student;


namespace Exam.Application.Features.Student.GetStudent
{
    public record GetStudentQuery(Guid id):ISingleQuery<StudentDto>
    {
    }
}
