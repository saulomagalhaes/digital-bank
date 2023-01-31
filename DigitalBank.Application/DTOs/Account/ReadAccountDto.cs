namespace DigitalBank.Application.DTOs.Account;

public class ReadAccountDto
{
    public int Id { get; set; }
    public string Number { get; set; }
    public decimal Balance { get; set; }
    public int PersonId { get; set; }
}
