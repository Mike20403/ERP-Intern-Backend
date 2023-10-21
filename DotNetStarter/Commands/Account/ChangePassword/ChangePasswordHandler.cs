using DotNetStarter.Common;
using DotNetStarter.Database.UnitOfWork;
using DotNetStarter.Extensions;
using DotNetStarter.Notifications.Users.PasswordChanged;
using DotNetStarter.Notifications.Users.UserCredentialChanged;

namespace DotNetStarter.Commands.Account.ChangePassword
{
    public sealed class ChangePasswordHandler : BaseRequestHandler<ChangePassword>
    {
        private readonly IDotNetStarterUnitOfWork _unitOfWork;

        public ChangePasswordHandler(
            IServiceProvider serviceProvider, 
            IDotNetStarterUnitOfWork unitOfWork
        ) : base(serviceProvider)
        {
            _unitOfWork = unitOfWork;
        }
        public override async Task Process(ChangePassword request, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.UserRepository.FindAsync(filter: u => u.Id == request.UserId);
            user!.Password = BCrypt.Net.BCrypt.HashPassword(request.NewPassword);
            await _unitOfWork.UserRepository.UpdateAsync(user!);

            await _unitOfWork.SaveChangesAsync();

            new PasswordChanged(user.Username, user.Firstname, user.Lastname).Enqueue();
            new UserCredentialChanged(user.Id).Enqueue();
        }
    }
}
