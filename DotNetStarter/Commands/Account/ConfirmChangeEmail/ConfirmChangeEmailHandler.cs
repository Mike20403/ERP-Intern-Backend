using DotNetStarter.Common;
using DotNetStarter.Common.Enums;
using DotNetStarter.Database.UnitOfWork;
using DotNetStarter.Entities;
using DotNetStarter.Extensions;
using DotNetStarter.Notifications.Users.EmailChanged;
using DotNetStarter.Notifications.Users.UserCredentialChanged;
using DotNetStarter.Services.Configuration;
using Microsoft.Extensions.Options;

namespace DotNetStarter.Commands.Account.ConfirmChangeEmail
{
    public sealed class ConfirmChangeEmailHandler : BaseRequestHandler<ConfirmChangeEmail>
    {
        private readonly IDotNetStarterUnitOfWork _unitOfWork;

        private readonly AppSettings _appSettings;

        public ConfirmChangeEmailHandler(
            IServiceProvider serviceProvider, 
            IDotNetStarterUnitOfWork unitOfWork,
            IOptions<AppSettings> appSettings
        ) : base(serviceProvider)
        {
            _unitOfWork = unitOfWork;
            _appSettings = appSettings.Value;
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
                Type = OtpType.ActivateAccount,
                Code = new Random().Next(0, 1000000).ToString("D6"),
                IsUsed = false,
                ExpiredDate = DateTime.Now.AddMinutes(_appSettings.Otp.ActiveOtpLifetimeDuration!),
            };
            
            await _unitOfWork.OtpRepository.CreateAsync(activeOtp);
            await _unitOfWork.OtpRepository.UpdateAsync(otp);
            await _unitOfWork.UserRepository.UpdateAsync(user!);
            await _unitOfWork.SaveChangesAsync();

            new EmailChanged(oldEmail, user.Username, user.Firstname, activeOtp.Code).Enqueue();
            new UserCredentialChanged(user.Id).Enqueue();
        }
    }
}
