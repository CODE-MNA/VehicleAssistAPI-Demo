﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VehicleAssist.Infrastructure.Data;

#nullable disable

namespace VehicleAssist.Infrastructure.Migrations
{
    [DbContext(typeof(VehicleAssistDBContext))]
    [Migration("20230307034221_newconfig")]
    partial class newconfig
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("VehicleAssist.Domain.Customer.Vehicle", b =>
                {
                    b.Property<int>("VehicleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VehicleId"));

                    b.Property<string>("Color")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageLink")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Mileage")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PlateNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("VehicleId");

                    b.HasIndex("CustomerId");

                    b.ToTable("Vehicles");
                });

            modelBuilder.Entity("VehicleAssist.Domain.Member.Member", b =>
                {
                    b.Property<int>("MemberId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("MemberId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MemberId"));

                    b.Property<string>("CellPhoneNumber")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("HomePhoneNumber")
                        .HasColumnType("varchar(30)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("MemberType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<bool>("UserActivated")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("UserActivatedDate")
                        .HasColumnType("datetime");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("MemberId");

                    b.ToTable("Members");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Member");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("VehicleAssist.Domain.Reminders.Reminder", b =>
                {
                    b.Property<int>("ReminderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReminderId"));

                    b.Property<int?>("CustomerMemberId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Latitude")
                        .HasColumnType("real");

                    b.Property<float>("Longitude")
                        .HasColumnType("real");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ReminderDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("ServiceType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ReminderId");

                    b.HasIndex("CustomerMemberId");

                    b.ToTable("Reminders");
                });

            modelBuilder.Entity("VehicleAssist.Domain.Company.Company", b =>
                {
                    b.HasBaseType("VehicleAssist.Domain.Member.Member");

                    b.Property<string>("CompanyDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Company");
                });

            modelBuilder.Entity("VehicleAssist.Domain.Customer.Customer", b =>
                {
                    b.HasBaseType("VehicleAssist.Domain.Member.Member");

                    b.HasDiscriminator().HasValue("Customer");
                });

            modelBuilder.Entity("VehicleAssist.Domain.Customer.Vehicle", b =>
                {
                    b.HasOne("VehicleAssist.Domain.Customer.Customer", "Customer")
                        .WithMany("Vehicles")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("VehicleAssist.Domain.Reminders.Reminder", b =>
                {
                    b.HasOne("VehicleAssist.Domain.Customer.Customer", null)
                        .WithMany("Reminders")
                        .HasForeignKey("CustomerMemberId");
                });

            modelBuilder.Entity("VehicleAssist.Domain.Customer.Customer", b =>
                {
                    b.Navigation("Reminders");

                    b.Navigation("Vehicles");
                });
#pragma warning restore 612, 618
        }
    }
}