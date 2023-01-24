namespace DigitalBank.Domain.Entities;

public class Account
{
    public int Id { get; set; }
    public string Number { get; set; }
    public decimal Balance { get; set; }
    public int PersonId { get; set; }
    public Person Person { get; set; }
    public ICollection<Transaction> Transactions { get; set; }
}


