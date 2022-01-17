using Core.Entities;

namespace eCademiaApp.Entities.DTOs
{
    // DB View (joined table) for User Login
    public class UserForLoginDto : IDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}