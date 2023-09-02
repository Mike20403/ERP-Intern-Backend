namespace DotNetStarter.Services.Email
{
    public interface IEmailService
    {
        Task SendResetPasswordEmailAsync(string email, string firstName, string code);
    }
}
