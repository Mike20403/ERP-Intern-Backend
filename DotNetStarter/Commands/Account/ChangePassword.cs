using MediatR;

namespace DotNetStarter.Commands.Account
{
    public sealed class ChangePassword : IRequest
    {
        public Guid UserId { get; }

        public string CurrentPassword { get; }

        public string NewPassword { get; }

        public ChangePassword(Guid userId, string currentPassword, string newPassword)
        {
            UserId = userId;
            CurrentPassword = currentPassword;
            NewPassword = newPassword;
        }
    }
}
