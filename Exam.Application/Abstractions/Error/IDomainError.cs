using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Application.Abstractions.Error
{
    public interface IDomainError
    {
        string ErrorMessage { get; set; }
        public List<string>? Errors { get; set; }
    }
}
