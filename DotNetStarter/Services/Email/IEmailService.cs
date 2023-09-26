namespace DotNetStarter.Services.Email
{
    public interface IEmailService
    {
        Task SendResetPasswordEmailAsync(string email, string firstName, string code);
        
        Task SendChangeEmailRequestAsync(string currentEmail, string newEmail, string firstName, string code);

        Task SendActivateEmailAsync(string email, string code);
    }
}
