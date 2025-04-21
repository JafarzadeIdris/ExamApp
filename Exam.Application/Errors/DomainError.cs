using Exam.Application.Abstractions.Error;

namespace Exam.Application.Errors
{
    public class DomainError : IDomainError
    {
        public string? Message { get; set; }
        public List<string>? ValidationErrors { get; set; }

        public DomainError(string message, List<string>? validationErrors = null)
        {
            Message = Message;
            ValidationErrors = ValidationErrors;
        }
    }
}
