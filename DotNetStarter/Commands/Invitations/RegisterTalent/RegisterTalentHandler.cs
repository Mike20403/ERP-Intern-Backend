using AutoMapper;
using DotNetStarter.Common;
using DotNetStarter.Common.Enums;
using DotNetStarter.Database.UnitOfWork;
using DotNetStarter.Entities;
using DotNetStarter.Extensions;
using DotNetStarter.Notifications.Invitations.TalentRegistered;

namespace DotNetStarter.Commands.Invitations.RegisterTalent
{
    public sealed class RegisterTalentHandler : BaseRequestHandler<RegisterTalent>
    {
        private readonly IDotNetStarterUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;

        public RegisterTalentHandler(
            IDotNetStarterUnitOfWork unitOfWork,
            IMapper mapper,
            IServiceProvider serviceProvider

        ) : base(serviceProvider)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public override async Task Process(RegisterTalent request, CancellationToken cancellationToken)
        {
            var role = await _unitOfWork.RoleRepository.FindAsync(ClassUtils.GetPropertyName<Role>(u => u.Privileges), r => r.Name == RoleNames.Talent);

            var otp = await _unitOfWork.OtpRepository.FindAsync
            (
                filter: o => o.Code == request.Code
                            && o.Type == OtpType.InviteTalent
                            && !o.IsUsed
            );
            otp!.IsUsed = true;

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

            new TalentRegistered(request.InvitationId, talent.Id).Enqueue();
        }
    }
}
