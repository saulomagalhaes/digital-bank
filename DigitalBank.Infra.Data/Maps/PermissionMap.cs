using DigitalBank.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DigitalBank.Infra.Data.Maps;

public class PermissionMap : IEntityTypeConfiguration<Permission>
{
    public void Configure(EntityTypeBuilder<Permission> builder)
    {
        builder.ToTable("permissions");

        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id)
            .UseIdentityColumn()
            .HasColumnName("id")
            .IsRequired();

        builder.Property(p => p.VisualName)
            .HasColumnName("visual_name")
            .IsRequired();

        builder.Property(p => p.PermissionName)
            .HasColumnName("permission_name")
            .IsRequired();

        builder.HasMany(p => p.userPermissions)
            .WithOne(u => u.Permission)
            .HasForeignKey(p => p.PermissionId);
    }
}
