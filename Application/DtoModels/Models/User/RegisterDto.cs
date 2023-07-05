namespace Application.DtoModels.Models.User
{
    public class RegisterDto
    {
        public string? Email { get; set; }

        public string? Username { get; set; }

        public string? Surname { get; set; }

        public string? PhoneNumber { get; set; }

        public string? Password { get; set; }

        public string? ConfirmPassword { get; set; }
    }
}