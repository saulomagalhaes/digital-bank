using DigitalBank.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DigitalBank.Infra.Data.Maps;

public class TransactionMap : IEntityTypeConfiguration<Transaction>
{
    public void Configure(EntityTypeBuilder<Transaction> builder)
    {
        builder.ToTable("transactions");

        builder.HasKey(t => t.Id);
        builder.Property(t => t.Id)
            .UseIdentityColumn()
            .HasColumnName("id")
            .IsRequired();

        builder.Property(t => t.Amount)
            .HasColumnName("amount")
            .IsRequired();

        builder.Property(t => t.Description)
            .HasColumnName("description")
            .IsRequired();

        builder.Property(t => t.AccountId)
            .HasColumnName("account_id");

        builder.HasOne(t => t.Account)
            .WithMany(a => a.Transactions)
            .HasForeignKey(t => t.AccountId);
    }
}
