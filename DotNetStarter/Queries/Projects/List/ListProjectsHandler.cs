using DotNetStarter.Common;
using DotNetStarter.Common.Models;
using DotNetStarter.Database.UnitOfWork;
using DotNetStarter.Entities;
using Microsoft.Data.SqlClient;
using System.Linq.Expressions;

namespace DotNetStarter.Queries.Projects.List
{
    public sealed class ListProjectsHandler : BaseRequestHandler<ListProjects, PagedList<Project>>
    {
        private readonly IDotNetStarterUnitOfWork _unitOfWork;

        public ListProjectsHandler(IServiceProvider serviceProvider, IDotNetStarterUnitOfWork unitOfWork) : base(serviceProvider)
        {
            _unitOfWork = unitOfWork;
        }
        public override async Task<PagedList<Project>> Process(ListProjects request, CancellationToken cancellationToken)
        {
            var filter = new List<Expression<Func<Project, bool>>>();

            if (!string.IsNullOrEmpty(request.SearchQuery))
            {
                filter.Add(u => u.Name.Contains(request.SearchQuery));
            }

            if (request.Status != null)
            {
                filter.Add(u => u.Status == request.Status);
            }

            if (request.AgencyMemberId != null)
            {
                filter.Add(u => u.AgencyMemberId == request.AgencyMemberId);
            }

            if (request.ProjectManagerId != null)
            {
                filter.Add(u => u.ProjectManagerId == request.ProjectManagerId);
            }

            return await _unitOfWork.ProjectRepository.GetPagedListAsync(
                $"{ClassUtils.GetPropertyName<Project>(u => u.CreatedDate)},{Enum.GetName(typeof(SortOrder), SortOrder.Descending)}",
                pageNumber: request.PageNumber,
                pageSize: request.PageSize,
                filter: filter.ToArray()
            );
        }
    }
}
