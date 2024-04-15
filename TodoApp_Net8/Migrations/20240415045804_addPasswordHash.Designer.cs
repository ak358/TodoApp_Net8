﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TodoApp_Net8.Data;

#nullable disable

namespace TodoApp_Net8.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240415045804_addPasswordHash")]
    partial class addPasswordHash
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TodoApp_Net8.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            RoleName = "administrator"
                        },
                        new
                        {
                            Id = 2,
                            RoleName = "user"
                        });
                });

            modelBuilder.Entity("TodoApp_Net8.Models.Todo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Detail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Done")
                        .HasColumnType("bit");

                    b.Property<DateTime>("Limit")
                        .HasColumnType("datetime2");

                    b.Property<string>("Summary")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Todoes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Detail = "This is the detail of Sample Todo 1",
                            Done = false,
                            Limit = new DateTime(2024, 4, 18, 13, 58, 3, 790, DateTimeKind.Local).AddTicks(8348),
                            Summary = "Sample Todo 1",
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            Detail = "This is the detail of Sample Todo 2",
                            Done = false,
                            Limit = new DateTime(2024, 4, 20, 13, 58, 3, 790, DateTimeKind.Local).AddTicks(8363),
                            Summary = "Sample Todo 2",
                            UserId = 2
                        });
                });

            modelBuilder.Entity("TodoApp_Net8.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Password = "h+wHM5ZK2BdwH60Ju2sKe3KOHR8+X7fQUvuwDgNaydo=",
                            RoleId = 1,
                            UserName = "admin"
                        },
                        new
                        {
                            Id = 2,
                            Password = "9gv6Hh1cCMGcXaV0qgVm7kN/6GD0iRhV4Rfj01sI1Ak=",
                            RoleId = 2,
                            UserName = "user"
                        });
                });

            modelBuilder.Entity("TodoApp_Net8.Models.Todo", b =>
                {
                    b.HasOne("TodoApp_Net8.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("TodoApp_Net8.Models.User", b =>
                {
                    b.HasOne("TodoApp_Net8.Models.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("TodoApp_Net8.Models.Role", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
