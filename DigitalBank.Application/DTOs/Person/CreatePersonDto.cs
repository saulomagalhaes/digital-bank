using System.ComponentModel.DataAnnotations;

namespace DigitalBank.Application.DTOs.Person;

public class CreatePersonDto
{
    [Required]
    public string Name { get; set; }
    [Required]
    public string Email { get; set; }
}
