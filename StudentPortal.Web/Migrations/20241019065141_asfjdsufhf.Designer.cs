﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StudentPortal.Web.Data;

#nullable disable

namespace StudentPortal.Web.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241019065141_asfjdsufhf")]
    partial class asfjdsufhf
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("StudentPortal.Web.Models.Entities.Schedule", b =>
                {
                    b.Property<int>("SubjectCode")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SubjectCode"));

                    b.Property<string>("AMPM")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CurriculumYear")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Days")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<TimeSpan>("EndTime")
                        .HasColumnType("time");

                    b.Property<string>("Room")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Section")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<TimeSpan>("StartTime")
                        .HasColumnType("time");

                    b.HasKey("SubjectCode");

                    b.ToTable("Schedule");
                });

            modelBuilder.Entity("StudentPortal.Web.Models.Entities.Student", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Course")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("StudentPortal.Web.Models.Entities.Subject", b =>
                {
                    b.Property<string>("SubjectCode")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("CourseCode")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("CurriculumYear")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Offering")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Requisite")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Units")
                        .HasColumnType("int");

                    b.HasKey("SubjectCode");

                    b.ToTable("Subjects");
                });
#pragma warning restore 612, 618
        }
    }
}
