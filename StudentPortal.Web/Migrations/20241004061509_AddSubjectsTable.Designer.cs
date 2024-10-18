﻿// <auto-generated />
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
    [Migration("20241004061509_AddSubjectsTable")]
    partial class AddSubjectsTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

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
                    b.Property<int>("SubjectCode")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SubjectCode"));

                    b.Property<string>("SubjectName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Units")
                        .HasColumnType("int");

                    b.HasKey("SubjectCode");

                    b.ToTable("Subjects");
                });
#pragma warning restore 612, 618
        }
    }
}
