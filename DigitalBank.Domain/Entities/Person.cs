namespace DigitalBank.Domain.Entities;

public class Person
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public ICollection<Account> Accounts { get; set; }
}


