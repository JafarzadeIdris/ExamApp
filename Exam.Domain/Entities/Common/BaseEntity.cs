
namespace Exam.Domain.Entities.Common
{
    public class BaseEntity
    {
        public BaseEntity()
        {
                CreatedDate = DateTime.Now;
        }
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
