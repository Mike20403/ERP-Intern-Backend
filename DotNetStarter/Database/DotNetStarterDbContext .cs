﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using DotNetStarter.Entities;
using DotNetStarter.Common.Enums;
using Microsoft.AspNetCore.Http;
using DotNetStarter.Extensions;
using DotNetStarter.Common;

namespace DotNetStarter.Database
{
    public class DotNetStarterDbContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        protected readonly IHttpContextAccessor HttpContextAccessor;

        public DotNetStarterDbContext()
        {
        }

        public DotNetStarterDbContext(IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            Configuration = configuration;
            HttpContextAccessor = httpContextAccessor;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to sql server database
            if (Configuration != null)
            {
                options.UseSqlServer(Configuration.GetConnectionString("DotNetStarter"));
            }
            else // it means we are in LINQPad mode
            {
                options.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=DotNetStarter;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region Congifuration
            modelBuilder.Entity<Privilege>(entity => {
                entity.HasIndex(e => e.Name).IsUnique();
            });

            modelBuilder.Entity<Role>(entity => {
                entity.HasIndex(e => e.Name).IsUnique();
            });

            modelBuilder.Entity<Role>()
                .HasMany(e => e.Privileges)
                .WithMany(e => e.Roles)
                .UsingEntity<RolePrivilege>();

            modelBuilder.Entity<RolePrivilege>().HasKey(sc => new { sc.RoleId, sc.PrivilegeId });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.Username).IsUnique();
                entity.HasIndex(e => e.PhoneNumber).IsUnique();
            });

            modelBuilder.Entity<User>()
                .HasMany(e => e.Privileges)
                .WithMany(e => e.Users)
                .UsingEntity<UserPrivilege>();

            modelBuilder.Entity<Talent>()
                .ToTable(
                    "Talents",
                    tableBuilder => tableBuilder.Property(talent => talent.Id).HasColumnName("TalentId"));

            modelBuilder.Entity<UserPrivilege>().HasKey(sc => new { sc.UserId, sc.PrivilegeId });
            #endregion

            #region Privilege
            var viewAgencyMembersPrivilege = new Privilege
            {
                Id = new Guid("a79f4031-3902-47ac-bbf9-252c665a6b94"),
                Name = PrivilegeNames.ViewStaffMembers,
            };
            var createAgencyMembersPrivilege = new Privilege
            {
                Id = new Guid("9b93570a-bb7b-43ff-b46c-bb74dff4c17e"),
                Name = PrivilegeNames.CreateStaffMembers,
            };
            var updateAgencyMembersPrivilege = new Privilege
            {
                Id = new Guid("c38fa488-ad8f-4821-a869-f2be2ff2dcc5"),
                Name = PrivilegeNames.UpdateStaffMembers,
            };
            var deleteAgencyMembersPrivilege = new Privilege
            {
                Id = new Guid("549eec1c-c4b5-41ae-944b-f5398fbb1106"),
                Name = PrivilegeNames.DeleteStaffMembers,
            };

            var viewTalentsPrivilege = new Privilege
            {
                Id = new Guid("cac3bf78-86a7-4255-9ed1-36a3cd89f1e9"),
                Name = PrivilegeNames.ViewTalents,
            };
            var createTalentsPrivilege = new Privilege
            {
                Id = new Guid("50817957-ef43-4393-b1a4-d557dc936daa"),
                Name = PrivilegeNames.CreateTalents,
            };
            var updateTalentsPrivilege = new Privilege
            {
                Id = new Guid("a9bedfe8-2813-465f-acd8-eadc61519e4d"),
                Name = PrivilegeNames.UpdateTalents,
            };
            var deleteTalentsPrivilege = new Privilege
            {
                Id = new Guid("183bc93e-89f7-41b0-9948-724194af2302"),
                Name = PrivilegeNames.DeleteTalents,
            };

            var viewProjectsPrivilege = new Privilege
            {
                Id = new Guid("0eefd2b0-d280-4ee7-906d-0baa3dcd0c88"),
                Name = PrivilegeNames.ViewProjects,
            };
            var createProjectsPrivilege = new Privilege
            {
                Id = new Guid("82bc464a-0d13-482e-97a7-7237a37e94c2"),
                Name = PrivilegeNames.CreateProjects,
            };
            var updateProjectsPrivilege = new Privilege
            {
                Id = new Guid("1e63d635-ecb8-4f3e-972e-14e932fab8c0"),
                Name = PrivilegeNames.UpdateProjects,
            };
            var deleteProjectsPrivilege = new Privilege
            {
                Id = new Guid("e46fc4b7-c5ac-499d-80f1-1a983e672839"),
                Name = PrivilegeNames.DeleteProjects,
            };

            var viewTasksPrivilege = new Privilege
            {
                Id = new Guid("c22a378a-feb2-4a97-82b9-3b0a0588ddcd"),
                Name = PrivilegeNames.ViewTasks,
            };
            var createTasksPrivilege = new Privilege
            {
                Id = new Guid("36b6bbda-3c16-47a7-8353-88fd19eaf2e1"),
                Name = PrivilegeNames.CreateTasks,
            };
            var updateTasksPrivilege = new Privilege
            {
                Id = new Guid("9a1edd05-bd24-462e-9754-534ec573745f"),
                Name = PrivilegeNames.UpdateTasks,
            };
            var deleteTasksPrivilege = new Privilege
            {
                Id = new Guid("9b07b2fd-259c-43bf-9a5d-715945b23414"),
                Name = PrivilegeNames.DeleteTasks,
            };

            var inviteTalentsPrivilege = new Privilege
            {
                Id = new Guid("78416000-2b67-4b1f-89e7-3dbe3fd726b7"),
                Name = PrivilegeNames.InviteTalents,
            };
            var removeTalentsFromProjectPrivilege = new Privilege
            {
                Id = new Guid("9483ac95-4f7a-4b5a-93cf-636a230a662d"),
                Name = PrivilegeNames.RemoveTalentsFromProject,
            };
            var CreatePaymentsPrivilege = new Privilege
            {
                Id = new Guid("6deeccfd-7c92-4699-bbae-de86f83f6237"),
                Name = PrivilegeNames.CreatePayments,
            };
            var UpdatePaymentsPrivilege = new Privilege
            {
                Id = new Guid("0636175f-b650-4d48-a5e3-37f08b394b45"),
                Name = PrivilegeNames.UpdatePayments,
            };
            var AcceptPaymentsPrivilege = new Privilege
            {
                Id = new Guid("5b665dc9-28a0-451f-af9d-05fdd64ac704"),
                Name = PrivilegeNames.AcceptPayments,
            };
            var FinalizePaymentsPrivilege = new Privilege
            {
                Id = new Guid("ea6706b9-32a3-4a17-ab7f-0598c87b522b"),
                Name = PrivilegeNames.FinalizePayments,
            };

            modelBuilder.Entity<Privilege>().HasData(
                viewAgencyMembersPrivilege,
                createAgencyMembersPrivilege,
                updateAgencyMembersPrivilege,
                deleteAgencyMembersPrivilege,
                viewTalentsPrivilege,
                createTalentsPrivilege,
                updateTalentsPrivilege,
                deleteTalentsPrivilege,
                viewProjectsPrivilege,
                createProjectsPrivilege,
                updateProjectsPrivilege,
                deleteProjectsPrivilege,
                viewTasksPrivilege,
                createTasksPrivilege,
                updateTasksPrivilege,
                deleteTasksPrivilege,
                inviteTalentsPrivilege,
                removeTalentsFromProjectPrivilege,
                CreatePaymentsPrivilege,
                UpdatePaymentsPrivilege,
                AcceptPaymentsPrivilege,
                FinalizePaymentsPrivilege
            );
            #endregion

            #region Role
            var administratorRole = new Role
            {
                Id = new Guid("364dfceb-7779-4190-a5bc-2bd4aba39af4"),
                Name = RoleNames.Administrator,
            };
            var projectManagerRole = new Role
            {
                Id = new Guid("2fa87016-bafe-44f7-b4b3-d41fb0f0e202"),
                Name = RoleNames.ProjectManager,
            };
            var agencyMemberRole = new Role
            {
                Id = new Guid("e73f1844-04be-4d7f-8e6e-65a1a20b2a83"),
                Name = RoleNames.AgencyMember,
            };
            var talentRole = new Role
            {
                Id = new Guid("36a36642-44db-4e8d-8cc8-adc387d73150"),
                Name = RoleNames.Talent,
            };

            modelBuilder.Entity<Role>().HasData(
                administratorRole,
                projectManagerRole,
                agencyMemberRole,
                talentRole);
            #endregion

            #region RolePrivilege
            var administratorViewAgencyMembersRolePrivilege = new RolePrivilege
            {
                RoleId = administratorRole.Id,
                PrivilegeId = viewAgencyMembersPrivilege.Id,
            };
            var administratorCreateAgencyMembersRolePrivilege = new RolePrivilege
            {
                RoleId = administratorRole.Id,
                PrivilegeId = createAgencyMembersPrivilege.Id,
            };
            var administratorUpdateAgencyMembersRolePrivilege = new RolePrivilege
            {
                RoleId = administratorRole.Id,
                PrivilegeId = updateAgencyMembersPrivilege.Id,
            };
            var administratorDeleteAgencyMembersRolePrivilege = new RolePrivilege
            {
                RoleId = administratorRole.Id,
                PrivilegeId = deleteAgencyMembersPrivilege.Id,
            };
            var administratorViewTalentsRolePrivilege = new RolePrivilege
            {
                RoleId = administratorRole.Id,
                PrivilegeId = viewTalentsPrivilege.Id,
            };
            var administratorCreateTalentsRolePrivilege = new RolePrivilege
            {
                RoleId = administratorRole.Id,
                PrivilegeId = createTalentsPrivilege.Id,
            };
            var administratorUpdateTalentsRolePrivilege = new RolePrivilege
            {
                RoleId = administratorRole.Id,
                PrivilegeId = updateTalentsPrivilege.Id,
            };
            var administratorDeleteTalentsRolePrivilege = new RolePrivilege
            {
                RoleId = administratorRole.Id,
                PrivilegeId = deleteTalentsPrivilege.Id,
            };

            var projectManagerViewTalentsRolePrivilege = new RolePrivilege
            {
                RoleId = projectManagerRole.Id,
                PrivilegeId = viewTalentsPrivilege.Id,
            };
            var projectManagerInviteTalentsRolePrivilege = new RolePrivilege
            {
                RoleId = projectManagerRole.Id,
                PrivilegeId = inviteTalentsPrivilege.Id,
            };
            var projectManagerRemoveTalentsFromProjectRolePrivilege = new RolePrivilege
            {
                RoleId = projectManagerRole.Id,
                PrivilegeId = removeTalentsFromProjectPrivilege.Id,
            };
            var projectManagerViewProjectsRolePrivilege = new RolePrivilege
            {
                RoleId = projectManagerRole.Id,
                PrivilegeId = viewProjectsPrivilege.Id,
            };
            var projectManagerUpdateProjectRolePrivilege = new RolePrivilege
            {
                RoleId = projectManagerRole.Id,
                PrivilegeId = updateProjectsPrivilege.Id,
            };
            var projectManagerViewTasksRolePrivilege = new RolePrivilege
            {
                RoleId = projectManagerRole.Id,
                PrivilegeId = viewTasksPrivilege.Id,
            };
            var projectManagerCreateTasksRolePrivilege = new RolePrivilege
            {
                RoleId = projectManagerRole.Id,
                PrivilegeId = createTasksPrivilege.Id,
            };
            var projectManagerUpdateTasksRolePrivilege = new RolePrivilege
            {
                RoleId = projectManagerRole.Id,
                PrivilegeId = updateTasksPrivilege.Id,
            };
            var projectManagerDeleteTasksRolePrivilege = new RolePrivilege
            {
                RoleId = projectManagerRole.Id,
                PrivilegeId = deleteTasksPrivilege.Id,
            };
            var projectManagerFinalizePaymentRolePrivilege = new RolePrivilege
            {
                RoleId = projectManagerRole.Id,
                PrivilegeId = FinalizePaymentsPrivilege.Id,
            };
            var agencyMemberViewProjectManagerPrivilege = new RolePrivilege
            {
                RoleId = agencyMemberRole.Id,
                PrivilegeId = viewAgencyMembersPrivilege.Id,
            };
            var agencyMemberViewTalentsRolePrivilege = new RolePrivilege
            {
                RoleId = agencyMemberRole.Id,
                PrivilegeId = viewTalentsPrivilege.Id,
            };
            var agencyMemberInviteTalentsRolePrivilege = new RolePrivilege
            {
                RoleId = agencyMemberRole.Id,
                PrivilegeId = inviteTalentsPrivilege.Id,
            };
            var agencyMemberRemoveTalentsRolePrivilege = new RolePrivilege
            {
                RoleId = agencyMemberRole.Id,
                PrivilegeId = removeTalentsFromProjectPrivilege.Id,
            };
            var agencyMemberAcceptPaymentRolePrivilege = new RolePrivilege
            {
                RoleId = agencyMemberRole.Id,
                PrivilegeId = AcceptPaymentsPrivilege.Id,
            };
            var agencyMemberViewProjectsRolePrivilege = new RolePrivilege
            {
                RoleId = agencyMemberRole.Id,
                PrivilegeId = viewProjectsPrivilege.Id,
            };
            var agencyMemberCreateProjectsRolePrivilege = new RolePrivilege
            {
                RoleId = agencyMemberRole.Id,
                PrivilegeId = createProjectsPrivilege.Id,
            };
            var agencyMemberUpdateProjectsRolePrivilege = new RolePrivilege
            {
                RoleId = agencyMemberRole.Id,
                PrivilegeId = updateProjectsPrivilege.Id,
            };
            var agencyMemberDeleteProjectsRolePrivilege = new RolePrivilege
            {
                RoleId = agencyMemberRole.Id,
                PrivilegeId = deleteProjectsPrivilege.Id,
            };

            var talentViewProjectsRolePrivilege = new RolePrivilege
            {
                RoleId = talentRole.Id,
                PrivilegeId = viewProjectsPrivilege.Id,
            };
            var talentCreatePaymentRolePrivilege = new RolePrivilege
            {
                RoleId = talentRole.Id,
                PrivilegeId = CreatePaymentsPrivilege.Id,
            };
            var talentUpatePaymentRolePrivilege = new RolePrivilege
            {
                RoleId = talentRole.Id,
                PrivilegeId = UpdatePaymentsPrivilege.Id,
            };
            var talentViewTasksRolePrivilege = new RolePrivilege
            {
                RoleId = talentRole.Id,
                PrivilegeId = viewTasksPrivilege.Id,
            };
            var talentCreateTasksRolePrivilege = new RolePrivilege
            {
                RoleId = talentRole.Id,
                PrivilegeId = createTasksPrivilege.Id,
            };
            var talentUpdateTasksRolePrivilege = new RolePrivilege
            {
                RoleId = talentRole.Id,
                PrivilegeId = updateTasksPrivilege.Id,
            };
            var talentDeleteTasksRolePrivilege = new RolePrivilege
            {
                RoleId = talentRole.Id,
                PrivilegeId = deleteTasksPrivilege.Id,
            };

            modelBuilder.Entity<RolePrivilege>().HasData(
                administratorViewAgencyMembersRolePrivilege,
                administratorCreateAgencyMembersRolePrivilege,
                administratorUpdateAgencyMembersRolePrivilege,
                administratorDeleteAgencyMembersRolePrivilege,
                administratorViewTalentsRolePrivilege,
                administratorCreateTalentsRolePrivilege,
                administratorUpdateTalentsRolePrivilege,
                administratorDeleteTalentsRolePrivilege,

                projectManagerViewTalentsRolePrivilege,
                projectManagerInviteTalentsRolePrivilege,
                projectManagerRemoveTalentsFromProjectRolePrivilege,
                projectManagerViewProjectsRolePrivilege,
                projectManagerUpdateProjectRolePrivilege,
                projectManagerViewTasksRolePrivilege,
                projectManagerCreateTasksRolePrivilege,
                projectManagerUpdateTasksRolePrivilege,
                projectManagerDeleteTasksRolePrivilege,
                projectManagerFinalizePaymentRolePrivilege,

                agencyMemberViewTalentsRolePrivilege,
                agencyMemberInviteTalentsRolePrivilege,
                agencyMemberRemoveTalentsRolePrivilege,
                agencyMemberAcceptPaymentRolePrivilege,
                agencyMemberViewProjectsRolePrivilege,
                agencyMemberCreateProjectsRolePrivilege,
                agencyMemberUpdateProjectsRolePrivilege,
                agencyMemberDeleteProjectsRolePrivilege,
                agencyMemberViewProjectManagerPrivilege,

                talentViewProjectsRolePrivilege,
                talentCreatePaymentRolePrivilege,
                talentUpatePaymentRolePrivilege,
                talentViewTasksRolePrivilege,
                talentCreateTasksRolePrivilege,
                talentUpdateTasksRolePrivilege,
                talentDeleteTasksRolePrivilege
            );
            #endregion

            #region User
            var dateTime = new DateTime(2023, 9, 14, 0, 0, 0);
            var admin = new User
            {
                Id = new Guid("a3edc636-8153-42af-85a1-65dac56cded7"),
                Username = "admin.dotnetstarter@yopmail.com",
                Firstname = "Admin",
                Lastname = "Yopmail",
                Password = "$2a$11$61sJj9Y7idWPUoWTysZ81u7B0veE3dPhfdPGIJbi.TB0r/NtgR0k2",
                PhoneNumber = "0333333333",
                Gender = Gender.Male,
                CreatedDate = dateTime,
                CreatedBy = "System",
                UpdatedDate = dateTime,
                UpdatedBy = "System",
                Status = Status.Active,
                RoleId = administratorRole.Id,
            };

            modelBuilder.Entity<User>().HasData(admin);
            #endregion

            #region UserPrivilege
            var administratorViewAgencyMemberUserPrivilege = new UserPrivilege
            {
                UserId = admin.Id,
                PrivilegeId = viewAgencyMembersPrivilege.Id,
            };
            var administratorCreateAgencyMemberUserPrivilege = new UserPrivilege
            {
                UserId = admin.Id,
                PrivilegeId = createAgencyMembersPrivilege.Id,
            };
            var administratorUpdateAgencyMemberUserPrivilege = new UserPrivilege
            {
                UserId = admin.Id,
                PrivilegeId = updateAgencyMembersPrivilege.Id,
            };
            var administratorDeleteAgencyMemberUserPrivilege = new UserPrivilege
            {
                UserId = admin.Id,
                PrivilegeId = deleteAgencyMembersPrivilege.Id,
            };

            var administratorViewTalentsUserPrivilege = new UserPrivilege
            {
                UserId = admin.Id,
                PrivilegeId = viewTalentsPrivilege.Id,
            };
            var administratorCreateTalentsUserPrivilege = new UserPrivilege
            {
                UserId = admin.Id,
                PrivilegeId = createTalentsPrivilege.Id,
            };
            var administratorUpdateTalentsUserPrivilege = new UserPrivilege
            {
                UserId = admin.Id,
                PrivilegeId = updateTalentsPrivilege.Id,
            };
            var administratorDeleteTalentsUserPrivilege = new UserPrivilege
            {
                UserId = admin.Id,
                PrivilegeId = deleteTalentsPrivilege.Id,
            };

            modelBuilder.Entity<UserPrivilege>().HasData(
                administratorViewAgencyMemberUserPrivilege,
                administratorCreateAgencyMemberUserPrivilege,
                administratorUpdateAgencyMemberUserPrivilege,
                administratorDeleteAgencyMemberUserPrivilege,
                administratorViewTalentsUserPrivilege,
                administratorCreateTalentsUserPrivilege,
                administratorUpdateTalentsUserPrivilege,
                administratorDeleteTalentsUserPrivilege
            );
            #endregion
        }

        public override int SaveChanges()
        {
            SetAuditing();
            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            SetAuditing();
            return await base.SaveChangesAsync(cancellationToken);
        }

        public DbSet<Privilege> Privileges { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<RolePrivilege> RolePrivileges { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Talent> Talents { get; set; }

        public DbSet<UserPrivilege> UserPrivileges { get; set; }

        public DbSet<Otp> Otps { get; set; }

        public DbSet<AuthToken> AuthTokens { get; set; }

        public DbSet<Project> Projects { get; set; }

        private void SetAuditing()
        {
            var now = DateTime.Now;
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is BaseAuditingEntity && (e.State == EntityState.Added || e.State == EntityState.Modified));

            foreach (var entityEntry in entries)
            {
                if (entityEntry.Entity is BaseAuditingEntity baseAuditing)
                {
                    baseAuditing.UpdatedDate = now;
                    baseAuditing.UpdatedBy = HttpContextAccessor.HttpContext.GetCurrentUserEmail() ?? "System";

                    if (entityEntry.State == EntityState.Added)
                    {
                        baseAuditing.CreatedDate = now;
                        baseAuditing.CreatedBy = HttpContextAccessor.HttpContext.GetCurrentUserEmail() ?? "System";
                    }
                }
            }
        }
    }
}
