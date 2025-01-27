﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace baroudeurs.Migrations
{
    [DbContext(typeof(baroudeursContext))]
    [Migration("20220113021026_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.1");

            modelBuilder.Entity("baroudeurs.Models.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("City", (string)null);
                });

            modelBuilder.Entity("baroudeurs.Models.Discovery", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("PointId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("TimeOfDiscovery")
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("PointId");

                    b.HasIndex("UserId");

                    b.ToTable("Discovery", (string)null);
                });

            modelBuilder.Entity("baroudeurs.Models.PointOfInterest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CityId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsEssential")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Latitude")
                        .HasColumnType("TEXT");

                    b.Property<string>("Longitude")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int>("PointType")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Theme")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("PointOfInterest", (string)null);
                });

            modelBuilder.Entity("baroudeurs.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("AccountCreation")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsOnline")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("LastConnection")
                        .HasColumnType("TEXT");

                    b.Property<string>("Username")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("baroudeurs.Models.Discovery", b =>
                {
                    b.HasOne("baroudeurs.Models.PointOfInterest", "Point")
                        .WithMany("Discoveries")
                        .HasForeignKey("PointId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("baroudeurs.Models.User", "User")
                        .WithMany("Discoveries")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Point");

                    b.Navigation("User");
                });

            modelBuilder.Entity("baroudeurs.Models.PointOfInterest", b =>
                {
                    b.HasOne("baroudeurs.Models.City", "City")
                        .WithMany("Points")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("baroudeurs.Models.City", b =>
                {
                    b.Navigation("Points");
                });

            modelBuilder.Entity("baroudeurs.Models.PointOfInterest", b =>
                {
                    b.Navigation("Discoveries");
                });

            modelBuilder.Entity("baroudeurs.Models.User", b =>
                {
                    b.Navigation("Discoveries");
                });
#pragma warning restore 612, 618
        }
    }
}
