using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CA_School.Models;

public partial class SchoolDbContext : DbContext
{
    public SchoolDbContext()
    {
    }

    public SchoolDbContext(DbContextOptions<SchoolDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<CourseAndStudent> CourseAndStudents { get; set; }

    public virtual DbSet<OrderCourse> OrderCourses { get; set; }

    public virtual DbSet<SocialClub> SocialClubs { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<Teacher> Teachers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("server=DESKTOP-KUQ9PNH;database=SchoolDB;uid=sa;pwd=Ahmet21293;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.CourseId).HasName("PK__Course__C92D71870D4FFF69");

            entity.Property(e => e.CourseId).HasColumnName("CourseID");
            entity.Property(e => e.CourseName).HasMaxLength(50);
            entity.Property(e => e.TeacherId).HasColumnName("TeacherID");

            entity.HasOne(d => d.Teacher).WithMany(p => p.Courses)
                .HasForeignKey(d => d.TeacherId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Course__TeacherI__2B3F6F97");
        });

        modelBuilder.Entity<CourseAndStudent>(entity =>
        {
            entity.HasKey(e => e.StudentId).HasName("PK__CourseAn__32C52A79A6331BB5");

            entity.HasIndex(e => e.CourseId, "UQ__CourseAn__C92D71868D2C38DE").IsUnique();

            entity.Property(e => e.StudentId)
                .ValueGeneratedNever()
                .HasColumnName("StudentID");
            entity.Property(e => e.CourseId).HasColumnName("CourseID");

            entity.HasOne(d => d.Course).WithOne(p => p.CourseAndStudent)
                .HasForeignKey<CourseAndStudent>(d => d.CourseId)
                .HasConstraintName("FK__CourseAnd__Cours__300424B4");

            entity.HasOne(d => d.Student).WithOne(p => p.CourseAndStudent)
                .HasForeignKey<CourseAndStudent>(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__CourseAnd__Stude__2E1BDC42");
        });

        modelBuilder.Entity<OrderCourse>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__OrderCou__C3905BAF2D02A909");

            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.CourseId).HasColumnName("CourseID");
            entity.Property(e => e.Discount).HasColumnType("decimal(2, 2)");
            entity.Property(e => e.EnrollmentDate).HasColumnType("date");
            entity.Property(e => e.StudentId).HasColumnName("StudentID");

            entity.HasOne(d => d.Course).WithMany(p => p.OrderCourses)
                .HasForeignKey(d => d.CourseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OrderCour__Cours__32E0915F");

            entity.HasOne(d => d.Student).WithMany(p => p.OrderCourses)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OrderCour__Stude__33D4B598");
        });

        modelBuilder.Entity<SocialClub>(entity =>
        {
            entity.HasKey(e => e.ClubId).HasName("PK__SocialCl__D35058C7E785EB94");

            entity.Property(e => e.ClubId).HasColumnName("ClubID");
            entity.Property(e => e.ClubName).HasMaxLength(50);
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.StudentId).HasName("PK__Students__32C52A7902E6B0AB");

            entity.Property(e => e.StudentId).HasColumnName("StudentID");
            entity.Property(e => e.Birthdate).HasColumnType("date");
            entity.Property(e => e.ClubId).HasColumnName("ClubID");
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);

            entity.HasOne(d => d.Club).WithMany(p => p.Students)
                .HasForeignKey(d => d.ClubId)
                .HasConstraintName("FK__Students__ClubID__267ABA7A");
        });

        modelBuilder.Entity<Teacher>(entity =>
        {
            entity.HasKey(e => e.TeacherId).HasName("PK__Teachers__EDF25944286FE26E");

            entity.Property(e => e.TeacherId).HasColumnName("TeacherID");
            entity.Property(e => e.TeacherLastname).HasMaxLength(50);
            entity.Property(e => e.TeacherName).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
