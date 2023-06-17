﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApi.Models;

#nullable disable

namespace Persistance.Migrations
{
    [DbContext(typeof(BtsContext))]
    [Migration("20230616163546_AddUserIdentity")]
    partial class AddUserIdentity
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseCollation("utf8mb4_0900_ai_ci")
                .HasAnnotation("ProductVersion", "7.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.HasCharSet(modelBuilder, "utf8mb4");

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<string>("NormalizedName")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<string>("RoleId")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("RoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ClaimType")
                        .HasColumnType("longtext");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("longtext");

                    b.Property<string>("UserId")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("UserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("longtext");

                    b.Property<string>("ProviderKey")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("UserId")
                        .HasColumnType("longtext");

                    b.ToTable("UserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("RoleId")
                        .HasColumnType("longtext");

                    b.Property<string>("UserId")
                        .HasColumnType("longtext");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("UserId")
                        .HasColumnType("longtext");

                    b.Property<string>("Value")
                        .HasColumnType("longtext");

                    b.ToTable("UserTokens");
                });

            modelBuilder.Entity("WebApi.Models.Driver", b =>
                {
                    b.Property<uint>("DriverId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int unsigned")
                        .HasColumnName("driver_id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)")
                        .HasColumnName("name");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)")
                        .HasColumnName("surname");

                    b.HasKey("DriverId")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "DriverId" }, "driver_id_UNIQUE")
                        .IsUnique();

                    b.ToTable("driver", (string)null);
                });

            modelBuilder.Entity("WebApi.Models.Route", b =>
                {
                    b.Property<int>("RouteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("route_id");

                    b.Property<uint>("Distance")
                        .HasColumnType("int unsigned")
                        .HasColumnName("distance");

                    b.Property<string>("EndLocation")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)")
                        .HasColumnName("end_location");

                    b.Property<uint>("FkDriver")
                        .HasColumnType("int unsigned")
                        .HasColumnName("fk_driver");

                    b.Property<uint>("FkShedule")
                        .HasColumnType("int unsigned")
                        .HasColumnName("fk_shedule");

                    b.Property<uint>("FkTransport")
                        .HasColumnType("int unsigned")
                        .HasColumnName("fk_transport");

                    b.Property<string>("StartLocation")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)")
                        .HasColumnName("start_location");

                    b.HasKey("RouteId")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "FkDriver" }, "driver_id_idx");

                    b.HasIndex(new[] { "FkShedule" }, "fk_shedule_idx");

                    b.HasIndex(new[] { "FkTransport" }, "transport_id_idx");

                    b.ToTable("route", (string)null);
                });

            modelBuilder.Entity("WebApi.Models.Shedule", b =>
                {
                    b.Property<uint>("SheduleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int unsigned")
                        .HasColumnName("shedule_id");

                    b.Property<TimeOnly>("ArrivalTime")
                        .HasColumnType("time")
                        .HasColumnName("arrival_time");

                    b.Property<DateOnly>("Date")
                        .HasColumnType("date")
                        .HasColumnName("date");

                    b.Property<TimeOnly>("DepartureTime")
                        .HasColumnType("time")
                        .HasColumnName("departure_time");

                    b.HasKey("SheduleId")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "SheduleId" }, "shedule_id_UNIQUE")
                        .IsUnique();

                    b.ToTable("shedule", (string)null);
                });

            modelBuilder.Entity("WebApi.Models.Ticket", b =>
                {
                    b.Property<uint>("TicketId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int unsigned")
                        .HasColumnName("ticket_id");

                    b.Property<int>("FkRouteT")
                        .HasColumnType("int")
                        .HasColumnName("fk_route_t");

                    b.Property<uint>("Price")
                        .HasColumnType("int unsigned")
                        .HasColumnName("price");

                    b.Property<int>("Seat")
                        .HasColumnType("int")
                        .HasColumnName("seat");

                    b.HasKey("TicketId")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "FkRouteT" }, "fk_route_idx");

                    b.HasIndex(new[] { "TicketId" }, "ticket_id_UNIQUE")
                        .IsUnique();

                    b.ToTable("ticket", (string)null);
                });

            modelBuilder.Entity("WebApi.Models.Transport", b =>
                {
                    b.Property<uint>("TransportId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int unsigned")
                        .HasColumnName("transport_id");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("color");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("model");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)")
                        .HasColumnName("number");

                    b.HasKey("TransportId")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "Number" }, "number_UNIQUE")
                        .IsUnique();

                    b.HasIndex(new[] { "TransportId" }, "transport_id_UNIQUE")
                        .IsUnique();

                    b.ToTable("transport", (string)null);
                });

            modelBuilder.Entity("WebApi.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255)")
                        .HasColumnName("user_id");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .HasColumnType("longtext");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("longtext");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("longtext");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("longtext");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(28)
                        .HasColumnType("varchar(28)")
                        .HasColumnName("surname");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("UserName")
                        .HasColumnType("longtext");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "Id" }, "user_id_UNIQUE")
                        .IsUnique();

                    b.ToTable("user", (string)null);
                });

            modelBuilder.Entity("WebApi.Models.Route", b =>
                {
                    b.HasOne("WebApi.Models.Driver", "FkDriverNavigation")
                        .WithMany("Routes")
                        .HasForeignKey("FkDriver")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_driver");

                    b.HasOne("WebApi.Models.Shedule", "FkSheduleNavigation")
                        .WithMany("Routes")
                        .HasForeignKey("FkShedule")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_shedule");

                    b.HasOne("WebApi.Models.Transport", "FkTransportNavigation")
                        .WithMany("Routes")
                        .HasForeignKey("FkTransport")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_transport");

                    b.Navigation("FkDriverNavigation");

                    b.Navigation("FkSheduleNavigation");

                    b.Navigation("FkTransportNavigation");
                });

            modelBuilder.Entity("WebApi.Models.Ticket", b =>
                {
                    b.HasOne("WebApi.Models.Route", "FkRouteTNavigation")
                        .WithMany("Tickets")
                        .HasForeignKey("FkRouteT")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_route_t");

                    b.Navigation("FkRouteTNavigation");
                });

            modelBuilder.Entity("WebApi.Models.Driver", b =>
                {
                    b.Navigation("Routes");
                });

            modelBuilder.Entity("WebApi.Models.Route", b =>
                {
                    b.Navigation("Tickets");
                });

            modelBuilder.Entity("WebApi.Models.Shedule", b =>
                {
                    b.Navigation("Routes");
                });

            modelBuilder.Entity("WebApi.Models.Transport", b =>
                {
                    b.Navigation("Routes");
                });
#pragma warning restore 612, 618
        }
    }
}
