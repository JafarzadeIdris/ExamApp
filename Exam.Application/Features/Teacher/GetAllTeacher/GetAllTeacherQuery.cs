using Exam.Application.Dtos.Teacher;

namespace Exam.Application.Features.Teacher.GetAllTeacher
{
    public record GetAllTeacherQuery: IListQuery<TeacherDto>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
