using DigitalBank.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DigitalBank.Infra.Data.Maps;

public class AccountMap : IEntityTypeConfiguration<Account>
{
    public void Configure(EntityTypeBuilder<Account> builder)
    {
        builder.ToTable("accounts");

        builder.HasKey(a => a.Id);
        builder.Property(a => a.Id)
            .UseIdentityColumn()
            .HasColumnName("id")
            .IsRequired();

        builder.Property(a => a.Number)
            .HasColumnName("number")
            .IsRequired();

        builder.Property(a => a.Balance)
            .HasColumnName("balance")
            .IsRequired();

        builder.Property(a => a.PersonId)
            .HasColumnName("person_id");

        builder.HasOne(a => a.Person)
            .WithMany(p => p.Accounts)
            .HasForeignKey(a => a.PersonId);
    }
}
