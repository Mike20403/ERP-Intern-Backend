using AutoMapper;
using DotNetStarter.Common;
using DotNetStarter.Common.Enums;
using DotNetStarter.Database.UnitOfWork;
using DotNetStarter.Entities;
using DotNetStarter.Extensions;
using DotNetStarter.Notifications.Invitations.TalentInvited;
using Hangfire;
using Microsoft.Extensions.Configuration;

namespace DotNetStarter.Commands.Invitations.InviteTalent
{
    public sealed class InviteTalentHandler : BaseRequestHandler<InviteTalent, Invitation>
    {
        private readonly IDotNetStarterUnitOfWork _unitOfWork;

        private readonly IConfiguration _configuration;

        private readonly IMapper _mapper;

        public InviteTalentHandler(
            IDotNetStarterUnitOfWork unitOfWork,
            IConfiguration configuration,
            IMapper mapper,
            IServiceProvider serviceProvider

        ) : base(serviceProvider)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
            _mapper = mapper;
        }

        public override async Task<Invitation> Process(InviteTalent request, CancellationToken cancellationToken)
        {
            var talent = await _unitOfWork.TalentRepository.FindAsync(filter: t => t.Id == request.TalentId);
            var inviter = await _unitOfWork.UserRepository.GetByIdAsync(request.InviterId);
            var project = await _unitOfWork.ProjectRepository.GetByIdAsync(request.ProjectId);

            var invitation = new Invitation
            {
                EmailAddress = talent?.Username ?? request.Email, // for invitation via TalentId (null email)
                InvitationStatus = InvitationStatus.Pending,
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
                    ExpiredDate = DateTime.Now.AddMinutes(int.Parse(_configuration["Otp:InvitationOtpLifetimeDuration"]!)),
                    IsUsed = false,
                };

                code = inviteOtp.Code;
                isExisting = false;

                await _unitOfWork.OtpRepository.CreateAsync(inviteOtp);
            }

            _mapper.Map(request, invitation);
            await _unitOfWork.InvitationRepository.CreateAsync(invitation);
            await _unitOfWork.SaveChangesAsync();

            new TalentInvited(invitation.EmailAddress!, invitation.Id, project!.Name, inviter!.Firstname, isExisting, code).Enqueue();

            new MarkInvitationExpired.MarkInvitationExpired(invitation.Id).Schedule(int.Parse(_configuration["Invitation:LifeTimeDurartion"]!)); // Mark invitation expired after 3 days

            return invitation;
        }
    }
}
