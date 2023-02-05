using DigitalBank.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DigitalBank.Infra.Data.Maps;

public class UserPermissionMap : IEntityTypeConfiguration<UserPermission>
{
    public void Configure(EntityTypeBuilder<UserPermission> builder)
    {
        builder.ToTable("userPermission");

        builder.HasKey(up => up.Id);
        builder.Property(up => up.Id)
            .UseIdentityColumn()
            .HasColumnName("id")
            .IsRequired();

        builder.Property(up => up.UserId)
            .HasColumnName("user_id")
            .IsRequired();

        builder.Property(up => up.PermissionId)
            .HasColumnName("permission_id")
            .IsRequired();

        builder.HasOne(up => up.Permission)
            .WithMany(p => p.userPermissions)
            .HasForeignKey(up => up.PermissionId);

        builder.HasOne(up => up.User)
            .WithMany(p => p.userPermissions)
            .HasForeignKey(up => up.UserId);
    }
}
