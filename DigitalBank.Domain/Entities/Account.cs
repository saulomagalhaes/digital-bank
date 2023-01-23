using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DigitalBank.Domain.Entities;

[Table("accounts")]
public class Account
{
    [Key]
    [Required]
    public int Id { get; set; }
    [Required(ErrorMessage = "O campo o Number é obrigatório")]
    public string Number { get; set; }
    [Required(ErrorMessage ="O campo Balance é obrigatório")]
    [Column(TypeName = "decimal(20,2)")]
    public decimal Balance { get; set; }

    public string UserId { get; set; }
    public IdentityUser User { get; set; }
}
