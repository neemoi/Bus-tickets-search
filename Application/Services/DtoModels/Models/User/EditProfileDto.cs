namespace Application.Services.DtoModels.Models.User
{
    public class EditProfileDto
    {
        public string? Email { get; set; }

        public string? Password { get; set; }

        public string? ConfirmPassword { get; set; }

        public string? CurrentPassword { get; set; }

        public string? UserName { get; set; }

        public string? Surname { get; set; }

        public string? PhoneNumber { get; set; }
    }
}
