﻿// <auto-generated />
using System;
using CodingTracker.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CodingTracker.Migrations
{
    [DbContext(typeof(CodingTrackerContext))]
    [Migration("20230202225018_DeadlineString")]
    partial class DeadlineString
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.2");

            modelBuilder.Entity("CodingTracker.CodingGoals", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CreationDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Deadline")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Goal")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("Hours")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("CodingGoals");
                });

            modelBuilder.Entity("CodingTracker.Model.CodingSession", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Duration")
                        .HasColumnType("INTEGER");

                    b.Property<string>("EndTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("StartTime")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Sessions");
                });
#pragma warning restore 612, 618
        }
    }
}
