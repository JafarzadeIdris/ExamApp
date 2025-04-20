using Exam.Domain.Entities;
using Exam.Domain.Entities.Common;


public class LessonEntity : BaseEntity
{
    public string Name { get; private set; }
    public string Code { get; private set; }
    public int ClassLevel { get; private set; }
    public Guid TeacherId { get; private set; }

    public TeacherEntity Teacher { get; private set; }
    public ICollection<ExamEntity> Exams { get; private set; } = new List<ExamEntity>();

    public LessonEntity(string name, string code, int classLevel, Guid teacherId)
    {
        SetName(name);
        SetCode(code);
        SetClassLevel(classLevel);
        TeacherId = teacherId;
    }

    public void SetName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Lesson name cannot be empty", nameof(name));

        Name = name;
    }

    public void SetCode(string code)
    {
        if (string.IsNullOrWhiteSpace(code))
            throw new ArgumentException("Lesson code cannot be empty", nameof(code));

        Code = code;
    }

    public void SetClassLevel(int level)
    {
        if (level < 1 || level > 11)
            throw new ArgumentOutOfRangeException(nameof(level), "Class level must be between 1 and 11");

        ClassLevel = level;
    }

    public void ChangeTeacher(Guid newTeacherId)
    {
        if (newTeacherId == Guid.Empty)
            throw new ArgumentException("Teacher ID must not be empty", nameof(newTeacherId));

        TeacherId = newTeacherId;
    }

    public void AddExam(ExamEntity exam)
    {
        if (exam is null)
            throw new ArgumentNullException(nameof(exam));

        Exams.Add(exam);
    }

}
