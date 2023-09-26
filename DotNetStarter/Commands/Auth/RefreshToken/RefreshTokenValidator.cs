using DotNetStarter.Common;
using DotNetStarter.Database.UnitOfWork;
using FluentValidation;

namespace DotNetStarter.Commands.Auth.RefreshToken
{
    public sealed class RefreshTokenValidator : AbstractValidator<RefreshToken>
    {
        public RefreshTokenValidator(IDotNetStarterUnitOfWork unitOfWork)
        {
            RuleFor(x => x.UserId)
                .NotEmpty();

            RuleFor(x => x.TokenId)
                .NotEmpty();

            RuleFor(x => x.Secret)
                .NotEmpty();

            RuleFor(x => x)
                .NotEmpty()
                .MustAsync((request, cancellation) => unitOfWork.AuthTokenRepository.AnyAsync(rt =>
                    rt.Secret == request.Secret
                    && rt.TokenId == request.TokenId
                    && rt.UserId == request.UserId
                    && !rt.IsUsed
                    && rt.ExpiredDate >= DateTime.Now))
                .WithErrorCode(DomainExceptions.InvalidAuthToken.Code)
                .WithMessage(DomainExceptions.InvalidAuthToken.Message);
        }
    }
}