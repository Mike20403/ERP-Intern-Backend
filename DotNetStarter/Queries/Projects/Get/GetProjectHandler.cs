using DotNetStarter.Common;
using DotNetStarter.Database.UnitOfWork;
using DotNetStarter.Entities;

namespace DotNetStarter.Queries.Projects.Get
{
    public sealed class GetProjectHandler : BaseRequestHandler<GetProject, Project>
    {
        private readonly IDotNetStarterUnitOfWork _unitOfWork;

        public GetProjectHandler(IServiceProvider serviceProvider, IDotNetStarterUnitOfWork unitOfWork) : base(serviceProvider)
        {
            _unitOfWork = unitOfWork;
        }
        public override async Task<Project> Process(GetProject request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.ProjectRepository.FindAsync(ClassUtils.GetPropertyName<Project>(p => p.ProjectManager), p => p.Id == request.ProjectId);
        }
    }
}
