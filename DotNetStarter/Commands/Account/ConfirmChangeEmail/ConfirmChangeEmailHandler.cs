using DotNetStarter.Common;
using DotNetStarter.Common.Enums;
using DotNetStarter.Database.UnitOfWork;
using DotNetStarter.Services.Email;

namespace DotNetStarter.Commands.Account.ConfirmChangeEmail
{
    public sealed class ConfirmChangeEmailHandler : BaseRequestHandler<ConfirmChangeEmail>
    {
        private readonly IDotNetStarterUnitOfWork _unitOfWork;

        private readonly IEmailService _emailService;

        public ConfirmChangeEmailHandler(IServiceProvider serviceProvider, IDotNetStarterUnitOfWork unitOfWork, IEmailService emailService) : base(serviceProvider)
        {
            _unitOfWork = unitOfWork;
            _emailService = emailService;
        }

        public override async Task Process(ConfirmChangeEmail request, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.UserRepository.
                FindAsync(filter: u => u.Username == request.CurrentEmail);
            
            var otp = await _unitOfWork.OtpRepository.
                FindAsync(filter: o => o.Code == request.ActiveCode && o.UserId == user!.Id);

            if(otp == null) // There aren't any otp match with current user
            {
                return;
            }

            user!.Username = request.NewEmail;
            user!.Status = Status.Inactive;

            await _unitOfWork.UserRepository.UpdateAsync(user!);
            await _unitOfWork.SaveChangesAsync();


            // Code used for send notification to old email, will be used soon (when config SendGrid template)
            //await _emailService.SendEmailAsync(request.CurrentEmail, "", new Dictionary<string, string>
            //{
            //    { "message", "You have confirmed to change email successfully" }
            //});
            await _emailService.SendActivateEmailAsync(request.NewEmail, request.ActiveCode);
        }
    }
}
