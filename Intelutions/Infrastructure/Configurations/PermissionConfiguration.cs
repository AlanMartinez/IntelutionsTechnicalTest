using System;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    class PermissionConfiguration : IEntityTypeConfiguration<Permission>
    {
        public void Configure(EntityTypeBuilder<Permission> builder)
        {
            builder.ToTable("Permission");
            builder.HasKey(p => p.Id);
            builder.Property(e => e.Id).ValueGeneratedOnAdd();
            builder.Ignore(p => p.PermissionType);
            builder
                .Property<string>("EmployeeName")
                .HasColumnName("EmployeeName")
                .IsRequired();
            builder
                .Property<string>("EmployeeLastName")
                .HasColumnName("EmployeeLastName")
                .IsRequired();
            builder
                .Property<DateTime>("PermissionDate")
                .HasColumnName("PermissionDate")
                .IsRequired();
            builder
                .Property<int?>("PermissionTypeId")
                .HasColumnName("PermissionTypeId")
                .IsRequired();
            builder.HasOne(p => p.PermissionType)
                .WithMany()
                .HasForeignKey("PermissionTypeId");
        }
    }
}
