using DotNetStarter.Common;
using DotNetStarter.Common.Enums;
using DotNetStarter.Database.UnitOfWork;
using FluentValidation;

namespace DotNetStarter.Commands.Invitations.RegisterTalent
{
    public sealed class RegisterTalentValidator : AbstractValidator<RegisterTalent>
    {
        public RegisterTalentValidator(IDotNetStarterUnitOfWork unitOfWork)
        {
            RuleFor(x => x.Firstname)
            .NotEmpty();

            RuleFor(x => x.Lastname)
                .NotEmpty();

            RuleFor(x => x.UserName)
                .NotEmpty()
                .EmailAddress()
                .WithMessage("Username must be an email address")
                .MustAsync(async (username, cancellation) =>
                {
                    var isExisted = await unitOfWork.UserRepository.AnyAsync(u => u.Username == username);

                    return !isExisted;
                })
                .WithErrorCode(DomainExceptions.UserAlreadyExists.Code)
                .WithMessage(DomainExceptions.UserAlreadyExists.Message);

            RuleFor(x => x.Password)
                .NotEmpty()
                .Matches(RegexPatterns.Password)
                .WithMessage(DomainExceptions.InvalidPassword.Message);

            RuleFor(x => x.PhoneNumber)
                .NotEmpty()
                .Matches(RegexPatterns.PhoneNumber)
                .WithMessage(DomainExceptions.InvalidPhoneNumber.Message)
                .MustAsync(async (phoneNumber, cancellation) =>
                {
                    var isExisted = await unitOfWork.UserRepository.AnyAsync(u => u.PhoneNumber == phoneNumber);

                    return !isExisted;
                })
                .WithErrorCode(DomainExceptions.PhoneNumberAlreadyExists.Code)
                .WithMessage(DomainExceptions.PhoneNumberAlreadyExists.Message);

            RuleFor(x => x.InvitationId)
                .NotEmpty()
                .MustAsync((request, invitationId, cancellation) => unitOfWork.InvitationRepository
                    .AnyAsync(i => i.Id == invitationId && i.EmailAddress == request.UserName))
                .WithErrorCode(DomainExceptions.InvalidInvitation.Code)
                .WithMessage(DomainExceptions.InvalidInvitation.Message);

            RuleFor(x => x.Code)
                .NotEmpty()
                .MustAsync((invitation, request, cancellation) => unitOfWork.OtpRepository
                    .AnyAsync
                    (
                        o => o.Code == invitation.Code
                            && !o.IsUsed
                            && o.Type == OtpType.InviteTalent 
                            && o.ExpiredDate >= DateTime.Now
                    )
                 )
                .WithErrorCode(DomainExceptions.InvalidOtp.Code)
                .WithMessage(DomainExceptions.InvalidOtp.Message);
        }
    }
}
