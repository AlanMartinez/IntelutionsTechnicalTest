using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class PermissionTypeConfiguration : IEntityTypeConfiguration<PermissionType>
    {
        public void Configure(EntityTypeBuilder<PermissionType> builder)
        {
            builder.ToTable("PermissionType");
            builder.HasKey(b => b.Id);
            builder.Property(o => o.Id).ValueGeneratedOnAdd();
            builder
                .Property<string>("Description")
                .HasColumnName("Description")
                .IsRequired();
        }
    }
}