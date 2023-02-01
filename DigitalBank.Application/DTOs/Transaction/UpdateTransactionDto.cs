using System.ComponentModel.DataAnnotations;

namespace DigitalBank.Application.DTOs.Transaction;

public class UpdateTransactionDto
{
    public decimal Amount { get; set; }
    public string Description { get; set; }
}
