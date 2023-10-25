using AutoMapper;
using DotNetStarter.Common;
using DotNetStarter.Common.Enums;
using DotNetStarter.Database.UnitOfWork;
using DotNetStarter.Entities;
using DotNetStarter.Extensions;
using DotNetStarter.Notifications.Invitations.TalentInvited;
using Microsoft.Extensions.Configuration;

namespace DotNetStarter.Commands.Invitations.InviteTalents
{
    public sealed class InviteTalentsHandler : BaseRequestHandler<InviteTalents, List<Invitation>>
    {
        private readonly IDotNetStarterUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public InviteTalentsHandler(
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

        public override async Task<List<Invitation>> Process(InviteTalents request, CancellationToken cancellationToken)
        {
            var invitations = new List<Invitation>();
            var inviter = await _unitOfWork.UserRepository.GetByIdAsync(request.InviterId);
            var project = await _unitOfWork.ProjectRepository.GetByIdAsync(request.ProjectId);

            foreach (var talentInvitation in request.Talents)
            {
                Talent? talent = null;
                if (talentInvitation.Id.HasValue)
                {
                    talent = await _unitOfWork.TalentRepository.FindAsync(filter: t => t.Id == talentInvitation.Id.Value);
                }

                var email = talentInvitation.Email;

                if (talent == null && !string.IsNullOrEmpty(email))
                {
                    talent = new Talent
                    {
                        Username = email
                    };
                }

                var invitation = new Invitation
                {
                    EmailAddress = talent?.Username,
                    InvitationStatus = InvitationStatus.Pending
                };

                string? code = null;
                bool isExisting = true;

                if (!string.IsNullOrEmpty(email))
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

                _mapper.Map(talentInvitation, invitation);
                _mapper.Map(request, invitation);
                await _unitOfWork.InvitationRepository.CreateAsync(invitation);

                invitations.Add(invitation);

                new TalentInvited(invitation.EmailAddress!, invitation.Id, project!.Name, inviter!.Firstname, isExisting, code).Enqueue();
                new MarkInvitationExpired.MarkInvitationExpired(invitation.Id).Schedule(int.Parse(_configuration["Invitation:LifeTimeDurartion"]!));
            }

            await _unitOfWork.SaveChangesAsync();
            return invitations;
        }
    }
}
