using Exam.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Domain.Entities
{
    public class LessonEntity:BaseEntity
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public int ClassLevel { get; set; }
        public Guid TeacherId { get; set; } 
        public TeacherEntity Teacher { get; set; }
        public ICollection<ExamEntity> Exams { get; set; }

    }
}
