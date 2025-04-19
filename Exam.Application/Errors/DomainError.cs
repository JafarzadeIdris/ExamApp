using Exam.Application.Abstractions.Error;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Application.Errors
{
    public class DomainError : IDomainError
    {
        public string? ErrorMessage { get; set; }
        public List<string>? Errors { get; set; }

        public DomainError(string errorMessage, List<string>? errors = null)
        {
            ErrorMessage = errorMessage;
            Errors = errors;
        }
    }
}
