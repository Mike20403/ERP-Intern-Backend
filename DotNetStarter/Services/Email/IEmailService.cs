namespace DotNetStarter.Services.Email
{
    public interface IEmailService
    {
        Task SendResetPasswordEmailAsync(string email, string firstName, string code);
        
        Task SendChangeEmailRequestAsync(string currentEmail, string newEmail, string firstName, string code);

        Task SendActivateAccountAsync(string email, string firstName, string code);

        Task SendNotificationAsync(string email, string firstName, string message);

        Task SendCardMovedAsync(string email, string firstName, string stageName, string cardName);

        Task SendCardCreatedAsync(string email, string firstName, string stageName, string cardName);

        Task SendChangePasswordEmailAsync(string email, string firstName, string lastName);

        Task SendInvitationEmailAsync(string email, Guid invitationId, string projectName, Guid projectId, string inviter, bool isExists, string? code = null);

        Task ResendOtp(string email, string firstName, string code);
    }
}
