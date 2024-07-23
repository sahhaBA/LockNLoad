using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using LockNLoad.Service.Entities;

namespace LockNLoad.Service.Contexts
{
    public partial class LockNLoadContext : DbContext
    {
        public LockNLoadContext()
        {
        }

        public LockNLoadContext(DbContextOptions<LockNLoadContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Appointment> Appointments { get; set; } = null!;
        public virtual DbSet<Bill> Bills { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Equipment> Equipment { get; set; } = null!;
        public virtual DbSet<Gender> Genders { get; set; } = null!;
        public virtual DbSet<Request> Requests { get; set; } = null!;
        public virtual DbSet<Review> Reviews { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<TrainingGround> TrainingGrounds { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<UserAppointment> UserAppointments { get; set; } = null!;
        public virtual DbSet<UserAppointmentEquipment> UserAppointmentEquipments { get; set; } = null!;
        public virtual DbSet<UserRole> UserRoles { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=LockNLoad;User Id=rsII;Password=razvojsoftvera1234#;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Appointment>(entity =>
            {
                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.EndDateTime).HasColumnType("datetime");

                entity.Property(e => e.StartDateTime).HasColumnType("datetime");

                entity.HasOne(d => d.TrainingGround)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.TrainingGroundId)
                    .HasConstraintName("FK_Appointments_TrainingGroundId");
            });

            modelBuilder.Entity<Bill>(entity =>
            {
                entity.HasOne(d => d.Request)
                    .WithMany(p => p.Bills)
                    .HasForeignKey(d => d.RequestId)
                    .HasConstraintName("FK_Bills_RequestId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Bills) 
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Bills_UserId");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Equipment>(entity =>
            {
                entity.Property(e => e.EquipmentImageUrl)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Equipment)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_Equipment_CategoryId");
            });

            modelBuilder.Entity<Gender>(entity =>
            {
                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Request>(entity =>
            {
                entity.Property(e => e.ApprovedDateTime).HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.RejectedDateTime).HasColumnType("datetime");

                entity.HasOne(d => d.Review)
                    .WithMany(p => p.Requests)
                    .HasForeignKey(d => d.ReviewId)
                    .HasConstraintName("FK_Requests_ReviewId");
            });

            modelBuilder.Entity<Review>(entity =>
            {
                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TrainingGround>(entity =>
            {
                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Location)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LocationImageUrl)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.Username, "UQ__Users__536C85E4CB91BF9B")
                    .IsUnique();

                entity.Property(e => e.DateOfRegistration).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PasswordHash)
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ProfileImageUrl)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Salt)
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Gender)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.GenderId)
                    .HasConstraintName("FK_Users_GenderId");
            });

            modelBuilder.Entity<UserAppointment>(entity =>
            {
                entity.HasOne(d => d.Appointment)
                    .WithMany(p => p.UserAppointments)
                    .HasForeignKey(d => d.AppointmentId)
                    .HasConstraintName("FK_UserAppointments_AppointmentId");

                entity.HasOne(d => d.Request)
                    .WithMany(p => p.UserAppointments)
                    .HasForeignKey(d => d.RequestId)
                    .HasConstraintName("FK_UserAppointments_RequestId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserAppointments)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_UserAppointments_UserId");
            });

            modelBuilder.Entity<UserAppointmentEquipment>(entity =>
            {
                entity.ToTable("UserAppointmentEquipment");

                entity.HasOne(d => d.Equipment)
                    .WithMany(p => p.UserAppointmentEquipments)
                    .HasForeignKey(d => d.EquipmentId)
                    .HasConstraintName("FK_UserAppointmentEquipment_EquipmentId");

                entity.HasOne(d => d.UserAppointment)
                    .WithMany(p => p.UserAppointmentEquipments)
                    .HasForeignKey(d => d.UserAppointmentId)
                    .HasConstraintName("FK_UserAppointmentEquipment_UserAppointmentId");
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.HasOne(d => d.Role)
                    .WithMany(p => p.UserRoles)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_UserRoles_RoleId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserRoles)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_UserRoles_UserId");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
