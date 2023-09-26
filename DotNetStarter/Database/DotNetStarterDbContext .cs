using Microsoft.EntityFrameworkCore;
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

            modelBuilder.Entity<UserPrivilege>().HasKey(sc => new { sc.UserId, sc.PrivilegeId });
            #endregion

            #region Privilege
            var manageUsersPrivilege = new Privilege
            {
                Id = new Guid("31abfcd0-ed97-4118-a168-f61682cc8034"),
                Name = PrivilegeNames.ManageUsers,
            };
            var managePaidLinguisticAssetsPrivilege = new Privilege
            {
                Id = new Guid("4f3095bc-4a7c-4444-a36d-1395183b9e32"),
                Name = PrivilegeNames.ManagePaidLinguisticAssets,
            };
            var manageVendorsPrivilege = new Privilege
            {
                Id = new Guid("c57f94c2-342b-423a-8fe8-e08dd5ce96b9"),
                Name = PrivilegeNames.ManageVendors,
            };
            var manageClientsAndProjectTagsPrivilege = new Privilege
            {
                Id = new Guid("fa1dd2fd-8037-4eba-8c51-2a1ee338a739"),
                Name = PrivilegeNames.ManageClientsAndProjectTags,
            };
            var createAnyProjectsPrivilege = new Privilege
            {
                Id = new Guid("844ef058-9bf3-4989-8717-101bf1887f85"),
                Name = PrivilegeNames.CreateAnyProjects,
            };
            var viewAllProjectsPrivilege = new Privilege
            {
                Id = new Guid("36ef0463-7435-4d8c-abc8-65a15824ed4e"),
                Name = PrivilegeNames.ViewAllProjects,
            };
            var manageLinguisticAssetsInAllProjectsPrivilege = new Privilege
            {
                Id = new Guid("7925dde1-b983-46c3-a9fa-59d08d497c3f"),
                Name = PrivilegeNames.ManageLinguisticAssetsInAllProjects,
            };
            var manageAllGlossariesPrivilege = new Privilege
            {
                Id = new Guid("ce641717-7ab9-46b4-8188-2ec28d1985a4"),
                Name = PrivilegeNames.ManageAllGlossaries,
            };
            var manageAllTmsPrivilege = new Privilege
            {
                Id = new Guid("19208f3f-0c95-416f-a095-99650fb94490"),
                Name = PrivilegeNames.ManageAllTms,
            };
            var suggestTermsWithoutSpecifyingAGlossaryPrivilege = new Privilege
            {
                Id = new Guid("06e6bc20-7534-4e47-b914-8a0dd0867a24"),
                Name = PrivilegeNames.SuggestTermsWithoutSpecifyingAGlossary,
            };
            var manageProjectTemplatesPrivilege = new Privilege
            {
                Id = new Guid("3f4a03fe-05ac-49e3-ac32-692ed12d1510"),
                Name = PrivilegeNames.ManageProjectTemplates,
            };
            var manageOrdersPrivilege = new Privilege
            {
                Id = new Guid("1e9c547e-f245-46e4-b4c6-779ce7a3774e"),
                Name = PrivilegeNames.ManageOrders,
            };
            var manageServiceTemplatesPrivilege = new Privilege
            {
                Id = new Guid("391a2af6-a576-43fd-9d3d-90baf5c52594"),
                Name = PrivilegeNames.ManageServiceTemplates,
            };

            modelBuilder.Entity<Privilege>().HasData(
                manageUsersPrivilege,
                managePaidLinguisticAssetsPrivilege,
                manageVendorsPrivilege,
                manageClientsAndProjectTagsPrivilege,
                createAnyProjectsPrivilege,
                viewAllProjectsPrivilege,
                manageLinguisticAssetsInAllProjectsPrivilege,
                manageAllGlossariesPrivilege,
                manageAllTmsPrivilege,
                suggestTermsWithoutSpecifyingAGlossaryPrivilege,
                manageProjectTemplatesPrivilege,
                manageOrdersPrivilege,
                manageServiceTemplatesPrivilege);
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
            var resourceManagerRole = new Role
            {
                Id = new Guid("752b3a92-dc11-487f-b2c9-0e5119e71604"),
                Name = RoleNames.ResourceManager,
            };
            var localizationTeamRole = new Role
            {
                Id = new Guid("75b9c8bd-68ff-49a2-ba3b-f3adf6b01d07"),
                Name = RoleNames.LocalizationTeam,
            };
            var talentRole = new Role
            {
                Id = new Guid("36a36642-44db-4e8d-8cc8-adc387d73150"),
                Name = RoleNames.Talent,
            };

            modelBuilder.Entity<Role>().HasData(
                administratorRole,
                projectManagerRole,
                resourceManagerRole,
                localizationTeamRole,
                talentRole);
            #endregion

            #region RolePrivilege
            var administratorManageUsersRolePrivilege = new RolePrivilege
            {
                Id = new Guid("9dbbfae8-7017-4a95-923d-c439b08d7110"),
                RoleId = administratorRole.Id,
                PrivilegeId = manageUsersPrivilege.Id,
            };
            var administratorManagePaidLinguisticAssetsRolePrivilege = new RolePrivilege
            {
                Id = new Guid("8d378b56-9c39-4c7e-8620-38c314821fef"),
                RoleId = administratorRole.Id,
                PrivilegeId = managePaidLinguisticAssetsPrivilege.Id,
            };
            var administratorManageVendorsRolePrivilege = new RolePrivilege
            {
                Id = new Guid("849c8950-e066-4543-9ed8-410a26916c0a"),
                RoleId = administratorRole.Id,
                PrivilegeId = manageVendorsPrivilege.Id,
            };
            var administratorManageClientsAndProjectTagsRolePrivilege = new RolePrivilege
            {
                Id = new Guid("44c3bfa4-0843-4c98-8c73-4106e452f305"),
                RoleId = administratorRole.Id,
                PrivilegeId = manageClientsAndProjectTagsPrivilege.Id,
            };
            var administratorCreateAnyProjectsRolePrivilege = new RolePrivilege
            {
                Id = new Guid("b8af3f12-42b5-4464-85bc-07d2315a61e1"),
                RoleId = administratorRole.Id,
                PrivilegeId = createAnyProjectsPrivilege.Id,
            };
            var administratorViewAllProjectsRolePrivilege = new RolePrivilege
            {
                Id = new Guid("b5855e40-ece8-4cb4-9acc-c87fa39c7543"),
                RoleId = administratorRole.Id,
                PrivilegeId = viewAllProjectsPrivilege.Id,
            };
            var administratorManageLinguisticAssetsInAllProjectsRolePrivilege = new RolePrivilege
            {
                Id = new Guid("d7a9c6f5-c519-4235-97f7-941c826f97d5"),
                RoleId = administratorRole.Id,
                PrivilegeId = manageLinguisticAssetsInAllProjectsPrivilege.Id,
            };
            var administratorManageAllGlossariesRolePrivilege = new RolePrivilege
            {
                Id = new Guid("0f467342-1e68-4cf5-85f3-46fce0948dad"),
                RoleId = administratorRole.Id,
                PrivilegeId = manageAllGlossariesPrivilege.Id,
            };
            var administratorManageAllTmsRolePrivilege = new RolePrivilege
            {
                Id = new Guid("dd11ec0b-3c25-44a7-bda0-c281e75683a6"),
                RoleId = administratorRole.Id,
                PrivilegeId = manageAllTmsPrivilege.Id,
            };
            var administratorSuggestTermsWithoutSpecifyingAGlossaryRolePrivilege = new RolePrivilege
            {
                Id = new Guid("9de33dad-f693-4be9-9e0d-69b687c6b682"),
                RoleId = administratorRole.Id,
                PrivilegeId = suggestTermsWithoutSpecifyingAGlossaryPrivilege.Id,
            };
            var administratorManageProjectTemplatesRolePrivilege = new RolePrivilege
            {
                Id = new Guid("d0b42a06-af2f-4348-b299-fcfddc72a142"),
                RoleId = administratorRole.Id,
                PrivilegeId = manageProjectTemplatesPrivilege.Id,
            };
            var administratorManageOrdersRolePrivilege = new RolePrivilege
            {
                Id = new Guid("b240f7dd-75dc-4595-a491-144cb1678406"),
                RoleId = administratorRole.Id,
                PrivilegeId = manageOrdersPrivilege.Id,
            };
            var administratorManageServiceTemplatesRolePrivilege = new RolePrivilege
            {
                Id = new Guid("9543579e-5ef5-472b-acc2-de08a867c38c"),
                RoleId = administratorRole.Id,
                PrivilegeId = manageServiceTemplatesPrivilege.Id,
            };

            var projectManagerManageClientsAndProjectTagsRolePrivilege = new RolePrivilege
            {
                Id = new Guid("75041757-4085-42ce-8800-10610b1f6091"),
                RoleId = projectManagerRole.Id,
                PrivilegeId = manageClientsAndProjectTagsPrivilege.Id,
            };
            var projectManagerCreateAnyProjectsRolePrivilege = new RolePrivilege
            {
                Id = new Guid("87491c80-15df-482c-87a2-e4770a7c1e5a"),
                RoleId = projectManagerRole.Id,
                PrivilegeId = createAnyProjectsPrivilege.Id,
            };
            var projectManagerViewAllProjectsRolePrivilege = new RolePrivilege
            {
                Id = new Guid("3a9f0b14-19df-4e2a-b522-c63e813510a9"),
                RoleId = projectManagerRole.Id,
                PrivilegeId = viewAllProjectsPrivilege.Id,
            };
            var projectManagerManageLinguisticAssetsInAllProjectsRolePrivilege = new RolePrivilege
            {
                Id = new Guid("e3ad16fb-0983-4b76-b900-e1512a1de3f9"),
                RoleId = projectManagerRole.Id,
                PrivilegeId = manageLinguisticAssetsInAllProjectsPrivilege.Id,
            };
            var projectManagerManageAllGlossariesRolePrivilege = new RolePrivilege
            {
                Id = new Guid("15306c3c-4888-4fef-b12c-8e307929cd1f"),
                RoleId = projectManagerRole.Id,
                PrivilegeId = manageAllGlossariesPrivilege.Id,
            };
            var projectManagerManageAllTmsRolePrivilege = new RolePrivilege
            {
                Id = new Guid("d57a2c99-27e5-464c-8715-3f7fb6f1a57f"),
                RoleId = projectManagerRole.Id,
                PrivilegeId = manageAllTmsPrivilege.Id,
            };
            var projectManagerSuggestTermsWithoutSpecifyingAGlossaryRolePrivilege = new RolePrivilege
            {
                Id = new Guid("1f0e1d76-2f51-40f3-9571-92bd0ba288b9"),
                RoleId = projectManagerRole.Id,
                PrivilegeId = suggestTermsWithoutSpecifyingAGlossaryPrivilege.Id,
            };
            var projectManagerManageProjectTemplatesRolePrivilege = new RolePrivilege
            {
                Id = new Guid("391b873b-247f-4e41-8fc7-8d8697e5240c"),
                RoleId = projectManagerRole.Id,
                PrivilegeId = manageProjectTemplatesPrivilege.Id,
            };
            var projectManagerManageOrdersRolePrivilege = new RolePrivilege
            {
                Id = new Guid("8bfee646-f1eb-41d5-a045-8fb7773d09a9"),
                RoleId = projectManagerRole.Id,
                PrivilegeId = manageOrdersPrivilege.Id,
            };

            var resourceManagerManageAllGlossariesRolePrivilege = new RolePrivilege
            {
                Id = new Guid("526e8242-f5a4-481d-8c16-5a8d953cd713"),
                RoleId = resourceManagerRole.Id,
                PrivilegeId = manageAllGlossariesPrivilege.Id,
            };
            var resourceManagerManageAllTmsRolePrivilege = new RolePrivilege
            {
                Id = new Guid("92e615d3-2fe3-4a34-94dd-88d1f17792de"),
                RoleId = resourceManagerRole.Id,
                PrivilegeId = manageAllTmsPrivilege.Id,
            };
            var resourceManagerSuggestTermsWithoutSpecifyingAGlossaryRolePrivilege = new RolePrivilege
            {
                Id = new Guid("d843a16e-59b8-4fe3-b860-9a6200f68a4b"),
                RoleId = resourceManagerRole.Id,
                PrivilegeId = suggestTermsWithoutSpecifyingAGlossaryPrivilege.Id,
            };

            var localizationTeamManageAllGlossariesRolePrivilege = new RolePrivilege
            {
                Id = new Guid("63fb0ea1-c5a2-44b4-85ae-e9ba1a0d2c93"),
                RoleId = localizationTeamRole.Id,
                PrivilegeId = manageAllGlossariesPrivilege.Id,
            };
            var localizationTeamCreateAnyProjectsRolePrivilege = new RolePrivilege
            {
                Id = new Guid("5b789d79-3444-4437-8d33-270f5024c57a"),
                RoleId = localizationTeamRole.Id,
                PrivilegeId = createAnyProjectsPrivilege.Id,
            };
            var localizationTeamViewAllProjectsRolePrivilege = new RolePrivilege
            {
                Id = new Guid("c4426758-be79-4e70-a980-2f555103fb98"),
                RoleId = localizationTeamRole.Id,
                PrivilegeId = viewAllProjectsPrivilege.Id,
            };
            var localizationTeamManageAllTmsRolePrivilege = new RolePrivilege
            {
                Id = new Guid("1f96dc48-84f7-4dfd-a45e-e5c17a6f45a6"),
                RoleId = localizationTeamRole.Id,
                PrivilegeId = manageAllTmsPrivilege.Id,
            };
            var localizationTeamManageLinguisticAssetsInAllProjectsRolePrivilege = new RolePrivilege
            {
                Id = new Guid("14d9869e-7283-4a86-afbf-b93a1cbcbbcb"),
                RoleId = localizationTeamRole.Id,
                PrivilegeId = manageLinguisticAssetsInAllProjectsPrivilege.Id,
            };

            modelBuilder.Entity<RolePrivilege>().HasData(
                administratorManageUsersRolePrivilege,
                administratorManagePaidLinguisticAssetsRolePrivilege,
                administratorManageVendorsRolePrivilege,
                administratorManageClientsAndProjectTagsRolePrivilege,
                administratorCreateAnyProjectsRolePrivilege,
                administratorViewAllProjectsRolePrivilege,
                administratorManageLinguisticAssetsInAllProjectsRolePrivilege,
                administratorManageAllGlossariesRolePrivilege,
                administratorManageAllTmsRolePrivilege,
                administratorSuggestTermsWithoutSpecifyingAGlossaryRolePrivilege,
                administratorManageProjectTemplatesRolePrivilege,
                administratorManageOrdersRolePrivilege,
                administratorManageServiceTemplatesRolePrivilege,
                projectManagerManageClientsAndProjectTagsRolePrivilege,
                projectManagerCreateAnyProjectsRolePrivilege,
                projectManagerViewAllProjectsRolePrivilege,
                projectManagerManageLinguisticAssetsInAllProjectsRolePrivilege,
                projectManagerManageAllGlossariesRolePrivilege,
                projectManagerManageAllTmsRolePrivilege,
                projectManagerSuggestTermsWithoutSpecifyingAGlossaryRolePrivilege,
                projectManagerManageProjectTemplatesRolePrivilege,
                projectManagerManageOrdersRolePrivilege,
                resourceManagerManageAllGlossariesRolePrivilege,
                resourceManagerManageAllTmsRolePrivilege,
                resourceManagerSuggestTermsWithoutSpecifyingAGlossaryRolePrivilege,
                localizationTeamManageAllGlossariesRolePrivilege,
                localizationTeamCreateAnyProjectsRolePrivilege,
                localizationTeamViewAllProjectsRolePrivilege,
                localizationTeamManageAllTmsRolePrivilege,
                localizationTeamManageLinguisticAssetsInAllProjectsRolePrivilege);
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
            var adminManageUsersUserPrivilege = new UserPrivilege
            {
                Id = new Guid("aa58599d-743d-4f39-b3c1-9f4f0f561d5e"),
                UserId = admin.Id,
                PrivilegeId = manageUsersPrivilege.Id,
            };
            var adminManagePaidLinguisticAssetsUserPrivilege = new UserPrivilege
            {
                Id = new Guid("8c620425-8f7d-43e5-82fa-17794c22a208"),
                UserId = admin.Id,
                PrivilegeId = managePaidLinguisticAssetsPrivilege.Id,
            };
            var adminManageVendorsUserPrivilege = new UserPrivilege
            {
                Id = new Guid("999c7d5e-f5f1-48dc-90bc-32bcc524e463"),
                UserId = admin.Id,
                PrivilegeId = manageVendorsPrivilege.Id,
            };
            var adminManageClientsAndProjectTagsUserPrivilege = new UserPrivilege
            {
                Id = new Guid("438dff74-2a59-43a8-a5fc-c63000fafa6d"),
                UserId = admin.Id,
                PrivilegeId = manageClientsAndProjectTagsPrivilege.Id,
            };
            var adminCreateAnyProjectsUserPrivilege = new UserPrivilege
            {
                Id = new Guid("81cba8a1-9a35-456e-971e-5cfa7030c7a4"),
                UserId = admin.Id,
                PrivilegeId = createAnyProjectsPrivilege.Id,
            };
            var adminViewAllProjectsUserPrivilege = new UserPrivilege
            {
                Id = new Guid("1beafe73-0317-44d1-b8c0-12e2e7a85236"),
                UserId = admin.Id,
                PrivilegeId = viewAllProjectsPrivilege.Id,
            };
            var adminManageLinguisticAssetsInAllProjectsUserPrivilege = new UserPrivilege
            {
                Id = new Guid("c65a5602-5d5e-4ae7-947a-1372a5b27dd2"),
                UserId = admin.Id,
                PrivilegeId = manageLinguisticAssetsInAllProjectsPrivilege.Id,
            };
            var adminManageAllGlossariesUserPrivilege = new UserPrivilege
            {
                Id = new Guid("b5ba8a36-6c3c-4ee2-bb4d-a938dd546395"),
                UserId = admin.Id,
                PrivilegeId = manageAllGlossariesPrivilege.Id,
            };
            var adminManageAllTmsUserPrivilege = new UserPrivilege
            {
                Id = new Guid("bfd1ddc4-d92e-40d5-be7c-52863a4529d1"),
                UserId = admin.Id,
                PrivilegeId = manageAllTmsPrivilege.Id,
            };
            var adminSuggestTermsWithoutSpecifyingAGlossaryUserPrivilege = new UserPrivilege
            {
                Id = new Guid("06346a5f-2681-4177-8ed1-5fc487007911"),
                UserId = admin.Id,
                PrivilegeId = suggestTermsWithoutSpecifyingAGlossaryPrivilege.Id,
            };
            var adminManageProjectTemplatesUserPrivilege = new UserPrivilege
            {
                Id = new Guid("810fd972-1080-4943-9383-60f0961fea4c"),
                UserId = admin.Id,
                PrivilegeId = manageProjectTemplatesPrivilege.Id,
            };
            var adminManageOrdersUserPrivilege = new UserPrivilege
            {
                Id = new Guid("72af926f-b0a5-421b-85ff-293fdca1cc4e"),
                UserId = admin.Id,
                PrivilegeId = manageOrdersPrivilege.Id,
            };
            var adminManageServiceTemplatesUserPrivilege = new UserPrivilege
            {
                Id = new Guid("e23e2a09-31be-4516-b570-c0e17290ace4"),
                UserId = admin.Id,
                PrivilegeId = manageServiceTemplatesPrivilege.Id,
            };

            modelBuilder.Entity<UserPrivilege>().HasData(
                adminManageUsersUserPrivilege,
                adminManagePaidLinguisticAssetsUserPrivilege,
                adminManageVendorsUserPrivilege,
                adminManageClientsAndProjectTagsUserPrivilege,
                adminCreateAnyProjectsUserPrivilege,
                adminViewAllProjectsUserPrivilege,
                adminManageLinguisticAssetsInAllProjectsUserPrivilege,
                adminManageAllGlossariesUserPrivilege,
                adminManageAllTmsUserPrivilege,
                adminSuggestTermsWithoutSpecifyingAGlossaryUserPrivilege,
                adminManageProjectTemplatesUserPrivilege,
                adminManageOrdersUserPrivilege,
                adminManageServiceTemplatesUserPrivilege);
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

        public DbSet<UserPrivilege> UserPrivileges { get; set; }

        public DbSet<Otp> Otps { get; set; }

        public DbSet<AuthToken> AuthTokens { get; set; }

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
