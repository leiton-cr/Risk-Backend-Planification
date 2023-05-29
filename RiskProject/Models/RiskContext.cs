using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace RiskProject.Models;

public partial class RiskContext : DbContext
{
    public RiskContext()
    {
    }

    public RiskContext(DbContextOptions<RiskContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblDetail> TblDetails { get; set; }

    public virtual DbSet<TblImpact> TblImpacts { get; set; }

    public virtual DbSet<TblPriority> TblPriorities { get; set; }

    public virtual DbSet<TblProbability> TblProbabilities { get; set; }

    public virtual DbSet<TblProject> TblProjects { get; set; }

    public virtual DbSet<TblRegister> TblRegisters { get; set; }

    public virtual DbSet<TblUser> TblUsers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Data Source=localhost;Database=Risk;Persist Security Info=True; User ID=steven;Password=1234;Trust Server Certificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tbl_deta__3213E83F04E5C33E");

            entity.ToTable("tbl_details");

            entity.Property(e => e.Id)
                .HasMaxLength(36)
                .IsUnicode(false)
                .HasColumnName("id");
            entity.Property(e => e.IdRegister)
                .HasMaxLength(36)
                .IsUnicode(false)
                .HasColumnName("id_register");
            entity.Property(e => e.ImpactDescription)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("impact_description");
            entity.Property(e => e.ImpactId)
                .HasMaxLength(36)
                .IsUnicode(false)
                .HasColumnName("impact_id");
            entity.Property(e => e.Owner)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("owner");
            entity.Property(e => e.Points).HasColumnName("points");
            entity.Property(e => e.PriorityId)
                .HasMaxLength(36)
                .IsUnicode(false)
                .HasColumnName("priority_id");
            entity.Property(e => e.ProbabilityId)
                .HasMaxLength(36)
                .IsUnicode(false)
                .HasColumnName("probability_id");
            entity.Property(e => e.ResponsePlan)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("response_plan");
            entity.Property(e => e.RiskDescription)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("risk_description");

            entity.HasOne(d => d.IdRegisterNavigation).WithMany(p => p.TblDetails)
                .HasForeignKey(d => d.IdRegister)
                .HasConstraintName("FK_details_registers");
            /*
            entity.HasOne(d => d.Impact).WithMany(p => p.TblDetails)
                .HasForeignKey(d => d.ImpactId)
                .HasConstraintName("FK_details_impacts");

            entity.HasOne(d => d.Priority).WithMany(p => p.TblDetails)
                .HasForeignKey(d => d.PriorityId)
                .HasConstraintName("FK_details_priorties");

            entity.HasOne(d => d.Probability).WithMany(p => p.TblDetails)
                .HasForeignKey(d => d.ProbabilityId)
                .HasConstraintName("FK_details_probabilities");
            */
        });

        modelBuilder.Entity<TblImpact>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tbl_impa__3213E83FC518A81F");

            entity.ToTable("tbl_impacts");

            entity.HasIndex(e => e.Value, "UQ__tbl_impa__40BBEA3AB4BDD904").IsUnique();

            entity.HasIndex(e => e.Name, "UQ__tbl_impa__72E12F1B91B54D19").IsUnique();

            entity.Property(e => e.Id)
                .HasMaxLength(36)
                .IsUnicode(false)
                .HasColumnName("id");
            entity.Property(e => e.Active)
                .HasDefaultValueSql("((1))")
                .HasColumnName("active");
            entity.Property(e => e.Name)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Value).HasColumnName("value");
        });

        modelBuilder.Entity<TblPriority>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tbl_prio__3213E83FF4779261");

            entity.ToTable("tbl_priorities");

            entity.HasIndex(e => e.Value, "UQ__tbl_prio__40BBEA3A6E6E0D9F").IsUnique();

            entity.HasIndex(e => e.Name, "UQ__tbl_prio__72E12F1B2F87276C").IsUnique();

            entity.Property(e => e.Id)
                .HasMaxLength(36)
                .IsUnicode(false)
                .HasColumnName("id");
            entity.Property(e => e.Active)
                .HasDefaultValueSql("((1))")
                .HasColumnName("active");
            entity.Property(e => e.Name)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Value).HasColumnName("value");
        });

        modelBuilder.Entity<TblProbability>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tbl_prob__3213E83F97A4B8C3");

            entity.ToTable("tbl_probabilities");

            entity.HasIndex(e => e.Value, "UQ__tbl_prob__40BBEA3A0F173CA7").IsUnique();

            entity.HasIndex(e => e.Name, "UQ__tbl_prob__72E12F1BD2EAB048").IsUnique();

            entity.Property(e => e.Id)
                .HasMaxLength(36)
                .IsUnicode(false)
                .HasColumnName("id");
            entity.Property(e => e.Active)
                .HasDefaultValueSql("((1))")
                .HasColumnName("active");
            entity.Property(e => e.Name)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Value).HasColumnName("value");
        });

        modelBuilder.Entity<TblProject>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tbl_proj__3213E83F53EF2353");

            entity.ToTable("tbl_projects");

            entity.HasIndex(e => e.Name, "UQ__tbl_proj__72E12F1BA4141C1D").IsUnique();

            entity.Property(e => e.Id)
                .HasMaxLength(36)
                .IsUnicode(false)
                .HasColumnName("id");
            entity.Property(e => e.Active)
                .HasDefaultValueSql("((1))")
                .HasColumnName("active");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<TblRegister>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tbl_regi__3213E83F1DE6817D");

            entity.ToTable("tbl_registers");

            entity.HasIndex(e => e.TaskId, "UQ__tbl_regi__0492148CEAC27264").IsUnique();

            entity.Property(e => e.Id)
                .HasMaxLength(36)
                .IsUnicode(false)
                .HasColumnName("id");
            entity.Property(e => e.Active)
                .HasDefaultValueSql("((1))")
                .HasColumnName("active");
            entity.Property(e => e.ProjectId)
                .HasMaxLength(36)
                .IsUnicode(false)
                .HasColumnName("project_id");
            entity.Property(e => e.TaskDescription)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("task_description");
            entity.Property(e => e.TaskId)
                .HasMaxLength(36)
                .IsUnicode(false)
                .HasColumnName("task_id");
            entity.Property(e => e.UpdatedAt)
                .HasColumnType("date")
                .HasColumnName("updated_at");
            /*
            entity.HasOne(d => d.Project).WithMany(p => p.TblRegisters)
                .HasForeignKey(d => d.ProjectId)
                .HasConstraintName("FK_registers_projects");
            */
        });

        modelBuilder.Entity<TblUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tbl_user__3213E83FA7AD9DCC");

            entity.ToTable("tbl_users");

            entity.HasIndex(e => e.Email, "UQ__tbl_user__AB6E61642AB48A0F").IsUnique();

            entity.Property(e => e.Id)
                .HasMaxLength(36)
                .IsUnicode(false)
                .HasColumnName("id");
            entity.Property(e => e.Active)
                .HasDefaultValueSql("((1))")
                .HasColumnName("active");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Pass)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("pass");
            entity.Property(e => e.Pepper)
                .HasMaxLength(48)
                .IsUnicode(false)
                .HasColumnName("pepper");
            entity.Property(e => e.Salt).HasColumnName("salt");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
