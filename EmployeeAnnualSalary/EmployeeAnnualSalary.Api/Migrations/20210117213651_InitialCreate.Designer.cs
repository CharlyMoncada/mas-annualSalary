﻿// <auto-generated />
using System;
using EmployeeAnnualSalary.Api.DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EmployeeAnnualSalary.Api.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20210117213651_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EmployeeAnnualSalary.Api.Domain.Models.Contract", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ContractType");

                    b.HasKey("Id");

                    b.HasIndex("ContractType")
                        .IsUnique()
                        .HasFilter("[ContractType] IS NOT NULL");

                    b.ToTable("Contracts");
                });

            modelBuilder.Entity("EmployeeAnnualSalary.Api.Domain.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ContractId");

                    b.Property<int?>("PersonId");

                    b.Property<long>("SalaryPerContract");

                    b.HasKey("Id");

                    b.HasIndex("ContractId");

                    b.HasIndex("PersonId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("EmployeeAnnualSalary.Api.Domain.Models.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName");

                    b.Property<string>("Identifier");

                    b.Property<string>("LastName");

                    b.HasKey("Id");

                    b.HasIndex("Identifier")
                        .IsUnique()
                        .HasFilter("[Identifier] IS NOT NULL");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("EmployeeAnnualSalary.Api.Domain.Models.Employee", b =>
                {
                    b.HasOne("EmployeeAnnualSalary.Api.Domain.Models.Contract", "Contract")
                        .WithMany()
                        .HasForeignKey("ContractId");

                    b.HasOne("EmployeeAnnualSalary.Api.Domain.Models.Person", "Person")
                        .WithMany()
                        .HasForeignKey("PersonId");
                });
#pragma warning restore 612, 618
        }
    }
}
