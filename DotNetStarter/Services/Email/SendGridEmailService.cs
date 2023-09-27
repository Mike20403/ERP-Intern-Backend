using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace DotNetStarter.Services.Email
{
    public class SendGridEmailService : IEmailService
    {
        private readonly IConfiguration _configuration;

        public SendGridEmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendChangePasswordEmailAsync(string email, string firstName, string lastName)
        {
            var templateId = _configuration["Email:SendGrid:TemplateIds:ChangePassword"];
            var templateData = new Dictionary<string, string>
            {
                { "firstName", firstName },
                { "lastName", lastName },
            };

            await SendEmailAsync(email, templateId!, templateData);
        }

        public async Task SendResetPasswordEmailAsync(string email, string firstName, string code)
        {
            var templateId = _configuration["Email:SendGrid:TemplateIds:ResetPassword"];
            var templateData = new Dictionary<string, string>
            {
                { "firstName", firstName },
                { "url", $"{_configuration["Urls:BasePortal"]}/auth/reset-password?username={email}&code={code}" },
            };

            await SendEmailAsync(email, templateId!, templateData);
        }

        private async Task SendEmailAsync(string email, string templateId, object templateData)
        {
            var apiKey = _configuration["Email:SendGrid:ApiKey"];
            var client = new SendGridClient(apiKey);

            var from = new EmailAddress(_configuration["Email:Common:FromEmail"], _configuration["Email:Common:FromName"]);
            EmailAddress to = new EmailAddress(email);

            var msg = MailHelper.CreateSingleTemplateEmail(from, to, templateId, templateData);
            await client.SendEmailAsync(msg);
        }
    }
}
