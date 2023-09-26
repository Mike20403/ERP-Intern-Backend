using DotNetStarter.Entities;
using DotNetStarter.Repositories;

namespace DotNetStarter.Database.UnitOfWork
{
    public interface IDotNetStarterUnitOfWork : IUnitOfWork
    {
        string? DataSource { get; }

        GenericRepository<DotNetStarterDbContext, User> UserRepository { get; }

        GenericRepository<DotNetStarterDbContext, Otp> OtpRepository { get; }

        GenericRepository<DotNetStarterDbContext, Role> RoleRepository { get; }

        GenericRepository<DotNetStarterDbContext, Privilege> PrivilegeRepository { get; }

        GenericRepository<DotNetStarterDbContext, AuthToken> AuthTokenRepository { get; }
    }
}
