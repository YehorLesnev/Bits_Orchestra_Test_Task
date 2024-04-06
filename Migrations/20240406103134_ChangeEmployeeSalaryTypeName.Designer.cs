﻿// <auto-generated />
using System;
using Bits_Orchestra_Test_Task.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Bits_Orchestra_Test_Task.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240406103134_ChangeEmployeeSalaryTypeName")]
    partial class ChangeEmployeeSalaryTypeName
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Bits_Orchestra_Test_Task.Entities.Employee", b =>
                {
                    b.Property<Guid>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("employee_id");

                    b.Property<DateOnly>("EmployeeDateOfBirth")
                        .HasColumnType("date")
                        .HasColumnName("employee_date_of_birth");

                    b.Property<string>("EmployeeName")
                        .IsRequired()
                        .HasMaxLength(55)
                        .HasColumnType("nvarchar(55)")
                        .HasColumnName("employee_name");

                    b.Property<string>("EmployeePhone")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("employee_phone");

                    b.Property<decimal>("EmployeeSalary")
                        .HasColumnType("Decimal(10,2)")
                        .HasColumnName("employee_salary");

                    b.Property<bool>("IsMarried")
                        .HasColumnType("bit")
                        .HasColumnName("is_married");

                    b.HasKey("EmployeeId");

                    b.ToTable("employees");
                });
#pragma warning restore 612, 618
        }
    }
}
