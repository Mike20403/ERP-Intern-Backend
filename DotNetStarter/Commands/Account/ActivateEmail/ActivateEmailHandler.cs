﻿using DotNetStarter.Common;
using DotNetStarter.Common.Enums;
using DotNetStarter.Database.UnitOfWork;

namespace DotNetStarter.Commands.Account.ActivateEmail
{
    public sealed class ActivateEmailHandler : BaseRequestHandler<ActivateEmail>
    {
        private readonly IDotNetStarterUnitOfWork _unitOfWork;

        public ActivateEmailHandler(IServiceProvider serviceProvider, IDotNetStarterUnitOfWork unitOfWork) : base(serviceProvider)
        {
            _unitOfWork = unitOfWork;
        }

        public override async Task Process(ActivateEmail request, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.UserRepository.FindAsync(filter: u => u.Username == request.Email);
            var otp = await _unitOfWork.OtpRepository.FindAsync(filter: u => u.Code == request.ActiveCode);

            user!.Status = Status.Active;
            otp!.IsUsed = true;

            await _unitOfWork.UserRepository.UpdateAsync(user);
            await _unitOfWork.OtpRepository.UpdateAsync(otp);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
