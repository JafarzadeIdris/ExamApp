using Exam.Application.Common;
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

            CreateMap<UpdateLessonCommand, LessonEntity>();
            CreateMap<LessonEntity, LessonDto>();
            CreateMap<CreateLessonCommand, LessonEntity>();

            CreateMap<PaginateResponse<StudentEntity>, PaginateResponse<StudentDto>>();
            CreateMap<PaginateResponse<TeacherEntity>, PaginateResponse<TeacherDto>>();
            CreateMap<PaginateResponse<LessonEntity>, PaginateResponse<LessonDto>>();
            CreateMap<PaginateResponse<ExamEntity>, PaginateResponse<ExamDto>>();

            CreateMap<UpdateExamCommand, ExamEntity>();
            CreateMap<ExamEntity, ExamDto>();
            CreateMap<CreateExamCommand, ExamEntity>();
        }
    }
}
