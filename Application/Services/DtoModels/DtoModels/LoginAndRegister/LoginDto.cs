﻿namespace Application.Services.DtoModels.DtoModels.LoginAndRegister
{
    public class LoginDto
    {
        public string Email { get; set; } = null!;

        public string Password { get; set; } = null!;

        public bool RememberMe { get; set; }
    }
}
