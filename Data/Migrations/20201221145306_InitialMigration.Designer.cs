﻿// <auto-generated />
using System;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Data.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20201221145306_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9");

            modelBuilder.Entity("Data.Models.ConditionModel", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("TEXT");

                    b.Property<int?>("Ground")
                        .HasColumnType("INTEGER");

                    b.Property<int>("RideId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Temperature")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("RideId")
                        .IsUnique();

                    b.ToTable("Conditions");
                });

            modelBuilder.Entity("Data.Models.LapModel", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("TEXT");

                    b.Property<double>("DistanceMeters")
                        .HasColumnType("REAL");

                    b.Property<double>("MaximumSpeed")
                        .HasColumnType("REAL");

                    b.Property<bool>("MaximumSpeedSpecified")
                        .HasColumnType("INTEGER");

                    b.Property<int>("RideId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("TEXT");

                    b.Property<double>("TotalTimeSeconds")
                        .HasColumnType("REAL");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("RideId");

                    b.ToTable("Laps");
                });

            modelBuilder.Entity("Data.Models.LapTrackpointModel", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double?>("Altitude")
                        .HasColumnType("REAL");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("LapId")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Latitude")
                        .HasColumnType("REAL");

                    b.Property<double>("Longitude")
                        .HasColumnType("REAL");

                    b.Property<double?>("Speed")
                        .HasColumnType("REAL");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("LapId");

                    b.ToTable("LapTrackpoints");
                });

            modelBuilder.Entity("Data.Models.RideModel", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Comment")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int?>("RouteId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("RouteId");

                    b.ToTable("Rides");
                });

            modelBuilder.Entity("Data.Models.RouteModel", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Comment")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int>("RouteEnum")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Routes");
                });

            modelBuilder.Entity("Data.Models.RouteTrackpointModel", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double?>("Altitude")
                        .HasColumnType("REAL");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("TEXT");

                    b.Property<double>("Latitude")
                        .HasColumnType("REAL");

                    b.Property<double>("Longitude")
                        .HasColumnType("REAL");

                    b.Property<int>("RouteId")
                        .HasColumnType("INTEGER");

                    b.Property<double?>("Speed")
                        .HasColumnType("REAL");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("RouteId");

                    b.ToTable("RouteTrackpoints");
                });

            modelBuilder.Entity("Data.Models.ConditionModel", b =>
                {
                    b.HasOne("Data.Models.RideModel", "Ride")
                        .WithOne("Condition")
                        .HasForeignKey("Data.Models.ConditionModel", "RideId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Data.Models.LapModel", b =>
                {
                    b.HasOne("Data.Models.RideModel", "Ride")
                        .WithMany()
                        .HasForeignKey("RideId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Data.Models.LapTrackpointModel", b =>
                {
                    b.HasOne("Data.Models.LapModel", "Lap")
                        .WithMany("Trackpoints")
                        .HasForeignKey("LapId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Data.Models.RideModel", b =>
                {
                    b.HasOne("Data.Models.RouteModel", "Route")
                        .WithMany("Rides")
                        .HasForeignKey("RouteId");
                });

            modelBuilder.Entity("Data.Models.RouteTrackpointModel", b =>
                {
                    b.HasOne("Data.Models.RouteModel", "Route")
                        .WithMany("Trackpoints")
                        .HasForeignKey("RouteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
