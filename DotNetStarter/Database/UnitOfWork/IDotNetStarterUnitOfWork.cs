using DotNetStarter.Entities;
using DotNetStarter.Repositories;

namespace DotNetStarter.Database.UnitOfWork
{
    public interface IDotNetStarterUnitOfWork : IUnitOfWork
    {
        string? DataSource { get; }

        GenericRepository<DotNetStarterDbContext, User> UserRepository { get; }

        GenericRepository<DotNetStarterDbContext, Talent> TalentRepository { get; }

        GenericRepository<DotNetStarterDbContext, Otp> OtpRepository { get; }

        GenericRepository<DotNetStarterDbContext, Role> RoleRepository { get; }

        GenericRepository<DotNetStarterDbContext, Privilege> PrivilegeRepository { get; }

        GenericRepository<DotNetStarterDbContext, AuthToken> AuthTokenRepository { get; }

        GenericRepository<DotNetStarterDbContext, Project> ProjectRepository { get; }

        GenericRepository<DotNetStarterDbContext, Stage> StageRepository { get; }

        GenericRepository<DotNetStarterDbContext, Card> CardRepository { get; }

        GenericRepository<DotNetStarterDbContext, Attachment> AttachmentRepository { get; }

        GenericRepository<DotNetStarterDbContext, Invitation> InvitationRepository { get; }

        GenericRepository<DotNetStarterDbContext, Payment> PaymentRepository  { get; }
    }
}
