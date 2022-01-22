using Core.Entities;

namespace eCademiaApp.Entities.Concrete
{
    public class Enrollment : IEntity
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public int CustomerId { get; set; }
        public int InstructorId { get; set; }
        public int UserId { get; set; }
        public Int16 Process { get; set; } //smallint == short
    }
}
