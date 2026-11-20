using G_NET97_EF_Assignment_2.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G_NET97_EF_Assignment_2.Configurations
{
    internal class BadgeConfiguration : IEntityTypeConfiguration<Badge>
    {

        public void Configure(EntityTypeBuilder<Badge> builder)
        {
            builder.HasKey(b => b.Id);

            builder.Property(b => b.CredentialNumber)
                   .IsRequired()
                   .HasMaxLength(50);

            // Ensure credential number is uniquely numbered per attendee
            builder.HasIndex(b => b.CredentialNumber)
                   .IsUnique();

            builder.Property(b => b.IssuedDate)
                   .IsRequired();

            builder.Property(b => b.Tier)
                   .HasConversion<string>() // Stores "Standard" or "VIP" as string
                   .HasMaxLength(20)
                   .IsRequired();

            // One-to-One: Attendee <-> Badge
            builder.HasOne(b => b.Attendee)
                   .WithOne(a => a.Badge)
                   .HasForeignKey<Badge>(b => b.AttendeeId)
                   .OnDelete(DeleteBehavior.Cascade);
        }

    }
}
