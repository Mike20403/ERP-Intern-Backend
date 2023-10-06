using DotNetStarter.Common;
using DotNetStarter.Database.UnitOfWork;
using DotNetStarter.Entities;

namespace DotNetStarter.Queries.Talents.Get
{
    public class GetTalentHandler : BaseRequestHandler<GetTalent, Talent>
    {
        private readonly IDotNetStarterUnitOfWork _unitOfWork;

        public GetTalentHandler(IServiceProvider serviceProvider, IDotNetStarterUnitOfWork unitOfWork) : base(serviceProvider)
        {
            _unitOfWork = unitOfWork;
        }

        public override async Task<Talent> Process(GetTalent request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.TalentRepository.FindAsync(ClassUtils.GetPropertyName<Talent>(u => u.Role), u => u.Id == request.UserId);
        }
    }
}
