using Microsoft.EntityFrameworkCore;
using DotNetStarter.Entities;
using DotNetStarter.Repositories;

namespace DotNetStarter.Database.UnitOfWork
{
    public class DotNetStarterUnitOfWork : IDotNetStarterUnitOfWork, IDisposable
    {
        private readonly DotNetStarterDbContext _context;

        public string? DataSource { get; private set; }

        public GenericRepository<DotNetStarterDbContext, User> UserRepository { get; private set; }

        public GenericRepository<DotNetStarterDbContext, Talent> TalentRepository { get; private set; }

        public GenericRepository<DotNetStarterDbContext, Otp> OtpRepository { get; private set; }

        public GenericRepository<DotNetStarterDbContext, Role> RoleRepository { get; private set; }

        public GenericRepository<DotNetStarterDbContext, Privilege> PrivilegeRepository { get; private set; }

        public GenericRepository<DotNetStarterDbContext, AuthToken> AuthTokenRepository { get; private set; }

        public GenericRepository<DotNetStarterDbContext, Project> ProjectRepository { get; private set; }

        public GenericRepository<DotNetStarterDbContext, Stage> StageRepository { get; private set; }

        public GenericRepository<DotNetStarterDbContext, Card> CardRepository { get; private set; }

        public GenericRepository<DotNetStarterDbContext, Attachment> AttachmentRepository { get; private set; }

        public GenericRepository<DotNetStarterDbContext, Invitation> InvitationRepository { get; private set; }

        public GenericRepository<DotNetStarterDbContext, Payment> PaymentRepository { get; private set; }

        public GenericRepository<DotNetStarterDbContext, Comment> CommentRepository { get; private set; }

        public DotNetStarterUnitOfWork(DotNetStarterDbContext context)
        {
            _context = context;

            DataSource = context.Database.GetDbConnection().DataSource;
            UserRepository = new GenericRepository<DotNetStarterDbContext, User>(_context);
            TalentRepository = new GenericRepository<DotNetStarterDbContext, Talent>(_context);
            OtpRepository = new GenericRepository<DotNetStarterDbContext, Otp>(_context);
            RoleRepository = new GenericRepository<DotNetStarterDbContext, Role>(_context);
            PrivilegeRepository = new GenericRepository<DotNetStarterDbContext, Privilege>(_context);
            AuthTokenRepository = new GenericRepository<DotNetStarterDbContext, AuthToken>(_context);
            ProjectRepository = new GenericRepository<DotNetStarterDbContext, Project>(_context);
            StageRepository = new GenericRepository<DotNetStarterDbContext, Stage>(_context);
            CardRepository = new GenericRepository<DotNetStarterDbContext, Card>(_context);
            AttachmentRepository = new GenericRepository<DotNetStarterDbContext, Attachment>(_context);
            InvitationRepository = new GenericRepository<DotNetStarterDbContext, Invitation>(_context);
            PaymentRepository = new GenericRepository<DotNetStarterDbContext, Payment>(_context);
            CommentRepository = new GenericRepository<DotNetStarterDbContext, Comment>(_context);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
