using System.ComponentModel.DataAnnotations;

namespace DigitalBank.Application.DTOs.Transaction;

public class CreateTransactionDto
{
    [Required]
    public decimal Amount { get; set; }
    [Required]
    public string Description { get; set; }
    [Required]
    public int AccountId { get; set; }
}
