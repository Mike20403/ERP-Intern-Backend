using AutoMapper;
using DotNetStarter.Common;
using DotNetStarter.Database.UnitOfWork;
using DotNetStarter.Entities;

namespace DotNetStarter.Commands.Talents.Update
{
    public sealed class UpdateTalentHandler : BaseRequestHandler<UpdateTalent, Talent>
    {
        private readonly IDotNetStarterUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;

        public UpdateTalentHandler(IServiceProvider serviceProvider, IDotNetStarterUnitOfWork unitOfWork, IMapper mapper) : base(serviceProvider)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public override async Task<Talent> Process(UpdateTalent request, CancellationToken cancellationToken)
        {
            var talent = await _unitOfWork.TalentRepository
                .FindAsync($"{ClassUtils.GetPropertyName<Talent>(t => t.Role!)},{ClassUtils.GetPropertyName<Talent>(t => t.Privileges)}", t => t.Id == request.UserId);

            // TODO: remove not null check
            if (request.PrivilegeNames is not null)
            {
                talent!.Privileges = await _unitOfWork.PrivilegeRepository.ListAsync(filter: p => request.PrivilegeNames!.Contains(p.Name));
            }

            _mapper.Map(request, talent);

            await _unitOfWork.TalentRepository.UpdateAsync(talent!);
            await _unitOfWork.SaveChangesAsync();

            return talent!;
        }
    }
}
