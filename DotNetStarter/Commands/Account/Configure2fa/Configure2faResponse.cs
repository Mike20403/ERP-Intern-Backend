namespace DotNetStarter.Commands.Account.Configure2fa
{
    public sealed class Configure2faResponse
    {
        public string? TwoFactorsSecret { get; }

        public string? TwoFactorsQr { get; }

        public Configure2faResponse(string? twoFactorsQr, string? twoFactorsSecret)
        {
            TwoFactorsQr = twoFactorsQr;
            TwoFactorsSecret = twoFactorsSecret;
        }
    }
}
