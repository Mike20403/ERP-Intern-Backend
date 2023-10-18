using AutoMapper;
using DotNetStarter.Common;
using DotNetStarter.Common.Enums;
using DotNetStarter.Database.UnitOfWork;
using DotNetStarter.Entities;
using DotNetStarter.Notifications.Invitations.AcceptInvitation;
using MediatR;

namespace DotNetStarter.Commands.Invitations.RegisterTalent
{
    public class RegisterTalentHandler : BaseRequestHandler<RegisterTalent>
    {
        private readonly IDotNetStarterUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;

        private readonly IMediator _mediator;

        public RegisterTalentHandler(
            IDotNetStarterUnitOfWork unitOfWork,
            IMapper mapper,
            IMediator mediator,
            IServiceProvider serviceProvider

        ) : base(serviceProvider)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _mediator = mediator;
        }

        public override async Task Process(RegisterTalent request, CancellationToken cancellationToken)
        {
            var role = await _unitOfWork.RoleRepository.FindAsync(ClassUtils.GetPropertyName<Role>(u => u.Privileges), r => r.Name == RoleNames.Talent);

            var talent = new Talent
            {
                RoleId = role!.Id,
                Privileges = role!.Privileges,
                Status = Status.Active
            };

            _mapper.Map(request, talent);
            talent.Password = BCrypt.Net.BCrypt.HashPassword(request.Password);

            await _unitOfWork.TalentRepository.CreateAsync(talent);
            await _unitOfWork.SaveChangesAsync();

            /* 
                 Create new talent with email then: 
                - Update Otps
                - Update Invitation (null TalentId -> new added talentId)
             */
            await _mediator.Publish
            (
                new TalentAccepted
                (
                    request.InvitationId,
                    talent.Id,
                    request.UserName,
                    request.Code
                )
            );
        }
    }
}
