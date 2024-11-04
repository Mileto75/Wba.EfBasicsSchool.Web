﻿using Microsoft.EntityFrameworkCore;
using Wba.EfBasics.Core.Entities;

namespace Wba.EfBasics.Web.Data
{
    public class SchoolDbContext : DbContext
    {
        //properties => db tables
        public DbSet<Course> Courses { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }
        public SchoolDbContext(DbContextOptions<SchoolDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //database configuration
            modelBuilder.HasDefaultSchema("DboSchool");
            //entity configuration
            //course
            modelBuilder.Entity<Course>()
                .Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(150);
            modelBuilder.Entity<Student>()
                .Property(c => c.Firstname)
                .IsRequired()
                .HasMaxLength(150);
            modelBuilder.Entity<Student>()
                .Property(c => c.Lastname)
                .IsRequired()
                .HasMaxLength(150);
            modelBuilder.Entity<Teacher>()
                .Property(c => c.Firstname)
                .IsRequired()
                .HasMaxLength(150);
            modelBuilder.Entity<Teacher>()
                .Property(c => c.Lastname)
                .IsRequired()
                .HasMaxLength(150);
            base.OnModelCreating(modelBuilder);
        }
    }
}
