using DotNetStarter.Common.Enums;

namespace Api.Models.Users
{
    public class ListUsersQueryParams : ListQueryParams
    {
        public Gender? Gender { get; set; }

        public Status? Status { get; set; }
    }
}
