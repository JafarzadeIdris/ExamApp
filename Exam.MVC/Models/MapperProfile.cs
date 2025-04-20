using AutoMapper;
using Exam.Application.Dtos.Student;
using Exam.Application.Dtos.Teacher;
using Exam.Application.Features.Student.CreateStudent;
using Exam.Application.Features.Student.UpdateStudent;
using Exam.Application.Features.Teacher.CreateTeacher;
using Exam.Application.Features.Teacher.UpdateTeacher;
using Exam.MVC.Models.Student;
using Exam.MVC.Models.Teacher;

namespace Exam.MVC.Models
{
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            CreateMap<TeacherDto,UpdateTeacherViewModel>();
            CreateMap<TeacherDto,CreateTeacherViewModel>();
            CreateMap<CreateTeacherViewModel, CreateTeacherCommand>();
            CreateMap<UpdateTeacherViewModel, UpdateTeacherCommand>();

            CreateMap<StudentDto, UpdateStudentViewModel>();
            CreateMap<StudentDto, CreateStudentViewModel>();
            CreateMap<CreateStudentViewModel, CreateStudentCommand>();
            CreateMap<UpdateStudentViewModel, UpdateStudentCommand>();
        }
    }
}
