using DotNetStarter.Common.Enums;
using MediatR;

namespace DotNetStarter.Commands.Otps.ResendOtp
{
    public sealed class ResendOtp : IRequest
    {
        public OtpType Type { get; }

        public string Code { get; }

        public ResendOtp(OtpType type, string code)
        {
            Type = type;
            Code = code;
        }
    }
}
