using DotNetStarter.Common;
using DotNetStarter.Database.UnitOfWork;
using DotNetStarter.Notifications.Users.UserCredentialChanged;
using DotNetStarter.Services.Email;
using MediatR;

namespace DotNetStarter.Commands.Account.ChangePassword
{
    public sealed class ChangePasswordHandler : BaseRequestHandler<ChangePassword>
    {
        private readonly IDotNetStarterUnitOfWork _unitOfWork;

        private readonly IEmailService _emailService;

        private readonly IMediator _mediator;

        public ChangePasswordHandler(
            IServiceProvider serviceProvider, 
            IDotNetStarterUnitOfWork unitOfWork, 
            IEmailService emailService,
            IMediator mediator
        ) : base(serviceProvider)
        {
            _unitOfWork = unitOfWork;
            _emailService = emailService;
            _mediator = mediator;   
        }
        public override async Task Process(ChangePassword request, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.UserRepository.FindAsync(filter: u => u.Id == request.UserId);
            user!.Password = BCrypt.Net.BCrypt.HashPassword(request.NewPassword);
            await _unitOfWork.UserRepository.UpdateAsync(user!);

            await _unitOfWork.SaveChangesAsync();

            await _mediator.Publish(new UserCredentialChanged(user.Id));

            await _emailService.SendChangePasswordEmailAsync(user.Username, user.Firstname, user.Lastname);
        }
    }
}
