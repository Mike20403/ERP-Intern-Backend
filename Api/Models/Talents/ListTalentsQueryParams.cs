using Api.Models.Users;

namespace Api.Models.Talents
{
    public class ListTalentsQueryParams : ListUsersQueryParams
    {
        public bool? IsAvailable { get; set; }
    }
}
