using DotNetStarter.Common;
using DotNetStarter.Common.Enums;
using DotNetStarter.Database.UnitOfWork;
using DotNetStarter.Entities;
using DotNetStarter.Extensions;
using DotNetStarter.Notifications.Users.ChangeEmailRequested;
using DotNetStarter.Services.Configuration;
using Microsoft.Extensions.Options;

namespace DotNetStarter.Commands.Account.ChangeEmailRequires
{
    public sealed class RequestChangeEmailHandler : BaseRequestHandler<RequestChangeEmail>
    {
        private readonly IDotNetStarterUnitOfWork _unitOfWork;

        private readonly AppSettings _appSettings;

        public RequestChangeEmailHandler(IServiceProvider serviceProvider, IDotNetStarterUnitOfWork unitOfWork, IOptions<AppSettings> appSettings) : base(serviceProvider)
        {
            _unitOfWork = unitOfWork;
            _appSettings = appSettings.Value;
        }

        public override async Task Process(RequestChangeEmail request, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.UserRepository.FindAsync(filter: u => u.Id == request.UserId);

            var otp = new Otp
            {
                UserId = user!.Id,
                Type = OtpType.ChangeEmail,
                Code = new Random().Next(0, 1000000).ToString("D6"),
                IsUsed = false,
                ExpiredDate = DateTime.Now.AddMinutes(_appSettings.Otp.ActiveOtpLifetimeDuration!),
            };

            await _unitOfWork.OtpRepository.CreateAsync(otp);
            await _unitOfWork.SaveChangesAsync();

            new ChangeEmailRequested(user.Username, request.Email, user.Firstname, otp.Code).Enqueue();
        }
    }
}
