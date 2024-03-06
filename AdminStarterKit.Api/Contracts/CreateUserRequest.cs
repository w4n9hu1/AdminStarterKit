using System.ComponentModel.DataAnnotations;

namespace AdminStarterKit.Api.Contracts
{
    public class CreateUserRequest
    {
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string Email { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }
    }
}
