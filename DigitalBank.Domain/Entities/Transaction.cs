using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DigitalBank.Domain.Entities;

[Table("transactions")]
public class Transaction
{
    [Key]
    [Required]
    public int Id { get; set; }
    [Required(ErrorMessage = "O campo o Amount é obrigatório")]
    [Column(TypeName = "decimal(20,2)")]
    public decimal Amount { get; set; }
    [Required(ErrorMessage = "O campo o Description é obrigatório")]
    public string Description { get; set; }

    public int AccountId { get; set; }
    public Account Account { get; set; }
}
