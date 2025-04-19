
using Exam.Domain.Entities.Common;

namespace Exam.Domain.Entities
{
    public class StudentEntity : BaseEntity
    {
        public int Number { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int ClassLevel { get; set; }
        public ICollection<ExamEntity> Exams { get; set; }
    }
}
