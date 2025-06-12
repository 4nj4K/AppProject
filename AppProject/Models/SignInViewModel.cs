using System;
using System.ComponentModel.DataAnnotations;

namespace AppProject.Models;

public class SignInViewModel
{
    [Required]
    [RegularExpression(@"")]
    [Display(Name = "Email", Prompt = "Enter email address")]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; } = null!;

    [Required]
    [RegularExpression(@"")]
    [Display(Name = "Password", Prompt = "Enter password")]
    [DataType(DataType.Password)]
    public string Password { get; set; } = null!;

    public bool IsPersistent { get; set; }
}
