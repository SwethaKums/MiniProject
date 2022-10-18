using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AirLinesAp.Models
{
    public partial class GigoAirlinesContext : DbContext
    {
        public GigoAirlinesContext()
        {
        }

        public GigoAirlinesContext(DbContextOptions<GigoAirlinesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BookingPage> BookingPages { get; set; } = null!;
        public virtual DbSet<FlightInformation> FlightInformations { get; set; } = null!;
        public virtual DbSet<Login> Logins { get; set; } = null!;
        public virtual DbSet<Payment> Payments { get; set; } = null!;
        public virtual DbSet<TravelLocation> TravelLocations { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=LAPTOP-CCNCPJ77;Database=GigoAirlines;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookingPage>(entity =>
            {
                entity.HasKey(e => e.BookingId)
                    .HasName("PK_Bookingid");

                entity.ToTable("BookingPage");

                entity.Property(e => e.BookDate).HasColumnType("date");

                entity.Property(e => e.Starttime)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TravelDate).HasColumnType("date");

                entity.HasOne(d => d.ArrivalNavigation)
                    .WithMany(p => p.BookingPageArrivalNavigations)
                    .HasForeignKey(d => d.Arrival)
                    .HasConstraintName("FK_Arrival");

                entity.HasOne(d => d.DepartureNavigation)
                    .WithMany(p => p.BookingPageDepartureNavigations)
                    .HasForeignKey(d => d.Departure)
                    .HasConstraintName("FK_Depart");
            });

            modelBuilder.Entity<FlightInformation>(entity =>
            {
                entity.HasKey(e => e.FlightId)
                    .HasName("PK_Flight");

                entity.ToTable("FlightInformation");

                entity.Property(e => e.FlightName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.TravelDate).HasColumnType("date");
            });

            modelBuilder.Entity<Login>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK_Userid");

                entity.ToTable("Login");

                entity.Property(e => e.EmailId)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PassWord)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.HasKey(e => e.Payid)
                    .HasName("PK_payid");

                entity.ToTable("Payment");

                entity.Property(e => e.Class)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ExpiryDate).HasColumnType("date");
            });

            modelBuilder.Entity<TravelLocation>(entity =>
            {
                entity.HasKey(e => e.CityId)
                    .HasName("PK_Cityid");

                entity.ToTable("TravelLocation");

                entity.Property(e => e.CityCode)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CityName)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
