using DigitalBank.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DigitalBank.Infra.Context;

public class DigitalBankContext : DbContext
{
    public DigitalBankContext(DbContextOptions<DigitalBankContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<Account> Accounts { get; set; }
    public DbSet<Transaction> Transactions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DigitalBankContext).Assembly);
    }
}
