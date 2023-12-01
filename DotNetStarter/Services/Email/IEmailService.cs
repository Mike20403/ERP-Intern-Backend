namespace DotNetStarter.Services.Email
{
    public interface IEmailService
    {
        Task SendResetPasswordEmailAsync(string email, string firstName, string code);

        Task SendAdminResetPasswordEmailAsync(string email, string firstName, string password);

        Task SendChangeEmailRequestAsync(string currentEmail, string newEmail, string firstName, string code);

        Task SendActivateAccountAsync(string email, string firstName, string code);

        Task SendNotificationAsync(string email, string firstName, string message);

        Task SendCardMovedAsync(List<CardRecipient> cardRecipients);

        Task SendCardCreatedAsync(List<CardRecipient> cardRecipients);

        Task SendChangePasswordEmailAsync(string email, string firstName, string lastName);

        Task SendInvitationEmailAsync(string email, Guid invitationId, string projectName, Guid projectId, string inviter, bool isExists, string? code = null);

        Task ResendOtp(string email, string firstName, string code);

        Task SendFileDataAsync(string email, string firstName, List<FileAttachmentInfo> attachments);

        Task SendRecoverAccountEmailAsync(string email, string firstName, string code);
    }
}
