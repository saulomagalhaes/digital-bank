using System.ComponentModel.DataAnnotations;

namespace DigitalBank.Application.DTOs.Person;

public class UpdatePersonDto
{
    public string Name { get; set; }
    public string Email { get; set; }
}
