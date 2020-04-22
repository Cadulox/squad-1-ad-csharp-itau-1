﻿// <auto-generated />
using System;
using ItaLog.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ItaLog.Data.Migrations
{
    [DbContext(typeof(ItaLogContext))]
    partial class ItaLogContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ItaLog.Domain.Models.ApiRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("ApiRole");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "User"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Administrator"
                        });
                });

            modelBuilder.Entity("ItaLog.Domain.Models.ApiUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(250)")
                        .HasMaxLength(250);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(250)")
                        .HasMaxLength(250);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("varchar(250)")
                        .HasMaxLength(250);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("varchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("varchar(250)")
                        .HasMaxLength(250);

                    b.Property<Guid>("UserToken")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("ApiUser");
                });

            modelBuilder.Entity("ItaLog.Domain.Models.ApiUserRole", b =>
                {
                    b.Property<int>("ApiUserId")
                        .HasColumnType("int");

                    b.Property<int>("ApiRoleId")
                        .HasColumnType("int");

                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("ApiUserId", "ApiRoleId");

                    b.HasIndex("ApiRoleId");

                    b.ToTable("ApiUserRole");
                });

            modelBuilder.Entity("ItaLog.Domain.Models.Environment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(20)")
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.ToTable("Environment");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Production"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Homologation"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Development"
                        });
                });

            modelBuilder.Entity("ItaLog.Domain.Models.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Archived")
                        .HasColumnType("bit");

                    b.Property<int>("EnvironmentId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ErrorDate")
                        .HasColumnType("datetime");

                    b.Property<int>("LogId")
                        .HasColumnType("int");

                    b.Property<string>("Origin")
                        .IsRequired()
                        .HasColumnType("varchar(20)")
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.HasIndex("EnvironmentId");

                    b.HasIndex("LogId");

                    b.ToTable("Event");
                });

            modelBuilder.Entity("ItaLog.Domain.Models.Level", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(20)")
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.ToTable("Level");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Debug"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Warning"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Error"
                        });
                });

            modelBuilder.Entity("ItaLog.Domain.Models.Log", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ApiUserId")
                        .HasColumnType("int");

                    b.Property<string>("Detail")
                        .IsRequired()
                        .HasColumnType("varchar(1024)")
                        .HasMaxLength(1024);

                    b.Property<int?>("EnvironmentId")
                        .HasColumnType("int");

                    b.Property<int>("LevelId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("varchar(250)")
                        .HasMaxLength(250);

                    b.Property<int>("UserErrorCode")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ApiUserId");

                    b.HasIndex("EnvironmentId");

                    b.HasIndex("LevelId");

                    b.ToTable("Log");
                });

            modelBuilder.Entity("ItaLog.Domain.Models.ApiUserRole", b =>
                {
                    b.HasOne("ItaLog.Domain.Models.ApiRole", "ApiRole")
                        .WithMany("UserRoles")
                        .HasForeignKey("ApiRoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ItaLog.Domain.Models.ApiUser", "ApiUser")
                        .WithMany("UserRoles")
                        .HasForeignKey("ApiUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ItaLog.Domain.Models.Event", b =>
                {
                    b.HasOne("ItaLog.Domain.Models.Environment", "Environment")
                        .WithMany()
                        .HasForeignKey("EnvironmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ItaLog.Domain.Models.Log", "Log")
                        .WithMany("Events")
                        .HasForeignKey("LogId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ItaLog.Domain.Models.Log", b =>
                {
                    b.HasOne("ItaLog.Domain.Models.ApiUser", "ApiUser")
                        .WithMany("Logs")
                        .HasForeignKey("ApiUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ItaLog.Domain.Models.Environment", null)
                        .WithMany("Logs")
                        .HasForeignKey("EnvironmentId");

                    b.HasOne("ItaLog.Domain.Models.Level", "Level")
                        .WithMany("Logs")
                        .HasForeignKey("LevelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
