using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Application.Abstractions.Error
{
    public interface IDomainError
    {
        public string? Message { get; set; }
        public List<string>? ValidationErrors { get; set; }
    }
}
