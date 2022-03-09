﻿// <auto-generated />
using System;
using Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EGrowAPI.Migrations
{
    [DbContext(typeof(MySqlContext))]
    partial class MySqlContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.15");

            modelBuilder.Entity("Models.Device", b =>
                {
                    b.Property<string>("DeviceGuid")
                        .HasColumnType("varchar(767)");

                    b.HasKey("DeviceGuid");

                    b.ToTable("Devices");
                });

            modelBuilder.Entity("Models.SensorData", b =>
                {
                    b.Property<string>("SensorDataGuid")
                        .HasColumnType("varchar(767)");

                    b.Property<int>("AmbientHumidityPercentage")
                        .HasColumnType("int");

                    b.Property<double>("AmbientTemperatureCelsius")
                        .HasColumnType("double");

                    b.Property<string>("DeviceGuid")
                        .HasColumnType("varchar(767)");

                    b.Property<int>("GrowthCm")
                        .HasColumnType("int");

                    b.Property<int>("LeafWetness")
                        .HasColumnType("int");

                    b.Property<int>("SoilHumidityPercentage")
                        .HasColumnType("int");

                    b.Property<double>("SoilTemperatureCelsius")
                        .HasColumnType("double");

                    b.Property<int>("SolarRadiation")
                        .HasColumnType("int");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime");

                    b.Property<int>("UvIndex")
                        .HasColumnType("int");

                    b.HasKey("SensorDataGuid");

                    b.HasIndex("DeviceGuid");

                    b.ToTable("SensorData");
                });

            modelBuilder.Entity("Models.User", b =>
                {
                    b.Property<string>("UserGuid")
                        .HasColumnType("varchar(767)");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<string>("Username")
                        .HasColumnType("text");

                    b.HasKey("UserGuid");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Models.SensorData", b =>
                {
                    b.HasOne("Models.Device", "Device")
                        .WithMany()
                        .HasForeignKey("DeviceGuid");

                    b.Navigation("Device");
                });
#pragma warning restore 612, 618
        }
    }
}
