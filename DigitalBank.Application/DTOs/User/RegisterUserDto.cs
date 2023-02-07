using System.ComponentModel.DataAnnotations;

namespace DigitalBank.Application.DTOs.User;

public class RegisterUserDto
{
    [Required]
    public string Name { get; set; }
    [Required]
    public string Email { get; set; }
    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }
    [Required]
    [Compare("Password")]
    public string ConfirmPassword { get; set; }

}
