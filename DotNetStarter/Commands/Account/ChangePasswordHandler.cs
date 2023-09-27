using DotNetStarter.Common;
using DotNetStarter.Database.UnitOfWork;
using DotNetStarter.Entities;
using DotNetStarter.Services.Email;

namespace DotNetStarter.Commands.Account
{
    public sealed class ChangePasswordHandler : BaseRequestHandler<ChangePassword>
    {
        private readonly IDotNetStarterUnitOfWork _unitOfWork;

        private readonly IEmailService _emailService;

        public ChangePasswordHandler(IServiceProvider serviceProvider, IDotNetStarterUnitOfWork unitOfWork, IEmailService emailService) : base(serviceProvider)
        {
            _unitOfWork = unitOfWork;
            _emailService = emailService;
        }
        public override async Task Process(ChangePassword request, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.UserRepository.FindAsync(filter: u => u.Id == request.UserId);

            user!.Password = BCrypt.Net.BCrypt.HashPassword(request.NewPassword);
            await _unitOfWork.UserRepository.UpdateAsync(user!);
            await _unitOfWork.SaveChangesAsync();

            await _emailService.SendChangePasswordEmailAsync(user.Username, user.Firstname, user.Lastname);
        }
    }
}
