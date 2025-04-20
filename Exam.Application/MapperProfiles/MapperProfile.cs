using AutoMapper;
using Exam.Application.Dtos.Teacher;
using Exam.Application.Features.Teacher.CreateTeacher;
using Exam.Domain.Entities;

namespace Exam.Application.MapperProfiles
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<CreateTeacherCommand, TeacherEntity>();
            CreateMap<TeacherEntity, TeacherDto>();
        }
    }
}
