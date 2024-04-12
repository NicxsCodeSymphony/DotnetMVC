using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace NICO.Entities;

public partial class EdisanTheLenderMachineContext : DbContext
{
    public EdisanTheLenderMachineContext()
    {
    }

    public EdisanTheLenderMachineContext(DbContextOptions<EdisanTheLenderMachineContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ClientInfo> ClientInfos { get; set; }

    public virtual DbSet<UserType> UserTypes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost\\EDISANEXPRESS;Database=EdisanTheLenderMachine;TrustServerCertificate=true; Trusted_Connection=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ClientInfo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ClientIn__3214EC07FE414437");

            entity.ToTable("ClientInfo");

            entity.Property(e => e.Address)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Birthdate).HasColumnType("date");
            entity.Property(e => e.CivilStatus)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Civil_Status");
            entity.Property(e => e.FistName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.MiddleName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.NameOfFather)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.NameOfMother)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Occupation)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Religion)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<UserType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__UserType__3214EC07BE42E7DE");

            entity.ToTable("UserType");

            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
