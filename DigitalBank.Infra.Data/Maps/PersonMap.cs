using DigitalBank.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DigitalBank.Infra.Data.Maps;

public class PersonMap : IEntityTypeConfiguration<Person>
{
    public void Configure(EntityTypeBuilder<Person> builder)
    {
        builder.ToTable("people");
        
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id)
            .UseIdentityColumn()
            .HasColumnName("id")
            .IsRequired();

        builder.Property(p => p.Name)
            .HasColumnName("name")
            .IsRequired();

        builder.Property(p => p.Email)
            .HasColumnName("email")
            .IsRequired();
    }
}
