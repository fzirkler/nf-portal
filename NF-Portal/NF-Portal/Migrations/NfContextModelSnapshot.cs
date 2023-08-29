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

            modelBuilder.Entity("NF_Portal.Models.Programm", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Bezeichnung")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("Bis")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("Von")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("Programme");
                });

            modelBuilder.Entity("NF_Portal.Models.Veranstaltung", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("Anmeldeschluss")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Auskunftsperson")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Bemerkung")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Beschreibung")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("Ersatztermin")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("IntroText")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("ProgrammId")
                        .HasColumnType("int");

                    b.Property<string>("Telefon")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("Termin")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Treffpunkt")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("ProgrammId");

                    b.ToTable("Veranstaltungen");
                });

            modelBuilder.Entity("NF_Portal.Models.Veranstaltung", b =>
                {
                    b.HasOne("NF_Portal.Models.Programm", "Programm")
                        .WithMany("Veranstaltungen")
                        .HasForeignKey("ProgrammId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Programm");
                });

            modelBuilder.Entity("NF_Portal.Models.Programm", b =>
                {
                    b.Navigation("Veranstaltungen");
                });
#pragma warning restore 612, 618
        }
    }
}
