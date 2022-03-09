using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using WolfUniversity.Domain;

namespace WolfUniversity.Infrastructure
{
    public partial class WolfUniversityDBContext : DbContext
    {
        public WolfUniversityDBContext()
        {
        }

        public WolfUniversityDBContext(DbContextOptions<WolfUniversityDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Course> Courses { get; set; } = null!;
        public virtual DbSet<Student> Students { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DVTLF3GQVG3\\MSSQLSERVER_2019; Database=WolfUniversityDB; trusted_connection=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>(entity =>
            {
                entity.Property(e => e.CourseCode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CourseDuration)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nqflevel).HasColumnName("NQFLevel");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Phone).HasColumnName("phone");

                entity.Property(e => e.StudentNumber)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Surname)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StudentCourse");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
