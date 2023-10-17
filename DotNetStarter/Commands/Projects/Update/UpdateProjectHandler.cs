using AutoMapper;
using DotNetStarter.Common;
using DotNetStarter.Database.UnitOfWork;
using DotNetStarter.Entities;

namespace DotNetStarter.Commands.Projects.Update
{
    public sealed class UpdateProjectHandler : BaseRequestHandler<UpdateProject, Project>
    {
        private readonly IDotNetStarterUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;

        public UpdateProjectHandler(IServiceProvider serviceProvider, IDotNetStarterUnitOfWork unitOfWork, IMapper mapper) : base(serviceProvider)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public override async Task<Project> Process(UpdateProject request, CancellationToken cancellationToken)
        {
            var project = await _unitOfWork.ProjectRepository.FindAsync(ClassUtils.GetPropertyName<Project>(p => p.ProjectManager), p => p.Id == request.ProjectId);

            _mapper.Map(request, project);

            await _unitOfWork.ProjectRepository.UpdateAsync(project!);
            await _unitOfWork.SaveChangesAsync();

            return project!;
        }
    }
}
