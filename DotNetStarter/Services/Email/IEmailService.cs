namespace DotNetStarter.Services.Email
{
    public interface IEmailService
    {
        Task SendResetPasswordEmailAsync(string email, string firstName, string code);
        
        Task SendChangeEmailRequestAsync(string currentEmail, string newEmail, string firstName, string code);

        Task SendActivateAccountAsync(string email, string firstName, string code);

        Task SendNotificationAsync(string email, string firstName, string message);

        Task SendChangePasswordEmailAsync(string email, string firstName, string lastName);
    }
}
