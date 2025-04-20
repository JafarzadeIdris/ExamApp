using Exam.Domain.Entities;
using Exam.Domain.Entities.Common;
using System.Xml.Linq;

public class StudentEntity : BaseEntity
{
    public int Number { get; private set; }
    public string Name { get; private set; }
    public string Surname { get; private set; }
    public int ClassLevel { get; private set; }

    public ICollection<ExamEntity> Exams { get; private set; } = new List<ExamEntity>();

    public StudentEntity(int number, string name, string surname, int classLevel)
    {
        SetNumber(number);
        SetName(name);
        SetSurname(surname);
        SetClassLevel(classLevel);
    }

    public void SetNumber(int number)
    {
        if (number < 1 || number > 99999)
            throw new ArgumentOutOfRangeException(nameof(number), "Student number must be between 1 and 99999.");

        Number = number;
    }

    public void SetName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Student name cannot be empty.", nameof(name));
        if (name.Length > 20)
            throw new ArgumentException("Student name cannot be longer than 20 characters.", nameof(name));

        Name = name;
    }

    public void SetSurname(string surname)
    {
        if (string.IsNullOrWhiteSpace(surname))
            throw new ArgumentException("Student surname cannot be empty.", nameof(surname));
        if (surname.Length > 20)
            throw new ArgumentException("Student name cannot be longer than 20 characters.", nameof(surname));

        Surname = surname;
    }

    public void SetClassLevel(int classLevel)
    {
        if (classLevel is < 1 or > 11)
            throw new ArgumentOutOfRangeException(nameof(classLevel), "Class level must be between 1 and 11.");

        ClassLevel = classLevel;
    }   

    public void AddExam(ExamEntity exam)
    {
        if (exam is null)
            throw new ArgumentNullException(nameof(exam));

        Exams.Add(exam);
    }
}
