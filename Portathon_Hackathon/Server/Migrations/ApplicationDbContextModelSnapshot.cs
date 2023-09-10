﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Portathon_Hackathon.Server.Context;

#nullable disable

namespace Portathon_Hackathon.Server.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.21")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Portathon_Hackathon.Shared.Entities.Company", b =>
                {
                    b.Property<int>("CompanyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CompanyId"), 1L, 1);

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CompanyId");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("Portathon_Hackathon.Shared.Entities.CrewMember", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("MemberName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("VehicleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("VehicleId");

                    b.ToTable("CrewMembers");
                });

            modelBuilder.Entity("Portathon_Hackathon.Shared.Entities.Evaluation", b =>
                {
                    b.Property<int>("EvaluationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EvaluationId"), 1L, 1);

                    b.Property<string>("EvaluationMessage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("EvaluationScore")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ReservationId")
                        .HasColumnType("int");

                    b.HasKey("EvaluationId");

                    b.HasIndex("ReservationId")
                        .IsUnique();

                    b.ToTable("Evaluations");
                });

            modelBuilder.Entity("Portathon_Hackathon.Shared.Entities.Request", b =>
                {
                    b.Property<int>("RequestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RequestId"), 1L, 1);

                    b.Property<string>("ContactConfirmation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("RequestDetail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RequestType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("VehicleId")
                        .HasColumnType("int");

                    b.HasKey("RequestId");

                    b.HasIndex("UserId");

                    b.HasIndex("VehicleId");

                    b.ToTable("Requests");
                });

            modelBuilder.Entity("Portathon_Hackathon.Shared.Entities.Reservation", b =>
                {
                    b.Property<int>("ReservationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReservationId"), 1L, 1);

                    b.Property<string>("OtherDetails")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RequestId")
                        .HasColumnType("int");

                    b.Property<string>("ReservationCase")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ReservationDate")
                        .HasColumnType("datetime2");

                    b.HasKey("ReservationId");

                    b.HasIndex("RequestId");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("Portathon_Hackathon.Shared.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("UserType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Portathon_Hackathon.Shared.Entities.Vehicle", b =>
                {
                    b.Property<int>("VehicleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VehicleId"), 1L, 1);

                    b.Property<decimal>("Capacity")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ChauffeurName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<string>("PlateNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TechnicDetail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VehicleType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("VehicleId");

                    b.HasIndex("CompanyId");

                    b.ToTable("Vehicles");
                });

            modelBuilder.Entity("Portathon_Hackathon.Shared.Entities.CrewMember", b =>
                {
                    b.HasOne("Portathon_Hackathon.Shared.Entities.Vehicle", "Vehicle")
                        .WithMany("CrewMembers")
                        .HasForeignKey("VehicleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("Portathon_Hackathon.Shared.Entities.Evaluation", b =>
                {
                    b.HasOne("Portathon_Hackathon.Shared.Entities.Reservation", "Reservation")
                        .WithOne("Evaluation")
                        .HasForeignKey("Portathon_Hackathon.Shared.Entities.Evaluation", "ReservationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Reservation");
                });

            modelBuilder.Entity("Portathon_Hackathon.Shared.Entities.Request", b =>
                {
                    b.HasOne("Portathon_Hackathon.Shared.Entities.User", "User")
                        .WithMany("Requests")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Portathon_Hackathon.Shared.Entities.Vehicle", "Vehicle")
                        .WithMany("requests")
                        .HasForeignKey("VehicleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("Portathon_Hackathon.Shared.Entities.Reservation", b =>
                {
                    b.HasOne("Portathon_Hackathon.Shared.Entities.Request", "Request")
                        .WithMany()
                        .HasForeignKey("RequestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Request");
                });

            modelBuilder.Entity("Portathon_Hackathon.Shared.Entities.Vehicle", b =>
                {
                    b.HasOne("Portathon_Hackathon.Shared.Entities.Company", "Company")
                        .WithMany("Vehicles")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("Portathon_Hackathon.Shared.Entities.Company", b =>
                {
                    b.Navigation("Vehicles");
                });

            modelBuilder.Entity("Portathon_Hackathon.Shared.Entities.Reservation", b =>
                {
                    b.Navigation("Evaluation")
                        .IsRequired();
                });

            modelBuilder.Entity("Portathon_Hackathon.Shared.Entities.User", b =>
                {
                    b.Navigation("Requests");
                });

            modelBuilder.Entity("Portathon_Hackathon.Shared.Entities.Vehicle", b =>
                {
                    b.Navigation("CrewMembers");

                    b.Navigation("requests");
                });
#pragma warning restore 612, 618
        }
    }
}
