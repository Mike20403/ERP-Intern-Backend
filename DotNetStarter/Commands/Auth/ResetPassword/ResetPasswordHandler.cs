using DotNetStarter.Common;
using DotNetStarter.Database.UnitOfWork;

namespace DotNetStarter.Commands.Auth.ResetPassword
{
    public sealed class ResetPasswordHandler : BaseRequestHandler<ResetPassword>
    {
        private readonly IDotNetStarterUnitOfWork _unitOfWork;

        public ResetPasswordHandler(IServiceProvider serviceProvider, IDotNetStarterUnitOfWork unitOfWork) : base(serviceProvider)
        {
            _unitOfWork = unitOfWork;
        }

        public override async Task Process(ResetPassword request, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.UserRepository.FindAsync(filter: u => u.Username == request.Username);
            user!.Password = BCrypt.Net.BCrypt.HashPassword(request.Password);

            var otp = await _unitOfWork.OtpRepository.FindAsync(filter: o => o.Code == request.Code && o.UserId == user!.Id);
            otp!.IsUsed = true;

            await _unitOfWork.UserRepository.UpdateAsync(user);
            await _unitOfWork.OtpRepository.UpdateAsync(otp);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
