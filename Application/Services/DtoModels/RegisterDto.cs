﻿using System.ComponentModel.DataAnnotations;

namespace WebApi
{
    public class RegisterDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [Required]
        public string? Surname { get; set; } = null!;

        [Required]
        public string? Phone { get; set; } = null!;

        [Required]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        public string Password { get; set; } = null!;

        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; } = null!;
    }
}