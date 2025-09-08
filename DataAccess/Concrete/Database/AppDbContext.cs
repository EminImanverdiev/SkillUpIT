using Core.Entities.Concrete;
using Entities.Concrete;
using Entities.Concrete.Events;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.Database
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Fag> Fags => Set<Fag>();
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<ContactBlock> ContactBlocks { get; set; }
        public DbSet<ContactMessage> ContactMessages { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Instructor> Instructor { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }
        public DbSet<EventContent> EventContents { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Partner> Partners { get; set; }
        public DbSet<Course> Courses { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Event>()
                .HasMany(x => x.EventContents)
                .WithOne(x => x.Event)
                .HasForeignKey(x => x.EventId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Course>()
          .HasMany(c => c.Tags)
          .WithMany(t => t.Courses)
          .UsingEntity<Dictionary<string, object>>(
              "CourseTag", 
              j => j.HasOne<Tag>()
                    .WithMany()
                    .HasForeignKey("TagId")
                    .OnDelete(DeleteBehavior.Cascade),
              j => j.HasOne<Course>()
                    .WithMany()
                    .HasForeignKey("CourseId")
                    .OnDelete(DeleteBehavior.Cascade),
              j =>
              {
                  j.HasKey("CourseId", "TagId");
                  j.ToTable("CourseTags");
              });
        }
    }
}
