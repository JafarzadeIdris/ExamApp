using Exam.Application.Dtos.Student;
using Exam.Application.Dtos.Teacher;
using Exam.Application.Features.Student.CreateStudent;
using Exam.Application.Features.Student.UpdateStudent;
using Exam.Application.Features.Teacher.CreateTeacher;
using Exam.Application.Features.Teacher.UpdateTeacher;

namespace Exam.Application.MapperProfiles
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<CreateTeacherCommand, TeacherEntity>();
            CreateMap<UpdateTeacherCommand, TeacherEntity>();
            CreateMap<TeacherEntity, TeacherDto>();
            CreateMap<CreateStudentCommand, StudentEntity>();
            CreateMap<UpdateStudentCommand, StudentEntity>();
            CreateMap<StudentEntity, StudentDto>();
        }
    }
}
