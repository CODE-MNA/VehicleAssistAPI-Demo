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
    [Migration("20230319203555_addedReminderSchedule")]
    partial class addedReminderSchedule
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("VehicleAssist.Domain.Appointments.Appointment", b =>
                {
                    b.Property<int>("AppointmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AppointmentId"));

                    b.Property<bool>("AlarmYN")
                        .HasColumnType("bit");

                    b.Property<int>("CompanyServiceId")
                        .HasColumnType("int");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndDateTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartDateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("AppointmentId");

                    b.HasIndex("CompanyServiceId");

                    b.HasIndex("CustomerId");

                    b.ToTable("Appointments");
                });

            modelBuilder.Entity("VehicleAssist.Domain.Company.CompanyService", b =>
                {
                    b.Property<int>("CompanyServiceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CompanyServiceId"));

                    b.Property<int?>("CompanyMemberId")
                        .HasColumnType("int");

                    b.HasKey("CompanyServiceId");

                    b.HasIndex("CompanyMemberId");

                    b.ToTable("CompanyServices");
                });

            modelBuilder.Entity("VehicleAssist.Domain.Company.Deal", b =>
                {
                    b.Property<int>("DealId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DealId"));

                    b.Property<int?>("CompanyMemberId")
                        .HasColumnType("int");

                    b.HasKey("DealId");

                    b.HasIndex("CompanyMemberId");

                    b.ToTable("Deals");
                });

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

            modelBuilder.Entity("VehicleAssist.Domain.Member.Address", b =>
                {
                    b.Property<int>("AddressId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AddressId"));

                    b.HasKey("AddressId");

                    b.ToTable("Addresses");
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
                        .HasColumnType("varchar(60)");

                    b.Property<bool>("UserActivated")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("UserActivatedDate")
                        .HasColumnType("datetime");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("MemberId");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("UserName")
                        .IsUnique();

                    b.ToTable("Members");

                    b.HasDiscriminator<string>("MemberType").HasValue("Member");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("VehicleAssist.Domain.Notification.Notification", b =>
                {
                    b.Property<int>("NotificationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NotificationId"));

                    b.HasKey("NotificationId");

                    b.ToTable("Notifications");
                });

            modelBuilder.Entity("VehicleAssist.Domain.Reminders.Reminder", b =>
                {
                    b.Property<int>("ReminderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReminderId"));

                    b.Property<int>("CustomerId")
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

                    b.Property<int?>("VehicleId")
                        .HasColumnType("int");

                    b.HasKey("ReminderId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("VehicleId");

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

            modelBuilder.Entity("VehicleAssist.Domain.Appointments.Appointment", b =>
                {
                    b.HasOne("VehicleAssist.Domain.Company.CompanyService", "CompanyService")
                        .WithMany("Appointments")
                        .HasForeignKey("CompanyServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VehicleAssist.Domain.Customer.Customer", "Customer")
                        .WithMany("Appointments")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CompanyService");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("VehicleAssist.Domain.Company.CompanyService", b =>
                {
                    b.HasOne("VehicleAssist.Domain.Company.Company", null)
                        .WithMany("CompanyServices")
                        .HasForeignKey("CompanyMemberId");
                });

            modelBuilder.Entity("VehicleAssist.Domain.Company.Deal", b =>
                {
                    b.HasOne("VehicleAssist.Domain.Company.Company", null)
                        .WithMany("DealServices")
                        .HasForeignKey("CompanyMemberId");
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
                    b.HasOne("VehicleAssist.Domain.Customer.Customer", "Customer")
                        .WithMany("Reminders")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VehicleAssist.Domain.Customer.Vehicle", null)
                        .WithMany("Reminders")
                        .HasForeignKey("VehicleId");

                    b.OwnsMany("VehicleAssist.Domain.Reminders.ReminderAlarmSchedule", "ReminderAlarmSchedules", b1 =>
                        {
                            b1.Property<int>("ReminderAlarmScheduleId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int");

                            SqlServerPropertyBuilderExtensions.UseIdentityColumn(b1.Property<int>("ReminderAlarmScheduleId"));

                            b1.Property<int>("ReminderId")
                                .HasColumnType("int");

                            b1.Property<string>("ScheduleType")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<float>("TimePrior")
                                .HasColumnType("real");

                            b1.HasKey("ReminderAlarmScheduleId");

                            b1.HasIndex("ReminderId");

                            b1.ToTable("ReminderAlarmSchedule");

                            b1.WithOwner("Reminder")
                                .HasForeignKey("ReminderId");

                            b1.Navigation("Reminder");
                        });

                    b.Navigation("Customer");

                    b.Navigation("ReminderAlarmSchedules");
                });

            modelBuilder.Entity("VehicleAssist.Domain.Company.CompanyService", b =>
                {
                    b.Navigation("Appointments");
                });

            modelBuilder.Entity("VehicleAssist.Domain.Customer.Vehicle", b =>
                {
                    b.Navigation("Reminders");
                });

            modelBuilder.Entity("VehicleAssist.Domain.Company.Company", b =>
                {
                    b.Navigation("CompanyServices");

                    b.Navigation("DealServices");
                });

            modelBuilder.Entity("VehicleAssist.Domain.Customer.Customer", b =>
                {
                    b.Navigation("Appointments");

                    b.Navigation("Reminders");

                    b.Navigation("Vehicles");
                });
#pragma warning restore 612, 618
        }
    }
}
