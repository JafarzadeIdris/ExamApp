using AutoMapper;
using Exam.Application.Features.Teacher;
using Exam.Domain.Entities;

namespace Exam.Application.MapperProfiles
{
    public class MapperProfile: Profile
    {
        public MapperProfile()
        {
            CreateMap<TeacherEntity, CreateTeacherCommand>().ReverseMap();
        }
    }
}
