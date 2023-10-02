using DotNetStarter.Common;
using DotNetStarter.Common.Models;
using DotNetStarter.Database.UnitOfWork;
using DotNetStarter.Entities;
using Microsoft.Data.SqlClient;
using System.Linq.Expressions;

namespace DotNetStarter.Queries.Users.List
{
    public sealed class ListUsersHandler : BaseRequestHandler<ListUsers, PagedList<User>>
    {
        private readonly IDotNetStarterUnitOfWork _unitOfWork;

        public ListUsersHandler(IServiceProvider serviceProvider, IDotNetStarterUnitOfWork unitOfWork) : base(serviceProvider)
        {
            _unitOfWork = unitOfWork;
        }

        public override async Task<PagedList<User>> Process(ListUsers request, CancellationToken cancellationToken)
        {
            var filter = new List<Expression<Func<User, bool>>>();

            if (!string.IsNullOrEmpty(request.SearchQuery))
            {
                filter.Add(u => u.Username.Contains(request.SearchQuery)
                                || u.Firstname.Contains(request.SearchQuery)
                                || u.Lastname.Contains(request.SearchQuery)
                                || u.PhoneNumber.Contains(request.SearchQuery));
            }

            if (request.RoleNames?.Count > 0)
            {
                var roles = await _unitOfWork.RoleRepository.ListAsync(filter: r => request.RoleNames.Contains(r.Name));

                var roleIds = roles.Select(r => r.Id);
                filter.Add(u => roleIds.Contains(u.RoleId!.Value));
            }

            if (request.Gender != null)
            {
                filter.Add(u => u.Gender == request.Gender);
            }

            if (request.Status != null)
            {
                filter.Add(u => u.Status == request.Status);
            }

            return await _unitOfWork.UserRepository.GetPagedListAsync(
                $"{ClassUtils.GetPropertyName<User>(u => u.CreatedDate)},{Enum.GetName(typeof(SortOrder), SortOrder.Descending)}",
                ClassUtils.GetPropertyName<User>(u => u.Role),
                pageNumber: request.PageNumber,
                pageSize: request.PageSize,
                filter: filter.ToArray()
            );
        }
    }
}
