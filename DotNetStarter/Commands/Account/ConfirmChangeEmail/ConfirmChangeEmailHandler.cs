using DotNetStarter.Common;
using DotNetStarter.Common.Enums;
using DotNetStarter.Database.UnitOfWork;
using DotNetStarter.Entities;
using DotNetStarter.Services.Email;
using Microsoft.Extensions.Configuration;

namespace DotNetStarter.Commands.Account.ConfirmChangeEmail
{
    public sealed class ConfirmChangeEmailHandler : BaseRequestHandler<ConfirmChangeEmail>
    {
        private readonly IDotNetStarterUnitOfWork _unitOfWork;

        private readonly IEmailService _emailService;

        private readonly IConfiguration _configuration;

        public ConfirmChangeEmailHandler(IServiceProvider serviceProvider, IDotNetStarterUnitOfWork unitOfWork, IEmailService emailService, IConfiguration configuration) : base(serviceProvider)
        {
            _unitOfWork = unitOfWork;
            _emailService = emailService;
            _configuration = configuration;
        }

        public override async Task Process(ConfirmChangeEmail request, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.UserRepository.
                FindAsync(filter: u => u.Id == request.UserId);
            
            var otp = await _unitOfWork.OtpRepository.
                FindAsync(filter: o => o.Code == request.ActiveCode && o.UserId == user!.Id);

            var oldEmail = user!.Username;

            otp!.IsUsed = true;
            user!.Username = request.Email;
            user!.Status = Status.Inactive;

            var activeOtp = new Otp
            {
                UserId = user!.Id,
                Type = OtpType.ActivateEmail,
                Code = new Random().Next(0, 1000000).ToString("D6"),
                IsUsed = false,
                ExpiredDate = DateTime.Now.AddMinutes(int.Parse(_configuration["Otp:ActiveOtpLifetimeDuration"]!)),
            };

            await _unitOfWork.OtpRepository.CreateAsync(activeOtp);
            await _unitOfWork.OtpRepository.UpdateAsync(otp);
            await _unitOfWork.UserRepository.UpdateAsync(user!);
            await _unitOfWork.SaveChangesAsync();

            // Send notification to old email - Send active code to new email
            string message = "Congratulation! you have changed your email, this email will no longer available";
            await _emailService.SendNotificationAsync(oldEmail, user.Firstname, message);
            await _emailService.SendActivateAccountAsync(request.Email, user.Firstname, activeOtp.Code);
        }
    }
}
