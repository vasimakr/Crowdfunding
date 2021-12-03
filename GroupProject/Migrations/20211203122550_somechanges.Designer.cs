﻿// <auto-generated />
using System;
using Crowdfunding.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Crowdfunding.Migrations
{
    [DbContext(typeof(FundRaiserContext))]
    [Migration("20211203122550_somechanges")]
    partial class somechanges
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Crowdfunding.Model.Backer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Backers");
                });

            modelBuilder.Entity("Crowdfunding.Model.BackerPackage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BackerId")
                        .HasColumnType("int");

                    b.Property<int?>("FundingPackageId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BackerId");

                    b.HasIndex("FundingPackageId");

                    b.ToTable("BackerPackages");
                });

            modelBuilder.Entity("Crowdfunding.Model.Creator", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Creators");
                });

            modelBuilder.Entity("Crowdfunding.Model.FundingPackage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<int?>("ProjectId")
                        .HasColumnType("int");

                    b.Property<int>("Tier")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.ToTable("FundingPackages");
                });

            modelBuilder.Entity("Crowdfunding.Model.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Category")
                        .HasColumnType("int");

                    b.Property<int?>("CreatorId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Fundings")
                        .HasColumnType("int");

                    b.Property<int>("Goal")
                        .HasColumnType("int");

                    b.Property<bool>("IsTrending")
                        .HasColumnType("bit");

                    b.Property<string>("StatusUpdate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CreatorId");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("Crowdfunding.Model.BackerPackage", b =>
                {
                    b.HasOne("Crowdfunding.Model.Backer", "Backer")
                        .WithMany("BackerPackages")
                        .HasForeignKey("BackerId");

                    b.HasOne("Crowdfunding.Model.FundingPackage", "FundingPackage")
                        .WithMany("BackerPackages")
                        .HasForeignKey("FundingPackageId");

                    b.Navigation("Backer");

                    b.Navigation("FundingPackage");
                });

            modelBuilder.Entity("Crowdfunding.Model.FundingPackage", b =>
                {
                    b.HasOne("Crowdfunding.Model.Project", "Project")
                        .WithMany("FundingPackages")
                        .HasForeignKey("ProjectId");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("Crowdfunding.Model.Project", b =>
                {
                    b.HasOne("Crowdfunding.Model.Creator", "Creator")
                        .WithMany("OwnedProjects")
                        .HasForeignKey("CreatorId");

                    b.Navigation("Creator");
                });

            modelBuilder.Entity("Crowdfunding.Model.Backer", b =>
                {
                    b.Navigation("BackerPackages");
                });

            modelBuilder.Entity("Crowdfunding.Model.Creator", b =>
                {
                    b.Navigation("OwnedProjects");
                });

            modelBuilder.Entity("Crowdfunding.Model.FundingPackage", b =>
                {
                    b.Navigation("BackerPackages");
                });

            modelBuilder.Entity("Crowdfunding.Model.Project", b =>
                {
                    b.Navigation("FundingPackages");
                });
#pragma warning restore 612, 618
        }
    }
}
