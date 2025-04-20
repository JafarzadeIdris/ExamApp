using Exam.Application.Abstractions.Commands;
using MediatR;

namespace Exam.Application.Features.Teacher.RemoveTeacher
{
    public  record RemoveTeacherCommand(Guid id):ICommand<Unit>
    {
    }
}
