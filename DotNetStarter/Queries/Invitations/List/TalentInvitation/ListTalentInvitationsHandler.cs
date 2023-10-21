using DotNetStarter.Common;
using DotNetStarter.Common.Models;
using DotNetStarter.Database.UnitOfWork;
using DotNetStarter.Entities;
using System.Linq.Expressions;

namespace DotNetStarter.Queries.Invitations.List.TalentInvitation
{
    public sealed class ListTalentInvitationsHandler : BaseRequestHandler<ListTalentInvitations, PagedList<Invitation>>
    {
        private readonly IDotNetStarterUnitOfWork _unitOfWork;

        public ListTalentInvitationsHandler(IServiceProvider serviceProvider, IDotNetStarterUnitOfWork unitOfWork) : base(serviceProvider)
        {
            _unitOfWork = unitOfWork;
        }

        public override async Task<PagedList<Invitation>> Process(ListTalentInvitations request, CancellationToken cancellationToken)
        {
            var filter = new List<Expression<Func<Invitation, bool>>>() { i => i.TalentId == request.TalentId };

            if (!string.IsNullOrEmpty(request.SearchQuery))
            {
                filter.Add(
                    i => i.Project!.Name.Contains(request.SearchQuery)
                        || (i.Inviter!.Firstname + " " + i.Inviter!.Lastname).Contains(request.SearchQuery)
                        || i.Inviter!.Username.Contains(request.SearchQuery)
                        || i.EmailAddress!.Contains(request.SearchQuery)
                );
            }

            if (request.InvitationStatus is not null) { 
                filter.Add(i => i.InvitationStatus == request.InvitationStatus);
            }

            return await _unitOfWork.InvitationRepository.GetPagedListAsync(
                request.OrderBy,
                pageNumber: request.PageNumber,
                pageSize: request.PageSize,
                filter: filter.ToArray()
            );
        }
    }
}
