﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NotelyCore.Persistence;

namespace NotelyCore.Persistence.Migrations
{
    [DbContext(typeof(NotelyCoreDbContext))]
    [Migration("20190725111049_EnumIntConversion")]
    partial class EnumIntConversion
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("NotelyCore.Domain.Identity.NotelyUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<string>("FirstName")
                        .HasMaxLength(32);

                    b.Property<string>("LastName")
                        .HasMaxLength(32);

                    b.Property<string>("MiddleInitial")
                        .HasMaxLength(1);

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasMaxLength(1024);

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("NotelyCore.Domain.Identity.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("NotelyCore.Domain.Identity.UserRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("RoleId");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("UserRole");
                });

            modelBuilder.Entity("NotelyCore.Domain.Note", b =>
                {
                    b.Property<int>("NoteId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Body");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<DateTime?>("ModifiedOn");

                    b.Property<int>("Priority");

                    b.Property<string>("Subject");

                    b.Property<int?>("UserId");

                    b.HasKey("NoteId");

                    b.HasIndex("UserId");

                    b.ToTable("Notes");

                    b.HasData(
                        new
                        {
                            NoteId = 1,
                            Body = "Body 1",
                            CreatedOn = new DateTime(2019, 7, 25, 14, 10, 49, 407, DateTimeKind.Local).AddTicks(1431),
                            Priority = 2,
                            Subject = "Note 1"
                        },
                        new
                        {
                            NoteId = 2,
                            Body = "Body 2",
                            CreatedOn = new DateTime(2019, 7, 25, 14, 10, 49, 407, DateTimeKind.Local).AddTicks(9619),
                            Priority = 1,
                            Subject = "Note 2"
                        },
                        new
                        {
                            NoteId = 3,
                            Body = "Body 3",
                            CreatedOn = new DateTime(2019, 7, 25, 14, 10, 49, 407, DateTimeKind.Local).AddTicks(9629),
                            Priority = 0,
                            Subject = "Note 3"
                        });
                });

            modelBuilder.Entity("NotelyCore.Domain.Identity.UserRole", b =>
                {
                    b.HasOne("NotelyCore.Domain.Identity.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("NotelyCore.Domain.Identity.NotelyUser", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("NotelyCore.Domain.Note", b =>
                {
                    b.HasOne("NotelyCore.Domain.Identity.NotelyUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });
#pragma warning restore 612, 618
        }
    }
}