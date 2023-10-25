using DotNetStarter.Common;
using DotNetStarter.Database.UnitOfWork;
using DotNetStarter.Entities;
using DotNetStarter.Extensions;
using DotNetStarter.Notifications.Users.SentOtp;
using Microsoft.Extensions.Configuration;

namespace DotNetStarter.Commands.Otps.ResendOtp
{
    public sealed class ResendOtpHandler : BaseRequestHandler<ResendOtp>
    {
        private readonly IDotNetStarterUnitOfWork _unitOfWork;

        private readonly IConfiguration _configuration;

        public ResendOtpHandler(
            IServiceProvider serviceProvider,
            IDotNetStarterUnitOfWork unitOfWork,
            IConfiguration configuration
        ) : base(serviceProvider)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
        }
        public override async Task Process(ResendOtp request, CancellationToken cancellationToken)
        {
            var oldOtp = await _unitOfWork.OtpRepository.FindAsync(filter: o => o.Code == request.Code && o.IsUsed == false);

            oldOtp!.IsUsed = true;

            var user = await _unitOfWork.UserRepository.FindAsync(filter: u => u.Id == oldOtp!.UserId);

            var otp = new Otp
            {
                UserId = user!.Id,
                Type = request.Type,
                Code = new Random().Next(0, 1000000).ToString("D6"),
                IsUsed = false,
                ExpiredDate = DateTime.Now.AddMinutes(int.Parse(_configuration["Otp:ActiveOtpLifetimeDuration"]!)),
            };

            await _unitOfWork.OtpRepository.CreateAsync(otp);
            await _unitOfWork.SaveChangesAsync();

            new OtpRenewed(user.Username, user.Firstname, otp.Code).Enqueue();
        }
    }
}
