using AutoMapper;
using DotNetStarter.Common;
using DotNetStarter.Common.Enums;
using DotNetStarter.Database.UnitOfWork;
using DotNetStarter.Entities;

namespace DotNetStarter.Commands.Projects.Create
{
    public sealed class CreateProjectHandler : BaseRequestHandler<CreateProject, Project>
    {
        private readonly IDotNetStarterUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;

        public CreateProjectHandler(IServiceProvider serviceProvider, IDotNetStarterUnitOfWork unitOfWork, IMapper mapper) : base(serviceProvider)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public override async Task<Project> Process(CreateProject request, CancellationToken cancellationToken)
        {
            var project = new Project
            {
                Name = request.Name,
                Status = ProjectStatus.Created,
                AgencyMemberId = request.AgencyMemberId,
            };

            _mapper.Map(request, project);

            await _unitOfWork.ProjectRepository.CreateAsync(project);
            await _unitOfWork.SaveChangesAsync();
            return project;
        }
    }
}
