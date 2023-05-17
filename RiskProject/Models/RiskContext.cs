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
        => optionsBuilder.UseSqlServer("Data Source=localhost;Database=Risk;Persist Security Info=True; User ID=sa;Password=admin123!;Trust Server Certificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tbl_deta__3213E83F0B531D74");

            entity.ToTable("tbl_details");

            entity.Property(e => e.Id)
                .HasMaxLength(36)
                .IsUnicode(false)
                .HasColumnName("id");
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

            entity.HasOne(d => d.Impact).WithMany(p => p.TblDetails)
                .HasForeignKey(d => d.ImpactId)
                .HasConstraintName("FK_details_impacts");

            entity.HasOne(d => d.Priority).WithMany(p => p.TblDetails)
                .HasForeignKey(d => d.PriorityId)
                .HasConstraintName("FK_details_priorties");

            entity.HasOne(d => d.Probability).WithMany(p => p.TblDetails)
                .HasForeignKey(d => d.ProbabilityId)
                .HasConstraintName("FK_details_probabilities");
        });

        modelBuilder.Entity<TblImpact>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tbl_impa__3213E83F198E97AD");

            entity.ToTable("tbl_impacts");

            entity.HasIndex(e => e.Name, "UQ__tbl_impa__72E12F1B49CA79BB").IsUnique();

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
            entity.HasKey(e => e.Id).HasName("PK__tbl_prio__3213E83F7CA8896C");

            entity.ToTable("tbl_priorities");

            entity.HasIndex(e => e.Name, "UQ__tbl_prio__72E12F1B67B09E36").IsUnique();

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
            entity.HasKey(e => e.Id).HasName("PK__tbl_prob__3213E83FC052B380");

            entity.ToTable("tbl_probabilities");

            entity.HasIndex(e => e.Name, "UQ__tbl_prob__72E12F1B8171F61C").IsUnique();

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
            entity.HasKey(e => e.Id).HasName("PK__tbl_proj__3213E83F84F44187");

            entity.ToTable("tbl_projects");

            entity.HasIndex(e => e.Name, "UQ__tbl_proj__72E12F1B2A4CD329").IsUnique();

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
            entity.HasKey(e => e.Id).HasName("PK__tbl_regi__3213E83F17FAEDB8");

            entity.ToTable("tbl_registers");

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

            entity.HasOne(d => d.Project).WithMany(p => p.TblRegisters)
                .HasForeignKey(d => d.ProjectId)
                .HasConstraintName("FK_registers_projects");

            entity.HasMany(d => d.IdDetails).WithMany(p => p.IdRegisters)
                .UsingEntity<Dictionary<string, object>>(
                    "TblRegisteredDetail",
                    r => r.HasOne<TblDetail>().WithMany()
                        .HasForeignKey("IdDetail")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_registered_details_register"),
                    l => l.HasOne<TblRegister>().WithMany()
                        .HasForeignKey("IdRegister")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_registered_details_detail"),
                    j =>
                    {
                        j.HasKey("IdRegister", "IdDetail").HasName("PK__tbl_regi__D6BD8A14EC9A16D7");
                        j.ToTable("tbl_registered_details");
                        j.IndexerProperty<string>("IdRegister")
                            .HasMaxLength(36)
                            .IsUnicode(false)
                            .HasColumnName("id_register");
                        j.IndexerProperty<string>("IdDetail")
                            .HasMaxLength(36)
                            .IsUnicode(false)
                            .HasColumnName("id_detail");
                    });
        });

        modelBuilder.Entity<TblUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tbl_user__3213E83F56BB5FAE");

            entity.ToTable("tbl_users");

            entity.HasIndex(e => e.Email, "UQ__tbl_user__AB6E61644B51CE02").IsUnique();

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
                .HasDefaultValueSql("((1))")
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
