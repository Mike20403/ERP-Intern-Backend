using DotNetStarter.Common.Enums;
using MediatR;

namespace DotNetStarter.Notifications.Users.ExportTalentRequested
{
    public sealed class ExportTalentRequested : INotification
    {
        public Guid AdministratorId { get; }

        public int PageNumber { get; }

        public int PageSize { get; }

        public string? SearchQuery { get; }

        public string? OrderBy { get; }

        public Gender? Gender { get; }

        public Status? Status { get; }

        public bool? IsAvailable { get; }

        public ExportTalentRequested(
            Guid administratorId,
            int pageNumber,
            int pageSize,
            string? searchQuery,
            string? orderBy,
            Gender? gender,
            Status? status,
            bool? isAvailable
        )
        {
            AdministratorId = administratorId;
            PageNumber = pageNumber;
            PageSize = pageSize;
            SearchQuery = searchQuery;
            OrderBy = orderBy;
            Gender = gender;
            Status = status;
            IsAvailable = isAvailable;
        }
    }
}
