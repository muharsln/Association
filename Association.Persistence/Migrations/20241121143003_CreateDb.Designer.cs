﻿// <auto-generated />
using System;
using Association.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Association.Persistence.Migrations
{
    [DbContext(typeof(AssociationDbContext))]
    [Migration("20241121143003_CreateDb")]
    partial class CreateDb
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Association.Core.Entities.DonationCategory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Id");

                    b.Property<Guid>("DonationGroupId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("DonationGroupId");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit")
                        .HasColumnName("IsActive");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("Name");

                    b.HasKey("Id");

                    b.HasIndex("DonationGroupId");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("DonationCategories", (string)null);
                });

            modelBuilder.Entity("Association.Core.Entities.DonationForm", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Id");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("CreateDate");

                    b.Property<Guid>("DonationCategoryId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("DonationCategoryId");

                    b.Property<Guid>("DonorId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("DonorId");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("TotalPrice");

                    b.HasKey("Id");

                    b.HasIndex("DonationCategoryId");

                    b.HasIndex("DonorId");

                    b.ToTable("DonationForms", (string)null);
                });

            modelBuilder.Entity("Association.Core.Entities.DonationGroup", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Id");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit")
                        .HasColumnName("IsActive");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("Name");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("DonationGroups", (string)null);
                });

            modelBuilder.Entity("Association.Core.Entities.DonationOption", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Id");

                    b.Property<int>("Currency")
                        .HasColumnType("int")
                        .HasColumnName("Currency");

                    b.Property<Guid>("DonationCategoryId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("DonationCategoryId");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit")
                        .HasColumnName("IsActive");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("Name");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("Price");

                    b.Property<int>("Sequence")
                        .HasColumnType("int")
                        .HasColumnName("Sequence");

                    b.HasKey("Id");

                    b.HasIndex("DonationCategoryId");

                    b.HasIndex("Name");

                    b.ToTable("DonationOptions", (string)null);
                });

            modelBuilder.Entity("Association.Core.Entities.DonationShare", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Id");

                    b.Property<Guid>("DonationFormId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("DonationFormId");

                    b.Property<Guid>("DonationOptionId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("DonationOptionId");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("FirstName");

                    b.Property<Guid>("IntentionTypeId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("IntentionTypeId");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("LastName");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("Phone");

                    b.Property<decimal>("ShareAmount")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("ShareAmount");

                    b.HasKey("Id");

                    b.HasIndex("DonationFormId");

                    b.HasIndex("DonationOptionId");

                    b.HasIndex("IntentionTypeId");

                    b.ToTable("DonationShares", (string)null);
                });

            modelBuilder.Entity("Association.Core.Entities.Donor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Id");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Email");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit")
                        .HasColumnName("IsActive");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Location");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("Name");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)")
                        .HasColumnName("Phone");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("Surname");

                    b.HasKey("Id");

                    b.ToTable("Donors", (string)null);
                });

            modelBuilder.Entity("Association.Core.Entities.IntentionType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Id");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit")
                        .HasColumnName("IsActive");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("Name");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("IntentionTypes", (string)null);
                });

            modelBuilder.Entity("Association.Core.Entities.DonationCategory", b =>
                {
                    b.HasOne("Association.Core.Entities.DonationGroup", "DonationGroup")
                        .WithMany("DonationCategories")
                        .HasForeignKey("DonationGroupId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("DonationGroup");
                });

            modelBuilder.Entity("Association.Core.Entities.DonationForm", b =>
                {
                    b.HasOne("Association.Core.Entities.DonationCategory", "DonationCategory")
                        .WithMany("DonationForms")
                        .HasForeignKey("DonationCategoryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Association.Core.Entities.Donor", "Donor")
                        .WithMany("DonationForms")
                        .HasForeignKey("DonorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("DonationCategory");

                    b.Navigation("Donor");
                });

            modelBuilder.Entity("Association.Core.Entities.DonationOption", b =>
                {
                    b.HasOne("Association.Core.Entities.DonationCategory", "DonationCategory")
                        .WithMany("DonationOptions")
                        .HasForeignKey("DonationCategoryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("DonationCategory");
                });

            modelBuilder.Entity("Association.Core.Entities.DonationShare", b =>
                {
                    b.HasOne("Association.Core.Entities.DonationForm", "DonationForm")
                        .WithMany("DonationShares")
                        .HasForeignKey("DonationFormId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Association.Core.Entities.DonationOption", "DonationOption")
                        .WithMany("DonationShares")
                        .HasForeignKey("DonationOptionId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Association.Core.Entities.IntentionType", "IntentionType")
                        .WithMany("DonationShares")
                        .HasForeignKey("IntentionTypeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("DonationForm");

                    b.Navigation("DonationOption");

                    b.Navigation("IntentionType");
                });

            modelBuilder.Entity("Association.Core.Entities.DonationCategory", b =>
                {
                    b.Navigation("DonationForms");

                    b.Navigation("DonationOptions");
                });

            modelBuilder.Entity("Association.Core.Entities.DonationForm", b =>
                {
                    b.Navigation("DonationShares");
                });

            modelBuilder.Entity("Association.Core.Entities.DonationGroup", b =>
                {
                    b.Navigation("DonationCategories");
                });

            modelBuilder.Entity("Association.Core.Entities.DonationOption", b =>
                {
                    b.Navigation("DonationShares");
                });

            modelBuilder.Entity("Association.Core.Entities.Donor", b =>
                {
                    b.Navigation("DonationForms");
                });

            modelBuilder.Entity("Association.Core.Entities.IntentionType", b =>
                {
                    b.Navigation("DonationShares");
                });
#pragma warning restore 612, 618
        }
    }
}