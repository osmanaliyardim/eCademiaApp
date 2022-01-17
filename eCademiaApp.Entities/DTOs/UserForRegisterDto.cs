using Core.Entities;

namespace eCademiaApp.Entities.DTOs
{
    // DB View (joined table) for User Registeration
    public class UserForRegisterDto : IDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}