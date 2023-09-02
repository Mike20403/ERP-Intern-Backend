using DotNetStarter.Common.Enums;
using DotNetStarter.Entities;

namespace DotNetStarter.Queries.Users.List
{
    public sealed class ListUsers : ListRequest<User>
    {
        public Status? Status { get; }

        public ListUsers(int pageNumber, int pageSize, string? searchQuery, Status? status) : base(pageNumber, pageSize, searchQuery)
        {
            Status = status;
        }
    }
}
