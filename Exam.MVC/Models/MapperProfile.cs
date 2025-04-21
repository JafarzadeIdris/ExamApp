using AutoMapper;
using Exam.Application.Dtos.Exam;
using Exam.Application.Dtos.Lesson;
using Exam.Application.Dtos.Student;
using Exam.Application.Dtos.Teacher;
using Exam.Application.Features.Exam.CreateExam;
using Exam.Application.Features.Exam.UpdateExam;
using Exam.Application.Features.Lesson.CreateLesson;
using Exam.Application.Features.Lesson.UpdateLesson;
using Exam.Application.Features.Student.CreateStudent;
using Exam.Application.Features.Student.UpdateStudent;
using Exam.Application.Features.Teacher.CreateTeacher;
using Exam.Application.Features.Teacher.UpdateTeacher;
using Exam.MVC.Models.Exam;
using Exam.MVC.Models.Lesson;
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

            CreateMap<LessonDto, UpdateLessonViewModel>();
            CreateMap<LessonDto, CreateLessonViewModel>();
            CreateMap<CreateLessonViewModel, CreateLessonCommand>();
            CreateMap<UpdateLessonViewModel, UpdateLessonCommand>();

            CreateMap<ExamDto, UpdateExamViewModel>();
            CreateMap<ExamDto, CreateExamViewModel>();
            CreateMap<CreateExamViewModel, CreateExamCommand>();
            CreateMap<UpdateExamViewModel, UpdateExamCommand>();
        }
    }
}
