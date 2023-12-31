﻿// <auto-generated />
using System;
using CoronaStatsAustria.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CoronaStatsAustria.Migrations
{
    [DbContext(typeof(CovidDataContext))]
    partial class CovidDataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CoronaStatsAustria.Models.CovidStats", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CovidCasesNumber")
                        .HasColumnType("int");

                    b.Property<int>("CovidDeathsNumber")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateOfImport")
                        .HasColumnType("datetime2");

                    b.Property<int>("DistrictId")
                        .HasColumnType("int");

                    b.Property<int>("DistrictPopulation")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DistrictId")
                        .IsUnique();

                    b.ToTable("CovidStatistics");
                });

            modelBuilder.Entity("CoronaStatsAustria.Models.District", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Code")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int>("StateId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StateId");

                    b.ToTable("Districts");
                });

            modelBuilder.Entity("CoronaStatsAustria.Models.FederalState", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("Id");

                    b.ToTable("States");
                });

            modelBuilder.Entity("CoronaStatsAustria.Models.CovidStats", b =>
                {
                    b.HasOne("CoronaStatsAustria.Models.District", "District")
                        .WithOne("CovidStatistics")
                        .HasForeignKey("CoronaStatsAustria.Models.CovidStats", "DistrictId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("District");
                });

            modelBuilder.Entity("CoronaStatsAustria.Models.District", b =>
                {
                    b.HasOne("CoronaStatsAustria.Models.FederalState", "State")
                        .WithMany("Districts")
                        .HasForeignKey("StateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("State");
                });

            modelBuilder.Entity("CoronaStatsAustria.Models.District", b =>
                {
                    b.Navigation("CovidStatistics")
                        .IsRequired();
                });

            modelBuilder.Entity("CoronaStatsAustria.Models.FederalState", b =>
                {
                    b.Navigation("Districts");
                });
#pragma warning restore 612, 618
        }
    }
}
