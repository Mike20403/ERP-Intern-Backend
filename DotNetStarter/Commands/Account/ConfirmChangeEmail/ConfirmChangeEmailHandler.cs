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

            // Send notification to old email - Send active code to new email
            string message = "Congratulation! you have changed your email, this email will no longer available";
            await _emailService.SendNotificationAsync(request.CurrentEmail, user.Firstname, message);
            await _emailService.SendActivateEmailAsync(request.NewEmail, user.Firstname, request.ActiveCode);
        }
    }
}
