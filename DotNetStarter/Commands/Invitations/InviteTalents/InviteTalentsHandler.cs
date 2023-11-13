using AutoMapper;
using DotNetStarter.Common;
using DotNetStarter.Common.Enums;
using DotNetStarter.Database.UnitOfWork;
using DotNetStarter.Entities;
using DotNetStarter.Extensions;
using DotNetStarter.Notifications.Invitations.TalentInvited;
using DotNetStarter.Services.Configuration;
using Microsoft.Extensions.Options;

namespace DotNetStarter.Commands.Invitations.InviteTalents
{
    public sealed class InviteTalentsHandler : BaseRequestHandler<InviteTalents, List<Invitation>>
    {
        private readonly IDotNetStarterUnitOfWork _unitOfWork;
        private readonly AppSettings _appSettings;
        private readonly IMapper _mapper;

        public InviteTalentsHandler(
            IDotNetStarterUnitOfWork unitOfWork,
            IOptions<AppSettings> appSettings,
            IMapper mapper,
            IServiceProvider serviceProvider
        ) : base(serviceProvider)
        {
            _unitOfWork = unitOfWork;
            _appSettings = appSettings.Value;
            _mapper = mapper;
        }

        public override async Task<List<Invitation>> Process(InviteTalents request, CancellationToken cancellationToken)
        {
            var invitations = new List<Invitation>();
            var inviter = await _unitOfWork.UserRepository.GetByIdAsync(request.InviterId);
            var project = await _unitOfWork.ProjectRepository.GetByIdAsync(request.ProjectId);

            foreach (var talentInvitation in request.Talents)
            {
                Invitation invitation;
                if (talentInvitation.Id.HasValue)
                {
                    var talent = await _unitOfWork.TalentRepository.FindAsync(filter: t => t.Id == talentInvitation.Id.Value);

                    invitation = new Invitation
                    {
                        TalentId = talent?.Id,
                        EmailAddress = talent?.Username,
                        InvitationStatus = InvitationStatus.Pending,
                    };
                }
                else
                {
                    invitation = new Invitation
                    {
                        EmailAddress = talentInvitation.Email,
                        InvitationStatus = InvitationStatus.Pending,
                    };
                }

                string? code = null;
                bool isExisting = true;

                if (!string.IsNullOrEmpty(talentInvitation.Email))
                {
                    var inviteOtp = new Otp
                    {
                        UserId = inviter!.Id,
                        Type = OtpType.InviteTalent,
                        Code = new Random().Next(0, 1000000).ToString("D6"),
                        ExpiredDate = DateTime.Now.AddMinutes(_appSettings.Otp.ActiveOtpLifetimeDuration!),
                        IsUsed = false,
                    };

                    code = inviteOtp.Code;
                    isExisting = false;

                    await _unitOfWork.OtpRepository.CreateAsync(inviteOtp);
                }

                _mapper.Map(request, invitation);
                await _unitOfWork.InvitationRepository.CreateAsync(invitation);

                invitations.Add(invitation);

                new TalentInvited(invitation.EmailAddress!, invitation.Id, project!.Name, project!.Id, inviter!.Firstname, isExisting, code).Enqueue();
                new MarkInvitationExpired.MarkInvitationExpired(invitation.Id).Schedule(_appSettings.Invitation.LifeTimeDurartion);
            }

            await _unitOfWork.SaveChangesAsync();
            return invitations;
        }
    }
}
