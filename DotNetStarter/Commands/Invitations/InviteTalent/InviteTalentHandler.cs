using AutoMapper;
using DotNetStarter.Common;
using DotNetStarter.Common.Enums;
using DotNetStarter.Database.UnitOfWork;
using DotNetStarter.Entities;
using DotNetStarter.Notifications.Invitations.TalentInvitation;
using DotNetStarter.Services.Email;
using MediatR;
using Microsoft.Extensions.Configuration;

namespace DotNetStarter.Commands.Invitations.InviteTalent
{
    public sealed class InviteTalentHandler : BaseRequestHandler<InviteTalent, Invitation>
    {
        private readonly IDotNetStarterUnitOfWork _unitOfWork;

        private readonly IConfiguration _configuration;

        private readonly IMapper _mapper;

        private readonly IMediator _mediator;

        public InviteTalentHandler(
            IDotNetStarterUnitOfWork unitOfWork,
            IConfiguration configuration,
            IMapper mapper,
            IMediator mediator,
            IServiceProvider serviceProvider

        ) : base(serviceProvider)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
            _mapper = mapper;
            _mediator = mediator;
        }

        public override async Task<Invitation> Process(InviteTalent request, CancellationToken cancellationToken)
        {
            var talent = await _unitOfWork.TalentRepository.FindAsync(filter: t => t.Id == request.TalentId);
            var inviter = await _unitOfWork.UserRepository.GetByIdAsync(request.InviterId);
            var project = await _unitOfWork.ProjectRepository.GetByIdAsync(request.ProjectId);

            var invitation = new Invitation
            {
                EmailAddress = talent?.Username ?? request.Email, // for invitation via TalentId (null email)
                InvitationStatus = InvitationStatus.Pending
            };

            string? code = null;
            bool isExisting = true;

            if (talent is null)
            {
                var inviteOtp = new Otp
                {
                    UserId = inviter!.Id,
                    Type = OtpType.InviteTalent,
                    Code = new Random().Next(0, 1000000).ToString("D6"),
                    IsUsed = false,
                    ExpiredDate = DateTime.Now.AddMinutes(int.Parse(_configuration["Otp:InvitationOtpLifetimeDuration"]!)),
                };

                code = inviteOtp.Code;
                isExisting = false;

                await _unitOfWork.OtpRepository.CreateAsync(inviteOtp);
            }

            _mapper.Map(request, invitation);
            await _unitOfWork.InvitationRepository.CreateAsync(invitation);
            await _unitOfWork.SaveChangesAsync();

            await _mediator.Publish(new TalentInvited(invitation.EmailAddress!, invitation.Id, project!.Name, inviter!.Firstname, isExisting, code));

            return invitation;
        }
    }
}
