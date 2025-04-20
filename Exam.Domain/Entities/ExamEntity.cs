using Exam.Domain.Entities.Common;

namespace Exam.Domain.Entities
{
    public class ExamEntity : BaseEntity
    {
        public DateTime ExamDate { get; private set; }
        public int Score { get; private set; }

        public Guid LessonId { get; private set; }
        public LessonEntity Lesson { get; private set; }

        public Guid StudentId { get; private set; }
        public StudentEntity Student { get; private set; }

        // Constructor
        public ExamEntity(DateTime examDate, int score, Guid lessonId, Guid studentId)
        {
            SetExamDate(examDate);
            SetScore(score);
            SetLesson(lessonId);
            SetStudent(studentId);
        }

        public void SetExamDate(DateTime date)
        {
            if (date == default)
                throw new ArgumentException("Exam date must be a valid date.", nameof(date));

            if (date > DateTime.UtcNow.AddDays(1))
                throw new ArgumentException("Exam date cannot be in the far future.", nameof(date));

            ExamDate = date;
        }

        public void SetScore(int score)
        {
            if (score < 0 || score > 100)
                throw new ArgumentOutOfRangeException(nameof(score), "Score must be between 0 and 100.");

            Score = score;
        }

        public void SetLesson(Guid lessonId)
        {
            if (lessonId == Guid.Empty)
                throw new ArgumentException("LessonId cannot be empty.", nameof(lessonId));

            LessonId = lessonId;
        }

        public void SetStudent(Guid studentId)
        {
            if (studentId == Guid.Empty)
                throw new ArgumentException("StudentId cannot be empty.", nameof(studentId));

            StudentId = studentId;
        }

    }
}
