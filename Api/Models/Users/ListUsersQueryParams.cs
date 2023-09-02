using DotNetStarter.Common.Enums;

namespace Api.Models.Users
{
    public class ListUsersQueryParams : ListQueryParams
    {
        public Status? Status { get; set; }
    }
}
