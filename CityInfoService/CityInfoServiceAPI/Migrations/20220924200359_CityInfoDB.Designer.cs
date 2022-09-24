﻿// <auto-generated />
using CityInfoServiceAPI.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CityInfoServiceAPI.Migrations
{
    [DbContext(typeof(CityInfoContext))]
    [Migration("20220924200359_CityInfoDB")]
    partial class CityInfoDB
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.9");

            modelBuilder.Entity("CityInfoServiceAPI.Entities.City", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("description")
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("CityInfoServiceAPI.Entities.PointOfInterest", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CityId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.HasIndex("CityId");

                    b.ToTable("PointsOfInterests");
                });

            modelBuilder.Entity("CityInfoServiceAPI.Entities.PointOfInterest", b =>
                {
                    b.HasOne("CityInfoServiceAPI.Entities.City", "city")
                        .WithMany("pointsOfInterest")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("city");
                });

            modelBuilder.Entity("CityInfoServiceAPI.Entities.City", b =>
                {
                    b.Navigation("pointsOfInterest");
                });
#pragma warning restore 612, 618
        }
    }
}
