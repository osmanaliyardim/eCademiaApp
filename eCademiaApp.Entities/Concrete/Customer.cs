using Core.Entities;

namespace eCademiaApp.Entities.Concrete
{
    // DB Table class for Customer
    public class Customer : IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int CourseId { get; set; }
        public string CompanyName { get; set; }
        public bool Status { get; set; }
    }
}
