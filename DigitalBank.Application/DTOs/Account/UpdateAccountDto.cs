using System.ComponentModel.DataAnnotations;

namespace DigitalBank.Application.DTOs.Account;

public class UpdateAccountDto
{
    public string Number { get; set; }
    public decimal Balance { get; set; }
}
