using DotNetStarter.Common.Enums;
using DotNetStarter.Entities;

namespace DotNetStarter.Queries.Talents.List
{
    public sealed class ListTalents : ListRequest<Talent>
    {
        public Gender? Gender { get; }

        public Status? Status { get; }

        public bool? IsAvailable { get; }

        public bool IsAutocomplete { get; }

        public ListTalents(
            int pageNumber,
            int pageSize,
            string? searchQuery,
            string? orderBy,
            Gender? gender,
            Status? status,
            bool? isAvailable,
            bool isAutocomplete
        ) : base(pageNumber, pageSize, searchQuery, orderBy)
        {
            Gender = gender;
            Status = status;
            IsAvailable = isAvailable;
            IsAutocomplete = isAutocomplete;
        }
    }
}
