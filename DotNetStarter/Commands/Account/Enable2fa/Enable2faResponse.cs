namespace DotNetStarter.Commands.Account.Enable2fa
{
    public sealed class Enable2faResponse
    {
        public List<string>? TwoFactorsBackupCode { get; }

        public Enable2faResponse(List<string> twoFactorsBackupCode) { 
            TwoFactorsBackupCode = twoFactorsBackupCode;
        }
    }
}
