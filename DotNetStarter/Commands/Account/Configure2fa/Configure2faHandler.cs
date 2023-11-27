using DotNetStarter.Common;
using DotNetStarter.Database.UnitOfWork;
using DotNetStarter.Entities;
using DotNetStarter.Extensions;
using DotNetStarter.Services.Configuration;
using MediatR;
using Microsoft.Extensions.Options;
using OtpNet;
using QRCoder;

namespace DotNetStarter.Commands.Account.Configure2fa
{
    public sealed class Configure2faHandler : BaseRequestHandler<Configure2fa, Configure2faResponse>
    {
        private readonly IDotNetStarterUnitOfWork _unitOfWork;

        private readonly AppSettings _appSettings;

        private readonly IMediator _mediator;

        public Configure2faHandler
        (
            IDotNetStarterUnitOfWork unitOfWork,
            IOptions<AppSettings> appSettings,
            IMediator mediator,
            IServiceProvider serviceProvider
        ) : base(serviceProvider) 
        { 
            _unitOfWork = unitOfWork;
            _appSettings = appSettings.Value;
            _mediator = mediator;
        }

        public override async Task<Configure2faResponse> Process(Configure2fa request, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.UserRepository.GetByIdAsync(request.UserId);
            user!.Secret = null;
            user!.is2faEnabled = false;

            string? qrCodeImageAsBase64 = null;

            new Revoke2faBackupCode.Revoke2faBackupCode(user.Id).Enqueue();

            if (request.Is2faEnabled)
            {
                user!.Secret = Base32Encoding.ToString(KeyGeneration.GenerateRandomKey(_appSettings.Totp.TotpSecretLength));

                var otpUri = new OtpUri(OtpType.Totp, user.Secret, user.Username, user.Firstname).ToString();

                QRCodeGenerator qrGenerator = new QRCodeGenerator();
                QRCodeData qrCodeData = qrGenerator.CreateQrCode(otpUri, QRCodeGenerator.ECCLevel.Q);
                Base64QRCode qrCode = new Base64QRCode(qrCodeData);
                qrCodeImageAsBase64 = qrCode.GetGraphic(2);
            }

            await _unitOfWork.SaveChangesAsync();

            return new Configure2faResponse(qrCodeImageAsBase64, user.Secret);
        }
    }
}