using DotNetStarter.Common;
using DotNetStarter.Common.Enums;
using DotNetStarter.Database.UnitOfWork;
using DotNetStarter.Entities;
using DotNetStarter.Services.Email;

namespace DotNetStarter.Commands.Account.ChangeEmailRequires
{
    public sealed class RequestChangeEmailHandler : BaseRequestHandler<RequestChangeEmail>
    {
        private readonly IDotNetStarterUnitOfWork _unitOfWork;

        private readonly IEmailService _emailService;

        public RequestChangeEmailHandler(IServiceProvider serviceProvider, IDotNetStarterUnitOfWork unitOfWork, IEmailService emailService) : base(serviceProvider)
        {
            _unitOfWork = unitOfWork;
            _emailService = emailService;
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
                ExpiredDate = DateTime.Now.AddHours(1),
            };

            await _unitOfWork.OtpRepository.CreateAsync(otp);
            await _unitOfWork.SaveChangesAsync();

            await _emailService.SendChangeEmailRequestAsync(user.Username, request.NewEmail, user.Firstname, otp.Code);
        }
    }
}
