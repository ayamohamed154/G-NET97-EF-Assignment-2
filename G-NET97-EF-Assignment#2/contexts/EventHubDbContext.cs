using G_NET97_EF_Assignment_2.Configurations;
using G_NET97_EF_Assignment_2.models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G_NET97_EF_Assignment_2.contexts
{
    internal class EventHubDbContext : DbContext
    {

        public DbSet<Organizer> Organizers { get; set; }
        public DbSet<OrganizerProfile> OrganizerProfiles { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Attendee> Attendees { get; set; }
        public DbSet<Badge> Badges { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(
                    "Server=.\\SQLEXPRESS;Database=EventHubDb;Trusted_Connection=True;TrustServerCertificate=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // 1. Direct Fluent API configuration in OnModelCreating for OrganizerProfile
            modelBuilder.Entity<OrganizerProfile>(entity =>
            {
                entity.HasKey(p => p.Id);

                entity.Property(p => p.Biography)
                      .HasMaxLength(1000);

                entity.Property(p => p.WebsiteUrl)
                      .HasMaxLength(300);

                entity.Property(p => p.LogoUrl)
                      .HasMaxLength(300);

                // One-to-One: Organizer <-> OrganizerProfile
                // Profile cannot exist without Organizer (Required + Cascade Delete)
                entity.HasOne(p => p.Organizer)
                      .WithOne(o => o.Profile)
                      .HasForeignKey<OrganizerProfile>(p => p.OrganizerId)
                      .IsRequired()
                      .OnDelete(DeleteBehavior.Cascade);
            });

            // 2. Separate Configuration Classes for Event and Badge
            modelBuilder.ApplyConfiguration(new EventConfiguration());
            modelBuilder.ApplyConfiguration(new BadgeConfiguration());
        }

    }
}
