using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sat.Recruitment.Domain.Entities;
using System;

namespace Sat.Recruitment.Infrastructure.Configurations
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");

            builder.HasKey(u => u.Id);

            builder.Property(u => u.Name).IsRequired().HasMaxLength(100);

            builder.Property(u => u.Email).IsRequired().HasMaxLength(250);

            builder.Property(u => u.Address).IsRequired().HasMaxLength(250);

            builder.Property(u => u.Phone).IsRequired().HasMaxLength(25);

            builder.Property(u => u.UserType)
                .HasConversion(
                    ut => ut.ToString(),
                    ut => (UserType)Enum.Parse(typeof(UserType), ut));

            builder.HasIndex(u => u.Name);

            builder.HasIndex(u => u.Email).IsUnique();
        }
    }
}
