﻿// <auto-generated />
using System;
using DotNetStarter.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DotNetStarter.Migrations
{
    [DbContext(typeof(DotNetStarterDbContext))]
    [Migration("20231011090107_AddCards")]
    partial class AddCards
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DotNetStarter.Entities.AuthToken", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ExpiredDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsUsed")
                        .HasColumnType("bit");

                    b.Property<string>("Secret")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("TokenId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AuthTokens");
                });

            modelBuilder.Entity("DotNetStarter.Entities.Card", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("NextCardId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("PrevCardId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("StageId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("NextCardId");

                    b.HasIndex("StageId");

                    b.HasIndex("PrevCardId", "NextCardId")
                        .IsUnique()
                        .HasFilter("[PrevCardId] IS NOT NULL AND [NextCardId] IS NOT NULL");

                    b.ToTable("Cards", t =>
                        {
                            t.HasCheckConstraint("CK_Prev_Next_Not_Equal", "[PrevCardId] <> [NextCardId]");
                        });
                });

            modelBuilder.Entity("DotNetStarter.Entities.Otp", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ExpiredDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsUsed")
                        .HasColumnType("bit");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<string>("UpdatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Otps");
                });

            modelBuilder.Entity("DotNetStarter.Entities.Privilege", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Privileges");

                    b.HasData(
                        new
                        {
                            Id = new Guid("a79f4031-3902-47ac-bbf9-252c665a6b94"),
                            Name = "VIEW_STAFF_MEMBERS"
                        },
                        new
                        {
                            Id = new Guid("9b93570a-bb7b-43ff-b46c-bb74dff4c17e"),
                            Name = "CREATE_STAFF_MEMBERS"
                        },
                        new
                        {
                            Id = new Guid("c38fa488-ad8f-4821-a869-f2be2ff2dcc5"),
                            Name = "UPDATE_STAFF_MEMBERS"
                        },
                        new
                        {
                            Id = new Guid("549eec1c-c4b5-41ae-944b-f5398fbb1106"),
                            Name = "DELETE_STAFF_MEMBERS"
                        },
                        new
                        {
                            Id = new Guid("cac3bf78-86a7-4255-9ed1-36a3cd89f1e9"),
                            Name = "VIEW_TALENTS"
                        },
                        new
                        {
                            Id = new Guid("50817957-ef43-4393-b1a4-d557dc936daa"),
                            Name = "CREATE_TALENTS"
                        },
                        new
                        {
                            Id = new Guid("a9bedfe8-2813-465f-acd8-eadc61519e4d"),
                            Name = "UPDATE_TALENTS"
                        },
                        new
                        {
                            Id = new Guid("183bc93e-89f7-41b0-9948-724194af2302"),
                            Name = "DELETE_TALENTS"
                        },
                        new
                        {
                            Id = new Guid("0eefd2b0-d280-4ee7-906d-0baa3dcd0c88"),
                            Name = "VIEW_PROJECTS"
                        },
                        new
                        {
                            Id = new Guid("82bc464a-0d13-482e-97a7-7237a37e94c2"),
                            Name = "CREATE_PROJECTS"
                        },
                        new
                        {
                            Id = new Guid("1e63d635-ecb8-4f3e-972e-14e932fab8c0"),
                            Name = "UPDATE_PROJECTS"
                        },
                        new
                        {
                            Id = new Guid("e46fc4b7-c5ac-499d-80f1-1a983e672839"),
                            Name = "DELETE_PROJECTS"
                        },
                        new
                        {
                            Id = new Guid("c22a378a-feb2-4a97-82b9-3b0a0588ddcd"),
                            Name = "VIEW_CARDS"
                        },
                        new
                        {
                            Id = new Guid("36b6bbda-3c16-47a7-8353-88fd19eaf2e1"),
                            Name = "CREATE_CARDS"
                        },
                        new
                        {
                            Id = new Guid("9a1edd05-bd24-462e-9754-534ec573745f"),
                            Name = "UPDATE_CARDS"
                        },
                        new
                        {
                            Id = new Guid("9b07b2fd-259c-43bf-9a5d-715945b23414"),
                            Name = "DELETE_CARDS"
                        },
                        new
                        {
                            Id = new Guid("78416000-2b67-4b1f-89e7-3dbe3fd726b7"),
                            Name = "INVITE_TALENTS"
                        },
                        new
                        {
                            Id = new Guid("9483ac95-4f7a-4b5a-93cf-636a230a662d"),
                            Name = "REMOVE_TALENTS_FROM_PROJECT"
                        },
                        new
                        {
                            Id = new Guid("6deeccfd-7c92-4699-bbae-de86f83f6237"),
                            Name = "CREATE_PAYMENTS"
                        },
                        new
                        {
                            Id = new Guid("0636175f-b650-4d48-a5e3-37f08b394b45"),
                            Name = "UPDATE_PAYMENTS"
                        },
                        new
                        {
                            Id = new Guid("5b665dc9-28a0-451f-af9d-05fdd64ac704"),
                            Name = "ACCEPT_PAYMENTS"
                        },
                        new
                        {
                            Id = new Guid("ea6706b9-32a3-4a17-ab7f-0598c87b522b"),
                            Name = "FINALIZE_PAYMENTS"
                        },
                        new
                        {
                            Id = new Guid("3e4d6b17-c11b-64b5-0036-a1fe8f9c269d"),
                            Name = "VIEW_STAGES"
                        },
                        new
                        {
                            Id = new Guid("5bc6b4f4-98e1-1e39-8aa6-4693ad11437e"),
                            Name = "UPDATE_STAGES"
                        });
                });

            modelBuilder.Entity("DotNetStarter.Entities.Project", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AgencyMemberId")
                        .IsRequired()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("ProjectManagerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("UpdatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("AgencyMemberId");

                    b.HasIndex("ProjectManagerId");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("DotNetStarter.Entities.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = new Guid("364dfceb-7779-4190-a5bc-2bd4aba39af4"),
                            Name = "ADMINISTRATOR"
                        },
                        new
                        {
                            Id = new Guid("2fa87016-bafe-44f7-b4b3-d41fb0f0e202"),
                            Name = "PROJECT_MANAGER"
                        },
                        new
                        {
                            Id = new Guid("e73f1844-04be-4d7f-8e6e-65a1a20b2a83"),
                            Name = "AGENCY_MEMBER"
                        },
                        new
                        {
                            Id = new Guid("36a36642-44db-4e8d-8cc8-adc387d73150"),
                            Name = "TALENT"
                        });
                });

            modelBuilder.Entity("DotNetStarter.Entities.RolePrivilege", b =>
                {
                    b.Property<Guid?>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("PrivilegeId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("RoleId", "PrivilegeId");

                    b.HasIndex("PrivilegeId");

                    b.ToTable("RolePrivileges");

                    b.HasData(
                        new
                        {
                            RoleId = new Guid("364dfceb-7779-4190-a5bc-2bd4aba39af4"),
                            PrivilegeId = new Guid("a79f4031-3902-47ac-bbf9-252c665a6b94")
                        },
                        new
                        {
                            RoleId = new Guid("364dfceb-7779-4190-a5bc-2bd4aba39af4"),
                            PrivilegeId = new Guid("9b93570a-bb7b-43ff-b46c-bb74dff4c17e")
                        },
                        new
                        {
                            RoleId = new Guid("364dfceb-7779-4190-a5bc-2bd4aba39af4"),
                            PrivilegeId = new Guid("c38fa488-ad8f-4821-a869-f2be2ff2dcc5")
                        },
                        new
                        {
                            RoleId = new Guid("364dfceb-7779-4190-a5bc-2bd4aba39af4"),
                            PrivilegeId = new Guid("549eec1c-c4b5-41ae-944b-f5398fbb1106")
                        },
                        new
                        {
                            RoleId = new Guid("364dfceb-7779-4190-a5bc-2bd4aba39af4"),
                            PrivilegeId = new Guid("cac3bf78-86a7-4255-9ed1-36a3cd89f1e9")
                        },
                        new
                        {
                            RoleId = new Guid("364dfceb-7779-4190-a5bc-2bd4aba39af4"),
                            PrivilegeId = new Guid("50817957-ef43-4393-b1a4-d557dc936daa")
                        },
                        new
                        {
                            RoleId = new Guid("364dfceb-7779-4190-a5bc-2bd4aba39af4"),
                            PrivilegeId = new Guid("a9bedfe8-2813-465f-acd8-eadc61519e4d")
                        },
                        new
                        {
                            RoleId = new Guid("364dfceb-7779-4190-a5bc-2bd4aba39af4"),
                            PrivilegeId = new Guid("183bc93e-89f7-41b0-9948-724194af2302")
                        },
                        new
                        {
                            RoleId = new Guid("2fa87016-bafe-44f7-b4b3-d41fb0f0e202"),
                            PrivilegeId = new Guid("cac3bf78-86a7-4255-9ed1-36a3cd89f1e9")
                        },
                        new
                        {
                            RoleId = new Guid("2fa87016-bafe-44f7-b4b3-d41fb0f0e202"),
                            PrivilegeId = new Guid("78416000-2b67-4b1f-89e7-3dbe3fd726b7")
                        },
                        new
                        {
                            RoleId = new Guid("2fa87016-bafe-44f7-b4b3-d41fb0f0e202"),
                            PrivilegeId = new Guid("9483ac95-4f7a-4b5a-93cf-636a230a662d")
                        },
                        new
                        {
                            RoleId = new Guid("2fa87016-bafe-44f7-b4b3-d41fb0f0e202"),
                            PrivilegeId = new Guid("0eefd2b0-d280-4ee7-906d-0baa3dcd0c88")
                        },
                        new
                        {
                            RoleId = new Guid("2fa87016-bafe-44f7-b4b3-d41fb0f0e202"),
                            PrivilegeId = new Guid("1e63d635-ecb8-4f3e-972e-14e932fab8c0")
                        },
                        new
                        {
                            RoleId = new Guid("2fa87016-bafe-44f7-b4b3-d41fb0f0e202"),
                            PrivilegeId = new Guid("c22a378a-feb2-4a97-82b9-3b0a0588ddcd")
                        },
                        new
                        {
                            RoleId = new Guid("2fa87016-bafe-44f7-b4b3-d41fb0f0e202"),
                            PrivilegeId = new Guid("36b6bbda-3c16-47a7-8353-88fd19eaf2e1")
                        },
                        new
                        {
                            RoleId = new Guid("2fa87016-bafe-44f7-b4b3-d41fb0f0e202"),
                            PrivilegeId = new Guid("9a1edd05-bd24-462e-9754-534ec573745f")
                        },
                        new
                        {
                            RoleId = new Guid("2fa87016-bafe-44f7-b4b3-d41fb0f0e202"),
                            PrivilegeId = new Guid("9b07b2fd-259c-43bf-9a5d-715945b23414")
                        },
                        new
                        {
                            RoleId = new Guid("2fa87016-bafe-44f7-b4b3-d41fb0f0e202"),
                            PrivilegeId = new Guid("ea6706b9-32a3-4a17-ab7f-0598c87b522b")
                        },
                        new
                        {
                            RoleId = new Guid("2fa87016-bafe-44f7-b4b3-d41fb0f0e202"),
                            PrivilegeId = new Guid("3e4d6b17-c11b-64b5-0036-a1fe8f9c269d")
                        },
                        new
                        {
                            RoleId = new Guid("2fa87016-bafe-44f7-b4b3-d41fb0f0e202"),
                            PrivilegeId = new Guid("5bc6b4f4-98e1-1e39-8aa6-4693ad11437e")
                        },
                        new
                        {
                            RoleId = new Guid("e73f1844-04be-4d7f-8e6e-65a1a20b2a83"),
                            PrivilegeId = new Guid("cac3bf78-86a7-4255-9ed1-36a3cd89f1e9")
                        },
                        new
                        {
                            RoleId = new Guid("e73f1844-04be-4d7f-8e6e-65a1a20b2a83"),
                            PrivilegeId = new Guid("78416000-2b67-4b1f-89e7-3dbe3fd726b7")
                        },
                        new
                        {
                            RoleId = new Guid("e73f1844-04be-4d7f-8e6e-65a1a20b2a83"),
                            PrivilegeId = new Guid("9483ac95-4f7a-4b5a-93cf-636a230a662d")
                        },
                        new
                        {
                            RoleId = new Guid("e73f1844-04be-4d7f-8e6e-65a1a20b2a83"),
                            PrivilegeId = new Guid("5b665dc9-28a0-451f-af9d-05fdd64ac704")
                        },
                        new
                        {
                            RoleId = new Guid("e73f1844-04be-4d7f-8e6e-65a1a20b2a83"),
                            PrivilegeId = new Guid("0eefd2b0-d280-4ee7-906d-0baa3dcd0c88")
                        },
                        new
                        {
                            RoleId = new Guid("e73f1844-04be-4d7f-8e6e-65a1a20b2a83"),
                            PrivilegeId = new Guid("82bc464a-0d13-482e-97a7-7237a37e94c2")
                        },
                        new
                        {
                            RoleId = new Guid("e73f1844-04be-4d7f-8e6e-65a1a20b2a83"),
                            PrivilegeId = new Guid("1e63d635-ecb8-4f3e-972e-14e932fab8c0")
                        },
                        new
                        {
                            RoleId = new Guid("e73f1844-04be-4d7f-8e6e-65a1a20b2a83"),
                            PrivilegeId = new Guid("e46fc4b7-c5ac-499d-80f1-1a983e672839")
                        },
                        new
                        {
                            RoleId = new Guid("e73f1844-04be-4d7f-8e6e-65a1a20b2a83"),
                            PrivilegeId = new Guid("a79f4031-3902-47ac-bbf9-252c665a6b94")
                        },
                        new
                        {
                            RoleId = new Guid("36a36642-44db-4e8d-8cc8-adc387d73150"),
                            PrivilegeId = new Guid("0eefd2b0-d280-4ee7-906d-0baa3dcd0c88")
                        },
                        new
                        {
                            RoleId = new Guid("36a36642-44db-4e8d-8cc8-adc387d73150"),
                            PrivilegeId = new Guid("6deeccfd-7c92-4699-bbae-de86f83f6237")
                        },
                        new
                        {
                            RoleId = new Guid("36a36642-44db-4e8d-8cc8-adc387d73150"),
                            PrivilegeId = new Guid("0636175f-b650-4d48-a5e3-37f08b394b45")
                        },
                        new
                        {
                            RoleId = new Guid("36a36642-44db-4e8d-8cc8-adc387d73150"),
                            PrivilegeId = new Guid("c22a378a-feb2-4a97-82b9-3b0a0588ddcd")
                        },
                        new
                        {
                            RoleId = new Guid("36a36642-44db-4e8d-8cc8-adc387d73150"),
                            PrivilegeId = new Guid("36b6bbda-3c16-47a7-8353-88fd19eaf2e1")
                        },
                        new
                        {
                            RoleId = new Guid("36a36642-44db-4e8d-8cc8-adc387d73150"),
                            PrivilegeId = new Guid("9a1edd05-bd24-462e-9754-534ec573745f")
                        },
                        new
                        {
                            RoleId = new Guid("36a36642-44db-4e8d-8cc8-adc387d73150"),
                            PrivilegeId = new Guid("9b07b2fd-259c-43bf-9a5d-715945b23414")
                        },
                        new
                        {
                            RoleId = new Guid("36a36642-44db-4e8d-8cc8-adc387d73150"),
                            PrivilegeId = new Guid("3e4d6b17-c11b-64b5-0036-a1fe8f9c269d")
                        });
                });

            modelBuilder.Entity("DotNetStarter.Entities.Stage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Order")
                        .HasColumnType("int");

                    b.Property<Guid?>("ProjectId")
                        .IsRequired()
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId", "Name")
                        .IsUnique();

                    b.HasIndex("ProjectId", "Order")
                        .IsUnique();

                    b.ToTable("Stages");
                });

            modelBuilder.Entity("DotNetStarter.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(450)");

                    b.Property<Guid?>("RoleId")
                        .IsRequired()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("UpdatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("PhoneNumber")
                        .IsUnique()
                        .HasFilter("[PhoneNumber] IS NOT NULL");

                    b.HasIndex("RoleId");

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("Users");

                    b.UseTptMappingStrategy();

                    b.HasData(
                        new
                        {
                            Id = new Guid("a3edc636-8153-42af-85a1-65dac56cded7"),
                            CreatedBy = "System",
                            CreatedDate = new DateTime(2023, 9, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Firstname = "Admin",
                            Gender = 1,
                            Lastname = "Yopmail",
                            Password = "$2a$11$61sJj9Y7idWPUoWTysZ81u7B0veE3dPhfdPGIJbi.TB0r/NtgR0k2",
                            PhoneNumber = "0333333333",
                            RoleId = new Guid("364dfceb-7779-4190-a5bc-2bd4aba39af4"),
                            Status = 0,
                            UpdatedBy = "System",
                            UpdatedDate = new DateTime(2023, 9, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Username = "admin.dotnetstarter@yopmail.com"
                        });
                });

            modelBuilder.Entity("DotNetStarter.Entities.UserPrivilege", b =>
                {
                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("PrivilegeId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "PrivilegeId");

                    b.HasIndex("PrivilegeId");

                    b.ToTable("UserPrivileges");

                    b.HasData(
                        new
                        {
                            UserId = new Guid("a3edc636-8153-42af-85a1-65dac56cded7"),
                            PrivilegeId = new Guid("a79f4031-3902-47ac-bbf9-252c665a6b94")
                        },
                        new
                        {
                            UserId = new Guid("a3edc636-8153-42af-85a1-65dac56cded7"),
                            PrivilegeId = new Guid("9b93570a-bb7b-43ff-b46c-bb74dff4c17e")
                        },
                        new
                        {
                            UserId = new Guid("a3edc636-8153-42af-85a1-65dac56cded7"),
                            PrivilegeId = new Guid("c38fa488-ad8f-4821-a869-f2be2ff2dcc5")
                        },
                        new
                        {
                            UserId = new Guid("a3edc636-8153-42af-85a1-65dac56cded7"),
                            PrivilegeId = new Guid("549eec1c-c4b5-41ae-944b-f5398fbb1106")
                        },
                        new
                        {
                            UserId = new Guid("a3edc636-8153-42af-85a1-65dac56cded7"),
                            PrivilegeId = new Guid("cac3bf78-86a7-4255-9ed1-36a3cd89f1e9")
                        },
                        new
                        {
                            UserId = new Guid("a3edc636-8153-42af-85a1-65dac56cded7"),
                            PrivilegeId = new Guid("50817957-ef43-4393-b1a4-d557dc936daa")
                        },
                        new
                        {
                            UserId = new Guid("a3edc636-8153-42af-85a1-65dac56cded7"),
                            PrivilegeId = new Guid("a9bedfe8-2813-465f-acd8-eadc61519e4d")
                        },
                        new
                        {
                            UserId = new Guid("a3edc636-8153-42af-85a1-65dac56cded7"),
                            PrivilegeId = new Guid("183bc93e-89f7-41b0-9948-724194af2302")
                        });
                });

            modelBuilder.Entity("DotNetStarter.Entities.Talent", b =>
                {
                    b.HasBaseType("DotNetStarter.Entities.User");

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("bit");

                    b.ToTable("Talents", null, t =>
                        {
                            t.Property("Id")
                                .HasColumnName("TalentId");
                        });
                });

            modelBuilder.Entity("DotNetStarter.Entities.AuthToken", b =>
                {
                    b.HasOne("DotNetStarter.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("DotNetStarter.Entities.Card", b =>
                {
                    b.HasOne("DotNetStarter.Entities.Card", "NextCard")
                        .WithMany()
                        .HasForeignKey("NextCardId");

                    b.HasOne("DotNetStarter.Entities.Card", "PrevCard")
                        .WithMany()
                        .HasForeignKey("PrevCardId");

                    b.HasOne("DotNetStarter.Entities.Stage", "Stage")
                        .WithMany("Cards")
                        .HasForeignKey("StageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("NextCard");

                    b.Navigation("PrevCard");

                    b.Navigation("Stage");
                });

            modelBuilder.Entity("DotNetStarter.Entities.Otp", b =>
                {
                    b.HasOne("DotNetStarter.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("DotNetStarter.Entities.Project", b =>
                {
                    b.HasOne("DotNetStarter.Entities.User", "AgencyMember")
                        .WithMany()
                        .HasForeignKey("AgencyMemberId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DotNetStarter.Entities.User", "ProjectManager")
                        .WithMany()
                        .HasForeignKey("ProjectManagerId");

                    b.Navigation("AgencyMember");

                    b.Navigation("ProjectManager");
                });

            modelBuilder.Entity("DotNetStarter.Entities.RolePrivilege", b =>
                {
                    b.HasOne("DotNetStarter.Entities.Privilege", "Privilege")
                        .WithMany()
                        .HasForeignKey("PrivilegeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DotNetStarter.Entities.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Privilege");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("DotNetStarter.Entities.Stage", b =>
                {
                    b.HasOne("DotNetStarter.Entities.Project", "Project")
                        .WithMany("Stages")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");
                });

            modelBuilder.Entity("DotNetStarter.Entities.User", b =>
                {
                    b.HasOne("DotNetStarter.Entities.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("DotNetStarter.Entities.UserPrivilege", b =>
                {
                    b.HasOne("DotNetStarter.Entities.Privilege", "Privilege")
                        .WithMany()
                        .HasForeignKey("PrivilegeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DotNetStarter.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Privilege");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DotNetStarter.Entities.Talent", b =>
                {
                    b.HasOne("DotNetStarter.Entities.User", null)
                        .WithOne()
                        .HasForeignKey("DotNetStarter.Entities.Talent", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DotNetStarter.Entities.Project", b =>
                {
                    b.Navigation("Stages");
                });

            modelBuilder.Entity("DotNetStarter.Entities.Stage", b =>
                {
                    b.Navigation("Cards");
                });
#pragma warning restore 612, 618
        }
    }
}
