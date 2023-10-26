using AutoMapper;
using DotNetStarter.Common;
using DotNetStarter.Database.UnitOfWork;
using DotNetStarter.Entities;

namespace DotNetStarter.Queries.TalentsOfAProject.List
{
    public sealed class ListProjectTalentsHandler : BaseRequestHandler<ListProjectTalents, List<User>>
    {
        private readonly IDotNetStarterUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ListProjectTalentsHandler(IServiceProvider serviceProvider, IDotNetStarterUnitOfWork unitOfWork, IMapper mapper) : base(serviceProvider)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public override async Task<List<User>> Process(ListProjectTalents request, CancellationToken cancellationToken)
        {
            var talents = await _unitOfWork.TalentRepository.ListAsync(filter: t => t.Projects!.Any(p => p.Id == request.ProjectId));

            return _mapper.Map<List<User>>(talents);
        }
    }
}
