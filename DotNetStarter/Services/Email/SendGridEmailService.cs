using DotNetStarter.Services.Configuration;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace DotNetStarter.Services.Email
{
    public class SendGridEmailService : IEmailService
    {
        private readonly AppSettings _appSettings;

        public SendGridEmailService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        public async Task SendChangePasswordEmailAsync(string email, string firstName, string lastName)
        {
            var templateId = _appSettings.Email.SendGrid.TemplateIds.ChangePassword;
            var templateData = new Dictionary<string, string>
            {
                { "firstName", firstName },
                { "lastName", lastName },
            };

            await SendEmailAsync(email, templateId!, templateData);
        }

        public async Task SendResetPasswordEmailAsync(string email, string firstName, string code)
        {
            var templateId = _appSettings.Email.SendGrid.TemplateIds.ResetPassword;
            var templateData = new Dictionary<string, string>
            {
                { "firstName", firstName },
                { "url", $"{_appSettings.Urls.BasePortal}/auth/reset-password?username={email}&code={code}" },
            };

            await SendEmailAsync(email, templateId!, templateData);
        }

        public async Task SendAdminResetPasswordEmailAsync(string email, string firstName, string password)
        {
            var templateId = _appSettings.Email.SendGrid.TemplateIds.AdminResetPassword;
            var templateData = new Dictionary<string, string>
            {
                { "firstName", firstName },
                { "password", password },
            };

            await SendEmailAsync(email, templateId!, templateData);
        }

        public async Task SendChangeEmailRequestAsync(string currentEmail, string newEmail, string firstName, string code)
        {
            var templateId = _appSettings.Email.SendGrid.TemplateIds.RequestChangeEmail;
            var templateData = new Dictionary<string, string>
            {
                { "firstName", firstName },
                { "newEmail", newEmail },
                { "url", $"{_appSettings.Urls.BasePortal}/account/change-email?email={newEmail}&code={code}" },
            };

            await SendEmailAsync(currentEmail, templateId!, templateData);
        }

        public async Task SendRecoverAccountEmailAsync(string email, string firstName, string code)
        {
            var templateId = _appSettings.Email.SendGrid.TemplateIds.RecoverAccount;
            var templateData = new Dictionary<string, string>
            {
                { "firstName", firstName },
                { "email", email },
                { "url", $"{_appSettings.Urls.BasePortal}/account/recover-account?email={email}&code={code}" },
            };

            await SendEmailAsync(email, templateId!, templateData);
        }

        public async Task SendActivateAccountAsync(string email, string firstName, string code)
        {
            var templateId = _appSettings.Email.SendGrid.TemplateIds.ActivateEmail;
            var templateData = new Dictionary<string, string>
            {
                { "firstName", firstName },
                { "url", $"{_appSettings.Urls.BasePortal}/auth/activate-account?email={email}&code={code}" },
            };
            await SendEmailAsync(email, templateId!, templateData);
        }

        public async Task SendNotificationAsync(string email, string firstName, string message)
        {
            var templateId = _appSettings.Email.SendGrid.TemplateIds.SendNotification;
            var templateData = new Dictionary<string, string>
            {
                { "firstName", firstName },
                { "message", message },
            };
            await SendEmailAsync(email, templateId!, templateData);
        }

        public async Task SendCardMovedAsync(List<CardRecipient> cardRecipients)
        {
            var templateId = _appSettings.Email.SendGrid.TemplateIds.CreateCard;

            foreach (var recipient in cardRecipients)
            {
                var templateData = new Dictionary<string, string>
                {
                    { "firstName", recipient.FirstName },
                    { "stageName", recipient.StageName },
                    { "cardName", recipient.CardName },
                };

                await SendEmailAsync(recipient.Email, templateId!, templateData);
            }
        }

        public async Task SendCardCreatedAsync(List<CardRecipient> cardRecipients)
        {
            var templateId = _appSettings.Email.SendGrid.TemplateIds.CreateCard;

            foreach (var recipient in cardRecipients)
            {
                var templateData = new Dictionary<string, string>
                {
                    { "firstName", recipient.FirstName },
                    { "stageName", recipient.StageName },
                    { "cardName", recipient.CardName },
                };

                await SendEmailAsync(recipient.Email, templateId!, templateData);
            }
        }

        public async Task SendInvitationEmailAsync(string email, Guid invitationId, string projectName, Guid projectId, string inviter, bool isExists, string? code)
        {
            var templateId = _appSettings.Email.SendGrid.TemplateIds.InviteTalent;

            var templateData = isExists
                ? new Dictionary<string, string>
                {
                    { "projectName", projectName },
                    { "inviter", inviter },
                    { "url", $"{_appSettings.Urls.BasePortal}/invitations?invitationId={invitationId}&email={email}&projectId={projectId}" },
                }
                : new Dictionary<string, string>
                {
                    { "projectName", projectName },
                    { "inviter", inviter },
                    { "url", $"{_appSettings.Urls.BasePortal}/auth/register-talent?email={email}&invitation={invitationId}&projectId={projectId}&code={code}" },
                };

            await SendEmailAsync(email, templateId!, templateData);
        }

        public async Task ResendOtp(string email, string firstName, string code)
        {
            var templateId = _appSettings.Email.SendGrid.TemplateIds.ResendOtp;
            var templateData = new Dictionary<string, string>
            {
                { "firstName", firstName },
                { "code", code },
            };
            await SendEmailAsync(email, templateId!, templateData);
        }

        public async Task SendFileDataAsync(string email, string firstName, List<FileAttachmentInfo> attachments)
        {
            var templateId = _appSettings.Email.SendGrid.TemplateIds.ExportFile;
            var templateData = new Dictionary<string, object>
                {
                    { "firstName", firstName },
                };
            await SendEmailAsync(email, templateId!, templateData, attachments);
        }

        private async Task SendEmailAsync(string email, string templateId, object templateData, List<FileAttachmentInfo>? attachments = null)
        {
            var apiKey = _appSettings.Email.SendGrid.ApiKey;
            var client = new SendGridClient(apiKey);

            var from = new EmailAddress(_appSettings.Email.Common.FromEmail, _appSettings.Email.Common.FromName);
            EmailAddress to = new EmailAddress(email);

            var msg = MailHelper.CreateSingleTemplateEmail(from, to, templateId, templateData);

            if (attachments is not null)
            {
                var sgAttachments = attachments.Select(attachmentInfo =>
                    new Attachment
                    {
                        Content = Convert.ToBase64String(attachmentInfo.Data),
                        Filename = attachmentInfo.FileName,
                        Type = attachmentInfo.ContentType,
                    }).ToList();

                msg.AddAttachments(sgAttachments);
            }

            await client.SendEmailAsync(msg);
        }  
    }
}
