using Core.Entities;

namespace eCademiaApp.Entities.Concrete
{
    // DB Table class for Course
    public class Course : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal SalePrice { get; set; }
        public string Description { get; set; }
        public double Point { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public Int64 Duration { get; set; } //bigint == long
        public string Language { get; set; }
        public int StudentNumber { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}
