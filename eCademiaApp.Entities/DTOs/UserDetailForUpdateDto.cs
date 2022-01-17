using Core.Entities;

namespace eCademiaApp.Entities.DTOs
{
    // DB View (joined table) for User Update
    public class UserDetailForUpdateDto : IDto
    {
        public int Id { get; set; }
        public int? CustomerId { get; set; }
        public int? InstructorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CompanyName { get; set; }
        public string NationalIdentity { get; set; }
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
