using Exam.Application.Dtos.Teacher;
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
        }
    }
}
