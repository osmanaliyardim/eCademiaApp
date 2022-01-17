using Core.Entities;

namespace eCademiaApp.Entities.DTOs
{
    // DB View (joined table) for User Details
    public class UserDetailDto : IDto
    {
        public int Id { get; set; }
        public int? CustomerId { get; set; }
        public int? InstructorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string CompanyName { get; set; }
    }
}
