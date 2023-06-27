namespace Application.Services.DtoModels.Models.User
{
    public class RegisterDto
    {
        public string? Email { get; set; } = null!;

        public string? Username { get; set; } = null!;

        public string? Surname { get; set; } = null!;

        public string? Phone { get; set; } = null!;

        public string? Password { get; set; } = null!;

        public string? ConfirmPassword { get; set; } = null!;
    }
}
