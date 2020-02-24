using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BlazorForum.Models
{
    public class RegisterInputModel
    {
        [Required]
        [DataType(DataType.Text)]
        [RegularExpression("([a-zA-Z0-9_-]+)",
            ErrorMessage = "Please check your username for formatting errors. It may only " +
            "contain letters, numbers, underscores, and hyphens.")]
        [MaxLength(15, ErrorMessage = "The username must be between 3 to 15 characters.")]
        [MinLength(3, ErrorMessage = "The username must be between 3 to 15 characters.")]
        [Display(Name = "Username")]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
