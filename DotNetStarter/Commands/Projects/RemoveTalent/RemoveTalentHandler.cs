using DotNetStarter.Common;
using DotNetStarter.Database.UnitOfWork;
using DotNetStarter.Entities;

namespace DotNetStarter.Commands.Projects.RemoveTalent
{
    public sealed class RemoveTalentHandler : BaseRequestHandler<RemoveTalent>
    {
        private readonly IDotNetStarterUnitOfWork _unitOfWork;

        public RemoveTalentHandler(IServiceProvider serviceProvider, IDotNetStarterUnitOfWork unitOfWork) : base(serviceProvider)
        {
            _unitOfWork = unitOfWork;
        }

        public override async Task Process(RemoveTalent request, CancellationToken cancellationToken)
        {
            var project = await _unitOfWork.ProjectRepository.FindAsync(ClassUtils.GetPropertyName<Project>(t => t.Talents!), filter: o => o.Id == request.ProjectId);

            project!.Talents = project.Talents!.Where(t => t.Id != request.TalentId).ToList();

            await _unitOfWork.SaveChangesAsync();
        }
    }
}
