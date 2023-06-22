﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistence;

namespace Persistence.Migrations
{
    [DbContext(typeof(DataBaceContext))]
    partial class DataBaceContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Domain.Coach.BisnesCoachs", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CoachsId")
                        .HasColumnType("int");

                    b.Property<int>("UsersId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CoachsId");

                    b.HasIndex("UsersId");

                    b.ToTable("BisnesCoachs");
                });

            modelBuilder.Entity("Domain.Coach.Coachs", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsRemoved")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Coachs");
                });

            modelBuilder.Entity("Domain.Coach.Image", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CoachsId")
                        .HasColumnType("int");

                    b.Property<string>("Src")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CoachsId")
                        .IsUnique();

                    b.ToTable("Image");
                });

            modelBuilder.Entity("Domain.Dates.DatesDrivigs", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CoachsId")
                        .HasColumnType("int");

                    b.Property<DateTime>("End")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsRemoved")
                        .HasColumnType("bit");

                    b.Property<DateTime>("Start")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("CoachsId");

                    b.ToTable("DatesDrivigs");
                });

            modelBuilder.Entity("Domain.User.BisnesUsers", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DatesDrivigsId")
                        .HasColumnType("int");

                    b.Property<bool>("StatusAiname")
                        .HasColumnType("bit");

                    b.Property<bool>("StatusAmali")
                        .HasColumnType("bit");

                    b.Property<bool>("StatusLerningAiname")
                        .HasColumnType("bit");

                    b.Property<bool>("StatusLerningAmali")
                        .HasColumnType("bit");

                    b.Property<int>("UsersId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DatesDrivigsId");

                    b.HasIndex("UsersId")
                        .IsUnique();

                    b.ToTable("BisnesUsers");
                });

            modelBuilder.Entity("Domain.User.Users", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CodeMeli")
                        .HasColumnType("int");

                    b.Property<string>("Family")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsRemoved")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("StatosCoachs")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Domain.Coach.BisnesCoachs", b =>
                {
                    b.HasOne("Domain.Coach.Coachs", "Coachs")
                        .WithMany("BisnesCoachs")
                        .HasForeignKey("CoachsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.User.Users", "Users")
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Coachs");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("Domain.Coach.Image", b =>
                {
                    b.HasOne("Domain.Coach.Coachs", "Coachs")
                        .WithOne("Image")
                        .HasForeignKey("Domain.Coach.Image", "CoachsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Coachs");
                });

            modelBuilder.Entity("Domain.Dates.DatesDrivigs", b =>
                {
                    b.HasOne("Domain.Coach.Coachs", "Coachs")
                        .WithMany()
                        .HasForeignKey("CoachsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Coachs");
                });

            modelBuilder.Entity("Domain.User.BisnesUsers", b =>
                {
                    b.HasOne("Domain.Dates.DatesDrivigs", "DatesDrivigs")
                        .WithMany()
                        .HasForeignKey("DatesDrivigsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.User.Users", "Users")
                        .WithOne("BisnesUsers")
                        .HasForeignKey("Domain.User.BisnesUsers", "UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DatesDrivigs");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("Domain.Coach.Coachs", b =>
                {
                    b.Navigation("BisnesCoachs");

                    b.Navigation("Image");
                });

            modelBuilder.Entity("Domain.User.Users", b =>
                {
                    b.Navigation("BisnesUsers");
                });
#pragma warning restore 612, 618
        }
    }
}
