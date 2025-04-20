using AutoMapper;
using Exam.Application.Dtos.Teacher;
using Exam.MVC.Models.Teacher;

namespace Exam.MVC.Models
{
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            CreateMap<TeacherDto,UpdateTeacherViewModel>();
            CreateMap<TeacherDto,CreateTeacherViewModel>();
        }
    }
}
