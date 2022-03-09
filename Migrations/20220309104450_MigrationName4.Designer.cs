﻿// <auto-generated />
using System;
using Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EGrowAPI.Migrations
{
    [DbContext(typeof(MySqlContext))]
    [Migration("20220309104450_MigrationName4")]
    partial class MigrationName4
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.15");

            modelBuilder.Entity("Model.SensorData", b =>
                {
                    b.Property<byte[]>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varbinary(16)");

                    b.Property<int>("AmbientHumidityPercentage")
                        .HasColumnType("int");

                    b.Property<double>("AmbientTemperatureCelsius")
                        .HasColumnType("double");

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

                    b.HasKey("Id");

                    b.ToTable("SensorData");
                });
#pragma warning restore 612, 618
        }
    }
}
