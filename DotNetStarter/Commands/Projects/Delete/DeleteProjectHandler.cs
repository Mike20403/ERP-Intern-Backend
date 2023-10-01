using DotNetStarter.Common;
using DotNetStarter.Database.UnitOfWork;

namespace DotNetStarter.Commands.Projects.Delete
{
    public sealed class DeleteProjectHandler : BaseRequestHandler<DeleteProject>
    {
        private readonly IDotNetStarterUnitOfWork _unitOfWork;

        public DeleteProjectHandler(IServiceProvider serviceProvider, IDotNetStarterUnitOfWork unitOfWork) : base(serviceProvider)
        {
            _unitOfWork = unitOfWork;
        }

        public override async Task Process(DeleteProject request, CancellationToken cancellationToken)
        {
            await _unitOfWork.ProjectRepository.DeleteAsync(request.ProjectId);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
