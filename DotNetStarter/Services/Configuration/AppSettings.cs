namespace DotNetStarter.Services.Configuration
{
    public class AppSettings
    {
        public JwtSettings Jwt { get; set; }
        public OtpSettings Otp { get; set; }
        public InvitationSettings Invitation { get; set; }
        public ConnectionStringsSettings ConnectionStrings { get; set; }
        public EmailSettings Email { get; set; }
        public UrlsSettings Urls { get; set; }
        public AzureStorageSettings AzureStorageSettings { get; set; }
        public AccountSettings Account { get; set; }
        public TotpSettings Totp { get; set; }
    }

    public class TotpSettings
    {
        public int TotpSecretLength { get; set; }
        public int TotpBackupCodeQuantity { get; set; }
        public int TotpBackupCodeLength { get; set; }
    }

    public class AccountSettings
    {
        public int PermanentDeleteAccountDuration { get; set; }
    }

    public class JwtSettings
    {
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string Key { get; set; }
        public int TokenLifetimeDuration { get; set; }
        public int RefreshTokenLifetimeDuration { get; set; }
    }

    public class OtpSettings
    {
        public int ActiveOtpLifetimeDuration { get; set; }
        public int InvitationOtpLifetimeDuration { get; set; }
    }

    public class InvitationSettings
    {
        public int LifeTimeDurartion { get; set; }
    }

    public class ConnectionStringsSettings
    {
        public string DotNetStarter { get; set; }
    }

    public class EmailSettings
    {
        public CommonSettings Common { get; set; }
        public SendGridSettings SendGrid { get; set; }
    }

    public class CommonSettings
    {
        public string FromEmail { get; set; }
        public string FromName { get; set; }
    }

    public class SendGridSettings
    {
        public string ApiKey { get; set; }
        public TemplateIdsSettings TemplateIds { get; set; }
    }

    public class TemplateIdsSettings
    {
        public string ResetPassword { get; set; }
        public string ActivateEmail { get; set; }
        public string RequestChangeEmail { get; set; }
        public string SendNotification { get; set; }
        public string ChangePassword { get; set; }
        public string InviteTalent { get; set; }
        public string ResendOtp { get; set; }
        public string MoveCard { get; set; }
        public string CreateCard { get; set; }
        public string AdminResetPassword { get; set; }
        public string ExportFile { get; set; }
        public string RecoverAccount { get; set; }
    }

    public class UrlsSettings
    {
        public string BasePortal { get; set; }
    }

    public class AzureStorageSettings
    {
        public string ConnectionString { get; set; }
        public string ContainerName { get; set; }
    }
}
