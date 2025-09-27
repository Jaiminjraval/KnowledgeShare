using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using KnowledgeShare.Models;

namespace KnowledgeShare.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Subject> Subjects { get; set; }
        public DbSet<SessionRequest> SessionRequests { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ApplicationUser>()
                .HasMany(u => u.Subjects)
                .WithMany(s => s.Tutors);

            builder.Entity<SessionRequest>()
                .HasOne(sr => sr.Learner)
                .WithMany(u => u.SentSessionRequests)
                .HasForeignKey(sr => sr.LearnerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<SessionRequest>()
                .HasOne(sr => sr.Tutor)
                .WithMany(u => u.ReceivedSessionRequests)
                .HasForeignKey(sr => sr.TutorId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
