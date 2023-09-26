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

            var now = DateTime.Now;

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
                Id = Guid.NewGuid(),
                Name = PrivilegeNames.ManageUsers,
            };
            var managePaidLinguisticAssetsPrivilege = new Privilege
            {
                Id = Guid.NewGuid(),
                Name = PrivilegeNames.ManagePaidLinguisticAssets,
            };
            var manageVendorsPrivilege = new Privilege
            {
                Id = Guid.NewGuid(),
                Name = PrivilegeNames.ManageVendors,
            };
            var manageClientsAndProjectTagsPrivilege = new Privilege
            {
                Id = Guid.NewGuid(),
                Name = PrivilegeNames.ManageClientsAndProjectTags,
            };
            var createAnyProjectsPrivilege = new Privilege
            {
                Id = Guid.NewGuid(),
                Name = PrivilegeNames.CreateAnyProjects,
            };
            var viewAllProjectsPrivilege = new Privilege
            {
                Id = Guid.NewGuid(),
                Name = PrivilegeNames.ViewAllProjects,
            };
            var manageLinguisticAssetsInAllProjectsPrivilege = new Privilege
            {
                Id = Guid.NewGuid(),
                Name = PrivilegeNames.ManageLinguisticAssetsInAllProjects,
            };
            var manageAllGlossariesPrivilege = new Privilege
            {
                Id = Guid.NewGuid(),
                Name = PrivilegeNames.ManageAllGlossaries,
            };
            var manageAllTmsPrivilege = new Privilege
            {
                Id = Guid.NewGuid(),
                Name = PrivilegeNames.ManageAllTms,
            };
            var suggestTermsWithoutSpecifyingAGlossaryPrivilege = new Privilege
            {
                Id = Guid.NewGuid(),
                Name = PrivilegeNames.SuggestTermsWithoutSpecifyingAGlossary,
            };
            var manageProjectTemplatesPrivilege = new Privilege
            {
                Id = Guid.NewGuid(),
                Name = PrivilegeNames.ManageProjectTemplates,
            };
            var manageOrdersPrivilege = new Privilege
            {
                Id = Guid.NewGuid(),
                Name = PrivilegeNames.ManageOrders,
            };
            var manageServiceTemplatesPrivilege = new Privilege
            {
                Id = Guid.NewGuid(),
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
                Id = Guid.NewGuid(),
                Name = RoleNames.Administrator,
            };
            var projectManagerRole = new Role
            {
                Id = Guid.NewGuid(),
                Name = RoleNames.ProjectManager,
            };
            var resourceManagerRole = new Role
            {
                Id = Guid.NewGuid(),
                Name = RoleNames.ResourceManager,
            };
            var localizationTeamRole = new Role
            {
                Id = Guid.NewGuid(),
                Name = RoleNames.LocalizationTeam,
            };
            var talentRole = new Role
            {
                Id = Guid.NewGuid(),
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
                Id = Guid.NewGuid(),
                RoleId = administratorRole.Id,
                PrivilegeId = manageUsersPrivilege.Id,
            };
            var administratorManagePaidLinguisticAssetsRolePrivilege = new RolePrivilege
            {
                Id = Guid.NewGuid(),
                RoleId = administratorRole.Id,
                PrivilegeId = managePaidLinguisticAssetsPrivilege.Id,
            };
            var administratorManageVendorsRolePrivilege = new RolePrivilege
            {
                Id = Guid.NewGuid(),
                RoleId = administratorRole.Id,
                PrivilegeId = manageVendorsPrivilege.Id,
            };
            var administratorManageClientsAndProjectTagsRolePrivilege = new RolePrivilege
            {
                Id = Guid.NewGuid(),
                RoleId = administratorRole.Id,
                PrivilegeId = manageClientsAndProjectTagsPrivilege.Id,
            };
            var administratorCreateAnyProjectsRolePrivilege = new RolePrivilege
            {
                Id = Guid.NewGuid(),
                RoleId = administratorRole.Id,
                PrivilegeId = createAnyProjectsPrivilege.Id,
            };
            var administratorViewAllProjectsRolePrivilege = new RolePrivilege
            {
                Id = Guid.NewGuid(),
                RoleId = administratorRole.Id,
                PrivilegeId = viewAllProjectsPrivilege.Id,
            };
            var administratorManageLinguisticAssetsInAllProjectsRolePrivilege = new RolePrivilege
            {
                Id = Guid.NewGuid(),
                RoleId = administratorRole.Id,
                PrivilegeId = manageLinguisticAssetsInAllProjectsPrivilege.Id,
            };
            var administratorManageAllGlossariesRolePrivilege = new RolePrivilege
            {
                Id = Guid.NewGuid(),
                RoleId = administratorRole.Id,
                PrivilegeId = manageAllGlossariesPrivilege.Id,
            };
            var administratorManageAllTmsRolePrivilege = new RolePrivilege
            {
                Id = Guid.NewGuid(),
                RoleId = administratorRole.Id,
                PrivilegeId = manageAllTmsPrivilege.Id,
            };
            var administratorSuggestTermsWithoutSpecifyingAGlossaryRolePrivilege = new RolePrivilege
            {
                Id = Guid.NewGuid(),
                RoleId = administratorRole.Id,
                PrivilegeId = suggestTermsWithoutSpecifyingAGlossaryPrivilege.Id,
            };
            var administratorManageProjectTemplatesRolePrivilege = new RolePrivilege
            {
                Id = Guid.NewGuid(),
                RoleId = administratorRole.Id,
                PrivilegeId = manageProjectTemplatesPrivilege.Id,
            };
            var administratorManageOrdersRolePrivilege = new RolePrivilege
            {
                Id = Guid.NewGuid(),
                RoleId = administratorRole.Id,
                PrivilegeId = manageOrdersPrivilege.Id,
            };
            var administratorManageServiceTemplatesRolePrivilege = new RolePrivilege
            {
                Id = Guid.NewGuid(),
                RoleId = administratorRole.Id,
                PrivilegeId = manageServiceTemplatesPrivilege.Id,
            };

            var projectManagerManageClientsAndProjectTagsRolePrivilege = new RolePrivilege
            {
                Id = Guid.NewGuid(),
                RoleId = projectManagerRole.Id,
                PrivilegeId = manageClientsAndProjectTagsPrivilege.Id,
            };
            var projectManagerCreateAnyProjectsRolePrivilege = new RolePrivilege
            {
                Id = Guid.NewGuid(),
                RoleId = projectManagerRole.Id,
                PrivilegeId = createAnyProjectsPrivilege.Id,
            };
            var projectManagerViewAllProjectsRolePrivilege = new RolePrivilege
            {
                Id = Guid.NewGuid(),
                RoleId = projectManagerRole.Id,
                PrivilegeId = viewAllProjectsPrivilege.Id,
            };
            var projectManagerManageLinguisticAssetsInAllProjectsRolePrivilege = new RolePrivilege
            {
                Id = Guid.NewGuid(),
                RoleId = projectManagerRole.Id,
                PrivilegeId = manageLinguisticAssetsInAllProjectsPrivilege.Id,
            };
            var projectManagerManageAllGlossariesRolePrivilege = new RolePrivilege
            {
                Id = Guid.NewGuid(),
                RoleId = projectManagerRole.Id,
                PrivilegeId = manageAllGlossariesPrivilege.Id,
            };
            var projectManagerManageAllTmsRolePrivilege = new RolePrivilege
            {
                Id = Guid.NewGuid(),
                RoleId = projectManagerRole.Id,
                PrivilegeId = manageAllTmsPrivilege.Id,
            };
            var projectManagerSuggestTermsWithoutSpecifyingAGlossaryRolePrivilege = new RolePrivilege
            {
                Id = Guid.NewGuid(),
                RoleId = projectManagerRole.Id,
                PrivilegeId = suggestTermsWithoutSpecifyingAGlossaryPrivilege.Id,
            };
            var projectManagerManageProjectTemplatesRolePrivilege = new RolePrivilege
            {
                Id = Guid.NewGuid(),
                RoleId = projectManagerRole.Id,
                PrivilegeId = manageProjectTemplatesPrivilege.Id,
            };
            var projectManagerManageOrdersRolePrivilege = new RolePrivilege
            {
                Id = Guid.NewGuid(),
                RoleId = projectManagerRole.Id,
                PrivilegeId = manageOrdersPrivilege.Id,
            };

            var resourceManagerManageAllGlossariesRolePrivilege = new RolePrivilege
            {
                Id = Guid.NewGuid(),
                RoleId = resourceManagerRole.Id,
                PrivilegeId = manageAllGlossariesPrivilege.Id,
            };
            var resourceManagerManageAllTmsRolePrivilege = new RolePrivilege
            {
                Id = Guid.NewGuid(),
                RoleId = resourceManagerRole.Id,
                PrivilegeId = manageAllTmsPrivilege.Id,
            };
            var resourceManagerSuggestTermsWithoutSpecifyingAGlossaryRolePrivilege = new RolePrivilege
            {
                Id = Guid.NewGuid(),
                RoleId = resourceManagerRole.Id,
                PrivilegeId = suggestTermsWithoutSpecifyingAGlossaryPrivilege.Id,
            };

            var localizationTeamManageAllGlossariesRolePrivilege = new RolePrivilege
            {
                Id = Guid.NewGuid(),
                RoleId = localizationTeamRole.Id,
                PrivilegeId = manageAllGlossariesPrivilege.Id,
            };
            var localizationTeamCreateAnyProjectsRolePrivilege = new RolePrivilege
            {
                Id = Guid.NewGuid(),
                RoleId = localizationTeamRole.Id,
                PrivilegeId = createAnyProjectsPrivilege.Id,
            };
            var localizationTeamViewAllProjectsRolePrivilege = new RolePrivilege
            {
                Id = Guid.NewGuid(),
                RoleId = localizationTeamRole.Id,
                PrivilegeId = viewAllProjectsPrivilege.Id,
            };
            var localizationTeamManageAllTmsRolePrivilege = new RolePrivilege
            {
                Id = Guid.NewGuid(),
                RoleId = localizationTeamRole.Id,
                PrivilegeId = manageAllTmsPrivilege.Id,
            };
            var localizationTeamManageLinguisticAssetsInAllProjectsRolePrivilege = new RolePrivilege
            {
                Id = Guid.NewGuid(),
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
            var admin = new User
            {
                Id = Guid.NewGuid(),
                Username = "admin.dotnetstarter@yopmail.com",
                Firstname = "Admin",
                Lastname = "Yopmail",
                Password = BCrypt.Net.BCrypt.HashPassword("Abc!2345"),
                PhoneNumber = "0333333333",
                Gender = Gender.Male,
                CreatedDate = now,
                CreatedBy = "System",
                UpdatedDate = now,
                UpdatedBy = "System",
                Status = Status.Active,
                RoleId = administratorRole.Id,
            };

            modelBuilder.Entity<User>().HasData(admin);
            #endregion

            #region UserPrivilege
            var adminManageUsersUserPrivilege = new UserPrivilege
            {
                Id = Guid.NewGuid(),
                UserId = admin.Id,
                PrivilegeId = manageUsersPrivilege.Id,
            };
            var adminManagePaidLinguisticAssetsUserPrivilege = new UserPrivilege
            {
                Id = Guid.NewGuid(),
                UserId = admin.Id,
                PrivilegeId = managePaidLinguisticAssetsPrivilege.Id,
            };
            var adminManageVendorsUserPrivilege = new UserPrivilege
            {
                Id = Guid.NewGuid(),
                UserId = admin.Id,
                PrivilegeId = manageVendorsPrivilege.Id,
            };
            var adminManageClientsAndProjectTagsUserPrivilege = new UserPrivilege
            {
                Id = Guid.NewGuid(),
                UserId = admin.Id,
                PrivilegeId = manageClientsAndProjectTagsPrivilege.Id,
            };
            var adminCreateAnyProjectsUserPrivilege = new UserPrivilege
            {
                Id = Guid.NewGuid(),
                UserId = admin.Id,
                PrivilegeId = createAnyProjectsPrivilege.Id,
            };
            var adminViewAllProjectsUserPrivilege = new UserPrivilege
            {
                Id = Guid.NewGuid(),
                UserId = admin.Id,
                PrivilegeId = viewAllProjectsPrivilege.Id,
            };
            var adminManageLinguisticAssetsInAllProjectsUserPrivilege = new UserPrivilege
            {
                Id = Guid.NewGuid(),
                UserId = admin.Id,
                PrivilegeId = manageLinguisticAssetsInAllProjectsPrivilege.Id,
            };
            var adminManageAllGlossariesUserPrivilege = new UserPrivilege
            {
                Id = Guid.NewGuid(),
                UserId = admin.Id,
                PrivilegeId = manageAllGlossariesPrivilege.Id,
            };
            var adminManageAllTmsUserPrivilege = new UserPrivilege
            {
                Id = Guid.NewGuid(),
                UserId = admin.Id,
                PrivilegeId = manageAllTmsPrivilege.Id,
            };
            var adminSuggestTermsWithoutSpecifyingAGlossaryUserPrivilege = new UserPrivilege
            {
                Id = Guid.NewGuid(),
                UserId = admin.Id,
                PrivilegeId = suggestTermsWithoutSpecifyingAGlossaryPrivilege.Id,
            };
            var adminManageProjectTemplatesUserPrivilege = new UserPrivilege
            {
                Id = Guid.NewGuid(),
                UserId = admin.Id,
                PrivilegeId = manageProjectTemplatesPrivilege.Id,
            };
            var adminManageOrdersUserPrivilege = new UserPrivilege
            {
                Id = Guid.NewGuid(),
                UserId = admin.Id,
                PrivilegeId = manageOrdersPrivilege.Id,
            };
            var adminManageServiceTemplatesUserPrivilege = new UserPrivilege
            {
                Id = Guid.NewGuid(),
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
