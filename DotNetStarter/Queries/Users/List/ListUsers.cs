using DotNetStarter.Common.Enums;
using DotNetStarter.Entities;

namespace DotNetStarter.Queries.Users.List
{
    public sealed class ListUsers : ListRequest<User>
    {
        public List<string>? RoleNames { get; }

        public Gender? Gender { get; }

        public Status? Status { get; }

        public ListUsers(int pageNumber, int pageSize, string? searchQuery, string? orderBy, List<string>? roleNames, Gender? gender, Status? status) : base(pageNumber, pageSize, searchQuery, orderBy)
        {
            RoleNames = roleNames;
            Gender = gender;
            Status = status;
        }
    }
}
