using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Sugarbakers.Models;

public partial class SugarbakersCh12Context : DbContext
{
    public SugarbakersCh12Context()
    {
    }

    public SugarbakersCh12Context(DbContextOptions<SugarbakersCh12Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Zipcode> Zipcodes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=(localdb)\\ProjectModels;Database=SugarbakersCh12;Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Departme__3214EC0748F83F54");

            entity.ToTable("Department");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Location)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Employee__3214EC07108B3B14");

            entity.ToTable("Employee");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Address)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.DepartmentId).HasColumnName("DepartmentID");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("First Name");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Last Name");
            entity.Property(e => e.Position)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Salary).HasColumnType("money");
            entity.Property(e => e.Zip)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.Department).WithMany(p => p.Employees)
                .HasForeignKey(d => d.DepartmentId)
                .HasConstraintName("FK_employeeDepartment");

            entity.HasOne(d => d.ZipNavigation).WithMany(p => p.Employees)
                .HasForeignKey(d => d.Zip)
                .HasConstraintName("FK_employeeZip");
        });

        modelBuilder.Entity<Zipcode>(entity =>
        {
            entity.HasKey(e => e.Zipcode1).HasName("PK__Zipcode__E546D6BFB47FF1C3");

            entity.ToTable("Zipcode");

            entity.Property(e => e.Zipcode1)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Zipcode");
            entity.Property(e => e.City)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.State)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
