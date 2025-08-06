using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SAFE.Models;

public partial class SafeContext : DbContext
{
    public SafeContext()
    {
    }

    public SafeContext(DbContextOptions<SafeContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<Alert> Alerts { get; set; }

    public virtual DbSet<Donation> Donations { get; set; }

    public virtual DbSet<EmergencyReport> EmergencyReports { get; set; }

    public virtual DbSet<Feedback> Feedbacks { get; set; }

    public virtual DbSet<Notification> Notifications { get; set; }

    public virtual DbSet<ResponseTeam> ResponseTeams { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=SAFE;Integrated Security=True;Encrypt=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Admin>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__admins__3213E83FA3D71DA1");

            entity.ToTable("admins");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .IsRowVersion()
                .IsConcurrencyToken()
                .HasColumnName("created_at");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("phone");
            entity.Property(e => e.Username)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("username");
        });

        modelBuilder.Entity<Alert>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__alerts__3213E83FB6AF7C3D");

            entity.ToTable("alerts");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.AlertTime)
                .IsRowVersion()
                .IsConcurrencyToken()
                .HasColumnName("alert_time");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.IssuedBy).HasColumnName("issued_by");
            entity.Property(e => e.Message)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("message");
            entity.Property(e => e.RelatedReportId).HasColumnName("related_report_id");
            entity.Property(e => e.SeverityLevel)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("severity_level");

            entity.HasOne(d => d.IssuedByNavigation).WithMany(p => p.Alerts)
                .HasForeignKey(d => d.IssuedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__alerts__issued_b__3D5E1FD2");

            entity.HasOne(d => d.RelatedReport).WithMany(p => p.Alerts)
                .HasForeignKey(d => d.RelatedReportId)
                .HasConstraintName("FK__alerts__related___3E52440B");
        });

        modelBuilder.Entity<Donation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__donation__3213E83FAD56C539");

            entity.ToTable("donations");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Date)
                .IsRowVersion()
                .IsConcurrencyToken()
                .HasColumnName("date");
            entity.Property(e => e.DonorId).HasColumnName("donor_id");
            entity.Property(e => e.ItemOrAmount)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("item_or_amount");
            entity.Property(e => e.UsedFor)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("used_for");

            entity.HasOne(d => d.Donor).WithMany(p => p.Donations)
                .HasForeignKey(d => d.DonorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__donations__donor__44FF419A");
        });

        modelBuilder.Entity<EmergencyReport>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__emergenc__3213E83FFCF9D947");

            entity.ToTable("emergency_reports");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("address");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Date)
                .IsRowVersion()
                .IsConcurrencyToken()
                .HasColumnName("date");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.Latitude).HasColumnName("latitude");
            entity.Property(e => e.Location)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("location");
            entity.Property(e => e.Longitude).HasColumnName("longitude");
            entity.Property(e => e.ReportedBy).HasColumnName("reported_by");
            entity.Property(e => e.Status)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("status");

            entity.HasOne(d => d.ReportedByNavigation).WithMany(p => p.EmergencyReports)
                .HasForeignKey(d => d.ReportedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__emergency__repor__3A81B327");
        });

        modelBuilder.Entity<Feedback>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__feedback__3213E83F580E05DC");

            entity.ToTable("feedbacks");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Message)
                .HasColumnType("text")
                .HasColumnName("message");
            entity.Property(e => e.Rating).HasColumnName("rating");
            entity.Property(e => e.SubmittedBy).HasColumnName("submitted_by");
            entity.Property(e => e.SubmittedOn)
                .IsRowVersion()
                .IsConcurrencyToken()
                .HasColumnName("submitted_on");

            entity.HasOne(d => d.SubmittedByNavigation).WithMany(p => p.Feedbacks)
                .HasForeignKey(d => d.SubmittedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__feedbacks__submi__47DBAE45");
        });

        modelBuilder.Entity<Notification>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__notifica__3213E83F772BC686");

            entity.ToTable("notifications");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.Message)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("message");
            entity.Property(e => e.SentTime)
                .IsRowVersion()
                .IsConcurrencyToken()
                .HasColumnName("sent_time");
            entity.Property(e => e.Type)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("type");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.Notifications)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__notificat__user___4AB81AF0");
        });

        modelBuilder.Entity<ResponseTeam>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__response__3213E83F6FA8C9F9");

            entity.ToTable("response_teams");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.AssignedBy).HasColumnName("assigned_by");
            entity.Property(e => e.AssignedReportId).HasColumnName("assigned_report_id");
            entity.Property(e => e.CreatedAt)
                .IsRowVersion()
                .IsConcurrencyToken()
                .HasColumnName("created_at");
            entity.Property(e => e.Members)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("members");
            entity.Property(e => e.Status)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("status");
            entity.Property(e => e.TeamName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("team_name");

            entity.HasOne(d => d.AssignedByNavigation).WithMany(p => p.ResponseTeams)
                .HasForeignKey(d => d.AssignedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__response___assig__4222D4EF");

            entity.HasOne(d => d.AssignedReport).WithMany(p => p.ResponseTeams)
                .HasForeignKey(d => d.AssignedReportId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__response___assig__412EB0B6");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__users__3213E83FB57F7CAA");

            entity.ToTable("users");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .IsRowVersion()
                .IsConcurrencyToken()
                .HasColumnName("created_at");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Location)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("location");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.Role)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("role");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
