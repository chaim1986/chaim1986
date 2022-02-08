﻿// <auto-generated />
using System;
using Elections.Persistenc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Elections.Migrations
{
    [DbContext(typeof(ElectionDbContext))]
    [Migration("20211228095803_updatevoters")]
    partial class updatevoters
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Elections.Models.Area", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("ElectionId")
                        .HasColumnType("int");

                    b.Property<string>("NameOfArea")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ElectionId");

                    b.ToTable("Areas");
                });

            modelBuilder.Entity("Elections.Models.Election", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsOpen")
                        .HasColumnType("bit");

                    b.Property<bool>("Ischangeable")
                        .HasColumnType("bit");

                    b.Property<int>("ManegerUserId")
                        .HasColumnType("int");

                    b.Property<string>("NameOfTheElection")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("userManagerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("userManagerId");

                    b.ToTable("Elections");
                });

            modelBuilder.Entity("Elections.Models.Fault", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("AreaId")
                        .HasColumnType("int");

                    b.Property<string>("Despriction")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ElectionId")
                        .HasColumnType("int");

                    b.Property<bool>("IsOpen")
                        .HasColumnType("bit");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AreaId");

                    b.HasIndex("ElectionId");

                    b.ToTable("Faults");
                });

            modelBuilder.Entity("Elections.Models.OptionToVote", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("CandidateOrPartyName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ElectionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ElectionId");

                    b.ToTable("OptionToVotes");
                });

            modelBuilder.Entity("Elections.Models.Reply", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FaultId")
                        .HasColumnType("int");

                    b.Property<int>("UserInspectorId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FaultId");

                    b.HasIndex("UserInspectorId");

                    b.ToTable("Replies");
                });

            modelBuilder.Entity("Elections.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmailAdress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsManager")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Elections.Models.Voter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<bool>("AlreadyVoted")
                        .HasColumnType("bit");

                    b.Property<int>("ElectionId")
                        .HasColumnType("int");

                    b.Property<bool>("IsInspector")
                        .HasColumnType("bit");

                    b.Property<int>("OptionToVoteIdNumber")
                        .HasColumnType("int");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ElectionId");

                    b.ToTable("Voters");
                });

            modelBuilder.Entity("Elections.Models.Area", b =>
                {
                    b.HasOne("Elections.Models.Election", "Election")
                        .WithMany("Areas")
                        .HasForeignKey("ElectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Election");
                });

            modelBuilder.Entity("Elections.Models.Election", b =>
                {
                    b.HasOne("Elections.Models.User", "userManager")
                        .WithMany()
                        .HasForeignKey("userManagerId");

                    b.Navigation("userManager");
                });

            modelBuilder.Entity("Elections.Models.Fault", b =>
                {
                    b.HasOne("Elections.Models.Area", "Area")
                        .WithMany()
                        .HasForeignKey("AreaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Elections.Models.Election", "Election")
                        .WithMany("Faults")
                        .HasForeignKey("ElectionId");

                    b.Navigation("Area");

                    b.Navigation("Election");
                });

            modelBuilder.Entity("Elections.Models.OptionToVote", b =>
                {
                    b.HasOne("Elections.Models.Election", "Election")
                        .WithMany("optionToVotes")
                        .HasForeignKey("ElectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Election");
                });

            modelBuilder.Entity("Elections.Models.Reply", b =>
                {
                    b.HasOne("Elections.Models.Fault", "Fault")
                        .WithMany("Replies")
                        .HasForeignKey("FaultId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Elections.Models.User", "UserInspector")
                        .WithMany()
                        .HasForeignKey("UserInspectorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Fault");

                    b.Navigation("UserInspector");
                });

            modelBuilder.Entity("Elections.Models.Voter", b =>
                {
                    b.HasOne("Elections.Models.Election", "Election")
                        .WithMany("Voters")
                        .HasForeignKey("ElectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Election");
                });

            modelBuilder.Entity("Elections.Models.Election", b =>
                {
                    b.Navigation("Areas");

                    b.Navigation("Faults");

                    b.Navigation("optionToVotes");

                    b.Navigation("Voters");
                });

            modelBuilder.Entity("Elections.Models.Fault", b =>
                {
                    b.Navigation("Replies");
                });
#pragma warning restore 612, 618
        }
    }
}
