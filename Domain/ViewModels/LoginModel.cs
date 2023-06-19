using System.ComponentModel.DataAnnotations;

namespace WebApi
{
    public class LoginModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [Required]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        public string Password { get; set; } = null!;

        public bool RememberMe { get; set; }
    }
}
