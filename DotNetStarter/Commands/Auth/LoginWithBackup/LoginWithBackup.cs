using DotNetStarter.Commands.Auth.Login;
using MediatR;

namespace DotNetStarter.Commands.Auth.LoginWithBackup
{
    public sealed class LoginWithBackup : IRequest<LoginResponse>
    {
        public string Username { get; }

        public string BackupCode { get; }

        public LoginWithBackup(string username, string backupCode) {
            Username = username;
            BackupCode = backupCode;
        }
    }
}
