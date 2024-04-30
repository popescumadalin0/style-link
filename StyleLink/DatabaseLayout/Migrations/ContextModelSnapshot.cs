﻿// <auto-generated />
using System;
using DatabaseLayout;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DatabaseLayout.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DatabaseLayout.Models.Appointment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("HairStylistSalonServiceId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("HairStylistSalonServiceId");

                    b.HasIndex("UserId");

                    b.ToTable("Appointments");
                });

            modelBuilder.Entity("DatabaseLayout.Models.Favorite", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SalonId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("SalonId");

                    b.HasIndex("UserId");

                    b.ToTable("Favorites");
                });

            modelBuilder.Entity("DatabaseLayout.Models.Feature", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("HTMLFlag")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Features");
                });

            modelBuilder.Entity("DatabaseLayout.Models.HairStylist", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("ProfileImage")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("ProfileImageFileName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProfileImageName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("HairStylists");
                });

            modelBuilder.Entity("DatabaseLayout.Models.HairStylistSalon", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("HairStylistId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SalonId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("HairStylistId");

                    b.HasIndex("SalonId");

                    b.ToTable("HairStylistSalons");
                });

            modelBuilder.Entity("DatabaseLayout.Models.HairStylistSalonService", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Currency")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("HairStylistSalonId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<Guid>("ServiceId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<TimeOnly>("Time")
                        .HasColumnType("time");

                    b.HasKey("Id");

                    b.HasIndex("HairStylistSalonId");

                    b.HasIndex("ServiceId");

                    b.ToTable("HairStylistSalonServices");
                });

            modelBuilder.Entity("DatabaseLayout.Models.Role", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Name");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("DatabaseLayout.Models.Salon", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GoogleMapsAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("ProfileImage")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("ProfileImageFileName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProfileImageName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Rating")
                        .HasColumnType("float");

                    b.Property<int>("ReviewCount")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Salons");
                });

            modelBuilder.Entity("DatabaseLayout.Models.SalonImage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<byte[]>("Content")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("SalonId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("SalonId");

                    b.ToTable("SalonImages");
                });

            modelBuilder.Entity("DatabaseLayout.Models.Service", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ServiceTypeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("ServiceTypeName");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("DatabaseLayout.Models.ServiceType", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Name");

                    b.ToTable("ServiceTypes");
                });

            modelBuilder.Entity("DatabaseLayout.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProfileImage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleName");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("DatabaseLayout.Models.WorkProgram", b =>
                {
                    b.Property<Guid>("SalonId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Friday")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Monday")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Saturday")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sunday")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Thursday")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tuesday")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Wednesday")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SalonId");

                    b.ToTable("WorkPrograms");
                });

            modelBuilder.Entity("FeatureRole", b =>
                {
                    b.Property<Guid>("FeaturesId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("RolesName")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("FeaturesId", "RolesName");

                    b.HasIndex("RolesName");

                    b.ToTable("FeatureRole");
                });

            modelBuilder.Entity("HairStylistService", b =>
                {
                    b.Property<Guid>("HairStylistsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ServicesId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("HairStylistsId", "ServicesId");

                    b.HasIndex("ServicesId");

                    b.ToTable("HairStylistService");
                });

            modelBuilder.Entity("DatabaseLayout.Models.Appointment", b =>
                {
                    b.HasOne("DatabaseLayout.Models.HairStylistSalonService", "HairStylistSalonService")
                        .WithMany("Appointments")
                        .HasForeignKey("HairStylistSalonServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DatabaseLayout.Models.User", "User")
                        .WithMany("Appointments")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("HairStylistSalonService");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DatabaseLayout.Models.Favorite", b =>
                {
                    b.HasOne("DatabaseLayout.Models.Salon", "Salon")
                        .WithMany("Favorites")
                        .HasForeignKey("SalonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DatabaseLayout.Models.User", "User")
                        .WithMany("Favorites")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Salon");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DatabaseLayout.Models.HairStylistSalon", b =>
                {
                    b.HasOne("DatabaseLayout.Models.HairStylist", "HairStylist")
                        .WithMany("HairStylistSalons")
                        .HasForeignKey("HairStylistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DatabaseLayout.Models.Salon", "Salon")
                        .WithMany("HairStylistSalons")
                        .HasForeignKey("SalonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("HairStylist");

                    b.Navigation("Salon");
                });

            modelBuilder.Entity("DatabaseLayout.Models.HairStylistSalonService", b =>
                {
                    b.HasOne("DatabaseLayout.Models.HairStylistSalon", "HairStylistSalon")
                        .WithMany("HairStylistSalonServices")
                        .HasForeignKey("HairStylistSalonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DatabaseLayout.Models.Service", "Service")
                        .WithMany("HairStylistSalonServices")
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("HairStylistSalon");

                    b.Navigation("Service");
                });

            modelBuilder.Entity("DatabaseLayout.Models.SalonImage", b =>
                {
                    b.HasOne("DatabaseLayout.Models.Salon", "Salon")
                        .WithMany("SalonImages")
                        .HasForeignKey("SalonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Salon");
                });

            modelBuilder.Entity("DatabaseLayout.Models.Service", b =>
                {
                    b.HasOne("DatabaseLayout.Models.ServiceType", "ServiceType")
                        .WithMany("Services")
                        .HasForeignKey("ServiceTypeName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ServiceType");
                });

            modelBuilder.Entity("DatabaseLayout.Models.User", b =>
                {
                    b.HasOne("DatabaseLayout.Models.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("DatabaseLayout.Models.WorkProgram", b =>
                {
                    b.HasOne("DatabaseLayout.Models.Salon", "Salon")
                        .WithOne("WorkProgram")
                        .HasForeignKey("DatabaseLayout.Models.WorkProgram", "SalonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Salon");
                });

            modelBuilder.Entity("FeatureRole", b =>
                {
                    b.HasOne("DatabaseLayout.Models.Feature", null)
                        .WithMany()
                        .HasForeignKey("FeaturesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DatabaseLayout.Models.Role", null)
                        .WithMany()
                        .HasForeignKey("RolesName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("HairStylistService", b =>
                {
                    b.HasOne("DatabaseLayout.Models.HairStylist", null)
                        .WithMany()
                        .HasForeignKey("HairStylistsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DatabaseLayout.Models.Service", null)
                        .WithMany()
                        .HasForeignKey("ServicesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DatabaseLayout.Models.HairStylist", b =>
                {
                    b.Navigation("HairStylistSalons");
                });

            modelBuilder.Entity("DatabaseLayout.Models.HairStylistSalon", b =>
                {
                    b.Navigation("HairStylistSalonServices");
                });

            modelBuilder.Entity("DatabaseLayout.Models.HairStylistSalonService", b =>
                {
                    b.Navigation("Appointments");
                });

            modelBuilder.Entity("DatabaseLayout.Models.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("DatabaseLayout.Models.Salon", b =>
                {
                    b.Navigation("Favorites");

                    b.Navigation("HairStylistSalons");

                    b.Navigation("SalonImages");

                    b.Navigation("WorkProgram")
                        .IsRequired();
                });

            modelBuilder.Entity("DatabaseLayout.Models.Service", b =>
                {
                    b.Navigation("HairStylistSalonServices");
                });

            modelBuilder.Entity("DatabaseLayout.Models.ServiceType", b =>
                {
                    b.Navigation("Services");
                });

            modelBuilder.Entity("DatabaseLayout.Models.User", b =>
                {
                    b.Navigation("Appointments");

                    b.Navigation("Favorites");
                });
#pragma warning restore 612, 618
        }
    }
}
