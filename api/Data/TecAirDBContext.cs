using System;
using api.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using api.Configuration;
using Microsoft.Extensions.Configuration;

#nullable disable

namespace api.Data
{
    public partial class TecAirDBContext : IdentityDbContext<User, Role, int>
    {
        private readonly IConfiguration _configuration;
        public TecAirDBContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public TecAirDBContext(DbContextOptions<TecAirDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Baggage> Baggages { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Flight> Flights { get; set; }
        public virtual DbSet<Plane> Planes { get; set; }
        public virtual DbSet<Rute> Rutes { get; set; }
        public virtual DbSet<Schoolid> Schoolids { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql(_configuration.GetConnectionString("DefaultConnection"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasAnnotation("Relational:Collation", "Spanish_Costa Rica.1252");

            modelBuilder.Entity<Baggage>(entity =>
            {
                entity.HasKey(e => e.Uniqueid)
                    .HasName("baggage_pkey");

                entity.ToTable("baggage");

                entity.Property(e => e.Uniqueid)
                    .ValueGeneratedNever()
                    .HasColumnName("uniqueid");

                entity.Property(e => e.Color)
                    .IsRequired()
                    .HasColumnName("color");

                entity.Property(e => e.Ssn).HasColumnName("ssn");

                entity.Property(e => e.Weight).HasColumnName("weight");

                entity.HasOne(d => d.SsnNavigation)
                    .WithMany(p => p.Baggages)
                    .HasForeignKey(d => d.Ssn)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("baggage_ssn_fkey");
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.HasKey(e => new { e.Ssn, e.IdFlight })
                    .HasName("book_pkey");

                entity.ToTable("book");

                entity.Property(e => e.Ssn).HasColumnName("ssn");

                entity.Property(e => e.IdFlight).HasColumnName("id_flight");

                entity.Property(e => e.Seat)
                    .IsRequired()
                    .HasColumnName("seat");

                entity.HasOne(d => d.IdFlightNavigation)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.IdFlight)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("book_id_flight_fkey");

                entity.HasOne(d => d.SsnNavigation)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.Ssn)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("book_ssn_fkey");
            });

            modelBuilder.Entity<Flight>(entity =>
            {
                entity.ToTable("flight");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.AirplaneLicense)
                    .IsRequired()
                    .HasColumnName("airplane_license");

                entity.Property(e => e.Deals).HasColumnName("deals");

                entity.Property(e => e.Gate)
                    .IsRequired()
                    .HasColumnName("gate");

                entity.Property(e => e.IdRute).HasColumnName("id_rute");

                entity.Property(e => e.Schedule)
                    .IsRequired()
                    .HasColumnName("schedule");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasColumnName("status")
                    .HasDefaultValueSql("'In time'::text");

                entity.HasOne(d => d.AirplaneLicenseNavigation)
                    .WithMany(p => p.Flights)
                    .HasForeignKey(d => d.AirplaneLicense)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("flight_airplane_license_fkey");

                entity.HasOne(d => d.IdRuteNavigation)
                    .WithMany(p => p.Flights)
                    .HasForeignKey(d => d.IdRute)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("flight_id_rute_fkey");
            });

            modelBuilder.Entity<Plane>(entity =>
            {
                entity.HasKey(e => e.AirplaneLicense)
                    .HasName("plane_pkey");

                entity.ToTable("plane");

                entity.Property(e => e.AirplaneLicense).HasColumnName("airplane_license");

                entity.Property(e => e.Capacity).HasColumnName("capacity");

                entity.Property(e => e.Model)
                    .IsRequired()
                    .HasColumnName("model");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasColumnName("status")
                    .HasDefaultValueSql("'Free'::text");
            });

            modelBuilder.Entity<Rute>(entity =>
            {
                entity.ToTable("rute");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Arrival)
                    .IsRequired()
                    .HasColumnName("arrival");

                entity.Property(e => e.Departure)
                    .IsRequired()
                    .HasColumnName("departure");

                entity.Property(e => e.Scale).HasColumnName("scale");
            });

            modelBuilder.Entity<Schoolid>(entity =>
            {
                entity.HasKey(e => e.Number)
                    .HasName("id_pkey");

                entity.ToTable("schoolid");

                entity.Property(e => e.Number)
                    .ValueGeneratedNever()
                    .HasColumnName("number");

                entity.Property(e => e.Mile).HasColumnName("mile");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Ssn)
                    .IsRequired()
                    .HasColumnName("ssn");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("first_name");

                entity.Property(e => e.LastName1)
                    .IsRequired()
                    .HasColumnName("last_name_1");

                entity.Property(e => e.LastName2)
                    .IsRequired()
                    .HasColumnName("last_name_2");


                entity.Property(e => e.Schoolid).HasColumnName("schoolid");

                entity.Property(e => e.University).HasColumnName("university");

                entity.HasOne(d => d.School)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.Schoolid)
                    .HasConstraintName("user_id_fkey");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
