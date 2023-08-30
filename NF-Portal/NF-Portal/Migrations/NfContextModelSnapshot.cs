﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NF_Portal.Data;

#nullable disable

namespace NF_Portal.Migrations
{
    [DbContext(typeof(NfContext))]
    partial class NfContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.21")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("NF_Portal.Models.NfEvent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("AdditionalDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("AdditionalInformation")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("Deadline")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("EventDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("IntroText")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("NfProgramId")
                        .HasColumnType("int");

                    b.Property<string>("Person")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("NfProgramId");

                    b.ToTable("NfEvent");
                });

            modelBuilder.Entity("NF_Portal.Models.NfProgram", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("From")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("To")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("NfPrograms");
                });

            modelBuilder.Entity("NF_Portal.Models.NfEvent", b =>
                {
                    b.HasOne("NF_Portal.Models.NfProgram", null)
                        .WithMany("NfEvents")
                        .HasForeignKey("NfProgramId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("NF_Portal.Models.NfProgram", b =>
                {
                    b.Navigation("NfEvents");
                });
#pragma warning restore 612, 618
        }
    }
}
