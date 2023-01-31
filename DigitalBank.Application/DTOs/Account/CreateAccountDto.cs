using System.ComponentModel.DataAnnotations;

namespace DigitalBank.Application.DTOs.Account;

public class CreateAccountDto
{
    [Required]
    public string Number { get; set; }
    [Required]
    public decimal Balance { get; set; }
    [Required]
    public int PersonId { get; set; }
}
