using DotNetStarter.Common;
using DotNetStarter.Common.Enums;
using DotNetStarter.Database.UnitOfWork;
using DotNetStarter.Extensions;
using DotNetStarter.Notifications.Users.ResetPasswordByAdminRequested;
using DotNetStarter.Notifications.Users.UserCredentialChanged;
using DotNetStarter.Services.Password;

namespace DotNetStarter.Commands.Users.ResetPassword
{
    public sealed class ResetPasswordHandler : BaseRequestHandler<ResetPassword>
    {
        private readonly IDotNetStarterUnitOfWork _unitOfWork;
        private readonly IPasswordService _passwordService;

        public ResetPasswordHandler(
            IServiceProvider serviceProvider,
            IPasswordService passwordService,
            IDotNetStarterUnitOfWork unitOfWork
        ) : base(serviceProvider)
        {
            _unitOfWork = unitOfWork;
            _passwordService = passwordService;
        }
        public override async Task Process(ResetPassword request, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.UserRepository.FindAsync(filter: u => u.Id == request.UserId);

            var password = _passwordService.GenerateRandomPassword();
            user!.Password = BCrypt.Net.BCrypt.HashPassword(password);
            user.Status = Status.ChangingPasswordRequired;

            await _unitOfWork.UserRepository.UpdateAsync(user!);
            await _unitOfWork.SaveChangesAsync();

            new PasswordReset(user.Username, user.Firstname, password).Enqueue();
            new UserCredentialChanged(user.Id).Enqueue();
        }
    }
}
