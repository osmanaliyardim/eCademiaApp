using Core.Entities;

namespace eCademiaApp.Entities.Concrete
{
    // DB Table class for Customer
    public class Customer : IEntity
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public bool Status { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}
