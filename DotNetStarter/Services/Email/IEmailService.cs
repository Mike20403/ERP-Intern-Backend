﻿namespace DotNetStarter.Services.Email
{
    public interface IEmailService
    {
        Task SendResetPasswordEmailAsync(string email, string firstName, string code);
        
        Task SendChangeEmailRequestAsync(string currentEmail, string newEmail, string firstName, string code);

        Task SendActivateAccountAsync(string email, string firstName, string code);

        Task SendNotificationAsync(string email, string firstName, string message);

        Task SendChangePasswordEmailAsync(string email, string firstName, string lastName);

        Task SendInvitationEmailAsync(string email, Guid invitationId, string projectName, string inviter, bool isExists, string? code = null);
    }
}
