using Exam.Application.Dtos.Teacher;


namespace Exam.Application.Features.Teacher.GetTeacher
{
    public record GetTeacherQuery(Guid id):ISingleQuery<TeacherDto>
    {
    }
}
