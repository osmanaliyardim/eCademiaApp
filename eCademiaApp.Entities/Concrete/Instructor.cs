using Core.Entities;

namespace eCademiaApp.Entities.Concrete
{
    // DB Table class for Instructor
    public class Instructor : IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string CompanyName { get; set; }
        public bool Status { get; set; }
    }
}
