using DotNetStarter.Common;
using DotNetStarter.Common.Enums;
using DotNetStarter.Database.UnitOfWork;
using DotNetStarter.Entities;
using DotNetStarter.Extensions;
using DotNetStarter.Notifications.Users.EmailChanged;
using DotNetStarter.Notifications.Users.UserCredentialChanged;
using Microsoft.Extensions.Configuration;

namespace DotNetStarter.Commands.Account.ConfirmChangeEmail
{
    public sealed class ConfirmChangeEmailHandler : BaseRequestHandler<ConfirmChangeEmail>
    {
        private readonly IDotNetStarterUnitOfWork _unitOfWork;

        private readonly IConfiguration _configuration;

        public ConfirmChangeEmailHandler(
            IServiceProvider serviceProvider, 
            IDotNetStarterUnitOfWork unitOfWork,
            IConfiguration configuration
        ) : base(serviceProvider)
        {
            _unitOfWork = unitOfWork;
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
                Type = OtpType.ActivateAccount,
                Code = new Random().Next(0, 1000000).ToString("D6"),
                IsUsed = false,
                ExpiredDate = DateTime.Now.AddMinutes(int.Parse(_configuration["Otp:ActiveOtpLifetimeDuration"]!)),
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
