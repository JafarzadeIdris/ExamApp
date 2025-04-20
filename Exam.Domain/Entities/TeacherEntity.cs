using Exam.Domain.Entities;
using Exam.Domain.Entities.Common;


public class TeacherEntity : BaseEntity
{
    public string FirstName { get; private set; }
    public string LastName { get; private set; }

    public ICollection<LessonEntity> Lessons { get; private set; } = new List<LessonEntity>();

    // Constructor
    public TeacherEntity(string firstName, string lastName)
    {
        SetFirstName(firstName);
        SetLastName(lastName);
    }

    public void SetFirstName(string firstName)
    {
        if (string.IsNullOrWhiteSpace(firstName))
            throw new ArgumentException("First name cannot be empty.", nameof(firstName));

        FirstName = firstName;
    }

    public void SetLastName(string lastName)
    {
        if (string.IsNullOrWhiteSpace(lastName))
            throw new ArgumentException("Last name cannot be empty.", nameof(lastName));

        LastName = lastName;
    }

    public void AddLesson(LessonEntity lesson)
    {
        if (lesson is null)
            throw new ArgumentNullException(nameof(lesson));

        Lessons.Add(lesson);
    }

    public void RemoveLesson(LessonEntity lesson)
    {
        if (lesson is null)
            throw new ArgumentNullException(nameof(lesson));

        Lessons.Remove(lesson);
    }

}
