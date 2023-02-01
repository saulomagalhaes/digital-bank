namespace DigitalBank.Application.DTOs.Transaction;

public class ReadTransactionDto
{
    public int Id { get; set; }
    public decimal Amount { get; set; }
    public string Description { get; set; }
    public int AccountId { get; set; }
}
