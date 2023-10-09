using DotNetStarter.Common;
using DotNetStarter.Database.UnitOfWork;
using DotNetStarter.Entities;
using Microsoft.Data.SqlClient;

namespace DotNetStarter.Queries.Stages.List
{
    public sealed class ListStagesHandler : BaseRequestHandler<ListStages, List<Stage>>
    {
        private readonly IDotNetStarterUnitOfWork _unitOfWork;

        public ListStagesHandler(IServiceProvider serviceProvider, IDotNetStarterUnitOfWork unitOfWork) : base(serviceProvider)
        {
            _unitOfWork = unitOfWork;
        }
        public override async Task<List<Stage>> Process(ListStages request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.StageRepository.ListAsync(
                $"{ClassUtils.GetPropertyName<Stage>(s => s.Order)},{Enum.GetName(typeof(SortOrder), SortOrder.Ascending)}",
                filter: s => s.ProjectId == request.ProjectId);
        }
    }
}
