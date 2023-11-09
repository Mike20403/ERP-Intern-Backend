using DotNetStarter.Common;
using DotNetStarter.Database.UnitOfWork;
using DotNetStarter.Entities;

namespace DotNetStarter.Queries.Talents.Get
{
    public sealed class GetTalentHandler : BaseRequestHandler<GetTalent, Talent>
    {
        private readonly IDotNetStarterUnitOfWork _unitOfWork;

        public GetTalentHandler(IServiceProvider serviceProvider, IDotNetStarterUnitOfWork unitOfWork) : base(serviceProvider)
        {
            _unitOfWork = unitOfWork;
        }

        public override async Task<Talent> Process(GetTalent request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.TalentRepository.FindAsync($"{ClassUtils.GetPropertyName<Talent>(t => t.Role)},{ClassUtils.GetPropertyName<Talent>(t => t.Privileges)}", t => t.Id == request.UserId);
        }
    }
}
