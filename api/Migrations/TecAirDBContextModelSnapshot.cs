﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using api.Data;

namespace api.Migrations
{
    [DbContext(typeof(TecAirDBContext))]
    partial class TecAirDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityByDefaultColumns()
                .HasAnnotation("Relational:Collation", "Spanish_Costa Rica.1252")
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<int>("RoleId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("text");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.Property<int>("RoleId")
                        .HasColumnType("integer");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("api.Entities.Baggage", b =>
                {
                    b.Property<int>("Uniqueid")
                        .HasColumnType("integer")
                        .HasColumnName("uniqueid");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("color");

                    b.Property<int>("Ssn")
                        .HasColumnType("integer")
                        .HasColumnName("ssn");

                    b.Property<string>("Status")
                        .HasColumnType("text")
                        .HasColumnName("status");

                    b.Property<int>("Weight")
                        .HasColumnType("integer")
                        .HasColumnName("weight");

                    b.HasKey("Uniqueid")
                        .HasName("baggage_pkey");

                    b.HasIndex("Ssn");

                    b.ToTable("baggage");
                });

            modelBuilder.Entity("api.Entities.Book", b =>
                {
                    b.Property<int>("Ssn")
                        .HasColumnType("integer")
                        .HasColumnName("ssn");

                    b.Property<int>("IdFlight")
                        .HasColumnType("integer")
                        .HasColumnName("id_flight");

                    b.Property<string>("Seat")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("seat");

                    b.Property<string>("Status")
                        .HasColumnType("text")
                        .HasColumnName("status");

                    b.HasKey("Ssn", "IdFlight")
                        .HasName("book_pkey");

                    b.HasIndex("IdFlight");

                    b.ToTable("book");
                });

            modelBuilder.Entity("api.Entities.Flight", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    b.Property<string>("AirplaneLicense")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("airplane_license");

                    b.Property<int?>("Deals")
                        .HasColumnType("integer")
                        .HasColumnName("deals");

                    b.Property<string>("Gate")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("gate");

                    b.Property<int>("IdRute")
                        .HasColumnType("integer")
                        .HasColumnName("id_rute");

                    b.Property<DateTime>("Schedule")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("schedule");

                    b.Property<string>("Status")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text")
                        .HasColumnName("status")
                        .HasDefaultValueSql("'In time'::text");

                    b.HasKey("Id");

                    b.HasIndex("AirplaneLicense");

                    b.HasIndex("IdRute");

                    b.ToTable("flight");
                });

            modelBuilder.Entity("api.Entities.Plane", b =>
                {
                    b.Property<string>("AirplaneLicense")
                        .HasColumnType("text")
                        .HasColumnName("airplane_license");

                    b.Property<int>("Capacity")
                        .HasColumnType("integer")
                        .HasColumnName("capacity");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("model");

                    b.Property<string>("Status")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text")
                        .HasColumnName("status")
                        .HasDefaultValueSql("'Free'::text");

                    b.HasKey("AirplaneLicense")
                        .HasName("plane_pkey");

                    b.ToTable("plane");
                });

            modelBuilder.Entity("api.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("api.Entities.Rute", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    b.Property<string>("Arrival")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("arrival");

                    b.Property<string>("Departure")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("departure");

                    b.Property<string>("Miles")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("miles");

                    b.HasKey("Id");

                    b.ToTable("rute");
                });

            modelBuilder.Entity("api.Entities.Scale", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<int>("OrderLanding")
                        .HasColumnType("integer")
                        .HasColumnName("order_landing");

                    b.Property<string>("Place")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("place");

                    b.Property<int>("RuteId")
                        .HasColumnType("integer")
                        .HasColumnName("route_id");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .IsUnique();

                    b.HasIndex("RuteId");

                    b.ToTable("scale");
                });

            modelBuilder.Entity("api.Entities.Schoolid", b =>
                {
                    b.Property<int>("Number")
                        .HasColumnType("integer")
                        .HasColumnName("number");

                    b.Property<int>("Mile")
                        .HasColumnType("integer")
                        .HasColumnName("mile");

                    b.HasKey("Number")
                        .HasName("id_pkey");

                    b.ToTable("schoolid");
                });

            modelBuilder.Entity("api.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("first_name");

                    b.Property<string>("LastName1")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("last_name_1");

                    b.Property<string>("LastName2")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("last_name_2");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<int?>("Schoolid")
                        .HasColumnType("integer")
                        .HasColumnName("schoolid");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<int?>("Ssn")
                        .IsRequired()
                        .HasColumnType("integer")
                        .HasColumnName("ssn");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("University")
                        .HasColumnType("text")
                        .HasColumnName("university");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.HasIndex("Schoolid");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("api.Entities.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("api.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("api.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.HasOne("api.Entities.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("api.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("api.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("api.Entities.Baggage", b =>
                {
                    b.HasOne("api.Entities.User", "SsnNavigation")
                        .WithMany("Baggages")
                        .HasForeignKey("Ssn")
                        .HasConstraintName("baggage_ssn_fkey")
                        .IsRequired();

                    b.Navigation("SsnNavigation");
                });

            modelBuilder.Entity("api.Entities.Book", b =>
                {
                    b.HasOne("api.Entities.Flight", "IdFlightNavigation")
                        .WithMany("Books")
                        .HasForeignKey("IdFlight")
                        .HasConstraintName("book_id_flight_fkey")
                        .IsRequired();

                    b.HasOne("api.Entities.User", "SsnNavigation")
                        .WithMany("Books")
                        .HasForeignKey("Ssn")
                        .HasConstraintName("book_ssn_fkey")
                        .IsRequired();

                    b.Navigation("IdFlightNavigation");

                    b.Navigation("SsnNavigation");
                });

            modelBuilder.Entity("api.Entities.Flight", b =>
                {
                    b.HasOne("api.Entities.Plane", "AirplaneLicenseNavigation")
                        .WithMany("Flights")
                        .HasForeignKey("AirplaneLicense")
                        .HasConstraintName("flight_airplane_license_fkey")
                        .IsRequired();

                    b.HasOne("api.Entities.Rute", "IdRuteNavigation")
                        .WithMany("Flights")
                        .HasForeignKey("IdRute")
                        .HasConstraintName("flight_id_rute_fkey")
                        .IsRequired();

                    b.Navigation("AirplaneLicenseNavigation");

                    b.Navigation("IdRuteNavigation");
                });

            modelBuilder.Entity("api.Entities.Scale", b =>
                {
                    b.HasOne("api.Entities.Rute", "Rute")
                        .WithMany("Scales")
                        .HasForeignKey("RuteId")
                        .HasConstraintName("scale_id_rute_fkey")
                        .IsRequired();

                    b.Navigation("Rute");
                });

            modelBuilder.Entity("api.Entities.User", b =>
                {
                    b.HasOne("api.Entities.Schoolid", "School")
                        .WithMany("Users")
                        .HasForeignKey("Schoolid")
                        .HasConstraintName("user_id_fkey");

                    b.Navigation("School");
                });

            modelBuilder.Entity("api.Entities.Flight", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("api.Entities.Plane", b =>
                {
                    b.Navigation("Flights");
                });

            modelBuilder.Entity("api.Entities.Rute", b =>
                {
                    b.Navigation("Flights");

                    b.Navigation("Scales");
                });

            modelBuilder.Entity("api.Entities.Schoolid", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("api.Entities.User", b =>
                {
                    b.Navigation("Baggages");

                    b.Navigation("Books");
                });
#pragma warning restore 612, 618
        }
    }
}
