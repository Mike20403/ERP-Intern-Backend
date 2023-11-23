using DotNetStarter.Common.Enums;
using MediatR;

namespace DotNetStarter.Commands.Users.Export
{
    public sealed class ExportUser : IRequest
    {
        public Guid AdministratorId { get; }

        public int PageNumber { get; }

        public int PageSize { get; }

        public string? SearchQuery { get; }

        public string? OrderBy { get; }

        public List<string>? RoleNames { get; }

        public Gender? Gender { get; }

        public Status? Status { get; }

        public ExportUser(
            Guid administratorId,
            int pageNumber,
            int pageSize,
            string? searchQuery,
            string? orderBy,
            List<string>? roleNames,
            Gender? gender,
            Status? status
        )
        {
            AdministratorId = administratorId;
            PageNumber = pageNumber;
            PageSize = pageSize;
            SearchQuery = searchQuery;
            OrderBy = orderBy;
            RoleNames = roleNames;
            Gender = gender;
            Status = status;
        }
    }
}
