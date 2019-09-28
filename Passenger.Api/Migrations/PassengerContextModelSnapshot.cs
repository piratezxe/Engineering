﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Passenger.Core.Database;

namespace EngineeringWork.Web.Migrations
{
    [DbContext(typeof(PassengerContext))]
    partial class PassengerContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Passenger.Core.Domain.DailyRoute", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("DailyRouteId");

                    b.Property<DateTime>("DateTime");

                    b.Property<Guid?>("DriverId");

                    b.HasKey("Id");

                    b.HasIndex("DriverId");

                    b.ToTable("DailyRoutes");
                });

            modelBuilder.Entity("Passenger.Core.Domain.Driver", b =>
                {
                    b.Property<Guid>("DriverId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("UpdatedAt");

                    b.Property<Guid?>("VehicleId");

                    b.HasKey("DriverId");

                    b.HasIndex("VehicleId");

                    b.ToTable("Drivers");
                });

            modelBuilder.Entity("Passenger.Core.Domain.Node", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<double>("Latitude");

                    b.Property<double>("Longitude");

                    b.Property<DateTime>("UpdatedAt");

                    b.HasKey("Id");

                    b.ToTable("Node");
                });

            modelBuilder.Entity("Passenger.Core.Domain.Passenger", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("AddressId");

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.ToTable("Passenger");
                });

            modelBuilder.Entity("Passenger.Core.Domain.PassengerNode", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("DailyRouteId");

                    b.Property<Guid?>("NodeId");

                    b.Property<Guid?>("PassengerId");

                    b.HasKey("Id");

                    b.HasIndex("DailyRouteId");

                    b.HasIndex("NodeId");

                    b.HasIndex("PassengerId");

                    b.ToTable("PassengerNode");
                });

            modelBuilder.Entity("Passenger.Core.Domain.RefreshToken", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Revoke");

                    b.Property<string>("Token");

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.ToTable("RefreshTokens");
                });

            modelBuilder.Entity("Passenger.Core.Domain.Route", b =>
                {
                    b.Property<Guid>("RouteId")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("DailyRouteId");

                    b.Property<Guid?>("EndNodeId");

                    b.Property<Guid?>("StartNodeId");

                    b.HasKey("RouteId");

                    b.HasIndex("DailyRouteId")
                        .IsUnique();

                    b.HasIndex("EndNodeId");

                    b.HasIndex("StartNodeId");

                    b.ToTable("Route");
                });

            modelBuilder.Entity("Passenger.Core.Domain.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Email");

                    b.Property<string>("FullName");

                    b.Property<string>("Password");

                    b.Property<string>("Role");

                    b.Property<string>("Salt");

                    b.Property<DateTime>("UpdatedAt");

                    b.Property<string>("Username");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Passenger.Core.Domain.Vehicle", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Brand");

                    b.Property<string>("Name");

                    b.Property<int>("Seats");

                    b.HasKey("Id");

                    b.ToTable("Vehicle");
                });

            modelBuilder.Entity("Passenger.Core.Domain.DailyRoute", b =>
                {
                    b.HasOne("Passenger.Core.Domain.Driver", "Driver")
                        .WithMany("DailyRoutes")
                        .HasForeignKey("DriverId");
                });

            modelBuilder.Entity("Passenger.Core.Domain.Driver", b =>
                {
                    b.HasOne("Passenger.Core.Domain.Vehicle", "Vehicle")
                        .WithMany()
                        .HasForeignKey("VehicleId");
                });

            modelBuilder.Entity("Passenger.Core.Domain.Passenger", b =>
                {
                    b.HasOne("Passenger.Core.Domain.Node", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId");
                });

            modelBuilder.Entity("Passenger.Core.Domain.PassengerNode", b =>
                {
                    b.HasOne("Passenger.Core.Domain.DailyRoute", "DailyRoute")
                        .WithMany("PassengerNodes")
                        .HasForeignKey("DailyRouteId");

                    b.HasOne("Passenger.Core.Domain.Node", "Node")
                        .WithMany()
                        .HasForeignKey("NodeId");

                    b.HasOne("Passenger.Core.Domain.Passenger", "Passenger")
                        .WithMany()
                        .HasForeignKey("PassengerId");
                });

            modelBuilder.Entity("Passenger.Core.Domain.Route", b =>
                {
                    b.HasOne("Passenger.Core.Domain.DailyRoute", "DailyRoute")
                        .WithOne("Route")
                        .HasForeignKey("Passenger.Core.Domain.Route", "DailyRouteId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Passenger.Core.Domain.Node", "EndNode")
                        .WithMany()
                        .HasForeignKey("EndNodeId");

                    b.HasOne("Passenger.Core.Domain.Node", "StartNode")
                        .WithMany()
                        .HasForeignKey("StartNodeId");
                });
#pragma warning restore 612, 618
        }
    }
}
